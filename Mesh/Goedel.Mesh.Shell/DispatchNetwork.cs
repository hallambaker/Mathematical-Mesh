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
        public override ShellResult NetworkAdd(NetworkAdd Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var identifier = Options.Identifier.Value;


                var entry = new CatalogedNetwork() {
                    Service = identifier
                    };
                using (var catalog = contextAccount.GetCatalogNetwork()) {
                    catalog.Update(entry);
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
        public override ShellResult NetworkDelete(NetworkDelete Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var identifier = Options.Identifier.Value;

                using (var catalog = contextAccount.GetCatalogNetwork()) {
                    var result = catalog.Locate(identifier);
                    catalog.Delete(result);

                    return new ResultEntry() {
                        Success = true,
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
        public override ShellResult NetworkGet(NetworkGet Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                using (var catalog = contextAccount.GetCatalogNetwork()) {
                    var identifier = Options.Identifier.Value;

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
        public override ShellResult NetworkDump(NetworkDump Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new ResultDump() {
                    Success = true,
                    CatalogedEntries = new List<CatalogedEntry>()
                    };
                using (var catalog = contextAccount.GetCatalogNetwork()) {
                    foreach (var entry in catalog) {
                        result.CatalogedEntries.Add(entry);
                        }
                    }

                return result;
                }
            }


        }
    }
