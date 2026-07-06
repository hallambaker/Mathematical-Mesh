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

namespace Goedel.Thing.Server;

/// <summary>
/// Well Known services.
/// </summary>
public enum WellKnownService {

    ///<summary>HTTP</summary> 
    HTTP,

    ///<summary>HTTP over TLS.</summary> 
    HTTPS,

    ///<summary>HTTP/2</summary> 
    HTTP2,

    ///<summary>HTTP/3</summary> 
    HTTP3,

    ///<summary>Git</summary> 
    Git,

    ///<summary>SSH</summary> 
    SSH,

    ///<summary>Andrews File System</summary> 
    AFS,

    ///<summary>Windows Server Message Block 2 file server</summary> 
    SMB2,

    ///<summary>Windows Server Message Block 3 file server</summary> 
    SMB3,

    ///<summary>Network File Server v3</summary> 
    NFS3,

    ///<summary>Network File Server v4</summary> 
    NFS4,

    ///<summary>Mathematical Mesh</summary> 
    Mesh,

    ///<summary>Internet Printing Protocol.</summary> 
    IPP
    }

/// <summary>
/// Extensions class.
/// </summary>
public  static partial class Extensions {

    /// <summary>
    /// Return the service prefix for <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The service to return the information for.</param>
    /// <returns>The IANA protocol identifier</returns>
    public static string GetProtocol(
                this WellKnownService service) => throw new NotImplementedException();

    /// <summary>
    /// Return the default for <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The service to return the information for.</param>
    /// <param name="port">The service port number.</param>
    /// <returns>The IANA protocol identifier</returns>
    public static int GetPort(
                this WellKnownService service, int port = 0) => throw new NotImplementedException();

    /// <summary>
    /// Return the configuration  for <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The service to return the information for.</param>
    /// <param name="configuration">The configuration data.</param>
    /// <returns>The IANA protocol identifier</returns>
    public static string GetConfiguration(
                this WellKnownService service, string configuration = null) => throw new NotImplementedException();





    }