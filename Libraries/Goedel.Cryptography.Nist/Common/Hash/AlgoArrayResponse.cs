namespace Goedel.Cryptography.Nist;
public class AlgoArrayResponse {
    //[JsonIgnore]
    public BitString Message { get; set; }
    //[JsonProperty(PropertyName = "md")]
    public BitString Digest { get; set; }
    //[JsonProperty(PropertyName = "outLen")]
    public int DigestLength => Digest.BitLength;

    //[JsonIgnore] 
    public bool ShouldPrintOutputLength { get; set; } = false;
    }

