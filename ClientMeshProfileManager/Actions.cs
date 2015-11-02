using System;
using System.Collections.Generic;
using Goedel.Debug;
using Goedel.Mesh;

namespace Goedel.MeshProfileManager {


    public partial class AddAccountStart {
        public override void Enter() {
            Trace.WriteLine("Enter Add Account");
            }

        public override bool Exit() {
            Trace.WriteLine("Exit Add Account");
            return true;
            }
        }

    public partial class SelectNormal {
        public override void Enter() {
            // set the default provider (prismproof.org)

            Input_MeshGateway = "prismproof.org";

            }

        public override bool Next() {
            // validate the provider, flag if failed.

            // In this may in future lead to new requirements, e.g. 
            // have to supply a PIN or whatever.

            var Accepted = Data.TryNewPortalAccount(Input_MeshGateway, Input_AccountName);

            //Data.Navigate(Data.Data_SelectNormal);

            return Accepted;
            }
        }

    public partial class AskPassword {
        public override void Enter() {
            }

        public override bool Exit() {
            // validate the provider, flag if failed.

            // In future this may  lead to new requirements, e.g. 
            // have to supply a PIN or whatever.

            return true;
            }

        public override bool ConfigurePassword() {
            Trace.WriteLine("Will Configure Password Manager");
            Data.ConfigurePassword = true;
            return true;
            }

        }

    public partial class AskNetwork {

        public override bool ConfigureNetwork() {
            Data.ConfigureNetwork = true;
            Trace.WriteLine("Will Configure Network");
            return true;
            }

        }

    public partial class AskEmail {

        public override bool ConfigureEmail() {

            // when we get to detailed config, we should look at the installed email 
            // application and pull out the account details.
            Data.ConfigureEmail = true;

            Data.AllMailAccountInfos = MailClientCatalog.FindLocal();
            Data.AccountIndex = 0;

            Trace.WriteLine("Will Configure Email");

            if (Data.AllMailAccountInfos.Count == 0) {
                Data.Navigate(Data.Data_NoEmailFound);
                return false;
                }

            return true;
            }

        }


    public partial class AskEmailAccount {

        public override void Enter() {
            var Account = Data.AllMailAccountInfos[Data.AccountIndex];



            Output_AccountName = Account.AccountName;
            Output_AccountAddress = Account.EmailAddress;
            Output_AccountPersonal = Account.DisplayName;
            }

        public override bool YesEmail() {
            Data.MailAccountInfos.Add(Data.AllMailAccountInfos[
                Data.AccountIndex]);
            return Next();
            }

        public override bool NoEmail() {
            return Next();
            }

        bool Next() {
            Data.AccountIndex++;
            if (Data.AccountIndex >= Data.AllMailAccountInfos.Count) {
                Data.Navigate(Data.Data_AskRecovery);
                return false;
                }
            return true;
            }
        }

    public partial class AskRecovery {

        public override bool CreateRecovery() {
            // At some point allow user to ask for a different share than 2 out of three.
            Data.ConfigureRecovery = true;
            Trace.WriteLine("Will Configure Recovery with ? of ? shares.");

            Data.share1 = "Computed 1";
            Data.share2 = "Computed 2";
            Data.share3 = "Computed 3";

            return true;
            }

        }


    public partial class GenerateKeys {
        public override void Enter() {
            Trace.WriteLine("Enter GenerateKeys");
            }

        public override bool Exit() {
            Trace.WriteLine("Exit GenerateKeys");
            return true;
            }

        public override void GenerateKeysTask1() {
            Trace.WriteLine("Generating the keys");

            Data.GenerateProfile();
            }
        }

    public partial class GenerateRecoveryKeys {
        public override void Enter() {
            Trace.WriteLine("Enter GenerateRecoveryKeys");

            }

        public override bool Exit() {
            Trace.WriteLine("Exit GenerateRecoveryKeys");
            return true;
            }

        public override void GenerateKeysTask2() {
            Trace.WriteLine("Generating the keys");

            Data.GenerateProfile();
            Dialog.UpdateProgress();
            }
        }




    public partial class ConnectDevice {

        public override bool WaitConnect() {


            Data.GetAccount(Input_MeshGateway2, Input_AccountName3);

            return true;
            }

        }


    public partial class ConnectPending {

        public override void Enter() {
            Trace.WriteLine("Enter ConnectPending");

            Output_ProfileUDF = Data.UDF;
            Refresh();
            }

        public override void WaitConnectTask() {
            Trace.WriteLine("Generating the keys");

            Data.PostConnect();
            Dialog.UpdateProgress();
            }

        }

    public partial class Finish {

        public override void Enter() {
            Trace.WriteLine("Enter Finish");

            Output_Fingerprint = Data.UDF;
            Refresh();
            }

        }


    public partial class FinishRecovery {

        public override void Enter() {
            Trace.WriteLine("Enter Finish");

            Output_RecoveryShare1f = Data.share1;
            Output_RecoveryShare2f = Data.share2;
            Output_RecoveryShare3f = Data.share3;
            Output_Fingerprintf = Data.UDF;
            Refresh();
            }

        }

    public partial class CheckFingerPrint {

        public override void Enter() {
            Trace.WriteLine("Enter Check UDF");

            Output_Fingerprint2 = Data.UDF;
            Refresh();
            }

        }

    public partial class RecoverKey {

        public override bool Recover() {
            Trace.WriteLine("Share 1 {0}", Input_RecoveryShare1);
            Trace.WriteLine("Share 2 {0}", Input_RecoveryShare2);

            string[] Shares = { Input_RecoveryShare1, Input_RecoveryShare2 };


            Refresh();

            Data.RecoverProfile(Shares);

            return true;
            }

        }


    public partial class SetupComplete {
        public override void Enter() {
            // set the default provider (prismproof.org)
            Output_ProfileUDF = Data.MeshClient.UDF;
            Output_AccountID = Data.AccountID;
            }

        public override bool Scan() {
            return Data.CheckPending();
            }
        }


    }
