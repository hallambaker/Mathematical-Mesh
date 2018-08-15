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
                string ID) {
            Result Result = null;

            var EntryCalendar = new EntryCalendar() {
                ID =ID
                };

            CatalogCalendar.Update(EntryCalendar);

            Result = new Result() {
                Success = true,
                Reason = "Added entry to calendar"
                };

            ReportResult(Result);
            }

        public void CalendarDelete(
                    string Identifier
                    ) {
            Result Result = null;

            CatalogCalendar.Delete(Identifier);

            Result = new Result() {
                Success = true,
                Reason = "Deleted entry from calendar"
                };

            ReportResult(Result);
            }

        public ResultDump CalendarDump() {

            var Result = new ResultDump() {
                Success = true,
                Reason = "Output calendar data",
                Data = CatalogCalendar.GetJson(true)
                };

            ReportResult(Result);
            return Result;
            }
        }
    }
