using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Catalog;
using Goedel.Catalog.Client;
namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {

        CatalogContact CatalogContact => CatalogSession.CatalogContact;

        public void ContactAdd(
                string File
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void ContactDelete(
                string Identifier
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void ContactdGet(
                string Identifier
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public ResultDump ContactDump() {

            var Result = new ResultDump() {
                Success = true,
                Reason = "Output calendar data",
                Data = CatalogContact.GetJson(true)
                };

            ReportResult(Result);
            return Result;
            }

        }
    }
