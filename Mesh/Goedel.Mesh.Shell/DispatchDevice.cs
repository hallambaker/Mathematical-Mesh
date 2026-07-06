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


using Goedel.Mesh.Client;

using Microsoft.Extensions.Options;

using System.Net.WebSockets;

namespace Goedel.Mesh.Shell;

public partial class Shell {

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceInitialize(DeviceInitialize options) {
        var outputFile = options.File.Value;
        var templateFile = options.Template.Value;
        var template = (templateFile == null) ? new() : JsonObject.StreamParse<JsDevice>(templateFile, false);

        template.Version = "1.0";
        template.Kind = "Network";
        // set the date of manufacture
        template.DateManufacture ??= DateTime.Now;
        // override the device id specified in the file with the one specified here.
        template.DeviceId = options.DeviceId.Value ?? template.DeviceId;

        var description = new JsProvision(template);


        if (options.MeshOnboard.Value) {
            // Add an entry for Mesh onboarding
            var deviceProfile = ProfileDevice.Generate();
            var enveloped = deviceProfile.Envelope as Enveloped;
            var profileBytes = enveloped.ToBytes();


            var seed = deviceProfile.SecretSeed.GetJWK();

            var endpoint = $"http://+:15099/.well-known/mmm_onboard/{deviceProfile.UdfString}/";

            description.AddOnboarding("meshonboard", [endpoint],
                seed, profileBytes, "application/mmmdevice");
            }

        if (!options.WiFi.ByDefault) {
            var ssid = template.ModelId ?? options.WiFi.Value;
            description.AddPhysicalWiFi(ssid, options.WiFi.Value);
            }
        if (!options.Ethernet.ByDefault) {
            description.AddPhysicalEthernet(options.Ethernet.Value);
            }

        var contextAccount = GetContextUser(options);
        if (options.Present.Value) {
            description.DevicePresentEarl = contextAccount.PublishEarl(description.JsDevice).Sync();
            }
        if (options.NotPresent.Value) {
            description.DeviceNotPresentEarl = contextAccount.PublishEarl(description.JsDevice).Sync();
            }

        var length = description.ToFile(outputFile);

        return new ResultFileEARL() {
            Wrapper = outputFile,
            Source = templateFile,
            URI = description.DevicePresentEarl,
            NotPresent = description.DeviceNotPresentEarl
            };

        }
    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceJsDevice(DeviceJsDevice options) {
        var outputFile = options.File.Value;

        // read in the description file;
        var description = JsonObject.StreamParse<JsProvision>(outputFile);

        var contextAccount = GetContextUser(options);

        // publish the device description twice, once to 
        description.DevicePresentEarl = contextAccount.PublishEarl(description.JsDevice).Sync();
        description.DeviceNotPresentEarl = contextAccount.PublishEarl(description.JsDevice).Sync();

        var length = description.ToFile(outputFile);

        return new ResultFileEARL() {
            Source = outputFile,
            URI = description.DevicePresentEarl,
            NotPresent = description.DeviceNotPresentEarl
            };
        }
    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceOnboard(DeviceOnboard options) {
        return DeviceOnboardAsync(options.File.Value).Sync();
        }


    /// <summary>Onboard the device described by configuration <paramref name="configFile"/></summary>
    /// <param name="configFile"></param>
    /// <returns>Result of onboarding the device.</returns>
    public async Task<ShellResult> DeviceOnboardAsync(
                string configFile) {


        var onboarding = new OnboardingServer(MeshHost, configFile);
        var contextDevice = await onboarding.WaitOnboardingAsync();

        //var result = new ResultConnect() {
        //    CatalogedMachine = contextUser.CatalogedMachine,
        //    Profile = contextUser.Profile,

        //    ActivationAccount = contextUser.ActivationAccount,
        //    RequestConnection = contextUser.RequestConnection,
        //    ActivationCommon = contextUser.ActivationCommon,
        //    RespondConnection = contextUser.RespondConnection
        //    };
        return null;

        }



    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceEarl(DeviceEarl options) {
        var earl = options.Uri.Value;
        var contextAccount = GetContextUser(options);
        var rights = GetRights(options);

        // ToDo: have to assign the rights!
        var processResult = contextAccount.AcceptOnboardAsync(earl, rights).Sync();

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
    public override ShellResult DeviceService(DeviceService options) {


        throw new NYI();
        }








    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult DeviceCredential(DeviceCredential options) {
        return base.DeviceCredential(options);
        }




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
