using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.IO;

namespace Goedel.Mesh.Portal.Client {

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
                FileStatus FileStatus = FileStatus.Read) : base(FileName, FileStatus) {
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
        public virtual KeyPair TryMatchRecipient (Recipient Recipient) {
            var KID = Recipient.Header.Kid;

            KID.SplitAccountID(out var Domain, out var Account);
            if (Domain != null) {
                return KeyPair.FindLocal(Account);
                }
            else {
                return KeyPair.FindLocal(KID);
                }
            }

        }




    }
