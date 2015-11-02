using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.CryptoLibNG;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Jose {

    public partial class Key {
        public virtual KeyPair GetKeyPair () {
            return null;
            }

        public static Key GetPublic(KeyPair KeyPair) {
            if (KeyPair as RSAKeyPair != null) {
                return new PublicKeyRSA(KeyPair as RSAKeyPair);
                }
            return null;
            }

        public static Key GetPrivate(KeyPair KeyPair) {
            if (KeyPair as RSAKeyPair != null) {
                return new PrivateKeyRSA(KeyPair as RSAKeyPair);
                }
            return null;
            }

        }


    public partial class PublicKeyRSA  {

        public PublicKeyRSA(RSAKeyPair KeyPair) {
            kid = KeyPair.UDF;
            var Provider = KeyPair.Provider;
            var Parameters = Provider.ExportParameters(false);

            n = Parameters.Modulus;
            e = Parameters.Exponent;
            }

        public virtual RSAParameters RSAParameters() {
            var RSAParameters = new RSAParameters();
            RSAParameters.Modulus = n;
            RSAParameters.Exponent = e;

            return RSAParameters;
            }

        public override KeyPair GetKeyPair() {
            var Parameters = RSAParameters();
            return new RSAKeyPair(Parameters);
            }

        }


    public partial class PrivateKeyRSA {

        public PrivateKeyRSA(RSAKeyPair KeyPair) {
            kid = KeyPair.UDF;
            var Provider = KeyPair.Provider;
            var Parameters = Provider.ExportParameters(true);

            n = Parameters.Modulus;
            e = Parameters.Exponent;
            d = Parameters.D;
            p = Parameters.P;
            q = Parameters.Q;
            dp = Parameters.DP;
            dq = Parameters.DQ;
            qi = Parameters.InverseQ;
            }

        public override RSAParameters RSAParameters() {

            var RSAParameters = new RSAParameters();
            RSAParameters.Modulus = n;
            RSAParameters.Exponent = e;
            RSAParameters.D = d;
            RSAParameters.P = p;
            RSAParameters.Q = q;
            RSAParameters.DP = dp;
            RSAParameters.DQ = dq;
            RSAParameters.InverseQ = qi;

            return RSAParameters;
            }

        }

    }
