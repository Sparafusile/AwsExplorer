using Amazon.S3;
using Amazon.S3.Model;

namespace Explorer;

public partial class ShareDialog : Form
{
    private S3Object S3Object { get; set; }
    private IAmazonS3 S3Client { get; set; }
    private Models.Folder Folder { get; set; }

    public ShareDialog( S3Object S3Object, Models.Folder Folder, IAmazonS3 S3Client )
    {
        InitializeComponent();

        var name = S3Object.Key.Split( "/" ).Last();
        this.Text = $"Share '{name}' with a presigned URL";

        this.S3Object = S3Object;
        this.S3Client = S3Client;
        this.Folder = Folder;
    }

    private void BtnCancel_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BtnOkay_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void BtnCreateUrl_Click( object sender, EventArgs e )
    {
        if( !int.TryParse( this.txtNumber.Text, out int n ) )
        {
            MessageBox.Show( this, "Please enter a timer interval smaller than 12 hours.", "Could not Generate URL", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

        var expireDate = DateTime.Now;

        if( this.rbHours.Checked )
        {
            expireDate = expireDate.AddHours( n );
        }
        else if( this.rbMinutes.Checked )
        {
            expireDate = expireDate.AddMinutes( n );
        }

        if( expireDate > DateTime.Now.AddHours( 12 ) )
        {
            expireDate = DateTime.Now.AddHours( 12 );
        }

        var url = this.S3Client.GeneratePreSignedURL( this.Folder.Bucket, this.S3Object.Key, expireDate, null );

        this.txtUrl.Text = url;
        this.txtUrl.SelectAll();
        this.txtUrl.Focus();
    }
}
