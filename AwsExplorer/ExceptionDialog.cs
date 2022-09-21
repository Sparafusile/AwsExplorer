namespace Explorer;

public partial class ExceptionDialog : Form
{
    public ExceptionDialog( string Title, Exception ex )
    {
        InitializeComponent();

        this.Text = Title;

        this.txtDescription.Text = ex.Message;
        this.txtDetails.Text = ex.StackTrace;
    }
}
