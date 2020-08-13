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
            var contextAccount = GetContextUser(Options);
            var title = Options.Title.Value;
            var identifier = Options.Identifier.Value ?? UDF.Nonce();

            var entry = new CatalogedTask() {
                Key = identifier,
                Title = title
                };

            var transaction = contextAccount.TransactBegin();
            var catalog = transaction.GetCatalogCalendar();
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
        public override ShellResult CalendarImport(CalendarImport Options) {
            var contextAccount = GetContextUser(Options);
            "Implement file import functionality".TaskFunctionality(true);

            var identifier = Options.Identifier.Value ?? UDF.Nonce();

            var entry = new CatalogedTask() {
                Key = identifier
                };

            var transaction = contextAccount.TransactBegin();
            var catalog = transaction.GetCatalogCalendar();
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
        public override ShellResult CalendarDelete(CalendarDelete Options) {
            var contextAccount = GetContextUser(Options);
            var key = Options.Identifier.Value;

            var transaction = contextAccount.TransactBegin();
            var catalog = transaction.GetCatalogCalendar();
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
        public override ShellResult CalendarGet(CalendarGet Options) {
            var contextAccount = GetContextUser(Options);
            var catalog = contextAccount.GetStore(CatalogCalendar.Label) as CatalogCalendar;
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
            using var contextAccount = GetContextUser(Options);
            var catalogedEntries = new List<CatalogedEntry>();

            var catalog = contextAccount.GetStore(CatalogCalendar.Label) as CatalogCalendar;
            foreach (var entry in catalog) {
                catalogedEntries.Add(entry);
                }

            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = catalogedEntries
                };
            return result;
            }
        }
    }
