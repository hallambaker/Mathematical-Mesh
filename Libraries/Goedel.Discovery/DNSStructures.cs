#region // Copyright
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
using System;
using System.Diagnostics;
using System.Net;

namespace Goedel.Discovery {

    /// <summary>Describe DNS Option</summary>
    public partial struct DNSOption {
        /// <summary>Code</summary>
        public ushort Code;
        /// <summary>Data</summary>
        public byte[] Data;
        }

    /// <summary>The type of gateway</summary>
    public enum DNSGatewayType : byte {
        /// <summary>Unknown</summary>
        NULL = 0,
        /// <summary>IPv4 Address</summary>
        IPv4 = 1,
        /// <summary>IPv6 Address</summary>
        IPv6 = 2,
        /// <summary>Domain name</summary>
        DomainName = 3,
        }

    /// <summary>DNS Gateway</summary>
    public partial struct DNSGateway {
        /// <summary>The type of gateway</summary>
        public DNSGatewayType Type { get; set; }

        IPAddress _IPAddress;
        string _DomainName;

        /// <summary>The IP address of the gateway</summary>
        public IPAddress IPAddress {
            set {
                _DomainName = null; _IPAddress = value;
                Type = DNSGatewayType.IPv4;
                }
            get => _IPAddress;

            }
        /// <summary>The DNS address of the gateway</summary>
        public string DomainName {
            set {
                _DomainName = value; _IPAddress = null; Type =
               DNSGatewayType.DomainName;
                }
            get => _DomainName;
            }

        }

    /// <summary>Base class for DNS records</summary>
    public abstract partial class DNSRecord {
        /// <summary>The domain name</summary>
        public Domain Domain;
        /// <summary>Record type code</summary>
        public DNSTypeCode RType;
        /// <summary>Record class</summary>
        public DNSClass RClass;
        /// <summary>Time to live</summary>
        public uint TTL;
        /// <summary>Record data</summary>
        public DNSBufferIndex RData;
        /// <summary>Start index</summary>
        public int Start;


        /// <summary>Default constructor</summary>
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




        /// <summary>Write value</summary>
        public static void Write() {
            //Encode ();
            }

        /// <summary>Convert to canonical form</summary>
        /// <returns>Canonical form of record data contents</returns>
        public abstract string Canonical();

        //// Debugging shortcut
        ///// <summary></summary>
        //public void Dump() {
        //    //Console.WriteLine (Canonical ());
        //    }

        //// Convert from canonical form
        //public virtual void Parse(string Canonical) {
        //    }

        /// <summary>Convert to wire form</summary>
        /// <param name="Index">Output buffer</param>
        public virtual void Encode(DNSBufferIndex Index) {
            }

        //// Convert from byte form
        //public virtual void Decode (DNSBuffer DNSBuffer, int Length) {
        //    }

        }


    /// <summary>DNS Flags</summary>
    public enum DNSFlags : ushort {
        /// <summary>QR</summary>
        QR = 0x8000,
        /// <summary>OP Codes</summary>
        OPCODE_Mask = 0x7800,
        /// <summary>Query</summary>
        OPCODE_QUERY = 0x0000,
        /// <summary>I Query</summary>
        OPCODE_IQUERY = 0x8000,
        /// <summary>Status </summary>
        OPCODE_STATUS = 0x1000,
        /// <summary>AA</summary>
        AA = 0x0400,
        /// <summary>TC</summary>
        TC = 0x0200,
        /// <summary>RD</summary>
        RD = 0x0100,
        /// <summary>RA</summary>
        RA = 0x0080,
        /// <summary>Z</summary>
        Z_Mask = 0x0070,
        /// <summary>Result code Flags</summary>
        RCODE_Mask = 0xF,
        /// <summary>Success</summary>
        RCODE_Success = 0,
        /// <summary>Format error</summary>
        RCODE_FormatError = 1,
        /// <summary>Failure at server</summary>
        RCODE_ServerFailure = 2,
        /// <summary>Name not understood</summary>
        RCODE_NameError = 3,
        /// <summary>Feature not implemented</summary>
        RCODE_NotImplemented = 4,
        /// <summary>Request refused.</summary>
        RCODE_Refused = 5
        };

    /// <summary>DNS Classes</summary>
    public enum DNSClass {
        //0            //0x0000         Reserved                        [RFC6195]
        /// <summary>Internet (IN)</summary>
        IN = 1,        //0x0001         Internet (IN)                   [RFC1035]
        //2            //0x0002         Unassigned                      
        /// <summary>Chaos (CH) </summary>
        CH = 3,        //0x0003         Chaos (CH)                      [Moon1981]
        /// <summary>Hesiod (HS</summary>
        HS = 4,        //0x0004         Hesiod (HS)                     [Dyer1987]

