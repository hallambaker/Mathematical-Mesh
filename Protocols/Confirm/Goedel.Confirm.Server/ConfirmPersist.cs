using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Confirm;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Persistence;

namespace Goedel.Confirm.Server {

    /// <summary>Confirmation persistence store.</summary>
    public class ConfirmStore {

        /// <summary>The default store file name</summary>
        public const string DefaultStore = "Confirm.jlog";


        const string KeyUserProfile = "AccountID";
        const string StoreType = "application/goedel-account";
        const string StoreComment = "Persistence store for Confirm data";

        PersistenceStore Confirm;
        PersistenceObjectIndex IndexAccountID;

        //string GetAccountKey (string AccountID) => "Account$" + AccountID;
        //string GetRequestKey (string BrokerID) => "Request$" + BrokerID;
        //string GetResponseKey (string BrokerID) => "Respomse$" + BrokerID;

        DataItem GetAccountData (string AccountID) => 
                IndexAccountID.Get(AccountEntry.GetPrimaryKey(AccountID));
        DataItem GetRequestData (string BrokerID) =>
                IndexAccountID.Get(AccountEntry.GetPrimaryKey(BrokerID));
        DataItem GetResponseData (string BrokerID) =>
                IndexAccountID.Get(AccountEntry.GetPrimaryKey(BrokerID));


        AccountEntry GetAccountEntry (string AccountID) {
            var DataEntry = GetAccountData(AccountID);
            if (DataEntry == null) {
                return null;
                }
            return AccountEntry.FromJSON(DataEntry?.JSONReader);
            }
        

        void NewAccountData (AccountEntry AccountEntry) {
            Confirm.New(AccountEntry);
            }
        void UpdateAccountData (AccountEntry AccountEntry) {
            Confirm.Update(AccountEntry);
            }
        void NewRequestData (RequestEntry RequestEntry) {
            Confirm.New(RequestEntry);
            }
        void UpdateRequestData (RequestEntry RequestEntry) {
            Confirm.Update(RequestEntry);
            }
        void NewResponseData (ResponseEntry ResponseEntry) {
            Confirm.New(ResponseEntry);
            }
        void UpdateResponseData (ResponseEntry ResponseEntry) {
            Confirm.Update(ResponseEntry);
            }

        /// <summary>
        /// The DNS name of this service.
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Confirmation store, wraps the actual persistent transactions.
        /// </summary>
        /// <param name="Domain">The service domain.</param>
        /// <param name="Store">The persistence log file.</param>
        public ConfirmStore (string Domain, string Store = DefaultStore) {
            this.Domain = Domain;
            Confirm = new LogPersistenceStore(Store, StoreType, StoreComment);

            //Accounts are kept in the portal store and indexed by the account
            IndexAccountID = Confirm.ObjectIndex;
            }


        /// <summary>
        /// Post new confirmation request
        /// </summary>
        /// <param name="RequestEntry">Request to post</param>
        /// <returns>Broker generated transaction identifier</returns>
        public string EnquiryPost (
                RequestEntry RequestEntry) {

            // Add the broker ID to the entry.
            RequestEntry.BrokerID = UDF.Random();

            // Get or create account record
            AccountEntry AccountEntry;
            var AccountDataEntry = GetAccountData(RequestEntry.ResponderAccount);
            if (AccountDataEntry == null) {
                AccountEntry = new AccountEntry() {
                    ResponderAccount = RequestEntry.ResponderAccount,
                    RequestIDs = new List<string> { RequestEntry.BrokerID }
                    };
                NewAccountData(AccountEntry);
                }
            else {
                AccountEntry = AccountEntry.FromJSON(AccountDataEntry.JSONReader);
                AccountEntry.RequestIDs.Add(RequestEntry.BrokerID);
                UpdateAccountData(AccountEntry);
                }

            NewRequestData(RequestEntry);

            return RequestEntry.BrokerID;
            }

