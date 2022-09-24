using Explorer.Models;

namespace AwsExplorer;

public partial class HistoryDialog : Form
{
    private List<FileHistory> History { get; set; }

    public HistoryDialog( List<FileHistory> History )
    {
        InitializeComponent();

        this.History = History;

        this.cbAction.Items.Clear();
        this.cbAction.Items.Add( string.Empty );
        this.cbAction.Items.AddRange( History.Select( m => m.Action ).OrderBy( m => m ).Distinct().ToArray() );

        this.cbPerson.Items.Clear();
        this.cbPerson.Items.Add( string.Empty );
        this.cbPerson.Items.AddRange( History.Select( m => m.Name ).OrderBy( m => m ).Distinct().ToArray() );

        foreach( var h in this.History )
        {
            this.flowLayout.Controls.Add( new HistoryComponent( h, this.flowLayout.Width - 25 ) );
        }
    }

    private void filterHistory( object sender, EventArgs e )
    {
        foreach( var h in this.flowLayout.Controls.Cast<HistoryComponent>() )
        {
            var visible = true;

            if( this.cbAction.SelectedItem is string action && !string.IsNullOrWhiteSpace( action ) )
            {
                if( !string.Equals( h.History.Action, action ) )
                {
                    visible = false;
                }
            }

            if( this.cbPerson.SelectedItem is string person && !string.IsNullOrWhiteSpace( person ) )
            {
                if( !string.Equals( h.History.Name, person ) )
                {
                    visible = false;
                }
            }

            h.Visible = visible;
        }
    }
}
