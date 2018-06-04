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
using Goedel.Utilities;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

namespace Goedel.Mesh {

    /// <summary>
    /// The personal profile is divided into two parts, the Master Profile which
    /// should change rarely, if ever and the Current Profile which changes each
    /// time a device or application is added to or removed from the profile.
    /// </summary>


    public partial class PersonalProfile  {


        /// <summary>
        /// The active device profile of the local machine that is attached to this
        /// profile.
        /// </summary>
        public DeviceProfile DeviceProfile {
            get { _DeviceProfile = _DeviceProfile ?? GetDevice(); return _DeviceProfile; }
            set => _DeviceProfile = value; }
        DeviceProfile _DeviceProfile = null;

        DeviceProfile GetDevice () {
            foreach (var Device in Devices) {
                if (Device.DeviceProfile.DeviceSignatureKey.PrivateKey != null) {
                    return Device.DeviceProfile;
                    }
                }
            return null;
            }



        /// <summary>
        /// The active device profile of the local machine that is attached to this
        /// profile.
        /// </summary>
        public SignedDeviceProfile SignedDeviceProfile => DeviceProfile?.SignedDeviceProfile;

        /// <summary>
        /// Get UDF fingerprint of the profile.
        /// </summary>
        public override string UDF => MasterProfile.Identifier;


        /// <summary>
        /// The corresponding signed profile.
        /// </summary>
        public SignedPersonalProfile SignedPersonalProfile {
            get {
                if (_SignedPersonalProfile == null) {
                    Sign();
                    }
                return _SignedPersonalProfile;
                }
            set { _SignedPersonalProfile = value; }
            }

        SignedPersonalProfile _SignedPersonalProfile;

        void ClearSignature () {
            _SignedPersonalProfile = null;
            }


        /// <summary>
        /// The parsed master profile associated with this profile
        /// </summary>
        public MasterProfile MasterProfile => SignedMasterProfile.MasterProfile;

        /// <summary>
        /// Get the list of administration keys.
        /// </summary>
        public List<PublicKey> AdministrationKeys => MasterProfile.OnlineSignatureKeys;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PersonalProfile () { }

        /// <summary>
        /// Create a personal profile with the specified master and administration
        /// profiles.
        /// </summary>
        /// <param name="DeviceProfile">The device profile to be the initial 
        /// administration device for the profile.</param>
        /// <param name="MasterProfile">The master profile for this 
        /// personal profile.</param>
        public PersonalProfile(DeviceProfile DeviceProfile, MasterProfile MasterProfile = null) {

            this.DeviceProfile = DeviceProfile ;
            var PersonalMasterProfile = MasterProfile ?? new MasterProfile(CryptoCatalog.Default);
            SignedMasterProfile = PersonalMasterProfile.SignedMasterProfile;

            Identifier = PersonalMasterProfile.MasterSignatureKey.UDF;
            Devices = new List<SignedDeviceProfile>() { SignedDeviceProfile };
            Applications = new List<ApplicationProfileEntry>();

            }

        /// <summary>
        /// Sign the current profile. 
        /// </summary>
        /// <param name="UDF">Specify the signature key by identifier</param>
        /// <param name="KeyPair">Specify the signature key by key handle</param>
        /// <param name="Encoding">The encoding for the inner data</param>
        /// <returns>The signed profile.</returns>
        public override SignedProfile Sign (string UDF = null, KeyPair KeyPair = null,
                        DataEncoding Encoding = DataEncoding.JSON) {
            // Locate the administration key for this device.
            var AdminKey = MasterProfile.AdministrationKey;

            Assert.NotNull(AdminKey, NotAdministrationDevice.Throw);

            SignedPersonalProfile = new SignedPersonalProfile(this, AdminKey);
            return SignedPersonalProfile;
            }

        /// <summary>
        /// Find the Application Profile Entry that matches an identifier.
        /// </summary>
        /// <param name="Identifier">The profile identifier</param>\
        /// <returns>The matching application profile entry if found, otherwise null.</returns>
        public ApplicationProfileEntry GetApplicationEntry(string Identifier) {

            foreach (var Entry in Applications) {
                if (Entry.Identifier == Identifier) {
                    return Entry;
                    }
                }
            return null;
            }


        /// <summary>
        /// Find the Application Profile Entry that matches an identifier.
        /// </summary>
        /// <param name="Type">The profile identifier</param>\
        /// <param name="AccountID">If not null, specifies the friendly name that the profile must match.</param>
        /// <returns>The matching application profile entry if found, otherwise null.</returns>
        public ApplicationProfileEntry GetNamedApplicationEntry (string Type, string AccountID = null) {

            foreach (var Entry in Applications) {
                if (Entry.Type == Type) {
                    if (AccountID == null | Entry.Friendly == AccountID) {
                        return Entry;
                        }
                    }
                }
            return null;
            }


