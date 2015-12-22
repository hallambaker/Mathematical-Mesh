//Sample license text.
using System;
using System.Collections.Generic;
using Goedel.Debug;
using Goedel.Mesh;

namespace Goedel.MeshSampleClient {


    public partial class SelectApplication {

        public override void Enter() {
            //Output_ProfileID = "Password Config";
            return;
            }
        }

    public partial class SelectPassword {

        public override void Enter() {




            Output_PasswordConfiguration = Data.GetPasswords();
            return;
            }
        }


    public partial class PasswordDialog {

        public override bool AcceptPassword() {
            Trace.WriteLine("AcceptPassword");
            Data.AddPassword(Input_DomainName, Input_Username,
                    Input_Password);
            return true;
            }
        }


    public partial class SelectNetwork {

        public override void Enter() {
            Output_NetworkConfiguration = Data.GetNetwork();
            return;
            }
        }


    public partial class SelectEmail {

        public override void Enter () {
            Output_EmailConfiguration = Data.GetMail();
            return;
            }
        }




    public partial class NetworkDialog {


        public override bool AcceptNetwork() {
            Trace.WriteLine("AcceptNetwork");
            Data.SetNetwork(Input_DNS1, Input_DNS2, Input_DNSProtocol);
            return true;
            }
        }

    public partial class EmailDialog {


        public override bool AcceptEmail() {
            Trace.WriteLine("AcceptEmail");
            Data.SetMail(Input_MailServer, Input_MailAccount);
            return true;
            }
        }

    }
