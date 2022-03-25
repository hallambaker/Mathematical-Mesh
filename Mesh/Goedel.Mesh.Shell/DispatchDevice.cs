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


        var rights = GetRights(options);

        var contextMeshPending = MeshHost.Connect(accountAddress, pin: pin, rights: rights);

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

        var contextMeshPending = MeshHost.Join(uri);
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

        var contextUser = MeshHost.Complete(accountAddress);
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
        contextAccount.Sync();

        // get the inbound spool
        var inbound = contextAccount.GetSpoolInbound();

        var messages = new List<Message>();
        var completed = new Dictionary<string, Message>();

        foreach (var message in inbound.Select(1, true)) {
            var meshMessage = Message.FromJson(message.GetBodyReader());
            if (!completed.ContainsKey(meshMessage.MessageId)) {
                switch (meshMessage) {
                    case MessageComplete meshMessageComplete: {
                            foreach (var reference in meshMessageComplete.References) {
                                completed.Add(reference.MessageId, meshMessageComplete);
                                }
                            break;
                            }
                    case AcknowledgeConnection : {
                            messages.Add(meshMessage);
                            break;
                            }
                    }
                }
            }

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
        var message = contextAccount.GetPendingMessageByID(messageID, out var found);

        if (message == null) {
            if (found) {
                // already processed
                throw new NYI();
                }
            else {
                // Didn't receive that request
                throw new NYI();
                }
            }
        var processResult = contextAccount.Process(message, accept, roles: rights);

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

        var (devicePreconfigurationPublic, devicePreconfigurationPrivate) = contextAccount.Preconfigure(
            out var filename, out var profileDevice, out var connectUri, bits: bits);



        var result = new ResultPublishDevice() {
            Uri = connectUri,
            FileName = filename,
            DevicePreconfigurationPrivate = devicePreconfigurationPrivate,
            DevicePreconfigurationPublic = devicePreconfigurationPublic
            };
        "".TaskFunctionality();
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

        contextAccount.DeleteDevice(deviceID);

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
        var result = new Result() {

            };
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
