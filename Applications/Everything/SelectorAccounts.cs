using Goedel.Cryptography.Dare;

using System.Collections;
using System.Collections.Specialized;



namespace Goedel.Everything;

/*
 
NB This will need very special treatment as it is not backed by a catalog in the account
 
 */




#region // Bindings to classes specified through the Guigen schema.


public partial class BoundAccount : IBoundPresentation, IDialog {


    public override string Display => "An Account";

    public GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundAccount;


    public static BoundAccount Convert(ContextUser input) {


        var result = new BoundAccount() {
            Service = input.ServiceDns,
            Display = "TBS",
            UDF = input.Profile.UdfString
            };

        return result;

        }



    }

#endregion

#region // Selection Catalog backing type.

// ToDo: move this to store / enumerate the Context User entries...
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