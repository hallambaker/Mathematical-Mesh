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


namespace Goedel.Mesh;

///<summary>Static class for manipulating Mesh Uris</summary>
public class MeshUri {

    /// <summary>
    /// Attempt to process <paramref name="account"/> as an EARL URI with embedded pin.
    /// If successfull replace the values <paramref name="account"/> and 
    /// <paramref name="pin"/>. Otherwise leave unchanged.
    /// </summary>
    /// <param name="account">The account address.</param>
    /// <param name="pin">The pin value.</param>
    public static void ParseUri(ref string account, ref string pin) {
        try {
            (account, pin) = ParseConnectUri(account);
            }
        catch {
            // leave unchanged
            }
        }



    /// <summary>
    /// Generate a connection URI for <paramref name="account"/> with secret 
    /// <paramref name="pin"/>.
    /// </summary>
    /// <param name="account">The account to connect to.</param>
    /// <param name="pin">The secret value.</param>
    /// <returns>The connection URI</returns>
    public static string ConnectUri(string account, string pin) =>
         $"{MeshConstants.MeshConnectURI}://{account}/{pin}";


    /// <summary>
    /// Generate a connection PIN from the private key value <paramref name="privateKeyUDF"/>
    /// for account <paramref name="accountAddress"/> with <paramref name="length"/> bits
    /// using algorithm <paramref name="algorithm"/>.
    /// </summary>
    /// <param name="privateKeyUDF">The private key value</param>
    /// <param name="accountAddress">The account address to connect to.</param>
    /// <param name="length">Length of the secret value in bits.</param>
    /// <param name="algorithm">Key derrivation algorithm.</param>
    /// <returns>The connection PN code.</returns>
    public static string GetConnectPin(
                PrivateKeyUDF privateKeyUDF,
                string accountAddress,
                int length = 0,
                CryptoAlgorithmId algorithm = CryptoAlgorithmId.HMAC_SHA_2_512) {
        var keyDerive = new KeyDeriveHKDF(privateKeyUDF.PrivateValue.ToBytes(), "", algorithm);

        return UDF.EncryptionKey(keyDerive.Derive(accountAddress.ToBytes(), length));
        }

    /// <summary>
    /// Parse a connection URI to recover the account and secret code.
    /// </summary>
    /// <param name="uriAddress">The URI to parse.</param>
    /// <returns>The account address and PIN values.</returns>
    public static (string, string) ParseConnectUri(string uriAddress) {
        try {
            var uri = new Uri(uriAddress);
            (uri.Scheme == MeshConstants.MeshConnectURI).AssertTrue(InvalidUriMethod.Throw);
            var pin = uri.LocalPath[1..];
            var accountAddress = $"{uri.UserInfo}@{uri.Authority}";

            return (accountAddress, pin);

            }
        catch {
            throw new InvalidUri();
            }

        }

    }
