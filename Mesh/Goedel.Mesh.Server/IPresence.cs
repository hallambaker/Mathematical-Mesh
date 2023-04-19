
#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion

namespace Goedel.Mesh.Server;


/// <summary>
/// Tracks the state of a device connection.
/// </summary>
public enum DeviceState {

    ///<summary>Connection requested, no contact.</summary> 
    Initial,

    ///<summary>Device has sent information within the timeout window.</summary> 
    Connected,

    ///<summary>Device was sent first overdue notice.</summary> 
    Overdue1,

    ///<summary>Device was sent first overdue notice.</summary> 
    Overdue2,

    ///<summary>Connection pending deletion.</summary> 
    Closed

    }


/// <summary>
/// Presence account interface.
/// </summary>
public interface IPresenceAccount {
    
    
    }

/// <summary>
/// Presence device interface.
/// </summary>
public interface IPresenceDevice {


    ///<summary>The device profile UDF.</summary> 
    public string DeviceId { get; set; }


    ///<summary>The device status.</summary> 
    public DeviceState DeviceState { get; set; }
    }


/// <summary>
/// Presence Service interface.
/// </summary>
public interface IPresence {

    /// <summary>
    /// Return a presence service endpoint for the specified account.
    /// </summary>
    /// <param name="accountHandle">The handle of the account making the request.</param>
    /// <returns>A unique device connection identifier and a service endpoint allowing the client to access the service..</returns>
    ServiceAccessToken GetEndPoint(
        AccountHandleLocked accountHandle);


    /// <summary>
    /// Called when an account handle is updated.
    /// </summary>
    void Notify(string accountIdentifier, byte[] bitMask);

    /// <summary>
    /// Return the connected devices for the specified account.
    /// </summary>
    /// <returns>List of the device identifiers of the connected devices.</returns>
    List<DeviceStatus> GetDevices(string accountIdentifier);

    }
