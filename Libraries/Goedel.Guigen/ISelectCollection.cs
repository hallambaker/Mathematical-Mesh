﻿using System.Collections;
using System.Collections.ObjectModel;

namespace Goedel.Guigen;


public interface IBoundPresentation : IBindable{

    object Bound { get; set; }
    
    }

public interface ISelectSummary {

    string? LabelValue { get; }


    string? IconValue { get;}
    }


public interface ISelectCollection : IEnumerable{

    ObservableCollection<IBindable> Entries { get; }



    void Add(IBindable item);

    void Remove(IBindable item);




    }


public class SelectList : ISelectCollection {
    public ObservableCollection<IBindable> Entries { get; } = new();

    public void Add(IBindable item) => Entries.Add(item);

    public IEnumerator GetEnumerator() => Entries.GetEnumerator();

    public void Remove(IBindable item) => Entries.Remove(item);



    }