namespace Goedel.Cryptography.Nist;

/// <summary>
/// Get SHA information
/// </summary>
public static class ShaAttributes {
    private static List<(ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name)> shaAttributes =
        new()
        {
            (ModeValues.SHA3, DigestSizes.d256, 256, 1088, -1, 256, new byte[] {0x00}, "SHA3-256"),
            (ModeValues.SHA3, DigestSizes.d384, 384, 832, -1, 384, new byte[] {0x00}, "SHA3-384"),
            (ModeValues.SHA3, DigestSizes.d512, 512, 576, -1, 512, new byte[] {0x00}, "SHA3-512"),
                
            // SHAKE has no output limit, but the output size is the common output size
            (ModeValues.SHAKE, DigestSizes.d128, 128, 1344, -1, 128, new byte[] {0x06, 0x09, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x0B}, "SHAKE-128"),
            (ModeValues.SHAKE, DigestSizes.d256, 256, 1088, -1, 256, new byte[] {0x00}, "SHAKE-256")
        };

    private static List<(ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name)> xofSignatureAttributes =
        new()
        {
            (ModeValues.SHAKE, DigestSizes.d128, 256, 1344, -1, 128, new byte[] {0x06, 0x09, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x0B}, "SHAKE-128"), // this entry makes SHAKE-128 work as a "Hash" for PSS; FIPS 186-5 requires an outputLen of 256
            (ModeValues.SHAKE, DigestSizes.d256, 512, 1088, -1, 256, new byte[] {0x00}, "SHAKE-256") // this entry makes SHAKE-256 work as a "Hash" for PSS; FIPS 186-5 requires an outputLen of 512
        };

    private static List<(HashFunctions hashFunction, ModeValues modeValue, DigestSizes digestSizes)> _hashFunctionsMap =
        new()
        {
            (HashFunctions.Sha3_d256, ModeValues.SHA3, DigestSizes.d256),
            (HashFunctions.Sha3_d384, ModeValues.SHA3, DigestSizes.d384),
            (HashFunctions.Sha3_d512, ModeValues.SHA3, DigestSizes.d512),
        };

    public static List<(ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name)> GetShaAttributes() {
        return shaAttributes;
        }

    public static List<(ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name)> GetXofSignatureAttributes() {
        return xofSignatureAttributes;
        }


    public static (ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name) GetShaAttributes(ModeValues mode, DigestSizes digestSize) {
        if (!GetShaAttributes().TryFirst(w => w.mode == mode && w.digestSize == digestSize, out var result)) {
            throw new ArgumentException($"Invalid {nameof(mode)}/{nameof(digestSize)} combination");
            }

        return result;
        }

    public static (ModeValues mode, DigestSizes digestSize, int outputLen, 
        int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name) GetXofPssAttributes(ModeValues mode, DigestSizes digestSize) {
        if (!GetXofSignatureAttributes().TryFirst(w => w.mode == mode && w.digestSize == digestSize, out var result)) {
            throw new ArgumentException($"Invalid {nameof(mode)}/{nameof(digestSize)} combination");
            }

        return result;
        }


    }
