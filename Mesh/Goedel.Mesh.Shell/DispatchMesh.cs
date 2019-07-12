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
        public override ShellResult MeshCreate(MeshCreate Options) {
            var account = Options.NewAccountID.Value;

            using (var contextMesh = MeshMachine.CreateMesh("main")) {

                if (account != null) {
                    var contextAccount = contextMesh.CreateAccount(account);
                    }

                return new ResultCreatePersonal() {
                    Success = true,
                    ProfilePersonal = contextMesh.ProfileMesh,
                    CatalogedDevice = contextMesh.CatalogedDevice,
                    MeshUDF = contextMesh.ProfileMesh.UDF,
                    DeviceUDF = contextMesh.CatalogedDevice.UDF
                    };
                }
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshEscrow(MeshEscrow Options) {
            using (var contextMesh = GetContextMeshAdmin(Options)) {
                var file = Options.File.Value ?? contextMesh.ProfileMesh.UDF + ".escrow";

                (var escrow, var shares) = contextMesh.Escrow(3, 2);
                escrow.ToFile(file);
                var textShares = new List<string>();
                foreach (var share in shares) {
                    textShares.Add(share.UDFKey);
                    }

                return new ResultEscrow() {
                    Success = true,
                    Shares = textShares,
                    Filename = file
                    };
                }
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
        public override ShellResult MeshRecover(MeshRecover Options) {
            var file = Options.File.Value;
            
            var recoverShares = new List<string>();
            AddIfPresent(recoverShares, Options.Share1);
            AddIfPresent(recoverShares, Options.Share2);
            AddIfPresent(recoverShares, Options.Share3);
            AddIfPresent(recoverShares, Options.Share4);

            AddIfPresent(recoverShares, Options.Share5);
            AddIfPresent(recoverShares, Options.Share6);
            AddIfPresent(recoverShares, Options.Share7);
            AddIfPresent(recoverShares, Options.Share8);
            var secret = new Secret(recoverShares);

            DareEnvelope escrow = null;

            if (file != null) {
                "convert file to encrypted data".TaskFunctionality();
                }
            else {
                "Pull encrypted escrow data from service".TaskFunctionality();
                }


            using (var contextMesh = ContextMeshAdmin.RecoverMesh(
                MeshMachine, secret, escrow: escrow)) {

                "recover subordinate accounts, etc.".TaskFunctionality();
                return new ResultRecover() {
                    Success = true,
                    ProfilePersonal = contextMesh.ProfileMesh,
                    CatalogedDevice = contextMesh.CatalogedDevice,
                    MeshUDF = contextMesh.ProfileMesh.UDF,
                    DeviceUDF = contextMesh.CatalogedDevice.UDF
                    };
                }
            }

        #region // Data dump, import and export of profiles - punt on this for now

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshList(MeshList Options) {
            var catalogedMachines = new List<CatalogedMachine> ();
            "extract hosts from machine".TaskFunctionality();

            return new ResultMachine() {
                Success = true,
                CatalogedMachines = catalogedMachines
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshGet(MeshGet Options) {
            var catalogedMachines = new List<CatalogedMachine>();

            "select default host".TaskFunctionality();

            return new ResultMachine() {
                Success = true,
                CatalogedMachines = catalogedMachines
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshExport(MeshExport Options) {
            var catalogedMachines = new List<CatalogedMachine>();

            "export host data".TaskFunctionality();

            return new ResultMachine() {
                Success = true,
                CatalogedMachines = catalogedMachines
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshImport(MeshImport Options) {
            var catalogedMachines = new List<CatalogedMachine>();

            "import host data".TaskFunctionality();

            return new ResultFile() {
                Success = true
                };
            }
        #endregion
        }
    }
