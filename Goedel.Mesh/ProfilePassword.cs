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
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;

namespace Goedel.Mesh {

    // Convenience routines for our two applications defined to date

    // In general it is useful to be able to consider a bundle of passwords 
    // as being part of the same application profile. 
    public partial class PasswordProfile : ApplicationProfile {
        const string TypeTag = "PasswordProfile";

        private PasswordProfilePrivate _Private;

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public PasswordProfilePrivate Private {
            get {
                if (_Private == null) {
                    var Plaintext = DecryptPrivate();
                    _Private = PasswordProfilePrivate.FromTagged(Plaintext);
                    }
                return _Private;
                }
            }

        /// <summary>
        /// Returns the private profile as a block of JSON encoded bytes ready for
        /// encryption.
        /// </summary>
        protected override byte[] GetPrivateData {
            get {
                return Private.GetBytes();
                }
            }



        /// <summary>
        /// Create a new password profile and attach it to the specified
        /// personal profile.
        /// </summary>
        /// <param name="PersonalProfile">Personal profile to connect to</param>
        public PasswordProfile(PersonalProfile PersonalProfile) :
            this(PersonalProfile, null) { }


        /// <summary>
        /// Create a new password profile and attach it to the specified
        /// personal profile.
        /// </summary>
        /// <param name="PersonalProfile">Personal profile to connect to</param>
        /// <param name="Friendly">Friendly name to be used to distinguish
        /// profiles of the same type</param>
        public PasswordProfile(PersonalProfile PersonalProfile, string Friendly)
            : base(PersonalProfile, TypeTag, Friendly) {
            _Private = new PasswordProfilePrivate();
            }



        /// <summary>
        /// Add an entry to the profile.
        /// </summary>
        /// <param name="Site">Site at which this entry is to be used.</param>
        /// <param name="Username">Username</param>
        /// <param name="Password">Password</param>
        public void Add(
            string Site, string Username, string Password) {
            Private.Add(Site, Username, Password);
            }

        /// <summary>
        /// Find the entry for a given site.
        /// </summary>
        /// <param name="Site">The site details are looked for</param>
        /// <param name="Username">Username (null if not found)</param>
        /// <param name="Password">Password (null if not found)</param>
        /// <returns>true if the site is found, false otherwise.</returns>
        public bool GetEntry(
            string Site, out string Username, out string Password) {

            if (Private.Entries != null) {
                foreach (var Entry in Private.Entries) {
                    foreach (var EntrySite in Entry.Sites) {
                        if (Site == EntrySite) {
                            Username = Entry.Username;
                            Password = Entry.Password;
                            return true;
                            }
                        }
                    }
                }
            Username = null;
            Password = null;
            return false;
            }

        ///// <summary>
        ///// Make a device entry for the application
        ///// </summary>
        ///// <param name="DeviceProfile">Device profile of device to add.</param>
        ///// <returns>The device entry.</returns>
        //public override DeviceEntry MakeEntry(SignedDeviceProfile DeviceProfile) {
        //    var DeviceEntry = base.MakeEntry(DeviceProfile);
        //    //DeviceEntry.EncryptedKey = MakeDecryptInfo(DeviceProfile.Signed);
        //    return DeviceEntry;
        //    }

        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile"></param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static PasswordProfile Get(SignedProfile SignedProfile) {
            return SignedProfile.Inner as PasswordProfile;
            }

        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile"></param>
        /// <param name="PersonalProfile">The personal profile to link the Password Profile to.</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static PasswordProfile Get(SignedProfile SignedProfile,
                    PersonalProfile PersonalProfile) {
            var Result = SignedProfile.Inner as PasswordProfile;

            if (Result == null) {
                throw new Throw("Not a password profile.");
                }

            Result.Link(PersonalProfile);
            return (Result);
            }

        }




    public partial class PasswordProfilePrivate {
        /// <summary>
        /// Add an entry to the profile.
        /// </summary>
        /// <param name="Site">Site at which this entry is to be used.</param>
        /// <param name="Username">Username</param>
        /// <param name="Password">Password</param>
        public void Add(string Site, string Username, string Password) {
            var Entry = new PasswordEntry(Site, Username, Password);
            Entries = Entries == null ? new List<PasswordEntry> (): Entries;
            Entries.Add (Entry);
            }
        }

    public partial class PasswordEntry {
        /// <summary>
        /// Create a password entry from a Site/Username/Password tripple.
        /// </summary>
        /// <param name="Site">Site at which this entry is to be used.</param>
        /// <param name="Username">Username</param>
        /// <param name="Password">Password</param>
        public PasswordEntry(
            string Site, string Username, string Password) {
            Sites = new List<string>();
            Sites.Add(Site);
            this.Username = Username;
            this.Password = Password;
            }
        }

    }
