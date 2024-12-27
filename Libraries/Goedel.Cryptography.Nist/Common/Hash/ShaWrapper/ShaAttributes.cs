//namespace Goedel.Cryptography.Nist;

///// <summary>
///// Get SHA information
///// </summary>
//public static class ShaAttributes {
//    private static List<(ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name)> shaAttributes =
//        [
//            (ModeValues.SHA3, DigestSizes.d256, 256, 1088, -1, 256, new byte[] {0x00}, "SHA3-256"),
//            (ModeValues.SHA3, DigestSizes.d384, 384, 832, -1, 384, new byte[] {0x00}, "SHA3-384"),
//            (ModeValues.SHA3, DigestSizes.d512, 512, 576, -1, 512, new byte[] {0x00}, "SHA3-512"),
                
//            // SHAKE has no output limit, but the output size is the common output size
//            (ModeValues.SHAKE, DigestSizes.d128, 128, 1344, -1, 128, new byte[] {0x06, 0x09, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x0B}, "SHAKE-128"),
//            (ModeValues.SHAKE, DigestSizes.d256, 256, 1088, -1, 256, new byte[] {0x00}, "SHAKE-256")
//        ];

//    //public static List<(ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name)> GetShaAttributes() {
//    //    return shaAttributes;
//    //    }





//    }
