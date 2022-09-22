using Amazon.S3;
using Explorer.Models;
using Amazon.S3.Model;
using System.Text.Json;
using Explorer.Classes;
using System.Runtime.InteropServices;

namespace Explorer;

public partial class Main : Form
{
    private const string AesKey = "Uk4T0f9mpc7XuAsHgrO223zgrwvR8taAyzFZWoXLyGg=";
    private const string AesIV = "mLGwr8pbunnyrt6vz0NcTg==";
    private const string SettingsFileName = "Settings.json";
    private const string LogFileName = "Log.txt";

    private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

    private IAmazonS3? S3Client { get; set; }
    private Models.Settings? Settings { get; set; }
    private Models.Folder? Folder { get; set; }
    private NativeMethods.SHFILEINFO shfi;

    public Main()
    {
        InitializeComponent();
    }

    private void Main_Load( object sender, EventArgs e )
    {
        this.LoadSettings();

        this.shfi = new NativeMethods.SHFILEINFO();

        // Obtain a handle to the system image list.
        IntPtr hSysImgList = NativeMethods.SHGetFileInfo( "", 0, ref this.shfi, (uint)Marshal.SizeOf( this.shfi ), NativeMethods.SHGFI_SYSICONINDEX | NativeMethods.SHGFI_SMALLICON );

        // Set the ListView control to use that image list.
        IntPtr hOldImgList = NativeMethods.SendMessage( this.treeView.Handle, (uint)NativeMethods.TVM.SETIMAGELIST, 0, hSysImgList );

        // If the ListView control already had an image list, delete the old one.
        if( hOldImgList != IntPtr.Zero ) NativeMethods.ImageList_Destroy( hOldImgList );

        this.cbFolder.Items.Clear();
        if( this.Settings == null ) return;
        this.cbFolder.Items.AddRange( this.Settings.Folders.ToArray() );

        if( this.Settings.Folders.Count == 1 )
        {
            this.cbFolder.SelectedIndex = 0;
        }
    }

    private void tbAddFolder_Click( object sender, EventArgs e )
    {
        var d = new FolderDialog() { StartPosition = FormStartPosition.CenterParent };
        if( d.ShowDialog() != DialogResult.OK || d.Folder == null ) return;

        if( this.Settings == null ) return;
        this.Settings.Folders.Add( d.Folder );
        this.SaveSettings();

        this.cbFolder.Items.Add( d.Folder );
        this.cbFolder.SelectedItem = d.Folder;
        this.cbFolder_SelectedIndexChanged();
    }

    private async void cbFolder_SelectedIndexChanged( object? sender = null, EventArgs? e = null )
    {
        await this.LoadRemoteFiles( false );
    }

    private async Task LoadRemoteFiles( bool RestoreState )
    {
        this.Folder = this.cbFolder.SelectedItem as Models.Folder;
        if( this.Folder == null ) return;

        var state = this.treeView.Nodes.GetExpansionState();

        this.label4.Visible = this.Folder.DatFile;
        this.label5.Visible = this.Folder.DatFile;
        this.txtComments.Visible = this.Folder.DatFile;
        this.txtHistory.Visible = this.Folder.DatFile;
        this.btnSaveComments.Visible = this.Folder.DatFile;

        this.Log( "Loading remote file list: " + this.Folder.Bucket );
        this.lblStatus.Text = $"Loading remote files from {this.Folder.Bucket}...";
        this.pbProgress.Value = 0;

        if( this.S3Client != null ) this.S3Client.Dispose();
        var region = Amazon.RegionEndpoint.GetBySystemName( this.Folder.Region );
        this.S3Client = new AmazonS3Client( this.Folder.AwsAccessKey, this.Folder.AwsSecretKey, region );

        this.treeView.Nodes.Clear();
        await foreach( var m in S3Client.GetObjects( this.Folder.Bucket, this.Folder.Prefix ) )
        {
            if( this.Folder.DatFile )
            {
                var name = m.Key.Split( "/" ).Last();
                if( name.StartsWith( "_" ) && name.EndsWith( ".dat" ) ) continue;
            }

            AddObject( m );
        }

        this.treeView.Sort();

        this.lblStatus.Text = $"All files loaded from {this.Folder.Bucket}";
        this.pbProgress.Value = this.pbProgress.Maximum;

        if( RestoreState )
        {
            this.treeView.Nodes.SetExpansionState( state );
        }
    }

