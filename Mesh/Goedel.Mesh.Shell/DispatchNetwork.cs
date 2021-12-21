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


namespace Goedel.Mesh.Shell;

public partial class Shell {


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult NetworkAdd(NetworkAdd options) {
        var contextUser = GetContextUser(options);
        var identifier = options.SSID.Value;
        var password = options.Password.Value;

        var entry = new CatalogedNetwork() {
            Service = identifier,
            Password = password
            };

        var transaction = contextUser.TransactBegin();
        var catalog = transaction.GetCatalogNetwork();
        transaction.CatalogUpdate(catalog, entry);
        transaction.Transact();

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
    public override ShellResult NetworkImport(NetworkImport options) {
        var contextUser = GetContextUser(options);
        //var identifier = options.SSID.Value;
        //var password = options.Password.Value;

        //var entry = new CatalogedNetwork() {
        //    Service = identifier,
        //    Password = password
        //    };

        //var transaction = contextUser.TransactBegin();
        //var catalog = transaction.GetCatalogNetwork();
        //transaction.CatalogUpdate(catalog, entry);
        //transaction.Transact();


        "Implement network import command".TaskFunctionality();

        return new Result() {
            Success = false,
            //CatalogEntry = null
            };
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult NetworkDelete(NetworkDelete options) {
        var contextUser = GetContextUser(options);
        var identifier = options.Identifier.Value;
        var key = CatalogedNetwork.PrimaryKey(null, identifier);

        var transaction = contextUser.TransactBegin();
        var catalog = transaction.GetCatalogNetwork();
        var result = catalog.Locate(key);
        result.AssertNotNull(EntryNotFound.Throw, key);
        transaction.CatalogDelete(catalog, result);
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
    public override ShellResult NetworkGet(NetworkGet options) {
        var contextUser = GetContextUser(options);
        var catalog = contextUser.GetStore(CatalogNetwork.Label) as CatalogNetwork;
        var identifier = options.Identifier.Value;
        var key = CatalogedNetwork.PrimaryKey(null, identifier);

        var result = contextUser.GetNetwork(key);

        return new ResultEntry() {
            Success = result != null,
            CatalogEntry = result
            };
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult NetworkDump(NetworkDump options) {
        var contextUser = GetContextUser(options);
        var result = new ResultDump() {
            Success = true,
            CatalogedEntries = new List<CatalogedEntry>()
            };
        var catalog = contextUser.GetStore(CatalogNetwork.Label) as CatalogNetwork;
        foreach (var entry in catalog) {
            result.CatalogedEntries.Add(entry);
            }

        return result;
        }


    }
