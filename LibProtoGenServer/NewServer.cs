using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Goedel.Protocol;



namespace Goedel.Protocol {

    public class HostServerConnection {
        public List<string>   Services;    // The service type "SxSConnect", "OmniQuery", "SXSConfirm", "PrivateDNS"
        public string   Transport;  // "HTTP", "UDP" or "DNS"
        public string   Domain;
        public int      Port;
        public string   Address;
        public int      Priority;
        public int      Weight;
        public byte []  Ticket;
        public Cryptography.Key    MasterSeed;


        //public HostServerConnection(Protocol Protocol) {


        //    }
        }


    // All messages are descended from this class
    public partial class TransactionStatus {
        public int Status;
        public string Description;

        public static TransactionStatus Success =
            new TransactionStatus(200, "Success");
        public static TransactionStatus UnauthorizedError =
            new TransactionStatus(401, "Unauthorized Error");


        public static TransactionStatus Authenticate =
            new TransactionStatus(281, "Pin code required");
        public static TransactionStatus TransactionIncomplete =
            new TransactionStatus(282, "Transaction Incomplete");


        public static TransactionStatus InternalServerError =
            new TransactionStatus(500, "Internal Server Error");
        public static TransactionStatus NotImplementedError =
            new TransactionStatus(501, "Not Implemented");

        public TransactionStatus(int Status, string Description) {
            this.Status = Status;
            this.Description = Description;
            }


        }
    
    //public abstract partial class JSONObject {
    //    //public virtual bool Authenticate() {
    //    //    return true;
    //    //    }

    //    //public virtual TransactionStatus Dispatch(AuthenticatedServer AuthenticatedServer,
    //    //        TicketData TicketData, string Payload, out JSONObject JSONObject) {
    //    //    throw new SystemException ("Dispatch method not implemented yet");
    //    //    }


    //    }


    //public class ConnectionServerContext : AuthenticatedServerContext {

    //    public byte[] PINSeed = Cryptography.Nonce();

    //    //public List<HostServerConnection> HostServers =
    //    //    new List<HostServerConnection>();

    //    //public ConnectionServerContext() {
    //    //    InitServerContext(Cryptography.Authentication.HS256);
    //    //    }

    //    //public ConnectionServerContext(Service Service) {
    //    //    InitServerContext(Cryptography.Authentication.HS256);
    //    //    }

    //    // Only a connection server issues PIN challenges

    //    public string GetPIN(string Account, string Domain) {
    //        string Text = Account + "@" + Domain;

    //        return Cryptography.MakePin(Text, PINSeed, 10);
    //        }

    //    //public Account GetAccount(string Domain, string Account) {
    //    //    return null;
    //    //    }

    //    public Cryptographic GetCryptographic(TicketData Ticket, String Protocol) {
    //        return GetCryptographic(Ticket, Protocol, Ticket.GetTicket(MasterSeed));
    //        }

    //    public Cryptographic GetCryptographic(TicketData TicketData, String Protocol, byte[] Ticket) {
    //        Cryptographic Result = new Cryptographic();

    //        // Fill in the Response structures
    //        Result.Authentication = Cryptography.AuthenticationCode(TicketData.Authentication);
    //        Result.Encryption = Cryptography.EncryptionCode(TicketData.Encryption);
    //        Result.Secret = TicketData.MasterKey.KeyData;
    //        Result.Protocol = Protocol;
    //        Result.Ticket = Ticket;

    //        return Result;
    //        }


    //    }


    //// Server Context information that is shared across all connections
    //public abstract partial class ServerContext {
    //    }

    //public abstract partial class AuthenticatedServerContext : ServerContext {
    //    public HostServerConnection     HostServerConnection;

    //    public string Domain;
    //    public Cryptography.Authentication Authentication;

    //    public Cryptography.Key MasterSeed;

    //    public TicketData GetTicketData(byte [] Ticket) {
    //        return TicketData.MakeTicket (Ticket, MasterSeed);
    //        }

