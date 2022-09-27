using Amazon.S3;

namespace Explorer;

public partial class FolderDialog : Form
{
    public Models.Folder? Folder { get; set; }

    public FolderDialog()
    {
        InitializeComponent();

        this.cbRegion.Items.Clear();
        foreach( var m in Amazon.RegionEndpoint.EnumerableAllRegions )
        {
            this.cbRegion.Items.Add( m.SystemName );
        }
        this.cbRegion.SelectedItem = "us-east-1";
    }

    public FolderDialog( Models.Folder Folder ) : this()
    {
        this.Folder = Folder;
        this.txtAwsAccessKey.Text = Folder.AwsAccessKey;
        this.txtAwsSecretKey.Text = Folder.AwsSecretKey;
        this.cbRegion.SelectedItem = Folder.Region;
        this.txtFilePrefix.Text = Folder.Prefix;
        this.cbOptions.Checked = Folder.DatFile;

        this.LoadBuckets();
    }

    private void BtnOkay_Click( object sender, EventArgs e )
    {
        this.Folder ??= new Models.Folder();
        this.Folder.AwsAccessKey = this.txtAwsAccessKey.Text;
        this.Folder.AwsSecretKey = this.txtAwsSecretKey.Text;
        this.Folder.Bucket = (string)this.cbRemoteBucket.SelectedItem;
        this.Folder.Prefix = this.txtFilePrefix.Text;
        this.Folder.DatFile = this.cbOptions.Checked;

        if( string.IsNullOrWhiteSpace( this.Folder.AwsAccessKey ) || string.IsNullOrWhiteSpace( this.Folder.AwsSecretKey ) )
        {
            MessageBox.Show( this, "Please enter AWS credentials.", "Could not Create Folder Link", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

        if( string.IsNullOrWhiteSpace( this.Folder.Bucket ) )
        {
            MessageBox.Show( this, "Please select a remote bucket.", "Could not Create Folder Link", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

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

        var region = Amazon.RegionEndpoint.GetBySystemName( this.Folder?.Region ?? "us-east-1" );
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

            if( this.Folder != null && !string.IsNullOrWhiteSpace( this.Folder.Bucket ) )
            {
                this.cbRemoteBucket.SelectedItem = Folder.Bucket;
            }
        }
        catch
        {
        }
    }
}
