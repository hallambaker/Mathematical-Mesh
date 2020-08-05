using Goedel.Cryptography;
using Goedel.Mesh.Client;
using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        ///// <summary>
        ///// Dispatch method
        ///// </summary>
        ///// <param name="Options">The command line options.</param>
        ///// <returns>Mesh result instance</returns>
        //public override ShellResult MeshCreate(MeshCreate Options) {

        //    var service = Options.NewServiceID.Value;

        //    var account = Options.NewAccountID.Value ?? service;



        //    // here we need to decide if this is a local name or an account name.


        //    var contextMesh = MeshHost.CreateMesh("main");

        //    throw new NYI();
        //    //if (account != null) {
        //    //    var contextAccount = contextMesh.CreateAccount(service);
        //    //    if (service != null) {
        //    //        contextAccount.AddService(service);
        //    //        }
        //    //    }

        //    //return new ResultCreatePersonal() {
        //    //    Success = true,
        //    //    ProfileMesh = contextMesh.ProfileMesh,
        //    //    CatalogedDevice = contextMesh.CatalogedDevice,
        //    //    MeshUDF = contextMesh.ProfileMesh.UDF,
        //    //    DeviceUDF = contextMesh.CatalogedDevice.UDF
        //    //    };
        //    }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountEscrow(AccountEscrow Options) {
            var contextMesh = GetContextAccount(Options);
            var shares = contextMesh.Escrow(3, 2);

            var textShares = new List<string>();
            foreach (var share in shares) {
                textShares.Add(share.UDFKey);
                }

            return new ResultEscrow() {
                Success = true,
                Shares = textShares
                };

            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountPurge(AccountPurge Options) {
            var contextMesh = GetContextAccount(Options);

            throw new NYI();
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
        public override ShellResult AccountRecover(AccountRecover Options) {
            
            // ToDo: this is going to need refactoring so that the localname and account tabs are filled.


            var recoverShares = new List<string>();
            AddIfPresent(recoverShares, Options.Share1);
            AddIfPresent(recoverShares, Options.Share2);
            AddIfPresent(recoverShares, Options.Share3);
            AddIfPresent(recoverShares, Options.Share4);

            AddIfPresent(recoverShares, Options.Share5);
            AddIfPresent(recoverShares, Options.Share6);
            AddIfPresent(recoverShares, Options.Share7);
            AddIfPresent(recoverShares, Options.Share8);
            var secret = new SharedSecret(recoverShares);


            var (algorithm, meshSecret) = secret.ParseKey();

            // should switch on algorithm so we can recover different types of profile!!!


            (algorithm == UdfAlgorithmIdentifier.MeshProfileUser |
                algorithm == UdfAlgorithmIdentifier.MeshProfileGroup).AssertTrue(InvalidRecoverySecret.Throw);

            var contextMesh = MeshHost.CreateMesh("main", secretSeed: meshSecret);

            throw new NYI();


            }

        #region // Data dump, import and export of profiles - punt on this for now

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountList(AccountList Options) {
            var catalogedMachines = new List<CatalogedMachine>();
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
        public override ShellResult AccountGet(AccountGet Options) {
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
        public override ShellResult AccountExport(AccountExport Options) {
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
        public override ShellResult AccountImport(AccountImport Options) {
            var catalogedMachines = new List<CatalogedMachine>();

            "import host data".TaskFunctionality();

            return new ResultFile() {
                Success = true
                };
            }
        #endregion
        }
    }