    private void Main_ResizeEnd( object sender, EventArgs e )
    {
        var changed = false;
        if( this.Settings == null ) return;

        if( this.Settings.WindowWidth != this.Width )
        {
            this.Settings.WindowWidth = this.Width;
            changed = true;
        }

        if( this.Settings.WindowHeight != this.Height )
        {
            this.Settings.WindowHeight = this.Height;
            changed = true;
        }

        if( changed )this.SaveSettings();
    }

    private void tbSettings_Click( object sender, EventArgs e )
    {
        this.Settings ??= new Settings();
        var d = new SettingsDialog( this.Settings ) { StartPosition = FormStartPosition.CenterParent };
        if( d.ShowDialog() != DialogResult.OK || d.Settings == null ) return;
        this.SaveSettings();
    }

    private void tbFontIncrease_Click( object sender, EventArgs e )
    {
        this.SetFontSize( this.treeView.Font.Size + 1 );
        this.SaveSettings();
    }

    private void tbFontDecrease_Click( object sender, EventArgs e )
    {
        this.SetFontSize( this.treeView.Font.Size - 1 );
        this.SaveSettings();
    }

    private async void tbSync_Click( object sender, EventArgs e )
    {
        await this.LoadRemoteFiles( true );
    }

    private void tbViewLogs_Click( object sender, EventArgs e )
    {
        var fullPath = !string.IsNullOrEmpty( this.Settings?.LogFilePath )
            ? Path.Combine( this.Settings.LogFilePath, LogFileName )
            : LogFileName;

        if( !File.Exists( fullPath ) ) return;

        System.Diagnostics.Process.Start( "notepad.exe", fullPath );
    }

    private void splitContainer_SplitterMoved( object sender, SplitterEventArgs e )
    {
        if( this.Settings == null ) return;
        this.Settings.TreeViewWidth = this.splitContainer.SplitterDistance;
        this.SaveSettings();
    }

    private async void treeView_AfterSelect( object sender, TreeViewEventArgs e )
    {
        if( e.Node == null ) return;

        if( e.Node.Nodes.Count == 0 )
        {
            if( e.Node.Tag is not S3Object obj ) return;

            this.lblKey.Text = obj.Key;
            this.lblSize.Text = SizeSuffix( obj.Size ) + $"   ({obj.Size:N0} byes)";
            this.lblModified.Text = obj.LastModified.ToString( "G" );
            this.txtComments.Text = this.txtHistory.Text = null;

            if( this.S3Client != null && this.Folder != null && this.Folder.DatFile )
            {
                try
                {
                    var metaData = await this.GetMetaData( obj.Key );

                    this.txtComments.Text = metaData?.Comments;

                    if( metaData?.History != null )
                    {
                        var h = metaData.History.OrderByDescending( m => m.Timestamp ).ToList();
                        this.txtHistory.Text = string.Join( Environment.NewLine + Environment.NewLine, h );
                    }
                }
                catch
                {
                    // The file might not exist
                }
            }
        }
        else
        {
        }
    }

    private void treeView_MouseUp( object sender, MouseEventArgs e )
    {
        if( e.Button == MouseButtons.Right )
        {
            this.treeView.SelectedNode = this.treeView.GetNodeAt( e.X, e.Y );

            if( this.treeView.SelectedNode != null )
            {
                this.treeViewContextMenu.Show( this.treeView, e.Location );
            }
        }
    }