        /// <summary>
        /// Request status of previous request
        /// </summary>
        /// <param name="BrokerID">Identifier of request to respond to.</param>
        /// <param name="Cancel">If true, the request will be cancelled.</param>
        /// <returns>The response entry.</returns>
        public ResponseEntry EnquiryStatus (
                string BrokerID,
                bool Cancel) {

            var DataEntry = GetResponseData(BrokerID);
            if (DataEntry != null) {
                return ResponseEntry.FromJSON(new JSONReader(DataEntry.Text));
                }

            string RequestStatus;
            var RequestEntryData = GetRequestData(BrokerID);

            if (RequestEntryData == null) {
                throw new BrokerIDNotFound();
                }
            else {
                RequestEntry RequestEntry = RequestEntry.FromJSON(RequestEntryData.JSONReader);
                if (RequestEntry.Expire < DateTime.UtcNow) {
                    RequestStatus = "EXPIRED";
                    }
                else if (Cancel) {
                    return CancelRequest(RequestEntry.ResponderAccount, BrokerID);                   
                    }
                else {
                    RequestStatus = "PENDING";
                    }
                }

            return new ResponseEntry() {
                BrokerID = BrokerID,
                RequestStatus = RequestStatus
                };
            }


        ResponseEntry CancelRequest (string ResponderAccount, string BrokerID) {
            var AccountEntry = GetAccountEntry(ResponderAccount);
            Assert.NotNull(AccountEntry, ResponderNotFound.Throw);

            var ResponseEntry = new ResponseEntry() {
                BrokerID = BrokerID,
                RequestStatus = "ECANCEL"
                };
            NewResponseData(ResponseEntry);

            AccountEntry.RequestIDs.Remove(BrokerID);
            AccountEntry.ArchivedIDs.Add(BrokerID);
            UpdateAccountData(AccountEntry);

            return ResponseEntry;
            }


        /// <summary>
        /// Get list of pending requests
        /// </summary>
        /// <param name="AccountID">The account identifier</param>
        /// <param name="MaxResponse">The maximum number of responses</param>
        /// <param name="AfterId">Return responses after the specified identifier</param>
        /// <returns>The list of request entries</returns>
        public List<RequestEntry> GetPending (
                string AccountID,
                int MaxResponse,
                int AfterId) {


            var AccountDataEntry = GetAccountData(AccountID);
            if (AccountDataEntry == null) {
                return null;
                }

            AccountEntry AccountEntry = AccountEntry.FromJSON(AccountDataEntry.JSONReader);
            var Result = new List<RequestEntry>();

            var Now = DateTime.UtcNow;
            var Expired = new List<string>();
            foreach (var RequestID in AccountEntry.RequestIDs) {
                var DataEntry = GetRequestData(RequestID);
                RequestEntry RequestEntry = RequestEntry.FromJSON(DataEntry.JSONReader);
                if (RequestEntry.Expire > Now) {
                    Result.Add(RequestEntry);
                    }
                else {
                    Expired.Add(RequestID);
                    }
                }

            // We have dropped some expired requests. We don't have to do anything about the 
            // request itself but we do have to move the 
            if (Expired.Count > 0) {
                var Index = 0;
                AccountEntry.ArchivedIDs = AccountEntry.ArchivedIDs ?? new List<string>();
                var NewRequestIDs = new List<string>();
                foreach (var RequestID in AccountEntry.RequestIDs) {
                    if (Index >= Expired.Count) {
                        // Do nothing
                        }
                    else if (RequestID == Expired[Index]) {
                        Index++;
                        AccountEntry.ArchivedIDs.Add(RequestID);
                        }
                    else {
                        NewRequestIDs.Add(RequestID);
                        }
                    }
                AccountEntry.RequestIDs = NewRequestIDs;
                UpdateAccountData(AccountEntry);
                }

            return Result;
            }

        /// <summary>
        /// Post response to a request
        /// </summary>
        /// <param name="ResponseEntry">The response entry to post.</param>
        public void Response (
                ResponseEntry ResponseEntry) {

            var RequestEntryData = GetRequestData(ResponseEntry.BrokerID);
            if (RequestEntryData == null) {
                throw new BrokerIDNotFound();
                }

            RequestEntry RequestEntry = RequestEntry.FromJSON(RequestEntryData.JSONReader);

            var ResponseDataEntry = GetResponseData(ResponseEntry.BrokerID);
            if (ResponseDataEntry != null) {
                throw new AlreadyResponded();
                }

            var AccountDataEntry = GetAccountData(RequestEntry.ResponderAccount);
            if (AccountDataEntry == null) {
                throw new ResponderNotFound();
                }
            AccountEntry AccountEntry = AccountEntry.FromJSON(AccountDataEntry.JSONReader);

            var Check = AccountEntry.RequestIDs.Remove(ResponseEntry.BrokerID);
            NewResponseData(ResponseEntry);
            UpdateAccountData(AccountEntry);
            }

        }
    }
