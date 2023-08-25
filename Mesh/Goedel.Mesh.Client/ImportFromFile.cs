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

namespace Goedel.Mesh.Client;

public partial class ContextUser {


    /// <summary>
    /// Add the bookmark data specified in the file <paramref name="fileName"/>. If
    /// <paramref name="merge"/> is true, merge this contact information.
    /// </summary>
    /// <param name="fileName">The file to fetch the contact data from.</param>
    /// <param name="localName">Short name for the contact to distinguish it from
    /// others.</param>
    /// <param name="merge">Add this data to the existing contact.</param>
    /// <param name="format">The format the input is written in.</param>
    /// <returns></returns>
    public async Task<CatalogedBookmark> AddBookmarkFromFileAsync(
                string fileName,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                bool merge = true,
                string? localName = null) {
        merge.Future();
        localName?.Future();

        using var transaction = TransactBegin();
        var catalog = transaction.GetCatalogBookmark();
        using var stream = fileName.OpenFileReadShared();
        var entry = catalog.ReadFromStream(stream, format);


        transaction.CatalogUpdate(catalog, entry);
        await transaction.TransactAsync();

        return entry;

        }

    /// <summary>
    /// Add the contact data specified in the file <paramref name="fileName"/>. If
    /// <paramref name="merge"/> is true, merge this contact information.
    /// </summary>
    /// <param name="fileName">The file to fetch the contact data from.</param>
    /// <param name="localName">Short name for the contact to distinguish it from
    /// others.</param>
    /// <param name="merge">Add this data to the existing contact.</param>
    /// <param name="format">The format the input is written in.</param>
    /// <returns></returns>
    public async Task<CatalogedCredential> AddCredentialFromFileAsync(
                string fileName,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                bool merge = true,
                string? localName = null) {
        merge.Future();
        localName?.Future();

        using var transaction = TransactBegin();
        var catalog = transaction.GetCatalogCredential();
        using var stream = fileName.OpenFileReadShared();
        var entry = catalog.ReadFromStream(stream, format);

        transaction.CatalogUpdate(catalog, entry);
        await transaction.TransactAsync();

        return entry;

        }




    /// <summary>
    /// Add the contact data specified in the file <paramref name="fileName"/>. If
    /// <paramref name="merge"/> is true, merge this contact information.
    /// </summary>
    /// <param name="fileName">The file to fetch the contact data from.</param>
    /// <param name="localName">Short name for the contact to distinguish it from
    /// others.</param>
    /// <param name="merge">Add this data to the existing contact.</param>
    /// <param name="format">The format the input is written in.</param>
    /// <returns></returns>
    public async Task<CatalogedContact> AddContactFromFileAsync(
                string fileName,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                bool merge = true,
                string? localName = null) {
        merge.Future();
        localName?.Future();

        using var transaction = TransactBegin();
        var catalog = transaction.GetCatalogContact();
        using var stream = fileName.OpenFileReadShared();
        var entry = catalog.ReadFromStream(stream, format);

        transaction.CatalogUpdate(catalog, entry);
        await transaction.TransactAsync();

        return entry;

        }

    /// <summary>
    /// Add the contact data specified in the file <paramref name="fileName"/>. If
    /// <paramref name="merge"/> is true, merge this contact information.
    /// </summary>
    /// <param name="fileName">The file to fetch the contact data from.</param>
    /// <param name="localName">Short name for the contact to distinguish it from
    /// others.</param>
    /// <param name="merge">Add this data to the existing contact.</param>
    /// <param name="format">The format the input is written in.</param>
    /// <returns></returns>
    public async Task<CatalogedNetwork> AddNetworkFromFileAsync(
                string fileName,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                bool merge = true,
                string? localName = null) {
        merge.Future();
        localName?.Future();

        using var transaction = TransactBegin();
        var catalog = transaction.GetCatalogNetwork();
        using var stream = fileName.OpenFileReadShared();
        var entry = catalog.ReadFromStream(stream, format);


        entry.LocalName = localName;

        transaction.CatalogUpdate(catalog, entry);
        await transaction.TransactAsync();

        return entry;

        }



    /// <summary>
    /// Add the contact data specified in the file <paramref name="fileName"/>. If
    /// <paramref name="merge"/> is true, merge this contact information.
    /// </summary>
    /// <param name="fileName">The file to fetch the contact data from.</param>
    /// <param name="localName">Short name for the contact to distinguish it from
    /// others.</param>
    /// <param name="merge">Add this data to the existing contact.</param>
    /// <param name="format">The format the input is written in.</param>
    /// <returns></returns>
    public async Task<CatalogedTask> AddTaskFromFileAsync(
                string fileName,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                bool merge = true,
                string? localName = null) {
        merge.Future();
        localName?.Future();

        using var transaction = TransactBegin();
        var catalog = transaction.GetCatalogCalendar();
        using var stream = fileName.OpenFileReadShared();
        var entry = catalog.ReadFromStream(stream, format);

        transaction.CatalogUpdate(catalog, entry);
        await transaction.TransactAsync();

        return entry;

        }


    /// <summary>
    /// Add the contact data specified in the file <paramref name="fileName"/>. If
    /// <paramref name="merge"/> is true, merge this contact information.
    /// </summary>
    /// <param name="fileName">The file to fetch the contact data from.</param>
    /// <param name="localName">Short name for the contact to distinguish it from
    /// others.</param>
    /// <param name="merge">Add this data to the existing contact.</param>
    /// <param name="format">The format the input is written in.</param>
    /// <returns></returns>
    public async Task<CatalogedApplication> AddApplicationFromFileAsync(
                string fileName,
                CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                bool merge = true,
                string? localName = null) {


        merge.Future();
        localName?.Future();

        using var transaction = TransactBegin();
        var catalog = transaction.GetCatalogApplication();
        using var stream = fileName.OpenFileReadShared();
        var entry = catalog.ReadFromStream(stream, format);


        entry.LocalName = localName;
        if (entry is CatalogedApplicationSsh applicationSsh) {
            entry.Key ??= applicationSsh.ClientKey.CryptoKey.KeyIdentifier;
            }
        transaction.CatalogUpdate(catalog, entry);
        await transaction.TransactAsync();

        return entry;

        }





    }
