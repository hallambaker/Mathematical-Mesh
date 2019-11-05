using Goedel.Cryptography;

namespace Goedel.Mesh {
    public static class Constants {

        public const CryptoAlgorithmID DefaultAlgorithmSignID = CryptoAlgorithmID.Ed448;
        public const CryptoAlgorithmID DefaultAlgorithmEncryptID = CryptoAlgorithmID.Ed448;
        public const CryptoAlgorithmID DefaultAlgorithmAuthenticateID = CryptoAlgorithmID.Ed448;

        public static CryptoAlgorithmID DefaultAlgorithmSign(this CryptoAlgorithmID cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmSignID);
        public static CryptoAlgorithmID DefaultAlgorithmEncrypt(this CryptoAlgorithmID cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmEncryptID);
        public static CryptoAlgorithmID DefaultAlgorithmAuthenticate(this CryptoAlgorithmID cryptoAlgorithmID) =>
            cryptoAlgorithmID.DefaultMeta(DefaultAlgorithmAuthenticateID);

        }
    }
