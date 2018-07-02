using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Catalog;
using Goedel.Catalog.Client;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {
        CatalogCalendar CatalogCalendar => CatalogSession.CatalogCalendar;

        public void CalendarAdd(
                string File) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void CalendarDelete(
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

        public void CalendarDump() {
            Result Result = null;

            // stuff

            //Output.WriteLine(CalendarSession.CalendarCatalog.GetJson(true));

            Result = new Result() {
                Success = true,
                Reason = "Output bookmark data"
                };

            ReportResult(Result);
            }
        }
    }
