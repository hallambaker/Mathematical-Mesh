namespace Goedel.Cryptography.Nist;

/// <summary>
/// Hash function class.
/// </summary>
public class HashFunction {

    ///<summary>The mode</summary> 
    public ModeValues Mode { get; }

    ///<summary>Sizes in bits</summary> 
    public DigestSizes DigestSize { get; }

    /// <summary>
    /// Constructor, return an instance with parameters specified by <paramref name="mode"/> and
    /// <paramref name="digestSize"/>.
    /// </summary>
    /// <param name="mode">The mode.</param>
    /// <param name="digestSize">Output size</param>
    /// 
    public HashFunction(ModeValues mode, DigestSizes digestSize) {
        Mode = mode;
        DigestSize = digestSize;
        }

    ///// <summary>
    ///// Get the hash value.
    ///// </summary>
    ///// <returns></returns>
    //public override int GetHashCode() => HashCode.Combine(Mode, DigestSize);
    }

/// <summary>
/// Digest mode values.
/// </summary>
public enum ModeValues {
    ///<summary>SHA-3</summary> 
    [EnumMember(Value = "SHA3")]
    SHA3,
    ///<summary>SHAKE</summary> 
    [EnumMember(Value = "SHAKE")]
    SHAKE
    }

/// <summary>
/// Digest mode sizes
/// </summary>
public enum DigestSizes {
    ///<summary>128 bit digest output</summary> 
    [EnumMember(Value = "128")]
    d128,
    ///<summary>256 bit digest output</summary> 
    [EnumMember(Value = "256")]
    d256,
    ///<summary>384 bit digest output</summary> 
    [EnumMember(Value = "384")]
    d384,
    ///<summary>512 bit digest output</summary> 
    [EnumMember(Value = "512")]
    d512,
    ///<summary>None</summary> 
    [EnumMember(Value = "NONE")]
    NONE
    }

