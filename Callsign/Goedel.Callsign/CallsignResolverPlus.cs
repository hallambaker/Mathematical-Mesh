using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Callsign;



public class ResolveClient : IResolver {

    ResolverServiceClient Client;
    public ResolveClient(
                ResolverServiceClient client,
                JpcSession session) {

        Client = client;
        }


    public bool TryResolveCallsign(string callsign, out CallsignBinding callsignBinding) {


        var queryResponse = Client.Query(callsign);
        if (!queryResponse.Success()) {
            callsignBinding = null;
            return false;
            }

        var result = queryResponse.Result.Decode();
        callsignBinding = result.Entry.Decode();

        return true;
        }
    }


public partial class ResolverResponse {

    public ResolverResponse(int status = 202) {
        Status = status;

        }


    }


public partial class QueryResponse {

    public QueryResponse() {
        }

    public QueryResponse(Enveloped<Registration> result) {
        Result = result;
        Status = result == null ? 404 : 201;
        if (result != null) {
            Status = 200;
            }
        else {
            Status = 400 ;
            StatusDescriptionCode = MeshConstants.MeshServerStatusNotFoundTag;
            StatusExtended = (int)MeshServerStatus.NotFound;
            }
        }


    }

public partial class ResolverServiceClient {




    public QueryResponse Query(string callSign, string registrationId = null, string logId = null) {
        callSign = CallsignMapping.Default.CanonicalizeStripped(callSign);
        var queryRequest = new QueryRequest() {
            CallSign = callSign,
            RegistrationId = registrationId,
            LogId = logId
            };

        return Query(queryRequest);
        }


    }