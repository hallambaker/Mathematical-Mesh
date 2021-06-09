using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkAdd(BookmarkAdd options) {
            var contextUser = GetContextUser(options);
            var uri = options.Uri.Value;
            var title = options.Title.Value;
            var path = options.Path.Value;

            var entry = new CatalogedBookmark() {
                Uri = uri,
                Title = title,
                Path = path
                };

            var transaction = contextUser.TransactBegin();
            var catalog = transaction.GetCatalogBookmark();
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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkDelete(BookmarkDelete options) {
            var contextAccount = GetContextUser(options);
            var uri = options.Uri.Value;

            var transaction = contextAccount.TransactBegin();
            var catalog = transaction.GetCatalogBookmark();
            var result = catalog.Locate(uri);
            result.AssertNotNull(EntryNotFound.Throw, uri);
            transaction.CatalogDelete(catalog, result);
            transaction.Transact();

            return new Result() {
                Success = true
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkGet(BookmarkGet options) {
            var contextAccount = GetContextUser(options);
            var catalog = contextAccount.GetStore(CatalogBookmark.Label) as CatalogBookmark;
            var identifier = options.Identifier.Value;

            var result = catalog.Locate(identifier);

            //result.AssertNotNull(EntryNotFound.Throw);

            return new ResultEntry() {
                Success = result != null,
                CatalogEntry = result
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkDump(BookmarkDump options) {
            var contextAccount = GetContextUser(options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextAccount.GetStore(CatalogBookmark.Label) as CatalogBookmark;
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }

            return result;
            }
        }
    }
