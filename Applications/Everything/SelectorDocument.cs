﻿using Goedel.Cryptography.Dare;
using Microsoft.Maui.Storage;

namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class DocumentSection {

    AccountSection Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public DocumentSection(AccountSection account) {
        Account = account;

        var catalog = ContextUser.GetStore(CatalogDocument.Label, create: false) as GuigenCatalogDocument;
        ChooseDocuments = catalog is null ? null : new DocumentSelection(catalog);
        }

    }

// Documented in Guigen output
public partial class BoundDocument : ISelectSummary, IBoundPresentation {

    public static readonly Dictionary<string, string> DictionaryExtensionContentType =
        new() {
                { "doc", "application/msword"},
                { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { "xls", "application/vnd.ms-excel" },
                { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                { "ppt", "application/vnd.ms-powerpoint" },
                { "pptx", "application/application/vnd.openxmlformats-officedocument.presentationml.presentation" },
                { "mdb", "application/ms-access" }

            };

    public static readonly Dictionary<string, string> DictionaryContentTypeLogo = new() {
                { "application/msword", "file_word.png"},
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document" , "file_word.png"},
                { "application/vnd.ms-excel" , "file_excel.png"},
                { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "file_excel.png" },
                { "application/vnd.ms-powerpoint" , "file_powerpoint.png"},
                { "application/application/vnd.openxmlformats-officedocument.presentationml.presentation" , "file_powerpoint.png"},
                { "application/pdf" , "file_pdf.png"}
            };


    public string? LabelValue => Filename;

    public string? IconValue => GetIcon();
    public string ContentType {get; set;}

    public CatalogedDocument Convert() {
        var result = new CatalogedDocument() {
            Filename = Filename
            };

        return result;
        }

    public static BoundDocument Convert(CatalogedDocument entry) {
        var result = new BoundDocument() {
            Filename = entry.Filename,
            ContentType = entry.ContentType ?? GetContentType(entry.Filename)
            };

        return result;

        }

    public string GetIcon() {
        var contentType = ContentType ?? GetContentType(Filename);
        if (contentType != null) {
            if (DictionaryContentTypeLogo.TryGetValue(contentType, out var icon)) {
                return icon;
                }
            }

        return "file_regular.png";
        }

    public static string GetContentType(string filename) {
        var extension = Path.GetExtension(filename);
        if (DictionaryExtensionContentType.TryGetValue(extension, out var contentType)) {
            return contentType;
            }
        return null;
        }

    }

#endregion
#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenCatalogDocument : CatalogDocument {

    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">The mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new GuigenCatalogContact(directory, storeId, policy, cryptoParameters, keyCollection,
            decrypt, create, bitmask: bitmask);


    /// <summary>
    /// Constructor for a catalog named <paramref name="storeName"/> in directory
    /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
    /// and key collection <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
    /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
    /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
    /// <param name="storeName">The catalog persistence container file name.</param>
    /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public GuigenCatalogDocument(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);
        }



    }


#endregion


#region // Selection Catalog backing type.

public partial class DocumentSelection : SelectionCatalog<GuigenCatalogDocument,
            CatalogedDocument, BoundDocument> {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public DocumentSelection(GuigenCatalogDocument catalog) : base(catalog) {
        }

    #region // Conversion overrides
    public override CatalogedDocument CreateFromBindable(IBindable contact) =>
        (contact as BoundDocument)?.Convert();

    public override BoundDocument ConvertToBindable(CatalogedDocument input) => BoundDocument.Convert(input);
    #endregion


    }


#endregion