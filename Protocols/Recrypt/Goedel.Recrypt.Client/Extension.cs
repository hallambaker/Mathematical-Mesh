using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography.Dare;
using Goedel.Recrypt;
using Goedel.IO;

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
        /// Decrypt a Data At Rest Encrypted (DARE) container.
        /// </summary>
        /// <param name="SessionPersonal">The Mesh Personal Profile to use to 
        /// obtain decryption keys</param>
        /// <param name="InputFile">File containing the ciphertext wrapped in a DARE container.</param>
        /// <param name="OutputFile">The file to write the output to. If null, the routine will attempt to 
        /// create a file with the name given in the archive or if unspecified by constructing a filename
        /// from the content type and the input file name.</param>

        public static void DecryptDARE (
                    this SessionPersonal SessionPersonal,
                    string InputFile,
                    string OutputFile) {
            SessionPersonal.DecryptDARE(InputFile, out var ContentData, out var ContentType);
            OutputFile.WriteFileNew(ContentData);

            }

        /// <summary>
        /// Decrypt a Data At Rest Encrypted (DARE) container.
        /// </summary>
        /// <param name="SessionPersonal">The Mesh Personal Profile to use to 
        /// obtain decryption keys</param>
        /// <param name="InputFile">File containing the ciphertext wrapped in a DARE container.</param>
        /// <param name="OutputFile">The file to write the output to. If null, the routine will attempt to 
        /// create a file with the name given in the archive or if unspecified by constructing a filename
        /// from the content type and the input file name.</param>

        public static void RecryptDARE (
                    this SessionPersonal SessionPersonal,
                    string InputFile,
                    string OutputFile) {
            SessionPersonal.RecryptDARE(InputFile, out var ContentData, out var ContentType);
            OutputFile.WriteFileNew(ContentData);

            }


        /// <summary>
        /// Return a FileContainerReader for the specified file with access to decryption keys 
        /// in the key collection associated with the specified personal session
        /// </summary>
        /// <param name="FileName">The file to open</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader DecryptReader(
                this SessionPersonal SessionPersonal,
                string FileName) => new FileContainerReaderDecrypting(SessionPersonal, FileName);

        /// <summary>
        /// Return a FileContainerReader for the specified file with access to decryption keys 
        /// and recryption group accessors in the key collection associated with the specified 
        /// personal session.
        /// </summary>
        /// <param name="FileName">The file to open</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader RecryptReader(
                this SessionPersonal SessionPersonal,
                string FileName) => new FileContainerReaderRecrypting(SessionPersonal, FileName);

        /// <summary>
        /// Return a FileContainerReader for the specified stream with access to decryption keys 
        /// in the key collection associated with the specified personal session
        /// </summary>
        /// <param name="FileName">The stream to read. This must support seek operations.</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader DecryptReader(
                this SessionPersonal SessionPersonal,
                Stream FileName) => throw new NYI();

        /// <summary>
        /// Return a FileContainerReader for the specified stream with access to decryption keys 
        /// and recryption group accessors in the key collection associated with the specified 
        /// personal session.
        /// </summary>
        /// <param name="FileName">The stream to read. This must support seek operations.</param>
        /// <returns>The reader instance</returns>
        public static FileContainerReader RecryptReader(
                this SessionPersonal SessionPersonal,
                Stream FileName) => throw new NYI();


        /// <summary>
        /// Create a new recryption session
        /// </summary>
        /// <param name="SessionPersonal"></param>
        /// <param name="AccountID"></param>
        /// <param name="Devices"></param>
        /// <returns></returns>
        public static SessionRecrypt CreateRecryptProfile (
                this SessionPersonal SessionPersonal,
                string AccountID = null,
                List<SignedDeviceProfile> Devices = null) {


            var RecryptProfile = new RecryptProfile(SessionPersonal.PersonalProfile, AccountID);

            Devices = Devices ?? SessionPersonal.PersonalProfile.Devices;

            // Add all devices as administrator devices
            foreach (var Device in Devices) {
                RecryptProfile.AddDevice(Device.DeviceProfile, true);
                }

            var SessionRecrypt = new SessionRecrypt(SessionPersonal, RecryptProfile);

            SessionRecrypt.Write();
            SessionPersonal.Write();

            return SessionRecrypt;
            }


        public static RecryptionKey GetEncryptionKey (
                this SessionPersonal SessionPersonal,
                string RecryptionGroup) {

            // create a client 
            var Client = new RecryptClient(RecryptionGroup);

            // request the recryption key
            var Response = Client.RecryptKey(RecryptionGroup);

            var RecryptionKey = Response.RecryptionKey;

            RecryptionKey.RecrytionGroup = RecryptionGroup;

            return RecryptionKey;
            }


        public static RecryptionGroup GetRecryptionGroup (
                this SessionPersonal SessionPersonal,
                string RecryptionGroup) {

            // create a client 
            var Client = new RecryptClient(RecryptionGroup);

            // request the recryption key
            var Response = Client.GetGroup(RecryptionGroup);

            return Response.RecryptionGroup;
            }
        }
    }
