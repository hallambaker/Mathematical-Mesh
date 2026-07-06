using Goedel.Cryptography;
using Goedel.IO;

namespace Goedel.Device;

/// <summary>Device connection client.</summary>
public class DeviceConnectClient : IDeviceConnectClient {

    /// <inheritdoc/>
    public DeviceConnectServer DeviceConnectServer { get; }

    /// <summary>Constructor, return a new client for the server
    /// <paramref name="deviceConnectServer"/></summary>
    /// <param name="deviceConnectServer">The device connection server.</param>
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
