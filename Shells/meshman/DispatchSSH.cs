using Goedel.Utilities;
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
            Assert.NotNull(DeviceProfile, NoDeviceProfile.Throw);

            var PersonalProfile = SignedPersonalProfile.Signed;

            }
        }
    }
