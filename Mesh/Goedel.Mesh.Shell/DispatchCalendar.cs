using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;

using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>

        public override ShellResult CalendarAdd(CalendarAdd Options) {
            var contextAccount = GetContextAccount(Options);
            var title = Options.Title.Value;
            var identifier = Options.Identifier.Value ?? UDF.Nonce();



            var entry = new CatalogedTask() {
                Key = identifier,
                Title = title
                };
            var catalog = contextAccount.GetCatalogCalendar();
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
        public override ShellResult CalendarImport(CalendarImport Options) {
            var contextAccount = GetContextAccount(Options);
            "Implement file import functionality".TaskFunctionality(true);

            var identifier = Options.Identifier.Value ?? UDF.Nonce();

            var entry = new CatalogedTask() {
                Key = identifier
                };

            var catalog = contextAccount.GetCatalogCalendar();
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
        public override ShellResult CalendarDelete(CalendarDelete Options) {
            var contextAccount = GetContextAccount(Options);
            var identifier = Options.Identifier.Value;

            var catalog = contextAccount.GetCatalogCalendar();
            var result = catalog.Locate(identifier);
            result.AssertNotNull(EntryNotFound.Throw, identifier);
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
        public override ShellResult CalendarGet(CalendarGet Options) {
            var contextAccount = GetContextAccount(Options);
            var catalog = contextAccount.GetCatalogCalendar();
            var identifier = Options.Identifier.Value;

            var result = catalog.Locate(identifier);

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
        public override ShellResult CalendarDump(CalendarDump Options) {
            using var contextAccount = GetContextAccount(Options);
            var catalogedEntries = new List<CatalogedEntry>();

            using (var catalog = contextAccount.GetCatalogCalendar()) {
                foreach (var entry in catalog) {
                    catalogedEntries.Add(entry);
                    }
                }

            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = catalogedEntries
                };
            return result;
            }
        }
    }
