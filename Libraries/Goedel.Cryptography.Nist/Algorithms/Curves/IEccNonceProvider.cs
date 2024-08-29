namespace Goedel.Cryptography.Nist;
public interface IEccNonceProvider {
        BigInteger GetNonce(BigInteger privateD, BigInteger hashedMessage, BigInteger orderN);
        }
    
