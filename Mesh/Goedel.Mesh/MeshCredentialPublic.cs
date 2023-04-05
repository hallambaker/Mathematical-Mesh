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


namespace Goedel.Mesh;


/// <summary>
/// JPC Credential bound to a Mesh credential (i.e. Mesh Profile and connection
/// assertion).
/// </summary>

public class MeshCredentialPublic : MeshKeyCredentialPublic {
    #region // Properties

    ///<inheritdoc cref="ICredential"/>
    public KeyPairAdvanced AuthenticationPrivate { get; }

    ///<summary>The device profile</summary> 
    public ProfileDevice ProfileDevice { get; }

    ///<summary>The connection device</summary> 
    public ConnectionService ConnectionDevice { get; }

    ///<summary>The address connection.</summary> 
    public ConnectionStripped ConnectionAccount { get; }


    #endregion
    #region // Constructors

    /// <summary>
    /// Create a credential wrapper for a device key asserted by means of the connection
    /// <paramref name="connectionDevice"/>.
    /// </summary>
    /// <param name="connectionDevice">The device connection assertion.</param>
    /// <param name="profileDevice">The device profile</param>
    /// <param name="connectionAccount">Connection to the account </param>
    /// <param name="authenticationKey">The authentication key</param>
    /// <param name="meshCredentialPrivate">The private credential.</param>
    public MeshCredentialPublic(ProfileDevice profileDevice,
            ConnectionService connectionDevice,
            ConnectionStripped connectionAccount,
            KeyPairAdvanced authenticationKey,
            MeshCredentialPrivate meshCredentialPrivate = null) : base(authenticationKey) {
        ProfileDevice = profileDevice ?? meshCredentialPrivate?.ProfileDevice;
        ConnectionDevice = connectionDevice ?? meshCredentialPrivate?.ConnectionDevice;
        ConnectionAccount = connectionAccount ?? meshCredentialPrivate?.ConnectionAccount;
        AuthenticationPrivate = authenticationKey ?? meshCredentialPrivate?.AuthenticationPrivate;
        //AuthenticationPublic = authenticationKey;

        //AuthenticationKeyId = authenticationKey.KeyIdentifier;
        Account = connectionAccount?.Account ?? connectionDevice?.ProfileUdf;
        }


    #endregion
    #region // Methods

    /////<inheritdoc cref="ICredential"/>
    //public (KeyPairAdvanced, KeyPairAdvanced) SelectKey() =>
    //    (KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced,
    //                AuthenticationPublic);

    /////<inheritdoc cref="ICredential"/>
    //public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<KeyPairAdvanced> ephemerals, string keyId) =>
    //    (ephemerals[0], AuthenticationPublic);

    /// <summary>
    /// Verify the device.
    /// </summary>
    /// <returns>The verified device (if successful)</returns>
    public MeshVerifiedDevice VerifyDevice() {
        if (ConnectionDevice != null) {
            return VerifyAccount();
            }
        ProfileDevice.AssertNotNull(NotAuthenticated.Throw);
        ProfileDevice.Validate();
        AuthenticationPublic.MatchKeyIdentifier(
                ProfileDevice.Authentication.Udf).AssertTrue(NotAuthenticated.Throw);
        CredentialValidation = CredentialValidation.Device;
        return new MeshVerifiedDevice(this);
        }

    /// <summary>
    /// Verify the account
    /// </summary>
    /// <returns>The verified account (if successful)</returns>
    public MeshVerifiedAccount VerifyAccount() {
        ConnectionDevice.AssertNotNull(NotAuthenticated.Throw);

        //Account = ConnectionAccount?.Account;

        AuthenticationPublic.MatchKeyIdentifier(
            ConnectionDevice.AuthenticationPublic.KeyIdentifier).AssertTrue(NotAuthenticated.Throw);

        CredentialValidation = CredentialValidation.Account;
        return new MeshVerifiedAccount(this);

        }


    #endregion

    }

/// <summary>
/// Wrapper for a private credential.
/// </summary>
public class MeshCredentialPrivate : MeshKeyCredentialPrivate {
    #region // Properties

    /////<inheritdoc/>
    //public byte[] Elements { get; }

    //List<PacketExtension> Extensions { get; } = new();

    ///<summary>The device profile</summary> 
    public ProfileDevice ProfileDevice { get; }

    ///<summary>The connection device</summary> 
    public ConnectionService ConnectionDevice { get; }

    ///<summary>The address connection.</summary> 
    public ConnectionStripped ConnectionAccount { get; }



    #endregion
    #region // Constructors

    /// <summary>
    /// Create private credential
    /// </summary>
    /// <param name="profileDevice"></param>
    /// <param name="connectionDevice"></param>
    /// <param name="connectionAccount"></param>
    /// <param name="authenticationKey"></param>
    /// <param name="meshCredentialPrivate"></param>
    public MeshCredentialPrivate(
            ProfileDevice profileDevice,
            ConnectionService connectionDevice,
            ConnectionStripped connectionAccount,
            KeyPairAdvanced authenticationKey,
            MeshCredentialPrivate meshCredentialPrivate = null) : base(
                        null, connectionDevice?.ProfileUdf) {

        AuthenticationPrivate = authenticationKey ?? meshCredentialPrivate?.AuthenticationPrivate;
        AuthenticationPublic = AuthenticationPrivate;

        ProfileDevice = profileDevice ?? meshCredentialPrivate?.ProfileDevice;
        ConnectionDevice = connectionDevice ?? meshCredentialPrivate?.ConnectionDevice;
        ConnectionAccount = connectionAccount ?? meshCredentialPrivate?.ConnectionAccount;


        if (meshCredentialPrivate?.ProfileDevice is null & profileDevice is not null) {
            Extensions.Add(new PacketExtension() {
                Tag = Goedel.Protocol.Presentation.PresentationConstants.ExtensionTagsMeshProfileDeviceTag,
                Value = profileDevice.DareEnvelope.GetBytes(false)
                });
            }
        if (meshCredentialPrivate?.ConnectionDevice is null & connectionDevice is not null) {
            authenticationKey.MatchKeyIdentifier(
                    connectionDevice.Authentication.PublicParameters.KeyPair.KeyIdentifier).AssertTrue(NYI.Throw);
            Extensions.Add(new PacketExtension() {
                Tag = Goedel.Protocol.Presentation.PresentationConstants.ExtensionTagsMeshConnectionDeviceTag,
                Value = connectionDevice.DareEnvelope.GetBytes(false)
                });
            }
        if (meshCredentialPrivate?.ConnectionAccount is null & connectionAccount is not null) {
            Extensions.Add(new PacketExtension() {
                Tag = Goedel.Protocol.Presentation.PresentationConstants.ExtensionTagsMeshConnectionAddressTag,
                Value = connectionAccount.DareEnvelope.GetBytes(false)
                });
            }
        }

    #endregion
    #region Implement ICredentialPrivate

    /// <summary>
    /// Return the public credential.
    /// </summary>
    /// <returns></returns>
    public MeshCredentialPublic GetMeshCredentialPublic() =>
                new(ProfileDevice,
                ConnectionDevice,
                ConnectionAccount,
                AuthenticationPrivate.KeyPairPublic() as KeyPairAdvanced);

    public override ICredentialPublic GetICredentialPublic() => GetMeshCredentialPublic();

    #endregion
    }
