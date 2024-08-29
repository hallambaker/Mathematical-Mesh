//using Goedel.Callsign;
//using Goedel.Mesh.Client;
//using Goedel.Mesh.Core;
//using Goedel.Protocol;
//using Goedel.Protocol.Presentation;

//namespace Goedel.Mesh.Machine;

//using Goedel.Mesh.Server;



///// <summary>
///// Implementation of a direct machine.
///// </summary>
//public class MachineDirect : MeshMachineDirect {




//    public ResolverService ResolverService { get; private set; }


//    /// <summary>
//    /// Constructor returning a new instance connecting to the service 
//    /// <paramref name="publicMeshService"/> by means of the client 
//    /// <paramref name="meshMachineClient"/>.
//    /// </summary>
//    /// <param name="meshMachineClient">A client instance provisioned with the
//    /// necessary credential.</param>
//    /// <param name="publicMeshService">The service instance.</param>
//    public MachineDirect(
//                IMeshMachineClient meshMachineClient,
//                PublicMeshService publicMeshService
//                ) : base (meshMachineClient, publicMeshService) {




//        }

//    /// <summary>
//    /// Add service to direct interface machine.
//    /// </summary>
//    /// <param name="jpcInterface"></param>
//    public void AddService(JpcInterface jpcInterface) {
//        DirectServices.Add(jpcInterface.GetWellKnown, jpcInterface);

//        switch (jpcInterface) {
//            case ResolverService resolverService: {
//                ResolverService = resolverService;

//                break;
//                }
//            }
//        }

//    ///<inheritdoc/>
//    public override IResolver GetResolver(ICredentialPrivate credential) {
//        throw new NotImplementedException();
//        }

//    ///<inheritdoc/>
//    public override ICarnet GetCarnet(ICredentialPrivate credential) {
//        throw new NotImplementedException();
//        }



//    }
