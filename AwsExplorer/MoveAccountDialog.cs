using Amazon.S3;

namespace Explorer;

public partial class MoveAccountDialog : Form
{
    public bool MoveFiles { get; set; }
    public string? SourcePrefix { get; set; }
    public string? DestinationBucket { get; set; }
    public string? DestinationPrefix { get; set; }
    public string? AwsAccessKey { get; set; }
    public string? AwsSecretKey { get; set; }
    public new string? Region { get; set; }

    public MoveAccountDialog( List<string> Prefixes, string? SourcePrefix = null )
    {
        InitializeComponent();

        this.MoveFiles = false;

        this.cbSourcePrefix.Items.Clear();
        this.cbSourcePrefix.Items.AddRange( Prefixes.ToArray() );
        this.cbSourcePrefix.SelectedItem = SourcePrefix;
        this.txtDestinationPrefix.Text = SourcePrefix;

        this.LoadBuckets();

        this.cbRegion.Items.Clear();
        foreach( var m in Amazon.RegionEndpoint.EnumerableAllRegions )
        {
            this.cbRegion.Items.Add( m.SystemName );
        }
        this.cbRegion.SelectedItem = "us-east-1";
    }

    private void BtnOkay_Click( object sender, EventArgs e )
    {
        this.MoveFiles = this.rbMove.Checked;
        this.SourcePrefix = (string)this.cbSourcePrefix.SelectedItem;
        this.DestinationBucket = (string)this.cbRemoteBucket.SelectedItem;
        this.AwsAccessKey = this.txtAwsAccessKey.Text;
        this.AwsSecretKey = this.txtAwsSecretKey.Text;
        this.Region = (string)this.cbRegion.SelectedItem;
        this.DestinationPrefix = this.txtDestinationPrefix.Text;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BtnCancel_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private async void BtnAddBucket_Click( object sender, EventArgs e )
    {
        if( string.IsNullOrWhiteSpace( this.txtAwsAccessKey.Text ) || string.IsNullOrWhiteSpace( this.txtAwsSecretKey.Text ) )
        {
            MessageBox.Show( this, "Please enter an AWS Access and Secret key first.", "Credentials Missing", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

        var d = new RenameDialog( string.Empty, "New Bucket Name", "Create" ) { StartPosition = FormStartPosition.CenterParent };
        if( d.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace( d.Name ) ) return;

        var region = Amazon.RegionEndpoint.GetBySystemName( (string)this.cbRegion.SelectedItem ?? "us-east-1" );
        using var S3Client = new AmazonS3Client( this.txtAwsAccessKey.Text, this.txtAwsSecretKey.Text, region );

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
        if( string.IsNullOrWhiteSpace( this.txtAwsAccessKey.Text ) || string.IsNullOrWhiteSpace( this.txtAwsSecretKey.Text ) || this.cbRegion.SelectedItem == null )
        {
            return;
        }

        try
        {
            var region = Amazon.RegionEndpoint.GetBySystemName( this.cbRegion.SelectedItem as string ?? "us-east-1" );
            using var S3Client = new AmazonS3Client( this.txtAwsAccessKey.Text, this.txtAwsSecretKey.Text, region );

            var results = await S3Client.ListBucketsAsync();

            this.cbRemoteBucket.Items.Clear();
            foreach( var b in results.Buckets )
            {
                this.cbRemoteBucket.Items.Add( b.BucketName );
            }
        }
        catch
        {
        }
    }

    private void cbSourcePrefix_SelectedIndexChanged( object sender, EventArgs e )
    {
        this.txtDestinationPrefix.Text = (string)this.cbSourcePrefix.SelectedItem;
    }
}
