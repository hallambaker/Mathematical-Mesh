using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Everything;

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

            return new ErrorResult(exception);
            }

        }

    ///<inheritdoc/>
    public override async Task<IResult> AccountCreate(AccountCreate data, ActionMode mode = ActionMode.Execute) {

        try {
            var contextUser = await MeshHost.ConfigureMeshAsync(data.ServiceAddress, data.LocalName);
            return new ReportAccountCreate() {
                LocalName = contextUser.CatalogedDevice?.LocalName,
                ServiceAddress = contextUser.ServiceAddress,
                ProfileUdf = contextUser.ProfileUser.UdfString,
                ServiceUdf = contextUser.ProfileService?.UdfString
                };
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


    public override async Task<IResult> AccountRequestConnect(AccountRequestConnect data, ActionMode mode = ActionMode.Execute) {
        try {
            var accountAddress = data.ConnectionString;
            var pin = data.ConnectionPin;
            var rights = ParseRights(data.Rights);

            var contextMeshPending = await MeshHost.ConnectAsync(accountAddress, pin: pin, rights: rights);

            return new ReportPending() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }


    //public override async Task<IResult> AccountConnectUri(AccountConnectUri data, ActionMode mode = ActionMode.Execute) {
    //    try {

    //        var uri = data.ConnectionUri;
    //        var local = data.LocalName;
    //        var contextMeshPending = await MeshHost.JoinAsync(uri, local);

    //        return new ReportPending() {
    //            };
    //        }
    //    catch (Exception exception) {
    //        if (TryProcessException(exception, data, out var result)) {
    //            return result;
    //            }
    //        return new ErrorResult(exception);
    //        }
    //    }




    ///<inheritdoc/>
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

    ///<inheritdoc/>
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

    ///<inheritdoc/>
    public override Task<IResult> AccountGenerateRecovery(AccountGenerateRecovery data, ActionMode mode = ActionMode.Execute) {
        try {
            var numberShares = data.NumberShares ?? 3;
            var quorum = data.Quorum ?? 2;

            var shares = ContextUser.Escrow(numberShares, quorum);

            if (shares == null || shares.Length <= 0) {
                return TaskResult(new SystemExeption() {
                    });
                }

            var result = new ReportShares() {
                Share1 = GetIndexOr(shares,0),
                Share2 = GetIndexOr(shares, 1),
                Share3 = GetIndexOr(shares, 2),
                Share4 = GetIndexOr(shares, 3),
                Share5 = GetIndexOr(shares, 4),
                Share6 = GetIndexOr(shares, 5),
                Share7 = GetIndexOr(shares, 6),
                Share8 = GetIndexOr(shares, 7)
                };  
            return TaskResult(result);
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return TaskResult(result);
                }
            return TaskResult(new ErrorResult(exception));
            }

        string GetIndexOr(KeyShareSymmetric[] array, int index) {
            var x = GetIndexOrNull(array, index);
            return x?.UDFKey;
            }

        }





    ///<inheritdoc/>
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










    /// <summary>
    /// Attempt to create a canned response for an exception of type <paramref name="exception"/>
    /// thrown by initial input <paramref name="parameters"/>.
    /// </summary>
    /// <param name="exception">The exception to respong to</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="result">The generated result.</param>
    /// <returns></returns>
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
        if (ExceptionDirectory.TryGetValue(exception.GetType().FullName, out var factory)) {
            result = factory();
            return true;
            }

        result = null;
        return false;
        }


    public List<string> ParseRights(string text) => new List<string>() { text };

    }

public interface IServiceAddress {

    ///<summary></summary> 
    public string ServiceAddress { get;}
    }

public partial class TestService : IServiceAddress {
    }

public partial class AccountCreate : IServiceAddress {
    }