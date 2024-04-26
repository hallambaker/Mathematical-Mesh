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


namespace Goedel.Mesh.Client;

/// <summary>
/// Context binding for a Group account
/// </summary>
public partial class ContextGroup : ContextAccount {
    #region // Properties

    ///<summary>The enclosing user context.</summary>
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


    //public override ProfileService ProfileService => ContextUser.ProfileService;

    ///<inheritdoc/>
    public override string ServiceAddress => ProfileGroup?.AccountAddress;

    ///<inheritdoc/>
    public override string ServiceDns => ServiceAddress.GetService();

    ///<summary>The group profile.</summary>
    public ProfileGroup ProfileGroup => CatalogedGroup?.ProfileGroup;

    ///<summary>The group connection under which this context is formed.</summary>
    public ConnectionGroup ConnectionGroup;
    ///<summary>Convenience accessor for the connection.</summary>
    public override Connection Connection => ConnectionGroup;

    /////<inheritdoc/>
    //public override IKeyCollection KeyCollection => ContextUser;


    ///<inheritdoc/>
    public MeshKeyCredentialPrivate GetKeyCredentialPrivate() =>
       new(KeyCommonAuthentication as KeyPairAdvanced, ServiceAddress);
    // have to get the credential from the client...


    ///<inheritdoc/>
    public override MeshServiceClient MeshClient {
        get => meshClient ??
          GetMeshClient(GetKeyCredentialPrivate()).CacheValue(out meshClient);
        set => meshClient = value;
        }
    MeshServiceClient meshClient;


    ///<summary>Dictionarry used to create stores</summary>
    public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => stores;

    readonly Dictionary<string, StoreFactoryDelegate> stores = new() {
            { CatalogMember.Label, CatalogMember.Factory },

        // All contexts have a capability catalog:
            { CatalogAccess.Label, CatalogAccess.Factory },
            { CatalogPublication.Label, CatalogPublication.Factory }
        };

    #endregion
    #region // Factory methods and constructors

    /// <summary>
    /// Default constuctor, creates a group context for <paramref name="catalogedGroup"/>
    /// </summary>
    /// <param name="contextAccount">The enclosing account context.</param>
    /// <param name="catalogedGroup">Description of the group to return the
    /// context for.</param>
    /// <param name="activationAccount">The account activation.</param>
    public ContextGroup(ContextUser contextAccount,
                CatalogedGroup catalogedGroup,
                ActivationCommon activationAccount) :
                base(contextAccount.MeshHost, null) {
        ActivationCommon = activationAccount;
        CatalogedGroup = catalogedGroup;
        ContextUser = contextAccount;
        }

    /// <summary>
    /// Create a new group.
    /// </summary>
    /// <param name="contextAccount">The enclosing account context.</param>
    /// <param name="catalogedGroup">Description of the group to create.</param>
    /// <param name="activationAccount">The account activation.</param>
    /// <param name="client">The client to connect to the service with.</param>
    /// <returns>The group context.</returns>
    public static ContextGroup CreateGroup(
                ContextUser contextAccount,
                CatalogedGroup catalogedGroup,
                ActivationCommon activationAccount,
                MeshServiceClient client) {
        var result = new ContextGroup(contextAccount, catalogedGroup, activationAccount) {
            MeshClient = client
            };

        // Prepopulate the catalogs
        Directory.CreateDirectory(result.StoresDirectory);

        result.LoadStores();
        result.SyncProgressUpload();

        return result;
        }

    #endregion
    #region // Class methods

    /// <summary>
    /// Add the member <paramref name="memberAddress"/> to the group.
    /// </summary>
    /// <param name="memberAddress">The member to add.</param>
    /// <param name="text">Invitation text.</param>
    /// <returns>The catalog entry for the member created.</returns>
    public CatalogedMember Add(string memberAddress, string text = null) => 
        AddAsync (memberAddress, text).Sync();

