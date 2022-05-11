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


namespace Goedel.Protocol.Service;

/// <summary>
/// Base class for service configurations.
/// </summary>
public abstract class ServiceConfiguration {

     
    ///<summary>Returns the configuration entry.</summary> 
    public abstract ConfigurationEntry GetConfigurationEntry();

    ///<summary>The default</summary>
    public GenericHostConfiguration DefaultHostConfiguration { get; set; }

    ///<summary>The service profile fingerprint.</summary> 
    public string ServiceUdf { get; set; } = string.Empty;

    ///<summary>Path to the service data</summary> 
    public string ServicePath { get; set; } = string.Empty;

    ///<summary>Service DNS addresses</summary> 
    public List<string> ServiceDNS { get; set; } = new List<string>();

    ///<summary>The set of administrators.</summary> 
    public List<string> Administrators { get; set; } = new List<string>();

    ///<summary>Path to the host data.</summary> 
    public string? HostPath { get; set; } = null;

    }
