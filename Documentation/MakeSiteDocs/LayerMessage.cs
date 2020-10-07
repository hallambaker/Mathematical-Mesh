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
        public string BobPurchase = "Purchase equipment for $6,000?";

        public List<ExampleResult> ContactRequest;
        public List<ExampleResult> ContactPending;
        public List<ExampleResult> ContactAccept;
        public List<ExampleResult> ContactCatalog;
        public List<ExampleResult> ContactGetResponse;
        public List<ExampleResult> ContactReject;
        public List<ExampleResult> ContactBlock;

        public List<ExampleResult> ConfirmRequest;
        public List<ExampleResult> ConfirmPending;
        public List<ExampleResult> ConfirmAccept;
        public List<ExampleResult> ConfirmGetAccept;
        public List<ExampleResult> ConfirmReject;
        public List<ExampleResult> ConfirmGetReject;
        public List<ExampleResult> ConfirmMallet;



        public void DoCommandsMessage() {

            ContactRequest = testCLIBob1.Example($"message contact {AliceService1}");
            ContactPending = testCLIAlice1.Example($"message pending");
            var resultPending = (ContactPending[0].Result as ResultPending);
            var id1 = "tbs";// resultPending.Messages[0].MessageID;
            var id2 = "tbs";// resultPending.Messages[1].MessageID;

            ContactAccept = testCLIAlice1.Example($"message accept {id1}");

            ContactCatalog = testCLIAlice1.Example($"contact list");
            ContactGetResponse = testCLIBob1.Example($"message status {id1}");
            ContactReject = testCLIAlice1.Example($"message reject {id2}");
            ContactBlock = testCLIAlice1.Example($"message block {MalletService}");

            ConfirmRequest = testCLIBob1.Example($"message confirm {AliceService1} \"{BobPurchase}\"");
            ConfirmPending = testCLIAlice1.Example($"message pending");
            var confirmPending = (ConfirmPending[0].Result as ResultPending);
            confirmPending.Keep();
            id1 = "tbs";//confirmPending.Messages[0].MessageID;
            id2 = "tbs";//confirmPending.Messages[1].MessageID;

            ConfirmAccept = testCLIAlice1.Example($"message accept {id1}");
            ConfirmGetAccept = testCLIBob1.Example($"message status {id1}");
            ConfirmReject = testCLIAlice1.Example($"message reject {id2}");
            ConfirmGetReject = testCLIBob1.Example($"message status {id2}");
            //ConfirmMallet = testCLIMallet1.Example($"message confirm {AliceService1} \"{BobPurchase}\"");
            }

        #endregion


        }
    }
