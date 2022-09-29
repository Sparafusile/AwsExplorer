namespace Explorer.Models;

public class FileMetaData
{
    public string Comments { get; set; }

    public List<FileHistory> History { get; set; }

    public FileMetaData()
    {
        this.Comments = string.Empty;
        this.History = new List<FileHistory>();
    }
}

public class FileHistory
{
    public string Name { get; set; }

    public string Action { get; set; }

    public string? Details { get; set; }

    public DateTime Timestamp { get; set; }

    public FileHistory( string Name, string Action )
    {
        this.Name = Name;
        this.Action = Action;
        this.Timestamp = DateTime.UtcNow;
    }

    public override string ToString()
    {
        var time = this.Timestamp.ToUniversalTime().ToString( "G" );
        return $"{time,-32} {this.Name,-32} {this.Action}";
    }
}
