using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

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

                var CataloguedGroup = contextAccount.CreateGroup(groupID);

                var result = new ResultEntry() {
                    CatalogEntry = CataloguedGroup
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
                using (var catalog = contextAccount.GetCatalogGroup(groupID)) {

                    //Contact contact = null;
                    "Implement pulling contact from contacts catalog".TaskFunctionality(false);

                    var entryMember = catalog.Add(memberID);

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
                using (var catalog = contextAccount.GetCatalogGroup(groupID)) {
                    var member = catalog.Locate(memberID);

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
                using (var catalog = contextAccount.GetCatalogGroup(groupID)) {
                   
                    var member = catalog.Locate(memberID);
                    catalog.Delete(member);

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
                using (var catalog = contextAccount.GetCatalogGroup(groupID)) {
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
