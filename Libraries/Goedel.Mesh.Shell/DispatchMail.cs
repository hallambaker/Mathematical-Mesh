using System;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;
using Goedel.Catalog;
using Goedel.Catalog.Client;
namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {
        CatalogMail CatalogMail => CatalogSession.CatalogMail;

        public void MailAdd(
                string Address
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void MailUpdate(
                string Address
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void MailDelete(
                string Address
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void SMIMEPrivate(
                string Address
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void SMIMEPublic(
                string Address
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void PGPPrivate(
                string Address
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void PGPPublic(
                string Address
                ) {
            Result Result = null;

            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        }
    }
