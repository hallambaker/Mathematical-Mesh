using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MailAdd(MailAdd options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MailUpdate(MailUpdate options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MailList(MailList options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SMIMEPrivate(SMIMEPrivate options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SMIMEPublic(SMIMEPublic options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PGPPrivate(PGPPrivate options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PGPPublic(PGPPublic options) {
            using var contextDevice = GetContextDevice(options);
            throw new NYI();
            }
        }
    }
