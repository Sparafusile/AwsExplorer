using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

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

        this.AwsAccessKey = this.AwsSecretKey = string.Empty;
        this.Bucket = this.Prefix = string.Empty;
        this.Region = "us-east-1";
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

    public string? GetLocalPath( string Key )
    {
        if( this.Links == null ) return null;

        return this.Links
            .OrderByDescending( m => m.Prefix.Length )
            .Select( m => m.GetLocalPath( Key ) )
            .Where( m => !string.IsNullOrWhiteSpace( m ) )
            .FirstOrDefault();
    }

    public string? GetRemoteKey( string Path )
    {
        if( this.Links == null ) return null;

        return this.Links
            .OrderByDescending( m => m.Path.Length )
            .Select( m => m.GetLocalPath( Path ) )
            .Where( m => !string.IsNullOrWhiteSpace( m ) )
            .FirstOrDefault();
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

    public string? GetLocalPath( string KeyOrPrefix )
    {
        if( !KeyOrPrefix.StartsWith( this.Prefix ) ) return null;

        var path = KeyOrPrefix;

        if( path != this.Prefix ) path = path[( this.Prefix.Length )..];
        else path = path.Split( "/" ).Last();

        if( path.StartsWith( "/" ) ) path = path[1..];

        path = path.Replace( "/", "\\" );

        return System.IO.Path.Combine( this.Path, path );
    }

    public string? GetRemoteKey( string Path )
    {
        if( !Path.StartsWith( this.Path ) ) return null;
        return this.Prefix + Path[this.Path.Length..].Replace( "\\", "/" );
    }
}

public static partial class ExtensionMethods
{
    public static IEnumerable<Folder> Clone( this IEnumerable<Folder> Folders )
    {
        foreach( var f in Folders ) yield return f.Clone();
    }
}