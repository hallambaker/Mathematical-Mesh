namespace Goedel.Cryptography.Nist;

/// <summary>
/// Result of calculating a hash.
/// </summary>
public class HashResult {

    ///<summary></summary> 
    public BitString Digest { get; set; }

    /// <summary>
    /// Constructor, return an instance for <paramref name="digest"/>
    /// </summary>
    /// <param name="digest">The digest value.</param>
    public HashResult(BitString digest) {
        Digest = digest;
        }



    }

