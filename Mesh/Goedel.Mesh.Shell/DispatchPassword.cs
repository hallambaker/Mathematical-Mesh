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
            var contextDevice = GetContextDevice(Options) ;
            var catalog = contextDevice.CatalogCredential;
            var site = Options.Site.Value;
            var username = Options.Username.Value;
            var password = Options.Password.Value;

            var entry = new CatalogEntryCredential() {
                Service = site,
                Username = username,
                Password = password
                };
            catalog.Add(entry);

            return new ResultEntry() {
                Success = true,
                CatalogEntry = entry
                };
            }

        /// <summary>
        /// Dispatch method to fetch a credential entry from the credential catalog.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordGet(PasswordGet Options) {
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogCredential;
            var site = Options.Site.Value;

            var result = catalog.LocateByService(site);

            return new ResultEntry() {
                Success = true,
                CatalogEntry = result
                };
            }

        /// <summary>
        /// Dispatch method to delete a credential entry from the catalog.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordDelete(PasswordDelete Options) {
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogCredential;
            var site = Options.Site.Value;
            var result = catalog.LocateByService(site);

            catalog.Delete(result);

            return new Result() {
                Success = true
                };
            }

        /// <summary>
        /// Dispatch method to dump the credential catalog. 
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordDump(PasswordDump Options) {
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogCredential;

            var result = new ResultDump() {
                Success = true,
                CatalogEntries = new List<CatalogEntry>()
                };

            foreach (var entry in catalog) {
                result.CatalogEntries.Add(entry);
                }

            return result;
            }
        }
    }
