using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.IO {

    /// <summary>
    /// Tools for managing directories
    /// </summary>
    public static partial class Extension {


        /// <summary>
        /// Delete a directory ignoring errors.
        /// </summary>
        /// <param name="Path">The directory to delete.</param>
        public static void DirectoryDelete (this string Path) {
            if (!Directory.Exists(Path)) {
                return;
                }

            try {
                var DirectoryInfo = new DirectoryInfo(Path);
                foreach (var Entry in DirectoryInfo.GetFiles()) {
                    Entry.Delete();
                    }

                Directory.Delete(Path, true);
                }
            catch {
                // Ignore failures, we have done as much as possible
                }

            }


        }


    }
