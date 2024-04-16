using Goedel.Mesh;



using System.Collections;

namespace Goedel.Everything;

public static class Extensions {
    public static List<string> ParseComments(this string text) =>
        new List<string> { text };

    public static string ParseComments(this List<string> texts) =>
        texts.First();

    public static string? NullifyIfEmpty (this string text) => text == "" ? null : text;
    }





public abstract class SelectionStore<TStore, TPersist, TEnum, TBindable> : ISelectCollection
                    where TStore : Store
                    //where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {

    public TStore Store { get; }

    ///<summary>If true, entries in the store are immutable and cannot be changed.</summary> 
    public virtual bool Readonly => false;


    public ObservableCollection<IBindable> Entries { get; } = new();

    public SelectionStore(TStore store) {
        Store = store;
        }

    ///<summary>Type check</summary> 
    public bool IsPersistedType(object data) => data is TPersist;


    ///<inheritdoc/>
    public virtual IEnumerator GetEnumerator() => Entries.GetEnumerator();

    /////<summary>Create a new entry from information in the GUI.</summary> 
    //public abstract TEnum CreateFromBindable(IBindable contact);

    ///<summary>Update the bound object with information from the GUI and return the 
    ///updated object.</summary> 
    public abstract TPersist UpdateWithBindable(IBindable contact);


    ///<summary>Construct a GUI binding for the entry.</summary> 
    public abstract TBindable ConvertToBindable(TPersist cataloged);


    public virtual void ResetBound(TBindable bound) { }

    //public virtual GuiDialog GetDialog(IBindable data) => null;




    ///<inheritdoc/>
    public abstract Task Add(IBoundPresentation item);

    ///<inheritdoc/>
    public abstract Task Update(IBoundPresentation item);

    ///<inheritdoc/>
    public abstract Task Remove(IBoundPresentation item);



    }



public abstract class SelectionCatalog<TCatalog,TPersist,TBindable> : SelectionStore<TCatalog, TPersist, TPersist, TBindable>,
                        ISelectCollection 
                    where TCatalog : Catalog<TPersist?>
                    where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {

    public TCatalog Catalog => Store;
    public ContextAccount ContextAccount { get; set; }

    public SelectionCatalog(
                    ContextAccount contextAccount, 
                    TCatalog store) : base (store){
        ContextAccount = contextAccount;
        foreach (var item in store) {
            var bound = ConvertToBindable(item);
            bound.Bound = item;
            Entries.Add(bound);
            }
        }

    public override async Task Add(IBoundPresentation item) => await AddAsync(item);
     

    public override async Task Remove(IBoundPresentation item) => await RemoveAsync(item);


    public override async Task Update(IBoundPresentation item) => await UpdateAsync(item);


    public async Task<TransactResponse> AddAsync(IBoundPresentation item) {
        var entry = item as TPersist;

        var transaction = ContextAccount.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        var result = await transaction.TransactAsync();

        Entries.Add(item);
        return result;
        }

    public async Task<TransactResponse> RemoveAsync(IBoundPresentation item) {
        var entry = item as TPersist;

        var transaction = ContextAccount.TransactBegin();
        transaction.CatalogDelete(Catalog, entry);
        var result = await transaction.TransactAsync();

        Entries.Remove(item);
        return result;
        }


    public  async Task<TransactResponse> UpdateAsync(IBoundPresentation item) {
        var entry = item.Bound as TPersist;

        var transaction = ContextAccount.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        var result = await transaction.TransactAsync();

        return result;
        }

    StoreUpdate StartTransaction() => new StoreUpdate() { 
        Store = Catalog.StoreName,
        Envelopes = new ()
        };


    }

