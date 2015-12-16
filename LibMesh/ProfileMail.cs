using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;

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
            get { return _Private.GetBytes(); }
            }


        /// <summary>
        /// Construct a MailProfile from the specified account information.
        /// </summary>
        /// <param name="UserProfile">The personal profile to attach this profile to.</param>
        /// <param name="MailAccountInfo">Description of the mail account.</param>
        public MailProfile(PersonalProfile UserProfile, MailAccountInfo MailAccountInfo)
            : base(UserProfile, "MailProfile", MailAccountInfo.AccountName) {
            _Private = new MailProfilePrivate(MailAccountInfo);
            }


        /// <summary>
        /// Construct an empty MailProfile for the specified account.
        /// </summary>
        /// <param name="UserProfile">The Personal Profile to link the MailProfile to.</param>
        /// <param name="Account">The mail account name.</param>
        public MailProfile(PersonalProfile UserProfile, string Account)
            : base(UserProfile, "MailProfile", Account) {
            //_Private = new MailProfilePrivate(Account);
            }

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
            MailAccountInfo.Encrypt = Private.Encrypt;
            }




        /// <summary>
        /// Make a device entry for the application
        /// </summary>
        /// <param name="DeviceProfile">Device profile of device to add.</param>
        /// <returns>The device entry.</returns>
        public override DeviceEntry MakeEntry(SignedDeviceProfile DeviceProfile) {
            var DeviceEntry = base.MakeEntry(DeviceProfile);
            //DeviceEntry.EncryptedKey = MakeDecryptInfo(DeviceProfile.Signed);
            return DeviceEntry;
            }


        /// <summary>
        /// Initialize S/MIME support using CA issued certificates.
        /// </summary>
        /// <param name="CertificateAuthorityName"></param>
        public void InitializeSMIME (string CertificateAuthorityName) {

            }


        /// <summary>
        /// Initialize S/MIME support using self issued certificates.
        /// </summary>
        public void InitializeSMIME() {

            }





        ///// <summary>
        ///// Initialize S/MIME support using self signed certificates.
        ///// </summary>
        //public void InitializeSMIMEx () {

        //    var RootKey = new CryptoProviderSignatureRSA(2048);

        //    var RootCert = Certificate.CreateRoot(
        //                RootKey,
        //                "Test Personal Root");
        //    RootCert.Sign();


        //    var IntermediateKey = new CryptoProviderSignatureRSA(2048);
        //    var IntermediateCertificate = Certificate.CreateIntermediate(
        //                IntermediateKey,
        //                "Test Personal Intermediate");
        //    IntermediateCertificate.TBSCertificate.SetValidity(5);
        //    IntermediateCertificate.Sign(RootCert);


        //    var SigningKey = new CryptoProviderSignatureRSA(2048);
        //    var SigningCertificate = Certificate.CreateEndEntity(
        //                SigningKey,
        //                Application.EmailSignature | Application.DataSignature,
        //                "alice@example.com",
        //                "Alice Example");
        //    SigningCertificate.TBSCertificate.SetValidity(1);
        //    SigningCertificate.Sign(IntermediateCertificate);


        //    var EncryptionKey = new CryptoProviderExchangeRSA(2048);
        //    var EncryptionCertificate = Certificate.CreateEndEntity(
        //                EncryptionKey,
        //                Application.EmailEncryption | Application.DataEncryption,
        //                "alice@example.com",
        //                "Alice Example");
        //    EncryptionCertificate.TBSCertificate.SetValidity(1);
        //    SigningCertificate.Sign(IntermediateCertificate);


        //    // Create CSRs for use with a CA
        //    var RootCSR = new CertificationRequest(RootCert);
        //    var IntermediateCSR = new CertificationRequest(IntermediateCertificate);
        //    var SigningCSR = new CertificationRequest(SigningCertificate);
        //    var EncryptionCSR = new CertificationRequest(EncryptionCertificate);




        //    // Now need to

        //    // Cross sign the root an intermediate under the master profile.

        //    // Escrow the encryption key under the master escrow key.

        //    // Insert the certificates into the right cert stores.


        //    CertificateStore.Register(RootCert);
        //    CertificateStore.Register(IntermediateCertificate);
        //    CertificateStore.Register(SigningCertificate);
        //    CertificateStore.Register(EncryptionCertificate); 
                

        //    }


        }

    public partial class MailProfilePrivate {

        /// <summary>
        /// Construct a MailProfile object from a MailAccountInfo object.
        /// </summary>
        /// <param name="MailAccountInfo"></param>
        public MailProfilePrivate(MailAccountInfo MailAccountInfo) {
            EmailAddress = MailAccountInfo.EmailAddress;
            ReplyToAddress = MailAccountInfo.ReplyToAddress;
            DisplayName = MailAccountInfo.DisplayName;
            AccountName = MailAccountInfo.AccountName;
            Inbound = MailAccountInfo.Inbound;
            Outbound = MailAccountInfo.Outbound;
            Sign = MailAccountInfo.Sign;
            Encrypt = MailAccountInfo.Encrypt;
            }



        }

    }
