using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult NetworkAdd(NetworkAdd Options) {
            var contextAccount = GetContextAccount(Options);
            var identifier = Options.Identifier.Value;
            var password = Options.Password.Value;

            var entry = new CatalogedNetwork() {
                Service = identifier,
                Password = password
                };
            var catalog = contextAccount.GetCatalogNetwork();
            catalog.Update(entry);


            return new ResultEntry() {
                Success = true,
                CatalogEntry = entry
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult NetworkDelete(NetworkDelete Options) {
            var contextAccount = GetContextAccount(Options);
            var identifier = Options.Identifier.Value;
            var key = CatalogedNetwork.PrimaryKey(null, identifier);
            var catalog = contextAccount.GetCatalogNetwork();
            var result = catalog.Locate(key);
            result.AssertNotNull(EntryNotFound.Throw, key);
            catalog.Delete(result);

            return new ResultEntry() {
                Success = true,
                CatalogEntry = result
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult NetworkGet(NetworkGet Options) {
            var contextAccount = GetContextAccount(Options);
            var catalog = contextAccount.GetCatalogNetwork();
            var identifier = Options.Identifier.Value;
            var key = CatalogedNetwork.PrimaryKey(null, identifier);

            var result = catalog.Locate(key);

            return new ResultEntry() {
                Success = result != null,
                CatalogEntry = result
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult NetworkDump(NetworkDump Options) {
            var contextAccount = GetContextAccount(Options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextAccount.GetCatalogNetwork();
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }

            return result;
            }


        }
    }
