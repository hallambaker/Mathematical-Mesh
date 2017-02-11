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
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Persistence;
using Goedel.Protocol;
using Goedel.IO;
using Goedel.Utilities;

namespace Goedel.Mesh {

    public partial class SignedProfile {


        /// <summary>
        /// The profile that was signed.
        /// </summary>
        public virtual Profile Profile {
            get { return null; }
            }

        /// <summary>
        /// Pass the UDF identifier of the inner profile if it is defined.
        /// </summary>
        public virtual string UDF {
            get { return Profile != null ? Profile.UDF : null; }
            }

        /// <summary>
        /// the list of index terms.
        /// </summary>
        public virtual List<IndexTerm> IndexTerms {
            get { return Profile != null ? Profile.IndexTerms : null; }
            }

        /// <summary>
        /// The unique identifier for the profile.
        /// </summary>
        public virtual string UniqueID {
            get { return Profile != null ? Profile.UniqueID : null; }
            }


        /// <summary>
        /// Validate this profile to check that it is internally consistent.
        /// </summary>
        /// <returns>True if the profile passed validation, otherwise false.</returns>
        public virtual bool Validate() {

            throw new NYI("Need to validate the profile");

            }

        /// <summary>
        /// Deserialize the signed data.
        /// </summary>
        /// <returns>The device profile object.</returns>
        public virtual Profile Unpack() {
            throw new NYI("Need to unpack the profile");
            }

        }

    public partial class SignedDeviceProfile {

        /// <summary>
        /// The inner profile object.
        /// </summary>
        public override Profile Profile {
            get { return DeviceProfile; }
            }

        /// <summary>
        /// Gets the inner signed data;
        /// </summary>
        public DeviceProfile DeviceProfile {
            get {
                _Signed = _Signed ?? UnpackDeviceProfile();
                return _Signed;
                }
            }
        DeviceProfile _Signed;

        /// <summary>
        /// Construct a signed profile from a device profile.
        /// </summary>
        /// <param name="Data">The device profile to sign.</param>
        public SignedDeviceProfile(DeviceProfile Data) {
            Sign(Data);
            }

        /// <summary>
        /// Create a new device profile
        /// </summary>
        /// <param name="Name">Name of the device</param>
        /// <param name="Description">Description of the device.</param>
        public SignedDeviceProfile(string Name, string Description) {
            var Data = new DeviceProfile(Name, Description, SignedDeviceProfile: this);
            Sign(Data);
            }


        /// <summary>
        /// Sign the device profile.
        /// </summary>
        /// <param name="Data">The device profile to sign.</param>
        public void Sign(DeviceProfile Data) {
            Identifier = Data.Identifier;  // pass through
            var PrivateKey = Data.DeviceSignatureKey.PrivateKey;
            SignedData = new JoseWebSignature(Data.GetBytes(), PrivateKey);
            _Signed = Data;
            }

        /// <summary>
        /// Deserialize the signed data.
        /// </summary>
        /// <returns>The device profile object.</returns>
        public override Profile Unpack() {
            return UnpackDeviceProfile();
            }



        /// <summary>
        /// Unpack the signed device profile data and verify it for
        /// consistency. Check the signature.
        /// </summary>
        /// <returns>The inner profile (if valid) otherwise null.</returns>
        public virtual DeviceProfile UnpackDeviceProfile() {
            _Signed = null;

            var Profile = DeviceProfile.FromTagged(SignedData.Payload);
            Assert.True(Profile.DeviceSignatureKey.Verify(), KeyFingerprintMismatch.Throw);

            var PublicKey = Profile.DeviceSignatureKey.KeyPair;
            Assert.NotNull(PublicKey, PublicKeyNotFound.Throw);
            Assert.True(SignedData.Verify(Profile.UDF, PublicKey), InvalidProfileSignature.Throw);

            Profile.SignedDeviceProfile = this;

            _Signed = Profile;
            return _Signed;
            }

