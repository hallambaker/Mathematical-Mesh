using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Catalog;
using Goedel.Catalog.Client;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {
        CatalogCredential CredentialCatalog => CatalogSession.CatalogCredential;

        public Result PasswordAdd(
                string Site,
                string Username,
                string Password) {
            Result Result = null;

            var CredentialEntry = new EntryCredential() {
                Site = Site,
                Username = Username,
                Password = Password
                };

            CredentialCatalog.Update(CredentialEntry);

            Result = new Result() {
                Success = true,
                Reason = "Credential registered"
                };

            
            return Result;
            }

        public ResultCredential PasswordGet(
                string Site,
                string Protocol = null
                ) {
            ResultCredential Result = null;

            var CredentialEntry = CredentialCatalog.GetBySite(Site, Protocol);

            if (CredentialEntry == null) {
                Result = new ResultCredential() {
                    Success = false,
                    Reason = "Credential not found"
                    };
                }
            else {
                Result = new ResultCredential() {
                    Success = true,
                    Reason = "Credential found",
                    Entry = CredentialEntry
                    };
                }

            ReportResult(Result);
            return Result;
            }

        public Result PasswordDelete(
                string Site,
                string Protocol=null
                ) {
            Result Result = null;

            CredentialCatalog.Delete(Site, Protocol);

            Result = new Result() {
                Success = true,
                Reason = "Credential deleted"
                };

            ReportResult(Result);
            return Result;
            }

        public ResultDump PasswordDump(
                ) {
            var Result = new ResultDump() {
                Success = true,
                Reason = "Output credential data",
                Data = CredentialCatalog.GetJson(true)
                };

            ReportResult(Result);
            return Result;
            }

        }
    }
