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
        public override ShellResult AccountHello(AccountHello Options) {

            // This dispatch uses a unique approach because it can be issued before the account
            // or service is created.

            var meshClient = GetMeshClient(Options);
            var jpcSession = GetJpcSession(Options);

            var helloRequest = new HelloRequest();
            var response = meshClient.Hello(helloRequest, jpcSession);

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

            using (var contextMesh = GetContextMeshAdmin(Options)) {

                var contextAccount = contextMesh.CreateAccount(accountID);
                return new ResultAccountCreate() {
                    Success = true,
                    ActivationAccount = contextAccount.ActivationAccount
                    };

                }
            }


        /// <summary>
        /// Register a profile to a new service. This is not currently supported.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountSync(AccountSync Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                var result = contextAccount.Sync();

                return new ResultSync() {
                    Success = true,
                    Fetched = result
                    };
                }
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountRegister(AccountRegister Options) {
            using (var contextAccount = GetContextAccount(Options)) {
                contextAccount.AddService(Options.NewAccountID.Value);

                return new ResultAccountCreate() {
                    Success = true,
                    ActivationAccount = contextAccount.ActivationAccount,
                    ServiceID = "fred"
                    };

                }
            }

        }
    }
