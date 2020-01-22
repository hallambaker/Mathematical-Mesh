using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// Base class for key derivation functions
    /// </summary>
    public abstract class KeyDerive {

        /// <summary>Salt used to derive keys to authenticate messages send by the client, i.e. the initiator
        /// to the server.</summary>
        public static readonly byte[] KeyedUDFMaster = "KeyedUDFMaster".ToBytes();
        /// <summary>Salt used to derive keys to authenticate messages send by the client, i.e. the initiator
        /// to the server.</summary>
        public static readonly byte[] KeyedUDFExpand = "KeyedUDFExpand".ToBytes();



        /// <summary>Salt used to derive keys to authenticate messages send by the client, i.e. the initiator
        /// to the server.</summary>
        public static readonly byte[] SaltClientToServerAuthenticate = "ClientToServerAuthenticate".ToBytes();
        /// <summary>Salt used to derive keys to authenticate messages send by the server, i.e. the responder
        /// to the client.</summary>
        public static readonly byte[] SaltServerToClientAuthenticate = "ServerToClientAuthenticate".ToBytes();
        /// <summary>Salt used to derive keys to encrypt messages send by the client, i.e. the initiator
        /// to the server.</summary>
        public static readonly byte[] SaltClientToServerEncrypt = "ClientToServerEncrypt".ToBytes();
        /// <summary>Salt used to derive keys to encrypt messages send by the server, i.e. the responder
        /// to the client.</summary>
        public static readonly byte[] SaltServerToClientEncrypt = "ServerToClientEncrypt".ToBytes();



        /// <summary>Key used to authenticate messages send by the client, i.e. the initiator
        /// to the server.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ClientToServerAuthenticate(int Length) => Derive(SaltClientToServerAuthenticate, Length);
        /// <summary>Key used to authenticate messages send by the server, i.e. the responder
        /// to the client.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ClientToServerToClientAuthenticate(int Length) => Derive(SaltServerToClientAuthenticate, Length);
        /// <summary>Key used to encrypt messages send by the client, i.e. the initiator
        /// to the server.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ClientToServerEncrypt(int Length) => Derive(SaltClientToServerEncrypt, Length);
        /// <summary>Key used to encrypt messages send by the server, i.e. the responder
        /// to the client.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ServerToClientEncrypt(int Length) => Derive(SaltServerToClientEncrypt, Length);

        /// <summary>
        /// Key Derivation function
        /// </summary>
        /// <param name="Info">The information to be used to vary this key</param>
        /// <param name="Length">The length of the key to extract in bits</param>
        /// <returns>The key agreement result.</returns>
        public abstract byte[] Derive(byte[] Info, int Length = 0);

        }


    /// <summary>
    /// The HKDF function described in RFC 5869
    /// </summary>
    public class KeyDeriveHKDF : KeyDerive {

        //CryptoProviderAuthentication Provider;
        CryptoAlgorithmID algorithm;

        /// <summary>The Pseudorandom key constructed from the IKM and salt</summary>
        public byte[] PRK { get; set; }

        /// <summary>The Pseudorandom key constructed from the IKM and salt</summary>
        public int DefaultLength { get; set; } = 256;

        /// <summary>
        /// Construct a KDF instance for the specified keying material
        /// </summary>
        /// <param name="ikm">The input Keying material</param>
        /// <param name="salt">A salt to vary the key derivation by application</param>
        /// <param name="algorithm">The MAC algorithm to use</param>
        public KeyDeriveHKDF(byte[] ikm, string salt = null,
                CryptoAlgorithmID algorithm = CryptoAlgorithmID.Default) :
                        this(ikm, salt?.ToBytes(), algorithm) {
            }


        /// <summary>
        /// Construct a KDF instance for the specified keying material
        /// </summary>
        /// <param name="ikm">The input Keying material</param>
        /// <param name="salt">A salt to vary the key derivation by application</param>
        /// <param name="algorithm">The MAC algorithm to use</param>
        public KeyDeriveHKDF(byte[] ikm, byte[] salt = null,
                CryptoAlgorithmID algorithm = CryptoAlgorithmID.Default) {
            this.algorithm = algorithm;
            PRK = Extract(this.algorithm, ikm, salt);
            }

        /// <summary>
        /// Key Derivation function
        /// </summary>
        /// <param name="Info">The information to be used to vary this key</param>
        /// <param name="Length">The length of the key to extract</param>
        /// <returns>The derrived key.</returns>
        public override byte[] Derive(byte[] Info, int Length = 0) {
            Length = Length == 0 ? DefaultLength : Length;

            return Expand(algorithm, PRK, Length, Info);
            }

        static readonly byte[] NullKey = new byte[0];

        /// <summary>
        /// Construct a HKDF instance for algorithm <paramref name="algorithm"/>, generate
        /// a PRK from the values <paramref name="ikm"/> and <paramref name="salt"/>,
        /// then use it to generate an output value od <paramref name="length"/> bits
        /// with additional input <paramref name="info"/>.
        /// </summary>
        /// <param name="ikm"></param>
        /// <param name="salt"></param>
        /// <param name="info"></param>
        /// <param name="length"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public static byte[] Derive(
                byte[] ikm, byte[] salt = null, byte[] info = null, int length = 0,
                CryptoAlgorithmID algorithm = CryptoAlgorithmID.Default) {
            var kdf = new KeyDeriveHKDF(ikm, salt, algorithm);
            return kdf.Derive(info, length);
            }


        /// <summary>
        /// Generate <paramref name="length"/> random bits using <paramref name="ikm"/> as a seed value and
        /// <paramref name="salt"/> as a salt.
        /// <para>This function is intended to be used to provide a pseudo-random number 
        /// generator for testing purposes and to securely generate nonces.</para>
        /// </summary>
        /// <param name="ikm">The initial keying material.</param>
        /// <param name="length">The number of bits to return.</param>
        /// <param name="salt">Optional salt value.</param>
        /// <returns>The pseudo-random output.</returns>
        public static byte[] Random(byte[] ikm, int length = 128, byte[] salt = null) {
            var prk = Extract(CryptoAlgorithmID.Default, ikm, salt);
            return Expand(CryptoAlgorithmID.Default, prk, length);

            }


        /// <summary>
        /// The extraction function
        /// </summary>
        /// <param name="algorithm">The MAC algorithm to use</param>
        /// <param name="IKM">The initial keying material</param>
        /// <param name="Salt">Salt to be used to vary the derived key across domains.</param>
        /// <returns>The extracted value.</returns>
        public static byte[] Extract(CryptoAlgorithmID algorithm,
                    byte[] IKM, byte[] Salt = null) {
            var (size, _) = algorithm.GetKeySize();

            var Key = Salt ?? new byte[size / 8];
            return IKM.GetMAC(Key, cryptoAlgorithmID: algorithm);
            }

        /// <summary>
        /// The expansion function
        /// </summary>
        /// <param name="algorithm">The MAC algorithm to use</param>
        /// <param name="prk">The pseudo-random key.</param>
        /// <param name="length">Length of output key in bits</param>
        /// <param name="info">Information data</param>
        /// <returns>The expanded value.</returns>
        public static byte[] Expand(CryptoAlgorithmID algorithm,
            byte[] prk, int length, byte[] info = null) {

            var (size, _) = algorithm.GetKeySize();
            info ??= NullKey;

            var result = new byte[length / 8];

            Assert.True(length < (255 * (size / 8)), ImplementationLimit.Throw);

            byte index = 1;

            // Calculate T1 and add to Result
            var data = new byte[info.Length + 1];
            data.AppendChecked(0, info);
            data[^1] = index++;
            var t = data.GetMAC(prk, cryptoAlgorithmID: algorithm);

            var offset = result.AppendChecked(0, t);

            data = new byte[t.Length + info.Length + 1];
            data.AppendChecked(t.Length, info);

            while (offset < result.Length) {
                data.AppendChecked(0, t);
                data[^1] = index++;
                t = data.GetMAC(prk, cryptoAlgorithmID: algorithm);
                offset = result.AppendChecked(offset, t);
                }

            return result;
            }




        }
    }
