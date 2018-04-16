using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Mesh.Portal.Client;
using Goedel.Mesh.Portal;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        //public List<SignedConnectionRequest> SignedConnectionRequests;

        //public string Authenticator;

        /// <summary>
        /// Begin the connection process
        /// </summary>
        /// <param name="Options"></param>
        public override void Connect (Connect Options) {
            var Address = Options.Portal.Value;
            Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);
            SetReporting(Options.Report, Options.Verbose);

            var DeviceRegistration = GetDevice(Options);

            // Fetch the Mesh profile
            MeshClient = new MeshClient(PortalAccount: Address);

            var ConnectStartResponse = MeshClient.ConnectRequest(
                    DeviceRegistration.SignedDeviceProfile,
                    out var DeviceRequest);

            MeshMachine.ConnectStartRequests.Add(DeviceRequest);

            var Authenticator = UDF.FromUDFPair(
                    DeviceRegistration.UDF,
                    MeshClient.PersonalProfile.UDF
                    );

            var Result = new ResultConnectStart() {
                Request = DeviceRequest.SignedRequest,
                Response = ConnectStartResponse,
                ProfileUDF = MeshClient.PersonalProfile.UDF
                };
            LastResult = Result;

            ReportWrite(LastResult.ToString());
            }

        /// <summary>
        /// List pending connection requests
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Pending(Pending Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();

            var Pending = MeshClient.ConnectPending();
            //SignedConnectionRequests = Pending.Pending;

            var Result = new ResultConnectPending() {
                Response = Pending,
                ProfileUDF = PersonalProfile.UDF
                };
            LastResult = Result;

            ReportWrite(LastResult.ToString());
            }

        /// <summary>
        /// Accept a connection request
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Accept(Accept Options) {
            PersonalProfile = null;

            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();



            var DeviceUDF = Options.DeviceUDF.Value;
            Assert.NotNull(DeviceUDF);
            Assert.True(DeviceUDF.Length >= 5);
            DeviceUDF = DeviceUDF.ToUpper();

            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();
            MeshClient.SignedPersonalProfile = PersonalProfile.SignedPersonalProfile;

            var Pending = MeshClient.ConnectPending();
            var SignedConnectionRequests = Pending.Pending;

            SignedConnectionRequest Choice=null;
            foreach (var Request in SignedConnectionRequests) {
                var Device = Request.Data.Device;

                var Authenticator = UDF.FromUDFPair(
                        Device.UDF,
                        PersonalProfile.UDF
                        );

                if (System.String.Compare(DeviceUDF, 0, Authenticator, 0, DeviceUDF.Length) == 0) {
                    Choice = Request;
                    }

                }

            Assert.NotNull(Choice);
            Assert.NotNull(Choice.Data);

            PersonalProfile.Add(Choice.Data);

            var ConnectClose = MeshClient.ConnectClose(Choice, ConnectionStatus.Accepted);

            RegistrationPersonal.WriteToLocal(); // Push the changes to the Mesh

            var Result = new ResultConnectAccept() {
                ProfileUDF = MeshClient.PersonalProfile.UDF,
                Request = Choice
                };
            LastResult = Result;


            ReportWrite(LastResult.ToString());
            }

        /// <summary>
        /// Complete processing of a connection request
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Complete(Complete Options) {
            SetReporting(Options.Report, Options.Verbose);

            int Index = -1;
            if (Options.Portal.ByDefault) {
                Assert.True(MeshMachine.ConnectStartRequests.Count > 0);
                Index = 0;
                }
            else {
                throw new NYI(); // NYI: Handle multiple simultaneous connection requests.
                }
            var ConnectStartRequest = MeshMachine.ConnectStartRequests[Index];

            MeshClient = new MeshClient(PortalAccount: ConnectStartRequest.AccountID);

             var UDF = ConnectStartRequest.SignedRequest.Data.Device.UDF;

            var Response = MeshClient.ConnectStatus(UDF);

            var Result = Response.Result;
            if (Result == null) {
                ReportWriteLine("Request still pending"); // NYI: should expire request etc.
                }
            else {
                var SignedProfile = Result.Data.Profile as SignedPersonalProfile;
                MeshMachine.CreateAccount(ConnectStartRequest.AccountID, SignedProfile.PersonalProfile, MeshClient);
                }

            var ResultConnect = new ResultConnectComplete() {
                Response = Response
                };
            LastResult = Result;

            ReportWrite(ResultConnect.ToString());
            }



        }
    }
