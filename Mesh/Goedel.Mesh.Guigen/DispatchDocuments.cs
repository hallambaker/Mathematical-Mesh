namespace Goedel.Everything;
public partial class EverythingMaui {

    // Focus: 040 Implement the document repository features.
    // Focus: 041 Need a file handling dialog

    ///<inheritdoc/>
    public override async Task<IResult> UploadDocument(UploadDocument data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedDocument() {
            Uid = uid,
            Title = data.Title,
            Path = data.Path,
            Description = data.Description
            };

        await CurrentAccount.Documents.AddAsync(entry);

        return NullResult.Completed;
        }

    ///<inheritdoc/>
    public override async Task<IResult> DocumentDelete(BoundDocument entry) {

        await CurrentAccount.Documents.DeleteAsync(entry);

        return NullResult.Completed;

        }


    // Focus: 042 Document update

    ///<inheritdoc/>
    public override async Task<IResult> DocumentUpdate(BoundDocument data) => await NotYetImplemented();



    // Focus: 041 Need a file handling dialog
    ///<inheritdoc/>
    public override async Task<IResult> DocumentExport(BoundDocument data) => await NotYetImplemented();
    }
