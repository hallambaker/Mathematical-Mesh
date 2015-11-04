using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;

namespace Goedel.Mesh {

    /// <summary>
    /// Abstract interface to a service that supports the MeshPortal API calls.
    /// </summary>
    public abstract class MeshPortal {

        public const string ProtocolID = "mathematicalmesh";


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public virtual MeshService GetService(string Portal) {
            return GetService(Portal, null);
            }
        public abstract MeshService GetService(string Service, string Account);

        /// <summary>
        /// May be set to the default MeshPortal by a calling application.
        /// </summary>
        public static MeshPortal Default;

        /// <summary>
        /// May be set to the default MeshService by a calling application.
        /// </summary>
        public MeshService MeshService;
        }


    public abstract class MeshLocalPortal : MeshPortal{
        /// <summary>
        /// File name for local access to the mesh store.
        /// </summary>
        protected string Store = "mesh.jlog";

        /// <summary>
        /// File name for local access to the portal store.
        /// </summary>
        protected string Portal = "portal.jlog";

        /// <summary>
        /// The service name (default to prismproof.org)
        /// </summary>
        protected string ServiceName = "prismproof.org";

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public PublicMeshServiceHost MeshServiceHost;
        }



    public class MeshPortalDirect: MeshLocalPortal {
        public MeshPortalDirect () {
            Init(Store, Portal);
            }

        public MeshPortalDirect(string Store, string Portal) {
            Init(Store, Portal);
            }


        void Init (string Store, string Portal) {
            MeshServiceHost = new PublicMeshServiceHost(ServiceName, Store, Portal);
            }

        public override MeshService GetService(string service, string Account) {
            var Session = new DirectSession(null);
            MeshService = new MeshServiceSession(MeshServiceHost, Session);
            return MeshService;
            }

        }

    public class MeshPortalLocal : MeshLocalPortal {
        public MeshPortalLocal() {
            MeshServiceHost = new PublicMeshServiceHost(ServiceName, Store, Portal);
            }

        public override MeshService GetService(string Service, string Account) {
            var Session = new LocalRemoteSession(MeshServiceHost, ServiceName, Account);
            MeshService = new MeshServiceClient(Session);
            return MeshService;
            }

        }

    public class MeshPortalRemote : MeshPortal {

        public override MeshService GetService(string Service, string Account) {
            var Session = new WebRemoteSession(ProtocolID, Service, Account);
            MeshService = new MeshServiceClient(Session);
            return MeshService;
            }
        }

    }
