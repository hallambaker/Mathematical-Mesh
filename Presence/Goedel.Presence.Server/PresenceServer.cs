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

using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Mesh.Server;
using System.Net.Sockets;
using Goedel.Discovery;
using System.Net;
using Goedel.Protocol.Service;

namespace Goedel.Presence.Server;

/// <summary>
/// Tracks a device connected to the service.
/// </summary>
public class DeviceBinding {

    public string DeviceId;

    public AccountBinding AccountBinding { get; }

    public ulong ConnectionId;

    public DateTime FirstContact { get; } = DateTime.Now;

    public DateTime LastContact { get; set; } = DateTime.Now;
    }


public class AccountBinding {

    public string AccountId;

    public DateTime FirstContact { get; } = DateTime.Now;

    public DateTime LastContact { get; set;  } = DateTime.Now;

    public Dictionary<string, DeviceBinding> ConnectedDevices { get;  }  = new();


    }


/// <summary>
/// The presence service.
/// </summary>
public class PresenceServer : PresenceService, IPresence {
    #region // Properties
    UdpClient UdpServiceIpv4;
    UdpClient UdpServiceIpv6;

    int PortIpv4;
    int PortIpv6;

    List<string> IP { get; }

    List<string> Endpoints { get; } = new();


    Dictionary<string, AccountBinding> Accounts { get; } = new();

    Dictionary <ulong, DeviceBinding>Devices { get; } = new();
    ulong ConnectionID = 0;
    #endregion
    #region // Constructors


    /// <summary>
    /// Default constructor, returns an empty instance.
    /// </summary>
    public PresenceServer(
            GenericHostConfiguration hostConfiguration,
            PresenceServiceConfiguration presenceServiceConfiguration) {
        // Assign a service port.
        UdpServiceIpv4 = HostNetwork.GetUDPClient();
        UdpServiceIpv6 = HostNetwork.GetUDPClient(AddressFamily.InterNetworkV6);

        PortIpv4 = GetPort(UdpServiceIpv4);
        PortIpv6 = GetPort(UdpServiceIpv6);

        IP = presenceServiceConfiguration?.IP ??
                hostConfiguration?.IP;

        if (IP is null) {
            IP = new();
            var localEndPoints = HostNetwork.GetLocalEndpoints();
            foreach (var localEndpoint in localEndPoints) {
                IP.Add(localEndpoint.ToString());
                }
            }

        foreach (var ip in IP) {
            if (IPEndPoint.TryParse(ip, out var endpoint)) {
                if (endpoint.Port <= 0) {
                    endpoint.Port = endpoint.AddressFamily == AddressFamily.InterNetwork ?
                        PortIpv4 : PortIpv6;
                    }
                Endpoints.Add(endpoint.ToString());
                }
            }

        }

    int GetPort(UdpClient udpClient) {

        var endpoint = udpClient?.Client?.LocalEndPoint as IPEndPoint;
        if (endpoint is null) {
            return -1;
            }
        return endpoint.Port;
        }


    #endregion
    #region // Implement Inteface IPresence

    ///<inheritdoc/>
    public (ulong, ServiceAccessToken) GetEndPoint(AccountHandleLocked accountHandle) {

        var connectionId = Interlocked.Increment(ref ConnectionID);

        lock (Accounts) {
            if (!Accounts.TryGetValue(accountHandle.AccountAddress, out var accountBinding)) {
                accountBinding = new AccountBinding() {
                    AccountId = accountHandle.AccountAddress
                    };
                Accounts.Add(accountHandle.AccountAddress, accountBinding);
                }
            accountBinding.LastContact = DateTime.Now;
            }

        var deviceBinding = new DeviceBinding() {
            ConnectionId = connectionId,
            LastContact = DateTime.Now
            };

        var tokenId = connectionId.BigEndian();

        var result = new ServiceAccessToken() {
            Prefix = MeshConstants.MeshPresenceService,
            SharedSecret = null, // ToDo Make a key and pass in the token!!!
            Token = tokenId,
            Endpoints = Endpoints
            };
        return (connectionId, result);

        }





    ///<inheritdoc/>
    public List<string> GetDevices(ulong connectionId) {
        throw new NotImplementedException();
        }

    ///<inheritdoc/>
    public void Notify(ulong connectionId) {
        throw new NotImplementedException();
        }


    #endregion
    #region // Override Methods
    #endregion
    #region // Methods


    ///<inheritdoc/>
    public override ConnectResponse Connect(ConnectRequest request, IJpcSession session) {
        throw new NotImplementedException();
        }



    ///<inheritdoc/>
    public override QueryResponse Query(QueryRequest request, IJpcSession session) {
        throw new NotImplementedException();
        }
    #endregion
    }
