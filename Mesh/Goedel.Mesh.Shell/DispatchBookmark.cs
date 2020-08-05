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
            var contextAccount = GetContextAccount(Options);
            var uri = Options.Uri.Value;
            var title = Options.Title.Value;
            var path = Options.Path.Value;

            var entry = new CatalogedBookmark() {
                Uri = uri,
                Title = title,
                Path = path
                };

            var catalog = contextAccount.GetCatalogBookmark();
            catalog.New(entry);


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
            var contextAccount = GetContextAccount(Options);
            var uri = Options.Uri.Value;


            var catalog = contextAccount.GetCatalogBookmark();
            var result = catalog.Locate(uri);
            result.AssertNotNull(EntryNotFound.Throw, uri);
            catalog.Delete(result);

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
            var contextAccount = GetContextAccount(Options);
            var catalog = contextAccount.GetCatalogBookmark();
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
            var contextAccount = GetContextAccount(Options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextAccount.GetCatalogBookmark();
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }

            return result;
            }
        }
    }
