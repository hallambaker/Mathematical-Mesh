using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh {

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
        public static string ConnectUri (string account, string pin) =>
             $"{Constants.MeshConnectURI}://{account}/{pin}";


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

            return UDF.SymmetricKey(keyDerive.Derive(accountAddress.ToBytes(), length));
            }

        /// <summary>
        /// Parse a connection URI to recover the account and secret code.
        /// </summary>
        /// <param name="uriAddress">The URI to parse.</param>
        /// <returns>The account address and PIN values.</returns>
        public static (string, string) ParseConnectUri(string uriAddress) {
            try {
                var uri = new Uri(uriAddress);
                (uri.Scheme == Constants.MeshConnectURI).AssertTrue(InvalidUriMethod.Throw);
                var pin = uri.LocalPath.Substring(1);
                var accountAddress = $"{uri.UserInfo}@{uri.Authority}";

                return (accountAddress, pin);

                }
            catch {
                throw new InvalidUri();
                }

            }

        }
    }
