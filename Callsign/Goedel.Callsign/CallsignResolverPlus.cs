using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Callsign;


/// <summary>
/// Client resolver class
/// </summary>
public class ResolveClient : IResolver {

    ResolverServiceClient Client;
    
    /// <summary>
    /// Constructor, returning an instance using the client <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to use.</param>
    public ResolveClient(
                ResolverServiceClient client) {

        Client = client;
        }


    ///<inheritdoc/>
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

    /// <summary>
    /// Constructor returning an instance of a resolver response.
    /// </summary>
    /// <param name="status">The status value to specify.</param>
    public ResolverResponse(int status = 202) {
        Status = status;

        }


    }


public partial class QueryResponse {

    /// <summary>
    /// Default constructor.
    /// </summary>
    public QueryResponse() {
        }

    /// <summary>
    /// Constructor returning an instance for the registration value <paramref name="result"/>.
    /// </summary>
    /// <param name="result">The enveloped registration value.</param>
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


    /// <summary>
    /// Perform a query attempting to resolve the callsign <paramref name="callSign"/>,
    /// </summary>
    /// <param name="callSign">The callsign to resolve.</param>
    /// <param name="registrationId">Optional registration identifier (used to query prior registrations)</param>
    /// <param name="logId">Optional log entry identifier (used to query prior registrations)</param>
    /// <returns>The query response</returns>

    public QueryResponse Query(string callSign, string? registrationId = null, string? logId = null) {
        callSign = CallsignMapping.Default.CanonicalizeStripped(callSign);
        var queryRequest = new QueryRequest() {
            CallSign = callSign,
            RegistrationId = registrationId,
            LogId = logId
            };

        return Query(queryRequest);
        }


    }