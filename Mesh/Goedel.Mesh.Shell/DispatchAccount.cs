using Goedel.Protocol;
using Goedel.Utilities;
using System;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Mesh.Client;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountHello(AccountHello Options) {

            // This dispatch uses a unique approach because it can be issued before the account
            // or service is created.

            var meshClient = GetMeshClient(Options);

            var helloRequest = new HelloRequest();
            var response = meshClient.Hello(helloRequest);

            return new ResultHello() {
                Success = true,
                Response = response,
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountCreate(AccountCreate Options) {
            var accountID = Options.NewAccountID.Value;
            var localname = Options.Localname.Value;

            var contextUser = MeshHost.CreateMesh(accountID, localname);
            return new ResultCreateAccount() {
                Success = true,
                ProfileUser = contextUser.ProfileUser,
                ActivationUser = contextUser.ActivationUser
                };
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountDelete(AccountDelete Options) {
            var profileUdf = Options.ProfileUdf.Value;

            var contextUser = MeshHost.LocateMesh(profileUdf, false);
            contextUser.AssertNotNull(ProfileFingerprintInvalid.Throw);

            contextUser.DeleteAccount();
            contextUser.Dispose();

            return new ResultDeleteAccount() {
                Success = true,
                UDF = profileUdf
                };
            }



        /// <summary>
        /// Register a profile to a new service. This is not currently supported.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountStatus(AccountStatus Options) {
            var contextAccount = GetContextUser(Options);
            var result = contextAccount.Status();

            return new ResultStatus() {
                Success = true,
                StatusResponse = result
                };
            }


        /// <summary>
        /// Register a profile to a new service. This is not currently supported.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountSync(AccountSync Options) {
            var contextAccount = GetContextUser(Options);
            var result = contextAccount.Sync();


            int ProcessedResults = 0;

            if (Options.AutoApprove.Value) {
                var process = contextAccount.ProcessAutomatics();
                ProcessedResults = process.Count;
                }


            return new ResultSync() {
                Success = true,
                Fetched = result,
                ProcessedResults = ProcessedResults
                };
            }


        /// <summary>
        /// Dispatch method, returns a connection PIN code for the account.
        /// Requires administrative privileges.
        /// </summary>
        /// <param name="Options">The dispatch options.</param>
        /// <returns>The result of the operation.</returns>
        public override ShellResult AccountGetPIN(AccountGetPIN Options) {
            var contextAccount = GetContextUser(Options);

            var expire = TimeSpan.Parse(Options.Expire.Value);

            var messageConnectionPIN = contextAccount.GetPIN(Constants.MessagePINActionDevice,
                        validity: expire.Ticks);

            var result = new ResultPIN() {
                MessagePIN = messageConnectionPIN,
                };

            return result;
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountConnect(AccountConnect Options) {
            var contextAccount = GetContextUser(Options);

            var catalogedDevice = contextAccount.Connect(Options.Uri.Value);


            var result = new ResultAccountConnect() {
                ProfileDevice = catalogedDevice.ProfileDevice
                };

            return result;
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountEscrow(AccountEscrow Options) {
            var contextMesh = GetContextUser(Options);
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
            var contextMesh = GetContextUser(Options);

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

            var contextUser = MeshHost.CreateMesh("main", secretSeed: secret.UDFKey);


            return new ResultCreateAccount() {
                Success = true,
                ProfileUser = contextUser.ProfileUser,
                ActivationUser = contextUser.ActivationUser
                };
            }

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
        }
    }
