using System.Collections;
using System.Collections.ObjectModel;

namespace Goedel.Guigen;


public interface ISelectSummary {

    string? LabelValue { get; }


    string? IconValue { get;}
    }


public interface ISelectCollection : IEnumerable{

    ObservableCollection<object> Entries { get; }



    void Add(IBindable item);

    void Remove(IBindable item);




    }


public class SelectList : ISelectCollection {
    public ObservableCollection<object> Entries { get; } = new();

    public void Add(IBindable item) => Entries.Add(item);

    public IEnumerator GetEnumerator() => Entries.GetEnumerator();

    public void Remove(IBindable item) => Entries.Remove(item);



    }