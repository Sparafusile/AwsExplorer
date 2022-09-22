using System.Diagnostics.CodeAnalysis;

namespace Explorer.Models;

public class Folder : IEqualityComparer<Folder>
{
    public string AwsAccessKey { get; set; }

    public string AwsSecretKey { get; set; }

    public string Region { get; set; }

    public string Bucket { get; set; }

    public string Prefix { get; set; }

    public bool DatFile { get; set; }

    public List<LocalLink> Links { get; set; }

    public Folder()
    {
        this.Links = new List<LocalLink>();
    }

    public Folder Clone()
    {
        return new Folder
        {
            AwsAccessKey = this.AwsAccessKey,
            AwsSecretKey = this.AwsSecretKey,
            Region = this.Region,
            Bucket = this.Bucket,
            Prefix = this.Prefix,
            DatFile = this.DatFile,
        };
    }

    public bool Equals( Folder? x, Folder? y )
    {
        if( x == null || y == null ) return false;

        if( string.Equals( x.AwsAccessKey, y.AwsAccessKey )
            && string.Equals( x.AwsSecretKey, y.AwsSecretKey )
            && string.Equals( x.Region, y.Region )
            && string.Equals( x.Bucket, y.Bucket )
            && string.Equals( x.Prefix, y.Prefix )
            && x.DatFile == y.DatFile ) return true;

        return false;
    }

    public int GetHashCode( [DisallowNull] Folder obj )
    {
        return HashCode.Combine( this.AwsAccessKey, this.AwsSecretKey, this.Region, this.Bucket, this.Prefix, this.DatFile );
    }

    public override string ToString()
    {
        if( !string.IsNullOrWhiteSpace( this.Prefix ) )
        {
            return this.Bucket + "/" + this.Prefix;
        }
        else return this.Bucket;
    }
}

public class LocalLink
{
    public string Prefix { get; set; }

    public string Path { get; set; }

    public bool Download { get; set; }

    public bool Upload { get; set; }

    public LocalLink( string prefix, string path )
    {
        Prefix = prefix;
        Path = path;
    }
}

public static partial class ExtensionMethods
{
    public static IEnumerable<Folder> Clone( this IEnumerable<Folder> Folders )
    {
        foreach( var f in Folders ) yield return f.Clone();
    }
}