    //    public bool VerifyTicket(byte[] Ticket) {
    //        return TicketData.VerifyTicket (Ticket, MasterSeed);
    //        }


    //    public Cryptography.Encryption GetEncryption (List<string> Algs) {
    //        return Cryptography.Encryption.A128CBC;
    //        }

    //    public Cryptography.Authentication GetAuthentication (List<string> Algs) {
    //        if (Algs.Count == 0) {
    //            return Cryptography.Authentication.HS256;
    //            }
    //        else {
    //            // Well we could support other algorithms but we don't
    //            return Cryptography.Authentication.HS256;
    //            //return Algs [0];
    //            }
    //        }

    //    public AuthenticatedServerContext() {
    //        InitServerContext (Cryptography.Authentication.HS256T128);
    //        }

    //    protected void InitServerContext(Cryptography.Authentication AuthenticationIn) {
    //        Authentication = AuthenticationIn;
    //        MasterSeed = new Cryptography.Key (Authentication);
    //        }
        
    //    }    

    public delegate BoundResponse DispatchBoundResponse (
                AuthenticatedServer Server, BoundRequest Request);
    public delegate AuthenticatedServer ServerFactory (Service Service) ;

    public class ServerIdentifier {
        public string Handle;
        public ServiceInterface[] ServiceInterfaces;
        public ServerFactory ServerFactory;
        public ServerCluster ServerCluster;
        public Dispatch Dispatch = null;

        public ServerIdentifier(
                string Handle,
                ServiceInterface[] ServiceInterfaces,
                ServerFactory ServerFactory
                ) {
            this.Handle = Handle;
            this.ServiceInterfaces = ServiceInterfaces;
            this.ServerFactory = ServerFactory;
            }

        public ServerIdentifier(
               string Handle,
               ServiceInterface[] ServiceInterfaces,
               ServerFactory ServerFactory,
               Dispatch Dispatch
               ) : this (Handle, ServiceInterfaces, ServerFactory) {
            this.Dispatch = Dispatch;
            }
        }


    public class ServiceInterface {
        string _WellKnown;
        string[] Transport;
        string[] Encoding;
        public DispatchBoundResponse Dispatch;     // Delegate to dispatch on

        public Server Server;

        public string WellKnown {
            get { return _WellKnown; }
            set { _WellKnown = value; }
            }

        readonly string[] DefaultTransport = {"HTTP"};
        readonly string[] DefaultEncoding = {"application/JSON"};

        public ServiceInterface(string Prefix) {
            this.WellKnown = Prefix;
            this.Dispatch = null;
            this.Transport = DefaultTransport;
            this.Encoding = DefaultEncoding;
            }

        public ServiceInterface(string Prefix, DispatchBoundResponse Dispatch) {
            this.WellKnown = Prefix;
            this.Dispatch = Dispatch;
            this.Transport = DefaultTransport;
            this.Encoding = DefaultEncoding;
            }

        public ServiceInterface(string Prefix, DispatchBoundResponse Dispatch,
                    string[] Transport, string[] Encoding) {
            this.WellKnown = Prefix;
            this.Dispatch = Dispatch;
            this.Transport = Transport;
            this.Encoding = Encoding;
            }
        }

    public delegate void DeserializeJSON (string Payload, out JSONObject Out);

    public abstract class Dispatch {


        // These are set as needed by the classes that inherit from Dispatch
        public bool InterfaceWebService = true;
        public bool InterfaceUDP = false;
        public AuthenticatedServer Server;
        public abstract string Handle {
            get;
            }

        public Dispatch(AuthenticatedServer Server) {
            this.Server = Server;
            }
        //public abstract JSONObject DeserializeJSON(string Payload);

        // The is the method that will be called with the raw data to 
        // perform a dispatch on

        public abstract TransactionStatus DispatchRAW (string Payload,
                TicketData TicketData, out string ResponseOut);


