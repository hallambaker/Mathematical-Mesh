#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

namespace Goedel.Cryptography.KeyFile;

/// <summary>
/// Recognized key file formats
/// </summary>
public enum KeyFileFormat {
    /// <summary>Default format according to context.</summary>
    Default,
    /// <summary>PEM private key file, used for many SSH implementations</summary>
    PEMPrivate,
    /// <summary>PEM public key file</summary>
    PEMPublic,
    /// <summary>PuTTY private key file</summary>
    PuTTY,
    /// <summary>OpenSSH native format</summary>
    OpenSSH,
    /// <summary>X509</summary>
    X509DER,
    /// <summary>PKCS 12 / PFX</summary>
    PKCS12,
    /// <summary>PKCS 7</summary>
    PKCS7
    }

/// <summary>Extension methods</summary>
/// <remarks>This currently hard wires to the .NET framework providers
/// rather than the portable base classes.</remarks>
public static class Extension {
    /// <summary>
    /// Convert key pair to specified format
    /// </summary>
    /// <param name="keyPair">Keypair to convert</param>
    /// <param name="keyFileFormat">Format to convert to</param>
    /// <param name="passphrase">Optional passphrase to be used as encryption key.</param>
    /// <returns>The keyfile data</returns>
    public static string ToKeyFile(this KeyPair keyPair, KeyFileFormat keyFileFormat,
            string passphrase = null) {


        // ToDo: Write Key To File - Add in handling of ECC Key Types 
        // ToDo: Write Key To File - Handle passphrase encryption for PEM
        // ToDo: Write Key To File - Create PFX/P12 using .NET built ins
        // ToDo: Write Key To File - Unit tests for file generation /parse
        // ToDo: Write Key To File - PUTTY key files



        switch (keyFileFormat) {
            case KeyFileFormat.PEMPrivate: {
                    return ToPEMPrivate(keyPair, passphrase);
                    }
            case KeyFileFormat.PEMPublic: {
                    return ToPEMPublic(keyPair);
                    }
            case KeyFileFormat.PuTTY: {
                    return ToPuTTY(keyPair);
                    }
            case KeyFileFormat.OpenSSH: {
                    return ToOpenSSH(keyPair);
                    }

            case KeyFileFormat.Default:
            case KeyFileFormat.X509DER:
            case KeyFileFormat.PKCS12:
            case KeyFileFormat.PKCS7:
            default:
                throw new FileFormatNotImplemented(null, null, keyFileFormat.ToString());
            }

        }

    /// <summary>
    /// Convert key pair to OpenSSH format
    /// </summary>
    /// <param name="keyPair">Key pair to convert</param>
    /// <param name="tag">Descriptive tag to add to the file.</param>
    /// <returns>The keyfile data</returns>
    public static string ToOpenSSH(this KeyPair keyPair, string tag=null) {
        SSHData sshData = keyPair switch {
            KeyPairBaseRSA rsaKeyPair => new SSH_RSA(rsaKeyPair),
            //KeyPairBaseECDH ecdhKeyPair => "RSA PRIVATE KEY",
            _ => throw new FileFormatAlgorithmNotImplemented(null, null, KeyFileFormat.OpenSSH, keyPair.CryptoAlgorithmId)
            };

        var data = sshData.Encode();

        var builder = new StringBuilder();
        builder.Append("ssh-rsa ");
        builder.Append(" ");
        builder.ToStringBase64(data, 0, data.Length);
        builder.Append(' ');
        builder.Append(tag ?? "");
        return builder.ToString();
        }

    /// <summary>
    /// Write the binary key data <paramref name="data"/> to the string builder 
    /// <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="tag">Type of key (algorithm, public/private)</param>
    /// <param name="data">The key data.</param>
    public static void ToPEM(StringBuilder builder, string tag, byte[] data) {
        builder.Append($"-----BEGIN {tag}-----\n");
        builder.ToStringBase64(data, format: ConversionFormat.PEM64);
        builder.Append($"\n-----END {tag}-----\n");
        }



