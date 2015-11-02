﻿using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.CryptoLibNG;
using Goedel.CryptoLibNG.PKIX;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    /// <summary>
    /// The personal profile is divided into two parts, the Master Profile which
    /// should change rarely, if ever and the Current Profile which changes each
    /// time a device or application is added to or removed from the profile.
    /// </summary>

    public partial class MasterProfile : Profile {

        /// <summary>
        /// Create a MasterProfile using the default signature and exchange
        /// algorithms.
        /// </summary>
        /// <param name="CryptoCatalog">Catalog to take the default algorithms from.</param>
        public MasterProfile(CryptoCatalog CryptoCatalog)
            : this (CryptoCatalog.AlgorithmSignature,
                   CryptoCatalog.AlgorithmExchange) {
            }

        /// <summary>
        /// Create a MasterProfile using the specified signature and exchange
        /// algorithms.
        /// </summary>
        /// <param name="SignatureAlgorithmID">The signature algorithm to be used for
        /// the master signature key and the online signature key.</param>
        /// <param name="ExchangeAlgorithmID">The exchange a</param>
        public MasterProfile(CryptoAlgorithmID SignatureAlgorithmID, 
                        CryptoAlgorithmID ExchangeAlgorithmID) {

            
            MasterSignatureKey = PublicKey.Generate(KeyType.PMSK, SignatureAlgorithmID);
            MasterSignatureKey.SelfSignCertificate(Application.PersonalMaster);

            var OnlineSignatureKey = PublicKey.Generate(KeyType.POSK, SignatureAlgorithmID);
            OnlineSignatureKey.SignCertificate(Application.CA, MasterSignatureKey);
  
            OnlineSignatureKeys = new List<PublicKey>();
            OnlineSignatureKeys.Add(OnlineSignatureKey);

            var MasterEscrowKey = PublicKey.Generate(KeyType.PMEK, ExchangeAlgorithmID);
            MasterEscrowKey.SignCertificate(Application.DataEncryption, MasterSignatureKey);

            MasterEscrowKeys = new List<PublicKey>();
            MasterEscrowKeys.Add(MasterEscrowKey);

            Identifier = MasterSignatureKey.UDF;
            }


        }

    public partial class PersonalProfile  {

        public SignedDeviceProfile SignedDeviceProfile;

        public override string UDF { get { return _PersonalMasterProfile.Identifier; } }
        MasterProfile _PersonalMasterProfile;


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

        ///// <summary>
        ///// Add a device to the profile.
        ///// </summary>
        ///// <param name="DeviceProfile">The device profile to add</param>
        //public void AddAdministrative(SignedDeviceProfile DeviceProfile) {
        //    AdministrationProfile.AddDevice(DeviceProfile);
        //    SignedAdministrationProfile = new SignedAdministrationProfile(
        //                _AdministrationProfile, _PersonalMasterProfile);
        //    }

        /// <summary>
        /// Add an application to the profile
        /// </summary>
        /// <param name="ApplicationProfile">The application profile to add.</param>
        public void Add(ApplicationProfile ApplicationProfile) {

            var ApplicationProfileEntry = new ApplicationProfileEntry();

            Applications.Add(ApplicationProfileEntry);
            }




        //public override void Package() {
        //    foreach (var Application in Applications) {
        //        Application.Package();
        //        }
        //    }


        public ApplicationProfileEntry GetApplication(string Type) {
            foreach (var App in Applications) {
                if (App.Type == Type) {
                    return App;
                    }
                }
            return null;

            }

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

        public ApplicationProfileEntry GetPasswordProfile () {
            var Profile = GetApplication(typeof(PasswordProfile).Name);
            return Profile;
            }

        public ApplicationProfileEntry GetNetworkProfile() {
            var Profile = GetApplication(typeof(NetworkProfile).Name);
            return Profile;
            }

        public ApplicationProfileEntry GetMailProfile() {
            var Profile = GetApplication(typeof(MailProfile).Name);
            return Profile;
            }

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

        //AdministrationProfile GetAdministrationProfile() {
        //    var AdminProfile = GetApplication(typeof(AdministrationProfile), Constants.AdminKey);
        //    return AdminProfile as AdministrationProfile;
        //    }


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

    }
