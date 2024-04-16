using System.Collections;
using System.Collections.ObjectModel;

namespace Goedel.Guigen;


public interface IBoundPresentation : IParameter {

    Object? Bound { get; set; }
    
    }

public interface ISelectSummary {

    string? LabelValue { get; }

    string? SecondaryValue { get; }
    string? IconValue { get;}
    }


public interface ISelectCollection : IEnumerable{

    ObservableCollection<IBindable> Entries { get; }

    //public  GuiDialog GetDialog(IBindable data);



    Task Add(IBoundPresentation item);

    Task Remove(IBoundPresentation item);

    Task Update(IBoundPresentation item);


    }



public class SelectList : ISelectList {
    public ObservableCollection<IBindable> Entries { get; } = new();

    public IEnumerator GetEnumerator() => Entries.GetEnumerator();

    public void Add(IBoundPresentation item) {
        Entries.Add(item);
        }

    public void Remove(IBoundPresentation item) {
        Entries.Remove(item);
        }




    }


