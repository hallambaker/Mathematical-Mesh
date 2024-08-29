
namespace Goedel.Cryptography.Nist;


public enum KyberFunction {
    None,

    [EnumMember(Value = "encapsulation")]
    Encapsulation,

    [EnumMember(Value = "decapsulation")]
    Decapsulation
    }
