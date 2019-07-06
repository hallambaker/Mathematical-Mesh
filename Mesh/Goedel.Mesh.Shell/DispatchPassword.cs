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
        /// Dispatch method to add a credential entry to the credential catalog.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordAdd(PasswordAdd Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var site = Options.Site.Value;
                var username = Options.Username.Value;
                var password = Options.Password.Value;

                var entry = new CatalogedCredential() {
                    Service = site,
                    Username = username,
                    Password = password
                    };

                using (var catalog = contextAccount.GetCatalogCredential()) {
                    catalog.Update(entry);
                    }

                return new ResultEntry() {
                    Success = true,
                    CatalogEntry = entry
                    };
                }
            }

        /// <summary>
        /// Dispatch method to fetch a credential entry from the credential catalog.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordGet(PasswordGet Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var site = Options.Site.Value;

                using (var catalog = contextAccount.GetCatalogCredential()) {
                    var result = catalog.LocateByService(site);


                    return new ResultEntry() {
                        Success = result != null,
                        CatalogEntry = result
                        };
                    }
                }
            }

        /// <summary>
        /// Dispatch method to delete a credential entry from the catalog.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordDelete(PasswordDelete Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var site = Options.Site.Value;


                using (var catalog = contextAccount.GetCatalogCredential()) {
                    var result = catalog.LocateByService(site);
                    catalog.Delete(result);
                    }

                return new Result() {
                    Success = true
                    };
                }
            }

        /// <summary>
        /// Dispatch method to dump the credential catalog. 
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordDump(PasswordDump Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new ResultDump() {
                    Success = true,
                    CatalogedEntries = new List<CatalogedEntry>()
                    };
                using (var catalog = contextAccount.GetCatalogCredential()) {
                    foreach (var entry in catalog) {
                        result.CatalogedEntries.Add(entry);
                        }
                    }
                return result;
                }
            }
        }
    }