        /// <summary>
        /// Find the Application Profile Entry that matches an identifier.
        /// </summary>
        /// <param name="Identifier">The profile identifier</param>
        /// <returns>The matching application profile entry if found, otherwise null.</returns>
        public SignedDeviceProfile GetDeviceProfile(string Identifier) {

            foreach (var Entry in Devices) {
                if (Entry.Identifier == Identifier) {
                    return Entry;
                    }
                }
            return null;
            }

        /// <summary>
        /// This method returns the list of index terms for the profile and is used
        /// by the mesh protocols.
        /// </summary>
        /// <returns>List of index terms.</returns>
        public override List<IndexTerm> GetIndex() {
            var Result = base.GetIndex();
            //foreach (var Account in Accounts) {
            //    Result.Add(new IndexTerm(MeshIndexTerm.KeyUserProfile, Account)); // account ID
            //    }
            return Result;
            }

        /// <summary>
        /// Add a device to the profile.
        /// </summary>
        /// <param name="DeviceProfile">The device profile to add</param>
        public void Add(DeviceProfile DeviceProfile) {
            Devices.Add(DeviceProfile.SignedDeviceProfile);
            ClearSignature();
            }

        /// <summary>
        /// Add a device to the profile.
        /// </summary>
        /// <param name="Request">The connection request for the device.</param>
        public void Add (ConnectionRequest Request) {
            Devices.Add(Request.Device);
            // NYI: add the application data here

            ClearSignature();
            }


        /// <summary>
        /// Add an application to the profile
        /// </summary>
        /// <param name="ApplicationProfile">The application profile to add.</param>
        /// <returns>The appliccation profile entry</returns>
        public ApplicationProfileEntry Add(ApplicationProfile ApplicationProfile) {

            // Hack: This should be done differently. first, accounts should be registered as AccountProfiles with the sub-apps specified.

            var ApplicationProfileEntry = new ApplicationProfileEntry() {
                Identifier = ApplicationProfile.Identifier,
                Type = ApplicationProfile.Tag(),
                ApplicationProfile = ApplicationProfile,   // Hack: This is temporary for the RSAConf profile should be fetched from the account
                AccountID = ApplicationProfile.ShortID  // ToDo: Should have separate calls for creating local and remote accounts
                };

            if (Applications == null) {
                Applications = new List<ApplicationProfileEntry>();
                }

            Applications.Add(ApplicationProfileEntry);
            ApplicationProfile.ApplicationProfileEntry = ApplicationProfileEntry;
            ApplicationProfile.PersonalProfile = this;

            ClearSignature();

            return ApplicationProfileEntry;
            }

        /// <summary>
        /// Get the first application entry of the specified type.
        /// </summary>
        /// <param name="Type">The application type.</param>
        /// <returns>The application profile entry (if found) or null otherwise.</returns>
        public ApplicationProfileEntry GetApplication(string Type) {
            foreach (var App in Applications) {
                if (App.Type == Type) {
                    return App;
                    }
                }
            return null;

            }

        /// <summary>
        /// The Administration key (if null, this is not an administration profile)
        /// </summary>
        public KeyPair AdministrationKey => MasterProfile.AdministrationKey;


        /// <summary>
        /// Unpack the profile and signed sub profiles.
        /// </summary>
        public override void Unpack() {
            Assert.NotNull(SignedMasterProfile, NoMasterProfile.Throw);
            //Throw.If(SignedAdministrationProfile == null, "No administration profile");
            Assert.NotNull(Devices == null, NoDeviceProfile.Throw);

            //MasterProfile = SignedMasterProfile.UnpackMasterProfile();
            //_AdministrationProfile = SignedAdministrationProfile.UnpackAndVerify();
            foreach (var Device in Devices) {
                Device.UnpackDeviceProfile();
                }
            }

        }


    /// <summary>
    /// Base class for application profile entries.
    /// </summary>
    public partial class ApplicationProfileEntry {

        /// <summary>
        /// The application profile object this entry belongs to.
        /// </summary>
        public ApplicationProfile ApplicationProfile;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApplicationProfileEntry () { }

        /// <summary>
        /// Create a new entry for the specified profile.
        /// </summary>
        /// <param name="ApplicationProfile">Profile to link to.</param>
        public ApplicationProfileEntry(ApplicationProfile ApplicationProfile) {

            Identifier = ApplicationProfile.Identifier;
            Type = ApplicationProfile.Tag();
            this.ApplicationProfile = ApplicationProfile;
            }

        /// <summary>
        /// Add the specified device to the linked personal profile and 
        /// create any device specific entries in the private profile.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        /// <param name="Administration">If true, enroll as an administration device.</param>
        public virtual void AddDevice(DeviceProfile Device, bool Administration=false) {
            // Create admin entry for this device
            if (Administration) {
                if (AdminDeviceUDF == null) {
                    AdminDeviceUDF = new List<string>();
                    }
                AdminDeviceUDF.Add(Device.Identifier);
                }

            // Create device entry for this device
            if (DecryptDeviceUDF == null) {
                DecryptDeviceUDF = new List<string>();
                }
            DecryptDeviceUDF.Add(Device.Identifier);
            }





        }


    }
