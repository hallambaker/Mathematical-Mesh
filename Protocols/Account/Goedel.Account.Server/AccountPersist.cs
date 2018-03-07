using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Account;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Persistence;

namespace Goedel.Account.Server {





    /// <summary>Base store for accounts (non persistent)</summary>
    public class AccountStore {

        /// <summary>The default store file name</summary>
        const string DefaultStore = "Account.jlog";

        const string KeyUserProfile = "AccountID";
        const string StoreType = "application/goedel-account";
        const string StoreComment = "Persistence store for Account data";

        PersistenceStore Account;
        PersistenceObjectIndex IndexAccountID;

        /// <summary>
        /// The DNS name of this service.
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Construct a persistence store for the specified domain, with the
        /// specified store and portal stores.
        /// </summary>
        /// <param name="Domain">Domain name of the service</param>
        /// <param name="Store">store name for the account persistence store.</param>
        public AccountStore (string Domain, string Store=DefaultStore) {
            this.Domain = Domain;
            Account = new LogPersistenceStore(Store, StoreType, StoreComment);

            //Accounts are kept in the portal store and indexed by the account
            IndexAccountID = Account.ObjectIndex;
            }


        /// <summary>Test to see if an account name is available. Note that 
        /// a subsequence CreateAccount request can fail even if a previous call 
        /// to CheckAccount succeeded as the account name may have been issued in the 
        /// interim or may fail for other reasons.
        /// </summary>
        /// <param name="AccountId">The requested account name</param>
        /// <returns>True is the name is available, otherwise false.</returns>
        public bool CheckAccount (string AccountId) {
            return !IndexAccountID.Contains(AccountId);
            }

        /// <summary>
        /// Create a new account record.
        /// </summary>
        /// <param name="AccountData">Account data to record.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool CreateAccount (AccountData AccountData) {

            AccountData.Created = DateTime.Now;
            Account.New(AccountData);

            return true;
            }

        /// <summary>
        /// Delete an account record.
        /// </summary>
        /// <param name="AccountId">Identifier of account to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool DeleteAccount (string AccountId) {
            return Account.Delete(AccountId);
            }

        /// <summary>
        /// Get an account record.
        /// </summary>
        /// <param name="AccountId">Identifier of account to delete.</param>
        /// <returns>The account record or null if not found.</returns>
        public AccountData GetAccount (string AccountId) {
            var AccountDataItem = IndexAccountID.Get(AccountId);
            if (AccountDataItem == null) {
                return null;
                }

            return AccountData.FromJSON(AccountDataItem.Text.JSONReader());

            }

        /// <summary>
        /// Update an account record.
        /// </summary>
        /// <param name="AccountData">Account data to write.</param>
        public void UpdateAccount (AccountData AccountData) {
            Account.Update(AccountData);
            }

        }
    }
