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


namespace Goedel.Mesh.Management;

/// <summary>
/// The Service Management Provider.
/// </summary>
public class ServiceManagementProvider : ServiceManagementService {

    ///<inheritdoc cref="ServiceFactoryDelegate"/>
    public static RudProvider Factory(
        IMeshMachine meshMachine,
        ServiceConfiguration serviceConfiguration,
        HostConfiguration hostConfiguration) {


        // Since it is the host that responds, the service binds to the host endpoints
        // in addition to the service.


        var wellKnown = ServiceManagementProvider.WellKnown + "/" + serviceConfiguration.Id;

        var endpoints = hostConfiguration.GetEndpoints(wellKnown);
        //endpoints.AddRange(hostConfiguration.GetEndpoints());
        var provider = new ServiceManagementProvider(serviceConfiguration, hostConfiguration);

        return new RudProvider(endpoints, provider);
        }


    ///<summary>The service description for a service reporting a single host.</summary> 
    public static ServiceDescription ServiceDescriptionHost => new(WellKnown, Factory);

    ///<summary>The service description for a service reporting a set of hosts.</summary> 
    public static ServiceDescription ServiceDescriptionMeta => throw new NYI();


    #region // Properties
    HostConfiguration HostConfiguration { get; }

    ServiceConfiguration ServiceConfiguration { get; }
    #endregion

    #region // Destructor
    #endregion

    #region // Constructors

    /// <summary>
    /// Return a new <see cref="ServiceManagementProvider"/> instance.
    /// </summary>
    /// <param name="serviceConfiguration"></param>
    /// <param name="hostConfiguration"></param>
    public ServiceManagementProvider(
            ServiceConfiguration serviceConfiguration,
            HostConfiguration hostConfiguration) {

        // Stash these away to report if needed.
        HostConfiguration = hostConfiguration;
        ServiceConfiguration = serviceConfiguration;


        HostConfiguration.Future();
        ServiceConfiguration.Future();
        }


    #endregion

    #region // Implement Interface: Ixxx
    #endregion

    #region // Methods 

    ///<inheritdoc/>
    public override ServiceStatusResponse ServiceStatus(ServiceStatusRequest request, IJpcSession session) {
        throw new System.NotImplementedException();
        }

    ///<inheritdoc/>
    public override ServiceConfigResponse ServiceConfig(ServiceConfigRequest request, IJpcSession session) => throw new NotImplementedException();

    #endregion
    }
