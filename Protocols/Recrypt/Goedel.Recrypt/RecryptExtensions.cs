using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography.Container;

namespace Goedel.Recrypt {


    public static partial class Extension {

        public static SessionRecryption SessionRecryption (
                this SessionPersonal SessionPersonal,
                string RecrytionAccount = null) {

            throw new NYI();
            }

        public static RecryptionKey GetEncryptionKey (
                this SessionPersonal SessionPersonal, 
                string RecrytionAccount) {

            throw new NYI();
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
            throw new NYI();
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
            throw new NYI();
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
