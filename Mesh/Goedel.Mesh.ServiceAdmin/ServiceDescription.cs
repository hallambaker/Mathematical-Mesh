#region // Copyright - MIT License
//  Copyright © 2021 by Phill Hallam-Baker
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

using System.Collections.Generic;

using Goedel.Protocol.Presentation;
using Goedel.Utilities;
using Goedel.Protocol;

namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// Delegate returning an instance of a service provider on the machine 
/// <paramref name="hostConfiguration"/>
/// according to the parameters specified in <paramref name="serviceConfiguration"/> and
/// <paramref name="hostConfiguration"/>/
/// </summary>
/// <param name="meshMachine">The Mesh machine instance.</param>
/// <param name="serviceConfiguration">The service configuration.</param>
/// <param name="hostConfiguration">The configuration of this specific host.</param>
/// <returns></returns>
public delegate RudProvider ServiceFactoryDelegate(
    IMeshMachine meshMachine,
    ServiceConfiguration serviceConfiguration,
    HostConfiguration hostConfiguration);

/// <summary>
/// Service description used to advertise a service provider.
/// </summary>
public record ServiceDescription(
        string WellKnown, ServiceFactoryDelegate Factory) {
    }


public partial class Configuration {
    #region // Properties

    bool processed = false;

    ///<summary>Dictionary mapping service name to configuiration.</summary> 
    public Dictionary<string, ServiceConfiguration> DictionaryService { get; } = new();

    #endregion
    #region // Constructors and Factory Methods

    /// <summary>
    /// Read a service configuration from the file <paramref name="filePath"/>.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The configuration.</returns>
    public static Configuration ReadFile(string filePath) =>
        JsonReader.ReadFile<Configuration>(filePath, false);
    
    #endregion
    #region // Methods 

    /// <summary>
    /// Perform post processing of a configuration to resolve identifiers to objects
    /// etc.
    /// </summary>
    public void PostProcess() {
        if (processed) {
            return;
            }
        processed = true;

        foreach (var entry in Entries) {
            if (entry is ServiceConfiguration serviceConfiguration) {

                DictionaryService.Add(serviceConfiguration.Id, serviceConfiguration);

                }

            }


        foreach (var entry in Entries) {
            if (entry is HostConfiguration hostConfiguration) {

                hostConfiguration.ServiceConfigs = new();

                foreach (var service in hostConfiguration.Services) {
                    if (DictionaryService.TryGetValue(service, out var config)) {
                        hostConfiguration.ServiceConfigs.Add(config);
                        config.DefaultIp ??= hostConfiguration.IP[0];
                        }

                    }


                }
            }
        }


    /// <summary>
    /// Return the host configuration for the machine <paramref name="id"/>
    /// </summary>
    /// <param name="id">Machine to return the configuration for.</param>
    /// <returns>The host configuration (if found).</returns>
    public HostConfiguration GetHostConfiguration(string id) {

        Entries.AssertNotNull(HostNotFound.Throw, id);

        bool nonHost = false;
        foreach (var entry in Entries) {

            if (entry.Id?.ToLower() == id.ToLower() | (id == "*")) {
                if (entry is HostConfiguration) {
                    return entry as HostConfiguration;
                    }
                nonHost = true;
                }
            }
        nonHost.AssertFalse(ConfigurationNotHost.Throw, id);
        throw new HostNotFound(null, null, id);

        }



    /// <summary>
    /// Return the host configuration for the host <paramref name="hostConfiguration"/>
    /// </summary>
    /// <param name="hostConfiguration">Host to return the service configuration for.</param>
    /// <returns>The host configuration (if found).</returns>
    public ServiceConfiguration GetServiceConfiguration(HostConfiguration hostConfiguration) {


        Entries.AssertNotNull(ServiceNotFound.Throw);
        if ((hostConfiguration.Services == null) || (hostConfiguration.Services.Count == 0)) {
            foreach (var entry in Entries) {

                if (entry is ServiceConfiguration) {
                    return entry as ServiceConfiguration;
                    }
                }
            }
        PostProcess();

        return hostConfiguration.ServiceConfigs[0];
        }



    #endregion
    }




/// <summary>
/// Describes a service configuration.
/// </summary>
public partial class ServiceConfiguration {

    #region // Properties
    /// <summary>The service profile.</summary>
    public Goedel.Mesh.ProfileService ProfileService => throw new NYI();

    ///<summary>The service instance.</summary> 
    public string Instance { get; set; }

    ///<summary>The default IP address</summary> 
    public string DefaultIp { get; set; }


    #endregion
    #region // Methods 



    #endregion


    }

/// <summary>
/// Describes a host configuration.
/// </summary>
public partial class HostConfiguration {

    #region // Properties

    ///// <summary>The host profile </summary>
    //public ProfileHost ProfileHost => EnvelopedProfileHost.Decode ();

    /////<summary>The connection of the host to the service.</summary> 
    //public ConnectionDevice ConnectionDevice => EnvelopedConnectionDevice.Decode();


    ///<summary>List of referenced service configurations.</summary> 
    public List<ServiceConfiguration> ServiceConfigs { get; set; }


    public bool ConsoleOutput { get; set; }


    #endregion
    #region // Methods 

    /// <summary>
    /// Returns the endpoints for the host configuration.
    /// </summary>
    /// <returns>The endpoints</returns>
    public List<Endpoint> GetEndpoints(string wellKnown = null) {

        var endpoints = new List<Endpoint>();

        foreach (var service in ServiceConfigs) {

            foreach (var address in service.Addresses) {
                if (address.IsDns()) {
                    endpoints.Add(new HttpEndpoint(address, wellKnown ?? service.WellKnown, service.Instance, Port: Port));
                    }
                else if (address.IsCallSign()) {
                    }
                }
            }

        return endpoints;
        }

    /// <summary>
    /// Get the private credential data.
    /// </summary>
    /// <returns>The private credential</returns>
    public ICredentialPrivate GetCredential(IMeshMachine meshMachine) =>
        meshMachine.GetCredential(DeviceUdf, ProfileUdf);

    #endregion
    }
