using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Protocol;
using Goedel.Protocol;


namespace Goedel.Mesh.Protocol.Client {



    /// <summary>
    /// Class that represents an administrator device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public class ContextAdministrator : ContextDevice {

        public virtual ProfileMaster ProfileMaster { get; protected set; }

        public ContextAdministrator(IMeshMachine machine = null, string accountID = null, string profileID = null) :
            base(machine, accountID, profileID) {
            }

        public void Register(string account) => throw new NYI();

        public void ConnectionResponse(string fingerprint, ConnectionState state) => throw new NYI();


        public MeshResult CreateAccount(
            string accountName,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Encrypt);

            var profileMesh = new ProfileMesh() {
                Account = accountName,
                MasterProfile = ProfileMaster.ProfileMasterSigned,
                DeviceProfile = ProfileDevice.ProfileDeviceSigned,
                AccountEncryptionKey = new PublicKey(keyEncrypt.KeyPairPublic())
                };




            var createRequest = new CreateRequest() {
                Profile = profileMesh
                };

            // We create a new meshClientSession because this won't have the 
            var meshClientSession = new MeshClientSession(this);


            MeshService = MeshMachine.GetMeshClient(accountName);

            var result = MeshService.CreateAccount(createRequest, meshClientSession);

            // if successful write out to host file

            AccountName = accountName;
            MeshMachine.Register(profileMesh);


            return new MeshResult() { MeshResponse = result };
            }




        public MeshResult DeleteAccount() {

            var deleteRequest = new DeleteRequest() { Account = AccountName };
            var result = MeshService.DeleteAccount(deleteRequest, MeshClientSession);
            return new MeshResult() { MeshResponse = result };
            }




        public DareMessage SetContactSelf(Contact contact, string label = null) {
            var signedContact = Sign(contact);
            var catalogEntryContact = new CatalogEntryContact(signedContact) {
                Key = AccountName
                };
            Add(catalogEntryContact);
            return signedContact;
            }


        public MeshResult Add(CatalogEntryContact catalogEntryContact) =>
            Add(CatalogCredential, catalogEntryContact);

        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public void Add(ProfileMesh profile) {
            var entry = new CatalogEntryDevice() {
                DeviceProfile = profile.DeviceProfile
                };
            Add(CatalogDevice, entry);
            }

        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage Add(ProfileApplication profile) => throw new NYI();

        public override void ProcessConnectionRequest(
                    MessageConnectionRequest messageConnectionRequest,
                    bool accept) {
            if (accept) {
                Add(messageConnectionRequest.ProfileMesh);
                }
            MarkRead(messageConnectionRequest);
            }
        }
    }
