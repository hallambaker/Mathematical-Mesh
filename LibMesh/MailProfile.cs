using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.CryptoLibNG;
using Goedel.CryptoLibNG.PKIX;

namespace Goedel.Mesh {




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

        protected override byte[] GetPrivateData {
            get { return _Private.GetBytes(); }
            }


        public MailProfile(PersonalProfile UserProfile, MailAccountInfo MailAccountInfo)
            : base(UserProfile, "MailProfile", MailAccountInfo.AccountName) {
            _Private = new MailProfilePrivate(MailAccountInfo);
            }



        public MailProfile(PersonalProfile UserProfile, string Account)
            : base(UserProfile, "MailProfile", Account) {
            //_Private = new MailProfilePrivate(Account);
            }

        public void Add(Connection Connection) {
            Private.Add(Connection);
            }

        public static MailProfile Get(PersonalProfile UserProfile) {
            //return UserProfile.GetApplication(typeof(MailProfile)) as MailProfile;
            return null;
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
        /// Initialize S/MIME support using CA issued certificate.
        /// </summary>
        /// <param name="CertificateAuthorityName"></param>
        public void InitializeSMIME (string CertificateAuthorityName) {

            


            }

        /// <summary>
        /// Initialize S/MIME support using self signed certificates.
        /// </summary>
        public void InitializeSMIME() {

            var RootKey = new CryptoProviderSignatureRSA(2048);

            var RootCert = Certificate.CreateRoot(
                        RootKey,
                        "Test Personal Root");
            RootCert.Sign();


            var IntermediateKey = new CryptoProviderSignatureRSA(2048);
            var IntermediateCertificate = Certificate.CreateIntermediate(
                        IntermediateKey,
                        "Test Personal Intermediate");
            IntermediateCertificate.TBSCertificate.SetValidity(5);
            IntermediateCertificate.Sign(RootCert);


            var SigningKey = new CryptoProviderSignatureRSA(2048);
            var SigningCertificate = Certificate.CreateEndEntity(
                        SigningKey,
                        Application.EmailSignature | Application.DataSignature,
                        "alice@example.com",
                        "Alice Example");
            SigningCertificate.TBSCertificate.SetValidity(1);
            SigningCertificate.Sign(IntermediateCertificate);

            var EncryptionKey = new CryptoProviderExchangeRSA(2048);
            var EncryptionCertificate = Certificate.CreateEndEntity(
                        EncryptionKey,
                        Application.EmailEncryption | Application.DataEncryption,
                        "alice@example.com",
                        "Alice Example");
            EncryptionCertificate.TBSCertificate.SetValidity(1);
            SigningCertificate.Sign(IntermediateCertificate);

            /*
            var EncryptionCSR = new CertificationRequest(EncryptionCertificate);
            var SigningCSR = new CertificationRequest(SigningCertificate);


            MasterCertificate.WindowsRegister(StoreName.Root, StoreLocation.CurrentUser);
            OnlineCertificate.WindowsRegister(StoreName.CertificateAuthority, StoreLocation.CurrentUser);

            EncryptionCertificate.WindowsRegister(StoreName.My, StoreLocation.CurrentUser);
            SigningCertificate.WindowsRegister(StoreName.My, StoreLocation.CurrentUser);
            */

            }


        }

    public partial class MailProfilePrivate {

        public MailProfilePrivate(MailAccountInfo MailAccountInfo) {
            }

        public void Add(Connection Connection) {
            if (Connections == null) {
                Connections = new List<Connection>();
                }
            Connections.Add(Connection);
            }

        }

    }
