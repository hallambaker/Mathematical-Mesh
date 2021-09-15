﻿#region // Copyright - MIT License
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

using Goedel.Cryptography;
using System.Net;

using Goedel.Cryptography.KeyFile;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {





        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHCreate(SSHCreate options) {
            var rights = GetRights(options);
            var id = options.ID.Value ?? "ssh";
            var contextUser = GetContextUser(options);
            using var transaction = contextUser.TransactBegin();

            var applicationSSH = CatalogedApplicationSsh.Create(id, rights);

            transaction.ApplicationCreate(applicationSSH);
            //transaction.ApplicationDeviceAdd(applicationSSH);
            var resultTransact = transaction.Transact();


            return resultTransact.Success() ?
                new ResultApplication() {
                    Success = true,
                    Application = applicationSSH
                    } :
                    new ResultFail() {
                        Success = false,
                        Reason = "TBS"
                        };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddHost(SSHAddHost options) {
            var id = options.ID.Value ?? "ssh";
            var contextUser = GetContextUser(options);
            using var transaction = contextUser.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();


            //var applicationSSH = new CatalogedApplicationSshHost() {
            //    Key = id
            //    };
            //catalogApplication.New(applicationSSH);

            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHKnown(SSHKnown options) {
            var id = options.ID.Value ?? "ssh";
            var contextUser = GetContextUser(options);
            using var transaction = contextUser.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();
            //var known = catalogApplication.GetSshHosts(id);




            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAuth(SSHAuth options) {
            var id = options.ID.Value ?? "ssh";
            var contextUser = GetContextUser(options);
            using var transaction = contextUser.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();
            //var known = catalogApplication.GetSshClients(id);
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPrivate(SSHPrivate options) {
            var id = options.ID.Value ?? "ssh";
            var format = options.Format.Value;
            var fileName = options.File.Value;
            var password = options.Password.Value;
            var contextUser = GetContextUser(options);

            var applicationEntrySsh = contextUser.GetApplicationEntrySsh(id);
            var keyData = applicationEntrySsh.Activation.ClientKey;
            var keyPair = keyData.GetKeyPair(KeySecurity.Exportable);
            var keyFileFormat = KeyFileFormat.PEMPrivate;

            var applicationSsh = contextUser.GetApplicationSsh(id);

            return KeyToFile(
                    keyPair,
                    fileName,
                    format,
                    password,
                    true,
                    keyFileFormat
                    );
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHPublic(SSHPublic options) {
            var id = options.ID.Value ?? "ssh";
            var format = options.Format.Value;
            var fileName = options.File.Value;
            var password = options.Password.Value;
            var contextUser = GetContextUser(options);

            var applicationSsh = contextUser.GetApplicationSsh(id);
            var keyPair = applicationSsh.ClientKey.GetKeyPair();
            var keyFileFormat = KeyFileFormat.PEMPublic;

            return KeyToFile(
                    keyPair,
                    fileName,
                    format,
                    password,
                    false,
                    keyFileFormat
                    );
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SSHAddClient(SSHAddClient options) {
            var id = options.ID.Value ?? "ssh";
            var contextUser = GetContextUser(options);
            using var transaction = contextUser.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();


            //var applicationSSH = new CatalogedApplicationSshClient() {
            //    Key = id
            //    };
            //catalogApplication.New(applicationSSH);
            throw new NYI();
            }




        }
    }
