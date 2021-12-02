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

namespace Goedel.Mesh.Shell;

public partial class Shell {

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MailAdd(MailAdd options) {
        var address = options.Address.Value.AssertNotNull(NYI.Throw);
        var rights = GetRights(options);

        var contextUser = GetContextUser(options);
        using var transaction = contextUser.TransactBegin();

        var applicationMail = CatalogedApplicationMail.Create(address, rights);
        applicationMail.AccountAddress = address;
        applicationMail.InboundConnect = options.Inbound.Value;
        applicationMail.OutboundConnect = options.Outbound.Value;

        transaction.ApplicationCreate(applicationMail);
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

        var contextUser = GetContextUser(options);
        using var transaction = contextUser.TransactBegin();

        var catalogApplication = transaction.GetCatalogApplication();
        var known = catalogApplication.GetMail();


        return new ResultApplicationList() {
            Success = true,
            Applications = known
            };

        }



    ShellResult KeyToFile(KeyPair keyPair,
                string fileName,
                string format,
                string password,
                bool privateKey,
                KeyFileFormat keyFileFormatDefault) {



        var length = (int)keyPair.ToKeyFile(fileName, keyFileFormatDefault);

        return new ResultKeyFile() {
            Success = true,
            Filename = fileName,
            TotalBytes = length,
            Udf = keyPair.KeyIdentifier,
            Private = privateKey,
            Algorithm = keyPair.CryptoAlgorithmId.ToJoseID(),
            Format = format
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult SmimeSign(SmimeSign options) {
        var address = options.Address.Value.AssertNotNull(NYI.Throw);
        var format = options.Format.Value;
        var fileName = options.File.Value;
        var password = options.Password.Value;
        var privateKey = options.Private.Value;
        using var contextUser = GetContextUser(options);


        KeyPair keyPair;
        KeyFileFormat keyFileFormat;
        if (privateKey) {
            var applicationEntryMail = contextUser.GetApplicationEntryMail(address);
            var keyData = applicationEntryMail.Activation.SmimeSign;
            keyPair = keyData.GetKeyPair(KeySecurity.Exportable);
            keyFileFormat = KeyFileFormat.PEMPrivate;
            }
        else {
            var applicationMail = contextUser.GetApplicationMail(address);
            keyPair = applicationMail.SmimeSign.GetKeyPair();
            keyFileFormat = KeyFileFormat.PEMPublic;
            }

        return KeyToFile(
                keyPair,
                fileName,
                format,
                password,
                privateKey,
                keyFileFormat
                );
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult SmimeEncrypt(SmimeEncrypt options) {
        var address = options.Address.Value.AssertNotNull(NYI.Throw);
        var format = options.Format.Value;
        var fileName = options.File.Value;
        var password = options.Password.Value;
        var privateKey = options.Private.Value;
        var contextUser = GetContextUser(options);

        KeyPair keyPair;
        KeyFileFormat keyFileFormat;
        if (privateKey) {
            var applicationEntryMail = contextUser.GetApplicationEntryMail(address);
            var keyData = applicationEntryMail.Activation.SmimeEncrypt;
            keyPair = keyData.GetKeyPair(KeySecurity.Exportable);
            keyFileFormat = KeyFileFormat.PEMPrivate;
            }
        else {
            var applicationMail = contextUser.GetApplicationMail(address);
            keyPair = applicationMail.SmimeEncrypt.GetKeyPair();
            keyFileFormat = KeyFileFormat.PEMPublic;
            }

        return KeyToFile(
                keyPair,
                fileName,
                format,
                password,
                privateKey,
                keyFileFormat
                );

        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult OpenpgpSign(OpenpgpSign options) {
        var address = options.Address.Value.AssertNotNull(NYI.Throw);
        var format = options.Format.Value;
        var fileName = options.File.Value;
        var password = options.Password.Value;
        var privateKey = options.Private.Value;
        var contextUser = GetContextUser(options);

        KeyPair keyPair;
        KeyFileFormat keyFileFormat;
        if (privateKey) {
            var applicationEntryMail = contextUser.GetApplicationEntryMail(address);
            var keyData = applicationEntryMail.Activation.OpenpgpSign;
            keyPair = keyData.GetKeyPair(KeySecurity.Exportable);
            keyFileFormat = KeyFileFormat.PEMPrivate;
            }
        else {
            var applicationMail = contextUser.GetApplicationMail(address);
            keyPair = applicationMail.OpenpgpSign.GetKeyPair();
            keyFileFormat = KeyFileFormat.PEMPublic;

            }

        return KeyToFile(
                keyPair,
                fileName,
                format,
                password,
                privateKey,
                keyFileFormat
                );

        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult OpenpgpEncrypt(OpenpgpEncrypt options) {
        var address = options.Address.Value.AssertNotNull(NYI.Throw);
        var format = options.Format.Value;
        var fileName = options.File.Value;
        var password = options.Password.Value;
        var privateKey = options.Private.Value;
        var contextUser = GetContextUser(options);

        KeyPair keyPair;
        KeyFileFormat keyFileFormat;
        if (privateKey) {
            var applicationEntryMail = contextUser.GetApplicationEntryMail(address);
            var keyData = applicationEntryMail.Activation.OpenpgpEncrypt;
            keyPair = keyData.GetKeyPair(KeySecurity.Exportable);
            keyFileFormat = KeyFileFormat.PEMPrivate;
            }
        else {
            var applicationMail = contextUser.GetApplicationMail(address);
            keyPair = applicationMail.OpenpgpEncrypt.GetKeyPair();
            keyFileFormat = KeyFileFormat.PEMPublic;
            }

        return KeyToFile(
                keyPair,
                fileName,
                format,
                password,
                privateKey,
                keyFileFormat
                );

        }

    }
