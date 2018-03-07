using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Mesh.Portal;

namespace Goedel.Mesh.Portal.Client {
    public partial class SerializationPersonal {

        /// <summary>
        /// Read a personal profile from a file
        /// </summary>
        /// <param name="FileName">The file to read</param>
        /// <returns>The profile serialization record.</returns>
        public static SerializationPersonal FromFile (string FileName) {
            try {
                using (var FileReader = FileName.OpenFileReadShared()) {
                    using (var TextReader = FileReader.OpenTextReader()) {
                        var Reader = new JSONReader(TextReader);
                        return FromJSON(Reader);
                        }
                    }
                }
            catch {
                return null;
                }
            }
        }

    public partial class SerializationApplication {

        /// <summary>
        /// Read an application profile from a file
        /// </summary>
        /// <param name="FileName">The file to read</param>
        /// <returns>The profile serialization record.</returns>
        public static SerializationApplication FromFile (string FileName) {
            try {
                using (var FileReader = FileName.OpenFileReadShared()) {
                    using (var TextReader = FileReader.OpenTextReader()) {
                        var Reader = new JSONReader(TextReader);
                        return FromJSON(Reader);
                        }
                    }
                }
            catch {
                return null;
                }
            }
        }


    public partial class SerializationDevice {

        /// <summary>
        /// Read a device profile from a file
        /// </summary>
        /// <param name="FileName">The file to read</param>
        /// <returns>The profile serialization record.</returns>
        public static SerializationDevice FromFile (string FileName) {
            try {
                using (var FileReader = FileName.OpenFileReadShared()) {
                    using (var TextReader = FileReader.OpenTextReader()) {
                        var Reader = new JSONReader(TextReader);
                        return FromJSON(Reader);
                        }
                    }
                }
            catch {
                return null;
                }
            }
        }



    }
