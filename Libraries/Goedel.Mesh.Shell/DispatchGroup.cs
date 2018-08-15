using System;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;
using Goedel.Catalog;
using Goedel.Catalog.Client;
namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {
        CatalogGroup CatalogGroup => CatalogSession.CatalogGroup;

        public void GroupAdd(
                string ID
                ) {
            Result Result = null;

            var EntryGroup = new EntryGroup() {
                ID = ID
                };
            CatalogGroup.Update(EntryGroup);

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void GroupCreate(
                string GroupID
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void GroupUser(
                string GroupID,
                string MemberID
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void GroupDelete(
                string GroupID,
                string MemberID
                ) {
            Result Result = null;

            CatalogGroup.Delete(GroupID);

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public ResultDump GroupDump() {
            var Result = new ResultDump() {
                Success = true,
                Reason = "Output group data",
                Data = CatalogGroup.GetJson(true)
                };

            ReportResult(Result);
            return Result;
            }
        }
    }
