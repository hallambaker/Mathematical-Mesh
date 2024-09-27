namespace Goedel.Cryptography.Nist;
public class EccKeyPair : IDsaKeyPair {
    public EccPoint PublicQ { get; } 
    public BigInteger PrivateD { get; }



    public EccKeyPair(EccPoint q, BigInteger d) {
        PublicQ = q;
        PrivateD = d;
        }

    }