    /// <summary>
    /// Add a member to the group.
    /// </summary>
    /// <param name="memberAddress">The member to add.</param>
    /// <param name="text">Constrained text to be included in the invitation.</param>
    /// <returns>The member catalog entry.</returns>
    public async Task<CatalogedMember> AddAsync(string memberAddress, string text = null) {

        var transactInvitation = ContextUser.TransactBegin();
        var transactGroup = TransactBegin();
        var catalogMember = transactGroup.GetCatalogMember();

        // Pull the contact information from the user's contact catalog
        var networkProtocolEntry = ContextUser.GetNetworkEntry(memberAddress);
        var userEncryptionKey = networkProtocolEntry.MeshKeyEncryption;

        // will fail because the ProfileService is not set.
        var serviceEncryptionKey = ContextUser.HostEncryptAccount;


        var keyGenerate = ActivationCommon.CommonEncryptionKey as KeyPairAdvanced;
        var (keyData, capabilityService) = CatalogAccess.MakeShare(
                    keyGenerate, ServiceAddress, serviceEncryptionKey, memberAddress);

        keyData.Envelope(encryptionKey: userEncryptionKey);
        var capabilityMember = new CapabilityDecryptPartial() {
            Id = ProfileGroup.CommonEncryption.Udf,
            EnvelopedKeyShare = keyData.GetEnvelopedKeyData(),
            Issued = (int) catalogMember.FrameCount
            };

        // Create and send the invitation

        var listCapability = new List<CryptographicCapability> { capabilityMember };

        var contact = CreateContact(listCapability);

        var groupInvitation = new GroupInvitation() {
            Sender = ContextUser.ServiceAddress,
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
        transactGroup.CatalogUpdate(catalogMember, catalogedMember);

        //// commit the transactions
        //Transact(transactGroup);
        //Transact(transactInvitation);

        await transactGroup.TransactAsync();
        await transactInvitation.TransactAsync();

        return catalogedMember;


        }

    /// <summary>
    /// Get the default (i.e. minimum contact info). This has a single network 
    /// address entry for this mesh and mesh account. 
    /// </summary>
    /// <returns>The default contact.</returns>
    public override Contact CreateContact(
                List<CryptographicCapability> capabilities = null) {


        var anchorAccount = new Anchor() {
            Udf = ProfileGroup.UdfString,
            Validation = "Self"
            };
        // ContextMesh.ProfileMesh.UDF 

        var contact = new ContactPerson() {
            Anchors = new List<Anchor>() { anchorAccount }
            };

        if (capabilities is null) {
            var address = new NetworkProfile(ServiceAddress, Profile as ProfileAccount);
            contact.NetworkAddresses = new List<NetworkAddress>() { address };
            }
        else {
            var address = new NetworkCapability(ServiceAddress, Profile as ProfileAccount) {
                Capabilities = capabilities
                };
            contact.NetworkAddresses = new List<NetworkAddress>() { address };
            }

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


    /// <summary>
    /// Delete a member from the group
    /// </summary>
    /// <param name="memberAddress">The member to delete.</param>
    /// <returns>The member catalog entry.</returns>
    public async Task DeleteAsync(string memberAddress) {
        var member = Locate(memberAddress);
        member.AssertNotNull(EntryNotFound.Throw, memberAddress);
        await DeleteAsync(member);
        }

    /// <summary>
    /// Delete a member from the group
    /// </summary>
    /// <param name="member">The member to delete.</param>
    /// <returns>The member catalog entry.</returns>
    public async Task DeleteAsync(CatalogedMember member) {
        var transactGroup = TransactBegin();


        var catalogMember = transactGroup.GetCatalogMember();
        var catalogCapability = transactGroup.GetCatalogAccess();

        var capability = catalogCapability.Get(member.ServiceCapabilityId);
        // delete the capabilities of the member


        transactGroup.CatalogDelete(catalogMember, member);
        transactGroup.CatalogDelete(catalogCapability, capability);

        await TransactAsync(transactGroup);
        }


    #endregion
    }
