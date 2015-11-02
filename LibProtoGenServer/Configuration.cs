using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;

// Store cryptographic keys and tickets

// Windows Platform

// Configuration file locations are stored as follows
//       HKEY_LOCAL_MACHINE\SOFTWARE\Comodo\Omnibroker
//          \Connect      Connection Server
//          \Query        Query Server
//
//       HKEY_CURRENT_USER\SOFTWARE\Comodo\Omnibroker
//          \Client       Client

// UNIX Platform
//       \etc\connect.conf
//       \etc\query.conf
//       ~\.trustprofile


namespace Goedel.Protocol {

    public partial class _Choice {
        public virtual void Complete () {
            }

        public virtual void CompleteChildren () {
            }

        }


    public class Config {
        string Path;
        public Configure Configure;


        public Config() {
            Configure = new Configure();
            }

        public Config(string PathIn) {
            Read(PathIn);
            }

        public void Read(string PathIn) {
            Path = PathIn;

            // Set up the parser
            Configure = new Configure();

            using (Stream infile =
                        new FileStream(Path, FileMode.Open, FileAccess.Read)) {
                // Create a new lexer
                Lexer Lexer = new Lexer(Path);
                // Call the lexer using the parser as the delegate
                Lexer.Process(infile, Configure);

                Configure.CompleteChildren ();
                }

            // Put the fixup here ???

            }

        public void Write() {
            Write(Path);
            }

        public void Write(string PathIn) {
            Configure.Serialize(Console.Out);

            using (Stream outfile = new FileStream(PathIn, FileMode.OpenOrCreate, FileAccess.Write)) {
                using (TextWriter writer = new StreamWriter(outfile)) {
                    Configure.Serialize(writer);
                    }
                }

            }

        public Cluster GetCluster(string handle) {
            foreach (_Choice Choice in Configure.Top) {
                if (Choice._Tag() == ConfigureType.Cluster) {
                    var Entry = (Cluster)Choice;

                    if (handle == null | (Entry.Id.ToString() == handle)) {
                        Entry.Complete ();
                        
                        return Entry;
                        }
                    }
                }
            throw new Exception("Handle not found");
            }


        }

    public partial class Interface {
        Cluster Cluster;
        bool _Completed = false;
        public string Prefix ;

        public int Port = 0;
        public string Domain = "localhost";
        public string Transport = "HTTP";

        public override void Complete() {
            if (_Completed) return; _Completed = true;

            if (ClusterID != null) {
                Cluster = (Cluster) ClusterID.Id.Definition;
                Cluster.Interfaces.Add (this);
                }

            if (Is._Tag() == ConfigureType.HTTP) {
                var HTTP = (HTTP) Is;
                string PortString = (HTTP.Port == 80) ? "" : ":" + HTTP.Port.ToString();
                Prefix = "http://" + HTTP.Domain + PortString + "/";
                Port = HTTP.Port;
                Domain =  HTTP.Domain;
                Transport = "HTTP";
                }
            if (Is._Tag() == ConfigureType.HTTPS) {
                var HTTPS = (HTTPS) Is;
                string PortString = (HTTPS.Port == 443) ? "" : ":" + HTTPS.Port.ToString();
                Prefix = "https://" + HTTPS.Domain + PortString + "/";
                Port = HTTPS.Port;
                Domain =  HTTPS.Domain;
                Transport = "HTTPS";
                }
            if (Is._Tag() == ConfigureType.UDP) {
                var UDP = (UDP) Is;
                string PortString = (UDP.Port == 443) ? "" : ":" + UDP.Port.ToString();
                Prefix = "https://" + UDP.Domain + PortString + "/";
                Port = UDP.Port;
                Domain =  UDP.Domain;
                Transport = "UDP";
                }
            }
        }

    public partial class On {
        public Interface   Interface;

        bool _Completed = false;
        public override void Complete() {
            if (_Completed) return; _Completed = true;

            Interface = (Interface) Id.Definition;
            }
        }

    public partial class Service {
        Cluster Cluster;

        public AuthenticatedServer ServerInstance;
        public List<ServiceInstance> ServiceInstances = new List<ServiceInstance> ();
        
        bool _Completed = false;
        public override void Complete()  {
            if (_Completed) return; _Completed = true;

            if (ClusterID != null) {
                Cluster = (Cluster)ClusterID.Id.Definition;
                Cluster.Services.Add (this);
                }

            foreach (var On in Interfaces) {
                On.Complete ();
                }

            }



        public AuthenticatedServer StartService(ServerCluster ServerCluster) {
            ServerInstance = ServerCluster.StartService (this);
            return ServerInstance;
            }
        }

    public partial class Configure {



        public void CompleteChildren () {
            foreach (var Entry in Top) {
                Entry.Complete ();
                Entry.CompleteChildren ();
                }
            }

        }

    partial class Cluster {
        public List <Interface>        Interfaces = new List<Interface> ();
        public List <Service>          Services = new List<Service> ();
        //public List<ServerIdentifier> ServerIdentifiers = new List<ServerIdentifier>();


        bool Filled = false;

        public override void Complete () {
            if (Filled) return;
            Filled = true;

            }

        //public ServerIdentifier GetService(string Handle) {
        //    foreach (var ServerIdentifier in ServerIdentifiers) {
        //        if (ServerIdentifier.Handle == Handle) {
        //            return ServerIdentifier;
        //            }
        //        }
        //    return null;
        //    }

        }
    }
