//Sample license text.
using System;
using System.Collections.Generic;
using Goedel.Debug;
using Goedel.Mesh;

namespace Goedel.MeshConnect {




    public partial class ConnectDevice {
        public override void Enter() {
            // set the default provider (prismproof.org)

            Input_MeshGateway2 = "prismproof.org";

            }

        /// <summary>
        /// Connect to the specified portal and account.
        /// </summary>
        /// <returns></returns>
        public override bool WaitConnect() {
            Data.GetAccount(Input_MeshGateway2, Input_AccountName3);
            return true;
            }

        }


    public partial class CheckFingerPrint {

        /// <summary>
        /// Setup page.
        /// </summary>
        public override void Enter() {
            Trace.WriteLine("Enter CheckFingerPrint");

            Output_Fingerprint1 = Data.SignedPersonalProfile.UDF;
            //Output_Device1 = Data.DevProfile.UDF;
            Refresh();
            }

        /// <summary>
        /// User has accepted the fingerprint, generate the keys.
        /// </summary>
        /// <returns></returns>
        public override bool AcceptFingerprint() {
            Trace.WriteLine("Generating the keys");

            return Data.PostConnect();
            }

        }

    public partial class WaitToComplete {

        /// <summary>
        /// Setup page, present the fingerprint of this device and the 
        /// profile we are attempting to connect to.
        /// </summary>
        public override void Enter() {
            Trace.WriteLine("Enter CheckFingerPrint");

            //Output_Fingerprint2 = Data.SignedPersonalProfile.UDF;
            Output_Device2 = Data.DevProfile.UDF;
            Refresh();
            }

        /// <summary>
        /// Check to see if the connection request was approved.
        /// </summary>
        /// <returns></returns>
        public override bool Check() {
            Trace.WriteLine("Generating the keys");

            return Data.CompleteConnect();
            }

        }


    }
