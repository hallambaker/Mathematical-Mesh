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
        public virtual Profile Profile => null;

        /// <summary>
        /// Pass the UDF identifier of the inner profile if it is defined.
        /// </summary>
        public virtual string UDF => Profile?.UDF;

        /// <summary>
        /// the list of index terms.
        /// </summary>
        public virtual List<IndexTerm> IndexTerms => Profile?.IndexTerms;

        /// <summary>
        /// The unique identifier for the profile.
        /// </summary>
        public virtual string UniqueID => Profile?.UniqueID;


        public override string _PrimaryKey => UniqueID;

        public override List<KeyValuePair<string, string>> _KeyValues => IndexTerms?.ToKeyValuePairs();


        /// <summary>
        /// Validate this profile to check that it is internally consistent.
        /// </summary>
        /// <returns>True if the profile passed validation, otherwise false.</returns>
        public virtual bool Validate() {

            throw new Goedel.Utilities.NYI("Need to validate the profile");

            }

        /// <summary>
        /// Deserialize the signed data.
        /// </summary>
        /// <returns>The device profile object.</returns>
        public virtual Profile Unpack() {
            throw new Goedel.Utilities.NYI("Need to unpack the profile");
            }

        }

    public partial class SignedDeviceProfile {

        /// <summary>
        /// The inner profile object.
        /// </summary>
        public override Profile Profile => DeviceProfile;

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
        /// Default Constructor
        /// </summary>
        public SignedDeviceProfile () { }


        /// <summary>
        /// Construct a signed profile from a device profile.
        /// </summary>
        /// <param name="DeviceProfile">The device profile to sign.</param>
        /// <param name="Encoding">The encoding for the inner data</param>
        public SignedDeviceProfile (DeviceProfile DeviceProfile, 
                    DataEncoding Encoding = DataEncoding.JSON) {
            Sign(DeviceProfile, Encoding);
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
        /// <param name="DeviceProfile">The device profile to sign.</param>
        /// <param name="Encoding">The encoding for the inner data</param>
        public void Sign(DeviceProfile DeviceProfile, 
                    DataEncoding Encoding = DataEncoding.JSON) {
            Identifier = DeviceProfile.Identifier;  // pass through
            var PrivateKey = DeviceProfile.DeviceSignatureKey.PrivateKey;
            SignedData = new JoseWebSignature(DeviceProfile, Encoding, PrivateKey);
            _Signed = DeviceProfile;
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

            var Profile = DeviceProfile.FromJSON(new JSONReader (SignedData.Payload));
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
        /// <param name="FileName">The name of the file</param>
        /// <param name="UDF">Fingerprint of the profile to find.</param>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedDeviceProfile FromFile (string FileName, string UDF) {

            using (var FileReader = FileName.OpenFileReadShared()) {
                using (var TextReader = FileReader.OpenTextReader()) {
                    var Reader = new JSONReader(TextReader);
                    var Result = FromJSON(Reader);
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
        public override Profile Profile => MasterProfile;

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public MasterProfile MasterProfile {
            get { _Signed = _Signed ?? UnpackMasterProfile(); return _Signed; }
            }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SignedMasterProfile () { }

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
        /// <returns>The unpacked profile.</returns>
        public override Profile Unpack() {
            return UnpackMasterProfile(); 
            }

        /// <summary>
        /// Unpack the signed data and verify its consistency.
        /// </summary>
        /// <returns>The corresponding master profile if validation is successful,
        /// otherwise null.</returns>
        public virtual MasterProfile UnpackMasterProfile() {

            var Text = System.Text.Encoding.UTF8.GetString(SignedData.Payload);
            //Goedel.Debug.Trace.WriteLine("Data as signed {0}", Text);

            var Unpacked = MasterProfile.FromJSON(new JSONReader(Text));

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

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public override Profile Profile => ApplicationProfile;
        /// <summary>
        /// The signed profile object.
        /// </summary>
        public ApplicationProfile ApplicationProfile {
            get {
                _ApplicationProfile = _ApplicationProfile?? UnpackAndVerify();
                return _ApplicationProfile;
                }
            }
        ApplicationProfile _ApplicationProfile = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SignedApplicationProfile () { }

        /// <summary>
        /// Construct a signed profile from the specified profile.
        /// </summary>
        /// <param name="Encoding">The encoding for the inner data</param>
        /// <param name="Data">The profile to sign.</param>
        public SignedApplicationProfile (ApplicationProfile Data, 
                    DataEncoding Encoding = DataEncoding.JSON) {
            _ApplicationProfile = Data;
            Sign(Encoding: Encoding);
            }

        /// <summary>
        /// Package and sign the 
        /// </summary>
        /// <param name="SigningKey">The signature key</param>
        /// <param name="Encoding">The encoding</param>
        public void Sign (KeyPair SigningKey=null, DataEncoding Encoding = DataEncoding.JSON) {
            SigningKey = SigningKey ?? ApplicationProfile.GetSignatureKey();
            Assert.NotNull(SigningKey, NotAdministrationDevice.Throw);

            ApplicationProfile.EncryptPrivate();
            Identifier = ApplicationProfile.Identifier;

            SignedData = new JoseWebSignature(ApplicationProfile, Encoding, SigningKey);
            }

        /// <summary>
        /// Unpack the signed data and verify its consistency.
        /// </summary>
        /// <returns>The corresponding master profile if validation is successful,
        /// otherwise null.</returns>
        public virtual ApplicationProfile UnpackAndVerify() {
            // NYI check signature chain.

            var Result = ReadProfile(SignedData.Payload);
            Result.SignedApplicationProfile = this;

            return Result;
            }


        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="Data">The input stream</param>
        /// <returns>The created object.</returns>		
        public static ApplicationProfile ReadProfile (byte[] Data) {
            var Reader = Data.JSONReader();

            Deserialize(Reader, out var Result);
            return Result as ApplicationProfile;



            }





        /// <summary>
        /// Search for the specified profile on the local machine.
        /// </summary>
        /// <param name="FileName">The name of the file</param>
        /// <param name="UDF">Fingerprint of the profile to find.</param>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedApplicationProfile FromFile (string FileName, string UDF=null) {
            try {
                using (var FileReader = FileName.OpenFileReadShared()) {
                    using (var TextReader = FileReader.OpenTextReader()) {
                        var Reader = new JSONReader(TextReader);
                        var Result = FromJSON(Reader, true);
                        return Result;
                        }
                    }
                }
            catch {
                return null;
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
        public override Profile Profile => _Signed;

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public PersonalProfile PersonalProfile {
            get { _Signed = _Signed ?? UnpackPersonalProfile(); return _Signed; }
            }
        PersonalProfile _Signed = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SignedPersonalProfile () { }

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
        /// <param name="FileName">The name of the file</param>
        /// <param name="UDF">Fingerprint of the profile to find.</param>
        /// <returns>The signed profile if found or null otherwise.</returns>
        public static SignedPersonalProfile FromFile (string FileName, string UDF=null) {
            try {
                using (var FileReader = FileName.OpenFileReadShared()) {
                    using (var TextReader = FileReader.OpenTextReader()) {
                        var Reader = new JSONReader(TextReader);
                        var Result = SignedPersonalProfile.FromJSON(Reader);

                        if (UDF != null) {
                            var Test = Result.PersonalProfile.UDF;
                            Goedel.Cryptography.UDF.Validate(UDF, Test);
                            }
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
        /// <returns>The unpacked personal profile.</returns>
        public virtual PersonalProfile UnpackPersonalProfile() {
            var Unpacked = PersonalProfile.FromJSON(new JSONReader(SignedData.Payload));

            Unpacked.Unpack();
            Validate(Unpacked);

            Unpacked.SignedPersonalProfile = this;
            _Signed = Unpacked;
            return Unpacked;
            }


        /// <summary>
        /// Validate this profile to check that it is internally consistent.
        /// </summary>
        /// <returns>True if the profile passed validation, otherwise false.</returns>
        public override bool Validate() {

            return true; // Hack: Must implemenmt this.

            }


        private void Validate(PersonalProfile Unpacked) {

            // Get the master profile (force Master profile validation)
            var MasterProfile = Unpacked.MasterProfile;

            // Check this is the correct Master profile
            Assert.True (MasterProfile.UDF == Unpacked.UDF, FingerprintMatchFailed.Throw);

            
            foreach (var Signature in SignedData.Signatures) {
                var KeyID = Signature.Header.Kid;
                var AdminKey = MasterProfile.AdministrationKeyPair(Signature.Header.Kid);

                // Check that this is a valid admin key
                Assert.NotNull(AdminKey, InvalidProfileSignature.Throw);

                // Check the signature
                var Verify = SignedData.Verify(KeyID, AdminKey);
                Assert.True(Verify, InvalidProfileSignature.Throw);
                }

            }


        }
    }
