using System;
using System.Collections.Generic;

using Goedel.Mesh;

using Goedel.Trojan;
using Goedel.Trojan.GTK;

using Goedel.Platform;
using Goedel.Mesh.Platform;


namespace PHB.Apps.Mesh.ProfileManager {
    public class Wrapper {
        static void Main(string[] args) {
            var Binding = new BindingGTK(); // Initialize the window system
            var ProfileManager = new ProfileManager(Binding);
            Binding.Run();
            }
        }


    public partial class ProfileManager {
        public RegistrationMachine RegistrationMachine;


        Binding Binding;
        Window MainWindow;

        /// <summary>
        /// Track state of the mesh connection.
        /// </summary>
        public List<MeshClient> MeshClients;


        public ProfileManager(Binding Binding) {

            // Here fill up the selection list with 
            // profiles, applications, devices
            Initialize();

            // Now create the window system
            this.Binding = Binding;
            MainWindow = new MainWindow(this, Binding);


            }



        public void Initialize() {
            // Get the current list of Mesh clients
            RegistrationMachine = RegistrationMachine.Current;


            //foreach (var PersonalProfile in RegistrationMachine.GetPersonal()) {
            //    var DisplayProfile = new Profile(PersonalProfile);
            //    Selector.Add(DisplayProfile);
            //    }

            //foreach (var DeviceProfile in RegistrationMachine.Devices) {
            //    var DisplayProfile = new Profile(DeviceProfile);
            //    Selector.Add(DisplayProfile);
            //    }


            Populate();
            }






        public void Populate() {
            var Profile1 = new Profile {
                Title = "Main Profile",
                };
            Profile1.Fingerprint.Value = "blahhhh";

            Selector.Add(Profile1);

            var Profile2 = new Profile {
                Title = "Site Profile"
                };
            Profile2.Fingerprint.Value = "More blahdy blah";
            Selector.Add(Profile2);


            Profile1.Devices.Value = new List<Goedel.Trojan.Object>();
            var Device1 = new Device {
                Title = "Voodoo" };
            Profile1.Devices.Value.Add(Device1);

            var Device2 = new Device {
                Title = "iPad" };
            Profile1.Devices.Value.Add(Device2);

            var Device3 = new Device {
                Title = "Router" };
            Profile1.Devices.Value.Add(Device3);


            }

        public override void Quit() {
            Binding.Quit();
            }


        public override void About() {
            Binding.About(_About);
            }


        // Fire up the wizards
        public override void ProfileCreate() {
            var Wizard = new WizardCreateProfile(this);
            Binding.Wizard(Wizard);
            }

        public override void ProfileEscrow(Object Profile) {
            var Dialog = new EscrowParameters();
            Binding.Dialog(Dialog);
            }



        /// <summary>
        ///Stub method for ConnectRefreshcommand.Override with application implementation.
        /// </summary>
 		public override void ConnectRefresh() {
            // Delete the list of pending requests

            // for each portal in the list
                // Request the list of pending requests
                // Update the selector

            }

        /// <summary>
        ///Stub method for ConnectAcceptcommand.Override with application implementation.
        /// </summary>
 		public override void ConnectAccept(Object Object) {
            }

        /// <summary>
        ///Stub method for ConnectRejectcommand.Override with application implementation.
        /// </summary>
 		public override void ConnectReject(Object Object) {
            }

        /// <summary>
        ///Stub method for ConnectGetOTCcommand.Override with application implementation.
        /// </summary>
 		public override void ConnectGetOTC() {
            }

        /// <summary>
        ///Stub method for DeviceDeletecommand.Override with application implementation.
        /// </summary>
 		public override void DeviceDelete(Object Object) {
            }

        /// <summary>
        ///Stub method for DeviceRefreshKeyscommand.Override with application implementation.
        /// </summary>
 		public override void DeviceRefreshKeys(Object Object) {
            }

        /// <summary>
        ///Stub method for ApplicationAddWizardcommand.Override with application implementation.
        /// </summary>
 		public override void ApplicationAddWizard(Object Object) {
            }

        /// <summary>
        ///Stub method for ApplicationAddMailcommand.Override with application implementation.
        /// </summary>
        public override void ApplicationAddMail(Object Profile) {
            var Dialog = new SelectAccountsEmail();
            //var Dialog = new ApplicationMail();

            //var Options = new List<string> {
            //    "RSA", "DH", "ECDH"
            //    };
            //Dialog.PGPAlgorithms.Options = Options;


            Binding.Dialog(Dialog);
            }

        /// <summary>
        ///Stub method for ApplicationAddSSHcommand.Override with application implementation.
        /// </summary>
 		public override void ApplicationAddSSH(Object Object) {
            var Dialog = new SSHOptions();
            Binding.Dialog(Dialog);
            }

        /// <summary>
        ///Stub method for ApplicationAddWiFicommand.Override with application implementation.
        /// </summary>
 		public override void ApplicationAddWiFi(Object Object) {
            var Dialog = new NetworkOptions();
            Binding.Dialog(Dialog);
            }

        /// <summary>
        ///Stub method for ApplicationAddWebcommand.Override with application implementation.
        /// </summary>
 		public override void ApplicationAddWeb(Object Object) {
            var SelectApplications = Object as SelectApplications;


            var Dialog = new WebOptions();

            if (SelectApplications != null) {
                SelectApplications.WebOptions = Dialog;
                }

            Binding.Dialog(Dialog);
            }

        /// <summary>
        ///Stub method for ApplicationDeletecommand.Override with application implementation.
        /// </summary>
 		public override void ApplicationDelete(Object Object) {
            }

        /// <summary>
        ///Stub method for ApplicationRefreshKeyscommand.Override with application implementation.
        /// </summary>
 		public override void ApplicationRefreshKeys(Object Object) {
            }

        /// <summary>
        ///Stub method for AdministratorAddcommand.Override with application implementation.
        /// </summary>
 		public override void AdministratorAdd(Object Object) {
            }

        /// <summary>
        ///Stub method for AdministratorRemovecommand.Override with application implementation.
        /// </summary>
 		public override void AdministratorRemove(Object Object) {
            }

        /// <summary>
        ///Stub method for KeyRefreshcommand.Override with application implementation.
        /// </summary>
 		public override void KeyRefresh() {
            }

        /// <summary>
        ///Stub method for KeyDeletecommand.Override with application implementation.
        /// </summary>
 		public override void KeyDelete() {
            }





        }



    public partial class EscrowParameters {

        /// <summary>
        /// Set up defaults
        /// </summary>
        public EscrowParameters() {
            Shares.Maximum = 16;
            Shares.Minimum = 2;
            Shares.Value = 3;
            Quorum.Maximum = 16;
            Quorum.Minimum = 2;
            Quorum.Value = 2;
            }

        public override bool Valid() {
            bool Result = base.Valid();

            if (Quorum.Test > Shares.Test) {
                Quorum.ReasonInvalid = 
                        "Quorum cannot be greater than the number of shares.";
                }

            return Result; 
            }

        public override bool Dispatch() {
            // Do the escrow bit here
            return true;
            }

        }


    public partial class SelectAccountsEmail {

        public SelectAccountsEmail() {
            Selection.Value = (int) EnumSelection.All;

            var Act1 = new EmailAccount();
            Act1.Address.Value = "Fred@example.com";
            Act1.Application.Value = "Windows Live Mail";
            Accounts.Value.Add(Act1);


            var Act2 = new EmailAccount();
            Act2.Address.Value = "Bob@minions.com";
            Act2.Application.Value = "Outlook";
            Accounts.Value.Add(Act2);

            }


        }

    }




