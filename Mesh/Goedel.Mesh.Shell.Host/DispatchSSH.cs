using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddHost(SSHAddHost options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddClient(SSHAddClient options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHCreate(SSHCreate options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHKnown(SSHKnown options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAuth(SSHAuth options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPrivate(SSHPrivate options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPublic(SSHPublic options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }
        }
    }
