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
        public MeshKeyCredentialPrivate(KeyPairAdvanced authenticationPrivate) :
            base(authenticationPrivate) {
            }
        #endregion
        #region Implement ICredential

        ///<inheritdoc/>
        public ICredentialPublic GetCredentials(List<PacketExtension> extensions) {

            ConnectionService connectionDevice = null;
            ConnectionAddress connectionAddress = null;
            ProfileDevice profileDevice = null;
            KeyPairAdvanced keyAuthentication = null;

            foreach (var extension in extensions) {
                switch (extension.Tag) {
                    case Constants.ExtensionTagsDirectX25519Tag: {
                        return new KeyCredentialPublic(new KeyPairX25519(extension.Value));
                        }
                    case Constants.ExtensionTagsDirectX448Tag: {
                        return new KeyCredentialPublic(new KeyPairX448(extension.Value));
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

        #endregion
        }

    }
