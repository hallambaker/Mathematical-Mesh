using System;
using System.Collections.Generic;

using Goedel.Mesh;

using Goedel.Trojan;
using Goedel.Trojan.GTK;


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
            RegistrationMachine = new RegistrationMachine();


            foreach (var PersonalProfile in RegistrationMachine.Personals) {
                var DisplayProfile = new Profile(PersonalProfile);
                Selector.Add(DisplayProfile);
                }

            foreach (var DeviceProfile in RegistrationMachine.Devices) {
                var DisplayProfile = new Profile(DeviceProfile);
                Selector.Add(DisplayProfile);
                }

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




        public override void ApplicationAddWizard(Object Profile) {
            }



        }



    public partial class EscrowParameters {
        public EscrowParameters() {
            Shares.Maximum = 16;
            Shares.Minimum = 2;
            Quorum.Maximum = 16;
            Quorum.Minimum = 2;
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




    }




