using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellMail : ExampleSet {

        public const string AliceAccount2Outbound = "smtp:submit.example.net:587";
        public const string AliceAccount2Inbound = "imap4:imap.example.net:993";


        public List<ExampleResult> MailAdd;
        public List<ExampleResult> MailAddExplicit;
        public List<ExampleResult> MailUpdate;

        public List<ExampleResult> MailUpdateOpenPGP;
        public List<ExampleResult> MailOpenPGPPrivate;
        public List<ExampleResult> MailOpenPGPPublic;

        public List<ExampleResult> MailUpdateSMIME;
        public List<ExampleResult> MailSMIMECA;
        public List<ExampleResult> MailSMIMEPrivate;
        public List<ExampleResult> MailSMIMEPublic;

        public const string SMIMECA = "ca.example.net";
        public const string MailPGPPublicKey = "pgp.public";
        public const string MailPGPPrivateKey = "pgp.private";
        public const string MailSMIMEPublicKey = "smime.public";
        public const string MailSMIMEPrivateKey = "smime.private";

        public List<ExampleResult> MailAuth;
        public List<ExampleResult> MailSMIMEPrivate2;

        public ShellMail(CreateExamples createExamples) :
                base(createExamples) {
            MailAdd = testCLIAlice1.Example($"mail add {AliceService1}");
            MailAddExplicit = testCLIAlice1.Example($"mail add {AliceService2} /inbound={AliceAccount2Inbound} /outbound={AliceAccount2Outbound}");
            MailUpdate = testCLIAlice1.Example($"mail update {AliceService2}");

            MailUpdateOpenPGP = testCLIAlice1.Example($"mail update  {AliceService1} /openpgp");
            MailOpenPGPPrivate = testCLIAlice1.Example($"mail openpgp private {AliceService1} {MailPGPPrivateKey}");
            MailOpenPGPPublic = testCLIAlice1.Example($"mail openpgp public {AliceService1} {MailPGPPublicKey}");

            MailUpdateSMIME = testCLIAlice1.Example($"mail {AliceService1} /smime");
            MailSMIMECA = testCLIAlice1.Example($"mail {AliceService1} /ca={SMIMECA}");
            MailSMIMEPrivate = testCLIAlice1.Example($"mail smime private {AliceService1} {MailSMIMEPrivateKey}");
            MailSMIMEPublic = testCLIAlice1.Example($"mail smime public {AliceService1} {MailSMIMEPublicKey}");

            }
        }
    }
