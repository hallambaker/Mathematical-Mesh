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

//  

using System.Net;
using System.Threading.Tasks;
namespace Goedel.Protocol;








/// <summary>
/// Service configuration
/// </summary>
public class GenericHostConfiguration : IConfigurationEntry {

    static int defaultPort = 15099;

    ///<summary>The configuration entry.</summary> 
    public readonly static ConfigurationEntry ConfigurationEntry =
            new ("Host", typeof(GenericHostConfiguration));

    ///<inheritdoc/>
    public ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;

    ///<summary>The platform account under which the host process is to run.</summary> 
    public string? RunAs { get; set; } = null;

    ///<summary>Service description (for logging)</summary> 
    public string? Description { get; set; } = null;

    ///<summary>The Host profile fingerprint.</summary> 
    public string? HostUdf { get; set; } = null;

    ///<summary>The Device profile fingerprint</summary> 
    public string? DeviceUdf { get; set; } = null;

    ///<summary>Host DNS address</summary> 
    public string? HostDns { get; set; } = null;

    ///<summary>The IP address and port numbers</summary> 
    public List<string> IP { get; set; } = new();

    ///<summary>Path to the host data.</summary> 
    public string? HostPath { get; set; } = null;


    ///<summary>The maximum number of cores, if zero, all cores on the machine
    ///are used.</summary> 
    public int MaxCores { get; set; } = 0;

    ///<summary>Service instance specifier, used to run multiple hosts on one machine 
    ///for testing, etc.</summary> 
    public string Instance { get; set; } = null!;

    ///<summary>The port number.</summary> 
    public int Port => GetPort();

    int GetPort() {
        if (IP == null || IP.Count == 0) {
            return defaultPort;
            }
        if (IPEndPoint.TryParse(IP[0], out var endpoint)) {
            return endpoint.Port == 0 ? defaultPort : endpoint.Port;
            }
        return defaultPort;
        }

    }


/// <summary>
/// Service listener interface for dependency injection selection.
/// </summary>
public interface IServiceListener {

    /// <summary>
    /// Start the listener.
    /// </summary>
    /// <param name="cancellationToken">Cancellation, listener will abort when triggered.</param>
    /// <returns>The listener task.</returns>
    Task StartAsync(
        CancellationToken cancellationToken
        );


    }






/// <summary>
/// Jpc Session interface.
/// </summary>
public interface IJpcSession {

    ///<summary>The verified account bound to this session (used for inbound sessions
    ///only.)</summary> 
    ICredential Credential { get; }

    /// <summary>
    /// The target account this session is attempting to interact with.
    /// </summary>
    public string TargetAccount { get; }


    //bool IsAsync { get; };


    /// <summary>
    /// Post the request <paramref name="request"/> 
    /// </summary>
    /// <param name="tag">The transaction identifier.</param>

    /// <param name="request">The transaction request.</param>
    /// <returns>The transaction response</returns>
    JsonObject Post(string tag, JsonObject request);


    /// <summary>
    /// Post the request <paramref name="request"/> asynchronously and create a
    /// task waiting for the result. 
    /// </summary>
    /// <remarks>Throws an exception if the connection type does not support asynchronous
    /// return.</remarks>
    /// <param name="tag">The transaction identifier.</param>

    /// <param name="request">The transaction request.</param>
    /// <returns>The transaction response</returns>
    Task<JsonObject> PostAsync(string tag, JsonObject request);



    /// <summary>
    ///Bind new credential to the session to create a new one.
    /// </summary>
    /// <param name="credential">Credential to bind.</param>
    /// <returns>The new session.</returns>
    IJpcSession Rebind(ICredential credential);
    }
