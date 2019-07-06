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
        public override ShellResult BookmarkAdd(BookmarkAdd Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var uri = Options.Uri.Value;
                var title = Options.Title.Value;
                var path = Options.Path.Value;

                var entry = new CatalogedBookmark() {
                    Uri = uri,
                    Title = title,
                    Path = path
                    };

                using (var catalog = contextAccount.GetCatalogBookmark()) {
                    catalog.New(entry);
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
        public override ShellResult BookmarkDelete(BookmarkDelete Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var uri = Options.Uri.Value;


                using (var catalog = contextAccount.GetCatalogBookmark()) {
                    var result = catalog.Locate(uri);

                    catalog.Delete(result);

                    return new Result() {
                        Success = true
                        };
                    }
                }
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult BookmarkGet(BookmarkGet Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                using (var catalog = contextAccount.GetCatalogBookmark()) {
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
        public override ShellResult BookmarkDump(BookmarkDump Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new ResultDump() {
                    Success = true,
                    CatalogedEntries = new List<CatalogedEntry>()
                    };
                using (var catalog = contextAccount.GetCatalogBookmark()) {
                    foreach (var entry in catalog) {
                        result.CatalogedEntries.Add(entry);
                        }
                    }
                return result;
                }
            }
        }
    }
