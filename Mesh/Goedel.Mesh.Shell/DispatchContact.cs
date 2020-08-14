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
            var contextUser = GetContextUser(Options);
            var file = Options.File.Value;

            "Need to merge in the self contact info and label with a name.".TaskFunctionality(true);

            var entry = contextUser.AddFromFile(file, self: true);

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
            var contextUser = GetContextUser(Options);

            var uri = contextUser.ContactUri(false, null);

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
            var contextUser = GetContextUser(Options);
            var expiry = DateTime.Now.AddTicks(Constants.DayInTicks);

            var uri = contextUser.ContactUri(true, expiry);

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
            var contextUser = GetContextUser(Options);
            var recipient = Options.Uri.Value;

            var entry = contextUser.ContactExchange(recipient, true, out var message);

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
            var contextUser = GetContextUser(Options);
            var recipient = Options.Uri.Value;

            var entry = contextUser.ContactExchange(recipient, false, out _);

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
            var contextUser = GetContextUser(Options);
            var file = Options.File.Value;
            var contactId = Options.Identifier.Value;

            var entry = contextUser.GetContact(contactId);

            using var fileStream = file.OpenFileNew();
            entry.WriteToStream(fileStream);

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
            var contextUser = GetContextUser(Options);
            var file = Options.File.Value;

            var entry = contextUser.AddFromFile(file, self: false);

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
            var contextUser = GetContextUser(Options);
            var identifier = Options.Identifier.Value;

            var result = contextUser.GetContact(identifier);

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
            var contextUser = GetContextUser(Options);
            var key = Options.Identifier.Value;

            var transaction = contextUser.TransactBegin();
            var catalog = transaction.GetCatalogContact();
            var result = catalog.Get(key);
            result.AssertNotNull(EntryNotFound.Throw, key);
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
        public override ShellResult ContactDump(ContactDump Options) {
            var contextUser = GetContextUser(Options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextUser.GetStore(CatalogContact.Label) as CatalogContact;
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }

            return result;
            }
        }
    }
