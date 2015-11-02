using System;
using System.Collections.Generic;
using Goedel.Debug;
using Goedel.Mesh;

namespace Goedel.MeshConnect {




    public partial class ConnectDevice {

        public override bool WaitConnect() {


            Data.GetAccount(Input_MeshGateway2, Input_AccountName3);

            return true;
            }

        }


    public partial class CheckFingerPrint {

        public override void Enter() {
            Trace.WriteLine("Enter CheckFingerPrint");

            Output_Fingerprint1 = Data.SignedCurrentProfile.UDF;
            Output_Device1 = Data.DevProfile.UDF;
            Refresh();
            }

        public override bool AcceptFingerprint() {
            Trace.WriteLine("Generating the keys");

            return Data.PostConnect();
            }

        }

    public partial class WaitToComplete {

        public override void Enter() {
            Trace.WriteLine("Enter CheckFingerPrint");

            Output_Fingerprint2 = Data.SignedCurrentProfile.UDF;
            Output_Device2 = Data.DevProfile.UDF;
            Refresh();
            }

        public override bool Check() {
            Trace.WriteLine("Generating the keys");

            return Data.CompleteConnect();
            }

        }


    }
