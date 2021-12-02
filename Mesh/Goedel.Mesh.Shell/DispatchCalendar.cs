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

    public override ShellResult CalendarAdd(CalendarAdd options) {
        var contextAccount = GetContextUser(options);
        var title = options.Title.Value;
        var identifier = options.Identifier.Value ?? UDF.Nonce();

        var entry = new CatalogedTask() {
            Key = identifier,
            Title = title
            };

        var transaction = contextAccount.TransactBegin();
        var catalog = transaction.GetCatalogCalendar();
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
    public override ShellResult CalendarImport(CalendarImport options) {
        var contextAccount = GetContextUser(options);
        "Implement file import functionality".TaskFunctionality(true);

        var identifier = options.Identifier.Value ?? UDF.Nonce();

        var entry = new CatalogedTask() {
            Key = identifier
            };

        var transaction = contextAccount.TransactBegin();
        var catalog = transaction.GetCatalogCalendar();
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
    public override ShellResult CalendarDelete(CalendarDelete options) {
        var contextAccount = GetContextUser(options);
        var key = options.Identifier.Value;

        var transaction = contextAccount.TransactBegin();
        var catalog = transaction.GetCatalogCalendar();
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
    public override ShellResult CalendarGet(CalendarGet options) {
        var contextAccount = GetContextUser(options);
        var catalog = contextAccount.GetStore(CatalogTask.Label) as CatalogTask;
        var identifier = options.Identifier.Value;

        var result = catalog.Locate(identifier);

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
    public override ShellResult CalendarDump(CalendarDump options) {
        var contextAccount = GetContextUser(options);
        var catalogedEntries = new List<CatalogedEntry>();

        var catalog = contextAccount.GetStore(CatalogTask.Label) as CatalogTask;
        foreach (var entry in catalog) {
            catalogedEntries.Add(entry);
            }

        var result = new ResultDump() {
            Success = true,
            CatalogedEntries = catalogedEntries
            };
        return result;
        }
    }
