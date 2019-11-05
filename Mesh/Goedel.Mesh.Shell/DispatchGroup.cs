using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupCreate(GroupCreate Options) {
            var groupID = Options.GroupID.Value;

            using (var contextAccount = GetContextAccount(Options)) {

                var contextGroup = contextAccount.CreateGroup(groupID);

                var result = new ResultEntry() {
                    CatalogEntry = contextGroup.CatalogedGroup
                    };
                return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupAdd(GroupAdd Options) {
            var groupID = Options.GroupID.Value;
            var memberID = Options.MemberID.Value;
            using (var contextAccount = GetContextAccount(Options)) {
                using (var contextGroup = contextAccount.GetContextGroup(groupID)) {

                    //Contact contact = null;
                    "Implement pulling contact from contacts catalog".TaskFunctionality(false);

                    var entryMember = contextGroup.Add(memberID);

                    var result = new ResultEntry() {
                        CatalogEntry = entryMember
                        };
                    return result;

                    }
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupGet(GroupGet Options) {
            var groupID = Options.GroupID.Value;
            var memberID = Options.MemberID.Value;
            using (var contextAccount = GetContextAccount(Options)) {
                using (var contextGroup = contextAccount.GetContextGroup(groupID)) {
                    var member = contextGroup.Locate(memberID);

                    var result = new ResultEntry() {
                        Success = member != null,
                        CatalogEntry = member
                        };
                    return result;
                    }
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupDelete(GroupDelete Options) {
            var groupID = Options.GroupID.Value;
            var memberID = Options.MemberID.Value;
            using (var contextAccount = GetContextAccount(Options)) {
                using (var contextGroup = contextAccount.GetContextGroup(groupID)) {

                    var member = contextGroup.Locate(memberID);
                    contextGroup.Delete(member);

                    var result = new ResultEntry() {
                        Success = member != null,
                        CatalogEntry = member
                        };

                    return result;
                    }
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupList(GroupList Options) {
            var groupID = Options.GroupID.Value;

            using (var contextAccount = GetContextAccount(Options)) {
                using (var catalog = contextAccount.GetContextGroup(groupID)) {
                    var catalogedEntries = new List<CatalogedEntry>();

                    "Fill in the member entries".TaskFunctionality();

                    var result = new ResultDump() {
                        Success = true,
                        CatalogedEntries = catalogedEntries
                        };
                    return result;
                    }
                }

            }
        }
    }
