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
using System.IO;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Context binding for a Group account
    /// </summary>
    public partial class ContextGroup : ContextAccount {
        #region // Properties

        ///<summary>The enclosing mesh context.</summary>
        public ContextUser ContextUser;

        /////<summary>Returns the MeshClient of the user account under which the account is managed.
        /////</summary>
        //public override MeshService MeshClient => ContextUser.MeshClient;


        ///<summary>The catalogued group description.</summary>
        public CatalogedGroup CatalogedGroup;


        ///<summary>The account profile</summary>
        public override Profile Profile => ProfileGroup;


        ///<summary>The device profile</summary>
        public override ProfileDevice ProfileDevice => ContextUser?.ProfileDevice;


        ///<inheritdoc/>
        public override string AccountAddress => ProfileGroup.AccountAddress;

        ///<summary>The group profile.</summary>
        public ProfileGroup ProfileGroup => CatalogedGroup.ProfileGroup;

        ///<summary>The group connection under which this context is formed.</summary>
        public ConnectionGroup ConnectionGroup;
        ///<summary>Convenience accessor for the connection.</summary>
        public override Connection Connection => ConnectionGroup;

        /////<inheritdoc/>
        //public override IKeyCollection KeyCollection => ContextUser;


        ///<inheritdoc/>
        public MeshKeyCredentialPrivate GetKeyCredentialPrivate() =>
           new MeshKeyCredentialPrivate(KeyAccountAuthentication as KeyPairAdvanced);
        // have to get the credential from the client...
        public override MeshServiceClient MeshClient {
            get => meshClient ??
              GetMeshClient(GetKeyCredentialPrivate()).CacheValue(out meshClient);
            set => meshClient = value;
            }
        MeshServiceClient meshClient;



        //new(
        //    null, ContextUser?.ConnectionDevice, CatalogedGroup?.ConnectionAddress,
        //    ContextUser?.DeviceAuthentication);


        ///<summary>The directory containing the catalogs related to the account.</summary>
        public override string StoresDirectory => storesDirectory ??
            Path.Combine(MeshMachine.DirectoryMesh, ProfileGroup.Udf).CacheValue(out storesDirectory);
        string storesDirectory;

        ///<summary>Dictionarry used to create stores</summary>
        public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => stores;
        Dictionary<string, StoreFactoryDelegate> stores = new() {
                { CatalogMember.Label, CatalogMember.Factory },

            // All contexts have a capability catalog:
                { CatalogAccess.Label, CatalogAccess.Factory },
                { CatalogPublication.Label, CatalogPublication.Factory }
            };

        #endregion
        #region // Factory methods and constructors

        ///// <summary>
        ///// Default constuctor, creates a group context for <paramref name="catalogedGroup"/>
        ///// </summary>
        ///// <param name="contextAccount">The enclosing account context.</param>
        ///// <param name="catalogedGroup">Description of the group to return the
        ///// context for.</param>
        //public ContextGroup(ContextUser contextAccount, CatalogedGroup catalogedGroup) :
        //            this (contextAccount, catalogedGroup, GetActivationAccount())  { 
            

        //    }



            // Here we have to recover the application group entry

            // create a fake activation account with just
            // Signing key
            // encryption key.


            //// Activate the device to communicate as the account (via threshold)
            //ActivationAccount = CatalogedGroup?.GetActivationAccount(ContextUser);

            //// Phase2: This is a hack, we are throwing the encryption key away rather than registering it.
            //var keyCollectionGroup = new KeyCollectionEphemeral();


        /// <summary>
        /// Default constuctor, creates a group context for <paramref name="catalogedGroup"/>
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to return the
        /// context for.</param>
        public ContextGroup(ContextUser contextAccount,
                    CatalogedGroup catalogedGroup,
                    ActivationAccount activationAccount) :
                    base(contextAccount.MeshHost, null) {
            ActivationAccount = activationAccount;
            CatalogedGroup = catalogedGroup;
            ContextUser = contextAccount;
            }


        static ActivationAccount GetActivationAccount() {

            // this needs fixin'
            // Should pull the account entry...


            throw new NYI();
            }

        /// <summary>
        /// Create a new group.
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to create.</param>
        /// <returns>The group context.</returns>
        public static ContextGroup CreateGroup(
                    ContextUser contextAccount, 
                    CatalogedGroup catalogedGroup,
                    ActivationAccount activationAccount,
                    MeshServiceClient client) {
            var result = new ContextGroup(contextAccount, catalogedGroup, activationAccount);
            result.MeshClient = client;
            // Prepopulate the catalogs
            Directory.CreateDirectory(result.StoresDirectory);

            result.LoadStores();
            result.SyncProgressUpload();

            return result;
            }

        #endregion
        #region // Class methods
        /// <summary>
        /// Add a member to the group.
        /// </summary>
        /// <param name="memberAddress">The member to add.</param>
        /// <param name="text">Constrained text to be included in the invitation.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Add(string memberAddress, string text = null) {

            var transactInvitation = ContextUser.TransactBegin();
            var transactGroup = TransactBegin();

            // Pull the contact information from the user's contact catalog
            var networkProtocolEntry = ContextUser.GetNetworkEntry(memberAddress);
            var userEncryptionKey = networkProtocolEntry.MeshKeyEncryption;

            // will fail because the ProfileService is not set.
            var serviceEncryptionKey = ContextUser.ProfileService.ServiceEncryption.GetKeyPair();


            var keyGenerate = ActivationAccount.AccountEncryptionKey as KeyPairAdvanced;
            var (keyData, capabilityService) = CatalogAccess.MakeShare(
                        keyGenerate, AccountAddress, serviceEncryptionKey, memberAddress);

            keyData.Envelope(encryptionKey: userEncryptionKey);
            var capabilityMember = new CapabilityDecryptPartial() {
                Id = ProfileGroup.AccountEncryption.Udf,
                EnvelopedKeyShare = keyData.GetEnvelopedKeyData()
                };

            // Create and send the invitation

            var listCapability = new List<CryptographicCapability> { capabilityMember };

            var contact = CreateContact(listCapability);

            var groupInvitation = new GroupInvitation() {
                Sender = ContextUser.AccountAddress,
                Recipient = memberAddress,
                Text = text,
                Contact = contact
                };

            var catalogedMember = new CatalogedMember() {
                ContactAddress = memberAddress,
                MemberCapabilityId = capabilityMember.Id,
                ServiceCapabilityId = capabilityService.Id,
                };

            transactInvitation.OutboundMessage(networkProtocolEntry, groupInvitation);

            // update the capabilities catalog to add the service capability
            var catalogAccess = transactGroup.GetCatalogAccess();
            var catalogedCapability = new CatalogedAccess(capabilityService);
            transactGroup.CatalogUpdate(catalogAccess, catalogedCapability);

            // update the members catalog to add the member entry
            var catalogMember = transactGroup.GetCatalogMember();
            transactGroup.CatalogUpdate(catalogMember, catalogedMember);

            //// commit the transactions
            //Transact(transactGroup);
            //Transact(transactInvitation);

            transactGroup.Transact();
            transactInvitation.Transact();

            return catalogedMember;


            }

        /// <summary>
        /// Get the default (i.e. minimum contact info). This has a single network 
        /// address entry for this mesh and mesh account. 
        /// </summary>
        /// <returns>The default contact.</returns>
        public override Contact CreateContact(
                    List<CryptographicCapability> capabilities = null) {


            var address = new NetworkAddress(AccountAddress, ProfileGroup) {
                Capabilities = capabilities
                };

            var anchorAccount = new Anchor() {
                Udf = ProfileGroup.Udf,
                Validation = "Self"
                };
            // ContextMesh.ProfileMesh.UDF 

            var contact = new ContactPerson() {
                Anchors = new List<Anchor>() { anchorAccount },
                NetworkAddresses = new List<NetworkAddress>() { address }
                };

            return contact;
            }





        /// <summary>
        /// Locate the a member record in the group.
        /// </summary>
        /// <param name="id">The member to locate.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Locate(string id) {
            var catalogMember = GetStore(CatalogMember.Label) as CatalogMember;
            return catalogMember.Locate(id) as CatalogedMember;

            }

        // ToDo: Delete Add member from group

        /// <summary>
        /// Delete a member from the group
        /// </summary>
        /// <param name="memberAddress">The member to delete.</param>
        /// <returns>The member catalog entry.</returns>
        public void Delete(string memberAddress) {
            var member = Locate(memberAddress);
            member.AssertNotNull(EntryNotFound.Throw, memberAddress);
            Delete(member);
            }


        /// <summary>
        /// Delete a member from the group
        /// </summary>
        /// <param name="member">The member to delete.</param>
        /// <returns>The member catalog entry.</returns>
        public void Delete(CatalogedMember member) {
            var transactGroup = TransactBegin();


            var catalogMember = transactGroup.GetCatalogMember();
            var catalogCapability = transactGroup.GetCatalogAccess();

            var capability = catalogCapability.Get(member.ServiceCapabilityId);
            // delete the capabilities of the member


            transactGroup.CatalogDelete(catalogMember, member);
            transactGroup.CatalogDelete(catalogCapability, capability);

            Transact(transactGroup);
            }


        #endregion
        }





    }
