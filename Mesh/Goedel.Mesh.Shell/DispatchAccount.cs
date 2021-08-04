#region // Copyright
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountHello(AccountHello options) {

            // This dispatch uses a unique approach because it can be issued before the account
            // or service is created.

            var meshClient = GetMeshClient(options);

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountCreate(AccountCreate options) {
            var accountID = options.NewAccountID.Value;
            var localname = options.Localname.Value;

            var contextUser = MeshHost.CreateMesh(accountID, localname);
            return new ResultCreateAccount() {
                Success = true,
                ProfileAccount = contextUser.ProfileUser,
                ActivationDevice = contextUser.ActivationDevice
                };
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountDelete(AccountDelete options) {
            var profileUdf = options.ProfileUdf.Value;

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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountStatus(AccountStatus options) {
            var contextAccount = GetContextUser(options);
            var result = contextAccount.Status();

            return new ResultStatus() {
                Success = true,
                StatusResponse = result
                };
            }


        /// <summary>
        /// Register a profile to a new service. This is not currently supported.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountSync(AccountSync options) {
            var contextAccount = GetContextUser(options);
            var result = contextAccount.Sync();


            int ProcessedResults = 0;

            if (options.AutoApprove.Value) {
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
        /// <param name="options">The dispatch options.</param>
        /// <returns>The result of the operation.</returns>
        public override ShellResult AccountGetPIN(AccountGetPIN options) {
            var contextAccount = GetContextUser(options);

            var expire = TimeSpan.Parse(options.Expire.Value);
            // ToDo: Allow other actions besides device.

            var messageConnectionPIN = contextAccount.GetPIN(MeshConstants.MessagePINActionDevice,
                        validity: expire.Ticks);

            var result = new ResultPIN() {
                MessagePIN = messageConnectionPIN,
                };

            return result;
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountConnect(AccountConnect options) {
            var contextAccount = GetContextUser(options);
            var rights = GetRights(options);

            var catalogedDevice = contextAccount.Connect(options.Uri.Value, rights);


            var result = new ResultAccountConnect() {
                ProfileDevice = catalogedDevice.ProfileDevice
                };

            return result;
            }



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountEscrow(AccountEscrow options) {
            var contextMesh = GetContextUser(options);
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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountPurge(AccountPurge options) {
            var contextMesh = GetContextUser(options);

            throw new NYI();
            }

        static void AddIfPresent(List<string> Keys, String Parameter) {
            if (Parameter.Value != null) {
                Keys.Add(Parameter.Value);
                }
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountRecover(AccountRecover options) {

            // ToDo: this is going to need refactoring so that the localname and account tabs are filled.


            var recoverShares = new List<string>();
            AddIfPresent(recoverShares, options.Share1);
            AddIfPresent(recoverShares, options.Share2);
            AddIfPresent(recoverShares, options.Share3);
            AddIfPresent(recoverShares, options.Share4);

            AddIfPresent(recoverShares, options.Share5);
            AddIfPresent(recoverShares, options.Share6);
            AddIfPresent(recoverShares, options.Share7);
            AddIfPresent(recoverShares, options.Share8);

            var secret = new SharedSecret(recoverShares);


            var (algorithm, meshSecret) = secret.ParseKey();

            // should switch on algorithm so we can recover different types of profile!!!
            (algorithm == UdfAlgorithmIdentifier.MeshProfileAccount |
                algorithm == UdfAlgorithmIdentifier.MeshProfileService).AssertTrue(InvalidRecoverySecret.Throw);


            var accountSeed = new PrivateKeyUDF(secret.UDFKey);
            var contextUser = MeshHost.CreateMesh("main", accountSeed: accountSeed);


            return new ResultCreateAccount() {
                Success = true,
                ProfileAccount = contextUser.ProfileUser,
                ActivationDevice = contextUser.ActivationDevice
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountList(AccountList options) {
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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountGet(AccountGet options) {
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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountExport(AccountExport options) {
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
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountImport(AccountImport options) {
            var catalogedMachines = new List<CatalogedMachine>();

            "import host data".TaskFunctionality();

            return new ResultFile() {
                Success = true
                };
            }
        }
    }
