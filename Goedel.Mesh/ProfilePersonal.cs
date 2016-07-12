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
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Jose;

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
        public SignedDeviceProfile SignedDeviceProfile;

        /// <summary>
        /// Get UDF fingerprint of the profile.
        /// </summary>
        public override string UDF { get { return _PersonalMasterProfile.Identifier; } }

        MasterProfile _PersonalMasterProfile;

        /// <summary>
        /// The corresponding signed profile.
        /// </summary>
        public SignedPersonalProfile Signed {
            get {
                return new SignedPersonalProfile(this);
                }
            }

        /// <summary>
        /// The parsed master profile associated with this profile
        /// </summary>
        public MasterProfile PersonalMasterProfile {
            get { return _PersonalMasterProfile; }
            }

        /// <summary>
        /// Create a personal profile including the associated master and administration
        /// profiles.
        /// </summary>
        /// <param name="DeviceProfile">The device profile to be the initial 
        /// administration device for the profile.</param>

        public PersonalProfile(SignedDeviceProfile DeviceProfile) {
            _PersonalMasterProfile = new MasterProfile(CryptoCatalog.Default);
            SignedMasterProfile = new SignedMasterProfile(_PersonalMasterProfile);


            // Set up the device and application profiles.
            Initialize(_PersonalMasterProfile, DeviceProfile);
            }

        /// <summary>
        /// Create a personal profile with the specified master and administration
        /// profiles.
        /// </summary>
        /// <param name="PersonalMasterProfile">The master profile for this 
        /// personal profile.</param>
        /// <param name="DeviceProfile">The device profile to be the initial 
        /// administration device for the profile.</param>
        public PersonalProfile(MasterProfile PersonalMasterProfile,
                    SignedDeviceProfile DeviceProfile) {
            Initialize(PersonalMasterProfile, DeviceProfile);
            }


        private void Initialize (MasterProfile PersonalMasterProfile,
                    SignedDeviceProfile DeviceProfile) {
            SignedDeviceProfile = DeviceProfile;

            Identifier = _PersonalMasterProfile.MasterSignatureKey.UDF;
            Devices = new List<SignedDeviceProfile>();
            Devices.Add(DeviceProfile);
            Applications = new List<ApplicationProfileEntry>();
            }

          
        /// <summary>
        /// Find the Application Profile Entry that matches an identifier.
        /// </summary>
        /// <param name="Identifier"></param>
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
        /// <param name="Identifier"></param>
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
        /// <returns></returns>
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
        public void Add(SignedDeviceProfile DeviceProfile) {
            Devices.Add(DeviceProfile);
            }

        /// <summary>
        /// Add an application to the profile
        /// </summary>
        /// <param name="ApplicationProfile">The application profile to add.</param>
        /// <returns>The appliccation profile entry</returns>
        public ApplicationProfileEntry Add(ApplicationProfile ApplicationProfile) {

            var ApplicationProfileEntry = new ApplicationProfileEntry();

            ApplicationProfileEntry.Identifier = ApplicationProfile.Identifier;

            if (Applications == null) {
                Applications = new List<ApplicationProfileEntry>();
                }

            Applications.Add(ApplicationProfileEntry);
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
        /// Get the named application entry.
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="MatchName"></param>
        /// <returns>The application profile entry (if found) or null otherwise.</returns>
        public ApplicationProfileEntry GetApplication(System.Type Type, string MatchName) {
            foreach (var App in Applications) {
                //if (App.GetType() == Type) {
                //    foreach (var Name in App.Names) {
                //        if (Name == MatchName) {
                //            return App;
                //            }
                //        }
                //    }
                }
            return null;
            }

        /// <summary>
        /// Get the default password profile.
        /// </summary>
        /// <returns>The application profile entry (if found) or null otherwise.</returns>
        public ApplicationProfileEntry GetPasswordProfile () {
            var Profile = GetApplication(typeof(PasswordProfile).Name);
            return Profile;
            }

        /// <summary>
        /// Get the default network profile.
        /// </summary>
        /// <returns>The application profile entry (if found) or null otherwise.</returns>
        public ApplicationProfileEntry GetNetworkProfile() {
            var Profile = GetApplication(typeof(NetworkProfile).Name);
            return Profile;
            }

        /// <summary>
        /// Get the default mail profile.
        /// </summary>
        /// <returns>The application profile entry (if found) or null otherwise.</returns>
        public ApplicationProfileEntry GetMailProfile() {
            var Profile = GetApplication(typeof(MailProfile).Name);
            return Profile;
            }

        /// <summary>
        /// Get the administration key (if available).
        /// </summary>
        /// <returns>The administration key.</returns>
        public KeyPair GetAdministrationKey() {
            foreach (var Device in Devices) {
                Console.WriteLine("Got Device {0}", Device.UDF);

                var Key = KeyPair.FindLocal(Device.UDF);
                if (Key != null) {
                    return Key;
                    }


                // if have private [device]...
                }
            return null;
            }


        /// <summary>
        /// Unpack the profile and signed sub profiles.
        /// </summary>
        public override void Unpack() {
            Throw.If(SignedMasterProfile == null, "No master profile");
            //Throw.If(SignedAdministrationProfile == null, "No administration profile");
            Throw.If(Devices == null, "No device profile");

            _PersonalMasterProfile = SignedMasterProfile.UnpackAndVerify();
            //_AdministrationProfile = SignedAdministrationProfile.UnpackAndVerify();
            foreach (var Device in Devices) {
                Device.UnpackAndVerify();
                }
            }


        }


    public partial class ApplicationProfileEntry {

        /// <summary>
        /// The application profile object this entry belongs to.
        /// </summary>
        public ApplicationProfile ApplicationProfile;

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
        public virtual void AddDevice(SignedDeviceProfile Device) {
            // Create admin entry for this device

            if (SignID == null) {
                SignID = new List<string>();
                }
            SignID.Add(Device.Identifier);

            if (DecryptID == null) {
                DecryptID = new List<string>();
                }
            DecryptID.Add(Device.Identifier);
            }

        }


    }
