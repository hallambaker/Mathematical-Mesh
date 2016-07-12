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

        public void Repor(string Text, List<string> Items) {
            if (!ReportOutput) return;
            Console.Write(Text);
            foreach (var Item in Items) {
                Console.Write(" ");
                Console.Write(Item);
                }
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

        RegistrationApplication RegistrationWeb;
        SignedApplicationProfile SignedApplicationWeb;
        PasswordProfile PasswordProfile;
        PasswordProfilePrivate PasswordProfilePrivate;

        private void GetPasswordProfile () {
            //RegistrationWeb = GetPasswordProfile();
            SignedApplicationWeb = RegistrationWeb.Profile;
            PasswordProfile = SignedApplicationWeb.Signed as PasswordProfile;
            PasswordProfilePrivate = PasswordProfile.Private;

            return;
            }

        private void UpdatePasswordProfile() {

            return;
            }

        }
    }
