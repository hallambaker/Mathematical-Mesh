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

namespace Goedel.Presence.Server;

/// <summary>
/// Tracks an account with device(s) connected to the service.
/// </summary>
public class PresenceBindingAccount : IPresenceAccount {

    /// <summary>
    /// Bitmask describing the set of catalogs that were updated.
    /// </summary>
    public byte[] Bitmask { get; set; } = null;

    /// <summary>
    /// The presence serial value.
    /// </summary>
    public int Serial { get; set; } = 0;

    ///<summary>The account identifier.</summary> 
    public string AccountId;

    ///<summary>Time at which the binding was created.</summary> 
    public System.DateTime FirstContact { get; } = System.DateTime.Now;

    ///<summary>Time at which the binding was last used.</summary> 
    public System.DateTime LastContact { get; set; } = System.DateTime.Now;

    ///<summary>Dictionary of connected devices.</summary> 
    public Dictionary<ulong, PresenceBindingDevice> ConnectedDevices { get; } = new();

    }