        //5-253        0x0005-0x00FD    Unassigned                    
        /// <summary>QCLASS NONE  </summary>
        NONE = 254,    //0x00FD         QCLASS NONE                     [RFC2136]
        /// <summary>QCLASS * (ANY) </summary>
        ANY = 255      //0x00FF         QCLASS * (ANY)                  [RFC1035]
        //256-65279    0x0100-0xFEFF    Unassigned                      
        //65280-65534  0xFF00-0xFFFE    Reserved for Private Use        [RFC6195]
        //65535        0xFFFF           Reserved                        [RFC6195] 
        }

    /// <summary>Domain name</summary>
    public class Domain {
        /// <summary>Unicode representation of name</summary>
        public string Name; // Unicode representation of name
        /// <summary>DNSClient represenation (punycode)</summary>
        public byte[] Data; // DNSClient represenation (punycode)


        /// <summary>Constructor from string</summary>
        /// <param name="Name">The DNS name in UNICODE format.</param>
        public Domain(string Name) => this.Name = Name;
        }



    /// <summary>DNS Message class</summary>
    public class DNSMessage {

        /// <summary>The message data</summary>
        public byte[] Data {
            get {
                DNSBufferIndex Index = new DNSBufferIndex();
                Encode(Index);
                return Index.Bytes;
                }
            }

        /// <summary>The message data buffer</summary>
        public DNSBuffer Buffer {
            get {
                DNSBufferIndex Index = new DNSBufferIndex();
                Encode(Index);
                return Index.Buffer;
                }
            }


        /// <summary>Message identifier code for matching requests and responses.</summary>
        public UInt16 ID;
        /// <summary>Flags</summary>
        public DNSFlags Flags;

        /// <summary>OPCode flags</summary>
        public DNSFlags OPCODE => (Flags & DNSFlags.OPCODE_Mask);
        /// <summary>Request code flags</summary>
        public DNSFlags RCODE => (Flags & DNSFlags.RCODE_Mask);
        /// <summary>The QR flag</summary>
        public bool QR => ((Flags & DNSFlags.QR) == DNSFlags.QR);
        /// <summary>The AA flag</summary>
        public bool AA => ((Flags & DNSFlags.AA) == DNSFlags.AA);
        /// <summary>The TC flag</summary>
        public bool TC => ((Flags & DNSFlags.TC) == DNSFlags.TC);
        /// <summary>The RD flag</summary>
        public bool RD => ((Flags & DNSFlags.RD) == DNSFlags.RD);
        /// <summary>The RA flag</summary>
        public bool RA => ((Flags & DNSFlags.RA) == DNSFlags.RA);

        /// <summary>The DNS Query</summary>
        public DNSQuery Query;
        /// <summary>The authoritative answers</summary>
        public DNSRecord[] Answers = { };
        /// <summary>The authorities answering</summary>
        public DNSRecord[] Authorities = { };
        /// <summary>Additional records</summary>
        public DNSRecord[] Additional = { };


        int QueryCount, AnswerCount, AuthorityCount, AdditionalCount;

        /// <summary>Encode message to buffer</summary>
        /// <param name="Index">Buffer out</param>
        public void Encode(DNSBufferIndex Index) {
            Index.WriteInt16(ID);
            Index.WriteInt16(Flags);
            Index.WriteInt16((Query == null) ? 0 : 1);
            Index.WriteInt16(Answers.Length);
            Index.WriteInt16(Authorities.Length);
            Index.WriteInt16(Additional.Length);

            if (Query != null) {
                Query.Encode(Index);
                }
            foreach (DNSRecord Record in Answers) {
                Record.Encode(Index);
                }
            foreach (DNSRecord Record in Authorities) {
                Record.Encode(Index);
                }
            foreach (DNSRecord Record in Additional) {
                Record.Encode(Index);
                }
            }

        /// <summary>Decode message from buffer</summary>
        /// <param name="Index">Buffer in</param>
        public void Decode(DNSBufferIndex Index) {

            Index.ReadInt16(out ID);
            Index.ReadInt16(out Flags);
            Index.ReadInt16(out QueryCount);
            Index.ReadInt16(out AnswerCount);
            Index.ReadInt16(out AuthorityCount);
            Index.ReadInt16(out AdditionalCount);

            //Console.WriteLine ("ID {0} Flags {1:x}  Queries {2} Answers {3} Authority {4} Additional {5}",
            //        ID, Flags, QueryCount, AnswerCount, AuthorityCount, AdditionalCount);

            if (QueryCount == 1) {
                //Console.WriteLine ("Form Query");
                Query = DNSQuery.Decode(Index);
                }

            Answers = new DNSRecord[AnswerCount];
            for (int i = 0; i < AnswerCount; i++) {
                Answers[i] = DNSRecord.Decode(Index);
                }
            Authorities = new DNSRecord[AuthorityCount];
            for (int i = 0; i < AuthorityCount; i++) {
                Authorities[i] = DNSRecord.Decode(Index);
                }
            Additional = new DNSRecord[AdditionalCount];
            for (int i = 0; i < AdditionalCount; i++) {
                Additional[i] = DNSRecord.Decode(Index);
                }
            }


