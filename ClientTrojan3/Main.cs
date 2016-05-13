using System;
using System.Collections.Generic;
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
        Binding Binding;
        Window MainWindow;

        public ProfileManager(Binding Binding) {

            // Here fill up the selection list with 
            // profiles, applications, devices
            Populate();

            // Now creat the window system
            this.Binding = Binding;
            MainWindow = new MainWindow(this, Binding);


            }



        public void Populate() {
            var Profile1 = new Profile {
                Title = "Main Profile",
                Fingerprint = "blahdy blah" };
            Selector.Add(Profile1);

            var Profile2 = new Profile {
                Title = "Site Profile",
                Fingerprint = "More blahdy blah"
                };
            Selector.Add(Profile2);


            Profile1.Devices = new List<Goedel.Trojan.Object>();
            var Device1 = new Device {
                Title = "Voodoo" };
            Profile1.Devices.Add(Device1);

            var Device2 = new Device {
                Title = "iPad"};
            Profile1.Devices.Add(Device2);

            var Device3 = new Device {
                Title = "Router"};
            Profile1.Devices.Add(Device3);


            }

        public override void Quit() {
            Binding.Quit();
            }


        public override void About() {
            Binding.About(_About);
            }


        public override void CreateProfile() {

            var Wizard = new WizardCreateProfile();
            Binding.Wizard(Wizard);

            }

        public override void CreateApplication() {
            }

        public override void CreateEscrow() {
            }



        }




    }




