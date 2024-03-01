namespace Goedel.Everything;
public partial class EverythingMaui {

    ///<inheritdoc/>
    public override async Task<IResult> AddMailAccount(AddMailAccount data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedApplicationMail() {
            Uid = uid,
            LocalName = data.LocalName,
            Path = data.Path,
            Description = data.Description,
            AccountAddress = data.AccountAddress,
            InboundConnect = data.InboundConnect,
            OutboundConnect = data.OutboundConnect
            };

        // Focus: 100 Add in key generation here

        await CurrentAccount.Applications.AddAsync(entry);

        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> AddSshAccount(AddSshAccount data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedApplicationSsh() {
            Uid = uid,
            LocalName = data.LocalName,
            Path = data.Path,
            Description = data.Description
            };

        // Focus: 100 Add in key generation here

        await CurrentAccount.Applications.AddAsync(entry);

        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> AddGitAccount(AddGitAccount data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedApplicationGit() {
            Uid = uid,
            LocalName = data.LocalName,
            Path = data.Path,
            Description = data.Description
            };

        // Focus: 100 Add in key generation here

        await CurrentAccount.Applications.AddAsync(entry);

        return NullResult.Completed;
        }


    ///<inheritdoc/>
    public override async Task<IResult> AddCodeSigningKey(AddCodeSigningKey data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedApplicationDeveloper() {
            Uid = uid,
            LocalName = data.LocalName,
            Path = data.Path,
            Description = data.Description
            };

        // Focus: 100 Add in key generation here

        await CurrentAccount.Applications.AddAsync(entry);

        return NullResult.Completed;
        }


    ///<inheritdoc/>
    public override async Task<IResult> ApplicationUpdate(BoundApplication entry) {
        entry.SetBound();

        await CurrentAccount.Applications.UpdateAsync(entry);

        return NullResult.Completed;
        }

    ///<inheritdoc/>
    public override async Task<IResult> ApplicationDelete(BoundApplication entry) {

        await CurrentAccount.Applications.DeleteAsync(entry);

        return NullResult.Completed;

        }

    }
