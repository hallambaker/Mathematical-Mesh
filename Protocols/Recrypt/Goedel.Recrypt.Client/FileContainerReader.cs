using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Recrypt;
using Goedel.IO;
using Goedel.Protocol;


namespace Goedel.Recrypt.Client {




    public static partial class Extension {

        /// <summary>
        /// Decrypt a Data At Rest Encrypted (DARE) container.
        /// </summary>
        /// <param name="SessionPersonal">The Mesh Personal Profile to use to 
        /// obtain decryption keys</param>
        /// <param name="InputData">The ciphertext wrapped in a DARE container.</param>
        /// <param name="OutputData">The plaintext.</param>
        /// <param name="ContentType">The content type.</param>
        public static void RecryptDARE (
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
        public static void RecryptDARE (
                    this SessionPersonal SessionPersonal,
                    string FileName,
                    out byte[] OutputData,
                    out string ContentType) {

            using (var Reader = SessionPersonal.RecryptReader(FileName)) {
                Reader.Read(out OutputData, out var ContentMeta);
                }

            ContentType = null;
            }
        }
    /// <summary>
    /// 
    /// </summary>
    public class FileContainerReaderRecrypting : FileContainerReaderDecrypting {

        SessionPersonal SessionPersonal;
        List<ApplicationProfileEntry> RecryptionProfiles = new List<ApplicationProfileEntry>();
        List<string> RecryptionAccounts = new List<string>();
        List<string> RecryptionKeys = new List<string>();

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
                FileStatus FileStatus = FileStatus.Read) : base(SessionPersonal, FileName, FileStatus) {
            SetPersonalSession(SessionPersonal);
            }

        /// <summary>
        /// Open 
        /// </summary>
        /// <param name="Data"></param>
        public FileContainerReaderRecrypting (
                SessionPersonal SessionPersonal,
                byte[] Data) : base(SessionPersonal, Data) {
            SetPersonalSession(SessionPersonal);
            }


        void SetPersonalSession (SessionPersonal SessionPersonal) {
            this.SessionPersonal = SessionPersonal;

            var PersonalProfile = SessionPersonal.PersonalProfile;
            foreach (var ApplicationProfileEntry in PersonalProfile.Applications) {
                if (ApplicationProfileEntry.Type == "RecryptProfile") {
                    RecryptionProfiles.Add(ApplicationProfileEntry);
                    RecryptionAccounts.Add(ApplicationProfileEntry.Friendly);
                    var ApplicationProfile = SessionPersonal.GetApplicationProfile(ApplicationProfileEntry);

                    AddKeys(ApplicationProfile);

                    }
                }
            }

        void AddKeys (ApplicationProfile ApplicationProfile) {

            var RecryptProfile = ApplicationProfile as RecryptProfile;

            Assert.NotNull(RecryptProfile);


            foreach (var Key in RecryptProfile.EncryptKeys) {
                if (Key.PrivateKey != null) {
                    RecryptionKeys.Add(Key.KeyPair.UDF);
                    }
                }

            }


        /// <summary>
        /// Perform a Key Exchange
        /// </summary>
        /// <param name="Recipients">The list of recipients</param>
        /// <param name="AlgorithmID">The bulk encryption algorithm</param>
        /// <returns>The result of the key exchange.</returns>
        public override byte[] GetExchange (List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) {


            var DirectKey = JoseWebEncryption.MatchDecryptionKey(Recipients, out var RecipientOut);
            if (DirectKey != null) {
                return DirectKey.Decrypt(RecipientOut.EncryptedKey,
                        RecipientOut.Header.Epk.KeyPair, AlgorithmID: AlgorithmID);
                }


            // See if we have a recryption key. Note that we never use the recryption
            // admin key for access even if we have it available.
            foreach (var Recipient in Recipients) {
                var KID = Recipient.Header.Kid;
                KID.SplitAccountID(out var Domain, out var Account);
                if (Account != null) {
                    var RecryptClient = new RecryptClient(Domain);
                    var Response = RecryptClient.RecryptData(SessionPersonal.UDF,
                            RecryptionKeys, Recipient);

                    var EncryptedDecryptionKey = Response.DecryptionKey;
                    var Partial = Response.Partial;

                    var PartialAgreement = KeyAgreement.FromJSON(Partial.JSONReader());

                    //var EKID = EncryptedDecryptionKey.Recipients[0].Header.Kid;
                    //var EncryptionKey = RecryptionProfiles.Find (x => x.
                    // OK need to work out the Decryption key to use.

                    var CompletionKeyData = EncryptedDecryptionKey.Decrypt();

                    ////// recover the completion key
                    var CompletionKey = Key.FromJSON(CompletionKeyData.JSONReader());
                    var CompletionKeyPair = CompletionKey.GetKeyPair();

                    return CompletionKeyPair.Decrypt(Recipient.EncryptedKey,
                                 Recipient.Header.Epk.KeyPair, AlgorithmID: AlgorithmID,
                                 Partial: PartialAgreement.KeyAgreementResult);

                    }
                }

            return null;
            }



        }

    }
