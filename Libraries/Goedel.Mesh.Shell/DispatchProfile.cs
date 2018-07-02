using System;
using System.Collections.Generic;
using System.IO;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Portal.Client;

namespace Goedel.Mesh.Shell {
    public partial class ShellDispatch {

        public void ProfileReset() {
            Result Result = null;

            MeshMachine.EraseTest();

            Result = new Result() {
                Success = true,
                Reason = "Debug profiles erased"
                };

            ReportResult(Result);
            }


        public void DeviceCreate(
                String DeviceID,
                String DeviceDescription,
                bool Default) {

            ResultDeviceCreate Result = null;

            var DeviceSession = MeshMachine.CreateDevice(
                        DeviceID, DeviceDescription, Default);
            var Profile = DeviceSession.DeviceProfile;
            Result = new ResultDeviceCreate() {
                Success = true,
                Reason = "Created Device Profile",
                DeviceUDF = Profile.UDF,
                Default = MeshMachine.Device == DeviceSession
                };

            ReportResult(Result);
            }

        public void PersonalCreate(
                    string NewAccountID) {
            Result Result = null;

            var PersonalProfile = new PersonalProfile(SessionDevice.DeviceProfile);
            var Registration = MeshMachine.CreateAccount(NewAccountID, PersonalProfile);

            Result = new ResultPersonalCreate() {
                Success = true,
                Reason = "Created Personal Profile",
                PersonalUDF = PersonalProfile.UDF,
                Default = MeshMachine.Personal == Registration
                };

            ReportResult(Result);
            }

        public void ProfileValidate(
                    string NewAccountID) {
            Result Result = null;

            // stuff
            var Response = MeshMachine.Validate(NewAccountID);

            Result = new Result() {
                Success = true,
                };

            if (Response.Valid) {
                Result.Reason = $"Account identifier [{NewAccountID}] is acceptable";
                }
            else {
                Result.Reason = $"Account identifier [{NewAccountID}] is not acceptable";
                }

            ReportResult(Result);
            }


        public void ProfileRegister(
                    string NewAccountID) {
            Result Result = null;

            MeshMachine.CreateAccount(NewAccountID, SessionPersonal);

            Result = new Result() {
                Success = true,
                Reason = "Registered profile to additional account."
                };

            ReportResult(Result);
            }

        public void ProfileSync() {
            Result Result = null;

            MeshMachine.Sync();

            Result = new Result() {
                Success = true,
                Reason = "Synchronized profiles"
                };

            ReportResult(Result);
            }

        public void ProfileEscrow(
                int Quorum,
                int Shares
                ) {

            Assert.NotNull(SessionPersonal, AccountNotFound.Throw);
            SessionPersonal.Escrow(Quorum, Shares);
            

            var Result = new Result() {
                Success = true,
                Reason = "Created and registered escrow entry."
                };

            ReportResult(Result);
            }

        public void ProfileRecover(
                string File,
                List<string> Shares) {
            Result Result = null;

            // stuff

            var Secret = new Goedel.Cryptography.Secret(Shares);
            SessionPersonal = MeshMachine.Recover(Secret);

            Result = new Result() {
                Success = true,
                Reason = "Recovered Personal Profile"
                };

            ReportResult(Result);
            }

        public void ProfileExport(
                string FileName
                ) {
            Result Result = null;

            FileName = FileName ?? SessionPersonal.UDF + ".mmp";
            File.WriteAllText(FileName, SessionPersonal.SignedPersonalProfile.ToString());

            Result = new Result() {
                Success = true,
                Reason = $"Exported personal profile to {FileName}"
                };

            ReportResult(Result);
            }

        public void ProfileImport(
                string File
                ) {
            Result Result = null;

            // stuff
            Assert.NYI("Re-import of a saved profile is not yet supported.");

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }

        public void ProfileList() {
            Result Result = null;

            // stuff
            foreach (var PersonalProfileEntry in MeshMachine.PersonalProfilesUDF) {
                var SignedPersonalProfile = PersonalProfileEntry.Value?.SignedPersonalProfile;
                SignedPersonalProfile.Describe(Output);
                }

            foreach (var ApplicationProfileEntry in MeshMachine.ApplicationProfilesByUDF) {
                var SignedApplicationProfile = ApplicationProfileEntry.Value?.SignedApplicationProfile;
                SignedApplicationProfile.Describe(Output);
                }


            Result = new Result() {
                Success = true,
                Reason = "Listed Profiles"
                };

            ReportResult(Result);
            }

        public void ProfileDump() {
            Result Result = null;

            // stuff
            Assert.NotNull(SessionPersonal, AccountNotFound.Throw);
            SessionPersonal.SignedPersonalProfile?.Describe(Output);

            Result = new Result() {
                Success = true,
                Reason = "Described profile"
                };

            ReportResult(Result);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Portal"></param>
        /// <param name="PIN"></param>
        public void ProfileConnect(
                string Portal,
                string PIN
                ) {
            Result Result = null;

            MeshMachine.Connect(SessionDevice, Portal, out var Authenticator);


            Result = new ResultConnect() {
                Success = true,
                Reason = "Posted connection request",
                Authenticator = Authenticator
                };

            ReportResult(Result);
            }

        public void ProfilePending() {
            Result Result = null;

            // stuff
            Assert.NotNull(SessionPersonal, AccountNotFound.Throw);
            var Pending = SessionPersonal.ConnectPending();
            Assert.NYI("List pending connections,");

            Result = new Result() {
                Success = true,
                Reason = "Created Device Profile"
                };

            ReportResult(Result);
            }



        public void ProfileAccept(
                string CompletionCode
                ) {
            Result Result = null;

            Assert.NotNull(SessionPersonal, AccountNotFound.Throw);
            SessionPersonal.ConnectClose(CompletionCode, ConnectionStatus.Accepted);
            // stuff

            Result = new Result() {
                Success = true,
                Reason = "Accepted connection request"
                };

            ReportResult(Result);
            }

        public void ProfileReject(
                string CompletionCode
                ) {
            Result Result = null;

            Assert.NotNull(SessionPersonal, AccountNotFound.Throw);
            SessionPersonal.ConnectClose(CompletionCode, ConnectionStatus.Rejected);

            Result = new Result() {
                Success = true,
                Reason = "Rejected connection request"
                };

            ReportResult(Result);
            }

        public void ProfileComplete() {
            Result Result = null;

            Assert.NotNull(SessionPersonal, AccountNotFound.Throw);
            var ConnectionStatus = SessionPersonal.CompleteConnect();

            Result = new ResultComplete() {
                Success = true,
                Reason = "Completed connection",
                ConnectionStatus = ConnectionStatus.ToString()
                };

            ReportResult(Result);
            }

        public void ProfileGetPIN(
                int Length
                ) {
            Result Result = null;

            Assert.NotNull(SessionPersonal, AccountNotFound.Throw);
            var PIN = SessionPersonal.GetPin(Length);

            Result = new ResultPIN() {
                Success = true,
                Reason = "PIN code issued",
                PIN = PIN
                };

            ReportResult(Result);
            }

        }
    }
