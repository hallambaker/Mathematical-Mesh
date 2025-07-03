


using System.Net;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Mesh.Server;


public abstract class EarlDispatch {

    public abstract Endpoint GetEndpoint();



    public abstract string Add(
                string locator,
                byte[] data);

    public abstract bool Delete(string locator);

    public abstract bool TryGetValue(
                string locator,
                out byte[] data);

    }


/// <summary>
/// Dispatch nubin for EARL resolution service 
/// </summary>
public class EarlDispatchCached: EarlDispatch {
    string Domain { get; }
    string? Instance { get; }
    Dictionary<string, byte[]> DataDictionary { get; } = [];

    string PathPrefix { get; }

    public EarlDispatchCached(string domain, string? instance = null) {
        Domain = domain;
        Instance = instance;
        PathPrefix = EarlClient.GetPrefix(Instance);
        }

    public override Endpoint GetEndpoint() {
        return new HttpEndpoint(Dispatch, "_earl._tcp", Instance);
        }

    /// <summary>
    /// The HTTP dispatch routine, process the request <paramref name="request"/>
    /// to construct the response <paramref name="response"/>.
    /// </summary>
    /// <param name="request">The HTTP request.</param>
    /// <param name="response">The HTTP response.</param>
    /// <returns>The HTTP status code returned.</returns>
    public HttpStatusCode Dispatch(HttpListenerRequest request,
                HttpListenerResponse response) {
        var path = request.Url.AbsolutePath;

        if (!path.StartsWith(PathPrefix)) {
            var locator = path[PathPrefix.Length..];
            if (DataDictionary.TryGetValue(locator, out var data)) {
                response.ContentType = "application/earl";
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Close(data, true);
                return HttpStatusCode.OK;
                }
            }

        //The path is not correct or there is no such resource
        response.StatusCode = (int)HttpStatusCode.NotFound;
        response.Close();
        return HttpStatusCode.NotFound;
        }


    /// <inheritdoc/>
    public override string Add(
                string locator,
                byte[] data) {
        var result = DataDictionary.Remove(locator);
        DataDictionary.Add(locator, data);

        //var uri = $"https


        return Domain;
        }

    /// <inheritdoc/>
    public override bool Delete(string locator)=> DataDictionary.Remove(locator);


    /// <inheritdoc/>
    public override bool TryGetValue(
                string locator,
                out byte[] data) => DataDictionary.TryGetValue(locator, out data);


    }



/// <summary>
/// EARL Client resolving direct to the service (for testing);
/// </summary>
/// <param name="EarlDispatch"></param>
public  class EarlClientDirect (EarlDispatch EarlDispatch, DnsClient dnsClient) : EarlClient (dnsClient){

    /// <inheritdoc/>
    public override Task<byte[]> TryGetValue(
                string authority,
                string earl) {

        var locator = Udf.EarlLocator(earl);
        EarlDispatch.TryGetValue(locator, out var data);

        if (data == null) {
            throw new NYI();
            }

        return Task.FromResult(data);
        }

    }