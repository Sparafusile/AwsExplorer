using Amazon.S3;
using Amazon.S3.Model;
using Explorer.Models;

namespace AwsExplorer;

public partial class VersionComponent : UserControl
{
    private IAmazonS3 S3Client { get; set; }
    private S3ObjectVersion Version { get; set; }
    private FileHistory? History { get; set; }

    private static readonly object s_changeEvent = new object();

    public event EventHandler Change
    {
        add => Events.AddHandler( s_changeEvent, value );
        remove => Events.RemoveHandler( s_changeEvent, value );
    }

    public VersionComponent( IAmazonS3 S3Client, S3ObjectVersion Version, FileHistory? History, int Width )
    {
        InitializeComponent();

        this.S3Client = S3Client;
        this.Version = Version;
        this.History = History;

        this.lblSize.Text = SizeSuffix( this.Version.Size );
        this.lblPerson.Text = this.History?.Name ?? "Unknown";
        this.lblTimestamp.Text = this.Version.LastModified.ToUniversalTime().ToString( "G" );

        this.btnRevert.Enabled = !this.Version.IsLatest;
        this.btnDelete.Enabled = !this.Version.IsLatest;

        this.Width = Width;
    }

    private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

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

    private async void BtnDownload_click( object sender, EventArgs e )
    {
        this.saveFileDialog.FileName = this.Version.Key.Split( "/" ).Last();
        var result = this.saveFileDialog.ShowDialog( this );
        if( result != DialogResult.OK ) return;

        var response = await this.S3Client.GetObjectAsync( this.Version.BucketName, this.Version.Key, this.Version.VersionId );

        using var stream = response.ResponseStream;
        using var output = this.saveFileDialog.OpenFile();
        stream.CopyTo( output );
        output.Close();
        stream.Close();
    }

    private async void BtnRevert_click( object sender, EventArgs e )
    {
        var result = MessageBox.Show( this, "This will overrite the current version of the file. Do you wish to continue?", "Possible Loss of Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
        if( result != DialogResult.Yes ) return;

        await this.S3Client.CopyObjectAsync( new CopyObjectRequest
        {
            SourceKey = this.Version.Key,
            SourceBucket = this.Version.BucketName,
            SourceVersionId = this.Version.VersionId,

            DestinationKey = this.Version.Key,
            DestinationBucket = this.Version.BucketName,
        } );

        Events[s_changeEvent]?.DynamicInvoke( this, EventArgs.Empty );
    }

    private async void BtnDelete_Click( object sender, EventArgs e )
    {
        var result = MessageBox.Show( this, "This will permanently delete this version of the file. Do you wish to continue?", "Possible Loss of Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
        if( result != DialogResult.Yes ) return;

        await this.S3Client.DeleteObjectAsync( this.Version.BucketName, this.Version.Key, this.Version.VersionId );

        Events[s_changeEvent]?.DynamicInvoke( this, EventArgs.Empty );
    }
}
