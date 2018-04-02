using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography;
using Goedel.Cryptography.Container;
using Goedel.Cryptography.Jose;
using Goedel.IO;

namespace Goedel.Recrypt {

    /// <summary>
    /// 
    /// </summary>
    public class FileContainerReaderDecrypting : FileContainerReader {
        SessionPersonal SessionPersonal;


        /// <summary>
        /// Open an existing file container in read mode.
        /// </summary>
        /// <param name="FileName">The file name to read</param>
        /// <param name="ReadIndex">If true, read the container index to permit random access</param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits read access.</param>
        /// <returns>File Container instance</returns>
        public FileContainerReaderDecrypting (
                SessionPersonal SessionPersonal,
                string FileName,
                bool ReadIndex = true,
                FileStatus FileStatus = FileStatus.Read) : base(FileName, ReadIndex, FileStatus) {
            this.SessionPersonal = SessionPersonal;
            }

        /// <summary>
        /// Open 
        /// </summary>
        /// <param name="Data"></param>
        public FileContainerReaderDecrypting (
                SessionPersonal SessionPersonal,
                byte[] Data) : base(Data) {
            this.SessionPersonal = SessionPersonal;
            }


        /// <summary>
        /// Perform a Key Exchange
        /// </summary>
        /// <param name="Recipients">The list of recipients</param>
        /// <param name="AlgorithmID">The bulk encryption algorithm</param>
        /// <returns>The result of the key exchange.</returns>
        public override byte[] GetExchange (List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) {
            foreach (var Recipient in Recipients) {

                var DecryptionKey = TryMatchRecipient(Recipient);

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                if (DecryptionKey != null) {
                    return DecryptionKey.Decrypt(Recipient.EncryptedKey,
                            Recipient.Header.Epk.KeyPair, AlgorithmID: AlgorithmID);
                    }
                }


            return null;
            }



        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="Recipient">The recipient to match</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public KeyPair TryMatchRecipient (Recipient Recipient) {
            var KID = Recipient.Header.Kid;

            KID.SplitAccountID(out var Account, out var Domain);
            if (Domain != null) {
                return KeyPair.FindLocal(Account);
                }
            else {
                return KeyPair.FindLocal(KID);
                }
            }

        }


    /// <summary>
    /// 
    /// </summary>
    public class FileContainerReaderRecrypting : FileContainerReaderDecrypting {

        SessionPersonal SessionPersonal;


        /// <summary>
        /// Open an existing file container in read mode.
        /// </summary>
        /// <param name="FileName">The file name to read</param>
        /// <param name="ReadIndex">If true, read the container index to permit random access</param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits read access.</param>
        /// <returns>File Container instance</returns>
        public FileContainerReaderRecrypting (
                SessionPersonal SessionPersonal,
                string FileName,
                bool ReadIndex = true,
                FileStatus FileStatus = FileStatus.Read) : base(SessionPersonal, FileName, ReadIndex, FileStatus) {
            }

        /// <summary>
        /// Open 
        /// </summary>
        /// <param name="Data"></param>
        public FileContainerReaderRecrypting (
                SessionPersonal SessionPersonal,
                byte[] Data) : base(SessionPersonal, Data) {
            }
        }

    public static partial class Extension {

        /// <summary>
        /// Decrypt a Data At Rest Encrypted (DARE) container.
        /// </summary>
        /// <param name="SessionPersonal">The Mesh Personal Profile to use to 
        /// obtain decryption keys</param>
        /// <param name="InputData">The ciphertext wrapped in a DARE container.</param>
        /// <param name="OutputData">The plaintext.</param>
        /// <param name="ContentType">The content type.</param>
        public static void DecryptDARE (
                    this SessionPersonal SessionPersonal, 
                    byte[] InputData,
                    out byte[] OutputData,
                    out string ContentType) {

            using (var Stream = new MemoryStream(InputData)) {
                using (var Reader = SessionPersonal.DecryptReader(Stream)) {
                    Reader.Read(out OutputData, out var ContentMeta);
                    }
                }

            ContentType = null;
            }

        /// <summary>
        /// Decrypt a Data At Rest Encrypted (DARE) container.
        /// </summary>
        /// <param name="SessionPersonal">The Mesh Personal Profile to use to 
        /// obtain decryption keys</param>
        /// <param name="FileName">File containing the ciphertext wrapped in a DARE container.</param>
        /// <param name="OutputData">The plaintext.</param>
        /// <param name="ContentType">The content type.</param>
        public static void DecryptDARE (
                    this SessionPersonal SessionPersonal, 
                    string FileName,
                    out byte[] OutputData,
                    out string ContentType) {

            using (var Reader = SessionPersonal.DecryptReader(FileName)) {
                Reader.Read(out OutputData, out var ContentMeta);
                }

            ContentType = null;
            }


        /// <summary>
        /// Return a FileContainerReader for the specified file with access to decryption keys 
        /// in the key collection associated with the specified personal session
        /// </summary>
        /// <param name="FileName">The file to open</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader DecryptReader (
                this SessionPersonal SessionPersonal,
                string FileName) {


            return new FileContainerReaderDecrypting (SessionPersonal, FileName, false);
            }

        /// <summary>
        /// Return a FileContainerReader for the specified file with access to decryption keys 
        /// and recryption group accessors in the key collection associated with the specified 
        /// personal session.
        /// </summary>
        /// <param name="FileName">The file to open</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader RecryptReader (
                this SessionPersonal SessionPersonal,
                string FileName) {

            return new FileContainerReaderRecrypting (SessionPersonal, FileName, false);
            }

        /// <summary>
        /// Return a FileContainerReader for the specified stream with access to decryption keys 
        /// in the key collection associated with the specified personal session
        /// </summary>
        /// <param name="FileName">The stream to read. This must support seek operations.</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader DecryptReader (
                this SessionPersonal SessionPersonal,
                Stream FileName) {
            throw new NYI();
            }

        /// <summary>
        /// Return a FileContainerReader for the specified stream with access to decryption keys 
        /// and recryption group accessors in the key collection associated with the specified 
        /// personal session.
        /// </summary>
        /// <param name="FileName">The stream to read. This must support seek operations.</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader RecryptReader (
                this SessionPersonal SessionPersonal,
                Stream FileName) {
            throw new NYI();
            }

        }

    }
