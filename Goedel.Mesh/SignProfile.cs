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
using Goedel.Debug;
using Goedel.Cryptography.Jose;
using Goedel.Persistence;
using Goedel.Protocol;

namespace Goedel.Mesh {

    public partial class SignedProfile {


        /// <summary>
        /// The profile that was signed.
        /// </summary>
        public virtual Profile Inner {
            get { return null; }
            }

        /// <summary>
        /// Pass the UDF identifier of the inner profile if it is defined.
        /// </summary>
        public virtual string UDF {
            get { return Inner != null ? Inner.UDF : null; }
            }

        /// <summary>
        /// the list of index terms.
        /// </summary>
        public virtual List<IndexTerm> IndexTerms {
            get { return Inner != null ? Inner.IndexTerms : null; }
            }

        /// <summary>
        /// The unique identifier for the profile.
        /// </summary>
        public virtual string UniqueID {
            get { return Inner != null ? Inner.UniqueID : null; }
            }


        /// <summary>
        /// Validate this profile to check that it is internally consistent.
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate () {

            Trace.NYI("Need to validate the profile");

            return true;
            }

        }


    public partial class SignedDeviceProfile {

        /// <summary>
        /// The inner profile object.
        /// </summary>
        public override Profile Inner {
            get { return Data; }
            }


        static SignedDeviceProfile _Current = null;

        /// <summary>
        /// The default profile of the current device.
        /// </summary>
        public static SignedDeviceProfile Current {
            get {
                if (_Current == null) {
                    _Current = FromRegistry();
                    }
                return _Current;
                }
            set { _Current = value; }
            }

        DeviceProfile _Signed;


        /// <summary>
        /// Gets the inner signed data;
        /// </summary>
        public DeviceProfile Data {
            get { if (_Signed == null) _Signed = Unpack(); return _Signed; }
            }

        /// <summary>
        /// Construct a signed profile from a device profile.
        /// </summary>
        /// <param name="Data">The device profile to sign.</param>
        public SignedDeviceProfile(DeviceProfile Data) {
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
        public DeviceProfile Unpack() {
            _Signed = null;

            var Reader = JSONReader.OfData(SignedData.Payload);
            var Profile = DeviceProfile.FromTagged(Reader);

            Throw.IfNot(Profile.DeviceSignatureKey.Verify(),
                    "Key fingerprint does not match key value");
            var PublicKey = Profile.DeviceSignatureKey.KeyPair;
            KeyNotFoundException.If(PublicKey == null);

            Throw.IfNot(SignedData.Verify(Profile.UDF, PublicKey), "Signature does not verify");

            _Signed = Profile;
            return _Signed;
            }

        /// <summary>
        /// Create a new device profile and persist it in the registry
        /// as the default profile.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        public SignedDeviceProfile(string Name, string Description) {
            var Data = new DeviceProfile(Name, Description);
            Sign(Data);
            _Current = this;
            }


        /// <summary>
        /// Unpack the signed device profile data and verify it for
        /// consistency. Check the signature.
        /// </summary>
        /// <returns>The inner profile (if valid) otherwise null.</returns>
        public virtual DeviceProfile UnpackAndVerify() {
            var Text = Encoding.UTF8.GetString(SignedData.Payload);
            //Goedel.Debug.Trace.WriteLine("Data as signed {0}", Text);

            var Unpacked = DeviceProfile.FromTagged (Text);

            Unpacked.Unpack();

            var SigningKey = Unpacked.DeviceSignatureKey.KeyPair;
            var Verify = SignedData.Verify(Unpacked.UDF, SigningKey);
            Throw.IfNot(Verify, "Device signature does not verify");


            _Signed = Unpacked;
            return Unpacked;
            }

        /// <summary>
        /// Find a device profile with the specified signing key from a list.
        /// </summary>
        /// <param name="Devices">The list of devices to search.</param>
        /// <param name="UDF">The identifier of the key to find.</param>
        /// <returns>The profile of the device (if found) otherwise null.</returns>
        public static SignedDeviceProfile FindSignatureKey(List<SignedDeviceProfile> Devices, string UDF) {
            foreach (var Device in Devices) {
                if (Device.Data.DeviceSignatureKey.UDF == UDF) {
                    if (Device.Data.DeviceSignatureKey.Verify()) {
                        return Device;
                        }
                    }
                }
            return null;
            }

        }



    public partial class SignedMasterProfile {
        MasterProfile _Signed;
        /// <summary>
        /// The signed profile object.
        /// </summary>
        public override Profile Inner {
            get { return Signed; }
            }

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public MasterProfile Signed {
            get { if (_Signed == null) _Signed = UnpackAndVerify(); return _Signed; }
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
        /// Unpack the signed data and verify its consistency.
        /// </summary>
        /// <returns>The corresponding master profile if validation is successful,
        /// otherwise null.</returns>
        public virtual MasterProfile UnpackAndVerify() {

            var Text = Encoding.UTF8.GetString(SignedData.Payload);
            //Goedel.Debug.Trace.WriteLine("Data as signed {0}", Text);

            var Unpacked = MasterProfile.FromTagged(Text);

            var SigningKey = Unpacked.MasterSignatureKey.KeyPair;
            var Verify = SignedData.Verify(Unpacked.MasterSignatureKey.UDF, SigningKey);
            Throw.IfNot(Verify, "Master signature does not verify");

            Unpacked.Unpack();

            _Signed = Unpacked;
            return Unpacked;
            }
        }

