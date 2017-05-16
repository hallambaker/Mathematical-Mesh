using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Cryptography.KeyFile;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSH (SSH Options) {
            SetReporting(Options);
            var RegistrationPersonal = GetPersonal(Options);
            RegistrationPersonal.CreateSSH();

            //var SSHProfile = new SSHProfile(true);
            //Register(RegistrationPersonal, SSHProfile);


            // NYI: Here a hook to 'This device' entry
            // Write out the files id_rsa, id_rsa.pub
            }

        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSHKnown (SSHKnown Options) {
            SetReporting(Options);
            var RegistrationApplication = GetApplication(Options, "SSHProfile");
            var SSHProfile = RegistrationApplication?.ApplicationProfile as SSHProfile;
            Assert.NotNull(SSHProfile, ProfileNotFound.Throw);

            var Private = SSHProfile.Private;

            var DecryptedDevicePrivate = SSHProfile.DecryptedDevicePrivate;

            Assert.NotNull(Private, ProfileNotReadable.Throw);
            foreach (var Host in Private.HostEntries) {
                Report("Host {0}", Host.Identifier);
                }



            }


        /// Create a list of SSH authorized keys from the Mesh profile
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSHAuth (SSHAuth Options) {
            SetReporting(Options);
            var RegistrationApplication = GetApplication(Options, "SSHProfile");
            var SSHProfile = RegistrationApplication?.ApplicationProfile as SSHProfile;
            Assert.NotNull(SSHProfile, ProfileNotFound.Throw);

            foreach (var Device in SSHProfile.Devices) {
                Report("Authorize {0}", Device.Identifier);
                }


            }

        /// Write out the SSH public key for this device
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSHPublic (SSHPublic Options) {
            SetReporting(Options);
            var RegistrationApplication = GetApplication(Options, "SSHProfile");
            var SSHProfile = RegistrationApplication?.ApplicationProfile as SSHProfile;
            Assert.NotNull(SSHProfile, ProfileNotFound.Throw);

            // Get the device specific data

            // NYI: We need an identifier to specify which device key was used to 
            // decrypt the profile.

            // Dump the public key corresponding to the device.

            }

        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSHPrivate (SSHPrivate Options) {
            SetReporting(Options);
            var RegistrationApplication = GetApplication(Options, "SSHProfile");
            var SSHProfile = RegistrationApplication?.ApplicationProfile as SSHProfile;
            Assert.NotNull(SSHProfile, ProfileNotFound.Throw);

            // Get the device specific data

            // Dump the private key corresponding to the device.

            }

        }
    }
