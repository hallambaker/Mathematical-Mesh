using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Mesh.Server;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        public List<SignedConnectionRequest> SignedConnectionRequests;

        public string Authenticator;

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

            Machine.ConnectStartRequests.Add(DeviceRequest);

            Authenticator = UDF.FromUDFPair(
                    DeviceRegistration.UDF,
                    MeshClient.PersonalProfile.UDF
                    );
            Console.WriteLine("Connect Request  {0}", Authenticator);
            Console.WriteLine("    Device       {0}", DeviceRegistration.UDF);
            Console.WriteLine("    Profile      {0}", MeshClient.PersonalProfile.UDF);

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
            SignedConnectionRequests = Pending.Pending;
            foreach (var Request in SignedConnectionRequests) {
                var Device = Request.Data.Device;
                var Authenticator = UDF.FromUDFPair(
                        Device.UDF,
                        PersonalProfile.UDF
                        );
                Console.WriteLine("Connect Request  {0}", Authenticator);
                Console.WriteLine("    Device       {0}", Device.UDF);
                Console.WriteLine("    Profile      {0}", PersonalProfile.UDF);
                }
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
            SignedConnectionRequests = Pending.Pending;

            SignedConnectionRequest Choice=null;
            foreach (var Request in SignedConnectionRequests) {
                var Device = Request.Data.Device;

                var Authenticator = UDF.FromUDFPair(
                        Device.UDF,
                        PersonalProfile.UDF
                        );

                if (System.String.Compare(DeviceUDF, 0, Authenticator, 0, DeviceUDF.Length) == 0) {
                    Choice = Request;

                    Console.WriteLine("Connect Request  {0}", Authenticator);
                    Console.WriteLine("    Device       {0}", Device.UDF);
                    Console.WriteLine("    Profile      {0}", PersonalProfile.UDF);
                    }

                }

            Assert.NotNull(Choice);
            Assert.NotNull(Choice.Data);

            PersonalProfile.Add(Choice.Data);

            var Result = MeshClient.ConnectClose(Choice, ConnectionStatus.Accepted);

            RegistrationPersonal.WriteToLocal(); // Push the changes to the Mesh
            }

        /// <summary>
        /// Complete processing of a connection request
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Complete(Complete Options) {
            SetReporting(Options.Report, Options.Verbose);

            int Index = -1;
            if (Options.Portal.ByDefault) {
                Assert.True(Machine.ConnectStartRequests.Count > 0);
                Index = 0;
                }
            else {
                throw new NYI(); // NYI: Handle multiple simultaneous connection requests.
                }
            var ConnectStartRequest = Machine.ConnectStartRequests[Index];

            MeshClient = new MeshClient(PortalAccount: ConnectStartRequest.AccountID);

             var UDF = ConnectStartRequest.SignedRequest.Data.Device.UDF;

            var Response = MeshClient.ConnectStatus(UDF);

            var Result = Response.Result;
            if (Result == null) {
                Console.WriteLine("Request still pending"); // NYI: shjould expire request etc.
                return;
                }

            var SignedProfile = Result.Data.Profile as SignedPersonalProfile;
            MeshSession.CreateAccount(ConnectStartRequest.AccountID, SignedProfile.PersonalProfile, MeshClient);


            }



        }
    }
