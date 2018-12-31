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
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogBookmark;
            var uri = Options.Uri.Value;
            var title = Options.Title.Value;
            var path = Options.Path.Value;

            var entry = new CatalogEntryBookmark() {
                Uri = uri,
                Title = title,
                Path = path
                };
            catalog.Add(entry);

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
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogBookmark;
            var uri = Options.Uri.Value;
            var result = catalog.Locate(uri);

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
        public override ShellResult BookmarkDump(BookmarkDump Options) {
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogBookmark;

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