    /// <summary>
    /// Convert key pair to PEMPrivate format
    /// </summary>
    /// <param name="keyPair">Key pair to convert</param>
    /// <param name="passphrase">Optional passphrase to be used as encryption key.</param>
    /// <returns>The keyfile data</returns>
    public static string ToPEMPrivate(this KeyPair keyPair, string passphrase = null) {
        passphrase.AssertNull(NYI.Throw);
        string tag = keyPair switch {
            KeyPairBaseRSA  => "RSA PRIVATE KEY",
            KeyPairBaseECDH  => "RSA PRIVATE KEY",
            _ => throw new FileFormatAlgorithmNotImplemented(null, null, KeyFileFormat.PEMPrivate, keyPair.CryptoAlgorithmId)
            };

        passphrase.AssertNull(NYI.Throw);
        var pkixData = keyPair.PKIXPrivateKey;
        var keyDER = pkixData.DER();
        
        var builder = new StringBuilder();
        ToPEM(builder, tag, keyDER);
        return builder.ToString();
        }





    /// <summary>
    /// Convert key pair to PEMPublic format
    /// </summary>
    /// <param name="keyPair">Key pair to convert</param>
    /// <returns>The keyfile data</returns>
    public static string ToPEMPublic(this KeyPair keyPair) {
        string tag = keyPair switch {
            KeyPairBaseRSA  => "RSA PUBLIC KEY",
            KeyPairBaseECDH  => "RSA PUBLIC KEY",
            _ => throw new FileFormatAlgorithmNotImplemented(null, null, KeyFileFormat.PEMPublic, keyPair.CryptoAlgorithmId)
            };

        var pkixData = keyPair.PKIXPublicKey;
        var keyDER = pkixData.DER();

        var builder = new StringBuilder();
        ToPEM(builder, tag, keyDER);
        return builder.ToString();

        }

    /// <summary>
    /// Convert key pair to PuTTY format
    /// </summary>
    /// <param name="keyPair">Key pair to convert</param>
    /// <returns>The keyfile data</returns>
    public static string ToPuTTY(this KeyPair keyPair) {
        return keyPair switch {
            KeyPairBaseRSA rsaKeyPair => ToPuTTY(rsaKeyPair),
            _ => throw new FileFormatAlgorithmNotImplemented(null, null, KeyFileFormat.PuTTY, keyPair.CryptoAlgorithmId)
            };
        }

    /// <summary>
    /// Convert key pair to PEM formatted string.
    /// </summary>
    /// <param name="rsaKeyPair">A  Key pair</param>
    /// <returns>Key Pair in PEM format</returns>
    public static string ToPuTTY(this KeyPairBaseRSA rsaKeyPair) =>
                throw new FileFormatAlgorithmNotImplemented(null, null, KeyFileFormat.PuTTY, rsaKeyPair.CryptoAlgorithmId);


 




    /// <summary>
    /// Debug utility
    /// </summary>
    /// <param name="RSAParameters">RSA Parameters in /NET format</param>
    public static void Dump(this RSAParameters RSAParameters) {
        RSAParameters.Modulus.Dump("Modulus");
        RSAParameters.Exponent.Dump("Exponent");
        RSAParameters.P.Dump("P");
        RSAParameters.Q.Dump("Q");
        RSAParameters.D.Dump("D");
        RSAParameters.DP.Dump("DP");
        RSAParameters.DQ.Dump("DQ");
        RSAParameters.InverseQ.Dump("InverseQ");
        }

    /// <summary>
    /// Debug output utility
    /// </summary>
    /// <param name="Data">Data to print</param>
    /// <param name="Tag">Tag to prepend to data</param>
    public static void Dump(this byte[] Data, string Tag) => Console.WriteLine("{0} : [{1}]  {2}.{3}.{4} ... {5}.{6}.{7}",
            Tag, Data.Length, Data[0], Data[1], Data[2],
                Data[^3], Data[^2], Data[^1]);
    }
