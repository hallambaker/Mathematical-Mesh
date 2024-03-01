#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


namespace Goedel.Mesh.Shell;

public partial class Shell {

    /// <summary>
    /// Dispatch method to create a new group.
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult GroupCreate(GroupCreate options) {
        var rights = GetRights(options);
        var groupID = options.GroupID.Value;
        var groupName = options.GroupName.Value;
        rights ??= new List<string> {"super", "admin" };
        var contextAccount = GetContextUser(options);

        byte[] cover = null;
        if (options.Cover.Value != null) {
             options.Cover.Value.OpenReadToEnd(out cover);
            }


        var contextGroup = contextAccount.CreateGroupAsync(groupID, groupName, roles: rights, cover: cover).Sync();

        //Screen.WriteLine($"Group Encryption key is {contextGroup.ProfileGroup.AccountEncryptionKey.KeyIdentifier}");


        return new ResultCreateAccount() {
            Success = true,
            ProfileAccount = contextGroup.ProfileGroup,
            };
        }

    /// <summary>
    /// Dispatch method to add a member to the group.
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult GroupAdd(GroupAdd options) {
        var groupID = options.GroupID.Value;
        var memberID = options.MemberID.Value;
        var contextAccount = GetContextUser(options);
        var contextGroup = contextAccount.GetContextGroup(groupID);


        var entryMember = contextGroup.AddAsync(memberID).Sync();

        var result = new ResultEntry() {
            CatalogEntry = entryMember
            };
        return result;
        }

    /// <summary>
    /// Dispatch method to fetch a group member's record.
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult GroupGet(GroupGet options) {
        var groupID = options.GroupID.Value;
        var memberID = options.MemberID.Value;
        var contextAccount = GetContextUser(options);
        var contextGroup = contextAccount.GetContextGroup(groupID);
        var member = contextGroup.Locate(memberID);

        var result = new ResultEntry() {
            Success = member != null,
            CatalogEntry = member
            };
        return result;
        }

    /// <summary>
    /// Dispatch method to remove a member from the group.
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult GroupDelete(GroupDelete options) {
        var groupID = options.GroupID.Value;
        var memberID = options.MemberID.Value;
        var contextAccount = GetContextUser(options);
        var contextGroup = contextAccount.GetContextGroup(groupID);
        var member = contextGroup.Locate(memberID);
        member.AssertNotNull(EntryNotFound.Throw, memberID);
        contextGroup.DeleteAsync(member).Sync();

        var result = new ResultEntry() {
            Success = member != null,
            CatalogEntry = member
            };

        return result;
        }

    /// <summary>
    /// Dispatch method to list the members of a group.
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult GroupList(GroupList options) {
        var groupID = options.GroupID.Value;

        var contextAccount = GetContextUser(options);
        var catalog = contextAccount.GetContextGroup(groupID);
        var catalogedEntries = new List<CatalogedEntry>();

        var result = new ResultDump() {
            Success = true,
            CatalogedEntries = catalogedEntries
            };
        return result;

        }
    }
