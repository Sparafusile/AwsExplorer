using Amazon.S3;
using Explorer.Models;

namespace AwsExplorer;

public partial class VersionDialog : Form
{
    private IAmazonS3 S3Client { get; set; }
    private string Bucket { get; set; }
    private string Key { get; set; }
    private List<FileHistory>? History { get; set; }

    public VersionDialog( IAmazonS3 S3Client, string Bucket, string Key, List<FileHistory>? History )
    {
        InitializeComponent();

        this.S3Client = S3Client;
        this.History = History;
        this.Bucket = Bucket;
        this.Key = Key;

        this.ListChanges();
    }

    private void VersionDialog_ResizeEnd( object sender, EventArgs e )
    {
        var width = this.flowLayout.Width - 25;
        foreach( Control c in this.flowLayout.Controls ) c.Width = width;
    }

    private async void ListChanges( object? sender = null, EventArgs? e = null )
    {
        var response = await this.S3Client.ListVersionsAsync( this.Bucket, this.Key );

        this.flowLayout.Controls.Clear();
        var width = this.flowLayout.Width - 25;

        foreach( var v in response.Versions.OrderByDescending( m => m.LastModified ) )
        {
            var h = this.History?
                .OrderBy( m => Math.Abs( ( m.Timestamp.ToUniversalTime() - v.LastModified.ToUniversalTime() ).TotalMinutes ) )
                .Where( m => Math.Abs( ( m.Timestamp.ToUniversalTime() - v.LastModified.ToUniversalTime() ).TotalMinutes ) < 1 )
                .FirstOrDefault();

            var vc = new VersionComponent( this.S3Client, v, h, width );
            vc.Change += new EventHandler( this.ListChanges );
            this.flowLayout.Controls.Add( vc );
        }
    }
}
