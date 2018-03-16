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

        public static SessionRecryption SessionRecryption (
                this SessionPersonal SessionPersonal,
                string UDF = null,
                string ShortId = null) {

            var Found = SessionPersonal.MeshMachine.Find(
                out var Result,
                "SessionRecryption",
                UDF:UDF,
                ShortId: ShortId);

            return Result as SessionRecryption;
            }

        public static SessionRecryption Create (
                this SessionPersonal SessionPersonal,
                RecryptProfile Profile) {
            return new SessionRecryption(SessionPersonal, Profile);
            }

        public static RecryptClient RecryptClient (this SessionPersonal SessionPersonal) {

            throw new NYI();
            }

        /// <summary>
        /// Search all associated recryption profiles to find if there is a matching group attached.
        /// </summary>
        /// <param name="SessionPersonal"></param>
        /// <param name="GroupID"></param>
        /// <returns></returns>
        public static RecryptionGroup RecryptionGroup (
                this SessionPersonal SessionPersonal,
                string GroupID) {
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
    public partial class SessionRecryption : SessionApplication {

        /// <summary>The list of application sessions.</summary>
        public List<SessionApplication> SessionApplications;

        RecryptClient RecryptClient => throw new NYI();
        AccountClient AccountClient => throw new NYI();

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
        public SessionRecryption (SessionPersonal SessionPersonal, RecryptProfile Profile) {

            this.SessionPersonal = SessionPersonal;
            var RecryptSession = SessionPersonal.Add(Profile);
            Write();
            SessionPersonal.Write();
            }


        /// <summary>
        /// Construct a SessionRecryption from a personal session.
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        public SessionRecryption (SessionPersonal SessionPersonal) {
            this.SessionPersonal = SessionPersonal;
            SessionApplications = SessionPersonal.GetApplicationsByType("RecryptProfile");

            foreach (var Session in SessionApplications) {
                var Profile = Session.ApplicationProfile as RecryptProfile;


                foreach (var EncryptedDevicePrivate in Profile.DevicePrivate) {
                    var KeyID = Session.FindByDecryption(EncryptedDevicePrivate.Recipients);

                    var Plaintext = EncryptedDevicePrivate.Decrypt(
                        KeyID.DeviceProfile.DeviceEncryptiontionKey.KeyPair);

                    var DevicePrivate = RecryptDevicePrivate.FromJSON(Plaintext.JSONReader());
                    Session.ApplicationDevicePrivate = DevicePrivate;

                    AddDevicePrivate(DevicePrivate);
                    }
                }
            }


        KeyPair DecryptionKeyPairFudge; // Hack: only supports one key at the 

        public override MeshMachine MeshMachine { set => throw new NotImplementedException(); }

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
        public KeyPair GetEncryptionKey (List<Recipient> Recipients) {

            return DecryptionKeyPairFudge;
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


            //var AccountID = Options.AccountID.Value;
            //var RecryptClient = new RecryptClient(AccountID);

            //Assert.NotNull(Options.GroupID.Value, NoGroupSpecified.Throw);

            var RecryptionGroup = new RecryptionGroup() {
                GroupName = GroupIdentifier
                };
            RecryptionGroup.Generate();

            foreach (var RecryptProfile in RecryptProfiles) {
                RecryptionGroup.AddMember(RecryptProfile);
                }

            RecryptClient.CreateGroup(RecryptionGroup);

            return RecryptionGroup;
            }

        public UpdateGroupResponse AddMember (
                            RecryptionGroup RecryptionGroup, 
                            string AccountID) {

            var MemberProfile = AccountClient.GetAccountPofile(AccountID);
            Assert.NotNull(MemberProfile);

            throw new NYI();
            //var RecryptProfile = MemberProfile.GetRecryptionProfile(AccountID);
            //Assert.NotNull(RecryptProfile);

            //RecryptionGroup.AddMember(RecryptProfile);

            //return RecryptClient.UpdateGroup(RecryptionGroup);
            }

        public UpdateGroupResponse AddMembers (
                            RecryptionGroup RecryptionGroup, 
                            IEnumerable<string> AccountIDs) {

            throw new NYI();

            //foreach (var AccountID in AccountIDs) {
            //    var MemberProfile = AccountClient.GetAccountPofile(AccountID);
            //    Assert.NotNull(MemberProfile);


            //    var RecryptProfile = MemberProfile.GetRecryptionProfile(AccountID);
            //    Assert.NotNull(RecryptProfile);

            //    RecryptionGroup.AddMember(RecryptProfile);
            //    }

            //return RecryptClient.UpdateGroup(RecryptionGroup);


            //throw new NYI();
            }

        public AddMemberResponse RemoveMember (RecryptionGroup RecryptionGroup, string UserIdentifier) {

            //RecryptionGroup.RemoveMember(UserIdentifier);

            //return RecryptClient.UpdateGroup(RecryptionGroup);

            throw new NYI();
            }

        }



    }
