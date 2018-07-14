//   Copyright © 2015 by Comodo Group Inc.
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

using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    public partial class ApplicationProfile : Profile {

        /// <summary>
        /// The personal profile to which this is attached.
        /// </summary>
        public PersonalProfile PersonalProfile;

        /// <summary>
        /// This application profile's entry in the parent personal profile.
        /// </summary>
        public ApplicationProfileEntry ApplicationProfileEntry;

        /// <summary>
        /// The corresponding signed profile.
        /// </summary>
        public SignedApplicationProfile SignedApplicationProfile {
            get {
                if (_SignedApplicationProfile == null) {
                    Sign();
                    }
                return _SignedApplicationProfile;
                }
            set => _SignedApplicationProfile = value;
            }

        SignedApplicationProfile _SignedApplicationProfile;


        /// <summary>
        /// The public data corresponding to the current device.
        /// </summary>
        public ApplicationDevicePublic ApplicationDevicePublic {
            get {
                _ApplicationDevicePublic = _ApplicationDevicePublic ?? GetDevicePublic();
                return _ApplicationDevicePublic;
                }
            }
        ApplicationDevicePublic _ApplicationDevicePublic;

        /// <summary>
        /// The decrypted private data corresponding to the current device.
        /// </summary>
        public ApplicationDevicePrivate ApplicationDevicePrivate {
            get {
                _ApplicationDevicePrivate = _ApplicationDevicePrivate ?? GetDevicePrivate();
                return _ApplicationDevicePrivate;
                }

            }
        ApplicationDevicePrivate _ApplicationDevicePrivate;


        /// <summary>
        /// The decrypted private data corresponding to the current device.
        /// </summary>
        public ApplicationProfilePrivate ApplicationProfilePrivate {
            get {
                _ApplicationProfilePrivate = _ApplicationProfilePrivate ?? GetProfilePrivate();
                return _ApplicationProfilePrivate;
                }
            set => _ApplicationProfilePrivate = value;
            }
        ApplicationProfilePrivate _ApplicationProfilePrivate;


        void ClearSignature() => _SignedApplicationProfile = null;


        /// <summary>
        /// Return the private data of this profile as raw data bytes.
        /// </summary>
        protected virtual byte[] GetPrivateData => ApplicationProfilePrivate?.GetJson (Tagged:true);



        /// <summary>
        /// Protected initializer
        /// </summary>
        public ApplicationProfile() => Identifier = Goedel.Cryptography.UDF.Random();


        /// <summary>
        /// Locate a signature key known to this device that 
        /// is authorized to sign this profile.
        /// </summary>
        /// <returns>An authorized key pair.</returns>
        public KeyPair GetSignatureKey() {
            Assert.NotNull(ApplicationProfileEntry, MeshException.Throw);
            if (ApplicationProfileEntry.AdminDeviceUDF == null) {
                return null;
                }
            foreach (var SignID in ApplicationProfileEntry.AdminDeviceUDF) {
                var SignKey = KeyPair.FindLocal(SignID);
                if (SignKey != null) {
                    return SignKey;
                    }
                }
            return null;
            }



        /// <summary>
        /// Encrypt the private data and create a decryption key for each device.
        /// </summary>
        public virtual void EncryptPrivate() {
            Assert.NotNull(ApplicationProfileEntry, MeshException.Throw);
            Assert.NotNull(ApplicationProfileEntry.DecryptDeviceUDF, MeshException.Throw);

            var PrivateData = GetPrivateData;
            if (PrivateData == null) {
                return;
                }

            SharedPrivate = new JoseWebEncryption(PrivateData);

            foreach (var Recipient in ApplicationProfileEntry.DecryptDeviceUDF) {
                // extract the device profile from the personal profile
                var SignedDeviceProfile = PersonalProfile.GetDeviceProfile(Recipient);
                var DeviceProfile = SignedDeviceProfile.DeviceProfile;
                var EncryptionKey = DeviceProfile.DeviceEncryptiontionKey;

                // create a recipient entry

                SharedPrivate.AddRecipient(EncryptionKey.KeyPair);
                }
            //Trace.NYI("Add entry here for the escrow key for this application");
            }


        /// <summary>
        /// Decrypt the common private data portion of the profile.
        /// </summary>
        /// <returns>Decrypted bytes.</returns>
        public virtual ApplicationProfilePrivate GetProfilePrivate () {
            if (SharedPrivate == null) {
                return null;
                }

            var Key = SharedPrivate.GetKey();
            Assert.NotNull(Key, MeshException.Throw);
            var Result = SharedPrivate.Decrypt(Key);



            return ApplicationProfilePrivate.FromJSON(new JSONReader(Result));
            }

        /// <summary>
        /// Locate and decrypt the private device data for the current device.
        /// </summary>
        /// <returns>Decrypted bytes.</returns>
        public virtual ApplicationDevicePrivate GetDevicePrivate () {
            var Found = DevicePrivate.GetKey(out var Key, out var JWE);
            if (!Found) {
                return null;
                }
            Assert.NotNull(Key, MeshException.Throw);
            var Data = JWE.Decrypt(Key);

            return ApplicationDevicePrivate.FromJSON(new JSONReader(Data));
            }


        /// <summary>
        /// Locate the public device data for the current device.
        /// </summary>
        /// <returns>Public device data for the current device</returns>
        public virtual ApplicationDevicePublic GetDevicePublic () {
            foreach (var Device in Devices) {
                if (Device.DeviceUDF == PersonalProfile.DeviceProfile.UDF) {
                    return Device;
                    }
                }
            return null;
            }


        /// <summary>
        /// Generate a public key pair for use in an application bound to a specific device, 
        /// using co-generation if supported by the device.
        /// </summary>
        /// <param name="KeyType">The cryptographic usage the key is intended for.</param>
        /// <param name="CryptoAlgorithmID">The Cryptographic algorithm to use.</param>
        /// <param name="DeviceProfile">The device to generate the key for.</param>
        /// <param name="Public">The public key</param>
        /// <param name="Private">The private key or key contribution.</param>
        /// <returns>The public key pair. Note that if co-generation is used, this may differ from the public key.</returns>
        public PublicKey MakeApplicationKeyPair (KeyType KeyType, CryptoAlgorithmID CryptoAlgorithmID,
                    DeviceProfile DeviceProfile, out PublicKey Public, out PublicKey Private) {
            //NYI: Should check to see if the device key supports co-generation and use it if so.
            var KeyPair = PublicKey.Generate(KeyType, CryptoAlgorithmID);
            Public = new PublicKey() { PublicParameters = KeyPair.PublicParameters };
            Private = new PublicKey() { PrivateParameters = KeyPair.PrivateParameters };
            return KeyPair;
            }


        /// <summary>
        /// Create a private keypair for a specific device using co-generation if supported by the device.
        /// </summary>
        /// <param name="KeyPair">The contributed key pair.</param>
        /// <param name="DeviceProfile">The device profile of the base device.</param>
        /// <returns>The created key</returns>
        public PublicKey MakeDevicePrivateKey (PublicKey KeyPair, DeviceProfile DeviceProfile) {
            var Private = KeyPair?.PrivateKey?.PKIXPrivateKey;
            var JKey = Key.Factory(Private);

            return new PublicKey() { PrivateParameters = JKey };
            }


        /// <summary>
        /// Add the specified device to the linked personal profile and 
        /// create any device specific entries in the private profile.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        /// <param name="Administration">If true, enroll as an administration device.</param>
        /// <param name="ApplicationDevicePublic">Per device public data,  if required.</param>
        public virtual void AddDevice(
                DeviceProfile Device,
                bool Administration = false,
                ApplicationDevicePublic ApplicationDevicePublic = null) => Assert.NYI("Should never happen. Make this abstract"); // Implement abstract types in protogen



        ///// <summary>
        ///// Create the public (and private) profiles for a device. This may be called by either
        ///// the administrator or on the device itself, depending on when the application is being
        ///// initialized.
        ///// </summary>
        ///// <param name="Device">The profile of the device to initialize</param>
        ///// <param name="ApplicationDevicePrivate"></param>
        ///// <returns></returns>
        //public virtual ApplicationDevicePublic CreateDeviceProfiles(DeviceProfile Device,
        //            out ApplicationDevicePrivate ApplicationDevicePrivate) {

        //    ApplicationDevicePrivate = null;
        //    return null;
        //    }

        /// <summary>
        /// Sign the current profile. It is not necessary to specify the signature
        /// key because the only valid signature key for a device profile is the
        /// one identified by the UDF of the profile.
        /// </summary>
        /// <param name="UDF">Specify the signature key by identifier</param>
        /// <param name="KeyPair">Specify the signature key by key handle</param>
        /// <param name="Encoding">The encoding for the inner data</param>
        /// <returns>The signed profile.</returns>
        public override SignedProfile Sign (string UDF = null, KeyPair KeyPair = null,
                        DataEncoding Encoding = DataEncoding.JSON) {
            this.SignedApplicationProfile = new SignedApplicationProfile(this);
            return SignedApplicationProfile;
            }


        }

    }
