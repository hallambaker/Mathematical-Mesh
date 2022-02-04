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

using System.Threading;
using System.Threading.Tasks;
namespace Goedel.Protocol;





public record struct ConfigurationEntry (
            string Name, 
            Type Type,
            string? Discovery = null,
            string? WellKnown = null
            ) {



    }



/// <summary>
/// Service configuration
/// </summary>
public class GenericHostConfiguration {


    public readonly static ConfigurationEntry ConfigurationEntry = 
            new ConfigurationEntry ("Host", typeof (GenericHostConfiguration));

    public string? RunAs { get; set; } = null;

    public string? Description { get; set; } = null;

    public string? HostUdf { get; set; } = null;

    public string? DeviceUdf { get; set; } = null;



    ///<summary>Host DNS address</summary> 
    public string? HostDns { get; set; } = null;

    ///<summary>The IP address and port numbers</summary> 
    public List<string> IP { get; set; } = new() ;





    ///<summary>The maximum number of cores, if zero, all cores on the machine
    ///are used.</summary> 
    public int MaxCores { get; set; } = 0;


    public string Instance { get; set; } = null!;

    public int Port = 15099;




    }



public interface IServiceListener {


    Task StartAsync(
        CancellationToken cancellationToken
        );


    }


/// <summary>
/// Service provider interface.
/// </summary>
public interface IConfguredService {

    ///<summary>The provider interface.</summary> 
    JpcInterface JpcInterface { get; }

    ///<summary>The Service endpoints.</summary> 
    public List<Endpoint> Endpoints { get; }



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



    /// <summary>
    /// Post the request <paramref name="request"/> 
    /// </summary>
    /// <param name="tag">The transaction identifier.</param>

    /// <param name="request">The transaction request.</param>
    /// <returns>The transaction response</returns>
    JsonObject Post(string tag, JsonObject request);


    /// <summary>
    ///Bind new credential to the session to create a new one.
    /// </summary>
    /// <param name="credential">Credential to bind.</param>
    /// <returns>The new session.</returns>
    IJpcSession Rebind(ICredential credential);
    }
