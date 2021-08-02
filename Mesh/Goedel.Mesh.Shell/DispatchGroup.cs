using System.Collections.Generic;

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method to create a new group.
        /// </summary>
        /// <param name="options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupCreate(GroupCreate options) {
            var groupID = options.GroupID.Value;

            var contextAccount = GetContextUser(options);
            var contextGroup = contextAccount.CreateGroup(groupID);

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


            var entryMember = contextGroup.Add(memberID);

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
            contextGroup.Delete(member);

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
    }
