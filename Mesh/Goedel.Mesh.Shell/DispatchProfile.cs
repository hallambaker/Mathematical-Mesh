using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Mesh.Protocol.Client;
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
        public override ShellResult ProfileHello(ProfileHello Options) {
            var meshClient = GetMeshClient(Options);
            var jpcSession = GetJpcSession(Options);

            var helloRequest = new HelloRequest();
            var response = meshClient.Hello(helloRequest, jpcSession);

            return new ResultHello() {
                Success = true,
                Response = response
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult DeviceCreate(DeviceCreate Options) {
            var context = ContextDevice.Generate(MeshMachine);

            return new ResultDeviceCreate() {
                Success = true,
                DeviceUDF = context.ProfileDevice.UDF,
                Default = context.DefaultDevice
                };

            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MasterCreate(MasterCreate Options) {
            var context = GetContextDevice(Options);


            // Generate a new device context if none found
            context = context ?? ContextDevice.Generate(MeshMachine);
            var master = context.GenerateMaster();

            return new ResultMasterCreate() {
                Success = true,
                DeviceUDF = context.ProfileDevice.UDF,
                PersonalUDF = master.ProfileMaster.UDF,
                Default = master.DefaultDevice
                };
            }




        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ProfileSync(ProfileSync Options) {
            var context = GetContextDevice(Options);
            var result = context.Sync();

            return new ResultSync() {
                Success = true
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ProfileEscrow(ProfileEscrow Options) {
            var context = GetContextMaster(Options);
            (var escrow, var shares) = context.Escrow(3, 2);
            return new ResultEscrow() {
                Success = true
                };
            }

        void AddIfPresent(List<string> Keys, String Parameter) {
            if (Parameter.Value != null) {
                Keys.Add(Parameter.Value);
                }
            }

        
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ProfileRecover(ProfileRecover Options) {
            var context = GetContextDevice(Options);

            var recoverShares = new List<string>();
            AddIfPresent(recoverShares, Options.Share1);
            AddIfPresent(recoverShares, Options.Share2);
            AddIfPresent(recoverShares, Options.Share3);
            AddIfPresent(recoverShares, Options.Share4);

            AddIfPresent(recoverShares, Options.Share5);
            AddIfPresent(recoverShares, Options.Share6);
            AddIfPresent(recoverShares, Options.Share7);
            AddIfPresent(recoverShares, Options.Share8);

            var Escrow = new DareMessage(); // Hack, should read the escrow data from the service or file.

            var DeviceAdminRecovered = context.Recover(Escrow, recoverShares);
            return new ResultRecover() {
                Success = false
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ProfileConnect(ProfileConnect Options) {
            var context = GetContextDevice(Options);
            var portal = Options.Portal.Value;
            var pin = Options.PIN.Value;

            var result = context.RequestConnect(portal);

            return new ResultConnect() {
                Success = true
                };
            }

        public override ShellResult ProfileAccept(ProfileAccept Options) => base.ProfileAccept(Options);

        public override ShellResult ProfileReject(ProfileReject Options) => base.ProfileReject(Options);

        public override ShellResult ProfilePending(ProfilePending Options) => base.ProfilePending(Options);

        public override ShellResult ProfileGetPIN(ProfileGetPIN Options) => base.ProfileGetPIN(Options);

        public override ShellResult ProfileList(ProfileList Options) => base.ProfileList(Options);

        public override ShellResult ProfileDump(ProfileDump Options) => base.ProfileDump(Options);

        #region // Import and export of profiles - punt on this for now

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ProfileRegister(ProfileRegister Options) {
            var context = GetContextMaster(Options);

            return new ResultConnect() {
                Success = true
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ProfileExport(ProfileExport Options) => throw new NYI();


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ProfileImport(ProfileImport Options) => throw new NYI();

        #endregion
        }
    }
