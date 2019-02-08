using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactAdd(ContactAdd Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                var identifier = Options.Identifier.Value;

                var entry = new CatalogEntryContact() {
                    Key = identifier
                    };
                using (var catalog = contextDevice.GetCatalogContact()) {
                    catalog.Add(entry);
                    }

                return new ResultEntry() {
                    Success = true,
                    CatalogEntry = entry
                    };
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactdGet(ContactdGet Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                var identifier = Options.Identifier.Value;

                using (var catalog = contextDevice.GetCatalogContact()) {
                    var result = catalog.Locate(identifier);

                    return new ResultEntry() {
                        Success = result != null,
                        CatalogEntry = result
                        };
                    }
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactDelete(ContactDelete Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                var identifier = Options.Identifier.Value;

                using (var catalog = contextDevice.GetCatalogContact()) {
                    var result = catalog.Locate(identifier);

                    catalog.Delete(result);
                    }

                return new Result() {
                    Success = true
                    };
                }
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactDump(ContactDump Options) {
            using (var contextDevice = GetContextDevice(Options)) {

                var result = new ResultDump() {
                    Success = true,
                    CatalogEntries = new List<CatalogEntry>()
                    };
                using (var catalog = contextDevice.GetCatalogContact()) {
                    foreach (var entry in catalog) {
                        result.CatalogEntries.Add(entry);
                        }
                    }
                return result;
                }
            }
        }
    }
