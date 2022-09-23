namespace Explorer;

public partial class DownloadDialog : Form
{
    public string Directory { get; set; }

    public bool Download { get; set; }

    public bool Upload { get; set; }

    public DownloadDialog()
    {
        InitializeComponent();

        this.Directory = string.Empty;
    }

    private void BtnDestination_Click( object sender, EventArgs e )
    {
        var result = this.folderBrowserDialog.ShowDialog( this );
        if( result != DialogResult.OK ) return;
        this.txtDestination.Text = this.folderBrowserDialog.SelectedPath;
    }

    private void BtnCancel_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BtnOkay_Click( object sender, EventArgs e )
    {
        this.Directory = this.txtDestination.Text;
        this.Download = this.rbDownload.Checked || this.rbBoth.Checked;
        this.Upload = this.rbBoth.Checked;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
