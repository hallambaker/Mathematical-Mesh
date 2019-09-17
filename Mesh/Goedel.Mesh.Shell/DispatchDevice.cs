using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Mesh.Client;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceRequestConnect(DeviceRequestConnect Options) {
            var serviceID = Options.ServiceID.Value;
            var pin = Options.PIN.Value;
            var contextMeshPending = MeshMachine.Connect(serviceID, PIN:pin);

            var result = new ResultConnect() {
                CatalogedMachine = contextMeshPending.CatalogedMachine
                };

            return result;
            }


        public override ShellResult DevicePending(DevicePending Options) {
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



        public override ShellResult DeviceAccept(DeviceAccept Options) =>
            ProcessRequest(Options, Options.CompletionCode.Value, true);

        public override ShellResult DeviceReject(DeviceReject Options) =>
            ProcessRequest(Options, Options.CompletionCode.Value, false);


        ShellResult ProcessRequest(IAccountOptions Options, string messageID, bool accept) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new ResultConnectProcess() {

                    };
                "".TaskFunctionality();
                return result;
                }


            }

        #region // dead code??

        //using (var contextDevice = GetContextDevice(Options)) {
        //    contextDevice.Sync();

        //    var messageConnectionRequest = GetConnectionRequest(contextDevice, messageID);
        //    messageConnectionRequest.AssertNotNull();

        //    contextDevice.ProcessConnectionRequest(messageConnectionRequest, accept);

        //    return new ResultConnectProcess() {
        //        Success = true,
        //        Accepted = accept,
        //        Witness = messageConnectionRequest.Witness
        //        };
        //    }


        //using (var contextDevice = GetContextDevice(Options)) {

        //    // sync
        //    contextDevice.Sync();

        //    var messages = new List<MeshMessage>();
        //    var result = new ResultPending() {
        //        Success = true,
        //        Messages = messages
        //        };

        //    // get the inbound spool
        //    var completed = new Dictionary<string, MeshMessage>();

        //    foreach (var message in contextDevice.SpoolInbound.Select(1, true)) {
        //        var meshMessage = MeshMessage.FromJSON(message.GetBodyReader());
        //        if (!completed.ContainsKey(meshMessage.MessageID)) {
        //            switch (meshMessage) {
        //                case MeshMessageComplete meshMessageComplete: {
        //                    foreach (var reference in meshMessageComplete.References) {
        //                        completed.Add(reference.MessageID, meshMessageComplete);
        //                        }
        //                    break;
        //                    }
        //                default: {
        //                    messages.Add(meshMessage);
        //                    break;
        //                    }
        //                }
        //            }
        //        }
        //    return result;
        //    }


        //MessageConnectionRequest GetConnectionRequest(
        //        ContextAccount contextDevice,
        //        string messageID) {
        //    contextDevice.Sync();
        //    var completed = new Dictionary<string, MeshMessage>();

        //    foreach (var message in contextDevice.SpoolInbound.Select(1, true)) {
        //        var meshMessage = MeshMessage.FromJSON(message.GetBodyReader());
        //        if (!completed.ContainsKey(meshMessage.MessageID)) {
        //            switch (meshMessage) {
        //                case MeshMessageComplete meshMessageComplete: {
        //                    foreach (var reference in meshMessageComplete.References) {
        //                        completed.Add(reference.MessageID, meshMessageComplete);
        //                        }
        //                    break;
        //                    }
        //                case MessageConnectionRequest messageConnectionRequest: {
        //                    if (messageConnectionRequest.Witness == messageID |
        //                            messageConnectionRequest.MessageID == messageID) {
        //                        return messageConnectionRequest;

        //                        }

        //                    break;
        //                    }

        //                }
        //            }
        //        }

        //    throw new NYI();
        //}

        #endregion


        public override ShellResult DeviceDelete(DeviceDelete Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                }
            }
        public override ShellResult DeviceList(DeviceList Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                "".TaskFunctionality();
                return result;
                }
            }

        public override ShellResult DeviceAuthorize(DeviceAuthorize Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new ResultAuthorize() {

                    };
                "".TaskFunctionality();
                return result;
                }
            }

        }
    }
