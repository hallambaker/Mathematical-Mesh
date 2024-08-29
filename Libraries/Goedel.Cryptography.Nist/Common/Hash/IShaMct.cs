namespace Goedel.Cryptography.Nist;
public interface IShaMct {
    MctResult<AlgoArrayResponse> MctHash(BitString message, bool isSample = false, MathDomain domain = null);
    }

