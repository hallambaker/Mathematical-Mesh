using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Recrypt;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Account;
using Goedel.Account.Client;

namespace Goedel.Recrypt.Client {

    public static partial class Extension {

        public static SessionRecrypt SessionRecryption (
                this SessionPersonal SessionPersonal,
                string ShortId = null,
                string UDF = null) {

            var Found = SessionPersonal.MeshMachine.Find(

                "RecryptProfile");

            return new SessionRecrypt(Found, SessionPersonal);
            }

        public static SessionRecrypt Create(
                this SessionPersonal SessionPersonal,
                RecryptProfile Profile) => new SessionRecrypt(SessionPersonal, Profile);

        //public static RecryptClient RecryptClient (this SessionPersonal SessionPersonal) {

        //    throw new NYI();
        //    }


        }

    // this is messed up
    // The recryption session should bind to a single recryption profile
    // This profile may have multiple keys


    /// <summary>
    /// Manage a set of application sessions that are recryption sessions bound to
    /// a single personal session. This allows for methods such as 'get set of candidate keys'
    /// </summary>
    public partial class SessionRecrypt : SessionApplication {

        /// <summary>The list of application sessions.</summary>
        public List<SessionApplication> SessionApplications;

        public RecryptProfile RecryptProfile => ApplicationProfile as RecryptProfile;

        RecryptClient _RecryptClient = null;

        RecryptClient RecryptClient {
            get {
                _RecryptClient = _RecryptClient ?? new RecryptClient(RecryptProfile.Account);
                return _RecryptClient;
                }
            }


        AccountClient AccountClient => throw new NYI(); // Currently unused, all accounts are stored at portal.

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
        /// Construct a new SessionRecryption from a profile specification.
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        public SessionRecrypt (
                    SessionPersonal SessionPersonal, 
                    RecryptProfile RecryptProfile,
                    bool Write = true) : base (SessionPersonal, RecryptProfile, Write) {
            }


        /// <summary>
        /// Construct a SessionRecryption from a cached profile
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        public SessionRecrypt (ApplicationProfile ApplicationProfile, SessionPersonal SessionPersonal) : 
                                base (ApplicationProfile, SessionPersonal) {

            // ToDo: sort out this covfefe

            //SessionApplications = SessionPersonal.GetApplicationsByType("RecryptProfile");

            //foreach (var Session in SessionApplications) {
            //    var Profile = Session.ApplicationProfile as RecryptProfile;
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


        KeyPair DecryptionKeyPairFudge; // Hack: only supports one key at the 

        // moment because we have no mapping to the recryption group

        void AddDevicePrivate (RecryptDevicePrivate RecryptDevicePrivate) {
            // OK here have to fix the udf generation first...

            foreach (var Key in RecryptDevicePrivate.DecryptKeys) {
                var KeyPair = Key.KeyPair;
                var UDF = KeyPair.UDF;
                DecryptKeyByID.Add(UDF, KeyPair);

                DecryptionKeyPairFudge = KeyPair;
                }
            foreach (var Key in RecryptDevicePrivate.SignKeys) {
                var KeyPair = Key.KeyPair;
                var UDF = KeyPair.UDF;
                SignKeyByID.Add(UDF, KeyPair);
                }
            }

        /// <summary>
        /// Get the encryption key
        /// </summary>
        /// <param name="Recipients">List of recipients.</param>
        /// <returns>The encryption key pair</returns>
        public KeyPair GetEncryptionKey(List<Recipient> Recipients) => DecryptionKeyPairFudge;
        /// <summary>
        /// Locate an existing recryption group.
        /// </summary>
        /// <param name="GroupIdentifier">The group identifier</param>
        /// <returns></returns>
        public RecryptionGroup GetRecryptionGroup (string GroupIdentifier) {
            // request the recryption key
            var Response = RecryptClient.GetGroup(GroupIdentifier);

            return Response.RecryptionGroup;
            }

        /// <summary>
        /// Create a new recryption group.
        /// </summary>
        /// <param name="GroupIdentifier">The group identifier</param>
        /// <param name="RecryptProfiles">Device profiles </param>
        /// <param name="cryptoAlgorithmID">The key exchange algorithm to use.</param>
        /// <param name="KeySize">The key size</param>
        /// <returns></returns>
        public RecryptionGroup CreateGroup (string GroupIdentifier,
                        List<RecryptProfile> RecryptProfiles = null,
                        CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default,
                        int KeySize=0) {

            var RecryptionGroup = new RecryptionGroup() {
                GroupName = GroupIdentifier
                };
            RecryptionGroup.Generate();

            if (RecryptProfiles != null) {
                foreach (var RecryptProfile in RecryptProfiles) {
                    RecryptionGroup.AddMember(RecryptProfile);
                    }
                }

            RecryptClient.CreateGroup(RecryptionGroup);

            return RecryptionGroup;
            }

        public UpdateGroupResponse AddMember (
                            RecryptionGroup RecryptionGroup, 
                            string AccountID) {

            var Profile = MeshClient.GetProfile(AccountID);

            // Issues - have not updated the profile to the mesh after adding Recrypt
            //    Have not published recryption profile

            var SignedProfile = SessionAccount.GetAccountPofile(AccountID, "RecryptProfile");
            Assert.NotNull(SignedProfile);

            RecryptionGroup.AddMember(SignedProfile.RecryptProfile());
            return RecryptClient.UpdateGroup(RecryptionGroup);
            }

        public UpdateGroupResponse AddMembers (
                            RecryptionGroup RecryptionGroup, 
                            IEnumerable<string> AccountIDs) {

            foreach (var AccountID in AccountIDs) {
                var Profile = MeshClient.GetProfile(AccountID);

                var SignedProfile = SessionAccount.GetAccountPofile(AccountID, "RecryptProfile");
                Assert.NotNull(SignedProfile);

                RecryptionGroup.AddMember(SignedProfile.RecryptProfile());
                }

            return RecryptClient.UpdateGroup(RecryptionGroup);
            }

        public UpdateGroupResponse RemoveMember (RecryptionGroup RecryptionGroup, string UserIdentifier) {

            RecryptionGroup.RemoveMember(UserIdentifier);

            return RecryptClient.UpdateGroup(RecryptionGroup);
            }

        }



    }
