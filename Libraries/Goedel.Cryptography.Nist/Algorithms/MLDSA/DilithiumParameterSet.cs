
namespace Goedel.Cryptography.Nist;

/// <summary>
/// ML-DSA algorithm strength identifiers.
/// </summary>
public enum DilithiumParameterSet {
    ///<summary>Unspecified, use default.</summary> 
    None,

    ///<summary>Security level 2.</summary> 
    [EnumMember(Value = "ML-DSA-44")]
    ML_DSA_44,

    ///<summary>Security level 3.</summary> 
    [EnumMember(Value = "ML-DSA-65")]
    ML_DSA_65,

    ///<summary>Security level 5.</summary> 
    [EnumMember(Value = "ML-DSA-87")]
    ML_DSA_87
    }
