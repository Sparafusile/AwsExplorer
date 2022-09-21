using Explorer.Models;

namespace Explorer;

public partial class SettingsDialog : Form
{
    public Settings Settings { get; set; }

    public SettingsDialog( Settings Settings )
    {
        InitializeComponent();

        this.Settings = Settings;
        this.Settings.CloseAction ??= "Close Normally";
        this.Settings.MinimizeAction ??= "Minimize to Taskbar";

        this.txtYourName.Text = Settings.UserName;
        this.cbCloseAction.SelectedItem = Settings.CloseAction;
        this.cbMinimizeAction.SelectedItem = Settings.MinimizeAction;
    }

    private void btnCancel_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void btnOkay_Click( object sender, EventArgs e )
    {
        this.DialogResult = DialogResult.OK;
        this.Settings.UserName = this.txtYourName.Text;
        this.Settings.MinimizeAction = this.cbMinimizeAction.SelectedItem as string;
        this.Settings.CloseAction = this.cbCloseAction.SelectedItem as string;
        this.Close();
    }
}
