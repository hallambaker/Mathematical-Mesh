
namespace Goedel.Cryptography.Nist;


/// <summary>
/// Enumeration of specified curves.
/// </summary>
public enum NistCurve {

    ///<summary>Curve P-256, (secp256r1)</summary> 
    [EnumMember(Value = "P-256")]
    P256,

    ///<summary>Curve P-384, (secp384r1)</summary> 
    [EnumMember(Value = "P-384")]
    P384,

    ///<summary>Curve P-521, (secp521r1)</summary> 
    [EnumMember(Value = "P-521")]
    P521,       // Should be 521 not 512.

    }

