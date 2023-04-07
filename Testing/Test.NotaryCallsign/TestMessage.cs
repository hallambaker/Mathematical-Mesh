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

using System.Collections.Generic;

using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;

using Xunit;

#pragma warning disable IDE0059
//#pragma warning disable CA1822

namespace Goedel.XUnit;


public partial class RegistrationTests {
   

    [Fact]
    public void CallsignBind() {
        var deviceA = GetTestCLI("MachineAlice");

        var resulta = MakeAccount(deviceA, AliceAccount);

        var serviceCallsign = GetContextRegistry();
        Console.WriteLine("Created Callsign Service");


        var resultBind = deviceA.Dispatch($"callsign bind {AliceCallsign}") as ResultPublish;
        ContextRegistry.Process();


        // Replace this with some command that waits until a completion message is received.
        var resultSync = deviceA.Dispatch($"callsign status {AliceCallsign}");

        CheckCallsign(deviceA);

        EndTest();
        }



    [Fact]
    public void CallsignRegistration() {

        var serviceCallsign = GetContextRegistry();

        var deviceA = GetTestCLI("MachineAlice");
        var resulta = MakeAccount(deviceA, AliceAccount);

        var resultRegister = deviceA.Dispatch($"callsign register {AliceCallsign}") as ResultPublish;

        var resultBind = deviceA.Dispatch($"callsign bind {AliceCallsign}") as ResultPublish;

        // Replace this with some command that waits until a completion message is received.
        var resultSync = deviceA.Dispatch($"callsign sync {AliceCallsign}");

        CheckCallsign(deviceA);

        EndTest();
        }


    [Fact]
    public void CallsignRegistrationPaid() {


        var serviceCarnet = GetCarnetService();
        var serviceCallsign = GetContextRegistry(10);



        var deviceA = GetTestCLI("MachineAlice");
        var resulta = MakeAccount(deviceA, AliceAccount);


        serviceCarnet.Dispatch($"carnet mint 50 /to={AliceAccount}");
        deviceA.Dispatch($"account sync");

        var resultRegister = deviceA.Dispatch($"callsign register {AliceCallsign} /pay=10") as ResultPublish;


        var resultBind = deviceA.Dispatch($"callsign bind {AliceCallsign}") as ResultPublish;

        CheckCallsign(deviceA);

        EndTest();
        }

    [Fact]
    public void CallsignRegistrationInsufficient() {


        var serviceCarnet = GetCarnetService();
        var serviceCallsign = GetContextRegistry(10);



        var deviceA = GetTestCLI("MachineAlice");
        var resulta = MakeAccount(deviceA, AliceAccount);


        serviceCarnet.Dispatch($"carnet mint 50 /to={AliceAccount}");
        deviceA.Dispatch($"account sync");

        var resultRegister = deviceA.Dispatch($"!callsign register {AliceCallsign} /pay=1") as ResultPublish;


        EndTest();
        }



    [Fact]
    public void CallsignTransfer() {

        var serviceCallsign = GetContextRegistry();

        var deviceC = GetTestCLI("MachineCarol");
        var resultC = MakeAccount(deviceC, CarolAccount);

        var resultRegister = deviceC.Dispatch($"callsign register {AliceCallsign}") as ResultPublish;




        var deviceA = GetTestCLI("MachineAlice");
        var resulta = MakeAccount(deviceA, AliceAccount);

        var resultTransfer = deviceC.Dispatch($"callsign transfer {AliceCallsign} AliceAccount") as ResultPublish;

        var resultBind = deviceA.Dispatch($"callsign bind {AliceCallsign}") as ResultPublish;

        CheckCallsign(deviceA);


        EndTest();
        }


    [Fact]
    public void CallsignPresencePresent() {


        var serviceCarnet = GetPresenceService();
        var serviceCallsign = GetContextRegistry(10);



        var deviceA = GetTestCLI("MachineAlice");
        var resulta = MakeAccount(deviceA, AliceAccount);


        var resultRegister = deviceA.Dispatch($"callsign register {AliceCallsign}") as ResultPublish;


        var deviceB = CheckCallsign(deviceA);

        // The next bit is going to be tricky, need to set up an async listener that continues to listen 
        // after the command returns.
        var resultChatReceive = deviceA.Dispatch($"chat listen /nointeractive");
        var resultChatSend = deviceB.Dispatch($"chat send {AliceCallsign} \"Hello\"");


        // collect up the pending chat messages and return them. The /close option closes the listener.
        var resultChatPoll = deviceA.Dispatch($"chat poll /close");


        EndTest();
        }
    [Fact]
    public void CallsignPresenceAbsent() {


        var serviceCarnet = GetPresenceService();
        var serviceCallsign = GetContextRegistry(10);



        var deviceA = GetTestCLI("MachineAlice");
        var resulta = MakeAccount(deviceA, AliceAccount);


        var resultRegister = deviceA.Dispatch($"callsign register {AliceCallsign}") as ResultPublish;


        var deviceB = CheckCallsign(deviceA);


        var resultChatSend = deviceB.Dispatch($"!chat send {AliceCallsign} \"Hello\"");


        EndTest();
        }

    }
