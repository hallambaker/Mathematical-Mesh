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
    public class ContextGroup : ContextAccount {
        #region // Properties

        ///<summary>The enclosing mesh context.</summary>
        public ContextUser ContextAccount;

        ///<summary>The catalogued group description.</summary>
        public CatalogedGroup CatalogedGroup;


        ///<summary>The account profile</summary>
        public override Profile Profile => ProfileGroup;

        ///<summary>The account address.</summary>
        public override string AccountAddress => CatalogedGroup.Key;

        ///<summary>The group profile.</summary>
        public ProfileGroup ProfileGroup => CatalogedGroup.Profile;

        ///<summary>The group connection under which this context is formed.</summary>
        public ConnectionGroup ConnectionGroup;
        ///<summary>Convenience accessor for the connection.</summary>
        public override Connection Connection => ConnectionGroup;


        ///<summary>The member's device signature key</summary>
        protected override KeyPair KeySignature => null;

        ///<summary>The directory containing the catalogs related to the account.</summary>
        public override string StoresDirectory => storesDirectory ??
            Path.Combine(MeshMachine.DirectoryMesh, ProfileGroup.UDF).CacheValue(out storesDirectory);
        string storesDirectory;

        ///<summary>Dictionarry used to create stores</summary>
        public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => stores;
        Dictionary<string, StoreFactoryDelegate> stores = new Dictionary<string, StoreFactoryDelegate>() {
            {SpoolInbound.Label, SpoolInbound.Factory},
            {SpoolOutbound.Label, SpoolOutbound.Factory},
            {SpoolLocal.Label, SpoolLocal.Factory},
            {SpoolArchive.Label, SpoolArchive.Factory},

            {CatalogMember.Label, CatalogMember.Factory},

            // All contexts have a capability catalog:
            {CatalogCapability.Label, CatalogCapability.Factory},
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
            ContextAccount = contextAccount;
            }

        /// <summary>
        /// Create a new group.
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to create.</param>
        /// <returns>The group context.</returns>
        public static ContextGroup CreateGroup(ContextUser contextAccount, CatalogedGroup catalogedGroup) {
            var result = new ContextGroup(contextAccount, catalogedGroup);

            // Prepoulate the catalogs
            Directory.CreateDirectory(result.StoresDirectory);

            result.GetCatalogMember();
            result.GetCatalogCapability();
            result.SyncProgressUpload();

            return result;
            }

        #endregion
        #region // Class methods

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogMember GetCatalogMember() => GetStore(CatalogMember.Label) as CatalogMember;

        // ToDo: Implement Add member to group

        /// <summary>
        /// Add a member to the group.
        /// </summary>
        /// <param name="memberAddress">The member to add.</param>
        /// <param name="text">Constrained text to be included in the invitation.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Add(string memberAddress, string text=null) {

            // Bug: Should create an entry for the member

            // Pull the contact information from the user's contact catalog
            var networkProtocolEntry = ContextAccount.GetCatalogContact().GetNetworkEntry(memberAddress);

            var userEncryptionKey = networkProtocolEntry.MeshKeyEncryption;
            var serviceEncryptionKey = ContextAccount.ProfileUser.ProfileService.KeyEncryption.CryptoKey;


            // Create the capability 
            var capabilityService = new CapabilityDecryptServiced() {
                AuthenticationId = ContextAccount.ProfileUser.UDF,
                KeyDataEncryptionKey = serviceEncryptionKey
                };

            var capabilityMember = new CapabilityDecryptPartial() {
                Id = ProfileGroup.AccountEncryption.UDF,
                SubjectId = ProfileGroup.AccountEncryption.UDF,
                ServiceAddress = AccountAddress,
                KeyDataEncryptionKey = userEncryptionKey
                };


            var keyGenerate = ContextAccount.GetCatalogCapability().TryFindKeyGenerate(
                            ProfileGroup.AccountEncryption.UDF);
            keyGenerate.CreateShares(capabilityService, capabilityMember);

            // Fix up the identifiers.
            capabilityMember.ServiceId = capabilityMember.KeyData.UDF;
            capabilityService.Id = capabilityMember.ServiceId;
            capabilityService.SubjectId = capabilityMember.ServiceId;

            // Create and send the invitation

            var listCapability = new List<CryptographicCapability> { capabilityMember };

            var contact = CreateContact(listCapability);

            var groupInvitation = new GroupInvitation() {
                Sender = ContextAccount.AccountAddress,
                Recipient = memberAddress,
                Text = text,
                Contact = contact
                };

            var catalogedMember = new CatalogedMember() {
                ContactAddress = memberAddress,
                MemberCapabilityId = capabilityMember.Id,
                ServiceCapabilityId = capabilityService.Id,
                };

            var transactInvitation = new TransactRequest();
            OutboundMessage(transactInvitation, networkProtocolEntry, groupInvitation);

            var transactGroup= new TransactRequest();
            
            // update the capabilities catalog to add the service capability
            var catalogCapability = GetCatalogCapability();
            var catalogedCapability = new CatalogedCapability(capabilityService);
            CatalogUpdate(transactGroup,  catalogCapability, catalogedCapability);

            // update the members catalog to add the member entry
            var catalogMember = GetCatalogMember();
            CatalogUpdate(transactGroup, catalogMember, catalogedMember);

            // commit the transactions
            Transact(transactGroup);
            Transact(transactInvitation);

            // ToDo: Handle error return properly if the group transaction fails (need retry race);

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
                UDF = ProfileGroup.UDF,
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
            var catalogMember = GetCatalogMember();
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
            var catalogMember = GetCatalogMember();
            var catalogCapability = GetCatalogCapability();

            var capability = catalogCapability.Get(member.ServiceCapabilityId);
            // delete the capabilities of the member

            var transactGroup = new TransactRequest();
            CatalogDelete(transactGroup, catalogMember, member);
            CatalogDelete(transactGroup, catalogCapability, capability);

            Transact(transactGroup);
            }


        #endregion
        }





    }
