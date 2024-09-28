
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Probable prime generator result.
/// </summary>
public class PpfResult {

    ///<summary>The prime.</summary> 
    public BigInteger Prime { get; }

    ///<summary>The XPrime.</summary> 
    public BigInteger XPrime { get; }

    /// <summary>
    /// Constuctor returning instance for <paramref name="p"/>, <paramref name="xp"/>
    /// </summary>
    /// <param name="p">The prime.</param>
    /// <param name="xp">The XPrime.</param>
    public PpfResult(BigInteger p, BigInteger xp) {
        Prime = p;
        XPrime = xp;
        }




    }

