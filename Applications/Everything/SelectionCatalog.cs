using Goedel.Mesh;

using Microsoft.Maui.ApplicationModel.Communication;

using System.Collections;

namespace Goedel.Everything;


public abstract class SelectionStore<TStore, TPersist, TBindable> : ISelectCollection
                    where TStore : Store
                    //where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {

    public TStore Store { get; }

    public ObservableCollection<IBindable> Entries { get; } = new();

    public SelectionStore(TStore store) {
        Store = store;
        }

    ///<summary>Type check</summary> 
    public bool IsPersistedType(object data) => data is TPersist;

    ///<inheritdoc/>
    public virtual IEnumerator GetEnumerator() => Entries.GetEnumerator();

    ///<summary>Convert the Gui contact form to a cataloged contact</summary> 
    public abstract TPersist ConvertFromBindable(IBindable contact);

    ///<summary>Convert the Gui contact form to a cataloged contact</summary> 
    public abstract IBindable ConvertToBindable(TPersist cataloged);

    ///<inheritdoc/>
    public abstract void Add(IBindable item);

    ///<inheritdoc/>
    public abstract void Update(IBindable item);

    ///<inheritdoc/>
    public abstract void Remove(IBindable item);
    }



public abstract class SelectionCatalog<TCatalog,TPersist,TBindable> : SelectionStore<TCatalog, TPersist, TBindable>,
                        ISelectCollection 
                    where TCatalog : Catalog<TPersist>
                    where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {

    public TCatalog Catalog => Store;

    public SelectionCatalog(TCatalog store) : base (store){
        foreach (var item in store) {
            var bound = ConvertToBindable(item);
            Entries.Add(bound);
            }
        }

    public override void Add(IBindable item) {
        var contact = ConvertFromBindable(item);
        Catalog.New(contact);
        Entries.Add(item);
        }

    public override void Remove(IBindable item) { 
        }

    public override void Update(IBindable item) {
        }

    }


public abstract class SelectionSpool<TCatalog, TBindable> : SelectionStore<TCatalog, SpoolIndexEntry, TBindable>,
                        ISelectCollection
                    where TCatalog : Spool
                    //where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {

    public TCatalog Catalog => Store;

    public SelectionSpool(TCatalog store) : base(store) {
        //foreach (var item in store) {
        //    var bound = ConvertToBindable(item);
        //    Entries.Add(bound);
        //    }
        }

    public override void Add(IBindable item) {
        //var contact = ConvertFromBindable(item);
        //Catalog.New(contact);
        //Entries.Add(item);
        }

    public override void Remove(IBindable item) {
        }

    public override void Update(IBindable item) {
        }

    }

