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


        ///// <summary>
        ///// Dispatch method
        ///// </summary>
        ///// <param name="Options">The command line options.</param>
        ///// <returns>Mesh result instance</returns>
        //public override ShellResult DeviceCreate(DeviceCreate Options) {
        //    var context = ContextDevice.Generate(MeshMachine);

        //    return new ResultDeviceCreate() {
        //        Success = true,
        //        DeviceUDF = context.ProfileDevice.UDF,
        //        ProfileDevice = context.ProfileDevice,
        //        Default = context.DefaultDevice
        //        };

        //    }

        public override ShellResult DeviceAuthorize(DeviceAuthorize Options) {
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
        public override ShellResult DeviceRequestConnect(DeviceRequestConnect Options) {

            throw new NYI();

            //using (var contextAccount = GetContextAccount(Options)) {

            //    var result = new Result() {

            //        };
            //    throw new NYI();
            //    //return result;
            //    }

            }


        public override ShellResult DevicePending(DevicePending Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }

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
            }

        

        public override ShellResult DeviceAccept(DeviceAccept Options) =>
            ProcessRequest(Options, Options.CompletionCode.Value, true);

        public override ShellResult DeviceReject(DeviceReject Options) =>
            ProcessRequest(Options, Options.CompletionCode.Value, false);


        ShellResult ProcessRequest(IAccountOptions Options, string messageID, bool accept) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }

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
            }

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




        public override ShellResult DeviceEarl(DeviceEarl Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }
        }
    }
