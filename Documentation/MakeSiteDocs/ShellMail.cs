#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion

using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator;

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
        //MailAdd = testCLIAlice1.Example($"mail add {AliceService1}");
        //MailAddExplicit = testCLIAlice1.Example($"mail add {AliceService2} /inbound={AliceAccount2Inbound} /outbound={AliceAccount2Outbound}");
        //MailUpdate = testCLIAlice1.Example($"mail update {AliceService2}");

        //MailUpdateOpenPGP = testCLIAlice1.Example($"mail update  {AliceService1} /openpgp");
        //MailOpenPGPPrivate = testCLIAlice1.Example($"mail openpgp private {AliceService1} {MailPGPPrivateKey}");
        //MailOpenPGPPublic = testCLIAlice1.Example($"mail openpgp public {AliceService1} {MailPGPPublicKey}");

        //MailUpdateSMIME = testCLIAlice1.Example($"mail {AliceService1} /smime");
        //MailSMIMECA = testCLIAlice1.Example($"mail {AliceService1} /ca={SMIMECA}");
        //MailSMIMEPrivate = testCLIAlice1.Example($"mail smime private {AliceService1} {MailSMIMEPrivateKey}");
        //MailSMIMEPublic = testCLIAlice1.Example($"mail smime public {AliceService1} {MailSMIMEPublicKey}");

        }
    }
