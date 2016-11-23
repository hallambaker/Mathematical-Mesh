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
using System.Text;
using Goedel.Registry;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    public partial class ApplicationProfile : Profile {

        /// <summary>
        /// The personal profile to which this is attached.
        /// </summary>
        protected PersonalProfile PersonalProfile;

        /// <summary>
        /// This application profile's entry in the parent personal profile.
        /// </summary>
        protected ApplicationProfileEntry ApplicationProfileEntry;

        /// <summary>
        /// Return a signed version of this profile.
        /// </summary>
        public SignedApplicationProfile Signed {
            get {
                return new SignedApplicationProfile(this);
                }
            }

        /// <summary>
        /// Return the private data of this profile as raw data bytes.
        /// </summary>
        protected virtual byte[] GetPrivateData {
            get { return null; }
            }


        /// <summary>
        /// Protected initializer
        /// </summary>
        protected override void _Initialize() {
            Identifier = Goedel.Cryptography.UDF.Random();
            }


        ///// <summary>
        ///// Create a new application profile and add it to the UserProfile.
        ///// </summary>
        ///// <param name="PersonalProfile">The personal profile to attach to.</param>
        ///// <param name="Type">Application type</param>
        ///// <param name="Tag">Friendly name</param>
        //public ApplicationProfile(PersonalProfile PersonalProfile,
        //            string Type, string Tag) {
        //    this.PersonalProfile = PersonalProfile;

        //    Identifier = Goedel.Cryptography.UDF.Random();


        //    }


        /// <summary>
        /// Connect an application profile read from store to a PersonalProfile object.
        /// </summary>
        /// <param name="PersonalProfile">Personal profile to link</param>
        public void Link(PersonalProfile PersonalProfile) {


            ApplicationProfileEntry = PersonalProfile.GetApplicationEntry(Identifier);
            Assert.NotNull(ApplicationProfileEntry, ProfileNotFound.Throw);

            Link(PersonalProfile, ApplicationProfileEntry);
            ApplicationProfileEntry.ApplicationProfile = this;
            }

        /// <summary>
        /// Connect an application profile read from store to a PersonalProfile object.
        /// </summary>
        /// <param name="PersonalProfile">Personal profile to link</param>
        /// <param name="ApplicationProfileEntry">Profile entry to link to</param>
        public void Link(PersonalProfile PersonalProfile, 
                    ApplicationProfileEntry ApplicationProfileEntry) {
            this.PersonalProfile = PersonalProfile;
            this.ApplicationProfileEntry = ApplicationProfileEntry;
            ApplicationProfileEntry.ApplicationProfile = this;
            }


        /// <summary>
        /// Locate a signature key known to this device that 
        /// is authorized to sign this profile.
        /// </summary>
        /// <returns>An authorized key pair.</returns>
        public KeyPair GetSignatureKey() {
            Assert.NotNull(ApplicationProfileEntry, MeshException.Throw);
            foreach (var SignID in ApplicationProfileEntry.SignID) {
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
            Assert.NotNull(ApplicationProfileEntry.DecryptID, MeshException.Throw);

            EncryptedData = new JoseWebEncryption(GetPrivateData);

            foreach (var Recipient in ApplicationProfileEntry.DecryptID) {
                // extract the device profile from the personal profile
                var SignedDeviceProfile = PersonalProfile.GetDeviceProfile(Recipient);
                var DeviceProfile = SignedDeviceProfile.Data;
                var EncryptionKey = DeviceProfile.DeviceEncryptiontionKey;

                // create a recipient entry

                EncryptedData.Add(EncryptionKey.KeyPair);
                }
            //Trace.NYI("Add entry here for the escrow key for this application");
            }


        /// <summary>
        /// Decrypt the private data portion of the profile.
        /// </summary>
        /// <returns>Decrypted bytes.</returns>
        public virtual byte[] DecryptPrivate() {
            var SignedDeviceProfile = PersonalProfile.SignedDeviceProfile;
            var DeviceProfile = SignedDeviceProfile.Data;
            var EncryptionKey = DeviceProfile.DeviceEncryptiontionKey;

            Assert.NotNull(ApplicationProfileEntry, MeshException.Throw);
            Assert.NotNull(ApplicationProfileEntry.DecryptID, MeshException.Throw);

            var Result = EncryptedData.Decrypt(EncryptionKey.KeyPair);

            return Result;
            }


        /// <summary>
        /// Add the specified device to the linked personal profile and 
        /// create any device specific entries in the private profile.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        public virtual void AddDevice(SignedDeviceProfile Device) {
            // Create admin entry for this device

            ApplicationProfileEntry.AddDevice(Device);
            }

        }

    }
