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
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public class MeshKeyCredentialPublic : KeyCredentialPublic, ICredentialPublic{

        #region // Constructors
        /// <summary>
        /// Create a new instance with the public key <paramref name="authenticationPublic"/>
        /// </summary>
        /// <param name="authenticationPublic">The public key.</param>
        public MeshKeyCredentialPublic(KeyPairAdvanced authenticationPublic) : 
                    base (authenticationPublic) {
            }

        #endregion
        }



    public class MeshKeyCredentialPrivate : KeyCredentialPrivate, ICredentialPrivate {
        #region // Constructors
        public MeshKeyCredentialPrivate(KeyPairAdvanced authenticationPrivate , string account) :


            // we do have to include the account address here!!!

                base(authenticationPrivate, account) {
            //authenticationPrivate.AssertNotNull(NYI.Throw);
            //account.AssertNotNull(NYI.Throw);


            }
        #endregion
        #region Implement ICredential

        public MeshKeyCredentialPublic GetMeshKeyCredentialPublic() =>
            new MeshKeyCredentialPublic(
            AuthenticationPrivate.KeyPairPublic() as KeyPairAdvanced) {
                Account = Account
                };


        ///<inheritdoc/>
        public override ICredentialPublic GetCredentials(List<PacketExtension> extensions) {

            ConnectionService connectionDevice = null;
            ConnectionAddress connectionAddress = null;
            ProfileDevice profileDevice = null;
            KeyPairAdvanced keyAuthentication = null;
            string account = null;
            KeyPairAdvanced keyDirect = null;

            foreach (var extension in extensions) {
                switch (extension.Tag) {
                    case Constants.ExtensionTagsDirectX25519Tag: {
                        keyDirect = new KeyPairX25519(extension.Value);
                        break;
                        }
                    case Constants.ExtensionTagsDirectX448Tag: {
                        keyDirect = new KeyPairX448(extension.Value);
                        break;
                        }
                    case Constants.ExtensionTagsClaimIdTag: {
                        account = extension.Value.ToUTF8();
                        break;
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

            if (keyDirect != null) {
                return new MeshKeyCredentialPublic(keyDirect) {
                    Account = account
                    };

                }
            else {


                return new MeshCredentialPublic(profileDevice, connectionDevice, connectionAddress, keyAuthentication);
                }
            }

        #endregion
        }

    }
