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

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

namespace Goedel.Mesh {



    public interface IVerifyCredential {

        /// <summary>
        /// Verify the device.
        /// </summary>
        /// <returns>The verified device (if successful)</returns>
        public MeshVerifiedDevice VerifyDevice();

        /// <summary>
        /// Verify the account
        /// </summary>
        /// <returns>The verified account (if successful)</returns>
        public MeshVerifiedAccount VerifyAccount();

        }





    /// <summary>
    /// JPC Credential bound to a Mesh credential (i.e. Mesh Profile and connection
    /// assertion).
    /// </summary>

    public class MeshCredential : ICredentialPublic, IVerifyCredential {
        #region // Properties

        ///<inheritdoc cref="ICredential"/>
        public KeyPairAdvanced AuthenticationPublic { get; }

        ///<inheritdoc cref="ICredential"/>
        public string Account { get; private set; }

        ///<inheritdoc cref="ICredential"/>
        public string AuthenticationKeyId { get; }

        ///<inheritdoc cref="ICredential"/>
        public string Provider => Account.GetService();

        ///<inheritdoc cref="ICredential"/>
        public CredentialValidation CredentialValidation { get; set; }

        ///<inheritdoc cref="ICredential"/>
        public KeyPairAdvanced AuthenticationPrivate { get; }




        ///<summary>The device profile</summary> 
        public ProfileDevice ProfileDevice { get; }

        ///<summary>The connection device</summary> 
        public ConnectionService ConnectionDevice { get; }

        ///<summary>The address connection.</summary> 
        public ConnectionAddress ConnectionAccount { get; }


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
        public MeshCredential(ProfileDevice profileDevice,
                ConnectionService connectionDevice,
                ConnectionAddress connectionAccount,
                KeyPairAdvanced authenticationKey,
                MeshCredentialPrivate meshCredentialPrivate = null) {
            ProfileDevice = profileDevice ?? meshCredentialPrivate?.ProfileDevice;
            ConnectionDevice = connectionDevice ?? meshCredentialPrivate?.ConnectionDevice;
            ConnectionAccount = connectionAccount ?? meshCredentialPrivate?.ConnectionAccount;
            AuthenticationPrivate = authenticationKey ?? meshCredentialPrivate?.AuthenticationPrivate;
            AuthenticationPublic = authenticationKey;

            AuthenticationKeyId = authenticationKey.KeyIdentifier;

            }


        #endregion
        #region // Methods

        ///<inheritdoc cref="ICredential"/>
        public (KeyPairAdvanced, KeyPairAdvanced) SelectKey() =>
            (KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced,
                        AuthenticationPublic);

        ///<inheritdoc cref="ICredential"/>
        public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<KeyPairAdvanced> ephemerals, string keyId) =>
            (ephemerals[0], AuthenticationPublic);

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

            Account = ConnectionAccount?.Account;

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
    public class MeshCredentialPrivate : MeshCredential, ICredentialPrivate {
        #region // Properties



        ///<inheritdoc/>
        public byte[] Value { get; }

        List<PacketExtension> Extensions { get; } = new();


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
                ConnectionAddress connectionAccount,
                KeyPairAdvanced authenticationKey,
                MeshCredentialPrivate meshCredentialPrivate = null) : base
                            (profileDevice, connectionDevice, connectionAccount,
                                    authenticationKey, meshCredentialPrivate) {

            if (meshCredentialPrivate?.ProfileDevice is null & profileDevice is not null) {
                Extensions.Add(new PacketExtension() {
                    Tag = Constants.ExtensionTagsMeshProfileDeviceTag,
                    Value = profileDevice.DareEnvelope.GetBytes(false)
                    });
                }
            if (meshCredentialPrivate?.ConnectionDevice is null & connectionDevice is not null) {
                authenticationKey.MatchKeyIdentifier(
                        connectionDevice.Authentication.PublicParameters.KeyPair.KeyIdentifier).AssertTrue (NYI.Throw);
                Extensions.Add(new PacketExtension() {
                    Tag = Constants.ExtensionTagsMeshConnectionDeviceTag,
                    Value = connectionDevice.DareEnvelope.GetBytes(false)
                    });
                }
            if (meshCredentialPrivate?.ConnectionAccount is null & connectionAccount is not null) {
                Extensions.Add(new PacketExtension() {
                    Tag = Constants.ExtensionTagsMeshConnectionAddressTag,
                    Value = connectionAccount.DareEnvelope.GetBytes(false)
                    });
                }



            }



