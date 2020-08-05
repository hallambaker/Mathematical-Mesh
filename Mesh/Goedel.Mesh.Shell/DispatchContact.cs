using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using System.Collections.Generic;
using System;
using Goedel.IO;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactSelf(ContactSelf Options) {
            var contextAccount = GetContextAccount(Options);
            var file = Options.File.Value;

            "Need to merge in the self contact info and label with a name.".TaskFunctionality(true);

            var catalog = contextAccount.GetCatalogContact();
            var entry = catalog.AddFromFile(file, self: true);

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
        public override ShellResult ContactStatic(ContactStatic Options) {
            var contextAccount = GetContextAccount(Options);


            var uri = contextAccount.ContactUri(false, null);

            var result = new ResultPublish() {
                Success = true,
                Uri = uri
                };
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactDynamic(ContactDynamic Options) {
            var contextAccount = GetContextAccount(Options);
            var expiry = DateTime.Now.AddTicks(Constants.DayInTicks);

            var uri = contextAccount.ContactUri(true, expiry);

            var result = new ResultPublish() {
                Success = true,
                Uri = uri
                };
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactExchange(ContactExchange Options) {
            var contextAccount = GetContextAccount(Options);
            var recipient = Options.Uri.Value;

            var entry = contextAccount.ContactExchange(recipient, true, out var message);

            return new ResultEntrySent() {
                Success = true,
                CatalogEntry = entry,
                Message = message
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContactFetch(ContactFetch Options) {
            var contextAccount = GetContextAccount(Options);
            var recipient = Options.Uri.Value;

            var entry = contextAccount.ContactExchange(recipient, false, out _);

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
        public override ShellResult ContactExport(ContactExport Options) {
            var contextAccount = GetContextAccount(Options);
            var file = Options.File.Value;
            var contactId = Options.Identifier.Value;

            var catalog = contextAccount.GetCatalogContact();

            var entry = catalog.Get(contactId);

            var fileStream = file.OpenFileNew();
            catalog.WriteToStream(fileStream, entry);

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
        public override ShellResult ContactAdd(ContactAdd Options) {
            var contextAccount = GetContextAccount(Options);
            var file = Options.File.Value;

            var catalog = contextAccount.GetCatalogContact();
            var entry = catalog.AddFromFile(file, self: false);

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
        public override ShellResult ContactGet(ContactGet Options) {
            var contextAccount = GetContextAccount(Options);
            var identifier = Options.Identifier.Value;

            var catalog = contextAccount.GetCatalogContact();
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
        public override ShellResult ContactDelete(ContactDelete Options) {
            var contextAccount = GetContextAccount(Options);
            var identifier = Options.Identifier.Value;

            var catalog = contextAccount.GetCatalogContact();
            var result = catalog.Get(identifier);
            result.AssertNotNull(EntryNotFound.Throw, identifier);
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
            var contextAccount = GetContextAccount(Options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextAccount.GetCatalogContact();
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }

            return result;
            }
        }
    }
