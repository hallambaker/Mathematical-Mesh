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


        public ContextAdministrator(IMeshMachine machine = null, string accountID = null, string profileID = null)   :
            base (machine,accountID, profileID){
            }

        public void Register(string account) => throw new NYI();

        public void ConnectionResponse (string fingerprint, ConnectionState state) => throw new NYI();


        public MeshResult CreateAccount(
            string accountName,
            List<string> language = null) {


            var profileMesh = new ProfileMesh() {
                Account = accountName,
                Language = language
                };




            var createRequest = new CreateRequest() {
                Profile = profileMesh
                };
            MeshService = Machine.GetMeshClient(accountName);

            var result = MeshService.CreateAccount(createRequest);

                // if successful write out to host file

            AccountName = accountName;



            return new MeshResult() { MeshResponse = result };
            }




        public MeshResult DeleteAccount() {

            var deleteRequest = new DeleteRequest() { Account = AccountName };
            var result = MeshService.DeleteAccount(deleteRequest);
            return new MeshResult() { MeshResponse = result };
            }




        public DareMessage SetContactSelf(Contact contact, string label=null) {
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
        public DareMessage Add(ProfileDevice profile) => throw new NYI();

        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage Add(ProfileApplication profile) => throw new NYI();

        }
    }
