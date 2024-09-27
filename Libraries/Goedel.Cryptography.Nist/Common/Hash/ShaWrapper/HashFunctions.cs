namespace Goedel.Cryptography.Nist;
public enum HashFunctions {
    ///<summary>None</summary> 
    [EnumMember(Value = "none")]
    None,
    ///<summary>SHA3 256 bit</summary> 
    [EnumMember(Value = "SHA3-256")]
    Sha3_d256,
    ///<summary>SHA3 384 bit</summary> 
    [EnumMember(Value = "SHA3-384")]
    Sha3_d384,
    ///<summary>SHA3 512 bit</summary> 
    [EnumMember(Value = "SHA3-512")]
    Sha3_d512,
    }

