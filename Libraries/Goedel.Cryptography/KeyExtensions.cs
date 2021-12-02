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

namespace Goedel.Cryptography;



/// <summary>
/// Extensions class for deriving UDF from key parameters
/// </summary>
public static class KeyExtensions {

    /// <summary>
    /// Calculate UDF data value for public key parameters
    /// </summary>
    /// <param name="key">The key to calculate the fingerprint of</param>
    /// <param name="bits">Precision, must be a multiple of 25 bits.</param>
    /// <param name="cryptoAlgorithmID">The digest algorithm to use.</param>
    /// <returns>The binary fingerprint value</returns>
    public static byte[] UDFBytes(this IPkixPublicKey key, int bits = 0,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512) {
        var data = key.SubjectPublicKeyInfo().DER();

        return Cryptography.UDF.FromKeyInfo(data, bits, cryptoAlgorithmID);
        }



    /// <summary>
    /// Calculate UDF fingerprint presentation for public key parameters
    /// </summary>
    /// <param name="key">The key to calculate the fingerprint of</param>
    /// <returns>The fingerprint presentation</returns>
    public static string UDF(this IPkixPublicKey key) {
        var Bytes = key.UDFBytes();
        return Cryptography.UDF.PresentationBase32(Cryptography.UDF.FromKeyInfo(Bytes));
        }

    /// <summary>
    /// Returns true if the key is exportable, otherwise false.
    /// </summary>
    /// <param name="keyStorage">The key security specifier.</param>
    /// <returns>true if the key is exportable, otherwise false</returns>
    public static bool IsExportable(this KeySecurity keyStorage) =>
        (keyStorage & KeySecurity.Exportable) == KeySecurity.Exportable;

    /// <summary>
    /// Returns true if the key is persisted, otherwise false.
    /// </summary>
    /// <param name="keyStorage">The key security specifier.</param>
    /// <returns>true if the key is persisted, otherwise false</returns>
    public static bool IsPersistable(this KeySecurity keyStorage) =>
        (keyStorage & KeySecurity.Persistable) == KeySecurity.Persistable;


    }
