﻿using Goedel.Mesh.Client;
using Goedel.Utilities;

using System.Collections.Generic;
using System;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceRequestConnect(DeviceRequestConnect options) {
            var accountAddress = options.AccountAddress.Value;
            var pin = options.PIN.Value;


            var rights = GetRights(options);

            var contextMeshPending = MeshHost.Connect(accountAddress, pin: pin, rights: rights);

            var result = new ResultConnect() {
                CatalogedMachine = contextMeshPending.CatalogedMachine,
                RequestConnection = contextMeshPending.RequestConnection,
                AcknowledgeConnection = contextMeshPending.AcknowledgeConnection
                };

            return result;
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceJoin(DeviceJoin options) {
            var uri = options.Uri.Value;

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceInstall(DeviceInstall options) {
            var filename = options.Profile.Value;

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceComplete(DeviceComplete options) {
            var accountAddress = options.AccountAddress .Value;

            // here need to pull up an account context for the pending connection.

            var contextUser = MeshHost.Complete(accountAddress);
            var result = new ResultConnect() {
                CatalogedMachine = contextUser.CatalogedMachine,
                Profile = contextUser.Profile,

                ActivationDevice = contextUser.ActivationDevice,
                RequestConnection = contextUser.RequestConnection,
                ActivationAccount = contextUser.ActivationAccount,
                RespondConnection = contextUser.RespondConnection
                };

            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DevicePending(DevicePending options) {
            var contextAccount = GetContextUser(options);
            contextAccount.Sync();

            // get the inbound spool
            var inbound = contextAccount.GetSpoolInbound();

            var messages = new List<Message>();
            var completed = new Dictionary<string, Message>();

            foreach (var message in inbound.Select(1, true)) {
                var meshMessage = Message.FromJson(message.GetBodyReader());
                if (!completed.ContainsKey(meshMessage.MessageId)) {
                    switch (meshMessage) {
                        case MessageComplete meshMessageComplete: {
                            foreach (var reference in meshMessageComplete.References) {
                                completed.Add(reference.MessageId, meshMessageComplete);
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
        public override ShellResult DeviceAccept(DeviceAccept options) {
            var rights = GetRights(options);
            return ProcessRequest(options, options.CompletionCode.Value, true, rights);
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceReject(DeviceReject options) =>
            ProcessRequest(options, options.CompletionCode.Value, false);

        ShellResult ProcessRequest(IAccountOptions options, string messageID, bool accept,
                List<string> rights=null) {
            var contextAccount = GetContextUser(options);


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
            var processResult = contextAccount.Process(message, accept, rights: rights);

            // Hack: need to obtain the actual result.
            var result = new ResultProcess() {
                ProcessResult = processResult as Message
                };
            return result;


            }




        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DevicePreconfigure(DevicePreconfigure options) {
            using var contextAccount = GetContextUser(options);

            var devicePreconfiguration = contextAccount.Preconfigure(
                out var filename, out var profileDevice, out var connectUri);

            var result = new ResultPublishDevice() {
                Uri = connectUri,
                ProfileDevice = profileDevice,
                FileName = filename,
                DevicePreconfiguration = devicePreconfiguration
                };
            "".TaskFunctionality();
            return result;
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceDelete(DeviceDelete options) {
            var contextAccount = GetContextUser(options);
            var deviceID = options.DeviceID.Value;

            contextAccount.DeleteDevice(deviceID);

            var result = new Result() {

                };
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceList(DeviceList options) {
            var contextAccount = GetContextUser(options);
            var result = new Result() {

                };
            "".TaskFunctionality();
            return result;
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceAuthorize(DeviceAuthorize options) {
            var contextAccount = GetContextUser(options);
            var rights = GetRights(options);




            var result = new ResultAuthorize() {

                };
            "Modify rights of existing device".TaskFunctionality();
            return result;
            }



        }
    }
