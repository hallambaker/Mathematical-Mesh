using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Everything;



public partial class EverythingMaui {



    HttpClient httpClient = new();




    ///<inheritdoc/>
    public override async Task<IResult> TestService(TestService data) {


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
            return ProcessException(exception, data);
            }

        }


    //public partial class AccountCreate {
    //    public override Validate 
    //    }

    ///<inheritdoc/>
    public override async Task<IResult> AccountCreate(AccountCreate data) {

        try {
            var deviceDescription = GetDeviceDescription();
            var localName = data.LocalName.IsBlank() ? data.ServiceAddress.GetAccount() : data.LocalName;

            var contextUser = await MeshHost.ConfigureMeshAsync(data.ServiceAddress, localName,
                deviceDescription: deviceDescription);

            // Make this the current account!
            var bound = GetBoundAccount(contextUser);
            SetContext(bound);


            return new ReportAccountCreate() {
                ReturnResult = ReturnResult.Home,
                LocalName = localName,
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


    public override async Task<IResult> AccountRequestConnect(AccountRequestConnect data) {
        try {
            var accountAddress = data.ConnectionString;
            var pin = data.ConnectionPin;
            var rights = ParseRights(data.Rights);

            var contextMeshPending = await MeshHost.ConnectAsync(accountAddress, pin: pin, rights: rights);

            return new ReportPending() {
                };
            }
        catch (Exception exception) {
            return ProcessException(exception, data);
            }
        }





    ///<inheritdoc/>
    public override async Task<IResult> AccountRecover(AccountRecover data) {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            return ProcessException(exception, data);
            }
        }

    ///<inheritdoc/>
    public override async Task<IResult> AccountDelete(AccountDelete data) {
        try {

            await ContextUser.DeleteAccountAsync();
            ContextUser.Dispose();

            BoundAccounts.Remove(CurrentAccount);
            SetDefaultAccount();

            /* need to clear the context user here*/
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            return ProcessException(exception, data);
            }
        }

    ///<inheritdoc/>
    public override Task<IResult> AccountGenerateRecovery(AccountGenerateRecovery data) {
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
    public override async Task<IResult> AccountSelect(BoundAccount data) {
        try {
            SetContext(data);

            return NullResult.HomeResult;
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    //public override  Task<IResult> AccountSwitch(AccountSwitch data) {


    //    }



    public List<string> ParseRights(string text) => new List<string>() { text };

    }

