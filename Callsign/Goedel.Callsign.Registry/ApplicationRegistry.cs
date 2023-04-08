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


using Goedel.Cryptography.Dare;
using System.Reflection.Emit;

namespace Goedel.Callsign.Registry;

#region // ActivationApplicationRegistry
public partial class ActivationApplicationRegistry {
    #region // Properties
    ///<summary>The enveloped object</summary> 
    public Enveloped<ActivationApplicationRegistry> GetEnvelopedActivationApplicationRegistry() =>
        new(DareEnvelope);

    #endregion


    }
#endregion

#region // ApplicationEntryRegistry

public partial class ApplicationEntryRegistry {

    #region // Properties
    ///<summary>The decrypted activation.</summary> 
    public ActivationApplicationRegistry Activation { get; set; }

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

public partial class CatalogedRegistry{
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

    ActivationCommon ActivationAccount { get; set; }


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
                PrivateParameters =ActivationAccount.SecretSeed } };



    #endregion
    #region // Factory methods and constructors
    /// <summary>
    /// Default constructor for serialization.
    /// </summary>     
    public CatalogedRegistry() {
        }


    /// <summary>
    /// Create and return a new catalog entry for <paramref name="profileGroup"/> with
    /// the activation data <paramref name="activationAccount"/>.
    /// </summary>
    /// <param name="profileGroup">The group profile.</param>
    /// <param name="activationAccount">The activation data.</param>
    /// <param name="encryptionKey">Key under which the activation is to be encrypted.</param>
    /// <returns>The created group.</returns>
    public CatalogedRegistry(
                    ProfileRegistry profileGroup,
                    ActivationCommon activationAccount,
                    CryptoKey encryptionKey
        //,
        //            ConnectionStripped connectionAddress
                    ) {
        encryptionKey.Future();
        //connectionAddress.Future();

        profileGroup?.DareEnvelope.AssertNotNull(Internal.Throw);

        ActivationAccount = activationAccount;
        Key = profileGroup.AccountAddress;
        EnvelopedProfileRegistry = profileGroup.GetEnvelopedProfileAccount();
        }


    ///<inheritdoc/>
    public override void Activate(List<ApplicationEntry> activationEntry, IKeyCollection keyCollection) {
        }

    ///<inheritdoc/>
    public override ApplicationEntry GetActivation(CatalogedDevice catalogedDevice) {
        var activation = new ActivationApplicationRegistry() {
            AccountEncryption = new KeyData(ActivationAccount.CommonEncryptionKey, true),
            AdministratorSignature = new KeyData(ActivationAccount.AdministratorSignatureKey, true),
            //AccountAuthentication = new KeyData(ActivationAccount.CommonAuthenticationKey, true),
            };

        activation.Envelope(encryptionKey: catalogedDevice.ConnectionDevice.Encryption.GetKeyPair());



        return new ApplicationEntryRegistry() {
            Identifier = ProfileRegistry.AccountAddress,
            EnvelopedActivation = activation.GetEnvelopedActivationApplicationRegistry()
            };

        }

    ///<inheritdoc/>
    public override void ToBuilder(StringBuilder output) {

        }

    #endregion

    }
