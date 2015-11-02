using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Protocol {
    partial class Constants {

        public static string[] JoseTags = {
            "alg", "jku", "jwk", "kid", "x5u", "x5c", "x5t", "x5t#S256", "typ", "cty", "crit", 
            "enc", "zip", "kty", "use", "key_ops", "sig", "sign", "verify", "encrypt", "decrypt",
            "wrapKey", "unwrapKey", "deriveKey", "deriveBits", 
            "HS256", "HS384", "HS512", "RS256", "RS384", "RS512", "ES256", "ES384", "ES512",
            "PS256", "PS384", "PS512", "none", "RSA1_5", "RSA-OAEP", "RSA-OAEP-256", 
            "A128KW", "A192KW", "A256KW", "dir", "ECDH-ES", "ECDH-ES+A128KW", "ECDH-ES+A192KW",
            "ECDH-ES+A256KW", "A128GCMKW", "A192GCMKW", "A256GCMKW", "PBES2-HS256+A128KW",
            "PBES2-HS384+A192KW", "PBES2-HS512+A256KW", "A128CBC-HS256", "A192CBC-HS384",
            "A256CBC-HS512", "A128GCM", "A192GCM", "A256GCM",
            "epk", "apu", "apv", "iv", "tag", "p2s", "p2c", "DEF", "crv", "x", "y", "d",
            "n", "e", "p", "q", "dp", "qi", "oth", "k", "P-256", "P-384", "P-521",
            "Protected", "Header", "Payload", "Signature"
           };

        public static Dictionary<string, int> MakeDictionary(string[] Tags) {
            var Result = new Dictionary<string, int>(Tags.Length);

            for (var i = 0; i<Tags.Length; i++) {
                Result.Add(Tags[i], i);
                }

            return Result;
            }


        }
    }
