using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Goedel.DNS {

    /// <summary></summary>
    public partial struct DNSOption {
        /// <summary></summary>
        public ushort          Code;
        /// <summary></summary>
        public byte []         Data;
        }

    /// <summary></summary>
    public enum DNSGatewayType : byte  {
        /// <summary></summary>
        NULL = 0,
        /// <summary></summary>
        IPv4 = 1,
        /// <summary></summary>
        IPv6 = 2,
        /// <summary></summary>
        DomainName = 3,
        }

    /// <summary></summary>
    public partial struct DNSGateway {
        /// <summary></summary>
        public DNSGatewayType _Type;
        /// <summary></summary>
        public DNSGatewayType Type {
            get { return _Type; }
            set { _Type = value; }
            }
        
        IPAddress               _IPAddress;
        string                  _DomainName;

        /// <summary></summary>
        public IPAddress        IPAddress {
            set {_DomainName = null; _IPAddress = value;
                _Type = DNSGatewayType.IPv4;}
            get {return _IPAddress;}
            
            }
        /// <summary></summary>
        public string           DomainName {
            set {_DomainName = value; _IPAddress = null; _Type = 
                DNSGatewayType.DomainName;}
            get {return _DomainName;}
            }

        }

    /// <summary></summary>
    public abstract partial class DNSRecord {
        /// <summary></summary>
        public Domain           Domain;
        /// <summary></summary>
        public DNSTypeCode      RType;
        /// <summary></summary>
        public DNSClass         RClass;
        /// <summary></summary>
        public uint             TTL;
        /// <summary></summary>
        public DNSBufferIndex   RData;
        /// <summary></summary>
        public int              Start;


        /// <summary></summary>
        public DNSRecord() {
            }

        //public DNSRecord (DNSBufferIndex   IndexIn) {
        //    Index = IndexIn;
        //    Decode ();
        //    }


        // Reader method, reads buffer and returns the relevant record...


        //public void Encode () {
        //    Index.WriteName (Domain.Name);
        //    Index.WriteInt16 (RType);
        //    Index.WriteInt16 (RClass);
        //    Index.WriteInt32 (TTL);               
        //    }

        //public void Decode () {
        //    Index.Dump ();

        //    Domain.Name = Index.ReadName ();
        //    RType = (DNSTypeCode)Index.ReadInt16 ();
        //    RClass = (DNSClass)Index.ReadInt16 ();
        //    TTL = Index.ReadInt32 ();
        //    Index.ReadL16Data (out RData);
        //    }




        /// <summary></summary>
        public void Write () {
            //Encode ();
            }

        // Convert to canonical form
        /// <summary></summary>
        public virtual string Canonical () {
            return null;
            }

        // Debugging shortcut
        /// <summary></summary>
        public void Dump() {
            Console.WriteLine (Canonical ());
            }

        //// Convert from canonical form
        //public virtual void Parse(string Canonical) {
        //    }

        // Convert to byte form
        /// <summary></summary>
        public virtual void Encode(DNSBufferIndex Index) {
            }

        //// Convert from byte form
        //public virtual void Decode (DNSBuffer DNSBuffer, int Length) {
        //    }

        }


    /// <summary></summary>
    public enum DNSFlags : ushort {
        /// <summary></summary>
        QR = 0x8000,
        /// <summary></summary>
        OPCODE_Mask = 0x7800,
        /// <summary></summary>
        OPCODE_QUERY = 0x0000,
        /// <summary></summary>
        OPCODE_IQUERY = 0x8000,
        /// <summary></summary>
        OPCODE_STATUS = 0x1000,
        /// <summary></summary>
        AA = 0x0400,
        /// <summary></summary>
        TC = 0x0200,
        /// <summary></summary>
        RD = 0x0100,
        /// <summary></summary>
        RA = 0x0080,
        /// <summary></summary>
        Z_Mask = 0x0070,
        /// <summary></summary>
        RCODE_Mask = 0xF,
        /// <summary></summary>
        RCODE_Success = 0,
        /// <summary></summary>
        RCODE_FormatError = 1,
        /// <summary></summary>
        RCODE_ServerFailure = 2,
        /// <summary></summary>
        RCODE_NameError = 3,
        /// <summary></summary>
        RCODE_NotImplemented = 4,
        /// <summary></summary>
        RCODE_Refused = 5
        };

    /// <summary></summary>
    public enum DNSClass {
        //0            //0x0000         Reserved                        [RFC6195]
        /// <summary></summary>
        IN = 1,        //0x0001         Internet (IN)                   [RFC1035]
        //2            //0x0002         Unassigned                      
        /// <summary></summary>
        CH = 3,        //0x0003         Chaos (CH)                      [Moon1981]
        /// <summary></summary>
        HS = 4,        //0x0004         Hesiod (HS)                     [Dyer1987]
        /// <summary></summary>
        //5-253        0x0005-0x00FD    Unassigned                    
        /// <summary></summary>
        NONE = 254,    //0x00FD         QCLASS NONE                     [RFC2136]
        /// <summary></summary>
        ANY = 255      //0x00FF         QCLASS * (ANY)                  [RFC1035]
        //256-65279    0x0100-0xFEFF    Unassigned                      
        //65280-65534  0xFF00-0xFFFE    Reserved for Private Use        [RFC6195]
        //65535        0xFFFF           Reserved                        [RFC6195] 
        }

    /// <summary></summary>
    public class Domain {
        /// <summary></summary>
        public string Name; // Unicode representation of name
        /// <summary></summary>
        public byte[] Data; // DNSClient represenation (punycode)


        /// <summary></summary>
        public Domain(string Name) {
            this.Name = Name;
            }
        }



    /// <summary></summary>
    public class DNSMessage {

        /// <summary></summary>
        public byte[] Data {
            get {
                DNSBufferIndex Index = new DNSBufferIndex();
                Encode (Index);
                return Index.Bytes;
                }
            }

        /// <summary></summary>
        public DNSBuffer Buffer {
            get {
                DNSBufferIndex Index = new DNSBufferIndex();
                Encode (Index);
                return Index.Buffer;
                }
            }


        /// <summary></summary>
        public UInt16           ID;
        /// <summary></summary>
        public DNSFlags         Flags;

        /// <summary></summary>
        public DNSFlags OPCODE { get { return (Flags & DNSFlags.OPCODE_Mask); } }
        /// <summary></summary>
        public DNSFlags RCODE { get { return (Flags & DNSFlags.RCODE_Mask); } }
        /// <summary></summary>
        public bool QR { get { return ((Flags & DNSFlags.QR) == DNSFlags.QR); } }
        /// <summary></summary>
        public bool AA { get { return ((Flags & DNSFlags.AA) == DNSFlags.AA); } }
        /// <summary></summary>
        public bool TC { get { return ((Flags & DNSFlags.TC) == DNSFlags.TC); } }
        /// <summary></summary>
        public bool RD { get { return ((Flags & DNSFlags.RD) == DNSFlags.RD); } }
        /// <summary></summary>
        public bool RA { get { return ((Flags & DNSFlags.RA) == DNSFlags.RA); } }

        /// <summary></summary>
        public DNSQuery         Query;
        /// <summary></summary>
        public DNSRecord []     Answers = { };
        /// <summary></summary>
        public DNSRecord []     Authorities = { };
        /// <summary></summary>
        public DNSRecord []     Additional = { };


        int QueryCount, AnswerCount, AuthorityCount, AdditionalCount;

        /// <summary></summary>
        public void Encode (DNSBufferIndex Index) {
            Index.WriteInt16 (ID);
            Index.WriteInt16 (Flags);
            Index.WriteInt16 ((Query == null) ? 0 : 1);
            Index.WriteInt16 (Answers.Length);
            Index.WriteInt16 (Authorities.Length);
            Index.WriteInt16 (Additional.Length);

            if (Query != null) {
                Query.Encode (Index);
                }
            foreach (DNSRecord Record in Answers) {
                Record.Encode (Index);
                }
            foreach (DNSRecord Record in Authorities) {
                Record.Encode (Index);
                }
            foreach (DNSRecord Record in Additional) {
                Record.Encode (Index);
                }
            }

        /// <summary></summary>
        public void Decode (DNSBufferIndex Index) {
            
            Index.ReadInt16 (out ID);
            Index.ReadInt16 (out Flags);
            Index.ReadInt16 (out QueryCount);
            Index.ReadInt16 (out AnswerCount);
            Index.ReadInt16 (out AuthorityCount);
            Index.ReadInt16 (out AdditionalCount);

            Console.WriteLine ("ID {0} Flags {1:x}  Queries {2} Answers {3} Authority {4} Additional {5}",
                    ID, Flags, QueryCount, AnswerCount, AuthorityCount, AdditionalCount);

            if (QueryCount == 1) {
                Console.WriteLine ("Form Query");
                Query = DNSQuery.Decode (Index);
                }

            Answers = new DNSRecord [AnswerCount];
            for (int i = 0; i < AnswerCount; i++) {
                Answers[i] = DNSRecord.Decode(Index);
                }
            Authorities = new DNSRecord [AuthorityCount];
            for (int i = 0; i < AuthorityCount; i++) {
                Authorities[i] = DNSRecord.Decode(Index);
                }
            Additional = new DNSRecord [AdditionalCount];
            for (int i = 0; i < AdditionalCount; i++) {
                Additional[i] = DNSRecord.Decode(Index);
                }
            }



        // Parse the data in the buffer BufferIn 
        /// <summary></summary>
        public DNSMessage (byte [] data) {
            DNSBufferIndex Index = new DNSBufferIndex (data);

            Decode (Index);
            }

        // Create Empty Message buffer (do not parse, done in sub);
        /// <summary></summary>
        public DNSMessage () {
            //Index = ( new DNSBufferIndex () );
            }

        /// <summary></summary>
        public virtual string TypeTag { get { return null; } }

        static int Display = 16;

        /// <summary></summary>
        /// <param name="Data"></param>
        protected void Dump(byte[] Data) {
            for (int i = 0; i < Data.Length; ) {
                for (int j = 0; (j < Display) ; j++) {
                if (i + j < Data.Length) {
                    Console.Write("{0:x2} ", Data[i + j]);
                    }
                else {
                    Console.Write ("   ");
                    }
                    }
                for (int j = 0; (j < Display) && (i+j < Data.Length); j++) {

                    if (Data[i+j] >= 32) {
                        Console.Write("{0:s}", (char)Data[i+j]);
                        }
                    else {
                        Console.Write(".");
                        }
                    }
                i += Display;
                Console.WriteLine ();
                }
            }

        /// <summary></summary>
        public void Dump () {

            Console.WriteLine ("DNS {0}", TypeTag); 
            Dump (Data);
            
            Console.WriteLine ("ID {0} / Flags {1}", ID, Flags);
            if (Query != null) {
                Console.WriteLine ("Query");
                Query.Dump ();
                }
            Console.WriteLine ("Answers");
            foreach (DNSRecord Record in Answers) {
                Record.Dump ();
                }
            Console.WriteLine ("Authorities");
            foreach (DNSRecord Record in Authorities) {
                Record.Dump ();
                }
            Console.WriteLine ("Additional");
            foreach (DNSRecord Record in Additional) {
                Record.Dump ();
                }
            }



        }

    //public class DNSQueryMessage : DNSMessage {


    //    public DNSQueryMessage (String Domain, DNSTypeCode QTypeIn, DNSClass QClassIn) 
    //            : base () {
    //        Query = new DNSQuery (Index, Domain, QTypeIn, QClassIn);
    //        }

    //    public DNSQueryMessage (String Domain, DNSTypeCode QTypeIn) :
    //        this (Domain, QTypeIn, DNSClass.IN) { }
    //    }





    //public class DNSMessage {
    //    public ushort ID;
    //    public DNSFlags Flags;
    //    public DNSFlags OPCODE { get { return (Flags & DNSFlags.OPCODE_Mask); } }
    //    public DNSFlags RCODE { get { return (Flags & DNSFlags.RCODE_Mask); } }
    //    public bool QR { get { return ((Flags & DNSFlags.QR) == DNSFlags.QR); } }
    //    public bool AA { get { return ((Flags & DNSFlags.AA) == DNSFlags.AA); } }
    //    public bool TC { get { return ((Flags & DNSFlags.TC) == DNSFlags.TC); } }
    //    public bool RD { get { return ((Flags & DNSFlags.RD) == DNSFlags.RD); } }
    //    public bool RA { get { return ((Flags & DNSFlags.RA) == DNSFlags.RA); } }
    //    }


    //The DNSClient protocol actually supports making multiple queries in one request but this
    //does not actually work in the field and should probably be deprecated.

    /// <summary></summary>
    public class DNSRequest : DNSMessage {
        public override string TypeTag { get { return "Request"; } }

        //public Domain QName;
        //public Int16 QType;
        //public DNSClass QClass;

        //// Here add in flags to turn on recursive resolution, DNSSEC validation, etc.


        /// <summary></summary>
        public DNSRequest(string Domain, string QType){
            if (QType == null) {
                Query = new DNSQuery (Domain, DNSTypeCode.ALL);
                }
            else {
                Query = new DNSQuery(Domain, DNS.TypeCode(QType) );
                }
            Flags = DNSFlags.RD | DNSFlags.OPCODE_QUERY;
            }

        /// <summary></summary>
        public DNSRequest(string Domain, DNSTypeCode QCode) {
            Query = new DNSQuery (Domain,  QCode);
            }

        }

    /// <summary></summary>
    public class DNSResponse : DNSMessage {

        /// <summary></summary>
        public override string TypeTag { get { return "Response"; } }
        //public List<DNSRR> Answer;
        //public List<DNSRR> Authoritative;
        //public List<DNSRR> Additional;

        /// <summary></summary>
        /// <param name="Data"></param>
        public DNSResponse(byte[] Data) {
            // here do the decode thing.
            //Dump (Data);
            
            DNSBufferIndex Index = new DNSBufferIndex (Data);

            Decode (Index);

            }
        }



    /// <summary></summary>
    public class DNSQuery {
        /// <summary></summary>
        public String           QName;
        /// <summary></summary>
        public DNSTypeCode      QType;
        /// <summary></summary>
        public DNSClass         QClass;

        /// <summary></summary>
        /// <param name="Index"></param>
        public void Encode (DNSBufferIndex   Index) {
            Index.WriteName (QName);
            Index.WriteInt16 (QType);
            Index.WriteInt16 (QClass);
            //Index.Dump ();
            }

        /// <summary></summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static DNSQuery Decode (DNSBufferIndex   Index) {
            String  QName = Index.ReadName ();
            DNSTypeCode QType = (DNSTypeCode)Index.ReadInt16 ();
            DNSClass QClass = (DNSClass)Index.ReadInt16 ();

            Console.WriteLine ("Query Name={0:s} Type={1:d} Class={1:d}",
                    QName, QType, QClass);
            return new DNSQuery (QName, QType, QClass);
            }

        // Constructors
        /// <summary></summary>
        /// <param name="Domain"></param>
        /// <param name="QTypeIn"></param>
        /// <param name="QClassIn"></param>
        public DNSQuery (String Domain, DNSTypeCode QTypeIn, DNSClass QClassIn) {
            QName = Domain;
            QType = QTypeIn;
            QClass = QClassIn;
            }

        /// <summary></summary>
        /// <param name="Domain"></param>
        /// <param name="QTypeIn"></param>
        public DNSQuery (String Domain, DNSTypeCode QTypeIn) :
            this (Domain, QTypeIn, DNSClass.IN) {}

        /// <summary></summary>
        public void Dump () {
            Console.WriteLine ("Query {0:s} {1:d} {2:d}",
                    QName,  QType,QClass);
            }

        }










    ///// <summary></summary>
    //public class DNSEx {



    //    // Old style asynch interface, start request with BeginQuery, passing completion 
    //    // routine that passes back 

    //    [HostProtectionAttribute(SecurityAction.LinkDemand, ExternalThreading = true)]
    //    public IAsyncResult BeginQuery (DNSRequest Request, 	        
    //                AsyncCallback requestCallback,
	   //             Object state) {
    //        return null;
    //        }

    //    public DNSResponse EndQuery(IAsyncResult asyncResult) {
    //        return null;
    //        }

    //    [HostProtectionAttribute(SecurityAction.LinkDemand, Synchronization = true, 
    //        ExternalThreading = true)]

    //    public Task<DNSResponse> QueryAsync(DNSRequest Request) {
    //        return null;
    //        }
    //    }
    }
