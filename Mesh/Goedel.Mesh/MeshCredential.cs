//  Copyright © 2021 Threshold Secrets Llc
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
//  
//  
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using System.Text;
using System.Collections.Generic;
using System;
using Goedel.Protocol;

namespace Goedel.Mesh {

    /// <summary>
    /// JPC Credential bound to a Mesh credential (i.e. Mesh Profile and connection
    /// assertion).
    /// </summary>

    public class MeshCredential : ICredentialPublic {
        #region // Properties
        ///<inheritdoc cref="ICredential"/>
        public string Account { get; private set; }

        ///<inheritdoc cref="ICredential"/>
        public string AuthenticationKeyId { get; }

        ///<inheritdoc cref="ICredential"/>
        public string Provider { get; }

        ///<inheritdoc cref="ICredential"/>
        public CredentialValidation CredentialValidation { get; }

        ///<inheritdoc cref="ICredential"/>
        public KeyPairAdvanced AuthenticationPrivate { get; }

        ///<inheritdoc cref="ICredential"/>
        public KeyPairAdvanced AuthenticationPublic { get; }

        ///<summary>The device profile</summary> 
        public ProfileDevice ProfileDevice { get; }

        ///<summary>The connection device</summary> 
        public ConnectionDevice ConnectionDevice { get; }

        ///<summary>The address connection.</summary> 
        public ConnectionAddress ConnectionAccount { get; }


        #endregion
        #region // Constructors

        /// <summary>
        /// Create a credential wrapper for a device key asserted by means of the connection
        /// <paramref name="connectionDevice"/>.
        /// </summary>
        /// <param name="connectionDevice">The device connection assertion.</param>
        public MeshCredential(ProfileDevice profileDevice,
                ConnectionDevice connectionDevice,
                ConnectionAddress connectionAccount,
                KeyPairAdvanced authenticationKey,
                MeshCredentialPrivate meshCredentialPrivate = null) :
                        this(connectionDevice.Authentication.GetKeyPairAdvanced()) {
            ProfileDevice = profileDevice ?? meshCredentialPrivate?.ProfileDevice;
            ConnectionDevice = connectionDevice ?? meshCredentialPrivate?.ConnectionDevice;
            ConnectionAccount = connectionAccount ?? meshCredentialPrivate?.ConnectionAccount;
            AuthenticationPrivate = authenticationKey ?? meshCredentialPrivate?.AuthenticationPrivate;
            }


        /// <summary>
        /// Create a credential wrapper for a device key asserted by means of the authentication
        /// key <paramref name="authenticationPublic"/>.
        /// </summary>
        /// <param name="authenticationPublic">The authentication key.</param>
        public MeshCredential(KeyPairAdvanced authenticationPublic) {
            AuthenticationPublic = authenticationPublic;
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


        ///// <summary>
        ///// Claim a binding to the account <paramref name="profileAccount"/>.
        ///// </summary>
        ///// <param name="profileAccount"></param>
        ///// <returns></returns>
        //public virtual bool Verify(ProfileAccount profileAccount) {
        //    if (!profileAccount.Verify(ConnectionDevice.DareEnvelope)) {
        //        return false;
        //        }

        //    Validated = profileAccount.Udf;
        //    Account = profileAccount.AccountAddress;
        //    return true;
        //    }

        #endregion

        }

    /// <summary>
    /// Wrapper for a private credential.
    /// </summary>
    public class MeshCredentialPrivate : MeshCredential, ICredentialPrivate {
        #region // Properties

        ///<inheritdoc/>
        public string Tag { get; }

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
                ConnectionDevice connectionDevice,
                ConnectionAddress connectionAccount,
                KeyPairAdvanced authenticationKey,
                MeshCredentialPrivate meshCredentialPrivate = null) : base 
                            (profileDevice, connectionDevice, connectionAccount, 
                                    authenticationKey, meshCredentialPrivate) {


            // Add extensions to describe the credential if they have changed.
            if (authenticationKey?.KeyIdentifier !=
                    meshCredentialPrivate?.AuthenticationPrivate?.KeyIdentifier) {
                Extensions.Add(new PacketExtension() {
                    Tag = authenticationKey.CryptoAlgorithmId.ToJoseID(),
                    Value = authenticationKey.IKeyAdvancedPublic.Encoding
                    });

                // here we need to do a key exchange against the new private key.


                }

            if (meshCredentialPrivate.ProfileDevice is null & profileDevice is not null) {
                Extensions.Add(new PacketExtension() {
                    Tag = Constants.ExtensionTagsMeshProfileDeviceTag,
                    Value = profileDevice.GetBytes()
                    });
                }
            if (meshCredentialPrivate.ConnectionDevice is null & connectionDevice is not null) {
                Extensions.Add(new PacketExtension() {
                    Tag = Constants.ExtensionTagsMeshProfileDeviceTag,
                    Value = connectionDevice.GetBytes()
                    });
                }
            if (meshCredentialPrivate.ConnectionAccount is null & connectionAccount is not null) {
                Extensions.Add(new PacketExtension() {
                    Tag = Constants.ExtensionTagsMeshProfileDeviceTag,
                    Value = connectionAccount.GetBytes()
                    });
                }



            }

        

