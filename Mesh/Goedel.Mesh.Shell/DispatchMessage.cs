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
                var recipient = Options.Recipient.Value;

                var message = new RequestContact() {
                    Recipient = recipient,
                    Reply = true
                    };

                contextAccount.SendMessage(message);


                var result = new ResultSent() {
                    Success = true,
                    Message = message
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
            using (var contextAccount = GetContextAccount(Options)) {
                var recipient = Options.Recipient.Value;
                var text = Options.Text.Value;

                var message = new RequestConfirmation() {
                    Recipient = recipient,
                    Text = text
                    };

                contextAccount.SendMessage(message);


                var result = new ResultSent() {
                    Success = true,
                    Message = message
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

            using (var contextAccount = GetContextAccount(Options)) {

                contextAccount.Sync();

                // get the inbound spool
                var inbound = contextAccount.GetSpoolInbound();

                var messages = new List<Message>();
                var completed = new Dictionary<string, Message>();

                foreach (var message in inbound.Select(1, true)) {
                    var meshMessage = Message.FromJSON(message.GetBodyReader());
                    if (!completed.ContainsKey(meshMessage.MessageID)) {
                        switch (meshMessage) {
                            case MessageComplete meshMessageComplete: {
                                foreach (var reference in meshMessageComplete.References) {
                                    completed.Add(reference.MessageID, meshMessageComplete);
                                    }
                                break;
                                }
                            default: {
                                messages.Add(meshMessage);
                                break;
                                }
                            }
                        }
                    }

                var result = new ResultPending() {
                    Success = true,
                    Messages = messages
                    };

                return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageStatus(MessageStatus Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new ResultSent() {

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
        public override ShellResult MessageAccept(MessageAccept Options) =>
            Process(Options, Options.RequestID.Value, true);

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageReject(MessageReject Options) =>
            Process(Options, Options.RequestID.Value, false);


        ShellResult Process (IAccountOptions options, string requestid, bool accept) {
            using (var contextAccount = GetContextAccount(options)) {

                var recipient = "alice@example.com";
                // Hack: Need to pull the message off the spool here and see what type it is,
                // then respond.


                var message = new ResponseConfirmation() {
                    Recipient = recipient,
                    Accept = accept
                    };

                contextAccount.SendMessage(message);

                var result = new ResultSent() {
                    Success = true,
                    Message = message
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

                var result = new ResultSent() {

                    };
                return result;
                }
            }


        }
    }
