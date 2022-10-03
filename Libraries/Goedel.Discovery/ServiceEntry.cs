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


namespace Goedel.Discovery;

/// <summary>
/// Represents an Internet destination, this may be a single IPv4 or IPv6 
/// address or a sequence of prioritized IP addresses.
/// </summary>
public class ServiceEntry {

    /// <summary>The prefixed Host address</summary>
    public string HostAddress {
        get {
            var Text = ServiceDescription?.Prefix + Address;
            return Text.ToLower();
            }
        }

    string _Address;
    /// <summary>The DNS Address to resolve</summary>
    public virtual string Address {
        get => _Address ?? ServiceDescription?.Default.Address;
        set => _Address = value;
        }

    int? _Port;
    /// <summary>The port number to connect to</summary>
    public virtual int? Port {
        get => _Port ?? ServiceDescription?.Default.Port;
        set => _Port = value;
        }

    /// <summary>Priority of this service entry</summary>
    public virtual int Priority { get; set; }
    /// <summary>Weight of this service entry</summary>
    public virtual int Weight { get; set; }

    string _Path;
    /// <summary>URI path to connect to (will default to /.well-known/&lt;Service&gt;</summary>
    public virtual string Path {
        get => _Path ?? ServiceDescription?.Default.Path;
        set => _Path = value;
        }

    TransportSecurity? _TransportSecurity;
    /// <summary>Transport security setting</summary>
    public virtual TransportSecurity? TransportSecurity {
        get => _TransportSecurity ?? ServiceDescription?.Default.TransportSecurity;
        set => _TransportSecurity = value;
        }

    Transport? _Transport;
    /// <summary>Transport setting</summary>
    public virtual Transport? Transport {
        get => _Transport ?? ServiceDescription?.Default.Transport;
        set => _Transport = value;
        }

    string _URI;
    /// <summary>Security policy URI</summary>
    public virtual string URI {
        get => _URI ?? ServiceDescription?.Default.URI;
        set => _URI = value;
        }

    string _UDF;
    /// <summary>Security policy fingerprint</summary>
    public virtual string UDF {
        get => _UDF ?? ServiceDescription?.Default.UDF;
        set => _UDF = value;
        }

    readonly List<string> _TXT = new();
    /// <summary>Text policy records</summary>
    public virtual List<string> TXT => _TXT;

    /// <summary>Internal flag used in the sorting algorithm to mark allocated entries. </summary>
    public bool Flag { get; set; } = false;


    /// <summary>The service description to which this entry is attached</summary>
    public ServiceDescription ServiceDescription { get; set; }


    /// <summary>Calculate the Web Service Endpoint for a HTTP binding</summary>
    public string HTTPEndpoint {
        get {
            if (_Port == null) {
                return "http://" + Address + Path;
                }
            else {
                return "http://" + Address + ":" + Port.ToString() + Path;
                }
            }
        }

    }
