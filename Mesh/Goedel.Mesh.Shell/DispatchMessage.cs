using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageContact(MessageContact options) {
            var contextAccount = GetContextUser(options);
            var recipient = options.Recipient.Value;

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageConfirm(MessageConfirm options) {
            var contextAccount = GetContextUser(options);
            var recipient = options.Recipient.Value;
            var text = options.Text.Value;

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessagePending(MessagePending options) {

            var contextAccount = GetContextUser(options);

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageStatus(MessageStatus options) {
            var contextAccount = GetContextUser(options);
            var result = new ResultSent() {

                };
            throw new NYI();
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageAccept(MessageAccept options) =>
            Process(options, options.RequestID.Value, true);

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageReject(MessageReject options) =>
            Process(options, options.RequestID.Value, false);


        ShellResult Process(IAccountOptions options, string requestid, bool accept) {
            var contextAccount = GetContextUser(options);
            var processResult = contextAccount.Process(requestid, accept);


            var result = new ResultSent() {
                Success = true
                };
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MessageBlock(MessageBlock options) {
            var contextAccount = GetContextUser(options);
            var result = new ResultSent() {

                };
            return result;
            }


        }
    }
