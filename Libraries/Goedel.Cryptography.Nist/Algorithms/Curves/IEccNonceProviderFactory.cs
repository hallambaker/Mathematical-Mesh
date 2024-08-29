namespace Goedel.Cryptography.Nist;
public interface IEccNonceProviderFactory {
    IEccNonceProvider GetNonceProvider(NonceProviderTypes nonceTypes, IHmac hmac, IEntropyProvider entropyProvider);
    }

