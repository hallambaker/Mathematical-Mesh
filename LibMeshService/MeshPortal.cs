using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;

namespace Goedel.Mesh {

    /// <summary>
    /// Abstract interface to a service that supports the MeshPortal API calls.
    /// Mostly for useful in test code where the ability to switch between a
    /// direct and indirect portal connection is desirable. 
    /// </summary>
    public abstract class MeshPortal {

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public virtual MeshService GetService(string Portal) {
            return GetService(Portal, null);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <param name="Account">Account name.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public abstract MeshService GetService(string Portal, string Account);

        /// <summary>
        /// May be set to the default MeshPortal by a calling application.
        /// </summary>
        public static MeshPortal Default;

        /// <summary>
        /// May be set to the default MeshService by a calling application.
        /// </summary>
        public MeshService MeshService;
        }


    /// <summary>
    /// Abstract interface to a local service provider.
    /// </summary>
    public abstract class MeshLocalPortal : MeshPortal{
        /// <summary>
        /// File name for local access to the mesh store.
        /// </summary>
        protected string MeshStore = "mesh.jlog";

        /// <summary>
        /// File name for local access to the portal store.
        /// </summary>
        protected string PortalStore = "portal.jlog";

        /// <summary>
        /// The service name (default to prismproof.org)
        /// </summary>
        protected string ServiceName = "prismproof.org";

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public PublicMeshServiceProvider MeshServiceHost;
        }


    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class MeshPortalDirect: MeshLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public MeshPortalDirect () {
            Init(MeshStore, PortalStore);
            }

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public MeshPortalDirect(string MeshStore, string PortalStore) {
            Init(MeshStore, PortalStore);
            }

        void Init (string MeshStore, string PortalStore) {
            MeshServiceHost = new PublicMeshServiceProvider(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>

        public override MeshService GetService(string Portal, string Account) {
            var Session = new DirectSession(null);
            MeshService = new MeshServiceSession(MeshServiceHost, Session);
            return MeshService;
            }

        }

    /// <summary>
    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
    /// Useful for producing documentation and for testing.
    /// </summary>
    public class MeshPortalLocal : MeshLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public MeshPortalLocal() {
            MeshServiceHost = new PublicMeshServiceProvider(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        public override MeshService GetService(string Service, string Account) {
            var Session = new LocalRemoteSession(MeshServiceHost, ServiceName, Account);
            MeshService = new MeshServiceClient(Session);
            return MeshService;
            }

        }

    /// <summary>
    /// Connection to network service using HTTP client.
    /// </summary>
    public class MeshPortalRemote : MeshPortal {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MeshPortalRemote () {

            }


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        public override MeshService GetService(string Service, string Account) {
            var URI = JPCProvider.WellKnownToURI(Service, MeshService.WellKnown, 
                        MeshService.Discovery, false, false);

            var Session = new WebRemoteSession(URI, Service, Account);
            MeshService = new MeshServiceClient(Session);
            return MeshService;
            }
        }

    }
