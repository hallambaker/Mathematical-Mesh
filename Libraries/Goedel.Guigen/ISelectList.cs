using System.Collections.ObjectModel;

namespace Goedel.Guigen;
public interface ISelectList {
    ObservableCollection<IBindable> Entries { get; }

    void Add(IBoundPresentation item);
    void Remove(IBoundPresentation item);
    }