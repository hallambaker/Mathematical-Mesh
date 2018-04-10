using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Recrypt;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography.Container;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Account;
using Goedel.Account.Client;

namespace Goedel.Recrypt.Client {

    public static partial class Extension {


        //public static SessionAccount Create (
        //        this SessionPersonal SessionPersonal,
        //        AccountProfile Profile) {
        //    return new SessionAccount(SessionPersonal, Profile);
        //    }

        public static AccountClient AccountClient (this SessionPersonal SessionPersonal) {

            throw new NYI();
            }

        }

    // this is messed up
    // The recryption session should bind to a single recryption profile
    // This profile may have multiple keys


    /// <summary>
    /// Manage a set of application sessions that are recryption sessions bound to
    /// a single personal session. This allows for methods such as 'get set of candidate keys'
    /// </summary>
    public partial class SessionAccount {
        public SessionPersonal SessionPersonal;
        public AccountProfile AccountProfile ;

        AccountClient _AccountClient = null;

        AccountClient AccountClient {
            get {
                _AccountClient = _AccountClient ?? new AccountClient(AccountProfile.AccountID);
                return _AccountClient;
                }
            }


        /// <summary>
        /// Construct a SessionRecryption from a personal session.
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        SessionAccount (SessionPersonal SessionPersonal, AccountProfile AccountProfile) {

            throw new NYI();

            //this.SessionPersonal = SessionPersonal;
            //ApplicationProfile = AccountProfile;

            //SessionPersonal.Add(this);  // The point at which the writes to the local disk, portal are performed.
            }

        /// <summary>
        /// Constrcut a SessionAccount by fetching the specified account from the Account service.
        /// If necessary, authentication credentials from the specified personal session will be used.
        /// </summary>
        /// <param name="SessionPersonal">The personal session (for credentials etc.)</param>
        /// <param name="AccountID">The account identifier.</param>
        public SessionAccount (SessionPersonal SessionPersonal, string AccountID) {

            throw new NYI();

            //this.SessionPersonal = SessionPersonal;
            //ApplicationProfile = AccountProfile;

            //SessionPersonal.Add(this);  // The point at which the writes to the local disk, portal are performed.
            }


        SessionAccount (SessionPersonal SessionPersonal, AccountClient AccountClient) {
            this.SessionPersonal = SessionPersonal;
            _AccountClient = AccountClient;
            }


        /// <summary>
        /// Create the session account.
        /// </summary>
        /// <param name="SessionPersonal"></param>
        /// <param name="AccountID"></param>
        /// <param name="UDF"></param>
        /// <param name="PortalID"></param>
        /// <param name="PIN"></param>
        /// <returns></returns>
        public static SessionAccount Create (
                    SessionPersonal SessionPersonal,
                    AccountData AccountData) {

            var AccountClient = new AccountClient(AccountData.AccountID);
            var Response = AccountClient.Create(AccountData);

            return new SessionAccount(SessionPersonal, AccountClient);
            }

        public static SessionAccount Create (
                    SessionPersonal SessionPersonal,
                    string AccountID,
                    List<string> Portals,
                    List<SignedApplicationProfile> Profiles) {

            var AccountData = new AccountData() {
                AccountID = AccountID,
                Created = DateTime.Now,
                Status = "Active",
                MeshUDF = SessionPersonal.UDF,
                Portal = Portals,
                Profiles = Profiles
                };

            return Create(SessionPersonal, AccountData);

            }



        /// <summary>
        /// Resolve an account identifier by making an account data request to the
        /// corresponding Account server.
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public static AccountData GetAccountPofile (string AccountID) {

            AccountID.SplitAccountID(out var Service, out var Account);

            var AccountClient = new AccountClient(Service);

            var Response = AccountClient.Get(AccountID);
            return Response.Data;
            }


        /// Resolve an account identifier by making an account data request to the
        /// corresponding Account server.
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public static SignedApplicationProfile GetAccountPofile (string AccountID, string ProfileType) {
            var AccountData = GetAccountPofile(AccountID);

            // extract the specific recrypt profile here.
            foreach (var Profile in AccountData.Profiles) {
                if (Profile.Profile._Tag == ProfileType) {
                    return Profile;
                    }
                }

            return null;
            }


        // blah blah
        // update, delete, etc.
        }



    }
