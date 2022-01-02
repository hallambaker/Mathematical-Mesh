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
    public override ShellResult BookmarkAdd(BookmarkAdd options) {
        var contextUser = GetContextUser(options);
        var uri = options.Uri.Value;
        var title = options.Title.Value;
        var path = options.Path.Value;

        var entry = new CatalogedBookmark() {
            Uri = uri,
            Title = title,
            Path = path
            };

        var transaction = contextUser.TransactBegin();
        var catalog = transaction.GetCatalogBookmark();
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
    public override ShellResult BookmarkDelete(BookmarkDelete options) {
        var contextAccount = GetContextUser(options);
        var uri = options.Uri.Value;

        var transaction = contextAccount.TransactBegin();
        var catalog = transaction.GetCatalogBookmark();
        var result = catalog.Locate(uri);
        result.AssertNotNull(EntryNotFound.Throw, uri);
        transaction.CatalogDelete(catalog, result);
        transaction.Transact();

        return new Result() {
            Success = true
            };
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult BookmarkGet(BookmarkGet options) {
        var contextAccount = GetContextUser(options);
        var catalog = contextAccount.GetStore(CatalogBookmark.Label) as CatalogBookmark;
        var identifier = options.Identifier.Value;

        var result = catalog.Locate(identifier);

        //result.AssertNotNull(EntryNotFound.Throw);

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
    public override ShellResult BookmarkDump(BookmarkDump options) {
        var contextAccount = GetContextUser(options);
        var result = new ResultDump() {
            Success = true,
            CatalogedEntries = new List<CatalogedEntry>()
            };
        var catalog = contextAccount.GetStore(CatalogBookmark.Label) as CatalogBookmark;
        foreach (var entry in catalog) {
            result.CatalogedEntries.Add(entry);
            }

        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult BookmarkImport(BookmarkImport options) {
        var contextUser = GetContextUser(options);
        var file = options.File.Value;

        var entry = contextUser.AddBookmarkFromFile(file);

        return new ResultEntry() {
            Success = true,
            CatalogEntry = entry
            };
        }


    }
