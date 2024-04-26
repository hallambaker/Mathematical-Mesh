namespace Goedel.Everything;

public abstract class SelectionSpool<TCatalog, TBindable> : SelectionStore<TCatalog, SpoolIndexEntry, Message, TBindable>,
                        ISelectCollection
                    where TCatalog : Spool
                    //where TPersist : CatalogedEntry
                    where TBindable : IBoundPresentation {


    public TCatalog Catalog => Store;
    public string? Tag = null;

    public SelectionSpool(TCatalog store) : base(store) {
        foreach (var index in store.GetMessages()) {
            if (index.HasPayload & (
                    Tag == null || index.MessageType == Tag)) {
                var meshMessage = index.Message;
                if (meshMessage != null) {

                    var bindable = ConvertToBindable(index);
                    if (bindable != null) {
                        Entries.Add(bindable);
                        }

                    }
                }
            }

        }





    public override Task<IResult> Add(IBoundPresentation item) {
        //var contact = CreateFromBindable(item);
        //Catalog.New(contact);
        //Entries.Add(item);

        return new Task<IResult>(() =>NullResult.Completed);
        }

    public override Task<IResult> Remove(IBoundPresentation item) {
        return new Task<IResult>(() => NullResult.Completed);
        }

    public override Task<IResult> Update(IBoundPresentation item) {
        return new Task<IResult>(() => NullResult.Completed);
        }

    }

