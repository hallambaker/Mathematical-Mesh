


using System.Diagnostics.CodeAnalysis;
using System.Net;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Mesh.Server;

/// <summary>EARL resolution service dispatch.</summary>
public abstract class EarlDispatch {

    /// <summary>The dispatch endpoint.</summary>
    /// <returns></returns>
    public abstract Endpoint GetEndpoint();


    /// <summary>Add an EARL entry.</summary>
    /// <param name="locator">The locator string.</param>
    /// <param name="data">The EARL data.</param>
    /// <returns>The DNS domain to which the EARL is registered.</returns>
    public abstract string Add(
                string locator,
                byte[] data);

    /// <summary>Delete an EARL entry.</summary>
    /// <param name="locator">The locator string.</param>
    /// <returns>True if found, otherwise fale.</returns>
    public abstract bool Delete(string locator);

    /// <summary>Attempt to locate the EARL <paramref name="locator"/></summary>
    /// <param name="locator">The locator string.</param>
    /// <param name="data">The EARL data.</param>
    /// <returns>True if the data was found, otherwise false.</returns>
    public abstract bool TryGetValue(
                string locator,
                [NotNullWhen(true)]out byte[] data);

    }


/// <summary>
/// Dispatch nubin for EARL resolution service using only cached data.
/// </summary>
public class EarlDispatchCached: EarlDispatch {
    string Domain { get; }
    string? Instance { get; }
    Dictionary<string, byte[]> DataDictionary { get; } = [];

    string PathPrefix { get; }

    /// <summary>Constructor, return a caching EARL repository with DNS address
    /// <paramref name="domain"/>.</summary>
    /// <param name="domain">The DNS domain of the repository.</param>
    /// <param name="instance">Optional instance specifier used in testing.</param>
    public EarlDispatchCached(string domain, string? instance = null) {


        Domain = domain;
        Instance = instance;
        PathPrefix = EarlClient.GetPrefix(Instance);
        }

    /// <inheritdoc/>
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
                [NotNullWhen(true)] out byte[] data) => DataDictionary.TryGetValue(locator, out data);


    }



/// <summary>
/// EARL Client resolving direct to the service (for testing);
/// </summary>
/// <param name="EarlDispatch">The EARL service dispatch description.</param>
/// <param name="dnsClient">The DNSClient to use.</param>
public  class EarlClientDirect (EarlDispatch EarlDispatch, DnsClient dnsClient=null) : EarlClient (dnsClient){

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