using Goedel.Utilities;
using Goedel.Cryptography.Dare;

using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method to create a new group.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupCreate(GroupCreate Options) {
            var groupID = Options.GroupID.Value;

            using var contextAccount = GetContextAccount(Options);
            var contextGroup = contextAccount.CreateGroup(groupID);

            var result = new ResultEntry() {
                CatalogEntry = contextGroup.CatalogedGroup
                };
            return result;
            }

        /// <summary>
        /// Dispatch method to add a member to the group.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupAdd(GroupAdd Options) {
            var groupID = Options.GroupID.Value;
            var memberID = Options.MemberID.Value;
            using var contextAccount = GetContextAccount(Options);
            using var contextGroup = contextAccount.GetContextGroup(groupID);

            var entryMember = contextGroup.Add(memberID);

            var result = new ResultEntry() {
                CatalogEntry = entryMember
                };
            return result;
            }

        /// <summary>
        /// Dispatch method to fetch a group member's record.
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupGet(GroupGet Options) {
            var groupID = Options.GroupID.Value;
            var memberID = Options.MemberID.Value;
            using var contextAccount = GetContextAccount(Options);
            using var contextGroup = contextAccount.GetContextGroup(groupID);
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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupDelete(GroupDelete Options) {
            var groupID = Options.GroupID.Value;
            var memberID = Options.MemberID.Value;
            using var contextAccount = GetContextAccount(Options);
            using var contextGroup = contextAccount.GetContextGroup(groupID);
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
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupList(GroupList Options) {
            var groupID = Options.GroupID.Value;

            using var contextAccount = GetContextAccount(Options);
            using var catalog = contextAccount.GetContextGroup(groupID);
            var catalogedEntries = new List<CatalogedEntry>();

            var result = new ResultDump() {
                Success = true,
                CatalogedEntries = catalogedEntries
                };
            return result;

            }
        }
    }
