namespace Explorer.Models;

public class Settings
{
    public string? UserName { get; set; }

    public string? LogFilePath { get; set; }

    public int WindowWidth { get; set; }

    public int WindowHeight { get; set; }

    public int TreeViewWidth { get; set; }

    public float FontSize { get; set; }

    public string? MinimizeAction { get; set; }

    public string? CloseAction { get; set; }

    public List<Folder> Folders { get; set; }

    public Settings()
    {
        this.Folders = new List<Folder>();
    }

    public Settings Clone()
    {
        return new Settings
        {
            UserName = this.UserName,
            LogFilePath = this.LogFilePath,
            WindowWidth = this.WindowWidth,
            WindowHeight = this.WindowHeight,
            TreeViewWidth = this.TreeViewWidth,
            FontSize = this.FontSize,
            MinimizeAction = this.MinimizeAction,
            CloseAction = this.CloseAction,
            Folders = this.Folders.Clone().ToList(),
        };
    }
}
