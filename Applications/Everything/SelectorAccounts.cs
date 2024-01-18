using Goedel.Cryptography.Dare;

using System.Collections;
using System.Collections.Specialized;



namespace Goedel.Everything;

/*
 
NB This will need very special treatment as it is not backed by a catalog in the account
 
 */




#region // Bindings to classes specified through the Guigen schema.


public partial class BoundAccount : ISelectSummary, IBoundPresentation {


    public CatalogedEntry CatalogedEntry {get; set; }

    public override string Display => "An Account";
    public string? SecondaryValue => "TBS";
    public string? LabelValue => Display;

    public string? IconValue => "account.png";


    }

#endregion
//#region // Binding to classes specified in the Mesh schema

///// <summary>
///// Extends <see cref="CatalogContact"/> to override the <see cref="Intern"/> method
///// so as to allow the bound selection boxes to be updated.
///// </summary>
//public class GuigenCatalogContact : CatalogContact {

//    /// <summary>
//    /// Factory delegate
//    /// </summary>
//    /// <param name="directory">Directory of store file on local machine.</param>
//    /// <param name="storeId">Store identifier.</param>
//    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
//    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
//    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
//    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
//    /// <param name="create">If true, create a new file if none exists.</param>
//    /// <param name="meshClient">The mesh client.</param>
//    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
//    /// <returns>The instance created.</returns>
//    public static new Store Factory(
//            string directory,
//                string storeId,
//                IMeshClient meshClient = null,
//                DarePolicy policy = null,
//                CryptoParameters cryptoParameters = null,
//                IKeyCollection keyCollection = null,
//                bool decrypt = true,
//                bool create = true,
//                byte[] bitmask = null) =>
//        new GuigenCatalogContact(directory, storeId, policy, cryptoParameters, keyCollection,
//            decrypt, create, bitmask: bitmask);


//    /// <summary>
//    /// Constructor for a catalog named <paramref name="storeName"/> in directory
//    /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
//    /// and key collection <paramref name="keyCollection"/>.
//    /// </summary>
//    /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
//    /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
//    /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
//    /// <param name="storeName">The catalog persistence container file name.</param>
//    /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
//    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
//    /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
//    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
//    public GuigenCatalogContact(
//                string directory,
//                string storeName = null,
//                DarePolicy policy = null,
//                CryptoParameters cryptoParameters = null,
//                IKeyCollection keyCollection = null,
//                bool decrypt = true,
//                bool create = true,
//                byte[] bitmask = null) :
//        base(directory, storeName ?? Label,
//                    policy, cryptoParameters, keyCollection,
//                    decrypt: decrypt, create: create, bitmask: bitmask) {
//        }

//    public override void Intern(SequenceIndexEntry indexEntry) {
//        base.Intern(indexEntry);
//        }



//    }


//#endregion


#region // Selection Catalog backing type.

public partial class AccountSelection : SelectionCatalog<GuigenCatalogContact,
            CatalogedContact, BoundAccount> {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public AccountSelection(GuigenCatalogContact catalog) : base(catalog) {
        }

    #region // Conversion overrides
    public override CatalogedContact CreateFromBindable(IBindable contact) {
        throw new NYI();
        }


    public override BoundAccount ConvertToBindable(CatalogedContact input) {
        throw new NYI();
        }


    public override CatalogedContact UpdateWithBindable(IBindable entry) {
        throw new NYI();
        }


    #endregion
    }


#endregion