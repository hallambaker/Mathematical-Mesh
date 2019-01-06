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
        public override ShellResult ContactAdd(ContactAdd Options) {
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogContact;
            var file = Options.File.Value;


            var entry = new CatalogEntryContact() {

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
        public override ShellResult ContactdGet(ContactdGet Options) {
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogContact;
            var identifier = Options.Identifier.Value;

            var result = catalog.Locate(identifier);
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
        public override ShellResult ContactDelete(ContactDelete Options) {
            var contextDevice = GetContextDevice(Options);
            var catalog = contextDevice.CatalogContact;
            var identifier = Options.Identifier.Value;
            var result = catalog.Locate(identifier);

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
        public override ShellResult ContactDump(ContactDump Options) {
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
