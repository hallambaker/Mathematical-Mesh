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
        public override ShellResult NetworkAdd(NetworkAdd Options) {
            var contextDevice = GetContextDevice(Options);
            var identifier = Options.Identifier.Value;


            var entry = new CatalogEntryTask() {
                Key = identifier
                };
            using (var catalog = contextDevice.GetCatalogNetwork()) {
                catalog.Update(entry);
                }

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
            var contextDevice = GetContextDevice(Options);
            var identifier = Options.Identifier.Value;

            using (var catalog = contextDevice.GetCatalogNetwork()) {
                var result = catalog.Locate(identifier);
                catalog.Delete(result);

                return new ResultEntry() {
                    Success = true,
                    CatalogEntry = result
                    };
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult NetworkGet(NetworkGet Options) {
            var contextDevice = GetContextDevice(Options);
            using (var catalog = contextDevice.GetCatalogNetwork()) {
                var identifier = Options.Identifier.Value;

                var result = catalog.Locate(identifier);

                return new ResultEntry() {
                    Success = result != null,
                    CatalogEntry = result
                    };
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult NetworkDump(NetworkDump Options) {
            var contextDevice = GetContextDevice(Options);

            var result = new ResultDump() {
                Success = true,
                CatalogEntries = new List<CatalogEntry>()
                };
            using (var catalog = contextDevice.GetCatalogNetwork()) {
                foreach (var entry in catalog) {
                    result.CatalogEntries.Add(entry);
                    }
                }

            return result;
            }


        }
    }
