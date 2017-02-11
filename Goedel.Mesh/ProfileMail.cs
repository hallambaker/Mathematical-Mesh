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

namespace Goedel.Mesh {



    /// <summary>
    /// The Mesh Mail Profile
    /// </summary>
    public partial class MailProfile : ApplicationProfile {

        private MailProfilePrivate _Private;

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>

        public MailProfilePrivate Private {
            get {
                if (_Private == null) {
                    _Private = MailProfilePrivate.FromTagged(DecryptPrivate());
                    }
                return _Private;
                }
            }

        /// <summary>
        /// Returns the private profile as a block of JSON encoded bytes ready for
        /// encryption.
        /// </summary>
        protected override byte[] GetPrivateData {
            get { return Private.GetBytes(); }
            }


        ///// <summary>
        ///// Construct a MailProfile from the specified account information.
        ///// </summary>
        /// <param name="MailProfilePrivate">Specify the private account parameters.</param>
        public MailProfile(MailProfilePrivate MailProfilePrivate) {

            }



        ///// <summary>
        ///// Construct a MailProfile from the specified account information.
        ///// </summary>
        ///// <param name="UserProfile">The personal profile to attach this profile to.</param>
        ///// <param name="MailAccountInfo">Description of the mail account.</param>
        //public MailProfile(PersonalProfile UserProfile, MailAccountInfo MailAccountInfo)
        //    : base(UserProfile, "MailProfile", MailAccountInfo.AccountName) {
        //    _Private = new MailProfilePrivate(MailAccountInfo);
        //    }


        ///// <summary>
        ///// Construct an empty MailProfile for the specified account.
        ///// </summary>
        ///// <param name="UserProfile">The Personal Profile to link the MailProfile to.</param>
        ///// <param name="Account">The mail account name.</param>
        //public MailProfile(PersonalProfile UserProfile, string Account)
        //    : base(UserProfile, "MailProfile", Account) {
        //    //_Private = new MailProfilePrivate(Account);
        //    }

        /// <summary>
        /// Get the default mail profile from the specified personal profile.
        /// </summary>
        /// <param name="UserProfile">The user profile</param>
        /// <returns>The default mail profile.</returns>
        public static MailProfile Get(PersonalProfile UserProfile) {
            //return UserProfile.GetApplication(typeof(MailProfile)) as MailProfile;
            return null;
            }

        /// <summary>
        /// Export the profile parameters to the specified MailAccountInfo
        /// structure. 
        /// </summary>
        /// <param name="MailAccountInfo">The object to copy parameters to. 
        /// This object must already exist. Any prepopulated elements that 
        /// are present will be overwritten.</param>
        /// <example>
        /// The typical way the Export method is used is to create a MailAccountInfo
        /// entry for a specific client by creating an object of the class for the 
        /// application in question and passing it to the Export method.
        /// </example>
        public void Export (MailAccountInfo MailAccountInfo) {
            MailAccountInfo.EmailAddress = Private.EmailAddress;
            MailAccountInfo.ReplyToAddress = Private.ReplyToAddress;
            MailAccountInfo.DisplayName = Private.DisplayName;
            MailAccountInfo.AccountName = Private.AccountName;
            MailAccountInfo.Inbound = Private.Inbound;
            MailAccountInfo.Outbound = Private.Outbound;
            MailAccountInfo.Sign = Private.Sign;
            foreach (var Key in Private.Sign) {
                Key.ImportPrivateParameters();
                }
            MailAccountInfo.Encrypt = Private.Encrypt;
            foreach (var Key in Private.Encrypt) {
                Key.ImportPrivateParameters();
                }
            }


        }

    public partial class MailProfilePrivate {

        /// <summary>
        /// Construct a MailProfile object from a MailAccountInfo object.
        /// </summary>
        /// <param name="MailAccountInfo">Description of the mail account settings.</param>
        public MailProfilePrivate(MailAccountInfo MailAccountInfo) {
            EmailAddress = MailAccountInfo.EmailAddress;
            ReplyToAddress = MailAccountInfo.ReplyToAddress;
            DisplayName = MailAccountInfo.DisplayName;
            AccountName = MailAccountInfo.AccountName;
            Inbound = MailAccountInfo.Inbound;
            Outbound = MailAccountInfo.Outbound;
            Sign = MailAccountInfo.Sign;
            foreach (var Key in Sign) {
                Key.ExportPrivateParameters();
                }
            Encrypt = MailAccountInfo.Encrypt;
            foreach (var Key in Encrypt) {
                Key.ExportPrivateParameters();
                }
            }



        }

    }
