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

using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;

namespace ExampleGenerator;




public class ExampleSet : CreateExamples {
    public CreateExamples CreateExamples;

    public override TestCLI Alice1 => CreateExamples.Alice1;
    public override TestCLI Alice2 => CreateExamples.Alice2;
    public override TestCLI Alice3 => CreateExamples.Alice3;
    public override TestCLI Alice4 => CreateExamples.Alice4;
    public override TestCLI Bob1 => CreateExamples.Bob1;
    public override TestCLI Mallet1 => CreateExamples.Mallet1;
    public override TestCLI Console1 => CreateExamples.Console1;
    public override TestCLI Maker1 => CreateExamples.Maker1;


    public override string Secret1 {
        get => CreateExamples.Secret1;
        set => CreateExamples.Secret1 = value;
        }

    public ExampleSet(CreateExamples createExamples) => CreateExamples = createExamples;
    }

public partial class CreateExamples {


    public ShellMessage ShellMessage;
    public ShellContact ShellContact;

    public ShellGroup ShellGroup;
    public ShellAccount ShellAccount;

    public ShellCalendar ShellCalendar;
    public ShellNetwork ShellNetwork;
    public ShellMail ShellMail;
    public ShellSSH ShellSSH;
    public ShellPassword ShellPassword;
    public ShellBookmark ShellBookmark;

    public ShellKey ShellKey;
    public ShellHash ShellHash;
    public ShellDare ShellDare;
    public ShellSequence ShellSequence;


    public void LayerService() => DoCommandsService();//DoCommandsServicedAccount();


    #region // Tests



    public void DoCommandsService() {

        // check connection to service
        ProfileHello = Alice1.Example($"account hello {AliceAccount}");
        ResultHello = ProfileHello[0].Result as ResultHello;

        // Shortcut to existing profile
        AliceProfiles = ProfileCreateAlice[0].Result as ResultCreatePersonal;


        // Create a Bob Account
        ProfileCreateBob = Bob1.Example($"account create {BobAccount} ");

        // Basic get information tests.
        ProfileList = Alice1.Example($"mesh list");
        ProfileDump = Alice1.Example($"mesh get");


        // Import and export test
        ProfileExport = Alice1.Example($"mesh export {TestExport}");
        ProfileImport = Alice4.Example($"mesh import {TestExport}"); // do on another device (to be created




        // ToDo: need to add a flow for an administration QR code push and implement the QR code document.

        ShellAccount.ConnectRequest = Alice2.Example($"device request {AliceAccount}");
        ShellAccount.ConnectRequestMallet = Mallet1.Example($"device request {AliceAccount}");

        ShellAccount.ConnectPending = Alice1.ExampleNoCatch($"device pending");


        var resultPending = (ShellAccount.ConnectPending[0].Result as ResultPending);
        var id1 = resultPending.Messages[1].MessageId;


        ShellAccount.ConnectAccept = Alice1.Example($"device accept {id1}");



        var id2 = resultPending.Messages[0].MessageId;

        ShellAccount.ConnectSync = Alice2.Example($"device complete");
        Alice2.Example($"account sync");

        ShellAccount.ConnectReject = Alice1.Example($"device reject {id2}");

        ShellAccount.ConnectList = Alice1.Example($"device list");
        ShellAccount.ConnectDelete = Alice1.Example($"device delete {id1}",
            $"device list");

        // Connect Device 3 using a PIN
        ShellAccount.ConnectGetPin = Alice1.Example($"account pin");
        var resultPin = (ShellAccount.ConnectGetPin[0].Result as ResultPIN);
        var pin = resultPin.MessagePIN.SaltedPin;
        ShellAccount.ConnectPin = Alice3.Example($"device request {AliceAccount} /pin={pin}");

        ShellAccount.ConnectPending3 = Alice1.Example($"device pending");
        ShellAccount.ConnectSyncPIN = Alice3.Example($"account sync");


        ShellAccount.ConnectEarlPrep = Alice4.Example("key earl");
        var resultEarl = (ShellAccount.ConnectEarlPrep[0].Result as ResultKey);

        ShellAccount.DeviceCreateUDF = $"udf://{EARLService}/{resultEarl.Key}";

        ShellAccount.DeviceEarl1 = Alice4.Example($"device pre {PollService} /key={ShellAccount.DeviceCreateUDF}");
        ShellAccount.DeviceEarl2 = Alice4.Example($"account sync");
        ShellAccount.DeviceEarl3 = Alice1.Example($"device earl {ShellAccount.DeviceCreateUDF}");
        ShellAccount.DeviceEarl4 = Alice4.Example($"account sync");

        }





    public void DoCommandsServicedAccount() {

        ShellContact.ContactAuth = Alice1.Example($"device auth {AliceDevice2} /contact");
        ShellBookmark.BookmarkAuth = Alice1.Example($"device auth {AliceDevice2} /bookmark");
        ShellPassword.PasswordAuth = Alice1.Example($"device auth {AliceDevice2} /password");
        ShellCalendar.CalendarAuth = Alice1.Example($"device auth {AliceDevice2} /calendar ");
        ShellNetwork.NetworkAuth = Alice1.Example($"device auth {AliceDevice2} /network");


        // These are all failing because the container is being initialized before it is 
        // synchronized on the device.


        // Failing: Because the key collection is not being populated with the activated keys as it should be.

        ShellContact.ContactList2 = Alice2.Example($"contact list");
        ShellBookmark.BookmarkList2 = Alice2.Example($"bookmark list");
        ShellPassword.PasswordList2 = Alice2.Example($"password list");
        ShellCalendar.CalendarList2 = Alice2.Example($"calendar list");
        ShellNetwork.NetworkList2 = Alice2.Example($"network list");

        ShellMail.MailAuth = Alice1.Example($"device auth {AliceDevice2} /mail ");
        ShellMail.MailSMIMEPrivate2 = Alice2.Example($"mail smime private {AliceAccount} {ShellMail.MailSMIMEPrivateKey}");
        }






    #endregion

    }
