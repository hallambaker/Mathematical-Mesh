////   Copyright © 2015 by Comodo Group Inc.
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
////  
////  

//using System;
//using System.Collections.Generic;
//using Goedel.Utilities;
//using Goedel.Persistence;
//using Goedel.Cryptography;
//using Goedel.Cryptography.PKIX;

//namespace Goedel.Mesh {

//    // Convenience routines for our two applications defined to date

//    // In general it is useful to be able to consider a bundle of passwords 
//    // as being part of the same application profile. 
//    public partial class PasswordProfile : ApplicationProfile {

//        /// <summary>
//        /// The portion of the profile that is encrypted in the mesh.
//        /// </summary>
//        public PasswordProfilePrivate Private {
//            get => ApplicationProfilePrivate as PasswordProfilePrivate;
//            set => ApplicationProfilePrivate = value;
//            }


//        /// <summary>
//        /// Create a new personal profile.
//        /// </summary>
//        /// <param name="MakePrivate">If true, a private profile will be created.</param>
//        public PasswordProfile(bool MakePrivate=false) {
//            if (MakePrivate) {
//                Private = new PasswordProfilePrivate();
//                }
//            }


//        /// <summary>
//        /// Add an entry to the profile.
//        /// </summary>
//        /// <param name="Site">Site at which this entry is to be used.</param>
//        /// <param name="Username">Username</param>
//        /// <param name="Password">Password</param>
//        public void Add(
//            string Site, string Username, string Password) {
//            Private = Private ?? new PasswordProfilePrivate();
//            Private.Add(Site, Username, Password);
//            }

//        /// <summary>
//        /// Find the entry for a given site.
//        /// </summary>
//        /// <param name="Site">The site details are looked for</param>
//        /// <param name="Username">Username (null if not found)</param>
//        /// <param name="Password">Password (null if not found)</param>
//        /// <returns>true if the site is found, false otherwise.</returns>
//        public PasswordEntry GetEntry(
//            string Site, out string Username, out string Password) {

//            var Entry = Get(Site);
//            if (Entry == null) {
//                Username = null;
//                Password = null;
//                return null ;
//                }

//            Username = Entry.Username;
//            Password = Entry.Password;
//            return Entry;
//            }


//        /// <summary>
//        /// Find the entry for a given site.
//        /// </summary>
//        /// <param name="Site">The site details are looked for</param>
//        /// <returns>The password entry</returns>
//        public PasswordEntry Get(string Site) {
//            return Private.Get(Site);

//            }


//        /// <summary>
//        /// Delete a password entry.
//        /// </summary>
//        /// <param name="Site">The site whose details are to be removed</param>
//        /// <returns>true if the site was found, otherwise false.</returns>
//        public bool Delete(string Site) {
//            return Private.Delete(Site);
//            }


//        /// <summary>
//        /// Convenience function that converts a generic Signed Profile returned
//        /// by the Mesh to a PasswordProfile.
//        /// </summary>
//        /// <param name="SignedProfile">A signed password profile.</param>
//        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
//        /// otherwise null.</returns>
//        public static PasswordProfile Get(SignedProfile SignedProfile) {
//            return SignedProfile.Profile as PasswordProfile;
//            }



//        }




//    public partial class PasswordProfilePrivate {


//        /// <summary>
//        /// Find the entry for a given site.
//        /// </summary>
//        /// <param name="Site">The site details are looked for</param>
//        /// <returns>The password entry if found</returns> 
//        public PasswordEntry Get(string Site) {
//            if (Entries != null) {
//                foreach (var Entry in Entries) {
//                    foreach (var EntrySite in Entry.Sites) {
//                        if (Site == EntrySite) {
//                            return Entry;
//                            }
//                        }
//                    }
//                }
//            return null;
//            }

//        /// <summary>
//        /// Delete a password entry.
//        /// </summary>
//        /// <param name="Site">The site to delete</param>
//        /// <returns>True if the entry was deleted, otherwise false.</returns>
//        public bool Delete(string Site) {
//            bool Result = false;

//            var Previous = Get(Site);
//            while (Previous != null) {
//                Entries.Remove(Previous);
//                Previous = Get(Site);
//                Result = true;
//                }

//            return Result;
//            }

//        /// <summary>
//        /// Add an entry to the profile.
//        /// </summary>
//        /// <param name="Site">Site at which this entry is to be used.</param>
//        /// <param name="Username">Username</param>
//        /// <param name="Password">Password</param>
//        public void Add(string Site, string Username, string Password) {

//            Delete(Site);

//            var Entry = new PasswordEntry(Site, Username, Password);
//            Entries = Entries ?? new List<PasswordEntry> () ;
//            Entries.Add (Entry);
//            }
//        }

//    public partial class PasswordEntry {


//        /// <summary>
//        /// Default Constructor
//        /// </summary>
//        public PasswordEntry () { }

//        /// <summary>
//        /// Create a password entry from a Site/Username/Password tripple.
//        /// </summary>
//        /// <param name="Site">Site at which this entry is to be used.</param>
//        /// <param name="Username">Username</param>
//        /// <param name="Password">Password</param>
//        public PasswordEntry(
//            string Site, string Username, string Password) {
//            Sites = new List<string>() { Site };
//            this.Username = Username;
//            this.Password = Password;
//            }
//        }

//    }
