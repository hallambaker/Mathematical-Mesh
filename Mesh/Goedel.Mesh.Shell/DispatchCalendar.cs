using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>

        public override ShellResult CalendarAdd(CalendarAdd options) {
            var contextAccount = GetContextUser(options);
            var title = options.Title.Value;
            var identifier = options.Identifier.Value ?? UDF.Nonce();

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult CalendarImport(CalendarImport options) {
            var contextAccount = GetContextUser(options);
            "Implement file import functionality".TaskFunctionality(true);

            var identifier = options.Identifier.Value ?? UDF.Nonce();

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult CalendarDelete(CalendarDelete options) {
            var contextAccount = GetContextUser(options);
            var key = options.Identifier.Value;

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult CalendarGet(CalendarGet options) {
            var contextAccount = GetContextUser(options);
            var catalog = contextAccount.GetStore(CatalogTask.Label) as CatalogTask;
            var identifier = options.Identifier.Value;

            var result = catalog.Locate(identifier);

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
        public override ShellResult CalendarDump(CalendarDump options) {
            var contextAccount = GetContextUser(options);
            var catalogedEntries = new List<CatalogedEntry>();

            var catalog = contextAccount.GetStore(CatalogTask.Label) as CatalogTask;
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
