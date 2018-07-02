using System;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Catalog;
using Goedel.Catalog.Client;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {

        CatalogBookmark CatalogBookmark => CatalogSession.CatalogBookmark;

        public void BookmarkAdd(
                string Uri,
                string Title,
                string Path
                ) {
            Result Result = null;

            var BookmarkEntry = new EntryBookmark() {
                Title = Title,
                Uri = Uri,
                Path = Path
                };

            CatalogBookmark.Update(BookmarkEntry);

            Result = new Result() {
                Success = true,
                Reason = "Bookmark registered"
                };

            ReportResult(Result);
            }

        public void BookmarkDelete(
                string Uri,
                string Path=null
                ) {
            Result Result = null;

            CatalogBookmark.Delete(Uri);

            Result = new Result() {
                Success = true,
                Reason = "Bookmark deleted"
                };

            ReportResult(Result);
            }

        public ResultDump BookmarkDump() {
            var Result = new ResultDump() {
                Success = true,
                Reason = "Output credential data",
                Data = CatalogBookmark.GetJson(true)
                };

            ReportResult(Result);
            return Result;
            }
        }
    }
