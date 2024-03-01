namespace Goedel.Everything;
public partial class EverythingMaui {

    ///<inheritdoc/>
    public override async Task<IResult> AddTask(AddTask data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedTask() {
            Uid = uid,
            Title = data.Title,
            Path = data.Path,
            Description = data.Description
            };

        await CurrentAccount.Tasks.AddAsync(entry);

        return NullResult.Completed;
        }

    ///<inheritdoc/>
    public override async Task<IResult> TaskUpdate(BoundTask entry) {
        entry.SetBound();

        await CurrentAccount.Tasks.UpdateAsync(entry);

        return NullResult.Completed;
        }

    ///<inheritdoc/>
    public override async Task<IResult> TaskDelete(BoundTask entry) {

        await CurrentAccount.Tasks.DeleteAsync(entry);

        return NullResult.Completed;

        }
    }
