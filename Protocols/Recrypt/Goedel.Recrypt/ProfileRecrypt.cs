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
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Mesh.Platform;
using Goedel.Protocol;

namespace Goedel.Recrypt {

    /// <summary>Extension methods for recryption</summary>
    public static partial class Extension {

        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static RecryptProfile RecryptProfile (this SignedProfile SignedProfile) {
            return SignedProfile.Profile as RecryptProfile;
            }
        }

    /// <summary>
    /// Manage a set of application sessions that are recryption sessions bound to
    /// a single personal session. This allows for methods such as 'get set of candidate keys'
    /// </summary>
    public partial class SessionRecryption {

        /// <summary>The personal session</summary>
        public SessionPersonal SessionPersonal;

        /// <summary>The list of application sessions.</summary>
        public List<SessionApplication> SessionApplications;


        //Dictionary<string, RecryptDevicePrivate> DevicePrivate;
        Dictionary<string, KeyPair> DecryptKeyByID = 
                    new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> SignKeyByID =
            new Dictionary<string, KeyPair>();

        ///////************************
        // Has come back to byte us
        // Need to use the device profile to work out what recypt keys we have available to us
        // then recover the decryption key and ID
        // then find a recryption profile we can use.
        // Save the encryption key to decrypt the returned data.
        List<SessionApplication> Result = new List<SessionApplication>();

        /// <summary>
        /// Construct a SessionRecryption from a personal session.
        /// </summary>
        /// <param name="SessionPersonal">The personal session to construct from.</param>
        public SessionRecryption (SessionPersonal SessionPersonal) {
            this.SessionPersonal = SessionPersonal;
            SessionApplications = SessionPersonal.GetApplicationsByType("RecryptProfile");

            foreach (var Session in SessionApplications) {
                var Profile = Session.ApplicationProfile as RecryptProfile;


                foreach (var EncryptedDevicePrivate in Profile.DevicePrivate) {
                    var KeyID = Session.FindByDecryption(EncryptedDevicePrivate.Recipients);

                    var Plaintext = EncryptedDevicePrivate.Decrypt(
                        KeyID.DeviceProfile.DeviceEncryptiontionKey.KeyPair);

                    var DevicePrivate = RecryptDevicePrivate.FromJSON(Plaintext.JSONReader());
                    Session.ApplicationDevicePrivate = DevicePrivate;

                    AddDevicePrivate(DevicePrivate);
                    }
                }
            }


        KeyPair DecryptionKeyPairFudge; // Hack: only supports one key at the 
                // moment because we have no mapping to the recryption group

        void AddDevicePrivate (RecryptDevicePrivate RecryptDevicePrivate) {
            // OK here have to fix the udf generation first...

            foreach (var Key in RecryptDevicePrivate.DecryptKeys) {
                var KeyPair = Key.KeyPair;
                var UDF = KeyPair.UDF;
                DecryptKeyByID.Add(UDF, KeyPair);

                DecryptionKeyPairFudge = KeyPair;
                }
            foreach (var Key in RecryptDevicePrivate.SignKeys) {
                var KeyPair = Key.KeyPair;
                var UDF = KeyPair.UDF;
                SignKeyByID.Add(UDF, KeyPair);
                }
            }

        /// <summary>
        /// Get the encryption key
        /// </summary>
        /// <param name="Recipients">List of recipients.</param>
        /// <returns>The encryption key pair</returns>
        public KeyPair GetEncryptionKey (List<Recipient> Recipients) {

            return DecryptionKeyPairFudge;
            }

        }


    // Convenience routines for our two applications defined to date

    // In general it is useful to be able to consider a bundle of passwords 
    // as being part of the same application profile. 
    public partial class RecryptProfile : ApplicationProfile {

        ///// <summary>
        ///// The portion of the profile that is encrypted in the mesh.
        ///// </summary>
        //public RecryptProfilePrivate Private {
        //    get => ApplicationProfilePrivate as RecryptProfilePrivate;
        //    set => ApplicationProfilePrivate = value;
        //    }


        /// <summary>
        /// Create a new recryption profile.
        /// </summary>
        public RecryptProfile () {
            }

        /// <summary>The encryption pair</summary>
        public PublicKey EncryptPair {set; private get;}

        /// <summary>The signature pair</summary>
        public PublicKey SignPair { set; private get; }

        /// <summary>
        /// Create a new recryption profile with private profiles for the specified device.
        /// At present a single recryption key is generated that is accessible to every 
        /// authorized device.
        /// </summary>
        /// <param name="PersonalProfile">The personal profile</param>
        /// <param name="AccountID">The account identifier</param>
        /// <param name="Friendly">The friendly name</param>
        public RecryptProfile (PersonalProfile PersonalProfile, string AccountID, string Friendly = null) {
            Account = AccountID;
            this.PersonalProfile = PersonalProfile;

            EncryptPair = PublicKey.Generate(KeyType.AEK, CryptoAlgorithmID.RSAExch);
            var EncryptPublic = new PublicKey() { PublicParameters = EncryptPair.PublicParameters };

            SignPair = PublicKey.Generate(KeyType.ASK, CryptoAlgorithmID.RSASign);
            var SignPublic = new PublicKey() { PublicParameters = SignPair.PublicParameters };

            EncryptKeys = new List<PublicKey>() { EncryptPublic };
            AuthKeys = new List<PublicKey>() { SignPublic };

            // Register with the application.
            ApplicationProfileEntry = PersonalProfile.Add(this);
            ApplicationProfileEntry.Friendly = Friendly ?? AccountID;
            }


        /// <summary>
        /// Create device specific data.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        /// <param name="Administration">If true, create an administration entry</param>
        public void AddDevice (DeviceProfile Device, bool Administration=true) {
            DevicePrivate = DevicePrivate ?? new List<JoseWebEncryption>();

            var EncryptPrivate = MakeDevicePrivateKey(EncryptPair, Device);
            var SignPrivate = MakeDevicePrivateKey(SignPair, Device);

            var DevicePrivateEntry = new RecryptDevicePrivate() {
                DecryptKeys = new List<PublicKey> { EncryptPrivate },
                SignKeys = new List<PublicKey> { SignPrivate }
                };

            var EncryptedDevicePrivate = Device.Encrypt(DevicePrivateEntry);
            DevicePrivate.Add(EncryptedDevicePrivate);

            // Create entries for administrative, decryption keys
            ApplicationProfileEntry.AddDevice(Device, Administration);
            }
        }
    }
