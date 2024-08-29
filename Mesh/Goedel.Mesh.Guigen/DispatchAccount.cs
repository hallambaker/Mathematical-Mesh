﻿namespace Goedel.Everything;



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

            PersonName? personName = null;
            // lets pars person name here.
            if (!data.ContactName.IsBlank()) {
                personName = new PersonName(data.ContactName);
                }

            var contextUser = await MeshHost.ConfigureMeshAsync(
                        data.ServiceAddress, localName,
                        deviceDescription: deviceDescription,
                        personName: personName);

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


            // here need to add a BoundAccountPending to BoundAccounts
            var bound = new BoundAccountPending(contextMeshPending.CatalogedPending);
            BoundAccounts.Add(bound);


            return new ReportPending() {
                };
            }
        catch (ConnectionAccountUnknownException exception) {
            return new ErrorResult(exception);
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
                Share1 = GetIndexOr(shares, 0),
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
    public override Task<IResult> AccountDefault(BoundAccountUser data) {
        try {
            if (data == DefaultAccount) {
                return TaskResult(NullResult.HomeResult);
                }
            var bound = data.Bound as CatalogedStandard;
            if (bound is not null) {
                bound.Default = true;
                MeshHost.Update(bound);
                DefaultAccount.IsDefault = false;
                DefaultAccount = data;
                DefaultAccount.IsDefault = true;
                }
            // Here we have to change stuff
            return TaskResult(NullResult.HomeResult);
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return TaskResult(result!);
                }
            return TaskResult(new ErrorResult(exception));
            }
        }



    ///<inheritdoc/>
    public override Task<IResult> AccountSelect(BoundAccountUser data) {
        try {
            SetContext(data);
            return TaskResult(NullResult.HomeResult);
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return TaskResult(result);
                }
            return TaskResult(new ErrorResult(exception));
            }
        }

    ///<inheritdoc/>
    public override async Task<IResult> AccountComplete(BoundAccountPending boundAccountPending) {
        try {
            var accountAddress = boundAccountPending.Service;
            var contextUser = await MeshHost.CompleteAsync(accountAddress);


            // if successfull

            // remove pending item from list
            // create BoundAccountUser
            // switch to BoundAccountUser
            // SetContext(data);
            var catalogued = contextUser.CatalogedMachine;
            catalogued.AssertNotNull(NYI.Throw);
            var bound = GetBoundAccount(contextUser);
            SetContext(bound);

            BoundAccounts.Remove(boundAccountPending);

            return NullResult.Completed;
            }
        catch (ConnectionAccountUnknownException exception) {
            return new ErrorResult(exception);
            }
        catch (ConnectionRefusedException exception) {
            return new ConnectionRefused();
            }
        catch (ConnectionPendingException exception) {
            return new ConnectionPending();
            }
        catch (ConnectionExpiredException exception) {
            return new ErrorResult(exception);
            }
        catch (RefusedPinInvalidException exception) {
            return new ErrorResult(exception);
            }
        catch (Exception exception) {
            if (TryProcessException(exception, boundAccountPending, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }


    public List<string> ParseRights(string text) => new List<string>() { text };

    }

/// <summary>
/// Callback parameters for action AccountRequestConnect 
/// </summary>
public partial class _AccountRequestConnect {

    bool IsConnected(Gui gui, string? connectionString) {
        if (connectionString is null) {
            return false;
            }

        var everythingMaui = gui as EverythingMaui;
        foreach (var account in everythingMaui.BoundAccounts) {
            switch (account) {
                case BoundAccountPending pending: {
                    if (connectionString.ToLower() == pending.Service.ToLower()) {
                        return true;
                        }
                    break;
                    }
                case BoundAccountUser user: {
                    if (connectionString.ToLower() == user.Service.ToLower()) {
                        return true;
                        }
                    break;
                    }

                }
            }

        return false;
        }

    }