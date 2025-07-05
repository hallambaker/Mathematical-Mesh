using Goedel.Contacts;

using System.Net;

namespace Goedel.Device;

/// <summary>
/// Stub for device connection server.
/// </summary>
public class DeviceConnectServer : IDeviceConnectServer {

    ///<summary>The test instance.</summary>
    public string Instance { get; }

    ///<summary>The HTTP endpoint</summary>
    public string Endpoint { get; }

    HttpListener HttpListener { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="instance"></param>
    public DeviceConnectServer(
                string instance) {
        Instance = instance;

        Endpoint = $"http://localhost:15099/.well-known/test/{instance}";

        HttpListener = new ();
        HttpListener.Prefixes.Add(Endpoint);

        HttpListener.Start();
        }

    /// <inheritdoc/>
    public async Task<DeviceConnect> GetBootstrapAsync() {

        var context = await HttpListener.GetContextAsync();
        
        // ToDo: Here add validation of the request against the EARL.
        
        var result = new DeviceConnect() {
            Networks = [
                new NetworkConnectEthernet ()
                ],
            Services = [
                new OnboardingService () {
                    Id = Udf.Nonce(),
                    Protocol = "_mmmConnect",
                    Endpoint = $"https://127.0.0.1/.well-known/mmmconnect/{Instance}"
                    }
                ]
            };

        // Prepare the response by serializing untagged and wrapping it in an envelope.

        // ToDo: Encrypt the response under a key formed from the EARL, a nonce provided
        // in the request and a salt provided in the response envelope.
        var enveloped = result.Envelope();
        var bytes = enveloped.GetBytes(false);

        var response = context.Response;
        response.Close(bytes, false);

        return result;
        }

    }