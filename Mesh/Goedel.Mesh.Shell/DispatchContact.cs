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
            using (var contextAccount = GetContextAccount(Options)) {

                throw new NYI();
                //var identifier = Options.Identifier.Value;

                //var entry = new CatalogEntryContact() {
                //    Key = identifier
                //    };
                //using (var catalog = contextDevice.GetCatalogContact()) {
                //    catalog.Add(entry);
                //    }

                //return new ResultEntry() {
                //    Success = true,
                //    CatalogEntry = entry
                //    };
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactGet(ContactGet Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var identifier = Options.Identifier.Value;

                using (var catalog = contextAccount.GetCatalogContact()) {
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
            using (var contextAccount = GetContextAccount(Options)) {
                var identifier = Options.Identifier.Value;

                using (var catalog = contextAccount.GetCatalogContact()) {
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
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new ResultDump() {
                    Success = true,
                    CatalogedEntries = new List<CatalogedEntry>()
                    };
                using (var catalog = contextAccount.GetCatalogContact()) {
                    foreach (var entry in catalog) {
                        result.CatalogedEntries.Add(entry);
                        }
                    }
                return result;
                }
            }
        }
    }
