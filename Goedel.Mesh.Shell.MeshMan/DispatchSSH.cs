using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSH(SSH Options) {
            SetReporting(Options);
            var RegistrationPersonal = GetPersonal(Options);

            var SSHProfile = new SSHProfile(true);

            // Add the application to the personal profile.
            // By default we add all the admin devices for the personal profile to be admin for 
            // the app profile.
            var RegistrationApplication = RegistrationPersonal.Add(SSHProfile, false);

            // Add this device to the registration in the personal profile.
            var DeviceProfile = RegistrationPersonal.PersonalProfile.DeviceProfile;
            RegistrationApplication.AddDevice(DeviceProfile, Administration: true);

            RegistrationPersonal.Write();
            RegistrationApplication.Write();
            }
        }
    }
