using Goedel.Debug;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void SSH(SSH Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();

            var DeviceProfile = GetDevice(SignedPersonalProfile);
            Utils.Assert(DeviceProfile, "Could not locate a device profile on this device");

            var PersonalProfile = SignedPersonalProfile.Signed;

            }
        }
    }
