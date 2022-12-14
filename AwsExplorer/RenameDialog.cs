namespace Explorer;

public partial class RenameDialog : Form
{
    public new string Name { get; set; }

    public RenameDialog( string Name, string Title = "Renaming", string OkayButtonText = "Okay" )
    {
        InitializeComponent();

        this.Name = Name;
        this.txtName.Text = Name;
        this.Text = Title;
        this.btnOkay.Text = OkayButtonText;
    }

    private void BtnCancel_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void BtnOkay_Click( object sender, EventArgs e )
    {
        this.Name = this.txtName.Text;

        if( string.IsNullOrWhiteSpace( this.Name ) )
        {
            MessageBox.Show( this, "Please enter a name.", "Cannot Perform Action", MessageBoxButtons.OK, MessageBoxIcon.Error );
            return;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
