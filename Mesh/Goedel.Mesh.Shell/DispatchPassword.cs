#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method to add a credential entry to the credential catalog.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordAdd(PasswordAdd options) {
            var contextUser = GetContextUser(options);
            var site = options.Site.Value;
            var username = options.Username.Value;
            var password = options.Password.Value;

            var entry = new CatalogedCredential() {
                Service = site,
                Username = username,
                Password = password
                };

            var transaction = contextUser.TransactBegin();
            var catalog = transaction.GetCatalogCredential();
            transaction.CatalogUpdate(catalog, entry);
            transaction.Transact();

            return new ResultEntry() {
                Success = true,
                CatalogEntry = entry
                };
            }

        /// <summary>
        /// Dispatch method to fetch a credential entry from the credential catalog.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordGet(PasswordGet options) {
            var contextUser = GetContextUser(options);
            var site = options.Site.Value;

            var result = contextUser.GetCredentialByService(site);

            return new ResultEntry() {
                Success = result != null,
                CatalogEntry = result
                };
            }

        /// <summary>
        /// Dispatch method to delete a credential entry from the catalog.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordDelete(PasswordDelete options) {
            var contextAccount = GetContextUser(options);
            var site = options.Site.Value;

            var transaction = contextAccount.TransactBegin();
            var catalog = transaction.GetCatalogCredential();
            var result = catalog.GetCredentialByService(site);
            result.AssertNotNull(EntryNotFound.Throw, site);
            transaction.CatalogDelete(catalog, result);
            transaction.Transact();

            return new Result() {
                Success = true
                };
            }

        /// <summary>
        /// Dispatch method to dump the credential catalog. 
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PasswordDump(PasswordDump options) {
            var contextAccount = GetContextUser(options);
            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = new List<CatalogedEntry>()
                };
            var catalog = contextAccount.GetStore(CatalogCredential.Label) as CatalogCredential;
            foreach (var entry in catalog) {
                result.CatalogedEntries.Add(entry);
                }
            return result;
            }
        }
    }
