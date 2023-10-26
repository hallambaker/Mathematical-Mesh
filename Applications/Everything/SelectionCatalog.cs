﻿using Goedel.Mesh;

using Microsoft.Maui.ApplicationModel.Communication;

using System.Collections;

namespace Goedel.Everything;

public static class Extensions {
    public static List<string> ParseComments(this string text) =>
        new List<string> { text };

    public static string ParseComments(this List<string> texts) =>
        texts.First();



    public static string NullifyIfEmpty (this string text) => text == "" ? null : text;
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

    ///<summary>Create a new entry from information in the GUI.</summary> 
    public abstract TEnum CreateFromBindable(IBindable contact);

    ///<summary>Update the bound object with information from the GUI and return the 
    ///updated object.</summary> 
    public abstract TPersist UpdateWithBindable(IBindable contact);


    ///<summary>Construct a GUI binding for the entry.</summary> 
    public abstract TBindable ConvertToBindable(TPersist cataloged);


    //public virtual GuiDialog GetDialog(IBindable data) => null;


    ///<inheritdoc/>
    public abstract void Add(IBoundPresentation item);

    ///<inheritdoc/>
    public abstract void Update(IBoundPresentation item);

    ///<inheritdoc/>
    public abstract void Remove(IBoundPresentation item);



    }



public abstract class SelectionCatalog<TCatalog,TPersist,TBindable> : SelectionStore<TCatalog, TPersist, TPersist, TBindable>,
                        ISelectCollection 
                    where TCatalog : Catalog<TPersist>
                    where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {

    public TCatalog Catalog => Store;

    public SelectionCatalog(TCatalog store) : base (store){
        foreach (var item in store) {
            var bound = ConvertToBindable(item);
            bound.Bound = item;
            Entries.Add(bound);
            }
        }

    public override void Add(IBoundPresentation item) {
        var contact = CreateFromBindable(item);
        Catalog.New(contact);
        Entries.Add(item);
        }

    public override void Remove(IBoundPresentation item) {
        Catalog.Delete(item.Bound as TPersist);
        //base.Remove(item);
        }

    public override void Update(IBoundPresentation item) {
        }

    }


public abstract class SelectionSpool<TCatalog, TBindable> : SelectionStore<TCatalog, SpoolIndexEntry, Message, TBindable>,
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

    public override void Add(IBoundPresentation item) {
        //var contact = ConvertFromBindable(item);
        //Catalog.New(contact);
        //Entries.Add(item);
        }

    public override void Remove(IBoundPresentation item) {
        }

    public override void Update(IBoundPresentation item) {
        }

    }

