
namespace Goedel.Device;


/// <summary>Interface for device connection servers.</summary>
public interface IDeviceConnectServer {

    /// <summary>
    /// Wait to receive a bootstrap connection request.
    /// </summary>
    /// <returns>The bootstrap data payload.</returns>
    Task<DeviceConnect> GetBootstrapAsync();
    }