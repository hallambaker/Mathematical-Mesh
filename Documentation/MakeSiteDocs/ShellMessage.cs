using Goedel.Mesh.Test;
using Goedel.Mesh.Shell;
using Goedel.Utilities;
using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellMessage : ExampleSet {

        public List<ExampleResult> ContactRequest;
        public List<ExampleResult> ContactPending;
        public List<ExampleResult> ContactAccept;
        public List<ExampleResult> ContactCatalog;
        public List<ExampleResult> ContactGetResponse;
        public List<ExampleResult> ContactReject;
        public List<ExampleResult> ContactBlock;




        public const string BobPurchase = "Purchase equipment for $6,000?";

        public List<ExampleResult> ConfirmRequest;
        public List<ExampleResult> ConfirmPending;
        public List<ExampleResult> ConfirmAccept;
        public List<ExampleResult> ConfirmGetAccept;
        public List<ExampleResult> ConfirmReject;
        public List<ExampleResult> ConfirmGetReject;
        public List<ExampleResult> ConfirmMallet;




        public ShellMessage(CreateExamples createExamples) :
                base(createExamples) {


            ContactRequest = Bob1.Example($"message contact {AliceAccount}");
            ContactPending = Alice1.Example($"message pending");
            var resultPending = (ContactPending[0].Result as ResultPending);
            var id1 = "tbs";// resultPending.Messages[0].MessageID;
            var id2 = "tbs";// resultPending.Messages[1].MessageID;

            ContactAccept = Alice1.Example($"message accept {id1}");

            ContactCatalog = Alice1.Example($"contact list");
            ContactGetResponse = Bob1.Example($"message status {id1}");
            ContactReject = Alice1.Example($"message reject {id2}");
            ContactBlock = Alice1.Example($"message block {MalletAccount}");

            ConfirmRequest = Bob1.Example($"message confirm {AliceAccount} \"{ShellMessage.BobPurchase}\"");
            ConfirmPending = Alice1.Example($"message pending");
            var confirmPending = (ConfirmPending[0].Result as ResultPending);
            confirmPending.Keep();
            id1 = "tbs";//confirmPending.Messages[0].MessageID;
            id2 = "tbs";//confirmPending.Messages[1].MessageID;

            ConfirmAccept = Alice1.Example($"message accept {id1}");
            ConfirmGetAccept = Bob1.Example($"message status {id1}");
            ConfirmReject = Alice1.Example($"message reject {id2}");
            ConfirmGetReject = Bob1.Example($"message status {id2}");
            //ConfirmMallet = testCLIMallet1.Example($"message confirm {AliceService1} \"{BobPurchase}\"");
            }

        }
    }
