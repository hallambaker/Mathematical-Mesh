using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Mesh;
using Goedel.Debug;
using Goedel.Mesh.Platform;



namespace Goedel.Mesh.MeshMan {

    public partial class Shell {

        bool VerboseOutput = true;
        bool ReportOutput = true;

        private void SetReporting(Flag Report, Flag Verbose) {
            ReportOutput = Report.Value;
            VerboseOutput = Verbose.Value;
            }

        public void Verbose(string Text, params object[] Data) {
            if (VerboseOutput & ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void ReportWrite(string Text) {
            if (ReportOutput) {
                Console.Write(Text);
                }
            }

        public void Report(string Text, List<string> Items) {
            if (!ReportOutput) return;
            Console.Write(Text);
            foreach (var Item in Items) {
                Console.Write(" ");
                Console.Write(Item);
                }
            Console.WriteLine();
            }

        public void Report(string Text, params object[] Data) {
            if (ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void Report(string Text) {
            if (ReportOutput) {
                Console.WriteLine(Text);
                }
            }


        RegistrationPersonal RegistrationPersonal;
        SignedPersonalProfile SignedPersonalProfile;

        private void GetProfile(String Portal, String UDF) {

            RegistrationPersonal = Machine.Personal;
            Utilities.Assert(RegistrationPersonal, "No profile found");

            PortalID = RegistrationPersonal?.Portals?[0];
            Utilities.Assert(PortalID, "No portal ID known");

            SignedPersonalProfile = RegistrationPersonal.Profile;
            }


        // A placeholder routine. This should actually search
        // the profile to find a matching device profile that
        // is supported on the local machine.
        private SignedDeviceProfile GetDevice(SignedPersonalProfile Profile) {
            return Machine.Device.Device;
            }

        ApplicationProfileEntry PasswordEntry;
        RegistrationApplication PasswordRegistration;
        SignedApplicationProfile SignedApplicationWeb;
        PasswordProfile PasswordProfile;
        PasswordProfilePrivate PasswordProfilePrivate;

        private void GetPasswordProfile () {

            PasswordEntry = SignedPersonalProfile.Signed.GetApplicationEntryPassword(
                null);
            PasswordRegistration = Machine.Get(PasswordEntry);

            SignedApplicationWeb = PasswordRegistration.Profile;
            PasswordProfile = SignedApplicationWeb.Signed as PasswordProfile;
            PasswordProfile.Link (SignedPersonalProfile.Signed, PasswordEntry);
            PasswordProfilePrivate = PasswordProfile.Private;

            return;
            }

        private void UpdatePasswordProfile() {

            var NewSigned = PasswordProfile.Signed;

            PasswordRegistration.Profile = NewSigned;
            PasswordRegistration.Update();
            MeshClient.Publish(PasswordRegistration.Profile);
            return;
            }

        }
    }
