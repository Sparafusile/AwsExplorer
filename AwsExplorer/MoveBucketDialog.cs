using Explorer;
using Amazon.S3;
using Explorer.Models;
using Explorer.Classes;

namespace AwsExplorer;

public partial class MoveBucketDialog : Form
{
    private Folder Folder { get; set; }
    private IAmazonS3 S3Client { get; set; }

    public bool MoveFiles { get; set; }
    public string? SourcePrefix { get; set; }
    public string? DestinationBucket { get; set; }
    public string? DestinationPrefix { get; set; }

    public MoveBucketDialog( IAmazonS3 S3Client, Folder Folder )
    {
        InitializeComponent();

        this.MoveFiles = false;
        this.Folder = Folder;
        this.S3Client = S3Client;

        this.LoadBuckets();
    }

    private async void BtnAddBucket_Click( object sender, EventArgs e )
    {
        if( this.Folder == null || string.IsNullOrWhiteSpace( this.Folder.AwsAccessKey ) || string.IsNullOrWhiteSpace( this.Folder.AwsSecretKey ) || string.IsNullOrWhiteSpace( this.Folder.Region ) )
        {
            MessageBox.Show( this, "Please enter an AWS Access and Secret key first.", "Credentials Missing", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

        var d = new RenameDialog( string.Empty, "New Bucket Name", "Create" ) { StartPosition = FormStartPosition.CenterParent };
        if( d.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace( d.Name ) ) return;

        try
        {
            var response = await S3Client.PutBucketAsync( d.Name );

            if( response.HttpStatusCode == System.Net.HttpStatusCode.OK )
            {
                this.cbRemoteBucket.Items.Add( d.Name );
                this.cbRemoteBucket.SelectedItem = d.Name;
            }
        }
        catch
        {
            MessageBox.Show( this, "Could not create bucket. Bucket names are shared between all users on AWS. The name you entered is already taken.", "Could Not Create Bucket", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
    }

    private async void LoadBuckets( object? sender = null, EventArgs? e = null )
    {
        if( string.IsNullOrWhiteSpace( this.Folder.AwsAccessKey ) || string.IsNullOrWhiteSpace( this.Folder.AwsSecretKey ) || string.IsNullOrWhiteSpace( this.Folder.Region ) )
        {
            return;
        }

        try
        {
            var results = await S3Client.ListBucketsAsync();

            this.cbRemoteBucket.Items.Clear();
            foreach( var b in results.Buckets )
            {
                if( string.Equals( this.Folder.Bucket, b.BucketName ) ) continue;
                this.cbRemoteBucket.Items.Add( b.BucketName );
            }
        }
        catch
        {
        }
    }

    private void BtnCancel_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BtnOkay_Click( object sender, EventArgs e )
    {
        this.MoveFiles = this.rbMove.Checked;
        this.SourcePrefix = this.txtSourcePrefix.Text;
        this.DestinationBucket = (string)this.cbRemoteBucket.SelectedItem;
        this.DestinationPrefix = this.txtDestinationPrefix.Text;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
