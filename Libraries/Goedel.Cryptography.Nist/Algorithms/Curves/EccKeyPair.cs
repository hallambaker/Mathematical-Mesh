namespace Goedel.Cryptography.Nist;
public class EccKeyPair : IDsaKeyPair {
        public EccPoint PublicQ { get; set; } = new EccPoint();
        public BigInteger PrivateD { get; set; }

        public EccKeyPair() {

            }

        public EccKeyPair(EccPoint q, BigInteger d) {
            PublicQ = q;
            PrivateD = d;
            }

        public EccKeyPair(EccPoint q) {
            PublicQ = q;
            }

        public EccKeyPair(BigInteger d) {
            PrivateD = d;
            }
        }
    
