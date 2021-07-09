﻿//  © 2021 by Phill Hallam-Baker
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
//  

using Goedel.Utilities;

using Goedel.Protocol.Presentation;
using System.Collections.Generic;


namespace Goedel.Mesh.ServiceAdmin {

    /// <summary>
    /// Delegate returning a host <paramref name="hostConfiguration"/> for the
    /// service  <paramref name="serviceConfiguration"/>
    /// </summary>
    /// <param name="serviceConfiguration">The service configuration.</param>
    /// <param name="hostConfiguration">The configuration of this specific host.</param>
    /// <returns></returns>
    public delegate RudProvider ServiceFactoryDelegate(
        ServiceConfiguration serviceConfiguration,
        HostConfiguration hostConfiguration);

    /// <summary>
    /// Service description used to advertise a service provider.
    /// </summary>
    public record ServiceDescription(
            string WellKnown, ServiceFactoryDelegate Factory) {


        }

    /// <summary>
    /// Describes a service configuration.
    /// </summary>
    public partial class ServiceConfiguration {
        /// <summary>The service profile.</summary>
        public Goedel.Mesh.ProfileService ProfileService => throw new NYI();

        ///<summary>The service instance.</summary> 
        public string Instance { get; set; }

        /// <summary>
        /// Returns the endpoints for the service configuration.
        /// </summary>
        /// <returns>The endpoints</returns>
        public List<Endpoint> GetEndpoints() {
            var endpoints = new List<Endpoint>();

            foreach (var address in Addresses) {
                if (address.IsDns()) {
                    endpoints.Add(new HttpEndpoint(address, WellKnown, Instance));
                    }
                else if (address.IsCallSign()) {


                    }

                }



            return endpoints;
            }





        }

    /// <summary>
    /// Describes a host configuration.
    /// </summary>
    public partial class HostConfiguration {

        /// <summary>The host profile </summary>
        public ProfileHost ProfileHost => throw new NYI();

        ///<summary>The connection of the host to the service.</summary> 
        public ConnectionDevice ConnectionDevice => throw new NYI();

        /// <summary>
        /// Returns the endpoints for the host configuration.
        /// </summary>
        /// <returns>The endpoints</returns>
        public List<Endpoint> GetEndpoints() {
            var endpoints = new List<Endpoint>();

            return endpoints;
            }

        /// <summary>
        /// Get the private credential data.
        /// </summary>
        /// <returns>The private credential</returns>
        public ICredentialPrivate GetCredential() {

            // to do: read the credential that was written out when the host
            // was initialized.


            throw new NYI();
            }


        }

    public partial class Configuration {


        /// <summary>
        /// Return the host configuration for the machine <paramref name="id"/>
        /// </summary>
        /// <param name="id">Machine to return the configuration for.</param>
        /// <returns>The host configuration (if found).</returns>
        public HostConfiguration GetHostConfiguration(string id) {

            Entries.AssertNotNull(HostNotFound.Throw, id);
            
            bool nonHost = false;
            foreach (var entry in Entries) {

                if (entry.Id?.ToLower() == id | (id == "*")) {
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
            throw new ServiceNotFound();
            }





        }



    }
