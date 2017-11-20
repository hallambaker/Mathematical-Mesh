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
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.KeyFile;

namespace Goedel.Mesh {

    // Convenience routines for our two applications defined to date

    public static partial class Extension {

        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static ApplicationProfileCatalog ApplicationProfileCatalog (this SignedProfile SignedProfile) {
            return SignedProfile.Profile as ApplicationProfileCatalog;
            }


        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static CredentialProfile PasswordProfile (this SignedProfile SignedProfile) {
            return SignedProfile.Profile as CredentialProfile;
            }


        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static BookmarkProfile BookmarkProfile (this SignedProfile SignedProfile) {
            return SignedProfile.Profile as BookmarkProfile;
            }


        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static ContactProfile ContactProfile (this SignedProfile SignedProfile) {
            return SignedProfile.Profile as ContactProfile;
            }


        }


    // In general it is useful to be able to consider a bundle of passwords 
    // as being part of the same application profile. 
    public abstract partial class ApplicationProfileCatalog : ApplicationProfile {

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        public ApplicationProfileCatalog () {
            }

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        /// <param name="PersonalProfile">The parent personal profile to attach to.</param>
        public ApplicationProfileCatalog (PersonalProfile PersonalProfile) {
            ApplicationProfileEntry = PersonalProfile.Add(this);
            }

        /// <summary>
        /// Add the specified device to the linked personal profile and 
        /// create any device specific entries in the private profile.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        /// <param name="Administration">If true, enroll as an administration device.</param>
        /// <param name="ApplicationDevicePublic">Per device public data,  if required.</param>
        public override void AddDevice (
                DeviceProfile Device,
                bool Administration = false,
                ApplicationDevicePublic ApplicationDevicePublic = null) {

            // Create entries for administrative, decryption keys
            ApplicationProfileEntry.AddDevice(Device, Administration);
            }
        }

    /// <summary>
    /// The Username and Password Profile
    /// 
    /// </summary>
    public partial class CredentialProfile  {


        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public CredentialProfilePrivate Private {
            get => ApplicationProfilePrivate as CredentialProfilePrivate;
            set => ApplicationProfilePrivate = value;
            }

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        public CredentialProfile () {
            }

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        /// <param name="PersonalProfile">The parent personal profile to attach to.</param>

        public CredentialProfile (PersonalProfile PersonalProfile) : base (PersonalProfile) {

            Private = new CredentialProfilePrivate() { };
            }

        }


    /// <summary>
    /// The Bookmark Profile
    /// </summary>
    public partial class BookmarkProfile {


        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public BookmarkProfilePrivate Private {
            get => ApplicationProfilePrivate as BookmarkProfilePrivate;
            set => ApplicationProfilePrivate = value;
            }

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        public BookmarkProfile () {
            }

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        /// <param name="PersonalProfile">The parent personal profile to attach to.</param>

        public BookmarkProfile (PersonalProfile PersonalProfile) : base(PersonalProfile) {
            Private = new BookmarkProfilePrivate() { };
            }

        }


    /// <summary>
    /// The Contact Mesh Profile
    /// </summary>
    public partial class ContactProfile {


        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public ContactProfilePrivate Private {
            get => ApplicationProfilePrivate as ContactProfilePrivate;
            set => ApplicationProfilePrivate = value;
            }

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        public ContactProfile () {
            }

        /// <summary>
        /// Create a new mail profile
        /// </summary>
        /// <param name="PersonalProfile">The parent personal profile to attach to.</param>

        public ContactProfile (PersonalProfile PersonalProfile) : base(PersonalProfile) {
            Private = new ContactProfilePrivate() { };
            }

        }



    }
