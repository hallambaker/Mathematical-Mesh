﻿using Goedel.Cryptography;
using Goedel.Protocol;


using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using ZXing.QrCode.Internal;

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
        catch (Exception ex) {

            return new ErrorResult(ex);
            }

        }

    ///<inheritdoc/>
    public override async Task<IResult> AccountCreate(AccountCreate data, ActionMode mode= ActionMode.Execute) {

        //// This chunk can be pushed into the generated code.
        //switch (mode) {
        //    case ActionMode.Initialize: {
        //        data.Reset (this);
        //        return NullResult.Initialized;
        //        }
        //    case ActionMode.Validate: {
        //        return data.Validate() ? NullResult.Valid :NullResult.Invalid;
        //        }
        //    }

        //var data1 = new byte[] {0,0};
        //var request = new ByteArrayContent(data1);

        //var address = "http://mmm.everything.com:15099/.well-known/mmm/";

        var contextUser = await MeshHost.ConfigureMeshAsync(data.ServiceAddress, data.LocalName);


        //var httpClient = new HttpClient();


        //await httpClient.GetAsync("https://cnn.com/");

        //await Task.Run(async () => {

        //    });
        //try {


        //    }

        //catch {
        //    }

        // here we have to tell the user the result

        // Profile fingerprint.

        // Add new profile to the accounts list and make current profile

        var result = new ReportAccount() {

            };

        return result;

        }


    }

public partial class AccountCreate {

    // This method can be pushed into the generated code.



    public void Reset(EverythingMaui context) {
        ServiceAddress = null;
        LocalName = null;
        Coupon = null;
        }
    }