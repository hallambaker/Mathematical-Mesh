namespace Goedel.Everything;
public partial class EverythingMaui {

    ///<inheritdoc/>
    public override async Task<IResult> AddPassword(AddPassword data) {

        var entry = new CatalogedCredential() {
            Protocol = data.Protocol,
            Service = data.Service,
            Username = data.Username,
            Password = data.Password
            };

        await CurrentAccount.Credentials.AddAsync(entry);

        return NullResult.Completed;
        }

    ///<inheritdoc/>
    public override async Task<IResult> CredentialUpdate(BoundCredential entry) {
        entry.SetBound();

        await CurrentAccount.Credentials.UpdateAsync(entry);

        return NullResult.Completed;
        }

    ///<inheritdoc/>
    public override async Task<IResult> CredentialDelete(BoundCredential entry) {
        entry.SetBound();

        await CurrentAccount.Credentials.UpdateAsync(entry);

        return NullResult.Completed;
        }


    // Focus: 030 Work out how to handle passkeys.

    ///<inheritdoc/>
    public override async Task<IResult> AddPasskey(AddPasskey data) => await NotYetImplemented();

    }



