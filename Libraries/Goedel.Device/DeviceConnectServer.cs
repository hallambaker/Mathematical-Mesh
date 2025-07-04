using System.Net;

namespace Goedel.Device;


public class DeviceConnectServer : IDeviceConnectServer {

    ///<summary>The test instance.</summary>
    public string Instance { get; }

    public string Endpoint { get; }

    HttpListener HttpListener { get; }
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
        var result = new DeviceConnect();

        var response = context.Response;
        response.StatusCode = 200;



        return result;
        }







    }