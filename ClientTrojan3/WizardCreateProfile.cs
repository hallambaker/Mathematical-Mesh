using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Mesh;
using Goedel.Trojan;


namespace PHB.Apps.Mesh.ProfileManager {

    public partial class ProfileManager {
        MeshClient MeshClient = null;

        public MeshClient GetCachedClient(string Portal) {
            if (MeshClient?.Portal == Portal) {
                return MeshClient;
                }

            try {
                return new MeshClient(Portal);
                }
            catch {
                return null;
                }
            }

        }



    public partial class NameDevice {
        public string Gotit = "no";
        ProfileManager ProfileManager { get { return Model as ProfileManager; } }

        public override void Initialize(Wizard Wizard) {
            base.Initialize(Wizard.Model);

            // Here try to pull a machine name from the environment variables
            DeviceName.Value = Goedel.Platform.Environment.MachineName;

            // Here look to see if we already have a device profile
            if (ProfileManager.RegistrationMachine.Device == null) {
                NewDeviceProfile.Value = true;
                NewDeviceProfile.ReadOnly = true;
                Gotit = "Yep";
                }
            }

        public override bool Valid() {
            bool Result = base.Valid();

            if (DeviceName.Test.Length <= 0) {
                Result = false;
                DeviceName.ReasonInvalid = "Device name cannot be empty";
                }

            // default the description to the device name.
            if (DeviceDescription.Test.Length <= 0) {
                DeviceDescription.Test = DeviceName.Test;
                }
            return Result;
            }

        }





    public partial class CreateProfile {

        ProfileManager ProfileManager { get { return Model as ProfileManager; } }
        WizardCreateProfile WizardCreateProfile { get { return Wizard as WizardCreateProfile; } }

        public override void Initialize(Wizard Wizard) {
            this.Wizard = Wizard;
            PortalAddress.Value = "mesh.prismproof.org";

            }


        public override bool Dispatch(Wizard Wizard) {
            this.Wizard = Wizard;

            //WizardCreateProfile.StartTaskPersonalProfile(); // start the profile creation task


            return true;
            }


        public override bool Valid() {
            bool Result = true;

            if (PortalAccount.Test.Length <= 0) {
                Result = false;
                PortalAccount.ReasonInvalid = "Portal account name cannot be empty";
                }

            if (PortalAddress.Test.Length <= 0) {
                Result = false;
                PortalAddress.ReasonInvalid = "Portal address cannot be empty";
                }

            // Check the account name for validity if there is a non zero portal address and account name.
            if (Result) {
                var MeshClient = ProfileManager.GetCachedClient(PortalAddress.Test);

                if (MeshClient == null) {
                    PortalAddress.ReasonInvalid = "Portal cannot be reached. Check address and network connection";
                    }
                else {
                    var Validation = MeshClient.Validate(PortalAccount.Test);
                    if (!Validation.Valid) {
                        Result = false;
                        PortalAddress.ReasonInvalid = Validation.Reason;
                        }
                    }
                }

            if (FriendlyName.Test.Length <= 0) {
                FriendlyName.Test = PortalAccount.Test + "@" + PortalAddress.Test;
                }


            return Result;
            }

        }

    public partial class SelectApplications {

        // The dialogs for each of the commands
        public WebOptions WebOptions;

        public override bool Dispatch() {
            return base.Dispatch();
            }
        }




    public partial class Review {
        ProfileManager ProfileManager { get { return Model as ProfileManager; } }
        WizardCreateProfile WizardCreateProfile { get { return Wizard as WizardCreateProfile; } }

        public override void Initialize(Wizard Wizard) {
            this.Wizard = Wizard;

            // here we perform all the necessary profile building, etc.

            WizardCreateProfile.Calculate();


            var PersonalProfile = WizardCreateProfile.PersonalProfile;
            FriendlyName.Value = WizardCreateProfile.FriendlyName;
            Fingerprint.Value = PersonalProfile.UDF;
            Fingerprint.Length = 64;
            MeshAddress.Value = WizardCreateProfile.MeshAddress;
            MeshAddress.Length = 64;

            Escrow.Value = WizardCreateProfile.EscrowKeys;
            Quorum.Value = WizardCreateProfile.EscrowQuorum;
            Shares.Value = WizardCreateProfile.EscrowKeyShares;

            if (WizardCreateProfile.WebApplicationProfile) {
                WebApplication.Value = true;
                Passwords.Value = WizardCreateProfile.WebApplicationPassword;
                Bookmarks.Value = WizardCreateProfile.WebApplicationBookmarks;
                }

            }


        public override bool Dispatch(Wizard Wizard) {
            return WizardCreateProfile.Save();
            }
        }


    public partial class CommitWizardCreateProfile {
        public override bool Dispatch() {
            return base.Dispatch();
            }
        }

    /// <summary>
    /// The profile creation wizard
    /// </summary>
    public partial class WizardCreateProfile {
        ProfileManager ProfileManager { get { return Model as ProfileManager; } }

        public string DeviceName { get { return NameDevice.DeviceName.Test; } }
        public string DeviceDescription { get { return NameDevice.DeviceDescription.Test; } }
        public bool NewDeviceProfile { get { return NameDevice.NewDeviceProfile.Test; } }

        public string PortalAddress { get { return CreateProfile.PortalAddress.Test; } }
        public string PortalAccount { get { return CreateProfile.PortalAccount.Test; } }
        public string FriendlyName { get { return CreateProfile.FriendlyName.Test; } }

        public string MeshAddress { get { return PortalAccount + "@" + PortalAddress; } }