        #endregion
        #region Implement ICredentialPrivate

        ///<inheritdoc/>
        public ICredentialPublic GetCredentials(List<PacketExtension> extensions) {

            ConnectionService connectionDevice = null;
            ConnectionAddress connectionAddress = null;
            ProfileDevice profileDevice = null;
            KeyPairAdvanced keyAuthentication = null;

            foreach (var extension in extensions) {
                switch (extension.Tag) {
                    case Constants.ExtensionTagsDirectX25519Tag: {
                        return new MeshKeyCredentialPublic(new KeyPairX25519(extension.Value));
                        }
                    case Constants.ExtensionTagsDirectX448Tag: {
                        return new MeshKeyCredentialPublic(new KeyPairX448 (extension.Value));
                        }


                    case Constants.ExtensionTagsMeshProfileDeviceTag: {
                        // convert the enveloped ConnectionDevice
                        var envelope = DareEnvelope.FromJSON(extension.Value, false);
                        profileDevice = envelope.DecodeJsonObject() as ProfileDevice;
                        keyAuthentication ??= profileDevice.Authentication.GetKeyPairAdvanced();
                        break;
                        }
                    case Constants.ExtensionTagsMeshConnectionDeviceTag: {
                        // convert the enveloped ConnectionDevice
                        var envelope = DareEnvelope.FromJSON(extension.Value, false);
                        connectionDevice = envelope.DecodeJsonObject() as ConnectionService;
                        keyAuthentication = connectionDevice.AuthenticationPublic;
                        break;
                        }
                    case Constants.ExtensionTagsMeshConnectionAddressTag: {
                        // convert the enveloped ConnectionDevice
                        var envelope = DareEnvelope.FromJSON(extension.Value, false);
                        connectionAddress = envelope.DecodeJsonObject() as ConnectionAddress;
                        break;
                        }
                    }
                }

            return new MeshCredential(profileDevice, connectionDevice, connectionAddress, keyAuthentication);
            }

        ///<inheritdoc/>
        public void AddEphemerals(List<PacketExtension> extensions, ref List<KeyPairAdvanced> ephmeralsOffered) {
            KeyPairAdvanced ephemeral;

            if (ephmeralsOffered != null) {
                ephemeral = ephmeralsOffered[0];
                //Screen.WriteLine($"Re-Offer of = {ephemeral}");

                }
            else {
                ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
                ephmeralsOffered = new List<KeyPairAdvanced> { ephemeral };
                //Screen.WriteLine($"Make Offer of = {ephemeral}");
                }

            var extension = new PacketExtension() {
                Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
                Value = ephemeral.IKeyAdvancedPublic.Encoding
                };


            extensions.Add(extension);
            }

        ///<inheritdoc/>
        public void AddCredentials(List<PacketExtension> extensions) {
            foreach (var extension in Extensions) {
                extensions.Add(extension);
                }
            }

        ///<inheritdoc/>
        public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<PacketExtension> extensions) {
            foreach (var extension in extensions) {
                if (extension.Tag == "X448") {
                    var ephemeral = new KeyPairX448(extension.Value, KeySecurity.Public);
                    //Screen.WriteLine($"Select = {ephemeral}");
                    return (AuthenticationPrivate, ephemeral);
                    }
                }
            throw new NYI();
            }

        ///<inheritdoc/>
        public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(string keyId, byte[] ephemeral) =>
                (AuthenticationPrivate, new KeyPairX448(ephemeral, KeySecurity.Public));

        #endregion
        }


    }
