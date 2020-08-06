using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageContact(MessageContact Options) {
            var contextAccount = GetContextAccount(Options);
            var recipient = Options.Recipient.Value;

            var message = contextAccount.ContactRequest(recipient);

            var result = new ResultSent() {
                Success = true,
                Message = message
                };
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageConfirm(MessageConfirm Options) {
            var contextAccount = GetContextAccount(Options);
            var recipient = Options.Recipient.Value;
            var text = Options.Text.Value;

            var message = contextAccount.ConfirmationRequest(recipient, text);

            var result = new ResultSent() {
                Success = true,
                Message = message
                };

            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessagePending(MessagePending Options) {

            var contextAccount = GetContextAccount(Options);

            // this is failing to read in the inbound messages as it should.
            // The 


            contextAccount.Sync();

            // get the inbound spool
            var inbound = contextAccount.GetSpoolInbound();

            var messages = new List<Message>();
            var completed = new Dictionary<string, Message>();

            foreach (var message in inbound.Select(1, true)) {
                var meshMessage = Message.FromJson(message.GetBodyReader());
                if (!completed.ContainsKey(message.Header.ContentMeta.UniqueID)) {
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

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageStatus(MessageStatus Options) {
            var contextAccount = GetContextAccount(Options);
            var result = new ResultSent() {

                };
            throw new NYI();
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


        ShellResult Process(IAccountOptions options, string requestid, bool accept) {
            var contextAccount = GetContextAccount(options);
            var processResult = contextAccount.Process(requestid, accept);


            var result = new ResultSent() {
                Success = true
                };
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageBlock(MessageBlock Options) {
            var contextAccount = GetContextAccount(Options);
            var result = new ResultSent() {

                };
            return result;
            }


        }
    }
