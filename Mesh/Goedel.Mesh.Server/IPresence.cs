﻿
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
/// Presence Service interface.
/// </summary>
public interface IPresence {

    /// <summary>
    /// Return a presence service endpoint for the specified account.
    /// </summary>
    /// <param name="accountHandle">The handle of the account making the request.</param>
    /// <returns>A unique device connection identifier and a service endpoint allowing the client to access the service..</returns>
    (ulong, ServiceAccessToken) GetEndPoint(AccountHandleLocked accountHandle);


    /// <summary>
    /// Called when an account handle is updated.
    /// </summary>
    void Notify(ulong connectionId);

    /// <summary>
    /// Return the connected devices for the specified account.
    /// </summary>
    /// <returns></returns>
    List<string> GetDevices(ulong connectionId);

    }