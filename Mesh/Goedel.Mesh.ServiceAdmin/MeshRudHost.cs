using Goedel.Protocol.GenericHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goedel.Protocol.Presentation;
using Goedel.Mesh;
using Goedel.Protocol.Service;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Goedel.Mesh.ServiceAdmin;


public class MeshRudHost : IProviderHost {

    GenericHostConfiguration GenericHostConfiguration { get; }

    public MeshRudHost(
                IOptionsMonitor<GenericHostConfiguration> genericHostConfiguration,
                IMeshMachine meshMachine) {
        //var credential = MeshMachine.GetCredential();


        //        RudService = new RudService(cancellationToken, ConfigurableServices,
        //            null, null);
        GenericHostConfiguration = genericHostConfiguration.CurrentValue;
        }



    ///<inheritdoc/>
    public async Task StartAsync(CancellationToken cancellationToken, IEnumerable<IProvider> providers) {
        throw new NotImplementedException();
        }

    }
