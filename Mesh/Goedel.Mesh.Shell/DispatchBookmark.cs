using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkAdd(BookmarkAdd Options) {
            var contextUser = GetContextUser(Options);
            var uri = Options.Uri.Value;
            var title = Options.Title.Value;
            var path = Options.Path.Value;

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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkDelete(BookmarkDelete Options) {
            var contextAccount = GetContextUser(Options);
            var uri = Options.Uri.Value;

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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkGet(BookmarkGet Options) {
            var contextAccount = GetContextUser(Options);
            var catalog = contextAccount.GetStore(CatalogBookmark.Label) as CatalogBookmark;
            var identifier = Options.Identifier.Value;

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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkDump(BookmarkDump Options) {
            var contextAccount = GetContextUser(Options);
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