    public partial class SignedApplicationProfile {
        ApplicationProfile _Signed = null;
        /// <summary>
        /// The signed profile object.
        /// </summary>
        public override Profile Inner {
            get { return Signed; }
            }
        /// <summary>
        /// The signed profile object.
        /// </summary>
        public ApplicationProfile Signed {
            get { if (_Signed == null) _Signed = UnpackAndVerify(); return _Signed; }
            }

        /// <summary>
        /// Construct a signed profile from the specified profile.
        /// </summary>
        /// <param name="Data">The profile to sign.</param>
        public SignedApplicationProfile(ApplicationProfile Data) {

            // Locate the administration key for this device.
            var AdminKey = Data.GetSignatureKey();

            Throw.If(AdminKey == null, "Device not authorized for administration.");

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


        }



    /// <summary>
    /// Personal profile signed with a valid administration key
    /// </summary>
    public partial class SignedPersonalProfile {
        PersonalProfile _Signed = null;

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public override Profile Inner {
            get { return _Signed; }
            }

        /// <summary>
        /// The signed profile object.
        /// </summary>
        public PersonalProfile Signed {
            get { if (_Signed == null) _Signed = UnpackAndVerify(); return _Signed; }
            }

        /// <summary>
        /// Create from a current personal profile.
        /// </summary>
        /// <param name="Data">The current profile to sign</param>
        /// <exception cref="Exception">The administration key could not be found.</exception>
        public SignedPersonalProfile(PersonalProfile Data) {

            // Locate the administration key for this device.
            var AdminKey = Data.GetAdministrationKey();

            Throw.If(AdminKey == null, "Device not authorized for administration.");

            // Make sure all the data is properly registered
            Data.Package();
            Identifier = Data.Identifier;

            //Goedel.Debug.Trace.WriteLine("Data to be signed {0}", Data.ToString());

            SignedData = new JoseWebSignature(Data.GetBytes(), AdminKey);
            _Signed = Data;
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
        PersonalProfile UnpackAndVerify() {

            var Text = Encoding.UTF8.GetString(SignedData.Payload);
            //Goedel.Debug.Trace.WriteLine("Data as signed {0}", Text);

            var Unpacked = PersonalProfile.FromTagged (Text);

            Unpacked.Unpack();

            CheckSignedPOSK(Unpacked);
            //CheckSignedAdmin(Unpacked);
            // Check the signature on the profile

            _Signed = Unpacked;
            return Unpacked;
            }

        //private void CheckSignedAdmin(PersonalProfile Unpacked) {

        //    // Get the UDF of the signing key.
        //    var SignatureKeyUDF = SignedData.ParsedHeader.kid;

        //    // Get the corresponding device key parameters.
        //    var SignedDevice = SignedDeviceProfile.FindSignatureKey(Unpacked.Devices, SignatureKeyUDF);

        //    // Is the device authorized for admin?
        //    bool Found = false;
        //    foreach (var Entry in Unpacked.AdministrationProfile.Entries) {
        //        if (Entry.UDF == SignedDevice.UDF) {
        //            Found = true;
        //            }
        //        }
        //    Throw.IfNot(Found, "Device not authorized to sign administration profile");

        //    // Check the signature.

        //    var SigningKey = SignedDevice.Signed.DeviceSignatureKey.KeyPair;
        //    var Verify = SignedData.Verify(SignatureKeyUDF, SigningKey);
        //    Throw.IfNot(Verify, "Profile signature does not verify");
        //    }

        private void CheckSignedPOSK(PersonalProfile Unpacked) {

            //// Get the UDF of the signing key.
            //var SignatureKeyUDF = Unpacked.SignedAdministrationProfile.SignedData.ParsedHeader.kid;

            //PublicKey SigningKey = null;
            //foreach (var Key in Unpacked.PersonalMasterProfile.OnlineSignatureKeys) {
            //    if (Key.UDF == SignatureKeyUDF) {
            //        Throw.IfNot(Key.Verify(), "Invalid key");
            //        SigningKey = Key;
            //        }
            //    }

            //Throw.If(SigningKey == null, "Administration profile not signed");

            //// Check the signature.

            //var Verify = Unpacked.SignedAdministrationProfile.SignedData.Verify(SignatureKeyUDF, SigningKey.KeyPair);
            //Throw.IfNot(Verify, "Profile signature does not verify");
            }

        }
    }
