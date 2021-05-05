//  Copyright © 2020 Threshold Secrets llc
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

    public partial class ActivationDevice {
        #region // Properties
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ActivationDevice> EnvelopedActivationDevice =>
            envelopedActivationDevice ?? new Enveloped<ActivationDevice>(DareEnvelope).
                    CacheValue(out envelopedActivationDevice);
        Enveloped<ActivationDevice> envelopedActivationDevice;

        ///<summary>The connection value.</summary>
        public override Connection Connection => ConnectionUser;

        ///<summary>The <see cref="ConnectionUser"/> instance binding the activated device
        ///to a MeshProfile.</summary>
        public ConnectionDevice ConnectionUser { get; set; }





        // Properties giving access to device specific keys

        ///<summary>The device signature key for use under the profile</summary>
        public KeyPair DeviceSignature { get; private set; }

        ///<summary>The device encryption key for use under the profile</summary>
        public KeyPair DeviceEncryption { get; private set; }

        ///<summary>The device authentication key for use under the profile</summary>
        public KeyPair DeviceAuthentication { get; private set; }

        ///<inheritdoc/>
        public virtual MeshActor MeshActor => MeshActor.Device;


        MeshCredentialPrivate MeshCredentialPrivate => meshCredentialPrivate ??
            new MeshCredentialPrivate(this);
        MeshCredentialPrivate meshCredentialPrivate;


        #endregion
        #region // Constructors

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ActivationDevice() {
            }

        /// <summary>
        /// Construct a new <see cref="ActivationDevice"/> instance for the profile
        /// <paramref name="profileDevice"/>.
        /// If the value <paramref name="masterSecret"/> is
        /// specified, it is used as the seed value. Otherwise, a seed value of
        /// length <paramref name="bits"/> is generated.
        /// The public key value is calculated for the public key pairs and the corresponding
        /// <see cref="ConnectionUser"/> generated for the public values.
        /// </summary>
        /// <param name="profileDevice">The base profile that the activation activates.</param>
        /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
        /// a seed value of <paramref name="bits"/> length is generated.</param>
        /// <param name="bits">The size of the seed to be generated if <paramref name="masterSecret"/>
        /// is null.</param>
        public ActivationDevice(
                    ProfileDevice profileDevice,
                    byte[] masterSecret = null,
                    int bits = 256) : base(
                        profileDevice, UdfAlgorithmIdentifier.MeshActivationAccount, masterSecret, bits) {
            ProfileDevice = profileDevice;

            AccountUdf = profileDevice.Udf;

            var deviceEncryption = ActivationSeed.ActivatePublic(
                    profileDevice.Encryption.GetKeyPairAdvanced(), 
                            MeshActor, MeshKeyOperation.Encrypt);
            var deviceSignature = ActivationSeed.ActivatePublic(
                    profileDevice.Signature.GetKeyPairAdvanced(), 
                            MeshActor, MeshKeyOperation.Sign);
            var deviceAuthentication = ActivationSeed.ActivatePublic(
                    profileDevice.Authentication.GetKeyPairAdvanced(), 
                            MeshActor, MeshKeyOperation.Authenticate);

            // Create the (unsigned) ConnectionUser
            ConnectionUser = new ConnectionDevice() {
                Encryption = new KeyData(deviceEncryption),
                Signature = new KeyData(deviceSignature),
                Authentication = new KeyData(deviceAuthentication)
                };
            }

        #endregion

        #region // Methods
        /// <summary>
        /// Activate the keys bound to this activation record using keys derived from 
        /// <paramref name="deviceKeySeed"/>.
        /// </summary>
        /// <param name="deviceKeySeed">Generator for the private key contributions.</param>
        public void Activate(
                PrivateKeyUDF deviceKeySeed) {
            ActivationSeed = new PrivateKeyUDF(ActivationKey);
            DeviceEncryption = ActivationSeed.ActivatePrivate(
                deviceKeySeed, MeshActor, MeshKeyOperation.Encrypt);
            DeviceSignature = ActivationSeed.ActivatePrivate(
                deviceKeySeed, MeshActor, MeshKeyOperation.Sign);
            DeviceAuthentication = ActivationSeed.ActivatePrivate(
                deviceKeySeed, MeshActor, MeshKeyOperation.Authenticate);

            }

        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The key collection 
        /// <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The Key collection.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Activation Account");
            indent++;
            DareEnvelope.Report(builder, indent);
            //indent++;
            //builder.AppendIndent(indent, $"KeySignature:     {ProfileSignature} ");
            }

        #endregion
        }

    }
