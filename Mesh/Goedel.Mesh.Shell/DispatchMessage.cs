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
        public override ShellResult MessageContact(MessageContact Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageConfirm(MessageConfirm Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessagePending(MessagePending Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageStatus(MessageStatus Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageAccept(MessageAccept Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageReject(MessageReject Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageBlock(MessageBlock Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                return result;
                }
            }


        }
    }
