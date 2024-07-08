using Goedel.Mesh;

namespace Goedel.Everything;
public partial class EverythingMaui {

    ///<inheritdoc/>
    public override async Task<IResult> AddGroup(AddGroup data) {

        var rights = new List<string> { "super", "admin" };

        var contextGroup = await ContextUser.CreateGroupAsync(
                data.GroupAddress, data.GroupName, roles: rights);


        var entry = new BoundApplicationGroup(contextGroup, ContextUser);
        CurrentAccount.Groups.Add(entry);

        return new SuccessGroupCreate(){
            GroupName = entry.GroupName,
            GroupAddress = entry.GroupAddress
            };

        }


    ///<inheritdoc/>
    public override async Task<IResult> GroupInvite(GroupInvite data) {

        //var context = data.Context;
        var contextGroup = data.Context.ContextGroup;
        var member = await contextGroup.AddAsync(data.Address, data.Message);

        return NullResult.Completed;
        }


    ///<inheritdoc/>
    //public override async Task<IResult> MemberReInvite(BoundGroupMember data) {
    //    return await NotYetImplemented();


    //    //var contextGroup = data.BoundGroup.GetContext();
    //    //await contextGroup.DeleteAsync(data.CatalogedMember);

    //    //return NullResult.Completed;
    //    }

    ///<inheritdoc/>
    public override async Task<IResult> MemberDelete(BoundGroupMember data) {
        var contextGroup = data.BoundGroup.ContextGroup;
        await contextGroup.DeleteAsync(data.CatalogedMember);

        return NullResult.Completed;
        }



    }


public partial class GroupInvite {
    public BoundApplicationGroup BoundGroup { get; set; }
    }



