//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  
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
