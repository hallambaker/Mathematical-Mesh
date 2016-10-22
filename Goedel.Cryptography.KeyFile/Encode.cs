using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography.KeyFile {
    public enum KeyFileFormat {
        PEMPrivate,         // Also for OpenSSH
        PuTTY,
        PEMPublic,
        OpenSSH
        }

    public static class Extension {

        public static string ToPEM (this KeyPair KeyPair) {
            if (KeyPair as RSAKeyPair != null) {
                return ToPEM(KeyPair as RSAKeyPair);
                }

            return null;
            }


        public static string ToPEM (RSAKeyPair RSAKeyPair) {

            var Provider = RSAKeyPair.Provider;
            Assert.Null(Provider, NoProviderSpecified.Throw);

            var RSAParameters = Provider.ExportParameters(true);
            Assert.Null(RSAParameters, PrivateKeyNotAvailable.Throw);

            var NewProvider = new RSACryptoServiceProvider();
            NewProvider.ImportParameters(RSAParameters);


            RSAParameters.Dump();

            var RSAPrivateKey = new RSAPrivateKey(RSAParameters);

            var Builder = new StringBuilder();

            Builder.Append("-----BEGIN RSA PRIVATE KEY-----");

            var KeyDER = RSAPrivateKey.DER();
            Builder.AppendBase64(KeyDER);


            Builder.Append("\n-----END RSA PRIVATE KEY-----\n");


            return Builder.ToString();

            }

        public static void Dump (this RSAParameters RSAParameters) {
            RSAParameters.Modulus.Dump("Modulus");
            RSAParameters.Exponent.Dump("Exponent");
            RSAParameters.P.Dump("P");
            RSAParameters.Q.Dump("Q");
            RSAParameters.D.Dump("D");
            RSAParameters.DP.Dump("DP");
            RSAParameters.DQ.Dump("DQ");
            RSAParameters.InverseQ.Dump("InverseQ");
            }

        public static void Dump (this byte[] Data, string Tag) {
            

            //Console.WriteLine("{0} : [{1}]  {2}.{3}.{4} ... {5}.{6}.{7}",
            //    Tag, Data.Length, Data[0], Data[1], Data[2],
            //        Data[Data.Length - 3],  Data[Data.Length - 2],  Data[Data.Length - 1]);

            }

        }
    }