    private async void treeViewNodeDelete_Click( object sender, EventArgs e )
    {
        if( this.S3Client == null ) return;

        var confirmResult = MessageBox.Show( "Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo );
        if( confirmResult != DialogResult.Yes ) return;

        async Task DeleteFolder( TreeNode node )
        {
            this.Log( "Deleting all files with a prefix '" + node.Tag.ToString() + "'" );

            for( var n = node.FirstNode ; n != null ; n = n.NextNode )
            {
                if( n.Nodes.Count > 0 )
                {
                    await DeleteFolder( n );
                }
                else
                {
                    await DeleteFile( n );
                }
            }
        }

        async Task DeleteFile( TreeNode node )
        {
            if( this.Folder == null ) return;
            if( node.Tag is not S3Object s3Object ) return;
            this.Log( "Deleting key '" + s3Object.Key + "'" );
            await this.S3Client.DeleteAsync( this.Folder.Bucket, s3Object.Key, null );

            if( !this.Folder.DatFile ) return;

            // Delete the .dat file
            var datKey = GetDatFileKey( s3Object.Key );
            await this.S3Client.DeleteAsync( this.Folder.Bucket, datKey, null );
        }

        if( this.treeView.SelectedNode.Tag is S3Object s3Object )
        {
            await DeleteFile( this.treeView.SelectedNode );
        }
        else if( this.treeView.SelectedNode.Tag is string prefix )
        {
            await DeleteFolder( this.treeView.SelectedNode );
        }

        if( this.treeView.SelectedNode?.Parent?.Nodes != null )
        {
            this.treeView.SelectedNode.Parent.Nodes.Remove( this.treeView.SelectedNode );
        }
        else
        {
            this.treeView.Nodes.Remove( this.treeView.SelectedNode );
        }
    }

    private async void treeViewNodeRename_Click( object sender, EventArgs e )
    {
        if( this.Settings == null || this.S3Client == null || this.Folder == null ) return;

        var d = new RenameDialog( this.treeView.SelectedNode.Text ) { StartPosition = FormStartPosition.CenterParent };
        if( d.ShowDialog() != DialogResult.OK ) return;

        List<string> GetKeys( TreeNode node )
        {
            var keys = new List<string>();

            for( var n = node.FirstNode ; n != null ; n = n.NextNode )
            {
                if( n.Nodes.Count > 0 )
                {
                    keys.AddRange( GetKeys( n ) );
                }
                else
                {
                    keys.Add( GetKey( n ) );
                }
            }

            return keys;
        }

        string GetKey( TreeNode node )
        {
            var key = node.FullPath;
            if( !string.IsNullOrWhiteSpace( this.Folder?.Prefix ) )
            {
                key = this.Folder.Prefix + key;
            }
            return key;
        }

        var RenameKeys = new List<(string, string)>();

        if( this.treeView.SelectedNode.Tag is S3Object s3Object )
        {
            var CurrentKey = GetKey( this.treeView.SelectedNode );
            this.treeView.SelectedNode.Text = d.Name;
            var NewKey = GetKey( this.treeView.SelectedNode );

            RenameKeys.Add( (CurrentKey, NewKey) );

            s3Object.Key = NewKey;
            this.lblKey.Text = NewKey;
        }
        else if( this.treeView.SelectedNode.Tag is string prefix )
        {
            var CurrentKeys = GetKeys( this.treeView.SelectedNode );
            this.treeView.SelectedNode.Text = d.Name;
            var NewKeys = GetKeys( this.treeView.SelectedNode );

            RenameKeys.AddRange( CurrentKeys.Zip( NewKeys ) );
        }

        foreach( var tuple in RenameKeys )
        {
            this.Log( $"Renaming '{tuple.Item1}' to '{tuple.Item2}'" );

            Task task = this.S3Client.CopyObjectAsync
            (
                this.Folder.Bucket,
                tuple.Item1,
                this.Folder.Bucket,
                tuple.Item2
            );

            task = task.ContinueWith( t => this.S3Client.DeleteAsync( this.Folder.Bucket, tuple.Item1, null ) );

            if( this.Folder.DatFile )
            {
                var datKey1 = GetDatFileKey( tuple.Item1 );
                var datKey2 = GetDatFileKey( tuple.Item2 );

                task = task.ContinueWith( async t =>
                {
                    var metaData = await this.GetMetaData( datKey1 );
                    metaData.History.Add( new FileHistory( this.Settings.UserName ?? "Unknown", "Renamed" )
                    {
                        Details = $"Renamed from '{tuple.Item1}' to '{tuple.Item2}'."
                    } );

                    var json = JsonSerializer.Serialize( metaData );

                    await this.S3Client.PutObjectAsync( new PutObjectRequest
                    {
                        ContentType = "application/json",
                        BucketName = this.Folder.Bucket,
                        ContentBody = json,
                        Key = datKey2,
                    } );
                } );

                task = task.ContinueWith( t => this.S3Client.DeleteAsync( this.Folder.Bucket, datKey1, null ) );
            }

            await task;
        }
    }

    private void treeViewNodeShare_Click( object sender, EventArgs e )
    {
        if( this.Settings == null || this.S3Client == null || this.Folder == null ) return;

        if( this.treeView.SelectedNode == null || this.treeView.SelectedNode.Nodes.Count > 0 )
        {
            MessageBox.Show( this, "Only individual files can be shared.", "Cannot Share", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

        if( this.treeView.SelectedNode.Tag is not S3Object s3Object ) return;

        var d = new ShareDialog( s3Object, this.Folder, this.S3Client ) { StartPosition = FormStartPosition.CenterParent };
        if( d.ShowDialog() != DialogResult.OK ) return;
    }

    private async void treeViewNodeDownload_Click( object sender, EventArgs e )
    {
        if( this.Settings == null || this.S3Client == null || this.Folder == null ) return;

        var nodePath = this.treeView.SelectedNode.FullPath;
        if( this.Folder.Links.Any( m => m.Prefix.StartsWith( nodePath ) ) )
        {
            var result = MessageBox.Show( this, "One or more files or sub directories already has a local link. Creating a new one will override the existing links.", "Duplicate Local Link", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning );
            if( result != DialogResult.OK ) return;
        }

        var d = new DownloadDialog() { StartPosition = FormStartPosition.CenterParent };
        if( d.ShowDialog() != DialogResult.OK ) return;

        if( this.Folder.Links.Any( m => m.Path.StartsWith( d.Directory ) ) )
        {
            MessageBox.Show( this, "Sorry, that directory contains a directory or file that already has a local link. Please choose a different destination directory.", "Cannot Create Local Link", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

        var fullPath = d.Directory;
        if( this.treeView.SelectedNode.Tag is string s )
        {
            // If the node is a folder, add the folder name to the destination path
            fullPath = Path.Combine( fullPath, this.treeView.SelectedNode.Text );
        }

        var link = new LocalLink( this.Folder.Prefix + nodePath, fullPath )
        {
            Upload = d.Upload,
            Download = d.Download,
        };

        if( link.Download || link.Upload )
        {
            this.Folder.Links.Add( link );
        }

        await this.SyncDown( link );
    }

    private void treeView_DragEnter( object sender, DragEventArgs e )
    {
        e.Effect = this.Folder == null ? DragDropEffects.None : DragDropEffects.All;
    }

    private TreeNode? lastDragDestination = null;
    private DateTime lastDragDestinationTime = default;

    private void treeView_DragOver( object sender, DragEventArgs e )
    {
        var targetPoint = this.treeView.PointToClient( new Point( e.X, e.Y ) );
        var node = this.treeView.GetNodeAt( targetPoint );

        this.treeView.Scroll();

        if( node.PrevVisibleNode != null )
        {
            node.PrevVisibleNode.BackColor = Color.Empty;
        }
        if( node.NextVisibleNode != null )
        {
            node.NextVisibleNode.BackColor = Color.Empty;
        }

        if( node.Nodes.Count == 0 ) return;

        node.BackColor = Color.Gray;

        if( node != lastDragDestination )
        {
            lastDragDestination = node;
            lastDragDestinationTime = DateTime.Now;
        }
        else
        {
            var hoverTime = DateTime.Now.Subtract( lastDragDestinationTime );
            if( hoverTime.TotalSeconds > 1.0 ) node.Expand();
        }
    }

    private async void treeView_DragDrop( object sender, DragEventArgs e )
    {
        if( e.Data == null || this.Folder == null || this.S3Client == null ) return;

        var point = this.treeView.PointToClient( new Point( e.X, e.Y ) );
        var node = this.treeView.GetNodeAt( point );

        var prefix = this.Folder.Prefix;

        if( node != null )
        {
            if( node.Nodes.Count > 0 )
            {
                prefix += node.FullPath;
            }
            else
            {
                prefix += string.Join( "/", node.FullPath.Split( "/" ).SkipLast( 1 ) );
            }

            if( !string.IsNullOrEmpty( prefix ) && !prefix.EndsWith( "/" ) )
            {
                prefix += "/";
            }
        }

        var objects = new List<(string, string)>();
        var paths = (string[])e.Data.GetData( DataFormats.FileDrop );

        foreach( var path in paths )
        {
            if( Directory.Exists( path ) )
            {
                var tempPrefix = prefix + Path.GetFileName( path );
                var files = Directory.GetFiles( path, "*.*", new EnumerationOptions { RecurseSubdirectories = true } );

                foreach( var file in files )
                {
                    var relativePath = file.Substring( path.Length );
                    var key = tempPrefix + relativePath.Replace( "\\", "/" );
                    objects.Add( (file, key) );
                }
            }
            else if( File.Exists( path ) )
            {
                var key = prefix + Path.GetFileName( path );
                objects.Add( (path, key) );
            }
        }

        this.pbProgress.Value = 0;
        this.pbProgress.Minimum = 0;
        this.pbProgress.Maximum = objects.Count;

        foreach( var m in objects )
        {
            this.Log( $"Uploading file from '{m.Item1}' to '{m.Item2}'" );
            this.lblStatus.Text = $"Uploading {m.Item1}";

            await this.CreateFile( m.Item2, m.Item1 );

            var info = new FileInfo( m.Item1 );
            this.AddObject( new S3Object { Key = m.Item2, Size = info.Length, LastModified = DateTime.Now } );

            this.pbProgress.Value++;
        }

        this.treeView.Sort();
        this.lblStatus.Text = $"All files uploaded";
        this.pbProgress.Value = this.pbProgress.Maximum;
    }

    private void cbFolder_KeyUp( object sender, KeyEventArgs e )
    {
        if( sender is not ComboBox cb ) return;
        if( cb.SelectedItem is not Models.Folder folder ) return;

        if( e.KeyCode == Keys.Delete )
        {
            cb.Items.Remove( folder );

            if( this.Settings != null )
            {
                this.Settings.Folders.Remove( folder );
                this.SaveSettings();
            }

            if( this.Folder != null && this.Folder == folder )
            {
                this.Folder = null;
                cb.SelectedItem = null;
                this.treeView.Nodes.Clear();
            }
        }
        else if( e.KeyValue == 192 )
        {
            var d = new FolderDialog( folder ) { StartPosition = FormStartPosition.CenterParent };
            if( d.ShowDialog() != DialogResult.OK || d.Folder == null ) return;
            this.SaveSettings();
        }
    }

    private async void btnSaveComments_Click( object sender, EventArgs e )
    {
        if( this.S3Client == null || this.Folder == null ) return;
        if( this.treeView.SelectedNode?.Tag is not S3Object obj ) return;

        this.lblStatus.Text = "Saving comments...";
        this.pbProgress.Value = 0;

        try
        {
            FileMetaData? metaData = null;
            var datKey = GetDatFileKey( obj.Key );

            try
            {
                using var stream = await this.S3Client.GetObjectStreamAsync( this.Folder.Bucket, datKey, null );
                using var jsonReader = new StreamReader( stream );
                metaData = JsonSerializer.Deserialize<FileMetaData>( jsonReader.ReadToEnd() );
            }
            catch
            {
                // The file might not exist
            }

            metaData ??= new FileMetaData();
            metaData.Comments = this.txtComments.Text;

            var json = JsonSerializer.Serialize( metaData,  new JsonSerializerOptions { WriteIndented = true } );
            await this.S3Client.PutObjectAsync( new PutObjectRequest
            {
                ContentType = "application/json",
                BucketName = this.Folder.Bucket,
                ContentBody = json,
                Key = datKey,
            } );

            this.lblStatus.Text = "Comments saved";
            this.pbProgress.Value = this.pbProgress.Maximum;
        }
        catch( Exception ex )
        {
            this.HandleException( "Could not save file meta data.", ex );
        }
    }

    private void LoadSettings()
    {
        this.lblStatus.Text = "Loading settings...";
        this.pbProgress.Value = 0;

        if( File.Exists( SettingsFileName ) )
        {
            var json = File.ReadAllText( SettingsFileName );
            this.Settings = JsonSerializer.Deserialize<Models.Settings>( json );

            if( this.Settings != null )
            {
                var iv = Convert.FromBase64String( AesIV );
                var key = Convert.FromBase64String( AesKey );

                foreach( var f in this.Settings.Folders )
                {
                    if( !string.IsNullOrWhiteSpace( f.AwsAccessKey ) )
                    {
                        f.AwsAccessKey = Classes.Encryption.decrypt( Convert.FromBase64String( f.AwsAccessKey ), key, iv );
                    }

                    if( !string.IsNullOrWhiteSpace( f.AwsSecretKey ) )
                    {
                        f.AwsSecretKey = Classes.Encryption.decrypt( Convert.FromBase64String( f.AwsSecretKey ), key, iv );
                    }
                }

                if( this.Settings.WindowWidth > 0 ) this.Width = this.Settings.WindowWidth;
                if( this.Settings.WindowHeight > 0 ) this.Height = this.Settings.WindowHeight;
                if( this.Settings.TreeViewWidth > 0 ) this.splitContainer.SplitterDistance = this.Settings.TreeViewWidth;
                //if( this.Settings.FontSize > 0 ) this.SetFontSize( this.Settings.FontSize );
                this.SetFontSize( 9 );

                Log( "Settings loaded" );
            }
        }

        this.lblStatus.Text = "Settings loaded";
        this.pbProgress.Value = this.pbProgress.Maximum;

        this.Settings ??= new Models.Settings();
        if( string.IsNullOrWhiteSpace( this.Settings.UserName ) ) this.tbSettings.PerformClick();
    }

    private void SaveSettings()
    {
        if( this.Settings == null ) return;

        this.lblStatus.Text = "Saving settings...";
        this.pbProgress.Value = 0;

        var clone = this.Settings.Clone();
        clone.WindowWidth = this.Width;
        clone.WindowHeight = this.Height;
        clone.TreeViewWidth = this.splitContainer.SplitterDistance;
        clone.FontSize = this.treeView.Font.Size;

        var iv = Convert.FromBase64String( AesIV );
        var key = Convert.FromBase64String( AesKey );

        foreach( var f in clone.Folders )
        {
            if( !string.IsNullOrWhiteSpace( f.AwsAccessKey ) )
            {
                f.AwsAccessKey = Convert.ToBase64String( Classes.Encryption.encrypt( f.AwsAccessKey, key, iv ) );
            }

            if( !string.IsNullOrWhiteSpace( f.AwsSecretKey ) )
            {
                f.AwsSecretKey = Convert.ToBase64String( Classes.Encryption.encrypt( f.AwsSecretKey, key, iv ) );
            }
        }

        var json = JsonSerializer.Serialize( clone, new JsonSerializerOptions
        {
            WriteIndented = true
        } );

        File.WriteAllText( SettingsFileName, json );

        Log( "Settings saved" );
        this.lblStatus.Text = "Settings saved";
        this.pbProgress.Value = this.pbProgress.Maximum;
    }

    private void Log( string Message, Exception? ex = null )
    {
        var lines = new List<string>();

        if( ex != null )
        {
            for( var m = ex ; m != null ; m = m.InnerException )
            {
                lines.Insert( 0, m.Message );
            }

            if( !string.IsNullOrWhiteSpace( ex.StackTrace ) )
            {
                lines.AddRange( ex.StackTrace.Split( Environment.NewLine ) );
            }
        }

        var d = DateTime.Now;
        lines.Insert( 0, Message );
        lines = lines.Select( m => d.ToString( "yyyy-MM-dd HH:mm:ss" ) + "> " + m ).ToList();

        var fullPath = !string.IsNullOrEmpty( this.Settings?.LogFilePath )
            ? Path.Combine( this.Settings.LogFilePath, LogFileName )
            : LogFileName;

        File.AppendAllLines( fullPath, lines );
    }

    private void HandleException( string Message, Exception ex )
    {
        this.Log( Message, ex );

        new ExceptionDialog( Message, ex ) { StartPosition = FormStartPosition.CenterParent }.ShowDialog();
    }

    private void AddObject( S3Object obj )
    {
        var key = obj.Key;

        if( this.Folder != null && !string.IsNullOrWhiteSpace( this.Folder.Prefix ) )
        {
            key = key[this.Folder.Prefix.Length..];
        }

        var parts = key.Split( "/" );
        var nodes = this.treeView.Nodes;

        for( var i = 0 ; i < parts.Length - 1 ; i++ )
        {
            var part = parts[i];

            var temp = nodes.Cast<TreeNode>().FirstOrDefault( m => string.Equals( part, m.Text ) );

            if( temp != null )
            {
                nodes = temp.Nodes;
                continue;
            }

            var node = new TreeNode( part, 3, 3 )
            {
                Tag = string.Join( "/", parts.Take( i + 1 ) ) + "/",
                //ContextMenuStrip = this.treeViewContextMenu
            };

            nodes.Add( node );
            nodes = node.Nodes;
        }

        var himl = NativeMethods.SHGetFileInfo( obj.Key,
                                                0,
                                                ref this.shfi,
                                                (uint)Marshal.SizeOf( this.shfi ),
                                                NativeMethods.SHGFI_DISPLAYNAME
                                                  | NativeMethods.SHGFI_SYSICONINDEX
                                                  | NativeMethods.SHGFI_SMALLICON
                                                  | NativeMethods.SHGFI_USEFILEATTRIBUTES );

        var leaf = new TreeNode( parts[^1], this.shfi.iIcon, this.shfi.iIcon )
        {
            Tag = obj,
            //ContextMenuStrip = this.treeViewContextMenu
        };

        nodes.Add( leaf );
    }

    private void SetFontSize( float size )
    {
        var list = new List<Control>
        {
            this.cbFolder,
            this.treeView,
            this.label1,
            this.lblKey,
            this.label2,
            this.lblModified,
            this.label3,
            this.lblSize,
            this.label4,
            this.txtComments,
            this.label5,
            this.txtHistory,
        };

        foreach( var c in list )
        {
            c.Font = new Font( c.Font.Name, size );
        }
    }

    // https://stackoverflow.com/a/14488941/292578
    private static string SizeSuffix( long value, int decimalPlaces = 1 )
    {
        if( value < 0 )
        {
            return "-" + SizeSuffix( -value, decimalPlaces );
        }

        int i = 0;
        decimal dValue = (decimal)value;
        while( Math.Round( dValue, decimalPlaces ) >= 1000 )
        {
            dValue /= 1024;
            i++;
        }

        return string.Format( "{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i] );
    }

    private static string GetDatFileKey( string Key )
    {
        var parts = Key.Split( "/" );
        if( parts[^1].StartsWith( "_" ) && parts[^1].EndsWith( ".dat" ) )
        {
            return Key;
        }

        parts[^1] = "_" + parts[^1] + ".dat";
        return string.Join( "/", parts );
    }

    private async Task<FileMetaData> GetMetaData( string Key )
    {
        if( this.S3Client == null || this.Folder == null ) return new FileMetaData();

        try
        {
            var datKey = GetDatFileKey( Key );
            using var stream = await this.S3Client.GetObjectStreamAsync( this.Folder.Bucket, datKey, null );
            using var jsonReader = new StreamReader( stream );
            var metaData = JsonSerializer.Deserialize<FileMetaData>( jsonReader.ReadToEnd() );
            return metaData ?? new FileMetaData();
        }
        catch
        {
            // The file might not exist
            return new FileMetaData();
        }
    }

    private async Task CreateFile( string Key, string Path )
    {
        if( this.S3Client == null || this.Folder == null ) return;

        Task task = this.S3Client.PutObjectAsync( new PutObjectRequest
        {
            BucketName = this.Folder.Bucket,
            FilePath = Path,
            Key = Key,
        } );

        if( !this.Folder.DatFile )
        {
            await task;
            return;
        }

        var datKey = GetDatFileKey( Key );

        task = task.ContinueWith( async t =>
        {
            var metaData = new FileMetaData();
            metaData.History.Add( new FileHistory( this.Settings?.UserName ?? "Unknown", "Created" ) );

            var json = JsonSerializer.Serialize( metaData );

            await this.S3Client.PutObjectAsync( new PutObjectRequest
            {
                ContentType = "application/json",
                BucketName = this.Folder.Bucket,
                ContentBody = json,
                Key = datKey,
            } );
        } );

        await task;
    }

    private async Task SyncDown( LocalLink link )
    {
        if( this.Settings == null || this.S3Client == null || this.Folder == null ) return;

        var objects = await S3Client.GetObjects( this.Folder.Bucket, link.Prefix ).ToListAsync();

        this.pbProgress.Value = 0;
        this.pbProgress.Minimum = 0;
        this.pbProgress.Maximum = objects.Count;

        foreach( var obj in objects )
        {
            var parts = obj.Key.Split( "/" );
            if( parts[^1].StartsWith( "_" ) && parts[^1].EndsWith( ".dat" ) )
            {
                this.pbProgress.Value++;
                continue;
            }

            var path = obj.Key;

            if( path != link.Prefix ) path = path[( link.Prefix.Length )..];
            else path = path.Split( "/" ).Last();

            if( path.StartsWith( "/" ) ) path = path[1..];

            this.lblStatus.Text = $"Downloading {path}";

            path = Path.Combine( link.Path, path.Replace( "/", "\\" ) );
            await S3Client.DownloadToFilePathAsync( this.Folder.Bucket, obj.Key, path, null );

            this.pbProgress.Value++;
        }

        this.pbProgress.Value = this.pbProgress.Maximum;
        this.lblStatus.Text = "All files downloaded";
    }
}