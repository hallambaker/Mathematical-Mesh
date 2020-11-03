using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Utilities;

using System.Collections.Generic;

#pragma warning disable IDE0059

namespace ExampleGenerator {


    public partial class CreateExamples {

        public void LayerMessage() {

            DoCommandsMessage();
            //DoCommandsGroup();
            }


        #region // Tests


        public void DoCommandsMessage() {

            ShellContact.ContactRequest = testCLIBob1.Example($"message contact {AliceService1}");
            ShellContact.ContactPending = testCLIAlice1.Example($"message pending");
            var resultPending = (ShellContact.ContactPending[0].Result as ResultPending);
            var id1 = "tbs";// resultPending.Messages[0].MessageID;
            var id2 = "tbs";// resultPending.Messages[1].MessageID;

            ShellContact.ContactAccept = testCLIAlice1.Example($"message accept {id1}");

            ShellContact.ContactCatalog = testCLIAlice1.Example($"contact list");
            ShellContact.ContactGetResponse = testCLIBob1.Example($"message status {id1}");
            ShellContact.ContactReject = testCLIAlice1.Example($"message reject {id2}");
            ShellContact.ContactBlock = testCLIAlice1.Example($"message block {MalletService}");

            ShellConfirm.ConfirmRequest = testCLIBob1.Example($"message confirm {AliceService1} \"{ShellConfirm.BobPurchase}\"");
            ShellConfirm.ConfirmPending = testCLIAlice1.Example($"message pending");
            var confirmPending = (ShellConfirm.ConfirmPending[0].Result as ResultPending);
            confirmPending.Keep();
            id1 = "tbs";//confirmPending.Messages[0].MessageID;
            id2 = "tbs";//confirmPending.Messages[1].MessageID;

            ShellConfirm.ConfirmAccept = testCLIAlice1.Example($"message accept {id1}");
            ShellConfirm.ConfirmGetAccept = testCLIBob1.Example($"message status {id1}");
            ShellConfirm.ConfirmReject = testCLIAlice1.Example($"message reject {id2}");
            ShellConfirm.ConfirmGetReject = testCLIBob1.Example($"message status {id2}");
            //ConfirmMallet = testCLIMallet1.Example($"message confirm {AliceService1} \"{BobPurchase}\"");
            }

        #endregion


        }
    }
