using System.Collections;
using System.Collections.ObjectModel;

namespace Goedel.Guigen;


public interface IBoundPresentation : IParameter {

    object Bound { get; set; }
    
    }

public interface ISelectSummary {

    string? LabelValue { get; }


    string? IconValue { get;}
    }


public interface ISelectCollection : IEnumerable{

    ObservableCollection<IBindable> Entries { get; }

    //public  GuiDialog GetDialog(IBindable data);

    void Add(IBoundPresentation item);

    void Remove(IBoundPresentation item);


    void Update(IBoundPresentation item);

    }


public class SelectList : ISelectCollection {
    public ObservableCollection<IBindable> Entries { get; } = new();

    public void Add(IBoundPresentation item) => Entries.Add(item);

    public IEnumerator GetEnumerator() => Entries.GetEnumerator();

    public void Remove(IBoundPresentation item) => Entries.Remove(item);

    public void Update(IBoundPresentation item) {
        }

    //public GuiDialog GetDialog(IBindable data) => null;

    }


