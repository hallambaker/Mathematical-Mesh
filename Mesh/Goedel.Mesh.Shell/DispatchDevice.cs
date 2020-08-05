using Goedel.Mesh.Client;
using Goedel.Utilities;

using System.Collections.Generic;
using System;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceRequestConnect(DeviceRequestConnect Options) {
            var accountAddress = Options.AccountAddress.Value;
            var pin = Options.PIN.Value;
            var contextMeshPending = MeshHost.Connect(accountAddress, PIN: pin);

            var result = new ResultConnect() {
                CatalogedMachine = contextMeshPending.CatalogedMachine
                };

            var profileDevice = contextMeshPending.ProfileDevice;
            //Console.WriteLine($"KeyOfflineSignature {profileDevice.KeyOfflineSignature.UDF}");
            //Console.WriteLine($"KeyEncryption {profileDevice.KeyEncryption.UDF}");
            //Console.WriteLine($"KeyAuthentication {profileDevice.KeyAuthentication.UDF}");
            return result;
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceJoin(DeviceJoin Options) {
            var uri = Options.Uri.Value;

            var contextMeshPending = MeshHost.Join(uri);
            var result = new ResultConnect() {
                CatalogedMachine = contextMeshPending.CatalogedMachine
                };
            "".TaskFunctionality();
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceInstall(DeviceInstall Options) {
            var filename = Options.Profile.Value;

            var contextMeshPending = MeshHost.Install(filename);

            var result = new ResultConnect() {
                CatalogedMachine = contextMeshPending.CatalogedMachine
                };
            "".TaskFunctionality();
            return result;
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceComplete(DeviceComplete Options) {
            var accountAddress = Options.AccountAddress .Value;

            // here need to pull up an account context for the pending connection.

            var contextUser = MeshHost.Complete(accountAddress);
            var result = new ResultConnect() {
                CatalogedMachine = contextUser.CatalogedMachine
                };

            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DevicePending(DevicePending Options) {
            using var contextAccount = GetContextAccount(Options);
            contextAccount.Sync();

            // get the inbound spool
            var inbound = contextAccount.GetSpoolInbound();

            var messages = new List<Message>();
            var completed = new Dictionary<string, Message>();

            foreach (var message in inbound.Select(1, true)) {
                var meshMessage = Message.FromJson(message.GetBodyReader());
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


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceAccept(DeviceAccept Options) =>
            ProcessRequest(Options, Options.CompletionCode.Value, true);


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceReject(DeviceReject Options) =>
            ProcessRequest(Options, Options.CompletionCode.Value, false);

        ShellResult ProcessRequest(IAccountOptions Options, string messageID, bool accept) {
            using var contextAccount = GetContextAccount(Options);

            // Hack: should be able to accept, reject specific requests, not just
            // the last one.
            var message = contextAccount.GetPendingMessageByID(messageID, out var found);

            if (message == null) {
                if (found) {
                    // already processed
                    throw new NYI();
                    }
                else {
                    // Didn't receive that request
                    throw new NYI();
                    }
                }
            var processResult = contextAccount.Process(message, accept);

            // Hack: need to obtain the actual result.
            var result = new ResultProcess() {
                ProcessResult = processResult as Message
                };
            return result;


            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceDelete(DeviceDelete Options) {
            using var contextAccount = GetContextAccount(Options);
            var result = new Result() {

                };
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceList(DeviceList Options) {
            using var contextAccount = GetContextAccount(Options);
            var result = new Result() {

                };
            "".TaskFunctionality();
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceAuthorize(DeviceAuthorize Options) {
            using var contextAccount = GetContextAccount(Options);
            var result = new ResultAuthorize() {

                };
            "".TaskFunctionality();
            return result;
            }



        }
    }
