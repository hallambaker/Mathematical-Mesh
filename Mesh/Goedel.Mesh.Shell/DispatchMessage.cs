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
            var identifier = Options.Recipient.Value;
            using (var context = GetContextDevice(Options)) {
                var contactCatalog = context.GetCatalogContact();
                //var contact = contactCatalog.LocateByID(context.AccountName);

                //var post = context.ContactRequest(identifier, contact.Contact);

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
        public override ShellResult MessageConfirm(MessageConfirm Options) {
            var identifier = Options.Recipient.Value;
            var text = Options.Text.Value;
            using (var context = GetContextDevice(Options)) {
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
        public override ShellResult MessagePending(MessagePending Options) {
            using (var context = GetContextDevice(Options)) {

                throw new NYI();

                //var r1 = context.Sync();
                //if (r1.Error) {
                //    return new Result("Request failed");
                //    }


                //var result = new ResultPending() {
                //    Messages = new List<MeshMessage>()
                //    };

                //foreach (var message in context.SpoolInbound.Select(1)) {
                //    }

                //return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageStatus(MessageStatus Options) {
            var identifier = Options.RequestID.Value;
            using (var context = GetContextDevice(Options)) {
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
        public override ShellResult MessageAccept(MessageAccept Options) {
            var identifier = Options.RequestID.Value;
            using (var context = GetContextDevice(Options)) {
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
        public override ShellResult MessageReject(MessageReject Options) {
            var identifier = Options.RequestID.Value;
            using (var context = GetContextDevice(Options)) {
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
            var identifier = Options.RequestID.Value;
            using (var context = GetContextDevice(Options)) {
                var result = new Result() {

                    };
                return result;
                }
            }


        }
    }
