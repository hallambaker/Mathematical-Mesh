
namespace Goedel.Device;

/// <summary>
/// Device connection client, requests a connection to a device by means of an 
/// EARL
/// </summary>
public interface IDeviceConnectClient {


    /// <summary>
    /// Make a connection request.
    /// </summary>
    /// <param name="earl">The EARL to which the request is posted.</param>
    /// <param name="device">The JsDevice data (if available).</param>
    /// <returns>The connection description.</returns>
    Task<DeviceConnect> RequestConnectAsync(string earl, JsDevice device=null);

    }