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


using System;

using ExampleGenerator;

using Goedel.Mesh.Test;

using Xunit;


namespace Goedel.XUnit;

public class MakeSiteDocs : CreateExamples {
    public static MakeSiteDocs Test() => new();


    public MakeSiteDocs() {

        Service = new LayerService(this);
        Account = new LayerAccount(this);
        Connect = new LayerConnect(this);

        Apps = new LayerApps(this);
        base.Contact = new LayerContact(this);
        Confirm = new LayerConfirm(this);
        Group = new LayerGroup(this);
        NYI = new LayerNYI(this);

        TestEnvironment = new TestEnvironmentCommon {
            //JpcConnection = Protocol.JpcConnection.Rud
            JpcConnection = Protocol.JpcConnection.Serialized
            };
        }



    [Fact]

    public void FullTest() {
        var index = "FullTest";

        ServiceConnect();
        CreateAliceAccount();
        EncodeDecodeFile(index);

        PasswordCatalog();
        BookmarkCatalog();
        ContactCatalog();
        NetworkCatalog();
        TaskCatalog();
        ConnectDeviceCompare(index);




        SSHApp();
        MailApp();
        CreateBobAccount();
        ContactExchange();



        Confirmation();
        GroupOperations();
        ConnectPINDynamicQR();
        ConnectStaticQR();

        TestConnectDisconnect(index);


        EscrowAndRecover();
        }

    [Fact]
    public void CiphertextVerify() {
        var index = "CiphertextVerify";


        ServiceConnect();
        CreateAliceAccount();
        EncodeDecodeFile(index);


        }



    [Fact]
    public void DeleteDevice() {
        var index = "DeleteDevice";

        ServiceConnect();
        CreateAliceAccount();
        EncodeDecodeFile(index);
        ConnectDeviceCompare(index);
        ConnectPINDynamicQR();
        TestConnectDisconnect(index);
        }

    [Fact]
    public void DecodeSecondDevice() {
        var index = "DecodeSecondDevice";

        ServiceConnect();
        CreateAliceAccount();
        EncodeDecodeFile(index);
        ConnectDeviceCompare(index);



        }


    [Fact]
    public void CreateSSH() {
        ServiceConnect();
        CreateAliceAccount();
        ConnectDevice();
        SSHApp();
        }


    [Fact]
    public void CreateMail() {
        ServiceConnect();
        CreateAliceAccount();
        ConnectDevice();
        MailApp();
        }

    [Fact]
    public void TestContact() {
        ServiceConnect();
        CreateAliceAccount();
        CreateBobAccount();
        ContactExchange();
        }

    [Fact]
    public void TestConfirmation() {
        ServiceConnect();
        CreateAliceAccount();
        Confirmation();
        }

    [Fact]
    public void GroupTests() {
        ServiceConnect();
        CreateAliceAccount();
        CreateBobAccount();
        ContactExchange();

        GroupOperations();
        }

    [Fact]
    public void Recover() {
        ServiceConnect();
        CreateAliceAccount();
        EscrowAndRecover();
        }




    }
