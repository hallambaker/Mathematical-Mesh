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


namespace Goedel.XUnit;

public partial class ShellTests {


    /// <summary>
    /// Test that attempts by Mallet to read Alice's private catalogs fail.
    /// </summary>
    /// <exception cref="NYI"></exception>
    [Fact(Skip = "Not yet implemented")]
    public void NYI_MalletCatalogReadFail() {
        throw new NYI();
        }

    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_RecoverApps() {
        "Check that SSH and Email applications work after recovery".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }

    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_ConfirmMultipleAccept() {
        "Attempt confirmation exchange, accept same message multiple times".TaskTest();
        "Attempt confirmation exchange, accept, reject message ".TaskTest();
        "Attempt confirmation exchange, reject, accept message ".TaskTest();
        "Attempt confirmation exchange, accept, delete, try reconnect".TaskTest();
        TestEnvironment.Dispose();
        EndTest();
        }
    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_LocalNameDevice() {
        "Address device by local name".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }

    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_LocalNameAccount() {
        "Address account by local name".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }
    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_ChangeDeviceAuthorization() {
        "Change authorization level after device created".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }
    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_HelpfulError() {

        //ServiceNoReply
        "Check error message is useful when can't connect to service".TaskTest();

        //DeviceNotAuthorized
        "Check error message is useful when attempting common decryption on non decryption device".TaskTest();

        //  AccountNotFound ()
        "... when referencing unknown account".TaskTest();

        // AccountNotFound ()
        "... when referencing unknown local name".TaskTest();

        // DeviceNotFound
        "... when referencing unknown device".TaskTest();

        // GroupNotFound
        "... when referencing unknown group".TaskTest();

        // ContactNotFound
        "... send message to unknown user".TaskTest();

        // DeviceNotAuthorized
        "... attempt operation not authorized for this device".TaskTest();

        // AccountNotGroup
        "... group operation on not a group".TaskTest();

        // MessageAlreadyProcessed
        "... device accept non existent message".TaskTest();

        // NoAuthorization
        "... attempt to connect a device without assigning a role or specifying /none".TaskTest();

        // AccountExists
        "... try to create an account already bound".TaskTest();
        TestEnvironment.Dispose();
        EndTest();
        }



    [Fact(Skip = "PQC archive")]
    public void NYI_PQCArchive() {
        "Encrypt to PQC secured archive".TaskTest();
        "Encrypt to hybrid secured archive".TaskTest();
        TestEnvironment.Dispose();
        EndTest();
        }


    [Fact(Skip = "PQC catalogs")]
    public void NYI_PQCCatalogs() {
        "Encrypt to PQC secured catalogs".TaskTest();
        "Encrypt to hybrid secured catalogs".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }


    [Fact(Skip = "PQC connect")]
    public void NYI_PQCConnect() {
        "Connect device with hybrid key exchange".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }






    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_KeyData() {
        "Write out key data in all known formats".TaskTest();
        "Write in key data in all known formats".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }
    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_DareArchive() {
        "Select specific file from a large archive".TaskTest();
        "Add files to archive after creation".TaskTest();
        "Add index to existing archive".TaskTest();
        "Create standalone index".TaskTest();

        "Created file has original extension".TaskTest();
        "Dearchive files".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }
    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_CatchUserError() {
        "Check creation of group with no devices authorized".TaskTest();
        "Check creation of ssh with no devices authorized".TaskTest();
        "Check creation of mail with no devices authorized".TaskTest();



        TestEnvironment.Dispose();
        EndTest();
        }


    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_SyncPartial() {
        "Parial sync, client side limited".TaskTest();
        "Parial sync, server side limited".TaskTest();
        "Incremental sync with interim reports".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }

    [Fact(Skip = "Additional checks on Shell")]
    public void NYI_SyncCorrupted() {

        "Reject attempt to double update".TaskTest();
        "Reject update from incorrect apex".TaskTest();

        TestEnvironment.Dispose();
        EndTest();
        }



    }
