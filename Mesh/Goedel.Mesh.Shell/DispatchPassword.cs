using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method to add a credential entry to the credential catalog.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordAdd(PasswordAdd Options) {
            var contextUser = GetContextUser(Options);
            var site = Options.Site.Value;
            var username = Options.Username.Value;
            var password = Options.Password.Value;

            var entry = new CatalogedCredential() {
                Service = site,
                Username = username,
                Password = password
                };

            var transaction = contextUser.TransactBegin();
            var catalog = transaction.GetCatalogCredential();
            transaction.CatalogUpdate(catalog, entry);
            transaction.Transact();

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
            var contextUser = GetContextUser(Options);
            var site = Options.Site.Value;

            var result = contextUser.GetCredentialByService(site);

            return new ResultEntry() {
                Success = result != null,
                CatalogEntry = result
                };
            }

        /// <summary>
        /// Dispatch method to delete a credential entry from the catalog.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordDelete(PasswordDelete Options) {
            var contextAccount = GetContextUser(Options);
            var site = Options.Site.Value;

            var transaction = contextAccount.TransactBegin();
            var catalog = transaction.GetCatalogCredential();
            var result = catalog.GetCredentialByService(site);
            result.AssertNotNull(EntryNotFound.Throw, site);
            transaction.CatalogDelete(catalog, result);
            transaction.Transact();

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
            var contextAccount = GetContextUser(Options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextAccount.GetStore(CatalogCredential.Label) as CatalogCredential;
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }
            return result;
            }
        }
    }
