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
            var contextUser = GetContextUser(Options);
            var identifier = Options.Identifier.Value;
            var password = Options.Password.Value;

            var entry = new CatalogedNetwork() {
                Service = identifier,
                Password = password
                };

            var transaction = contextUser.TransactBegin();
            var catalog = transaction.GetCatalogNetwork();
            transaction.CatalogUpdate(catalog, entry);
            transaction.Transact();

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
            var contextUser = GetContextUser(Options);
            var identifier = Options.Identifier.Value;
            var key = CatalogedNetwork.PrimaryKey(null, identifier);
            
            var transaction = contextUser.TransactBegin();
            var catalog = transaction.GetCatalogNetwork();
            var result = catalog.Locate(key);
            result.AssertNotNull(EntryNotFound.Throw, key);
            transaction.CatalogDelete(catalog, result);
            transaction.Transact();

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
            var contextUser = GetContextUser(Options);
            var catalog = contextUser.GetStore(CatalogContact.Label) as CatalogContact;
            var identifier = Options.Identifier.Value;
            var key = CatalogedNetwork.PrimaryKey(null, identifier);

            var result = contextUser.GetNetwork(key);

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
            var contextUser = GetContextUser(Options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextUser.GetStore(CatalogContact.Label) as CatalogContact;
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }

            return result;
            }


        }
    }
