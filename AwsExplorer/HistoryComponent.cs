using Explorer.Models;

namespace AwsExplorer;

public partial class HistoryComponent : UserControl
{
    public FileHistory History { get; set; }

    public HistoryComponent( FileHistory History, int width )
    {
        InitializeComponent();

        this.History = History;

        this.Width = width;
        this.lblPerson.Text = this.History.Name;
        this.lblAction.Text = this.History.Action;
        this.lblTimestamp.Text = this.History.Timestamp.ToString( "G" ) + " UTC";

        if( string.IsNullOrWhiteSpace( this.History.Details ) )
        {
            this.Height = 36;
        }
        else
        {
            this.txtDetails.Text = this.History.Details;
        }
    }
}