        public bool EscrowKeys { get { return CreateProfile.Escrow.Test; } }
        public int EscrowQuorum { get { return CreateProfile.Quorum.Test; } }
        public int EscrowShares { get { return CreateProfile.Shares.Test; } }

        public bool WebApplicationProfile { get { return SelectApplications.WebOptions != null; } }
        public bool WebApplicationPassword { get { return SelectApplications.WebOptions.Passwords.Test; } }
        public bool WebApplicationBookmarks { get { return SelectApplications.WebOptions.Bookmarks.Test; } }


        public List<Goedel.Trojan.Object> EscrowKeyShares = null;

        SignedDeviceProfile _DeviceProfile;
        PersonalProfile _PersonalProfile;
        SignedPersonalProfile _SignedPersonalProfile;
        PasswordProfile PasswordProfile;
        SignedApplicationProfile SignedPasswordProfile;


        /// <summary>
        /// The device profile. This takes some time to generate and so the process is performed 
        /// asynchronously. If the task has not completed, the thread will wait for completion.
        /// </summary>
        public SignedDeviceProfile DeviceProfile {
            get {
                //TaskGetProfiles.Wait();
                return _DeviceProfile;
                }
            }

        /// <summary>
        /// The personal profile. This takes some time to generate and so the process is performed 
        /// asynchronously. If the task has not completed, the thread will wait for completion.
        /// </summary>
        public PersonalProfile PersonalProfile {
            get {
                //TaskGetProfiles.Wait();
                return _PersonalProfile;
                }
            }


        public WizardCreateProfile(Model Model) : base (Model) {
            }


        public bool Calculate() {

            if (NewDeviceProfile) {
                var NewProfile = new SignedDeviceProfile(DeviceName, DeviceDescription);
                _DeviceProfile = NewProfile;
                }
            else {
                _DeviceProfile = ProfileManager.RegistrationMachine.Device.Device;
                }
            _PersonalProfile = new PersonalProfile(_DeviceProfile);


            // Have got the profile, escrow the key
            if (EscrowKeys) {
                var OfflineEscrowEntry = new
                    OfflineEscrowEntry(_PersonalProfile, EscrowShares, EscrowQuorum);

                EscrowKeyShares = new List<Goedel.Trojan.Object>();

                int Index = 1;
                foreach (var KeyShare in OfflineEscrowEntry.KeyShares) {
                    var Share = new Share();
                    Share.Number.Value = Index++;
                    Share.Value.Value = KeyShare.Text;
                    EscrowKeyShares.Add(Share);
                    }
                }

            if (WebApplicationProfile) {
                PasswordProfile = new PasswordProfile(PersonalProfile);
                PasswordProfile.AddDevice(_DeviceProfile);
                }

            // Mail profiles here
            /*
                             foreach (var MailAccountInfo in MailAccountInfos) {
                                // Add in the S/MIME parameters and update the profile
                                //if (!MailAccountInfo.GotSMIME) {
                                    MailAccountInfo.GenerateSMIME();
                                    MailAccountInfo.Update();
                                    //}

                                var MailProfile = new MailProfile(UserProfile, MailAccountInfo);
                                MailProfile.AddDevice(ThisDevice);

                                //var SignedMailProfile = new SignedApplicationProfile(MailProfile);
                                MeshClient.Publish(MailProfile.Signed);
                                }
             * */

            // Network profiles here
            /*
                                var NetworkProfile = new NetworkProfile(UserProfile);
                                NetworkProfile.AddDevice(ThisDevice);
                                MeshClient.Publish(NetworkProfile.Signed);
            */

            // SSH profiles here


            SignedPasswordProfile = PasswordProfile.Signed;
            _SignedPersonalProfile = new SignedPersonalProfile(PersonalProfile);

            return true;
            }

        
        public bool Save() {
   
            if (NewDeviceProfile) {
                ProfileManager.RegistrationMachine.Add(_DeviceProfile);
                }
            ProfileManager.RegistrationMachine.Add(_SignedPersonalProfile, MeshAddress);
            ProfileManager.RegistrationMachine.Add(SignedPasswordProfile);

            var MeshClient = ProfileManager.GetCachedClient(PortalAddress);
            MeshClient.CreatePersonalProfile(MeshAddress, _SignedPersonalProfile);
            MeshClient.Publish(SignedPasswordProfile);

            return true;
            }

        //public override bool Dispatch() {
        //    // attach the new personal profile to the list of selected.


        //    //ProfileManager.RegistrationMachine.Add(DeviceProfile);

        //    //var SignedPersonalProfile = PersonalProfile.Signed;

        //    //ProfileManager.RegistrationMachine.Add(SignedPersonalProfile, MeshAddress);

        //    return true;
        //    }

        //public override void Exit () {
        //    CancellationTokenSource.Cancel();
        //    }


        //CancellationTokenSource CancellationTokenSource;
        //CancellationToken CancellationToken;
        //Task TaskGetProfiles = null;


        ///// <summary>
        ///// Called to start the generation of a personal profile. 
        ///// </summary>
        //public void StartTaskPersonalProfile() {
        //    if (TaskGetProfiles != null) {
        //        // We have a pending task, kill it.
        //        CancellationTokenSource.Cancel();
        //        }

        //    CancellationTokenSource = new CancellationTokenSource();
        //    CancellationToken = CancellationTokenSource.Token;
        //    TaskGetProfiles = Task.Run( () => AsyncGetProfiles(), CancellationToken);
        //    }


        /// <summary>
        /// The actual async task. Specified as a function as a lambda binding is 
        /// just too confusing in the code.
        /// </summary>
        void AsyncGetProfiles() {

            }



        }
    }
