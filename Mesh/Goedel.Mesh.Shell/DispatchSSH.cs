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

using Goedel.Cryptography.Jose;
using Goedel.Cryptography.KeyFile;
using Goedel.Registry;

namespace Goedel.Mesh.Shell;

public partial class Shell {





    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult SSHCreate(SSHCreate options) {
        var rights = GetRights(options);
        var id = options.ID.Value;
        var contextUser = GetContextUser(options);
        using var transaction = contextUser.TransactBegin();

        var applicationSSH = CatalogedApplicationSsh.Create(id, rights);
        transaction.ApplicationCreate(applicationSSH);
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
    public override ShellResult SSHGet(SSHGet options) {
        var id = options.Identifier.Value;
        var format = options.Format.Value;
        var fileName = options.File.Value;
        var password = options.Password.Value;
        var contextUser = GetContextUser(options);

        // We need the application entry for this specific device, not a generic one.


        var applicationSsh = contextUser.GetApplicationSsh(id);

        

        if (!options.Private.Value) {
            var publicformat = GetKeyFileFormat(options, KeyFileFormat.OpenSSH);


            return KeyToFile(
            applicationSsh.ClientKey.GetKeyPair(KeySecurity.Public),
            fileName,
            password,
            false,
            publicformat
            );
            }

        


       var applicationEntrySsh = contextUser.GetApplicationEntrySsh(applicationSsh.Key);
        applicationEntrySsh.AssertNotNull(NYI.Throw);

        var keyData = applicationEntrySsh.Activation.ClientKey;



        var keyPair = keyData.GetKeyPair(KeySecurity.Exportable);
        var privateformat = GetKeyFileFormat(options, KeyFileFormat.PEMPrivate);
        return KeyToFile(
                keyPair,
                fileName,
                password,
                true,
                privateformat
                );
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult SSHList(SSHList options) {
        var contextUser = GetContextUser(options);
        using var transaction = contextUser.TransactBegin();

        var catalogApplication = transaction.GetCatalogApplication();
        var known = catalogApplication.GetSsh();

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
    public override ShellResult SSHClient(SSHClient options) {
        var contextUser = GetContextUser(options);
        var file = options.FileIn.Value;
        var id = options.Identifier.Value;

        var entry = contextUser.AddApplicationFromFile(file, localName: id);

        return new ResultEntry() {
            Success = true,
            CatalogEntry = entry
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult SSHDelete(SSHDelete options) {
        var contextUser = GetContextUser(options);
        var identifier = options.Identifier.Value;

        var applicationSsh = contextUser.GetApplicationSsh(identifier);


        var transaction = contextUser.TransactBegin();
        var catalog = transaction.GetCatalogApplication();
        var result = catalog.GetSsh(applicationSsh.Key);

        result.AssertNotNull(EntryNotFound.Throw, identifier);
        transaction.CatalogDelete<CatalogedApplication>(catalog, result);
        transaction.Transact();

        return new ResultEntry() {
            Success = true,
            CatalogEntry = result
            };
        }







    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult SSHHost(SSHHost options) {
        var contextUser = GetContextUser(options);
        var file = options.FileIn.Value;
        var id = options.Identifier.Value;

        var entry = contextUser.AddCredentialFromFile(file, localName: id);

        return new ResultEntry() {
            Success = true,
            CatalogEntry = entry
            };
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult SSHKnown(SSHKnown options) {
        var contextUser = GetContextUser(options);
        var id = options.Identifier.Value;

        var result = new ResultDump() {
            Success = true,
            CatalogedEntries = new List<CatalogedEntry>()
            };


        var catalog = contextUser.GetStore(CatalogCredential.Label) as CatalogCredential;



        if (id == null) {
            foreach (var entry in catalog.AsCatalogedType) {

                if (entry.HostAuthentication != null) {
                    result.CatalogedEntries.Add(entry);
                    }
                }
            }
        else {
            var key = CatalogedCredential.GetKey ("ssh", id);

            var entry = contextUser.GetCredential(key);
            entry.AssertNotNull(NYI.Throw);
            result.CatalogedEntries.Add(entry);
            }


        return result;
        }


    }
