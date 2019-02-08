using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MailAdd(MailAdd Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                throw new NYI();
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MailUpdate(MailUpdate Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                throw new NYI();
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SMIMEPrivate(SMIMEPrivate Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                throw new NYI();
                }
            }
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SMIMEPublic(SMIMEPublic Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                throw new NYI();
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PGPPrivate(PGPPrivate Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                throw new NYI();
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PGPPublic(PGPPublic Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                throw new NYI();
                }
            }
        }
    }
