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

using Goedel.Cryptography.KeyFile;
using Goedel.Registry;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MailAdd(MailAdd options) {
            var address = options.Address.Value.AssertNotNull(NYI.Throw);
            var rights = GetRights(options);

            using var contextDevice = GetContextUser(options);
            using var transaction = contextDevice.TransactBegin();

            var applicationMail = CatalogedApplicationMail.Create(address, rights);
            applicationMail.AccountAddress = address;
            applicationMail.InboundConnect = options.Inbound.Value;
            applicationMail.OutboundConnect = options.Outbound.Value;


            transaction.ApplicationCreate(applicationMail);
            //transaction.ApplicationCreate(applicationMail);

            var resultTransact = transaction.Transact();

            return resultTransact.Success() ?
                new ResultApplication() {
                    Success = true,
                    Application = applicationMail
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
        public override ShellResult MailUpdate(MailUpdate options) {
            var address = options.Address.Value.AssertNotNull(NYI.Throw);
            using var contextDevice = GetContextUser(options);
            using var transaction = contextDevice.TransactBegin();

            var applicationMail = new CatalogedApplicationMail() {
                Key = address
                };

            transaction.ApplicationUpdate(applicationMail);

            var resultTransact = transaction.Transact();
            return resultTransact.Success() ?
                new ResultApplication() {
                    Success = true,
                    Application = applicationMail
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
        public override ShellResult MailList(MailList options) {

            using var contextDevice = GetContextUser(options);
            using var transaction = contextDevice.TransactBegin();

            var catalogApplication = transaction.GetCatalogApplication();
            var known = catalogApplication.GetMail();


            return new ResultApplicationList() {
                Success = true,
                Applications = known
                };

            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SMIMEPrivate(SMIMEPrivate options) {
            var address = options.Address.Value.AssertNotNull(NYI.Throw);
            var fileName = options.File.Value;
            
            using var contextDevice = GetContextUser(options);

            var applicationMail = contextDevice.GetApplicationMail(address);

            // dump out the private SMIME from applicationMail
            applicationMail.SmimeEncryptKeyPair.ToKeyFile(fileName, KeyFileFormat.PEMPrivate);


            throw new NYI();
            }
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult SMIMEPublic(SMIMEPublic options) {
            var address = options.Address.Value.AssertNotNull(NYI.Throw);
            using var contextDevice = GetContextUser(options);
            using var transaction = contextDevice.TransactBegin();

            var applicationMail = contextDevice.GetApplicationMail(address);

            // dump out the public SMIME from applicationMail
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PGPPrivate(PGPPrivate options) {
            var address = options.Address.Value.AssertNotNull(NYI.Throw);
            using var contextDevice = GetContextUser(options);
            using var transaction = contextDevice.TransactBegin();

            var applicationMail = contextDevice.GetApplicationMail(address);

            // dump out the private PGP from applicationMail
            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult PGPPublic(PGPPublic options) {
            var address = options.Address.Value.AssertNotNull(NYI.Throw);
            using var contextDevice = GetContextUser(options);

            var applicationMail = contextDevice.GetApplicationMail(address);

            // dump out the public PGP from applicationMail
            throw new NYI();
            }
        }
    }