        ///// <summary>
        ///// Construct a credential from <paramref name="connectionDevice"/> with 
        ///// private key capabilities.
        ///// </summary>
        ///// <param name="connectionDevice">An activated device activation.</param>
        ///// <param name="key">The private key</param>
        //public MeshCredentialPrivate(ConnectionDevice connectionDevice, KeyPair key) : base (connectionDevice) {

        //    (connectionDevice.AuthenticationPublic.KeyIdentifier).AssertEqual(key.KeyIdentifier, NYI.Throw);


        //    Tag = Constants.ExtensionTagsMeshConnectionDeviceTag;
        //    Value = connectionDevice.DareEnvelope.GetJsonB(false);

        //    Screen.WriteLine(connectionDevice.ToString());

            
        //    AuthenticationPrivate = key as KeyPairAdvanced;

        //    }

        ///// <summary>
        ///// Construct a credential from <paramref name="profileDevice"/> with 
        ///// private key capabilities.
        ///// </summary>
        ///// <param name="profileDevice"></param>
        //public MeshCredentialPrivate(ProfileDevice profileDevice) : 
        //            base (profileDevice.Authentication.GetKeyPairAdvanced(KeySecurity.Public)) {

        //    AuthenticationPrivate = profileDevice.Authentication.GetKeyPairAdvanced(KeySecurity.Device);

        //    }

        ///// <summary>
        ///// Create a credential wrapper for a device key asserted by means of the authentication
        ///// key <paramref name="authenticationprivate"/>.
        ///// </summary>
        ///// <param name="authenticationprivate">The authentication key.</param>
        //public MeshCredentialPrivate(KeyPairAdvanced authenticationprivate) :
        //    base(authenticationprivate) {

        //    AuthenticationPrivate = authenticationprivate;

        //    }


        #endregion
        #region Implement ICredential

        ///<inheritdoc/>
        public ICredentialPublic GetCredentials(List<PacketExtension> extensions) {

            ConnectionDevice connectionDevice= null;
            ConnectionAddress connectionAddress = null;
            ProfileDevice profileDevice = null;
            KeyPairAdvanced keyAuthentication = null;

            foreach (var extension in extensions) {
                switch (extension.Tag) {
                    case Constants.ExtensionTagsMeshProfileDeviceTag: {
                        // convert the enveloped ConnectionDevice
                        var envelope = DareEnvelope.FromJSON(extension.Value, false);
                        profileDevice = envelope.DecodeJsonObject() as ProfileDevice;
                        keyAuthentication ??= profileDevice.KeyAuthentication as KeyPairAdvanced;
                        break;
                        }
                    case Constants.ExtensionTagsMeshConnectionDeviceTag: {
                        // convert the enveloped ConnectionDevice
                        var envelope = DareEnvelope.FromJSON(extension.Value, false);
                        connectionDevice = envelope.DecodeJsonObject() as ConnectionDevice;
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
                Screen.WriteLine($"Re-Offer of = {ephemeral}");

                }
            else {
                ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
                ephmeralsOffered = new List<KeyPairAdvanced> { ephemeral };
                Screen.WriteLine($"Make Offer of = {ephemeral}");
                }

            var extension = new PacketExtension() {
                Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
                Value = ephemeral.IKeyAdvancedPublic.Encoding
                };


            extensions.Add(extension);
            }

        ///<inheritdoc/>
        public void AddCredentials(List<PacketExtension> extensions) => extensions.Add(new PacketExtension() {
            Tag = Tag,
            Value = Value
            });

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
        #region Local methods

        /// <summary>
        /// Not sure if this is needed, binding of the profile might well be a stream 
        /// action rather than a credential action.
        /// </summary>
        /// <param name="profileAccount"></param>
        public void Bind(ProfileAccount profileAccount) {

            }

        #endregion
        }


    }
