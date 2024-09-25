
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

/// <summary>
/// The curve type. Only prime curves are required.
/// </summary>
public enum CurveType {

    ///<summary>Prime curve.</summary> 
    Prime,

    ///<summary>Binary curve</summary> 
    Binary
    }

///<summary>The secret generation mode.</summary> 
public enum SecretGenerationMode {

    ///<summary>Testing candidates, a secret is generated with the number of bits
    ///necessary and rejected if it is too large.</summary> 
    [EnumMember(Value = "testing candidates")]
    TestingCandidates,

    ///<summary>Extra bits, the secret is generated with a suffiently large number of bits that
    ///truncation is unlikely to introduce bias.</summary> 
    [EnumMember(Value = "extra bits")]
    ExtraRandomBits
    }

/// <summary>
/// 
/// </summary>
public enum NonceProviderTypes {
    Random,
    Deterministic
    }

