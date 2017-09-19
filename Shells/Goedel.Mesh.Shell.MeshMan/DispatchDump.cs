using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {
    public partial class Shell {
        /// <summary>
        /// Write out the current personal profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Dump (Dump Options) {
            SetReporting(Options);
            var RegistrationPersonal = GetPersonal(Options);

            Report(RegistrationPersonal, true);
            }



        /// <summary>
        /// Report the profiles registered to the current machine.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void List (List Options) {
            SetReporting(Options);

            Report("Personal Profiles");
            foreach (var Registration in Machine.PersonalProfilesUDF) {
                Report(Registration.Value, false);
                }
            Report("Device Profiles"); 
            foreach (var Registration in Machine.DeviceProfiles) {
                Report(Registration.Value);
                }
            Report("Application Profiles");
            foreach (var Registration in Machine.ApplicationProfiles) {
                Report(Registration.Value);
                }
            }

        void Report (SessionPersonal Registration, bool Detail) {
            var SignedPersonalProfile = Registration.SignedPersonalProfile;
            var PersonalProfile = SignedPersonalProfile.PersonalProfile;

            var Identifier = PersonalProfile.Identifier ?? "<null>";
            var Updated = PersonalProfile.Updated.ToString() ?? "<null>";
            var UDF = PersonalProfile.UDF ?? "<null>";


            Report("Profile {0}", Identifier);
            Report("    UDF : {0}", UDF);
            Report("    Updated : {0}", Updated);

            ReportWrite("    PortalIDs :");
            foreach (var Portal in Registration.Portals) {
                ReportWrite(" ");
                ReportWrite(Portal);
                }
            Report("");

            if (!Detail) {
                return;
                }

            Report("Devices");
            foreach (var Device in PersonalProfile.Devices) {
                Report(Device.DeviceProfile);
                }

            Report("Applications");
            foreach (var ApplicationProfileEntry in PersonalProfile.Applications) {
                Report("    Type {0}, Friendly {1}", ApplicationProfileEntry.Type,
                        ApplicationProfileEntry.Friendly);
                Report("    Identifier: {0}", ApplicationProfileEntry.Identifier);
                Report("        Sign IDs: ", ApplicationProfileEntry.AdminDeviceUDF);
                Report("        Decrypt IDs: ", ApplicationProfileEntry.DecryptDeviceUDF);
                }

            }

        void Report (SessionApplication Registration) {
            Report(Registration.SignedApplicationProfile);
            }

        void Report (SignedApplicationProfile Application) {
            Report("    Profile {0}", Application.UDF);
            }

        void Report (RegistrationDevice Registration) {
            Report(Registration.DeviceProfile);
            }

        void Report (DeviceProfile Device) {
            Report("    Profile {0}", Device.UDF);
            Report("        Description {0}", Device.Description);
            foreach (var Name in Device.Names) {
                Report("        Name {0}", Name);
                }
            }



        }
    }
