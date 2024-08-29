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


using Goedel.Cryptography.Jose;
using Goedel.Protocol;

namespace Goedel.Callsign.Registry;

#region // ActivationApplicationRegistry
public partial class ActivationApplicationRegistry {
    #region // Properties
    ///<summary>The enveloped object</summary> 
    public Enveloped<ActivationApplicationRegistry> GetEnvelopedActivationApplicationRegistry() =>
        new(DareEnvelope);

    ///<summary>The encryption key used to decrypt messages sent to the registry.</summary> 
    public KeyPair CommonEncryptionKey { get; private set; }

    ///<summary>The signaturee key used to sign registry registrations..</summary> 
    public KeyPair AdministratorSignatureKey { get; private set; }

    ///<summary>The  key used to authenticate the device to the registry.</summary> 
    public KeyPair AccountAuthentication { get; private set; }
    #endregion

    /// <summary>
    /// Activate the application for the device <paramref name="profileDevice"/>.
    /// </summary>
    /// <param name="profileDevice">The activated device profile.</param>
    public void Activate(ProfileDevice profileDevice) {
        CommonEncryptionKey = AccountEncryption.GetKeyPair();
        AdministratorSignatureKey = AdministratorSignature.GetKeyPair();

        var accountSeed = new PrivateKeyUDF(ActivationKey);
        AccountAuthentication = accountSeed.ActivatePrivate(
            profileDevice.KeyAuthentication, MeshActor.Service, MeshKeyOperation.Authenticate);

        }
    }
#endregion

#region // ApplicationEntryRegistry

public partial class ApplicationEntryRegistry {

    #region // Properties
    ///<summary>The decrypted activation.</summary> 
    public ActivationApplicationRegistry Activation { get; set; }

    ///<inheritdoc/>
    public override CatalogedAccess GetCatalogedAccess() {

        var connectionService = EnvelopedConnectionService.Decode();

        var capability = new AccessCapability() {
            Id = connectionService.Authentication.Udf,
            Active = true
            };

        var result = new CatalogedAccess() {
            Capability = capability
            };

        return result;

        }

    #endregion
    #region // Methods

    ///<inheritdoc/>
    public override void Decode(IKeyCollection keyCollection) =>
        Activation = EnvelopedActivation.Decode(keyCollection);

    /// <summary>
    /// Construct an activation record for the group.
    /// </summary>
    /// <returns></returns>
    public ActivationCommon GetActivationAccount() => new() {
        CommonEncryptionKey = Activation.AccountEncryption.GetKeyPair(),
        AdministratorSignatureKey = Activation.AdministratorSignature.GetKeyPair()
        };


    #endregion

    }
#endregion

public partial class CatalogedRegistry {
    #region // Properties
    ///<summary>Return the catalog identifier for the group <paramref name="groupAddress"/>.</summary>
    public static string GetGroupID(string groupAddress) => "CatalogedRegistry:" + groupAddress;

    /// <summary>
    /// The primary key used to catalog the entry.
    /// </summary>
    public override string _PrimaryKey => GetGroupID(Key);


    ///<summary>Cached convenience accessor that unpacks the value of <see cref="EnvelopedProfileRegistry"/>
    ///to return the <see cref="ProfileRegistry"/> value.</summary>
    public ProfileRegistry? ProfileRegistry => profileRegistry ??
                (EnvelopedProfileRegistry.Decode(KeyCollection) as ProfileRegistry).CacheValue(out profileRegistry);
    ProfileRegistry? profileRegistry;

    ///<summary>The connection used to authenticate the client to the service.</summary> 
    public ConnectionService ConnectionService { get; set; }

    ///<summary>The activation record.</summary> 
    public ActivationApplicationRegistry ActivationApplicationRegistry { get; set; }

    PrivateKeyUDF SecretSeed { get; }
    KeyPair CommonEncryptionKey { get; }
    KeyPair AdministratorSignatureKey { get; }

    ///<inheritdoc/>
    public override bool DeviceAuthorized(CatalogedDevice catalogedDevice) {
        return true;
        }

