using System;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;
using Goedel.Catalog;
using Goedel.Catalog.Client;
namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {
        CatalogNetwork CatalogNetwork => CatalogSession.CatalogNetwork;

        public void NetworkAdd(
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

        public void NetworkDelete(
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

        public ResultDump NetworkDump() {
            var Result = new ResultDump() {
                Success = true,
                Reason = "Output credential data",
                Data = CatalogNetwork.GetJson(true)
                };

            ReportResult(Result);
            return Result;
            }

        }
    }
