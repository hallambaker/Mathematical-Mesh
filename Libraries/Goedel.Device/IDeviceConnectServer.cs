
namespace Goedel.Device;

public interface IDeviceConnectServer {

    /// <summary>
    /// Wait to receive a bootstrap connection request.
    /// </summary>
    /// <returns>The bootstrap data payload.</returns>
    Task<DeviceConnect> GetBootstrapAsync();
    }