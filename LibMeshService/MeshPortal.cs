using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Mesh;

namespace Goedel.Mesh {
    public abstract class MeshPortal {
        protected string Store = "mesh.jlog";
        protected string Portal = "portal.jlog";
        protected string ServiceName = "prismproof.org";

        public PublicMeshServiceHost MeshServiceHost;
        public MeshService MeshService;
        //public JPCSession Session;

        public virtual MeshService GetService(string Service) {
            return GetService(Service, null);
            }
        public abstract MeshService GetService(string Service, string Account);


        public static MeshPortal Default;


        }


    public class MeshPortalDirect: MeshPortal {
        public MeshPortalDirect () {
            MeshServiceHost = new PublicMeshServiceHost(ServiceName, Store, Portal);
            }

        public MeshPortalDirect(string Store, string Portal) {
            MeshServiceHost = new PublicMeshServiceHost(ServiceName, Store, Portal);
            }

        public override MeshService GetService(string service, string Account) {
            var Session = new DirectSession(null);
            MeshService = new MeshServiceSession(MeshServiceHost, Session);
            return MeshService;
            }

        }

    public class MeshPortalLocal : MeshPortal {
        JHost JHost;
        public MeshPortalLocal() {
            MeshServiceHost = new PublicMeshServiceHost(ServiceName, Store, Portal);
            JHost = new JHost();
            var HostService = JHost.AddService(MeshServiceHost);
            var HostPort = JHost.AddHTTP(ServiceName);
            HostService.AddPort(HostPort);
            }

        public override MeshService GetService(string Service, string Account) {
            var Session = new RemoteSession(ServiceName, Account);
            MeshService = new MeshServiceClient(Session);
            return MeshService;
            }

        }

    public class MeshPortalRemote : MeshPortal {

        public override MeshService GetService(string Service, string Account) {
            var Session = new RemoteSession(Service, Account);
            MeshService = new MeshServiceClient(Session);
            return MeshService;
            }
        }

    }
