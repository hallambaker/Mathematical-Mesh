using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;

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

        ///<summary>The account address.</summary>
        public override string AccountAddress => ProfileGroup.AccountAddress;

        ///<summary>The group profile.</summary>
        public ProfileGroup ProfileGroup => CatalogedGroup.ProfileGroup;

        ///<summary>The group connection under which this context is formed.</summary>
        public ConnectionGroup ConnectionGroup;
        ///<summary>Convenience accessor for the connection.</summary>
        public override Connection Connection => ConnectionGroup;



        ///<summary>The directory containing the catalogs related to the account.</summary>
        public override string StoresDirectory => storesDirectory ??
            Path.Combine(MeshMachine.DirectoryMesh, ProfileGroup.Udf).CacheValue(out storesDirectory);
        string storesDirectory;

        ///<summary>Dictionarry used to create stores</summary>
        public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => stores;
        Dictionary<string, StoreFactoryDelegate> stores = new() {
            {CatalogMember.Label, CatalogMember.Factory},

            // All contexts have a capability catalog:
            {CatalogAccess.Label, CatalogAccess.Factory},
            {CatalogPublication.Label, CatalogPublication.Factory}
            };

        #endregion
        #region // Factory methods and constructors

        /// <summary>
        /// Default constuctor, creates a group context for <paramref name="catalogedGroup"/>
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to return the
        /// context for.</param>
        public ContextGroup(ContextUser contextAccount, CatalogedGroup catalogedGroup) :
                    base(contextAccount.MeshHost, null) { 
            CatalogedGroup = catalogedGroup;
            ContextUser = contextAccount;

            // Activate the device to communicate as the account (via threshold)
            ActivationAccount = CatalogedGroup?.GetActivationAccount(KeyCollection);
            ActivationAccount.Activate(KeyCollection);

            }


        /// <summary>
        /// Generation constructor: create a group using the seed value <paramref name="activationAccount"/>
        /// and return a client context under <paramref name="contextuser"/>
        /// </summary>
        /// <param name="contextuser"></param>
        /// <param name="activationAccount"></param>
        public ContextGroup(ContextUser contextuser, ActivationAccount activationAccount) :
                    base(activationAccount) => ContextUser = contextuser;


        /// <summary>
        /// Create a new group.
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to create.</param>
        /// <returns>The group context.</returns>
        public static ContextGroup CreateGroup(ContextUser contextAccount, CatalogedGroup catalogedGroup) {
            var result = new ContextGroup(contextAccount, catalogedGroup);

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
        public CatalogedMember Add(string memberAddress, string text=null) {

            var transactInvitation = ContextUser.TransactBegin();
            var transactGroup = TransactBegin();

            // Bug: Should create an entry for the member

            // Pull the contact information from the user's contact catalog
            var networkProtocolEntry = ContextUser.GetNetworkEntry(memberAddress);
            var userEncryptionKey = networkProtocolEntry.MeshKeyEncryption;

            // will fail because the ProfileService is not set.
            var serviceEncryptionKey = ContextUser.ProfileService.ServiceEncryption.CryptoKey;

            // Create the capability 
            var capabilityService = new CapabilityDecryptServiced() {
                AuthenticationId = ContextUser.ProfileUser.Udf,
                KeyDataEncryptionKey = serviceEncryptionKey
                };

            var capabilityMember = new CapabilityDecryptPartial() {
                Id = ProfileGroup.AccountEncryption.Udf,
                SubjectId = ProfileGroup.AccountEncryption.Udf,
                ServiceAddress = AccountAddress,
                KeyDataEncryptionKey = userEncryptionKey
                };

            var keyGenerate = transactInvitation.GetCatalogAccess().TryFindKeyGenerate(
                            ProfileGroup.AccountEncryption.Udf);
            keyGenerate.CreateShares(capabilityService, capabilityMember);

            // Fix up the identifiers.
            capabilityMember.ServiceId = capabilityMember.KeyData.Udf;
            capabilityService.Id = capabilityMember.ServiceId;
            capabilityService.SubjectId = capabilityMember.ServiceId;

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

            // commit the transactions
            Transact(transactGroup);
            Transact(transactInvitation);

            // ToDo: Handle error return properly if the group transaction fails (need retry race);

            catalogAccess.Dump();
            catalogMember.Dump();

            return catalogedMember;
            }

        /// <summary>
        /// Get the default (i.e. minimum contact info). This has a single network 
        /// address entry for this mesh and mesh account. 
        /// </summary>
        /// <returns>The default contact.</returns>
        public override Contact CreateContact(
                    List<CryptographicCapability> capabilities= null) {


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
