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
    public class ContextGroup : ContextAccountEntry {

        ///<summary>The enclosing mesh context.</summary>
        public override ContextMesh ContextMesh => ContextAccount.ContextMesh;


        ///<summary>The enclosing mesh context.</summary>
        public ContextAccount ContextAccount;

        ///<summary>The catalogued group description.</summary>
        public CatalogedGroup CatalogedGroup;

        ///<summary>The group profile.</summary>
        public ProfileGroup ProfileGroup => CatalogedGroup.Profile;

        ///<summary>The group connection under which this context is formed.</summary>
        public ConnectionGroup ConnectionGroup;
        ///<summary>Convenience accessor for the connection.</summary>
        public override Connection Connection => ConnectionGroup;

        ///<summary>The directory containing the catalogs related to the account.</summary>
        public override string StoresDirectory => storesDirectory ??
            Path.Combine(MeshMachine.DirectoryMesh, ProfileGroup.UDF).CacheValue(out storesDirectory);
        string storesDirectory;

        /// <summary>
        /// Default constuctor, creates a group context for <paramref name="catalogedGroup"/>
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to return the
        /// context for.</param>
        public ContextGroup(ContextAccount contextAccount, CatalogedGroup catalogedGroup) {
            CatalogedGroup = catalogedGroup;
            ContextAccount = contextAccount;
            AccountAddress = CatalogedGroup.Key;

            }

        /// <summary>
        /// Create a new group.
        /// </summary>
        /// <param name="contextAccount">The enclosing account context.</param>
        /// <param name="catalogedGroup">Description of the group to create.</param>
        /// <returns>The group context.</returns>
        public static ContextGroup CreateGroup(ContextAccount contextAccount, CatalogedGroup catalogedGroup) {
            var result = new ContextGroup(contextAccount, catalogedGroup);

            // Prepoulate the catalogs
            Directory.CreateDirectory(result.StoresDirectory);

            result.GetCatalogMember();
            result.GetCatalogCapability();

            return result;
            }


        ///<summary>Returns the network catalog for the account</summary>
        public CatalogMember GetCatalogMember() => GetStore(CatalogMember.Label) as CatalogMember;

        /// <summary>
        /// Create a new instance bound to the specified core within this account context.
        /// </summary>
        /// <param name="name">The name of the store to bind.</param>
        /// <returns>The store instance.</returns>
        protected override Store MakeStore(string name) => name switch
            {
                CatalogMember.Label => new CatalogMember(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                _ => base.MakeStore(name),
                };



        #region Implement Group operations

        ///<summary>Return the account address.</summary>
        public override string GetAccountAddress() => CatalogedGroup.Key;


        // ToDo: Implement Add member to group

        /// <summary>
        /// Add a member to the group.
        /// </summary>
        /// <param name="memberAddress">The member to add.</param>
        /// <returns>The member catalog entry.</returns>
        public CatalogedMember Add(string memberAddress, string text=null) {

            // Bug: Should create an entry for the member

            // Pull the contact information from the user's contact catalog
            var networkProtocolEntry = ContextAccount.GetCatalogContact().GetNetworkEntry(memberAddress);

            var userEncryptionKey = networkProtocolEntry.MeshKeyEncryption;
            var serviceEncryptionKey = ContextAccount.ProfileAccount.ProfileService.KeyEncryption.CryptoKey;


            // Create the capability 
            var capabilityService = new CapabilityDecryptServiced() {
                AuthenticationId = ContextAccount.ProfileAccount.UDF,
                KeyDataEncryptionKey = serviceEncryptionKey
                };

            var capabilityMember = new CapabilityDecryptPartial() {
                Id = ProfileGroup.KeyEncryption.UDF,
                SubjectId = ProfileGroup.KeyEncryption.UDF,
                ServiceAddress = AccountAddress,
                KeyDataEncryptionKey = userEncryptionKey
                };


            var keyGenerate = ContextAccount.GetCatalogCapability().TryFindKeyGenerate(
                            ProfileGroup.KeyEncryption.UDF);
            keyGenerate.CreateShares(capabilityService, capabilityMember);

            // Fix up the identifiers.
            capabilityMember.ServiceId = capabilityMember.KeyData.UDF;
            capabilityService.Id = capabilityMember.ServiceId;
            capabilityService.SubjectId = capabilityMember.ServiceId;





            // Add the service capability to the service catalog

            // This is failing to push out to the service catalog as it should
            // Sync is only for downloads.

            GetCatalogCapability().Add(capabilityService);



            // Create and send the invitation

            var listCapability = new List<CryptographicCapability> { capabilityMember };

            var contact = CreateContact(false, listCapability);

            var groupInvitation = new GroupInvitation() {
                Sender = ContextAccount.AccountAddress,
                Recipient = memberAddress,
                Text = text,
                Contact = contact
                };

            ContextAccount.SendMessage(groupInvitation, memberAddress, userEncryptionKey);


            //var envelopedCapabilityService = capabilityService.Encode(
            //    //encryptionKey:serviceEncryptionKey
            //    );
            //GetCatalogCapability().AppendDirect(envelopedCapabilityService);

            // Add the member to the member catalog

            var catalogedMember = new CatalogedMember() {
                ContactAddress = memberAddress,
                MemberCapabilityId = capabilityMember.Id,
                ServiceCapabilityId = capabilityService.Id,
                };
            GetCatalogMember().New(catalogedMember);

            SyncProgressUpload();


            // return the member entry.
            return catalogedMember;
            }


        IKeyAdvancedPrivate[] GetKeySplit(
                    CryptoKey userEncryptionKey, CryptoKey serviceEncryptionKey) {
            userEncryptionKey.Future();

            var keyGenerate = ContextAccount.GetCatalogCapability().TryFindKeyGenerate(
                            ProfileGroup.KeyEncryption.UDF);


            throw new NYI();

            //var keys = groupPrivate.MakeRecryptionKeySet(2);





            //return keys;

            }


        /// <summary>
        /// Get the default (i.e. minimum contact info). This has a single network 
        /// address entry for this mesh and mesh account. 
        /// </summary>
        /// <returns>The default contact.</returns>
        public override Contact CreateContact(bool meshUDF = false, 
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

            if (meshUDF) {
                var anchorMesh = new Anchor() {
                    UDF = ContextMesh.ProfileMesh.UDF,
                    Validation = "Self"
                    };
                contact.Anchors.Add(anchorMesh);
                }


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
            Delete(member);
            }


        /// <summary>
        /// Delete a member from the group
        /// </summary>
        /// <param name="member">The member to delete.</param>
        /// <returns>The member catalog entry.</returns>
        public void Delete(CatalogedMember member) {
            var catalogMember = GetCatalogMember();

            // delete the capabilities of the member


            catalogMember.Delete(member);

            return;
            }


        #endregion
        }





    }