        /// <summary>
        /// Find a device profile with the specified signing key from a list.
        /// </summary>
        /// <param name="Devices">The list of devices to search.</param>
        /// <param name="UDF">The identifier of the key to find.</param>
        /// <returns>The profile of the device (if found) otherwise null.</returns>
        public static SignedDeviceProfile FindSignatureKey(List<SignedDeviceProfile> Devices, string UDF) {
            foreach (var Device in Devices) {
                if (Device.DeviceProfile.DeviceSignatureKey.UDF == UDF) {
                    if (Device.DeviceProfile.DeviceSignatureKey.Verify()) {
                        return Device;
                        }
                    }
                }
            return null;
            }

        /// <summary>
        /// Search for the specified profile on the local machine.
        /// </summary>
        /// <param name="UDF">Fingerprint of the profile to find.</param>
        /// <param name="FileName">The name of the file</param>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedDeviceProfile FromFile(string UDF, string FileName) {

            using (var FileReader = FileName.OpenFileReadShared()) {
                using (var TextReader = FileReader.OpenTextReader()) {
                    var Reader = new JSONReader(TextReader);
                    var Result = SignedDeviceProfile.FromTagged(Reader);
                    Result.UnpackDeviceProfile();

                    return Result;
                    }
                }
            }

        }



    public partial class SignedMasterProfile {
        MasterProfile _Signed;
        /// <summary>
        /// The signed profile object.
        /// </summary>
        public override Profile Profile {
            get { return MasterProfile; }
            }

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public MasterProfile MasterProfile {
            get { if (_Signed == null) _Signed = UnpackMasterProfile(); return _Signed; }
            }

        /// <summary>
        /// Construct a signed profile from the specified profile.
        /// </summary>
        /// <param name="Data">The profile to sign.</param>
        public SignedMasterProfile(MasterProfile Data) {
            Identifier = Data.Identifier;  // pass through
            SignedData = new JoseWebSignature(Data.GetBytes(), Data.MasterSignatureKey.KeyPair);
            _Signed = Data;
            }

        /// <summary>
        /// Unpack the profile.
        /// </summary>
        /// <returns></returns>
        public override Profile Unpack() {
            return UnpackMasterProfile(); 
            }

        /// <summary>
        /// Unpack the signed data and verify its consistency.
        /// </summary>
        /// <returns>The corresponding master profile if validation is successful,
        /// otherwise null.</returns>
        public virtual MasterProfile UnpackMasterProfile() {

            var Text = Encoding.UTF8.GetString(SignedData.Payload);
            //Goedel.Debug.Trace.WriteLine("Data as signed {0}", Text);

            var Unpacked = MasterProfile.FromTagged(Text);

            var SigningKey = Unpacked.MasterSignatureKey.KeyPair;
            var Verify = SignedData.Verify(Unpacked.MasterSignatureKey.UDF, SigningKey);
            Assert.True(Verify, InvalidProfileChain.Throw);

            Unpacked.Unpack();

            Unpacked.SignedMasterProfile = this;

            _Signed = Unpacked;
            return Unpacked;
            }
        }

    public partial class SignedApplicationProfile {
        ApplicationProfile _Signed = null;
        /// <summary>
        /// The signed profile object.
        /// </summary>
        public override Profile Profile {
            get { return ApplicationProfile; }
            }
        /// <summary>
        /// The signed profile object.
        /// </summary>
        public ApplicationProfile ApplicationProfile {
            get { if (_Signed == null) _Signed = UnpackAndVerify(); return _Signed; }
            }

        /// <summary>
        /// Construct a signed profile from the specified profile.
        /// </summary>
        /// <param name="Data">The profile to sign.</param>
        public SignedApplicationProfile(ApplicationProfile Data) {

            // Locate the administration key for this device.
            var AdminKey = Data.GetSignatureKey();

            Assert.NotNull(AdminKey, NotAdministrationDevice.Throw);

            // Make sure all the data is properly registered
            Data.EncryptPrivate();
            Identifier = Data.Identifier;

            //Goedel.Debug.Trace.WriteLine("Data to be signed {0}", Data.ToString());

            SignedData = new JoseWebSignature(Data.GetBytes(), AdminKey);
            _Signed = Data;
            }

        /// <summary>
        /// Unpack the signed data and verify its consistency.
        /// </summary>
        /// <returns>The corresponding master profile if validation is successful,
        /// otherwise null.</returns>
        public virtual ApplicationProfile UnpackAndVerify() {

            // Get the signature key

            // Get this application entry from the personal profile

            // check the signature key is included in SignID for this application

            // abort if fail


            // unpack the data

            var Result = ApplicationProfile.FromTagged(SignedData.Payload);


            return Result;
            }

        /// <summary>
        /// Search for the specified profile on the local machine.
        /// </summary>
        /// <param name="UDF">Fingerprint of the profile to find.</param>
        /// <param name="FileName">The name of the file</param>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedApplicationProfile FromFile(string UDF, string FileName) {

            using (var FileReader = FileName.OpenFileReadShared()) {
                using (var TextReader = FileReader.OpenTextReader()) {
                    var Reader = new JSONReader(TextReader);
                    var Result = SignedApplicationProfile.FromTagged(Reader);

                    return Result;
                    }
                }
            }

        }



    /// <summary>
    /// Personal profile signed with a valid administration key
    /// </summary>
    public partial class SignedPersonalProfile {

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public override Profile Profile {
            get { return _Signed; }
            }

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public PersonalProfile PersonalProfile {
            get { if (_Signed == null) _Signed = UnpackPersonalProfile(); return _Signed; }
            }
        PersonalProfile _Signed = null;

        /// <summary>
        /// Create from a current personal profile.
        /// </summary>
        /// <param name="Data">The current profile to sign</param>
        /// <param name="AdminKey">The administration key to use for signing.</param>
        /// <exception cref="Exception">The administration key could not be found.</exception>
        public SignedPersonalProfile(PersonalProfile Data, KeyPair AdminKey) {

            // Make sure all the data is properly registered
            Data.Package();
            Identifier = Data.Identifier;
            SignedData = new JoseWebSignature(Data.GetBytes(), AdminKey);
            _Signed = Data;
            }





        /// <summary>
        /// Search for the specified profile on the local machine.
        /// </summary>
        /// <param name="UDF">Fingerprint of the profile to find.</param>
        /// <param name="FileName">The name of the file</param>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedPersonalProfile FromFile(string UDF, string FileName) {
            try {
                using (var FileReader = FileName.OpenFileReadShared()) {
                    using (var TextReader = FileReader.OpenTextReader()) {
                        var Reader = new JSONReader(TextReader);
                        var Result = SignedPersonalProfile.FromTagged(Reader);

                        var Test = Result.PersonalProfile.UDF;
                        Goedel.Cryptography.UDF.Validate(UDF, Test);

                        return Result;
                        }
                    }
                }
            catch {
                return null;
                }
            }

        /// <summary>
        /// Unpack the SignedData structure and verify that the components 
        /// are all valid.
        /// <para>The Personal Master is signed with the PMSK.</para>
        /// <para>The Administration profile is signed with the POSK.</para>
        /// <para>The Personal profile is signed with a valid admin key.</para>
        /// <para>Each signing key matches the specified UDF.</para>
        /// </summary>
        /// <returns></returns>
        public virtual PersonalProfile UnpackPersonalProfile() {
            var Unpacked = PersonalProfile.FromTagged (SignedData.Payload);

            Unpacked.Unpack();
            Validate(Unpacked);

            Unpacked.SignedPersonalProfile = this;
            _Signed = Unpacked;
            return Unpacked;
            }

        private void Validate(PersonalProfile Unpacked) {

            // Get the master profile (force Master profile validation)
            var MasterProfile = Unpacked.MasterProfile;

            // Check this is the correct Master profile
            Assert.True (MasterProfile.UDF == Unpacked.UDF, FingerprintMatchFailed.Throw);

            
            foreach (var Signature in SignedData.Signatures) {
                var KeyID = Signature.Header.kid;
                var AdminKey = MasterProfile.AdministrationKeyPair(Signature.Header.kid);

                // Check that this is a valid admin key
                Assert.NotNull(AdminKey, InvalidProfileSignature.Throw);

                // Check the signature
                var Verify = SignedData.Verify(KeyID, AdminKey);
                Assert.True(Verify, InvalidProfileSignature.Throw);
                }

            }


        }
    }
