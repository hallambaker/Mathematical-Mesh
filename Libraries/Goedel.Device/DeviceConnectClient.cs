using Goedel.Cryptography;
using Goedel.IO;

namespace Goedel.Device;

public class DeviceConnectClient : IDeviceConnectClient {

    /// <inheritdoc/>
    public DeviceConnectServer DeviceConnectServer { get; }

    public DeviceConnectClient(DeviceConnectServer deviceConnectServer) {
        DeviceConnectServer = deviceConnectServer;

        }

    /// <inheritdoc/>
    public async Task<DeviceConnect> RequestConnectAsync(
                string earl,
                JsDevice device=null
                ) {

        var client = UriClient.HttpClient;
        var result = client.GetStringAsync(DeviceConnectServer.Endpoint);


        return new DeviceConnect();
        }



    }
