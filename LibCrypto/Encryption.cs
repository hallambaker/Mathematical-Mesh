using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Goedel.LibCrypto {
    /// <summary>
    /// Provider for bulk encryption algorithms (e.g. AES).
    /// </summary>
    public abstract class CryptoProviderEncryption : CryptoProviderBulk {

        /// <summary>
        /// The type of algorithm
        /// </summary>
        public override CryptoAlgorithmClass AlgorithmClass { get { return CryptoAlgorithmClass.Encryption; } }

        private SymmetricAlgorithm _Provider;

        /// <summary>
        /// The Key under which encryption/decryption is performed.
        /// </summary>
        public byte[] Key {
            get { return _Provider.Key; }
            set { _Provider.Key = value; }
            }

        /// <summary>
        /// The initialization vector under which encryption/decryption is performed.
        /// </summary>
        public byte[] IV {
            get { return _Provider.IV; }
            set { _Provider.IV = value; }
            }
        /// <summary>
        /// The .NET cryptographic provider (for use by sub classes).
        /// </summary>
        protected SymmetricAlgorithm Provider {
            get { return _Provider; }
            set { _Provider = value; }
            }
        ICryptoTransform Transform = null;
        bool Encrypting;

        /// <summary>
        /// If set to true, the initialization vector (if used) will be prepended to the
        /// output byte stream.
        /// </summary>
        public bool AppendIV = false;

        /// <summary>
        /// If set to true, the authentication code (if created) will be prepended to the
        /// output byte stream.
        /// 
        /// Since we don't currently have a GCM mode, this isn't currently used.
        /// </summary>
        public bool AppendIntegrity = false;

        /// <summary>
        /// Constructor for initializing a delegate class.
        /// </summary>
        /// <param name="SymmetricAlgorithm">Cryptographic provider.</param>
        /// <param name="KeySize">Key size in bits.</param>
        /// <param name="CipherMode">Cipher mode to use</param>
        protected CryptoProviderEncryption(SymmetricAlgorithm SymmetricAlgorithm,
                int KeySize, CipherMode CipherMode) {
            this.Provider = SymmetricAlgorithm;
            Provider.KeySize = KeySize;
            Provider.Mode = CipherMode;
            }

        /// <summary>
        /// Start an encryption session with random key and IV.
        /// </summary>
        public virtual void StartEncrypt() {
            Encrypting = true;
            Provider.GenerateKey();
            Provider.GenerateIV();
            }

        /// <summary>
        /// Start an encryption session with the specified key and IV.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        public virtual void StartEncrypt(byte[] Key, byte[] IV) {
            Encrypting = true;
            if (Key != null) {
                Provider.Key = Key;
                }
            else {
                Provider.GenerateKey();
                }
            if (Key != null) {
                Provider.IV = IV;
                }
            else {
                Provider.GenerateIV();
                }
            }

        /// <summary>
        /// Start a decryption session with the specified key and implicit IV.
        /// </summary>
        /// <param name="Key"></param>
        public virtual void StartDecrypt(byte[] Key) {
            AppendIntegrity = true;
            Encrypting = false;
            Provider.Key = Key;
            Provider.GenerateIV();
            }

        /// <summary>
        /// Start a decryption session with the specified key and IV.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        public virtual void StartDecrypt(byte[] Key, byte[] IV) {
            AppendIntegrity = false;
            Encrypting = false;
            if (Key != null) {
                Provider.Key = Key;
                }
            else {
                Provider.GenerateKey();
                }
            if (Key != null) {
                Provider.IV = IV;
                }
            else {
                Provider.GenerateIV();
                }
            }


        /// <summary>
        /// Encrypt the provided cryptoblob
        /// </summary>
        public virtual CryptoData Encrypt(byte [] Data) {
            StartEncrypt();
            return Process(Data);
            }


        /// <summary>
        /// Encrypt the provided cryptoblob
        /// </summary>
        public virtual CryptoData Encrypt(CryptoData Input) {
            StartEncrypt(Input.Key, Input.IV);
            return Process(Input);
            }

        /// <summary>
        /// Start an encryption session with random key and IV.
        /// </summary>
        public virtual CryptoData Decrypt(CryptoData Input, byte[] Data) {
            StartDecrypt(Input.Key, Input.IV);
            return Process(Data);
            }


        /// <summary>
        /// Processes the specified region of the specified byte array
        /// </summary>
        /// <param name="InputBuffer">The input to process</param>
        /// <param name="InputOffset">The offset into the byte array from which to begin using data.</param>
        /// <param name="Count">The number of bytes in the array to use as data.</param>
        /// <returns>The result of the cryptographic operation.</returns>
        public override CryptoData Process(byte[] InputBuffer, int InputOffset, int Count) {

            int FullBlocks;
            int ExtraBytes;
            int LastOffset = 0;
            
            if (Encrypting) {
                Transform = Provider.CreateEncryptor();
                FullBlocks = Count / Transform.InputBlockSize;
                ExtraBytes = AppendIV ? Transform.InputBlockSize : 0;

                // calculate extra bytes required for padding
                if (Provider.Mode == CipherMode.CBC) {
                    ExtraBytes += Transform.OutputBlockSize;
                    }
                else if (Provider.Mode == CipherMode.CTS) {
                    // Cipher Text Stealling does not require padding unless there is
                    // less than a full block in the input.
                    ExtraBytes += FullBlocks == 0 ? Transform.OutputBlockSize : Count % Transform.InputBlockSize;
                    }
                }
            else {
                Transform = Provider.CreateDecryptor();
                FullBlocks = (Count / Transform.InputBlockSize) - 1 - (AppendIV ? 1 : 0);
                // This will always be more than needed.
                ExtraBytes = Transform.OutputBlockSize;
                LastOffset = FullBlocks > 0 ? Transform.OutputBlockSize : 0;
                }


            // Here we will need to add code to manage the additional data for the
            // integrity check value and initialization when available.

            int TotalBytes = FullBlocks * Transform.OutputBlockSize + ExtraBytes;

            byte[] OutputBuffer = new byte[TotalBytes];
            int OutputOffset = 0;


            if (AppendIV) {
                Array.Copy(Provider.IV, OutputBuffer, Provider.IV.Length);
                OutputOffset += Provider.IV.Length;
                }

            if (FullBlocks == 0) {
                }
            else if (Transform.CanTransformMultipleBlocks) { // Can we do it the fast way?
                Transform.TransformBlock(InputBuffer, InputOffset, FullBlocks * Transform.InputBlockSize,
                    OutputBuffer, OutputOffset);
                InputOffset += FullBlocks * Transform.InputBlockSize;
                OutputOffset += FullBlocks * Transform.OutputBlockSize;

                }
            else { // Do it the lame way
                for (var i = 0; i < FullBlocks; i++) {
                    Transform.TransformBlock(InputBuffer, InputOffset, Transform.InputBlockSize,
                        OutputBuffer, OutputOffset);
                    InputOffset += Transform.InputBlockSize;
                    OutputOffset += Transform.OutputBlockSize;
                    }               
                }
            
            var LastBlock = Transform.TransformFinalBlock(InputBuffer, InputOffset,
                Count - FullBlocks * Transform.InputBlockSize);

            Array.Copy(LastBlock, 0, OutputBuffer, OutputOffset - LastOffset, LastBlock.Length);
            Array.Resize(ref OutputBuffer, TotalBytes - Transform.OutputBlockSize + LastBlock.Length - LastOffset);
            var CryptoResult = new CryptoData(CryptoAlgorithmID.NULL, null, null, OutputBuffer);

            CryptoResult.IV = IV;
            CryptoResult.Key = Key;
            return CryptoResult;
            }
        }



    /// <summary>
    /// Provider for the SHA-2 256 bit Hash Algorithm
    /// </summary>
    public class CryptoProviderEncryptAES : CryptoProviderEncryption {

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm {
            get {
                return new CryptoAlgorithm(
                    CryptoAlgorithmID, Name, Size,
                    null, null, null,
                    "http://www.w3.org/2001/04/xmlenc#aes128-cbc",
                    CryptoAlgorithmClass.Encryption,
                    GetCryptoProvider);
                }
            }



        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID {
            get {
                if (Provider.KeySize == 128) {
                    if (Provider.Mode == CipherMode.CBC) {

                        return CryptoAlgorithmID.AES128CBC;
                        }
                    else {
                        return CryptoAlgorithmID.AES128CTS;
                        }
                    }
                else {
                    if (Provider.Mode == CipherMode.CBC) {

                        return CryptoAlgorithmID.AES256CBC;
                        }
                    else {
                        return CryptoAlgorithmID.AES256CTS;
                        }
                    }
                }
            }
        /// <summary>
        /// .NET Framework name
        /// </summary>
        public override string Name {
            get {
                return "AES";
                }
            }
        /// <summary>
        /// JSON Algorithm Name
        /// </summary>
        public override string JSONName {
            get {
                return "AE128";
                }
            }
        /// <summary>
        /// Default algorithm key size.
        /// </summary>
        public override int Size {
            get {
                return Provider.KeySize;
                }
            }
        /// <summary>
        /// Returns the default crypto provider.
        /// </summary>
        public override GetCryptoProvider GetCryptoProvider {
            get {
                return Factory;
                }
            }
        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID DigestAlgorithm) {
            return new CryptoProviderEncryptAES(KeySize);
            }

        /// <summary>
        /// Create an AES provider with the specified key size.
        /// </summary>
        /// <param name="KeySize"></param>
        public CryptoProviderEncryptAES(int KeySize)
            : base(new AesManaged(), KeySize, CipherMode.CBC) {
            }

        /// <summary>
        /// Create an AES provider with the specified key size and mode.
        /// </summary>
        /// <param name="KeySize">Key Size in bits.</param>
        /// <param name="CipherMode">The cipher mode to use (CBC or CTS).</param>
        public CryptoProviderEncryptAES(int KeySize, CipherMode CipherMode)
            : base(new AesManaged(), KeySize, CipherMode) {
            }

        }


    }