using System.Security.Cryptography;

namespace Explorer.Classes;

public static class Encryption
{
    public static byte[] encrypt( string plainText, byte[] key, byte[] iv )
    {
        return encrypt( System.Text.Encoding.UTF8.GetBytes( plainText ), key, iv );
    }

    public static byte[] encrypt( byte[] plainText, byte[] key, byte[] iv )
    {
        // http://msdn.microsoft.com/en-us/library/system.security.cryptography.rijndaelmanaged.aspx

        // Check arguments.
        if( plainText == null || plainText.Length <= 0 ) throw new ArgumentNullException( "plainText" );
        if( key == null || key.Length <= 0 ) throw new ArgumentNullException( "key" );
        if( iv == null || iv.Length <= 0 ) throw new ArgumentNullException( "iv" );

        // Create an RijndaelManaged object
        // with the specified key and IV.
        using( var aesAlg = new AesManaged() )
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            try
            {
                using( var stream = new MemoryStream() )
                using( var encryptor = aesAlg.CreateEncryptor( aesAlg.Key, aesAlg.IV ) )
                using( var encrypt = new CryptoStream( stream, encryptor, CryptoStreamMode.Write ) )
                {
                    encrypt.Write( plainText, 0, plainText.Length );
                    encrypt.FlushFinalBlock();
                    return stream.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }
    }

    public static string decrypt( byte[] cipherText, byte[] key, byte[] iv )
    {
        // http://msdn.microsoft.com/en-us/library/system.security.cryptography.rijndaelmanaged.aspx
        // http://stackoverflow.com/questions/4501289/c-sharp-byte-encryption

        // Check arguments.
        if( cipherText == null || cipherText.Length <= 0 ) throw new ArgumentNullException( "cipherText" );
        if( key == null || key.Length <= 0 ) throw new ArgumentNullException( "key" );
        if( iv == null || iv.Length <= 0 ) throw new ArgumentNullException( "iv" );

        byte[]? plaintext = null;

        using( var aesAlg = new AesManaged() )
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            try
            {
                using( var stream = new MemoryStream() )
                using( var decryptor = aesAlg.CreateDecryptor( aesAlg.Key, aesAlg.IV ) )
                using( var encrypt = new CryptoStream( stream, decryptor, CryptoStreamMode.Write ) )
                {
                    encrypt.Write( cipherText, 0, cipherText.Length );
                    encrypt.FlushFinalBlock();
                    plaintext = stream.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }

        return System.Text.Encoding.UTF8.GetString( plaintext );
    }

    public static byte[] GetRandomAesKey()
    {
        using( var r = new RijndaelManaged() )
        {
            r.GenerateKey();
            return r.Key;
        }
    }

    public static byte[] GetRandomAesIV()
    {
        using( var r = new RijndaelManaged() )
        {
            r.GenerateIV();
            return r.IV;
        }
    }
}