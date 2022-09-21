namespace Explorer;

public partial class RenameDialog : Form
{
    public string Name { get; set; }

    public RenameDialog( string Name, string Title = "Renaming", string OkayButtonText = "Okay" )
    {
        InitializeComponent();

        this.Name = Name;
        this.txtName.Text = Name;
        this.Text = Title;
        this.btnOkay.Text = OkayButtonText;
    }

    private void btnCancel_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void btnOkay_Click( object sender, EventArgs e )
    {
        this.Name = this.txtName.Text;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