        public virtual BoundResponse BoundDispatch (BoundRequest BoundRequest) {
            string Response = null;
            TicketData TicketData = null;

            //try {
                if (BoundRequest.Ticket != null) {
                    TicketData = Server.GetTicketData (BoundRequest.Ticket);
                    // TicketData set to NULL if not valid.
                    }

                var TransactionStatus = DispatchRAW (BoundRequest.Payload, TicketData, out Response);

                if (Response == null) {
                    return BoundResponse.ErrorUnknown;
                    }

                BoundResponse BoundResponseOut;
                if (TicketData == null) {
                    BoundResponseOut = new BoundResponse(Response);
                    }
                else {
                    BoundResponseOut = new BoundResponse(Response, 
                        BoundRequest.Ticket, TicketData.Authentication, TicketData.MasterKey);
                    }

                BoundResponseOut.Status = TransactionStatus.Status;
                BoundResponseOut.StatusDescription = TransactionStatus.Description;
                return BoundResponseOut;
                //}
            //catch {
            //    return BoundResponse.ErrorUnknown;
            //    }
            }


        }

    public abstract partial class AuthenticatedServer : Server {
        
        // The new identification scheme
        //public abstract string Handle { get; }

        public abstract string Handle {
            get;
            }

        public abstract List<string> Interfaces {
            get;
            }

        protected List<Dispatch> _Dispatchers = new List<Dispatch> ();
        public virtual List<Dispatch> Dispatchers {get {return _Dispatchers;}}
        
        //public abstract static AuthenticatedServer Factory(Service Service) {
        //    return null;
        //    }

        // Callback that will be called when another service on the same
        // host is activated.
        public virtual void RegisterService (AuthenticatedServer AuthenticatedServer) {
            }
        public virtual void DeRegisterService (AuthenticatedServer AuthenticatedServer) {
            }

        //// Get rid of this soon
        //public abstract ServerIdentifier ServerIdentifierProperty {get;}



        public byte[] PINSeed = Cryptography.Nonce();
        public ServerCluster ServerCluster = null;
        
        public Cryptography.Encryption EncryptionAlgorithm = 
            Cryptography.Encryption.A128CBC;
        public Cryptography.Authentication AuthenticationAlgorithm =
            Cryptography.Authentication.HS256T128;


        public Cryptography.Key MasterSeed;
        public string Seed;
        
        public Cryptography.Encryption GetEncryption (List<string> Algs) {
            return Cryptography.Encryption.A128CBC;
            }

        public Cryptography.Authentication GetAuthentication (List<string> Algs) {
            return Cryptography.Authentication.HS256;
            }        
        
        public string GetPIN(string Account, string Domain) {
            string Text = Account + "@" + Domain;

            return Cryptography.MakePin(Text, PINSeed, 10);
            }


        public AuthenticatedServer(Goedel.Protocol.Service Service, bool Flag) :
            this (Service) {
            }

        public AuthenticatedServer(Goedel.Protocol.Service Service) {

            if (Service.Secrets.Count > 0) {
                Seed = Service.Secrets[Service.Secrets.Count-1].Data;
                byte[] Data = BaseConvert.FromBase64urlString (Seed);
                MasterSeed = new Cryptography.Key (Data, AuthenticationAlgorithm, EncryptionAlgorithm);
                }
            else {
                Seed = null;
                }

            Seed = Service.Secrets[0].Data;

            }

        public virtual void Publish (Goedel.Protocol.Service Service) {
            }

        public virtual void Publish (AuthenticatedServer AuthenticatedServer) {
            }

        public byte[] GetTicketData(TicketData TicketData) {
            MasterSeed.Dump ("PackTicket::");
            return TicketData.GetTicket (MasterSeed);
            }           

        public TicketData GetTicketData(byte [] Ticket) {
            MasterSeed.Dump ("UnpackTicket::");
            return TicketData.MakeTicket (Ticket, MasterSeed);
            }     

        //public AuthenticatedServerContext ServerContext = null;

        public override BoundResponse Request(BoundRequest BoundRequest) {
            return null;
            }



        }
    
   
    }
