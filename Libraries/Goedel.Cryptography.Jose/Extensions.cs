using System;
using System.Collections.Generic;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Jose {

    /// <summary>Static class containing convenience functions</summary>
    public static class Extensions {
        public static byte[] GetDigest(this string fileName, string algID) =>
             CryptoStreamFromID.GetDigestOfFile(fileName, algID.ToCryptoAlgorithmID(CryptoAlgorithmID.SHA_2_512));

        }
    }
