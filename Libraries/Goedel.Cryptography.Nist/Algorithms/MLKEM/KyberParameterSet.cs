
namespace Goedel.Cryptography.Nist;

/// <summary>
/// ML-KEM parameter sets
/// </summary>
public enum KyberParameterSet {
    ///<summary>None</summary> 
    None,

    ///<summary>ML-KEM-512</summary> 
    [EnumMember(Value = "ML-KEM-512")]
    ML_KEM_512,

    ///<summary>ML-KEM-768</summary> 
    [EnumMember(Value = "ML-KEM-768")]
    ML_KEM_768,

    ///<summary>ML-KEM-1024</summary> 
    [EnumMember(Value = "ML-KEM-1024")]
    ML_KEM_1024
    }
