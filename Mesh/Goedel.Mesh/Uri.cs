using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public class MeshUri {

        public static string ConnectUri (string account, string pin) =>
             $"{Constants.MeshConnectURI}://{account}/{pin}";


        public static string GetConnectPin(
                    PrivateKeyUDF privateKeyUDF,
                    string accountAddress,
                    int length = 0,
                    CryptoAlgorithmId algorithm = CryptoAlgorithmId.HMAC_SHA_2_512) {
            var keyDerive = new KeyDeriveHKDF(privateKeyUDF.PrivateValue.ToBytes(), "", algorithm);

            return UDF.SymmetricKey(keyDerive.Derive(accountAddress.ToBytes(), length));
            }

        public static (string, string) ParseConnectUri(string uriAddress) {
            try {
                var uri = new Uri(uriAddress);
                (uri.Scheme == Constants.MeshConnectURI).AssertTrue();
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
