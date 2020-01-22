using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddHost(SSHAddHost Options) {
            using var contextDevice = GetContextDevice(Options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddClient(SSHAddClient Options) {
            using var contextDevice = GetContextDevice(Options);
            throw new NYI();
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHCreate(SSHCreate Options) {
            using var contextDevice = GetContextDevice(Options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHKnown(SSHKnown Options) {
            using var contextDevice = GetContextDevice(Options);
            throw new NYI();
            }
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAuth(SSHAuth Options) {
            using var contextDevice = GetContextDevice(Options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPrivate(SSHPrivate Options) {
            using var contextDevice = GetContextDevice(Options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPublic(SSHPublic Options) {
            using var contextDevice = GetContextDevice(Options);
            throw new NYI();
            }
        }
    }