        /// <summary>Parse the data in the buffer BufferIn </summary>
        /// <param name="data">The encoded message</param>
        public DNSMessage(byte[] data) {
            DNSBufferIndex Index = new DNSBufferIndex(data);

            Decode(Index);
            }


        /// <summary> Create Empty Message buffer (do not parse, done in sub);</summary>
        public DNSMessage() {
            //Index = ( new DNSBufferIndex () );
            }

        /// <summary>The type tag</summary>
        public virtual string TypeTag => null;

        }

    //The DNSClient protocol actually supports making multiple queries in one request but this
    //does not actually work in the field and should probably be deprecated.

    /// <summary>DNS request message</summary>
    public class DNSRequest : DNSMessage {

        /// <summary>Text tag describing message type.</summary>
        public override string TypeTag => "Request";

        /// <summary>Constructor for request</summary>
        /// <param name="Domain">The domain name</param>
        /// <param name="QType">The query type</param>
        public DNSRequest(string Domain, string QType) {
            if (QType == null) {
                Query = new DNSQuery(Domain, DNSTypeCode.ALL);
                }
            else {
                Query = new DNSQuery(Domain, DNS.TypeCode(QType));
                }
            Flags = DNSFlags.RD | DNSFlags.OPCODE_QUERY;
            }

        /// <summary>Constructor for request</summary>
        /// <param name="Domain">The domain name</param>
        /// <param name="QCode">The query type</param>
        public DNSRequest(string Domain, DNSTypeCode QCode) {
            Flags = DNSFlags.RD | DNSFlags.OPCODE_QUERY;
            Query = new DNSQuery(Domain, QCode);
            }

        }

    /// <summary>DNS response message</summary>
    public class DNSResponse : DNSMessage {

        /// <summary>The type of the message</summary>
        public override string TypeTag => "Response";

        /// <summary>Default constructor</summary>
        /// <param name="Data">Input data</param>
        public DNSResponse(byte[] Data) {
            // here do the decode thing.
            //Dump (Data);

            try {
                DNSBufferIndex Index = new DNSBufferIndex(Data);

                Decode(Index);
                }
            catch {
                Debug.WriteLine("Ooops");
                }

            }
        }



    /// <summary>DNS Query class</summary>
    public class DNSQuery {
        /// <summary>The Query name</summary>
        public String QName;
        /// <summary>The Query Type</summary>
        public DNSTypeCode QType;
        /// <summary>The Class</summary>
        public DNSClass QClass;

        /// <summary>Encode Query</summary>
        /// <param name="Index">Output buffer</param>
        public void Encode(DNSBufferIndex Index) {
            Index.WriteName(QName);
            Index.WriteInt16(QType);
            Index.WriteInt16(QClass);
            //Index.Dump ();
            }

        /// <summary>Decode Query</summary>
        /// <param name="Index">Input buffer</param>
        /// <returns>Query</returns>
        public static DNSQuery Decode(DNSBufferIndex Index) {
            String QName = Index.ReadName();
            DNSTypeCode QType = (DNSTypeCode)Index.ReadInt16();
            DNSClass QClass = (DNSClass)Index.ReadInt16();

            //Console.WriteLine ("Query Name={0:s} Type={1:d} Class={1:d}",
            //        QName, QType, QClass);
            return new DNSQuery(QName, QType, QClass);
            }

        // Constructors
        /// <summary>Constructor from main components</summary>
        /// <param name="Domain">Domain name</param>
        /// <param name="QTypeIn">Query type</param>
        /// <param name="QClassIn">Query class</param>
        public DNSQuery(String Domain, DNSTypeCode QTypeIn, DNSClass QClassIn) {
            QName = Domain;
            QType = QTypeIn;
            QClass = QClassIn;
            }

        /// <summary>Constructor from main components for internet class</summary>
        /// <param name="Domain">Domain name</param>
        /// <param name="QTypeIn">Query type</param>
        public DNSQuery(String Domain, DNSTypeCode QTypeIn) :
            this(Domain, QTypeIn, DNSClass.IN) { }
        }

    }
