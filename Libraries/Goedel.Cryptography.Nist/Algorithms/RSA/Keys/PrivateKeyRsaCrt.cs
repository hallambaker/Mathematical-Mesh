
namespace Goedel.Cryptography.Nist;

/// <summary>
/// RSA private key in CRT form.
/// </summary>
public class PrivateKeyRsaCrt  {
    ///<summary>Prime1</summary> 
    public BigInteger P { get; set; }

    ///<summary>Prime2</summary> 
    public BigInteger Q { get; set; }

    ///<summary>PrivateExponent</summary> 
    public BigInteger D { get; set; }

    ///<summary>Exponent1</summary> 
    public BigInteger DMP1 { get; set; }

    ///<summary>Exponent2</summary> 
    public BigInteger DMQ1 { get; set; }

    ///<summary>Coefficient</summary> 
    public BigInteger IQMP { get; set; }

    }
