using Amazon.S3;
using Amazon.S3.Model;

namespace Explorer.Classes;

public static partial class ExtensionMethods
{
    public static async IAsyncEnumerable<S3Object> GetObjects( this IAmazonS3 S3Client, string Bucket, string? Prefix = null )
    {
        var request = new ListObjectsV2Request
        {
            Prefix = Prefix,
            BucketName = Bucket,
        };

        var response = await S3Client.ListObjectsV2Async( request );

        do
        {
            foreach( var obj in response.S3Objects )
            {
                yield return obj;
            }

            if( !response.IsTruncated ) break;

            request.ContinuationToken = response.NextContinuationToken;
            response = await S3Client.ListObjectsV2Async( request );
        }
        while( true );
    }

    public static async Task DownloadObjects( this IAmazonS3 S3Client, string Bucket, string Prefix, string LocalPath )
    {
        await foreach( var obj in S3Client.GetObjects( Bucket, Prefix ) )
        {
            var path = obj.Key[( Prefix?.Length ?? 0 )..].Replace( "/", "\\" );
            if( path.StartsWith( "\\" ) ) path = path[1..];
            path = Path.Combine( LocalPath, path );

            await S3Client.DownloadToFilePathAsync( Bucket, obj.Key, path, null );
        }
    }

    // https://stackoverflow.com/a/20081867/292578
    public static List<string> GetExpansionState( this TreeNodeCollection nodes )
    {
        return nodes.Descendants()
                    .Where( n => n.IsExpanded )
                    .Select( n => n.FullPath )
                    .ToList();
    }

    // https://stackoverflow.com/a/20081867/292578
    public static void SetExpansionState( this TreeNodeCollection nodes, List<string> savedExpansionState )
    {
        foreach( var node in nodes.Descendants().Where( n => savedExpansionState.Contains( n.FullPath ) ) )
        {
            node.Expand();
        }
    }

    // https://stackoverflow.com/a/20081867/292578
    public static IEnumerable<TreeNode> Descendants( this TreeNodeCollection c )
    {
        foreach( var node in c.OfType<TreeNode>() )
        {
            yield return node;

            foreach( var child in node.Nodes.Descendants() )
            {
                yield return child;
            }
        }
    }
}
