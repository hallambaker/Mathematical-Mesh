using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {




        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult EarlDevice(EarlDevice Options) {
            using var contextAccount = GetContextAccount(Options);

            contextAccount.CreateDeviceEarl(
                    out var secretSeed, 
                    out var profileDevice,
                    out var connectKey,
                    out var connectUri);

            var filename = connectKey + ".medk";
            var devicePreconfiguration = new DevicePreconfiguration(secretSeed, connectUri);


            devicePreconfiguration.ToFile(filename, tagged: true);

            var result = new ResultPublishDevice() {
                Uri = connectUri,
                ProfileDevice = profileDevice,
                FileName = filename,
                };
            "".TaskFunctionality();
            return result;
            }




        }
    }
