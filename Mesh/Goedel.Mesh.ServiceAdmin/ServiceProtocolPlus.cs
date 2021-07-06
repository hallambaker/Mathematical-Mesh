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
//  

using Goedel.Utilities;

using Goedel.Protocol;

using System;
using System.Collections.Generic;


namespace Goedel.Mesh.ServiceAdmin {
    public partial class Configuration {
        bool processed = false;

        public Dictionary<string, ServiceConfiguration> DictionaryService { get;}  = new();

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
        }


    /// <summary>
    /// Service administration request
    /// </summary>
    public partial class ServiceConfiguration  {

        #region // Properties

        public string DefaultIp { get; set; }


        

        #endregion 

        #region // Destructor
        #endregion 

        #region // Constructors
        #endregion 

        #region // Implement Interface: Ixxx
        #endregion 

        #region // Methods 
        #endregion 
        }

    public partial class HostConfiguration {
        public List<ServiceConfiguration> ServiceConfigs { get; set; }


        }

    }
