#region // Copyright - MIT License
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

using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {





        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHCreate(SSHCreate options) {

            var id = options.ID.Value ?? "ssh";
            using var contextDevice = GetContextDevice(options);
            using var transaction = contextDevice.TransactBegin();

            var applicationSSH = new CatalogedApplicationSsh() {
                Key = id
                };

            transaction.ApplicationCreate(applicationSSH);
            transaction.ApplicationDeviceAdd(applicationSSH);
            var result = transaction.Transact();

            throw new NYI();
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddHost(SSHAddHost options) {
            var id = options.ID.Value ?? "ssh";
            using var contextDevice = GetContextDevice(options);
            using var transaction = contextDevice.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();


            var applicationSSH = new CatalogedApplicationSshHost() {
                Key = id
                };
            catalogApplication.New(applicationSSH);

            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHKnown(SSHKnown options) {
            var id = options.ID.Value ?? "ssh";
            using var contextDevice = GetContextDevice(options);
            using var transaction = contextDevice.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();
            var known = catalogApplication.GetSshHosts(id);




            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAuth(SSHAuth options) {
            var id = options.ID.Value ?? "ssh";
            using var contextDevice = GetContextDevice(options);
            using var transaction = contextDevice.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();
            var known = catalogApplication.GetSshClients(id);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPrivate(SSHPrivate options) {
            var id = options.ID.Value ?? "ssh";
            using var contextDevice = GetContextDevice(options);
            using var transaction = contextDevice.TransactBegin();

            var applicationSsh = transaction.ApplicationGetShh(id, 
                                contextDevice.AccountDeviceId);

            // here dump out the private key 

            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPublic(SSHPublic options) {
            var id = options.ID.Value ?? "ssh";
            using var contextDevice = GetContextDevice(options);
            using var transaction = contextDevice.TransactBegin();

            // need to be able to pull key from different device here.
            var applicationSsh = transaction.ApplicationGetShh(id,
                                contextDevice.AccountDeviceId);

            // here dump out the public key 

            throw new NYI();
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddClient(SSHAddClient options) {
            var id = options.ID.Value ?? "ssh";
            using var contextDevice = GetContextDevice(options);
            using var transaction = contextDevice.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();


            var applicationSSH = new CatalogedApplicationSshClient() {
                Key = id
                };
            catalogApplication.New(applicationSSH);
            throw new NYI();
            }




        }
    }
