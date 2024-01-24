namespace Goedel.Everything;

public abstract class SelectionSpool<TCatalog, TBindable> : SelectionStore<TCatalog, SpoolIndexEntry, Message, TBindable>,
                        ISelectCollection
                    where TCatalog : Spool
                    //where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {


    public TCatalog Catalog => Store;
    public string Tag = null;

    public SelectionSpool(TCatalog store) : base(store) {
        foreach (var index in store.GetMessages()) {
            if (index.HasPayload & (
                    Tag == null || index.MessageType == Tag)) {
                var meshMessage = index.Message;
                if (meshMessage != null) {

                    var bindable = ConvertToBindable(index);
                    Entries.Add(bindable);

                    }
                }
            }

        }





    public override void Add(IBoundPresentation item) {
        //var contact = CreateFromBindable(item);
        //Catalog.New(contact);
        //Entries.Add(item);
        }

    public override void Remove(IBoundPresentation item) {
        }

    public override void Update(IBoundPresentation item) {
        }

    }

