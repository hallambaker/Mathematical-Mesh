namespace Goedel.Cryptography.Nist;

/// <summary>
/// Result of calculating a hash.
/// </summary>
public class HashResult {

    private BitString _digest;


    private readonly byte[] _digestBytes;

    ///<summary></summary> 
    public BitString Digest {
        get {
            if (_digest != null) return _digest;
            if (_digestBytes == null) return null;
            _digest = new BitString(_digestBytes);
            return _digest;
            }
        private set => _digest = value;
        }

    /// <summary>
    /// Constructor, return an instance for <paramref name="digest"/>
    /// </summary>
    /// <param name="digest">The digest value.</param>
    public HashResult(BitString digest) {
        Digest = digest;
        }



    }

