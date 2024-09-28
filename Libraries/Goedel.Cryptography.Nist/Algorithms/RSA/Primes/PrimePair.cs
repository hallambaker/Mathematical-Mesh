
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Record holding a prime pair.
/// </summary>
public record PrimePair {

    ///<summary>The prime P.</summary> 
    public BigInteger P { get; set; }

    ///<summary>The prime Q.</summary> 
    public BigInteger Q { get; set; }
    }

