namespace Goedel.Cryptography.Nist;
public interface IcSHAKE {
        HashResult HashMessage(HashFunction hashFunction, BitString message, string customization, string functionName = "");
        HashResult HashMessage(HashFunction hashFunction, BitString message, BitString customization, string functionName = "");
        }
    
