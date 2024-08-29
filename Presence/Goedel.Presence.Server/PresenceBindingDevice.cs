//  Copyright © 2021 by Threshold Secrets Llc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

using Goedel.Mesh.Server;
using Goedel.Protocol.Presentation;

using System.Net;

namespace Goedel.Presence.Server;

/// <summary>
/// Tracks a device connected to the service.
/// </summary>
public record PresenceBindingDevice : IQueuableTask, IPresenceDevice {

    ///<summary>State of the device connection</summary> 
    public DeviceState DeviceState { get; set; } = DeviceState.Initial;

    ///<summary>The unique connection ID assigned by the service.</summary> 
    public ulong ConnectionId;

    /// <inheritdoc/>
    public string DeviceId { get; set; }

    /// <inheritdoc/>
    public DeviceStatus DeviceStatus { get; set; }

    ///<summary>The corresponding account binding.</summary> 
    public PresenceBindingAccount AccountBinding { get; init; }

    ///<summary>Time at which the binding was created.</summary> 
    public System.DateTime FirstContact { get; } = System.DateTime.Now;

    ///<summary>Time at which the binding was last used.</summary> 
    public System.DateTime LastContact { get; set; } = System.DateTime.Now;

    ///<summary>Time at which the binding was last used.</summary> 
    public System.DateTime Expire { get; set; } = System.DateTime.Now;

    ///<summary>The last endpoint from which the device was accessed.</summary> 
    public IPEndPoint CurrentEndpoint { get; set; }

    ///<summary>Monotonically increasing connection request counter. To prevent replay
    ///attacks, a connection request MUST be rejected unless it contains a greater or equal
    ///serial number.</summary> 
    public int LastConnectionSerial { get; set; } = -1;

    ///<summary>Monotonically increasing message request counter. </summary> 
    public int LastSerial { get; set; } = -1;

    ///<summary>When set, there is a pending notification to be sent to the device.</summary> 
    public bool Notify { get; set; } = false;


    ///<summary>The shared secret to be used to encrypt outbound messages</summary> 
    public byte[] EncryptKey { get; }

    ///<summary>The shared secret to be used to decrypt inbound messages</summary>
    public byte[] DecryptKey { get; }

    /// <summary>
    /// Compile a packet sequence providing notification of the current status.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public List<byte[]> GetPackets() => throw new NYI();

    #region // Implement IQueuableTask

    ///<inheritdoc/>
    public System.DateTime WakeAt { get; set; }

    ///<inheritdoc/>
    public int CompareTo(object obj) {
        var other = obj as PresenceBindingDevice;

        if (other == null) {
            throw new ArgumentException($"Argument not of type {nameof(PresenceBindingDevice)}");
            }

        var compare = WakeAt.CompareTo(other.WakeAt);
        return compare != 0 ? compare : ConnectionId.CompareTo(other.ConnectionId);


        }
    #endregion


    /// <summary>
    /// Return the status of the devices attached.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public DeviceStatus GetDeviceStatus() => throw new NYI();
    }


