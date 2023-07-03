using System.Collections;

namespace Goedel.Everything;

public class CatalogSelector : ISelectCollection {

    public Store Store;



    public List<string> Test => new List<string>() { "apple", "bob" };

    public GuiBinding Binding { get; set; }

    public Func<GuiBinding, object> BindingDelegate { get; }

    public CatalogSelector(Store store) {
        Store = store;
        BindingDelegate = EverythingMaui.GetBinding;
        }

    public IEnumerator GetEnumerator() => Store.Enumerate();
    }