    /// <summary>
    /// Return the escrowed keys.
    /// </summary>
    /// <returns></returns>
    public override KeyData[] GetEscrow() =>
        new KeyData[] { new KeyData () {
                PrivateParameters = SecretSeed } };



    #endregion
    #region // Factory methods and constructors
    /// <summary>
    /// Default constructor for serialization.
    /// </summary>     
    public CatalogedRegistry() {
        }


    /// <summary>
    /// Create and return a new catalog entry for <paramref name="profile"/> with
    /// the activation data <paramref name="activationAccount"/>.
    /// </summary>
    /// <param name="profile">The group profile.</param>
    /// <param name="activationAccount">The activation data.</param>
    /// <returns>The created group.</returns>
    public CatalogedRegistry(
                    ProfileRegistry profile,
                    ActivationCommon activationAccount
                    ) {


        profileRegistry = profile;
        profile?.DareEnvelope.AssertNotNull(Internal.Throw);


        Key = profile.AccountAddress;
        EnvelopedProfileRegistry = profile.GetEnvelopedProfileAccount();


        SecretSeed = activationAccount.SecretSeed;
        CommonEncryptionKey = activationAccount.CommonEncryptionKey;
        AdministratorSignatureKey = activationAccount.AdministratorSignatureKey;
        }


    ///<inheritdoc/>
    public override void Activate(
                List<ApplicationEntry> activationEntries,
                ProfileDevice profileDevice,
                IKeyCollection keyCollection) {

        foreach (var entry in activationEntries) {
            if (entry is ApplicationEntryRegistry applicationEntry) {
                if (applicationEntry.Identifier == ProfileRegistry.UdfString) {
                    Activate(applicationEntry, profileDevice, keyCollection);
                    }
                }


            }

        }


    void Activate(
                ApplicationEntryRegistry applicationEntry,
                ProfileDevice profileDevice,
                IKeyCollection keyCollection) {
        profileDevice.Activate(keyCollection);

        ActivationApplicationRegistry = applicationEntry.EnvelopedActivation.Decode(keyCollection);
        ConnectionService = applicationEntry.EnvelopedConnectionService.Decode(keyCollection);
        ActivationApplicationRegistry.Activate(profileDevice);
        }

    ///<inheritdoc/>
    public override ApplicationEntry GetActivation(CatalogedDevice catalogedDevice) {
        //connectionDevice = new ConnectionDevice() {
        //    Authentication = profileDevice.Encryption
        //    };
        //connectionDevice.Envelope(KeyAdministratorSign);


        var profileDevice = catalogedDevice.ProfileDevice;
        var accountSeed = new PrivateKeyUDF(
                udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);

        var AccountAuthentication = accountSeed.ActivatePublic(
            profileDevice.Authentication.GetKeyPairAdvanced(), MeshActor.Service, MeshKeyOperation.Authenticate);


        var activation = new ActivationApplicationRegistry() {
            ActivationKey = accountSeed.PrivateValue,
            AccountEncryption = new KeyData(CommonEncryptionKey, true),
            AdministratorSignature = new KeyData(AdministratorSignatureKey, true),
            };

        activation.Envelope(encryptionKey: catalogedDevice.ConnectionDevice.Encryption.GetKeyPair());


        var connectionService = new ConnectionService() {
            ProfileUdf = ProfileRegistry.UdfString,
            Authentication = new KeyData(AccountAuthentication)
            };
        connectionService.Envelope(AdministratorSignatureKey, objectEncoding:
            ObjectEncoding.JSON_B);

        return new ApplicationEntryRegistry() {
            Identifier = ProfileRegistry.UdfString,
            EnvelopedActivation = activation.GetEnvelopedActivationApplicationRegistry(),
            EnvelopedConnectionService = connectionService?.GetEnvelopedConnectionService()
            };

        }

    ///<inheritdoc/>
    public override void ToBuilder(StringBuilder output) {

        }

    #endregion

    }
