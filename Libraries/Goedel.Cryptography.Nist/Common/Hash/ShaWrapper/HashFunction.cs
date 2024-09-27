namespace Goedel.Cryptography.Nist;
public class HashFunction {
    public ModeValues Mode { get; }
    public DigestSizes DigestSize { get; }

    /// <summary>
    /// Output length in bits.
    /// </summary>
    //[JsonIgnore]
    public int OutputLen { get; }

    //[JsonIgnore]
    public int BlockSize { get; }

    //[JsonIgnore]
    public BigInteger MaxMessageLen { get; }

    //[JsonIgnore]
    public int ProcessingLen { get; }

    //[JsonIgnore]
    public string Name { get; }

    //[JsonIgnore]
    public byte[] OID { get; }

    public HashFunction(ModeValues mode, DigestSizes digestSize, bool isXofPss = false) {
        Mode = mode;
        DigestSize = digestSize;

        (ModeValues mode, DigestSizes digestSize, int outputLen, int blockSize, BigInteger maxMessageSize, int processingLen, byte[] OID, string name) attributes;
        if (isXofPss && mode == ModeValues.SHAKE) {
            attributes = ShaAttributes.GetXofPssAttributes(mode, digestSize);
            }
        else {
            attributes = ShaAttributes.GetShaAttributes(mode, digestSize);
            }

        OutputLen = attributes.outputLen;
        BlockSize = attributes.blockSize;
        MaxMessageLen = attributes.maxMessageSize;
        ProcessingLen = attributes.processingLen;
        Name = attributes.name;
        OID = attributes.OID;
        }



    /// <summary>
    /// Get the hash value.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(Mode, DigestSize);
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

