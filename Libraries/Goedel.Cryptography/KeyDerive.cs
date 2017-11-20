using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// Base class for key derivation functions
    /// </summary>
    public abstract class KeyDerive {

        /// <summary>Salt used to derive keys to authenticate messages send by the client, i.e. the initiator
        /// to the server.</summary>
        public readonly byte[] SaltClientToServerAuthenticate = "ClientToServerAuthenticate".ToBytes();
        /// <summary>Salt used to derive keys to authenticate messages send by the server, i.e. the responder
        /// to the client.</summary>
        public readonly byte[] SaltServerToClientAuthenticate = "ServerToClientAuthenticate".ToBytes();
        /// <summary>Salt used to derive keys to encrypt messages send by the client, i.e. the initiator
        /// to the server.</summary>
        public readonly byte[] SaltClientToServerEncrypt = "ClientToServerEncrypt".ToBytes();
        /// <summary>Salt used to derive keys to encrypt messages send by the server, i.e. the responder
        /// to the client.</summary>
        public readonly byte[] SaltServerToClientEncrypt = "ServerToClientEncrypt".ToBytes();



        /// <summary>Key used to authenticate messages send by the client, i.e. the initiator
        /// to the server.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ClientToServerAuthenticate(int Length) {
            return Derive(SaltClientToServerAuthenticate, Length);
            }
        /// <summary>Key used to authenticate messages send by the server, i.e. the responder
        /// to the client.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ClientToServerToClientAuthenticate(int Length) {
            return Derive(SaltServerToClientAuthenticate, Length);
            }
        /// <summary>Key used to encrypt messages send by the client, i.e. the initiator
        /// to the server.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ClientToServerEncrypt(int Length) {
            return Derive(SaltClientToServerEncrypt, Length);
            }
        /// <summary>Key used to encrypt messages send by the server, i.e. the responder
        /// to the client.</summary>
        /// <param name="Length">The key length in bits</param>
        /// <returns>The key value</returns>
        public virtual byte[] ServerToClientEncrypt(int Length) {
            return Derive(SaltServerToClientEncrypt, Length);
            }

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

        CryptoProviderAuthentication Provider;

        /// <summary>The Pseudorandom key constructed from the IKM and salt</summary>
        public byte[] PRK;

        /// <summary>The Pseudorandom key constructed from the IKM and salt</summary>
        public int DefaultLength { get; set; } = 256;

        /// <summary>
        /// Construct a KDF instance for the specified keying material
        /// </summary>
        /// <param name="IKM">The input Keying material</param>
        /// <param name="Salt">A salt to vary the key derivation by application</param>
        /// <param name="Algorithm">The MAC algorithm to use</param>
        public KeyDeriveHKDF(byte[] IKM, string Salt = null,
                CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default) :
                        this (IKM, Salt?.ToBytes(), Algorithm) {
            }


        /// <summary>
        /// Construct a KDF instance for the specified keying material
        /// </summary>
        /// <param name="IKM">The input Keying material</param>
        /// <param name="Salt">A salt to vary the key derivation by application</param>
        /// <param name="Algorithm">The MAC algorithm to use</param>
        public KeyDeriveHKDF (byte[] IKM, byte[] Salt=null, 
                CryptoAlgorithmID Algorithm =CryptoAlgorithmID.Default) : this (
                    IKM, Salt, CryptoCatalog.Default.GetAuthentication(Algorithm)) {
            }

        /// <summary>
        /// Construct a KDF instance for the specified keying material
        /// </summary>
        /// <param name="IKM">The input Keying material</param>
        /// <param name="Salt">A salt to vary the key derivation by application</param>
        /// <param name="Provider">Provider for the MAC algorithm to use</param>
        public KeyDeriveHKDF(byte[] IKM, byte[] Salt,
                CryptoProviderAuthentication Provider) {

            this.Provider = Provider;
            PRK = Extract(Provider, IKM, Salt);
            }

        /// <summary>
        /// Key Derivation function
        /// </summary>
        /// <param name="Info">The information to be used to vary this key</param>
        /// <param name="Length">The length of the key to extract</param>
        /// <returns>The derrived key.</returns>
        public override byte[] Derive(byte[] Info, int Length = 0) {
            Length = Length == 0 ? DefaultLength : Length;

            return Expand(Provider, PRK, Length, Info);
            }

        static readonly byte[] NullKey = new byte[0];

        /// <summary>
        /// The extraction function
        /// </summary>
        /// <param name="Provider">The authentication provider.</param>
        /// <param name="IKM">The initial keying material</param>
        /// <param name="Salt">Salt to be used to vary the derived key across domains.</param>
        /// <returns>The extracted value.</returns>
        public static byte[] Extract(CryptoProviderAuthentication Provider,
                    byte[] IKM, byte[] Salt = null) {
            var Key = Salt ?? new byte[Provider.Size/8];

            return Provider.ProcessData(IKM,  Key);
            }

        /// <summary>
        /// The expansion function
        /// </summary>
        /// <param name="Provider">The authentication provider.</param>
        /// <param name="PRK">The pseudo-random key.</param>
        /// <param name="Length">Length of output key in bits</param>
        /// <param name="Info">Information data</param>
        /// <returns>The expanded value.</returns>
        public static byte[] Expand(CryptoProviderAuthentication Provider,
            byte[] PRK, int Length, byte[] Info = null) {

            Info = Info ?? NullKey;

            var Result = new byte[Length / 8];

            Assert.True(Length < (255 * (Provider.Size / 8)), ImplementationLimit.Throw);

            byte Index = 1;

            // Calculate T1 and add to Result
            var Data = new byte[Info.Length+1];
            Data.AppendChecked(0, Info);
            Data[Data.Length-1] = Index++;
            var T = Provider.ProcessData(Data, PRK);
            var Offset = Result.AppendChecked(0, T);

            Data = new byte[T.Length + Info.Length + 1];
            Data.AppendChecked(T.Length, Info);

            while (Offset < Result.Length) {
                Data.AppendChecked(0, T);
                Data[Data.Length - 1] = Index++;
                T = Provider.ProcessData(Data, PRK);
                Offset = Result.AppendChecked(Offset, T);
                }

            return Result;
            }
        }
    }
