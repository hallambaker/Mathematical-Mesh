using System.Collections;

namespace Goedel.Everything;

public static class Extensions {
    public static List<string> ParseComments(this string text) =>
        new List<string> { text };

    public static string ParseComments(this List<string> texts) =>
        texts.First();

    public static string? NullifyIfEmpty(this string text) => text == "" ? null : text;
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
    public abstract Task<IResult> Add(IBoundPresentation item);

    ///<inheritdoc/>
    public abstract Task<IResult> Update(IBoundPresentation item);

    ///<inheritdoc/>
    public abstract Task<IResult> Remove(IBoundPresentation item);



    }



public abstract class SelectionCatalog<TCatalog, TPersist, TBindable> : SelectionStore<TCatalog, TPersist, TPersist, TBindable>,
                        ISelectCollection
                    where TCatalog : Catalog<TPersist?>
                    where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {

    public TCatalog Catalog => Store;
    public ContextAccount ContextAccount { get; set; }

    public SelectionCatalog(
                    ContextAccount contextAccount,
                    TCatalog store) : base(store) {
        ContextAccount = contextAccount;
        foreach (var item in store) {
            if (Include(item)) {
                var bound = ConvertToBindable(item);
                bound.Bound = item;
                Entries.Add(bound);
                }
            }
        }


    public virtual bool Include(TPersist? item) => true;

    public override async Task<IResult> Add(IBoundPresentation item) {
        try {
            await AddAsync(item);
            return NullResult.Completed;
            }
        catch (Exception e) {
            return new ErrorResult(e);
            }
        }



    public override async Task<IResult> Remove(IBoundPresentation item) {
        try {
            await RemoveAsync(item);
            return NullResult.Completed;
            }
        catch (Exception e) {
            return new ErrorResult(e);
            }
        }


    public override async Task<IResult> Update(IBoundPresentation item) {
        try {
            await UpdateAsync(item);
            return NullResult.Completed;
            }
        catch (Exception e) {
            return new ErrorResult(e);
            }
        }



    public async Task<TransactResponse> AddAsync(IBoundPresentation item) {
        var entry = item.Bound as TPersist;

        var transaction = ContextAccount.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        var result = await transaction.TransactAsync();

        Entries.Add(item);
        return result;
        }

    public async Task<TransactResponse> RemoveAsync(IBoundPresentation item) {
        var entry = item.Bound as TPersist;

        var transaction = ContextAccount.TransactBegin();
        transaction.CatalogDelete(Catalog, entry);
        var result = await transaction.TransactAsync();

        Entries.Remove(item);
        return result;
        }


    public async Task<TransactResponse> UpdateAsync(IBoundPresentation item) {
        UpdateWithBindable(item);
        var entry = item.Bound as TPersist;

        var transaction = ContextAccount.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        var result = await transaction.TransactAsync();

        return result;
        }

    StoreUpdate StartTransaction() => new StoreUpdate() {
        Store = Catalog.StoreName,
        Envelopes = new()
        };


    }

