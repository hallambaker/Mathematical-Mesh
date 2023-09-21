using Goedel.Cryptography;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Protocol;


using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using ZXing.QrCode.Internal;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Everything;

public partial class TestService {
    //ResourceManager ResourceManager;

    //public override IResult Validate() {
    //    GuiResultInvalid result = null;

    //    // error on ServiceAddress
    //    if (ServiceAddress == null
    //        ) {
    //        result ??= new GuiResultInvalid(this);
    //        result.SetError(1, "Service address cannot be blank", "ServiceAddressNotEmpty");
    //        }

    //    // error on ServiceAddress
    //    if (!ServiceAddress.TryParseServiceAddress()
    //        ) {
    //        result ??= new GuiResultInvalid(this);
    //        result.SetError(1, "Not a valid service address", "ServiceAddressNotValid");
    //        }

    //    return (result as IResult) ?? NullResult.Valid;
    //    }

    }

public partial class ChooseContact {

    public Task<IResult> Add() => throw new NYI();
    public Task<IResult> Delete() => throw new NYI();

    public void Select () => throw new NYI();



    }

public partial class EverythingMaui {



    HttpClient httpClient = new();




    ///<inheritdoc/>
    public override async Task<IResult> TestService(TestService data, ActionMode mode = ActionMode.Execute) {


        //var meshClient = GetMeshClient(options, options.Account.Value);

        //var result1 = await httpClient.GetAsync("https://cnn.com/");


        //return Task.FromResult(result as IResult);
        try {
            var profileDevice = ProfileDevice.Generate();
            var credential = new MeshCredentialPrivate(profileDevice, null, null, profileDevice.KeyAuthentication as KeyPairAdvanced);
            var meshClient = MeshMachine.GetMeshClient(credential, data.ServiceAddress);


            var helloRequest = new HelloRequest();



            var response = await meshClient.HelloAsync(helloRequest);
            response.Success().AssertTrue(NYI.Throw);
            response.EnvelopedProfileService.AssertNotNull(NYI.Throw);

            var profileService = response.EnvelopedProfileService.Decode();

            //task.Wait();
            var result = new ReportHost() {
                ServiceUdf = profileService.UdfString
                };

            return result;

            }

        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }

            if (ExceptionDirectory.TryGetValue(exception.GetType().FullName, out var factory)) {
                return factory();
                }

            return new ErrorResult(exception);
            }

        }

    ///<inheritdoc/>
    public override async Task<IResult> AccountCreate(AccountCreate data, ActionMode mode = ActionMode.Execute) {

        try {
            var contextUser = await MeshHost.ConfigureMeshAsync(data.ServiceAddress, data.LocalName);
            return new ReportAccount() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }

        }

    public override async Task<IResult> AccountConnect(AccountConnect data, ActionMode mode = ActionMode.Execute) {
        try {

            //var contextAccount = GetContextUser(options);
            //var rights = GetRights(options);

            //var catalogedDevice = contextAccount.ConnectStaticUriAsync(options.Uri.Value, rights).Sync();


            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    public override async Task<IResult> AccountRecover(AccountRecover data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    public override async Task<IResult> AccountDelete(AccountDelete data, ActionMode mode = ActionMode.Execute) {
        try {

            await ContextUser.DeleteAccountAsync();
            ContextUser.Dispose();
            ContextUser = null;

            /* need to clear the context user here*/
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    public override async Task<IResult> AccountGenerateRecovery(AccountGenerateRecovery data, ActionMode mode = ActionMode.Execute) {
        try {
            //var contextMesh = GetContextUser(options);
            //var shares = contextMesh.Escrow(3, 2);

            //var textShares = new List<string>();
            //foreach (var share in shares) {
            //    textShares.Add(share.UDFKey);
            //    }

            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    public override async Task<IResult> AccountGetPin(AccountGetPin data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);

            //var messageConnectionPIN = await ContextUser.GetPinAsync(MeshConstants.MessagePINActionDevice,
            //validity: expire.Ticks, roles: rights, bits: bits).Sync();

            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }


    public override async Task<IResult> AccountSwitch(AccountSwitch data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    public override async Task<IResult> RequestContact(RequestContact data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);

            //var contextAccount = GetContextUser(options);
            //var recipient = options.Recipient.Value;

            //var message = contextAccount.ContactRequestAsync(recipient).Sync();

            //var result = new ResultSent() {
            //    Success = true,
            //    Message = message
            //    };

            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }


    public override async Task<IResult> RequestConfirmation(RequestConfirmation data, ActionMode mode = ActionMode.Execute) {
        try {

            //var contextAccount = GetContextUser(options);
            //var recipient = options.Recipient.Value;
            //var text = options.Text.Value;


            //var message = contextAccount.ConfirmationRequestAsync(recipient, text).Sync();

            //var result = new ResultSent() {
            //    Success = true,
            //    Message = message
            //    };


            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }




    public override async Task<IResult> CreateMail(CreateMail data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> CreateChat(CreateChat data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> StartVoice(StartVoice data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> StartVideo(StartVideo data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> SendDocument(SendDocument data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> ShareDocument(ShareDocument data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    public override async Task<IResult> AddMailAccount(AddMailAccount data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> AddSshAccount(AddSshAccount data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> AddGitAccount(AddGitAccount data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }
    public override async Task<IResult> AddCodeSigningKey(AddCodeSigningKey data, ActionMode mode = ActionMode.Execute) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    public bool TryProcessException(Exception exception, IParameter parameters, out IResult result) {

        switch (exception) {
            case HttpRequestException httpRequestException: {
                if (exception.InnerException is System.Net.Sockets.SocketException) {
                    var data = parameters as IServiceAddress;
                    result = new ServiceNotFound() {
                        ServiceName = data.ServiceAddress
                        };
                    return true;
                    }
                else {
                    result = new HttpRequestFail();
                    return true;
                    }

                }
            }

        result = null;
        return false;
        }

    }

public interface IServiceAddress {

    ///<summary></summary> 
    public string ServiceAddress { get;}
    }

public partial class TestService : IServiceAddress {
    }

public partial class AccountCreate : IServiceAddress {
    }