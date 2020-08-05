using Goedel.Protocol;
using Goedel.Utilities;
using System;

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

            var contextAccount = MeshHost.CreateMesh(accountID, localname);
            return new ResultCreateAccount() {
                Success = true,
                ProfileUser = contextAccount.ProfileUser,
                ActivationUser = contextAccount.ActivationUser
                };
            }


        /// <summary>
        /// Register a profile to a new service. This is not currently supported.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountStatus(AccountStatus Options) {
            using var contextAccount = GetContextAccount(Options);
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
            using var contextAccount = GetContextAccount(Options);
            var result = contextAccount.Sync();

            if (Options.AutoApprove.Value) {
                contextAccount.ProcessAutomatics();
                }


            return new ResultSync() {
                Success = true,
                Fetched = result
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountRegister(AccountRegister Options) {
            using var contextAccount = GetContextAccount(Options); //GetContextMeshAdmin(Options);

            throw new NYI();

            //contextAccount.AddService(Options.NewAccountID.Value);

            //return new ResultRegisterService() {
            //    Success = true,
            //    AccountAddress = contextAccount.AccountAddress,
            //    ActivationAccount = contextAccount.ActivationAccount,
            //    ProfileAccount = contextAccount.ProfileAccount
            //    };
            }

        /// <summary>
        /// Dispatch method, returns a connection PIN code for the account.
        /// Requires administrative privileges.
        /// </summary>
        /// <param name="Options">The dispatch options.</param>
        /// <returns>The result of the operation.</returns>
        public override ShellResult AccountGetPIN(AccountGetPIN Options) {
            using var contextAccount = GetContextAccount(Options);

            var expire = TimeSpan.Parse(Options.Expire.Value);

            var messageConnectionPIN = contextAccount.GetPIN(Constants.MessagePINActionDevice,
                        validity: expire.Ticks);

            var result = new ResultPIN() {
                MessagePIN = messageConnectionPIN
                };

            return result;
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountInvite(AccountInvite Options) {
            using var contextAccount = GetContextAccount(Options);


            var messagePIN = contextAccount.GetPIN(Constants.MessagePINActionContact, length: 128);
            var uri = messagePIN.GetURI();

            var result = new ResultPIN() {
                MessagePIN = messagePIN,
                Uri = uri
                };

            return result;
            }




        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult AccountConnect(AccountConnect Options) {
            using var contextAccount = GetContextAccount(Options);

            var catalogedDevice = contextAccount.Connect(Options.Uri.Value);


            var result = new ResultAccountConnect() {
                ProfileDevice = catalogedDevice.ProfileDevice
                };

            return result;
            }


        }
    }
