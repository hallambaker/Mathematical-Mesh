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


        public static SessionAccount Create (
                this SessionPersonal SessionPersonal,
                AccountProfile Profile) {
            return new SessionAccount(SessionPersonal, Profile);
            }

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

        /// <summary>The list of application sessions.</summary>
        public List<SessionApplication> SessionApplications;

        public AccountProfile AccountProfile ;

        AccountClient _AccountClient = null;

        AccountClient AccountClient {
            get {
                _AccountClient = _AccountClient ?? new AccountClient(AccountProfile.AccountID);
                return _AccountClient;
                }
            }

        //Dictionary<string, RecryptDevicePrivate> DevicePrivate;
        Dictionary<string, KeyPair> DecryptKeyByID =
                    new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> SignKeyByID =
            new Dictionary<string, KeyPair>();

        ///////************************
        // Has come back to byte us
        // Need to use the device profile to work out what recypt keys we have available to us
        // then recover the decryption key and ID
        // then find a recryption profile we can use.
        // Save the encryption key to decrypt the returned data.
        List<SessionApplication> Result = new List<SessionApplication>();


        /// <summary>
        /// Construct a SessionRecryption from a personal session.
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        public SessionAccount (SessionPersonal SessionPersonal, AccountProfile AccountProfile) {

            throw new NYI();

            //this.SessionPersonal = SessionPersonal;
            //ApplicationProfile = AccountProfile;

            //SessionPersonal.Add(this);  // The point at which the writes to the local disk, portal are performed.
            }


        /// <summary>
        /// Construct a SessionRecryption from a personal session.
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        public SessionAccount (SessionPersonal SessionPersonal) {

            throw new NYI();

            //this.SessionPersonal = SessionPersonal;
            //SessionApplications = SessionPersonal.GetApplicationsByType("RecryptProfile");

            //foreach (var Session in SessionApplications) {
            //    var Profile = Session.ApplicationProfile as AccountProfile;


            //    foreach (var EncryptedDevicePrivate in Profile.DevicePrivate) {
            //        var KeyID = Session.FindByDecryption(EncryptedDevicePrivate.Recipients);

            //        var Plaintext = EncryptedDevicePrivate.Decrypt(
            //            KeyID.DeviceProfile.DeviceEncryptiontionKey.KeyPair);

            //        var DevicePrivate = RecryptDevicePrivate.FromJSON(Plaintext.JSONReader());
            //        Session.ApplicationDevicePrivate = DevicePrivate;

            //        AddDevicePrivate(DevicePrivate);
            //        }
            //    }
            }

        public  MeshMachine MeshMachine { set => throw new NotImplementedException(); }


        }



    }
