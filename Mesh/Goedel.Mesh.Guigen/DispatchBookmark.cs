namespace Goedel.Everything;


public partial class AddFeed {





    //public override IResult Validate(Gui gui) {


    //    return NullResult.Valid;
    //    }

    }
public partial class EverythingMaui {

 


    ///<inheritdoc/>
    public override async Task<IResult> AddFeed(AddFeed data) {
        var uid = Udf.Nonce();

        var uri = data.Uri ??= $"{data.Site}:{data.Account}";
        var title = data.Title ?? uri;

        var entry = new CatalogedFeed() {
            Uri = uri,
            Title = title,
            LocalName = data.Path,
            Uid = uid
            };

        await CurrentAccount.Feeds.AddAsync(entry);

        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> AddBookmark(AddBookmark data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedBookmark() {
            Uri = data.Uri,
            Title = data.Title,
            LocalName = data.Path,
            Uid = uid
            };

        await CurrentAccount.Bookmarks.AddAsync(entry);

        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> BookmarkUpdate(BoundBookmark entry) {
        entry.SetBound();
        await CurrentAccount.Bookmarks.UpdateAsync(entry);


        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> BookmarkDelete(BoundBookmark entry) {

        await CurrentAccount.Bookmarks.DeleteAsync(entry);


        return NullResult.Completed;
        }
    }
