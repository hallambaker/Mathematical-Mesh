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


namespace Goedel.Mesh.Shell;

public partial class Shell {


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceRequestConnect(DeviceRequestConnect options) {
        var accountAddress = options.AccountAddress.Value;
        var pin = options.PIN.Value;


        var rights = GetRights(options, false);

        var contextMeshPending = MeshHost.ConnectAsync(accountAddress, pin: pin, rights: rights).Sync();

        var result = new ResultConnect() {
            CatalogedMachine = contextMeshPending.CatalogedMachine,
            RequestConnection = contextMeshPending.RequestConnection,
            AcknowledgeConnection = contextMeshPending.AcknowledgeConnection
            };

        return result;
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceJoin(DeviceJoin options) {
        var uri = options.Uri.Value;

        var contextMeshPending = MeshHost.JoinAsync(uri).Sync();
        var result = new ResultConnect() {
            CatalogedMachine = contextMeshPending.CatalogedMachine
            };
        "".TaskFunctionality();
        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceInstall(DeviceInstall options) {
        var filename = options.Profile.Value;

        var contextMeshPending = MeshHost.Install(filename);

        var result = new ResultConnect() {
            CatalogedMachine = contextMeshPending.CatalogedMachine
            };
        "".TaskFunctionality();
        return result;
        }



    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceComplete(DeviceComplete options) {
        var accountAddress = options.AccountAddress.Value;

        // here need to pull up an account context for the pending connection.

        var contextUser = MeshHost.CompleteAsync(accountAddress).Sync();
        var result = new ResultConnect() {
            CatalogedMachine = contextUser.CatalogedMachine,
            Profile = contextUser.Profile,

            ActivationAccount = contextUser.ActivationAccount,
            RequestConnection = contextUser.RequestConnection,
            ActivationCommon = contextUser.ActivationCommon,
            RespondConnection = contextUser.RespondConnection
            };

        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DevicePending(DevicePending options) {
        var contextAccount = GetContextUser(options);
        contextAccount.SynchronizeAsync().Sync();

        var messages = contextAccount.GetOpenMessages(AcknowledgeConnection.__Tag);

        var result = new ResultPending() {
            Success = true,
            Messages = messages
            };

        return result;

        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceAccept(DeviceAccept options) {
        var rights = GetRights(options);
        return ProcessRequest(options, options.CompletionCode.Value, true, rights);
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceReject(DeviceReject options) =>
        ProcessRequest(options, options.CompletionCode.Value, false);

    ShellResult ProcessRequest(IAccountOptions options, string messageID, bool accept,
            List<string> rights = null) {
        var contextAccount = GetContextUser(options);


        // Hack: should be able to accept, reject specific requests, not just
        // the last one.

        contextAccount.TryGetMessageByMessageId(messageID, out var index).AssertTrue(MessageIdNotFound.Throw);
        index.IsOpen.AssertTrue(NYI.Throw); // make a better response for already done.


        var message = index.Message;
        var processResult = contextAccount.ProcessAsync(message, accept, roles: rights).Sync();

        // Hack: need to obtain the actual result.
        var result = new ResultProcess() {
            ProcessResult = processResult as Message
            };
        return result;


        }




    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DevicePreconfigure(DevicePreconfigure options) {
        var bits = 5 * options.Length.Value;

        using var contextAccount = GetContextUser(options);

        var devicePreconfiguration = contextAccount.Preconfigure(
            //out var filename, out var profileDevice, out var connectUri, 
            bits: bits);



        var result = new ResultPublishDevice() {
            Uri = devicePreconfiguration.ConnectUri,
            FileName = devicePreconfiguration.Filename,
            DevicePreconfigurationPrivate = devicePreconfiguration.DevicePreconfigurationPrivate,
            DevicePreconfigurationPublic = devicePreconfiguration.DevicePreconfigurationPublic
            };
        "Tidy this return up".TaskFunctionality();
        return result;
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceDelete(DeviceDelete options) {
        var contextAccount = GetContextUser(options);
        var deviceID = options.DeviceID.Value;
        contextAccount.DeleteDeviceAsync(deviceID).Wait();
        try {

            }
        catch {
            }

        var result = new Result() {

            };
        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceList(DeviceList options) {
        var contextAccount = GetContextUser(options);

        var deviceCatalog = contextAccount.GetStore(CatalogDevice.Label) as CatalogDevice;
        var result = new ResultDump() {
            Success = true,
            CatalogedEntries = new List<CatalogedEntry>()
            };
        foreach (var device in deviceCatalog) {
            result.CatalogedEntries.Add(device);
            }


        "".TaskFunctionality();
        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceAuthorize(DeviceAuthorize options) {
        var contextAccount = GetContextUser(options);
        var rights = GetRights(options);




        var result = new ResultAuthorize() {

            };
        "Modify rights of existing device".TaskFunctionality();
        return result;
        }



    }
