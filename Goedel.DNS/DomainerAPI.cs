using System.Net;
using System.Collections.Generic;
namespace Goedel.DNS {

	public partial class DNS {
		// Dictionary of Type names to codes
		//
		// if (DictionaryType.ContainsKey("RR") {
		//    int value = dictionary["RR"];
		//    }
		static Dictionary <string, ushort> DictionaryType = new Dictionary <string, ushort> () {
			{"A", 1},
			{"NS", 2},
			{"MD", 3},
			{"MF", 4},
			{"CNAME", 5},
			{"SOA", 6},
			{"MB", 7},
			{"MG", 8},
			{"MR", 9},
			{"NULL", 10},
			{"WKS", 11},
			{"PTR", 12},
			{"HINFO", 13},
			{"MINFO", 14},
			{"MX", 15},
			{"TXT", 16},
			{"RP", 17},
			{"AFSDB", 18},
			{"X25", 19},
			{"ISDN", 20},
			{"RT", 21},
			{"SIG", 24},
			{"KEY", 25},
			{"AAAA", 28},
			{"SRV", 33},
			{"NAPTR", 35},
			{"KX", 36},
			{"CERT", 37},
			{"DNAME", 39},
			{"OPT", 41},
			{"DS", 43},
			{"SSHFP", 44},
			{"IPSECKEY", 45},
			{"RRSIG", 46},
			{"NSEC", 47},
			{"DNSKEY", 48},
			{"DHCID", 49},
			{"NSEC3", 50},
			{"NSEC3PARAM", 51},
			{"TLSA", 52},
			{"HIP", 55},
			{"SPF", 99},
			{"NID", 104},
			{"L32", 105},
			{"L64", 106},
			{"LP", 107},
			{"TKEY", 249},
			{"TSIG", 250},
			{"IXFR", 251},
			{"AXFR", 252},
			{"MAILB", 253},
			{"MAILA", 254},
			{"ALL", 255},
			{"URI", 256},
			{"CAA", 257},
			{"TA", 32768},
			{"DLV", 32769},
			{"*", 255} // End of list * = ALL
			} ;

		static Dictionary <ushort, string> DictionaryCode = new Dictionary <ushort, string> () {
			{1, "A"},
			{2, "NS"},
			{3, "MD"},
			{4, "MF"},
			{5, "CNAME"},
			{6, "SOA"},
			{7, "MB"},
			{8, "MG"},
			{9, "MR"},
			{10, "NULL"},
			{11, "WKS"},
			{12, "PTR"},
			{13, "HINFO"},
			{14, "MINFO"},
			{15, "MX"},
			{16, "TXT"},
			{17, "RP"},
			{18, "AFSDB"},
			{19, "X25"},
			{20, "ISDN"},
			{21, "RT"},
			{24, "SIG"},
			{25, "KEY"},
			{28, "AAAA"},
			{33, "SRV"},
			{35, "NAPTR"},
			{36, "KX"},
			{37, "CERT"},
			{39, "DNAME"},
			{41, "OPT"},
			{43, "DS"},
			{44, "SSHFP"},
			{45, "IPSECKEY"},
			{46, "RRSIG"},
			{47, "NSEC"},
			{48, "DNSKEY"},
			{49, "DHCID"},
			{50, "NSEC3"},
			{51, "NSEC3PARAM"},
			{52, "TLSA"},
			{55, "HIP"},
			{99, "SPF"},
			{104, "NID"},
			{105, "L32"},
			{106, "L64"},
			{107, "LP"},
			{249, "TKEY"},
			{250, "TSIG"},
			{251, "IXFR"},
			{252, "AXFR"},
			{253, "MAILB"},
			{254, "MAILA"},
			{255, "ALL"},
			{256, "URI"},
			{257, "CAA"},
			{32768, "TA"},
			{32769, "DLV"},
			{0, ""} // End of list * = ALL
			} ;


        public static DNSTypeCode TypeCode(string Tag) {
            if (Tag != null) {
                return (DNSTypeCode) DictionaryType[Tag];
                }
            return 0;
            }
        public static string TypeCode(int Code ) {
            return DictionaryCode[(ushort)Code];
            }
		}


	public enum DNSTypeCode : ushort {
		A = 1,
		NS = 2,
		MD = 3,
		MF = 4,
		CNAME = 5,
		SOA = 6,
		MB = 7,
		MG = 8,
		MR = 9,
		NULL = 10,
		WKS = 11,
		PTR = 12,
		HINFO = 13,
		MINFO = 14,
		MX = 15,
		TXT = 16,
		RP = 17,
		AFSDB = 18,
		X25 = 19,
		ISDN = 20,
		RT = 21,
		NSAP = 22,  // Deprecated, NOT IMPLEMENTED
		NSAPPTR = 23,  // Deprecated, NOT IMPLEMENTED
		SIG = 24,
		KEY = 25,
		PX = 26,  // Deprecated, NOT IMPLEMENTED
		GPOS = 27,  // Deprecated, NOT IMPLEMENTED
		AAAA = 28,
		LOC = 29,  // Deprecated, NOT IMPLEMENTED
		NXT = 30,  // Deprecated, NOT IMPLEMENTED
		EID = 31,  // Deprecated, NOT IMPLEMENTED
		NIMLOC = 32,  // Deprecated, NOT IMPLEMENTED
		SRV = 33,
		ATMA = 34,  // Deprecated, NOT IMPLEMENTED
		NAPTR = 35,
		KX = 36,
		CERT = 37,
		A6 = 38,  // Deprecated, NOT IMPLEMENTED
		DNAME = 39,
		SINK = 40,  // Deprecated, NOT IMPLEMENTED
		OPT = 41,
		APL = 42,  // Deprecated, NOT IMPLEMENTED
		DS = 43,
		SSHFP = 44,
		IPSECKEY = 45,
		RRSIG = 46,
		NSEC = 47,
		DNSKEY = 48,
		DHCID = 49,
		NSEC3 = 50,
		NSEC3PARAM = 51,
		TLSA = 52,
		HIP = 55,
		NINFO = 56,  // Deprecated, NOT IMPLEMENTED
		RKEY = 57,  // Deprecated, NOT IMPLEMENTED
		TALINK = 58,  // Deprecated, NOT IMPLEMENTED
		CDS = 59,  // Deprecated, NOT IMPLEMENTED
		SPF = 99,
		UINFO = 100,  // Deprecated, NOT IMPLEMENTED
		UID = 101,  // Deprecated, NOT IMPLEMENTED
		GID = 102,  // Deprecated, NOT IMPLEMENTED
		UNSPEC = 103,  // Deprecated, NOT IMPLEMENTED
		NID = 104,
		L32 = 105,
		L64 = 106,
		LP = 107,
		TKEY = 249,
		TSIG = 250,
		IXFR = 251,  // Used in Queries only
		AXFR = 252,  // Used in Queries only
		MAILB = 253,  // Used in Queries only
		MAILA = 254,  // Used in Queries only
		ALL = 255,  // Used in Queries only
		URI = 256,
		CAA = 257,
		TA = 32768,
		DLV = 32769,
		Unknown = 0
		}

	// All resource record classes are descended from DNSRR
	public abstract partial  class DNSRecord {
		public virtual DNSTypeCode			Code {
			get {return (0);} }		
		public virtual string	Label {
			get {return ("Unknown");} }	
		public virtual string	Description {
			get {return ("Record is not defined");} }
			
			
			
        public static DNSRecord Decode(DNSBufferIndex Index) {
			DNSRecord			DNSRecord;
			
			Domain				Domain;
			DNSTypeCode			RType;
			DNSClass			RClass;
			uint				TTL;
			int				RDLength;

            Domain = Index.ReadDomain ();
            RType = (DNSTypeCode)Index.ReadInt16 ();
            RClass = (DNSClass)Index.ReadInt16 ();
            TTL = Index.ReadInt32 ();
			RDLength = Index.ReadInt16 ();
			int NextRecord = Index.Pointer + RDLength;

            //Index.ReadL16Data (out RData);

			switch ((int) RType) {
				case (1) : {
					DNSRecord = DNSRecord_A.Decode (Index, RDLength);
					break;
					}
				case (2) : {
					DNSRecord = DNSRecord_NS.Decode (Index, RDLength);
					break;
					}
				case (3) : {
					DNSRecord = DNSRecord_MD.Decode (Index, RDLength);
					break;
					}
				case (4) : {
					DNSRecord = DNSRecord_MF.Decode (Index, RDLength);
					break;
					}
				case (5) : {
					DNSRecord = DNSRecord_CNAME.Decode (Index, RDLength);
					break;
					}
				case (6) : {
					DNSRecord = DNSRecord_SOA.Decode (Index, RDLength);
					break;
					}
				case (7) : {
					DNSRecord = DNSRecord_MB.Decode (Index, RDLength);
					break;
					}
				case (8) : {
					DNSRecord = DNSRecord_MG.Decode (Index, RDLength);
					break;
					}
				case (9) : {
					DNSRecord = DNSRecord_MR.Decode (Index, RDLength);
					break;
					}
				case (10) : {
					DNSRecord = DNSRecord_NULL.Decode (Index, RDLength);
					break;
					}
				case (11) : {
					DNSRecord = DNSRecord_WKS.Decode (Index, RDLength);
					break;
					}
				case (12) : {
					DNSRecord = DNSRecord_PTR.Decode (Index, RDLength);
					break;
					}
				case (13) : {
					DNSRecord = DNSRecord_HINFO.Decode (Index, RDLength);
					break;
					}
				case (14) : {
					DNSRecord = DNSRecord_MINFO.Decode (Index, RDLength);
					break;
					}
				case (15) : {
					DNSRecord = DNSRecord_MX.Decode (Index, RDLength);
					break;
					}
				case (16) : {
					DNSRecord = DNSRecord_TXT.Decode (Index, RDLength);
					break;
					}
				case (17) : {
					DNSRecord = DNSRecord_RP.Decode (Index, RDLength);
					break;
					}
				case (18) : {
					DNSRecord = DNSRecord_AFSDB.Decode (Index, RDLength);
					break;
					}
				case (19) : {
					DNSRecord = DNSRecord_X25.Decode (Index, RDLength);
					break;
					}
				case (20) : {
					DNSRecord = DNSRecord_ISDN.Decode (Index, RDLength);
					break;
					}
				case (21) : {
					DNSRecord = DNSRecord_RT.Decode (Index, RDLength);
					break;
					}
				case (24) : {
					DNSRecord = DNSRecord_SIG.Decode (Index, RDLength);
					break;
					}
				case (25) : {
					DNSRecord = DNSRecord_KEY.Decode (Index, RDLength);
					break;
					}
				case (28) : {
					DNSRecord = DNSRecord_AAAA.Decode (Index, RDLength);
					break;
					}
				case (33) : {
					DNSRecord = DNSRecord_SRV.Decode (Index, RDLength);
					break;
					}
				case (35) : {
					DNSRecord = DNSRecord_NAPTR.Decode (Index, RDLength);
					break;
					}
				case (36) : {
					DNSRecord = DNSRecord_KX.Decode (Index, RDLength);
					break;
					}
				case (37) : {
					DNSRecord = DNSRecord_CERT.Decode (Index, RDLength);
					break;
					}
				case (39) : {
					DNSRecord = DNSRecord_DNAME.Decode (Index, RDLength);
					break;
					}
				case (41) : {
					DNSRecord = DNSRecord_OPT.Decode (Index, RDLength);
					break;
					}
				case (43) : {
					DNSRecord = DNSRecord_DS.Decode (Index, RDLength);
					break;
					}
				case (44) : {
					DNSRecord = DNSRecord_SSHFP.Decode (Index, RDLength);
					break;
					}
				case (45) : {
					DNSRecord = DNSRecord_IPSECKEY.Decode (Index, RDLength);
					break;
					}
				case (46) : {
					DNSRecord = DNSRecord_RRSIG.Decode (Index, RDLength);
					break;
					}
				case (47) : {
					DNSRecord = DNSRecord_NSEC.Decode (Index, RDLength);
					break;
					}
				case (48) : {
					DNSRecord = DNSRecord_DNSKEY.Decode (Index, RDLength);
					break;
					}
				case (49) : {
					DNSRecord = DNSRecord_DHCID.Decode (Index, RDLength);
					break;
					}
				case (50) : {
					DNSRecord = DNSRecord_NSEC3.Decode (Index, RDLength);
					break;
					}
				case (51) : {
					DNSRecord = DNSRecord_NSEC3PARAM.Decode (Index, RDLength);
					break;
					}
				case (52) : {
					DNSRecord = DNSRecord_TLSA.Decode (Index, RDLength);
					break;
					}
				case (55) : {
					DNSRecord = DNSRecord_HIP.Decode (Index, RDLength);
					break;
					}
				case (99) : {
					DNSRecord = DNSRecord_SPF.Decode (Index, RDLength);
					break;
					}
				case (104) : {
					DNSRecord = DNSRecord_NID.Decode (Index, RDLength);
					break;
					}
				case (105) : {
					DNSRecord = DNSRecord_L32.Decode (Index, RDLength);
					break;
					}
				case (106) : {
					DNSRecord = DNSRecord_L64.Decode (Index, RDLength);
					break;
					}
				case (107) : {
					DNSRecord = DNSRecord_LP.Decode (Index, RDLength);
					break;
					}
				case (249) : {
					DNSRecord = DNSRecord_TKEY.Decode (Index, RDLength);
					break;
					}
				case (250) : {
					DNSRecord = DNSRecord_TSIG.Decode (Index, RDLength);
					break;
					}
				case (256) : {
					DNSRecord = DNSRecord_URI.Decode (Index, RDLength);
					break;
					}
				case (257) : {
					DNSRecord = DNSRecord_CAA.Decode (Index, RDLength);
					break;
					}
				case (32768) : {
					DNSRecord = DNSRecord_TA.Decode (Index, RDLength);
					break;
					}
				case (32769) : {
					DNSRecord = DNSRecord_DLV.Decode (Index, RDLength);
					break;
					}
				default : {
					DNSRecord = DNSRecord_Unknown.Decode (Index, RDLength) ;
					break;
					}
				}
			DNSRecord.Domain = Domain;
			DNSRecord.RType = RType;
			DNSRecord.RClass = RClass;
			DNSRecord.TTL = TTL;
			Index.Pointer = NextRecord;

            return DNSRecord;
            }				

		public static DNSRecord Parse(string Tag, Parse Parse) {
			switch (Tag) {

				case ("A") : {
					return DNSRecord_A.Parse (Parse);
					}
				case ("NS") : {
					return DNSRecord_NS.Parse (Parse);
					}
				case ("MD") : {
					return DNSRecord_MD.Parse (Parse);
					}
				case ("MF") : {
					return DNSRecord_MF.Parse (Parse);
					}
				case ("CNAME") : {
					return DNSRecord_CNAME.Parse (Parse);
					}
				case ("SOA") : {
					return DNSRecord_SOA.Parse (Parse);
					}
				case ("MB") : {
					return DNSRecord_MB.Parse (Parse);
					}
				case ("MG") : {
					return DNSRecord_MG.Parse (Parse);
					}
				case ("MR") : {
					return DNSRecord_MR.Parse (Parse);
					}
				case ("NULL") : {
					return DNSRecord_NULL.Parse (Parse);
					}
				case ("WKS") : {
					return DNSRecord_WKS.Parse (Parse);
					}
				case ("PTR") : {
					return DNSRecord_PTR.Parse (Parse);
					}
				case ("HINFO") : {
					return DNSRecord_HINFO.Parse (Parse);
					}
				case ("MINFO") : {
					return DNSRecord_MINFO.Parse (Parse);
					}
				case ("MX") : {
					return DNSRecord_MX.Parse (Parse);
					}
				case ("TXT") : {
					return DNSRecord_TXT.Parse (Parse);
					}
				case ("RP") : {
					return DNSRecord_RP.Parse (Parse);
					}
				case ("AFSDB") : {
					return DNSRecord_AFSDB.Parse (Parse);
					}
				case ("X25") : {
					return DNSRecord_X25.Parse (Parse);
					}
				case ("ISDN") : {
					return DNSRecord_ISDN.Parse (Parse);
					}
				case ("RT") : {
					return DNSRecord_RT.Parse (Parse);
					}
				case ("SIG") : {
					return DNSRecord_SIG.Parse (Parse);
					}
				case ("KEY") : {
					return DNSRecord_KEY.Parse (Parse);
					}
				case ("AAAA") : {
					return DNSRecord_AAAA.Parse (Parse);
					}
				case ("SRV") : {
					return DNSRecord_SRV.Parse (Parse);
					}
				case ("NAPTR") : {
					return DNSRecord_NAPTR.Parse (Parse);
					}
				case ("KX") : {
					return DNSRecord_KX.Parse (Parse);
					}
				case ("CERT") : {
					return DNSRecord_CERT.Parse (Parse);
					}
				case ("DNAME") : {
					return DNSRecord_DNAME.Parse (Parse);
					}
				case ("OPT") : {
					return DNSRecord_OPT.Parse (Parse);
					}
				case ("DS") : {
					return DNSRecord_DS.Parse (Parse);
					}
				case ("SSHFP") : {
					return DNSRecord_SSHFP.Parse (Parse);
					}
				case ("IPSECKEY") : {
					return DNSRecord_IPSECKEY.Parse (Parse);
					}
				case ("RRSIG") : {
					return DNSRecord_RRSIG.Parse (Parse);
					}
				case ("NSEC") : {
					return DNSRecord_NSEC.Parse (Parse);
					}
				case ("DNSKEY") : {
					return DNSRecord_DNSKEY.Parse (Parse);
					}
				case ("DHCID") : {
					return DNSRecord_DHCID.Parse (Parse);
					}
				case ("NSEC3") : {
					return DNSRecord_NSEC3.Parse (Parse);
					}
				case ("NSEC3PARAM") : {
					return DNSRecord_NSEC3PARAM.Parse (Parse);
					}
				case ("TLSA") : {
					return DNSRecord_TLSA.Parse (Parse);
					}
				case ("HIP") : {
					return DNSRecord_HIP.Parse (Parse);
					}
				case ("SPF") : {
					return DNSRecord_SPF.Parse (Parse);
					}
				case ("NID") : {
					return DNSRecord_NID.Parse (Parse);
					}
				case ("L32") : {
					return DNSRecord_L32.Parse (Parse);
					}
				case ("L64") : {
					return DNSRecord_L64.Parse (Parse);
					}
				case ("LP") : {
					return DNSRecord_LP.Parse (Parse);
					}
				case ("TKEY") : {
					return DNSRecord_TKEY.Parse (Parse);
					}
				case ("TSIG") : {
					return DNSRecord_TSIG.Parse (Parse);
					}
				case ("URI") : {
					return DNSRecord_URI.Parse (Parse);
					}
				case ("CAA") : {
					return DNSRecord_CAA.Parse (Parse);
					}
				case ("TA") : {
					return DNSRecord_TA.Parse (Parse);
					}
				case ("DLV") : {
					return DNSRecord_DLV.Parse (Parse);
					}

				default : {
					return null;
					}
				}
			}

		}

		
	public partial class DNSRecord_Unknown : DNSRecord {
		//public DNSBufferIndex   RData;

		public static DNSRecord_Unknown Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_Unknown NewRecord = new DNSRecord_Unknown (); 

			Index.ReadL16Data (out NewRecord.RData);

			return NewRecord;
			}
		}



	// A 1 Host address
	//     See RFC1035

	public class DNSRecord_A : DNSRecord {

		public IPAddress   Address  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.A);} }		
		public override string	Label {
			get {return ("A");} }	
		public override string	Description {
			get {return ("Host address");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("A", Domain);
			Canonicalize.IPv4  (Address);
			return Canonicalize.Text;
            }

        public static DNSRecord_A Parse(Parse Parse) {
			DNSRecord_A NewRecord = new DNSRecord_A () ;
			
			NewRecord.Address = Parse.IPv4  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteIPv4 (Address);
			//Encode.IPv4  (Address);
            }

        // Convert from byte form
        public static  DNSRecord_A Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_A NewRecord = new DNSRecord_A () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Address = Index.ReadIPv4 ();
			

			return NewRecord;
            }

		}

	// NS 2 Authoritative name server
	//     See RFC1035

	public class DNSRecord_NS : DNSRecord {

		public Domain   NSDNAME  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.NS);} }		
		public override string	Label {
			get {return ("NS");} }	
		public override string	Description {
			get {return ("Authoritative name server");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("NS", Domain);
			Canonicalize.Domain  (NSDNAME);
			return Canonicalize.Text;
            }

        public static DNSRecord_NS Parse(Parse Parse) {
			DNSRecord_NS NewRecord = new DNSRecord_NS () ;
			
			NewRecord.NSDNAME = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (NSDNAME);
			//Encode.Domain  (NSDNAME);
            }

        // Convert from byte form
        public static  DNSRecord_NS Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_NS NewRecord = new DNSRecord_NS () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.NSDNAME = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// MD 3 Mail destination
	//     See RFC1035

	public class DNSRecord_MD : DNSRecord {

		public Domain   MADNAME  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.MD);} }		
		public override string	Label {
			get {return ("MD");} }	
		public override string	Description {
			get {return ("Mail destination");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("MD", Domain);
			Canonicalize.Domain  (MADNAME);
			return Canonicalize.Text;
            }

        public static DNSRecord_MD Parse(Parse Parse) {
			DNSRecord_MD NewRecord = new DNSRecord_MD () ;
			
			NewRecord.MADNAME = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (MADNAME);
			//Encode.Domain  (MADNAME);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_MD Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_MD NewRecord = new DNSRecord_MD () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.MADNAME = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// MF 4 Mail forwarder
	//     See RFC1035

	public class DNSRecord_MF : DNSRecord {

		public Domain   MADNAME  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.MF);} }		
		public override string	Label {
			get {return ("MF");} }	
		public override string	Description {
			get {return ("Mail forwarder");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("MF", Domain);
			Canonicalize.Domain  (MADNAME);
			return Canonicalize.Text;
            }

        public static DNSRecord_MF Parse(Parse Parse) {
			DNSRecord_MF NewRecord = new DNSRecord_MF () ;
			
			NewRecord.MADNAME = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (MADNAME);
			//Encode.Domain  (MADNAME);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_MF Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_MF NewRecord = new DNSRecord_MF () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.MADNAME = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// CNAME 5 Canonical name for an alias
	//     See RFC1035

	public class DNSRecord_CNAME : DNSRecord {

		public Domain   CNAME  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.CNAME);} }		
		public override string	Label {
			get {return ("CNAME");} }	
		public override string	Description {
			get {return ("Canonical name for an alias");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("CNAME", Domain);
			Canonicalize.Domain  (CNAME);
			return Canonicalize.Text;
            }

        public static DNSRecord_CNAME Parse(Parse Parse) {
			DNSRecord_CNAME NewRecord = new DNSRecord_CNAME () ;
			
			NewRecord.CNAME = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (CNAME);
			//Encode.Domain  (CNAME);
            }

        // Convert from byte form
        public static  DNSRecord_CNAME Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_CNAME NewRecord = new DNSRecord_CNAME () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.CNAME = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// SOA 6 Start of a zone of authority
	//     See RFC1035

	public class DNSRecord_SOA : DNSRecord {

		public Domain   MNAME  ;
		public Domain   RNAME  ;
		public uint   SERIAL  ;
		public uint   REFRESH  ;
		public uint   RETRY  ;
		public uint   EXPIRE  ;
		public uint   MINIMUM  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.SOA);} }		
		public override string	Label {
			get {return ("SOA");} }	
		public override string	Description {
			get {return ("Start of a zone of authority");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("SOA", Domain);
			Canonicalize.Domain  (MNAME);
			Canonicalize.Domain  (RNAME);
			Canonicalize.Int32  (SERIAL);
			Canonicalize.Int32  (REFRESH);
			Canonicalize.Int32  (RETRY);
			Canonicalize.Int32  (EXPIRE);
			Canonicalize.Int32  (MINIMUM);
			return Canonicalize.Text;
            }

        public static DNSRecord_SOA Parse(Parse Parse) {
			DNSRecord_SOA NewRecord = new DNSRecord_SOA () ;
			
			NewRecord.MNAME = Parse.Domain  ();
			NewRecord.RNAME = Parse.Domain  ();
			NewRecord.SERIAL = Parse.Int32  ();
			NewRecord.REFRESH = Parse.Int32  ();
			NewRecord.RETRY = Parse.Int32  ();
			NewRecord.EXPIRE = Parse.Int32  ();
			NewRecord.MINIMUM = Parse.Int32  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (MNAME);
			//Encode.Domain  (MNAME);
			Index.WriteDomain (RNAME);
			//Encode.Domain  (RNAME);
			Index.WriteInt32 (SERIAL);
			//Encode.Int32  (SERIAL);
			Index.WriteInt32 (REFRESH);
			//Encode.Int32  (REFRESH);
			Index.WriteInt32 (RETRY);
			//Encode.Int32  (RETRY);
			Index.WriteInt32 (EXPIRE);
			//Encode.Int32  (EXPIRE);
			Index.WriteInt32 (MINIMUM);
			//Encode.Int32  (MINIMUM);
            }

        // Convert from byte form
        public static  DNSRecord_SOA Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_SOA NewRecord = new DNSRecord_SOA () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.MNAME = Index.ReadDomain ();
			NewRecord.RNAME = Index.ReadDomain ();
			NewRecord.SERIAL = Index.ReadInt32 ();
			NewRecord.REFRESH = Index.ReadInt32 ();
			NewRecord.RETRY = Index.ReadInt32 ();
			NewRecord.EXPIRE = Index.ReadInt32 ();
			NewRecord.MINIMUM = Index.ReadInt32 ();
			

			return NewRecord;
            }

		}

	// MB 7 Mailbox domain name
	//     See RFC1035

	public class DNSRecord_MB : DNSRecord {

		public Domain   MadName  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.MB);} }		
		public override string	Label {
			get {return ("MB");} }	
		public override string	Description {
			get {return ("Mailbox domain name");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("MB", Domain);
			Canonicalize.Domain  (MadName);
			return Canonicalize.Text;
            }

        public static DNSRecord_MB Parse(Parse Parse) {
			DNSRecord_MB NewRecord = new DNSRecord_MB () ;
			
			NewRecord.MadName = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (MadName);
			//Encode.Domain  (MadName);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_MB Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_MB NewRecord = new DNSRecord_MB () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.MadName = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// MG 8 Mail group member
	//     See RFC1035

	public class DNSRecord_MG : DNSRecord {

		public Domain   MGMNAME  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.MG);} }		
		public override string	Label {
			get {return ("MG");} }	
		public override string	Description {
			get {return ("Mail group member");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("MG", Domain);
			Canonicalize.Domain  (MGMNAME);
			return Canonicalize.Text;
            }

        public static DNSRecord_MG Parse(Parse Parse) {
			DNSRecord_MG NewRecord = new DNSRecord_MG () ;
			
			NewRecord.MGMNAME = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (MGMNAME);
			//Encode.Domain  (MGMNAME);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_MG Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_MG NewRecord = new DNSRecord_MG () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.MGMNAME = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// MR 9 Mail rename domain name
	//     See RFC1035

	public class DNSRecord_MR : DNSRecord {

		public Domain   NEWNAME  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.MR);} }		
		public override string	Label {
			get {return ("MR");} }	
		public override string	Description {
			get {return ("Mail rename domain name");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("MR", Domain);
			Canonicalize.Domain  (NEWNAME);
			return Canonicalize.Text;
            }

        public static DNSRecord_MR Parse(Parse Parse) {
			DNSRecord_MR NewRecord = new DNSRecord_MR () ;
			
			NewRecord.NEWNAME = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (NEWNAME);
			//Encode.Domain  (NEWNAME);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_MR Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_MR NewRecord = new DNSRecord_MR () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.NEWNAME = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// NULL 10 Null RR
	//     See RFC1035

	public class DNSRecord_NULL : DNSRecord {

		public byte[]   Anything  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.NULL);} }		
		public override string	Label {
			get {return ("NULL");} }	
		public override string	Description {
			get {return ("Null RR");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("NULL", Domain);
			Canonicalize.Binary  (Anything);
			return Canonicalize.Text;
            }

        public static DNSRecord_NULL Parse(Parse Parse) {
			DNSRecord_NULL NewRecord = new DNSRecord_NULL () ;
			
			NewRecord.Anything = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteData (Anything);
			//Encode.Binary  (Anything);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_NULL Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_NULL NewRecord = new DNSRecord_NULL () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Anything = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// WKS 11 Well known service description
	//     See RFC1035

	public class DNSRecord_WKS : DNSRecord {

		public IPAddress   Address  ;
		public byte   Protocol  ;
		public byte[]   BITMAP  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.WKS);} }		
		public override string	Label {
			get {return ("WKS");} }	
		public override string	Description {
			get {return ("Well known service description");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("WKS", Domain);
			Canonicalize.IPv4  (Address);
			Canonicalize.Byte  (Protocol);
			Canonicalize.Binary  (BITMAP);
			return Canonicalize.Text;
            }

        public static DNSRecord_WKS Parse(Parse Parse) {
			DNSRecord_WKS NewRecord = new DNSRecord_WKS () ;
			
			NewRecord.Address = Parse.IPv4  ();
			NewRecord.Protocol = Parse.Byte  ();
			NewRecord.BITMAP = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteIPv4 (Address);
			//Encode.IPv4  (Address);
			Index.WriteByte (Protocol);
			//Encode.Byte  (Protocol);
			Index.WriteData (BITMAP);
			//Encode.Binary  (BITMAP);
            }

        // Convert from byte form
        public static  DNSRecord_WKS Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_WKS NewRecord = new DNSRecord_WKS () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Address = Index.ReadIPv4 ();
			NewRecord.Protocol = Index.ReadByte ();
			NewRecord.BITMAP = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// PTR 12 Domain name pointer
	//     See RFC1035

	public class DNSRecord_PTR : DNSRecord {

		public Domain   PTRDNAME  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.PTR);} }		
		public override string	Label {
			get {return ("PTR");} }	
		public override string	Description {
			get {return ("Domain name pointer");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("PTR", Domain);
			Canonicalize.Domain  (PTRDNAME);
			return Canonicalize.Text;
            }

        public static DNSRecord_PTR Parse(Parse Parse) {
			DNSRecord_PTR NewRecord = new DNSRecord_PTR () ;
			
			NewRecord.PTRDNAME = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (PTRDNAME);
			//Encode.Domain  (PTRDNAME);
            }

        // Convert from byte form
        public static  DNSRecord_PTR Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_PTR NewRecord = new DNSRecord_PTR () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.PTRDNAME = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// HINFO 13 Host information
	//     See RFC1035

	public class DNSRecord_HINFO : DNSRecord {

		public string   CPU  ;
		public string   OS  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.HINFO);} }		
		public override string	Label {
			get {return ("HINFO");} }	
		public override string	Description {
			get {return ("Host information");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("HINFO", Domain);
			Canonicalize.String  (CPU);
			Canonicalize.String  (OS);
			return Canonicalize.Text;
            }

        public static DNSRecord_HINFO Parse(Parse Parse) {
			DNSRecord_HINFO NewRecord = new DNSRecord_HINFO () ;
			
			NewRecord.CPU = Parse.String  ();
			NewRecord.OS = Parse.String  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteString8 (CPU);
			//Encode.String  (CPU);
			Index.WriteString8 (OS);
			//Encode.String  (OS);
            }

        // Convert from byte form
        public static  DNSRecord_HINFO Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_HINFO NewRecord = new DNSRecord_HINFO () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.CPU = Index.ReadString ();
			NewRecord.OS = Index.ReadString ();
			

			return NewRecord;
            }

		}

	// MINFO 14 Mailbox or mail list information
	//     See RFC1035

	public class DNSRecord_MINFO : DNSRecord {

		public Domain   RMAILBX  ;
		public Domain   EMAILBX  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.MINFO);} }		
		public override string	Label {
			get {return ("MINFO");} }	
		public override string	Description {
			get {return ("Mailbox or mail list information");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("MINFO", Domain);
			Canonicalize.Domain  (RMAILBX);
			Canonicalize.Domain  (EMAILBX);
			return Canonicalize.Text;
            }

        public static DNSRecord_MINFO Parse(Parse Parse) {
			DNSRecord_MINFO NewRecord = new DNSRecord_MINFO () ;
			
			NewRecord.RMAILBX = Parse.Domain  ();
			NewRecord.EMAILBX = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (RMAILBX);
			//Encode.Domain  (RMAILBX);
			Index.WriteDomain (EMAILBX);
			//Encode.Domain  (EMAILBX);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_MINFO Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_MINFO NewRecord = new DNSRecord_MINFO () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.RMAILBX = Index.ReadDomain ();
			NewRecord.EMAILBX = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// MX 15 Mail exchange
	//     See RFC1035

	public class DNSRecord_MX : DNSRecord {

		public ushort   Preference  ;
		public Domain   Exchange  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.MX);} }		
		public override string	Label {
			get {return ("MX");} }	
		public override string	Description {
			get {return ("Mail exchange");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("MX", Domain);
			Canonicalize.Int16  (Preference);
			Canonicalize.Domain  (Exchange);
			return Canonicalize.Text;
            }

        public static DNSRecord_MX Parse(Parse Parse) {
			DNSRecord_MX NewRecord = new DNSRecord_MX () ;
			
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.Exchange = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteDomain (Exchange);
			//Encode.Domain  (Exchange);
            }

        // Convert from byte form
        public static  DNSRecord_MX Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_MX NewRecord = new DNSRecord_MX () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.Exchange = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// TXT 16 Text strings
	//     See RFC1035

	public class DNSRecord_TXT : DNSRecord {

		public List<string>   Text  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.TXT);} }		
		public override string	Label {
			get {return ("TXT");} }	
		public override string	Description {
			get {return ("Text strings");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("TXT", Domain);
			Canonicalize.Strings  (Text);
			return Canonicalize.Text;
            }

        public static DNSRecord_TXT Parse(Parse Parse) {
			DNSRecord_TXT NewRecord = new DNSRecord_TXT () ;
			
			NewRecord.Text = Parse.Strings  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			foreach (string s in Text) {
				Index.WriteString8 (s);
				}
			//Encode.Strings  (Text);
            }

        // Convert from byte form
        public static  DNSRecord_TXT Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_TXT NewRecord = new DNSRecord_TXT () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Text = Index.ReadStrings (Length - (Index.Pointer - NewRecord.Start)) ;
			

			return NewRecord;
            }

		}

	// RP 17 Responsible Person
	//     See RFC1183

	public class DNSRecord_RP : DNSRecord {

		public string   MBox  ;
		public Domain   Txt  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.RP);} }		
		public override string	Label {
			get {return ("RP");} }	
		public override string	Description {
			get {return ("Responsible Person");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("RP", Domain);
			Canonicalize.Mail  (MBox);
			Canonicalize.Domain  (Txt);
			return Canonicalize.Text;
            }

        public static DNSRecord_RP Parse(Parse Parse) {
			DNSRecord_RP NewRecord = new DNSRecord_RP () ;
			
			NewRecord.MBox = Parse.Mail  ();
			NewRecord.Txt = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteMail (MBox);
			//Encode.Mail  (MBox);
			Index.WriteDomain (Txt);
			//Encode.Domain  (Txt);
            }

        // Convert from byte form
        public static  DNSRecord_RP Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_RP NewRecord = new DNSRecord_RP () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.MBox = Index.ReadMail ();
			NewRecord.Txt = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// AFSDB 18 AFS Data Base location
	//     See RFC1183,RFC5864

	public class DNSRecord_AFSDB : DNSRecord {

		public ushort   SubType  ;
		public Domain   HostName  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.AFSDB);} }		
		public override string	Label {
			get {return ("AFSDB");} }	
		public override string	Description {
			get {return ("AFS Data Base location");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("AFSDB", Domain);
			Canonicalize.Int16  (SubType);
			Canonicalize.Domain  (HostName);
			return Canonicalize.Text;
            }

        public static DNSRecord_AFSDB Parse(Parse Parse) {
			DNSRecord_AFSDB NewRecord = new DNSRecord_AFSDB () ;
			
			NewRecord.SubType = Parse.Int16  ();
			NewRecord.HostName = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (SubType);
			//Encode.Int16  (SubType);
			Index.WriteDomain (HostName);
			//Encode.Domain  (HostName);
            }

        // Convert from byte form
        public static  DNSRecord_AFSDB Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_AFSDB NewRecord = new DNSRecord_AFSDB () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.SubType = Index.ReadInt16 ();
			NewRecord.HostName = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// X25 19 X.25 PSDN address
	//     See RFC1183

	public class DNSRecord_X25 : DNSRecord {

		public string   PSDN  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.X25);} }		
		public override string	Label {
			get {return ("X25");} }	
		public override string	Description {
			get {return ("X.25 PSDN address");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("X25", Domain);
			Canonicalize.String  (PSDN);
			return Canonicalize.Text;
            }

        public static DNSRecord_X25 Parse(Parse Parse) {
			DNSRecord_X25 NewRecord = new DNSRecord_X25 () ;
			
			NewRecord.PSDN = Parse.String  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteString8 (PSDN);
			//Encode.String  (PSDN);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_X25 Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_X25 NewRecord = new DNSRecord_X25 () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.PSDN = Index.ReadString ();
			

			return NewRecord;
            }

		}

	// ISDN 20 ISDN address
	//     See RFC1183

	public class DNSRecord_ISDN : DNSRecord {

		public string   ISDN  ;
		public string   SA  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.ISDN);} }		
		public override string	Label {
			get {return ("ISDN");} }	
		public override string	Description {
			get {return ("ISDN address");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("ISDN", Domain);
			Canonicalize.String  (ISDN);
			Canonicalize.OptionalString  (SA);
			return Canonicalize.Text;
            }

        public static DNSRecord_ISDN Parse(Parse Parse) {
			DNSRecord_ISDN NewRecord = new DNSRecord_ISDN () ;
			
			NewRecord.ISDN = Parse.String  ();
			NewRecord.SA = Parse.OptionalString  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteString8 (ISDN);
			//Encode.String  (ISDN);
			if (SA != null) {
				Index.WriteString8 (SA);
				}
			//Encode.OptionalString  (SA);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_ISDN Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_ISDN NewRecord = new DNSRecord_ISDN () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.ISDN = Index.ReadString ();
			// If there is space left in the record, the optional string will be represented as
			// an octet followed by the string data
			if (Length - (Index.Pointer - NewRecord.Start) > 0) {
				NewRecord.SA = Index.ReadString ();
				}
			else {
				NewRecord.SA = null;
				}
			

			return NewRecord;
            }

		}

	// RT 21 Route Through
	//     See RFC1183

	public class DNSRecord_RT : DNSRecord {

		public ushort   Preference  ;
		public Domain   Exchange  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.RT);} }		
		public override string	Label {
			get {return ("RT");} }	
		public override string	Description {
			get {return ("Route Through");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("RT", Domain);
			Canonicalize.Int16  (Preference);
			Canonicalize.Domain  (Exchange);
			return Canonicalize.Text;
            }

        public static DNSRecord_RT Parse(Parse Parse) {
			DNSRecord_RT NewRecord = new DNSRecord_RT () ;
			
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.Exchange = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteDomain (Exchange);
			//Encode.Domain  (Exchange);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_RT Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_RT NewRecord = new DNSRecord_RT () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.Exchange = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// SIG 24 Security signature
	//     See RFC2535

	public class DNSRecord_SIG : DNSRecord {

		public ushort   TypeCovered  ;
		public byte   Algorithm  ;
		public byte   Labels  ;
		public uint   OriginalTTL  ;
		public uint   SignatureExpiration  ;
		public uint   SignatureInception  ;
		public ushort   KeyTag  ;
		public string   SignersName  ;
		public byte[]   Signature  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.SIG);} }		
		public override string	Label {
			get {return ("SIG");} }	
		public override string	Description {
			get {return ("Security signature");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("SIG", Domain);
			Canonicalize.Int16  (TypeCovered);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Byte  (Labels);
			Canonicalize.Int32  (OriginalTTL);
			Canonicalize.Time32  (SignatureExpiration);
			Canonicalize.Time32  (SignatureInception);
			Canonicalize.Int16  (KeyTag);
			Canonicalize.String  (SignersName);
			Canonicalize.Binary  (Signature);
			return Canonicalize.Text;
            }

        public static DNSRecord_SIG Parse(Parse Parse) {
			DNSRecord_SIG NewRecord = new DNSRecord_SIG () ;
			
			NewRecord.TypeCovered = Parse.Int16  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.Labels = Parse.Byte  ();
			NewRecord.OriginalTTL = Parse.Int32  ();
			NewRecord.SignatureExpiration = Parse.Time32  ();
			NewRecord.SignatureInception = Parse.Time32  ();
			NewRecord.KeyTag = Parse.Int16  ();
			NewRecord.SignersName = Parse.String  ();
			NewRecord.Signature = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (TypeCovered);
			//Encode.Int16  (TypeCovered);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteByte (Labels);
			//Encode.Byte  (Labels);
			Index.WriteInt32 (OriginalTTL);
			//Encode.Int32  (OriginalTTL);
			Index.WriteInt32 (SignatureExpiration);
			//Encode.Time32  (SignatureExpiration);
			Index.WriteInt32 (SignatureInception);
			//Encode.Time32  (SignatureInception);
			Index.WriteInt16 (KeyTag);
			//Encode.Int16  (KeyTag);
			Index.WriteString8 (SignersName);
			//Encode.String  (SignersName);
			Index.WriteData (Signature);
			//Encode.Binary  (Signature);
            }

        // Convert from byte form
        public static  DNSRecord_SIG Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_SIG NewRecord = new DNSRecord_SIG () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.TypeCovered = Index.ReadInt16 ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.Labels = Index.ReadByte ();
			NewRecord.OriginalTTL = Index.ReadInt32 ();
			NewRecord.SignatureExpiration = Index.ReadTime32 ();
			NewRecord.SignatureInception = Index.ReadTime32 ();
			NewRecord.KeyTag = Index.ReadInt16 ();
			NewRecord.SignersName = Index.ReadString ();
			NewRecord.Signature = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// KEY 25 Security key
	//     See RFC2535

	public class DNSRecord_KEY : DNSRecord {

		public ushort   Flags  ;
		public byte   Protocol  ;
		public byte   Algorithm  ;
		public byte[]   PublicKey  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.KEY);} }		
		public override string	Label {
			get {return ("KEY");} }	
		public override string	Description {
			get {return ("Security key");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("KEY", Domain);
			Canonicalize.Int16  (Flags);
			Canonicalize.Byte  (Protocol);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Binary  (PublicKey);
			return Canonicalize.Text;
            }

        public static DNSRecord_KEY Parse(Parse Parse) {
			DNSRecord_KEY NewRecord = new DNSRecord_KEY () ;
			
			NewRecord.Flags = Parse.Int16  ();
			NewRecord.Protocol = Parse.Byte  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.PublicKey = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Flags);
			//Encode.Int16  (Flags);
			Index.WriteByte (Protocol);
			//Encode.Byte  (Protocol);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteData (PublicKey);
			//Encode.Binary  (PublicKey);
            }

        // Convert from byte form
        public static  DNSRecord_KEY Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_KEY NewRecord = new DNSRecord_KEY () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Flags = Index.ReadInt16 ();
			NewRecord.Protocol = Index.ReadByte ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.PublicKey = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// AAAA 28 IP6 Address
	//     See RFC3596

	public class DNSRecord_AAAA : DNSRecord {

		public IPAddress   Address  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.AAAA);} }		
		public override string	Label {
			get {return ("AAAA");} }	
		public override string	Description {
			get {return ("IP6 Address");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("AAAA", Domain);
			Canonicalize.IPv6  (Address);
			return Canonicalize.Text;
            }

        public static DNSRecord_AAAA Parse(Parse Parse) {
			DNSRecord_AAAA NewRecord = new DNSRecord_AAAA () ;
			
			NewRecord.Address = Parse.IPv6  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteIPv6 (Address);
			//Encode.IPv6  (Address);
            }

        // Convert from byte form
        public static  DNSRecord_AAAA Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_AAAA NewRecord = new DNSRecord_AAAA () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Address = Index.ReadIPv6 ();
			

			return NewRecord;
            }

		}

	// SRV 33 Server Selection
	//     See RFC2782

	public class DNSRecord_SRV : DNSRecord {

		public ushort   Priority  ;
		public ushort   Weight  ;
		public ushort   Port  ;
		public Domain   Target  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.SRV);} }		
		public override string	Label {
			get {return ("SRV");} }	
		public override string	Description {
			get {return ("Server Selection");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("SRV", Domain);
			Canonicalize.Int16  (Priority);
			Canonicalize.Int16  (Weight);
			Canonicalize.Int16  (Port);
			Canonicalize.Domain  (Target);
			return Canonicalize.Text;
            }

        public static DNSRecord_SRV Parse(Parse Parse) {
			DNSRecord_SRV NewRecord = new DNSRecord_SRV () ;
			
			NewRecord.Priority = Parse.Int16  ();
			NewRecord.Weight = Parse.Int16  ();
			NewRecord.Port = Parse.Int16  ();
			NewRecord.Target = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Priority);
			//Encode.Int16  (Priority);
			Index.WriteInt16 (Weight);
			//Encode.Int16  (Weight);
			Index.WriteInt16 (Port);
			//Encode.Int16  (Port);
			Index.WriteDomain (Target);
			//Encode.Domain  (Target);
            }

        // Convert from byte form
        public static  DNSRecord_SRV Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_SRV NewRecord = new DNSRecord_SRV () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Priority = Index.ReadInt16 ();
			NewRecord.Weight = Index.ReadInt16 ();
			NewRecord.Port = Index.ReadInt16 ();
			NewRecord.Target = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// NAPTR 35 Naming Authority Pointer
	//     See RFC2915,RFC2168,RFC3403

	public class DNSRecord_NAPTR : DNSRecord {

		public ushort   Order  ;
		public ushort   Preference  ;
		public string   Flags  ;
		public string   Services  ;
		public string   Regexp  ;
		public Domain   Replacement  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.NAPTR);} }		
		public override string	Label {
			get {return ("NAPTR");} }	
		public override string	Description {
			get {return ("Naming Authority Pointer");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("NAPTR", Domain);
			Canonicalize.Int16  (Order);
			Canonicalize.Int16  (Preference);
			Canonicalize.String  (Flags);
			Canonicalize.String  (Services);
			Canonicalize.String  (Regexp);
			Canonicalize.Domain  (Replacement);
			return Canonicalize.Text;
            }

        public static DNSRecord_NAPTR Parse(Parse Parse) {
			DNSRecord_NAPTR NewRecord = new DNSRecord_NAPTR () ;
			
			NewRecord.Order = Parse.Int16  ();
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.Flags = Parse.String  ();
			NewRecord.Services = Parse.String  ();
			NewRecord.Regexp = Parse.String  ();
			NewRecord.Replacement = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Order);
			//Encode.Int16  (Order);
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteString8 (Flags);
			//Encode.String  (Flags);
			Index.WriteString8 (Services);
			//Encode.String  (Services);
			Index.WriteString8 (Regexp);
			//Encode.String  (Regexp);
			Index.WriteDomain (Replacement);
			//Encode.Domain  (Replacement);
            }

        // Convert from byte form
        public static  DNSRecord_NAPTR Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_NAPTR NewRecord = new DNSRecord_NAPTR () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Order = Index.ReadInt16 ();
			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.Flags = Index.ReadString ();
			NewRecord.Services = Index.ReadString ();
			NewRecord.Regexp = Index.ReadString ();
			NewRecord.Replacement = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// KX 36 Key Exchanger
	//     See RFC2230

	public class DNSRecord_KX : DNSRecord {

		public ushort   Preference  ;
		public Domain   Exchange  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.KX);} }		
		public override string	Label {
			get {return ("KX");} }	
		public override string	Description {
			get {return ("Key Exchanger");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("KX", Domain);
			Canonicalize.Int16  (Preference);
			Canonicalize.Domain  (Exchange);
			return Canonicalize.Text;
            }

        public static DNSRecord_KX Parse(Parse Parse) {
			DNSRecord_KX NewRecord = new DNSRecord_KX () ;
			
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.Exchange = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteDomain (Exchange);
			//Encode.Domain  (Exchange);
            }

        // Convert from byte form
        public static  DNSRecord_KX Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_KX NewRecord = new DNSRecord_KX () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.Exchange = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// CERT 37 CERT
	//     See RFC4398

	public class DNSRecord_CERT : DNSRecord {

		public ushort   Type  ;
		public ushort   KeyTag  ;
		public byte   Algorithm  ;
		public byte[]   Certificate  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.CERT);} }		
		public override string	Label {
			get {return ("CERT");} }	
		public override string	Description {
			get {return ("CERT");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("CERT", Domain);
			Canonicalize.Int16  (Type);
			Canonicalize.Int16  (KeyTag);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Binary  (Certificate);
			return Canonicalize.Text;
            }

        public static DNSRecord_CERT Parse(Parse Parse) {
			DNSRecord_CERT NewRecord = new DNSRecord_CERT () ;
			
			NewRecord.Type = Parse.Int16  ();
			NewRecord.KeyTag = Parse.Int16  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.Certificate = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Type);
			//Encode.Int16  (Type);
			Index.WriteInt16 (KeyTag);
			//Encode.Int16  (KeyTag);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteData (Certificate);
			//Encode.Binary  (Certificate);
            }

        // Convert from byte form
        public static  DNSRecord_CERT Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_CERT NewRecord = new DNSRecord_CERT () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Type = Index.ReadInt16 ();
			NewRecord.KeyTag = Index.ReadInt16 ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.Certificate = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// DNAME 39 DNAME
	//     See RFC6672

	public class DNSRecord_DNAME : DNSRecord {

		public Domain   Target  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.DNAME);} }		
		public override string	Label {
			get {return ("DNAME");} }	
		public override string	Description {
			get {return ("DNAME");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("DNAME", Domain);
			Canonicalize.Domain  (Target);
			return Canonicalize.Text;
            }

        public static DNSRecord_DNAME Parse(Parse Parse) {
			DNSRecord_DNAME NewRecord = new DNSRecord_DNAME () ;
			
			NewRecord.Target = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (Target);
			//Encode.Domain  (Target);
            }

        // Convert from byte form
        public static  DNSRecord_DNAME Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_DNAME NewRecord = new DNSRecord_DNAME () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Target = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// OPT 41 OPT
	//     See RFC2671,RFC3225

	public class DNSRecord_OPT : DNSRecord {

		public List<DNSOption>   Options  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.OPT);} }		
		public override string	Label {
			get {return ("OPT");} }	
		public override string	Description {
			get {return ("OPT");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("OPT", Domain);
			return Canonicalize.Text;
            }

        public static DNSRecord_OPT Parse(Parse Parse) {
			DNSRecord_OPT NewRecord = new DNSRecord_OPT () ;
			

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			//Encode.  ();
			foreach (DNSOption opt in Options) {
				Index.WriteInt16 (opt.Code);
				Index.WriteInt16 (opt.Data.Length);
				Index.WriteData (opt.Data);
				}
			//Encode.  (Options);
            }

        // Convert from byte form
        public static  DNSRecord_OPT Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_OPT NewRecord = new DNSRecord_OPT () ;
			NewRecord.Start = Index.Pointer;

			

			return NewRecord;
            }

		}

	// DS 43 Delegation Signer
	//     See RFC4034,RFC3658

	public class DNSRecord_DS : DNSRecord {

		public ushort   KeyTag  ;
		public byte   Algorithm  ;
		public byte   DigestType  ;
		public byte[]   Digest  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.DS);} }		
		public override string	Label {
			get {return ("DS");} }	
		public override string	Description {
			get {return ("Delegation Signer");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("DS", Domain);
			Canonicalize.Int16  (KeyTag);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Byte  (DigestType);
			Canonicalize.Hex  (Digest);
			return Canonicalize.Text;
            }

        public static DNSRecord_DS Parse(Parse Parse) {
			DNSRecord_DS NewRecord = new DNSRecord_DS () ;
			
			NewRecord.KeyTag = Parse.Int16  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.DigestType = Parse.Byte  ();
			NewRecord.Digest = Parse.Hex  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (KeyTag);
			//Encode.Int16  (KeyTag);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteByte (DigestType);
			//Encode.Byte  (DigestType);
			Index.WriteData (Digest);
			//Encode.Hex  (Digest);
            }

        // Convert from byte form
        public static  DNSRecord_DS Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_DS NewRecord = new DNSRecord_DS () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.KeyTag = Index.ReadInt16 ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.DigestType = Index.ReadByte ();
			NewRecord.Digest = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// SSHFP 44 SSH Key Fingerprint
	//     See RFC4255

	public class DNSRecord_SSHFP : DNSRecord {

		public byte   Algorithm  ;
		public byte   FPType  ;
		public byte[]   Fingerprint  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.SSHFP);} }		
		public override string	Label {
			get {return ("SSHFP");} }	
		public override string	Description {
			get {return ("SSH Key Fingerprint");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("SSHFP", Domain);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Byte  (FPType);
			Canonicalize.Hex  (Fingerprint);
			return Canonicalize.Text;
            }

        public static DNSRecord_SSHFP Parse(Parse Parse) {
			DNSRecord_SSHFP NewRecord = new DNSRecord_SSHFP () ;
			
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.FPType = Parse.Byte  ();
			NewRecord.Fingerprint = Parse.Hex  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteByte (FPType);
			//Encode.Byte  (FPType);
			Index.WriteData (Fingerprint);
			//Encode.Hex  (Fingerprint);
            }

        // Convert from byte form
        public static  DNSRecord_SSHFP Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_SSHFP NewRecord = new DNSRecord_SSHFP () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.FPType = Index.ReadByte ();
			NewRecord.Fingerprint = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// IPSECKEY 45 IPSECKEY
	//     See RFC4025

	public class DNSRecord_IPSECKEY : DNSRecord {

		public byte   Precedence  ;
		public byte   GatewayType  ;
		public byte   Algorithm  ;
		public DNSGateway   Gateway  ;
		public byte[]   PublicKey  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.IPSECKEY);} }		
		public override string	Label {
			get {return ("IPSECKEY");} }	
		public override string	Description {
			get {return ("IPSECKEY");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("IPSECKEY", Domain);
			Canonicalize.Byte  (Precedence);
			Canonicalize.Byte  (GatewayType);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Binary  (PublicKey);
			return Canonicalize.Text;
            }

        public static DNSRecord_IPSECKEY Parse(Parse Parse) {
			DNSRecord_IPSECKEY NewRecord = new DNSRecord_IPSECKEY () ;
			
			NewRecord.Precedence = Parse.Byte  ();
			NewRecord.GatewayType = Parse.Byte  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.PublicKey = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteByte (Precedence);
			//Encode.Byte  (Precedence);
			Index.WriteByte (GatewayType);
			//Encode.Byte  (GatewayType);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			//Encode.  (Gateway);
			Index.WriteData (PublicKey);
			//Encode.Binary  (PublicKey);
            }

        // Convert from byte form
        public static  DNSRecord_IPSECKEY Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_IPSECKEY NewRecord = new DNSRecord_IPSECKEY () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Precedence = Index.ReadByte ();
			NewRecord.GatewayType = Index.ReadByte ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.PublicKey = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// RRSIG 46 RRSIG
	//     See RFC4034,RFC3755

	public class DNSRecord_RRSIG : DNSRecord {

		public ushort   TypeCovered  ;
		public byte   Algorithm  ;
		public byte   Labels  ;
		public uint   OriginalTTL  ;
		public uint   SignatureExpiration  ;
		public uint   SignatureInception  ;
		public ushort   KeyTag  ;
		public string   SignersName  ;
		public byte[]   Signature  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.RRSIG);} }		
		public override string	Label {
			get {return ("RRSIG");} }	
		public override string	Description {
			get {return ("RRSIG");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("RRSIG", Domain);
			Canonicalize.Int16  (TypeCovered);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Byte  (Labels);
			Canonicalize.Int32  (OriginalTTL);
			Canonicalize.Time32  (SignatureExpiration);
			Canonicalize.Time32  (SignatureInception);
			Canonicalize.Int16  (KeyTag);
			Canonicalize.String  (SignersName);
			Canonicalize.Binary  (Signature);
			return Canonicalize.Text;
            }

        public static DNSRecord_RRSIG Parse(Parse Parse) {
			DNSRecord_RRSIG NewRecord = new DNSRecord_RRSIG () ;
			
			NewRecord.TypeCovered = Parse.Int16  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.Labels = Parse.Byte  ();
			NewRecord.OriginalTTL = Parse.Int32  ();
			NewRecord.SignatureExpiration = Parse.Time32  ();
			NewRecord.SignatureInception = Parse.Time32  ();
			NewRecord.KeyTag = Parse.Int16  ();
			NewRecord.SignersName = Parse.String  ();
			NewRecord.Signature = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (TypeCovered);
			//Encode.Int16  (TypeCovered);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteByte (Labels);
			//Encode.Byte  (Labels);
			Index.WriteInt32 (OriginalTTL);
			//Encode.Int32  (OriginalTTL);
			Index.WriteInt32 (SignatureExpiration);
			//Encode.Time32  (SignatureExpiration);
			Index.WriteInt32 (SignatureInception);
			//Encode.Time32  (SignatureInception);
			Index.WriteInt16 (KeyTag);
			//Encode.Int16  (KeyTag);
			Index.WriteString8 (SignersName);
			//Encode.String  (SignersName);
			Index.WriteData (Signature);
			//Encode.Binary  (Signature);
            }

        // Convert from byte form
        public static  DNSRecord_RRSIG Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_RRSIG NewRecord = new DNSRecord_RRSIG () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.TypeCovered = Index.ReadInt16 ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.Labels = Index.ReadByte ();
			NewRecord.OriginalTTL = Index.ReadInt32 ();
			NewRecord.SignatureExpiration = Index.ReadTime32 ();
			NewRecord.SignatureInception = Index.ReadTime32 ();
			NewRecord.KeyTag = Index.ReadInt16 ();
			NewRecord.SignersName = Index.ReadString ();
			NewRecord.Signature = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// NSEC 47 NSEC
	//     See RFC4034,RFC3755

	public class DNSRecord_NSEC : DNSRecord {

		public Domain   NextDomain  ;
		public byte[]   TypeBitMaps  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.NSEC);} }		
		public override string	Label {
			get {return ("NSEC");} }	
		public override string	Description {
			get {return ("NSEC");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("NSEC", Domain);
			Canonicalize.Domain  (NextDomain);
			Canonicalize.Binary  (TypeBitMaps);
			return Canonicalize.Text;
            }

        public static DNSRecord_NSEC Parse(Parse Parse) {
			DNSRecord_NSEC NewRecord = new DNSRecord_NSEC () ;
			
			NewRecord.NextDomain = Parse.Domain  ();
			NewRecord.TypeBitMaps = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (NextDomain);
			//Encode.Domain  (NextDomain);
			Index.WriteData (TypeBitMaps);
			//Encode.Binary  (TypeBitMaps);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_NSEC Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_NSEC NewRecord = new DNSRecord_NSEC () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.NextDomain = Index.ReadDomain ();
			NewRecord.TypeBitMaps = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// DNSKEY 48 DNSKEY
	//     See RFC4034,RFC3755

	public class DNSRecord_DNSKEY : DNSRecord {

		public ushort   Flags  ;
		public byte   Protocol  ;
		public byte   Algorithm  ;
		public byte[]   PublicKey  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.DNSKEY);} }		
		public override string	Label {
			get {return ("DNSKEY");} }	
		public override string	Description {
			get {return ("DNSKEY");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("DNSKEY", Domain);
			Canonicalize.Int16  (Flags);
			Canonicalize.Byte  (Protocol);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Binary  (PublicKey);
			return Canonicalize.Text;
            }

        public static DNSRecord_DNSKEY Parse(Parse Parse) {
			DNSRecord_DNSKEY NewRecord = new DNSRecord_DNSKEY () ;
			
			NewRecord.Flags = Parse.Int16  ();
			NewRecord.Protocol = Parse.Byte  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.PublicKey = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Flags);
			//Encode.Int16  (Flags);
			Index.WriteByte (Protocol);
			//Encode.Byte  (Protocol);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteData (PublicKey);
			//Encode.Binary  (PublicKey);
            }

        // Convert from byte form
        public static  DNSRecord_DNSKEY Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_DNSKEY NewRecord = new DNSRecord_DNSKEY () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Flags = Index.ReadInt16 ();
			NewRecord.Protocol = Index.ReadByte ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.PublicKey = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// DHCID 49 DHCID
	//     See RFC4701

	public class DNSRecord_DHCID : DNSRecord {

		public byte[]   Identifier  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.DHCID);} }		
		public override string	Label {
			get {return ("DHCID");} }	
		public override string	Description {
			get {return ("DHCID");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("DHCID", Domain);
			Canonicalize.Binary  (Identifier);
			return Canonicalize.Text;
            }

        public static DNSRecord_DHCID Parse(Parse Parse) {
			DNSRecord_DHCID NewRecord = new DNSRecord_DHCID () ;
			
			NewRecord.Identifier = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteData (Identifier);
			//Encode.Binary  (Identifier);
            }

        // Convert from byte form
        public static  DNSRecord_DHCID Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_DHCID NewRecord = new DNSRecord_DHCID () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Identifier = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// NSEC3 50 NSEC3
	//     See RFC5155

	public class DNSRecord_NSEC3 : DNSRecord {

		public byte   HashAlgorithm  ;
		public byte   Flags  ;
		public ushort   Iterations  ;
		public byte[]   Salt  ;
		public byte[]   NextHashedOwnerName  ;
		public byte[]   TypeBitMaps  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.NSEC3);} }		
		public override string	Label {
			get {return ("NSEC3");} }	
		public override string	Description {
			get {return ("NSEC3");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("NSEC3", Domain);
			Canonicalize.Byte  (HashAlgorithm);
			Canonicalize.Byte  (Flags);
			Canonicalize.Int16  (Iterations);
			Canonicalize.Binary8  (Salt);
			Canonicalize.Binary8  (NextHashedOwnerName);
			Canonicalize.Binary  (TypeBitMaps);
			return Canonicalize.Text;
            }

        public static DNSRecord_NSEC3 Parse(Parse Parse) {
			DNSRecord_NSEC3 NewRecord = new DNSRecord_NSEC3 () ;
			
			NewRecord.HashAlgorithm = Parse.Byte  ();
			NewRecord.Flags = Parse.Byte  ();
			NewRecord.Iterations = Parse.Int16  ();
			NewRecord.Salt = Parse.Binary8  ();
			NewRecord.NextHashedOwnerName = Parse.Binary8  ();
			NewRecord.TypeBitMaps = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteByte (HashAlgorithm);
			//Encode.Byte  (HashAlgorithm);
			Index.WriteByte (Flags);
			//Encode.Byte  (Flags);
			Index.WriteInt16 (Iterations);
			//Encode.Int16  (Iterations);
			Index.WriteByte ((byte)Salt.Length);
			Index.WriteData (Salt);
			//Encode.Binary8  (Salt);
			Index.WriteByte ((byte)NextHashedOwnerName.Length);
			Index.WriteData (NextHashedOwnerName);
			//Encode.Binary8  (NextHashedOwnerName);
			Index.WriteData (TypeBitMaps);
			//Encode.Binary  (TypeBitMaps);
            }

        // Convert from byte form
        public static  DNSRecord_NSEC3 Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_NSEC3 NewRecord = new DNSRecord_NSEC3 () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.HashAlgorithm = Index.ReadByte ();
			NewRecord.Flags = Index.ReadByte ();
			NewRecord.Iterations = Index.ReadInt16 ();
			{
			int FieldLength = Index.ReadByte ();
			NewRecord.Salt = Index.ReadData (FieldLength);
			}
			{
			int FieldLength = Index.ReadByte ();
			NewRecord.NextHashedOwnerName = Index.ReadData (FieldLength);
			}
			NewRecord.TypeBitMaps = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// NSEC3PARAM 51 NSEC3PARAM
	//     See RFC5155

	public class DNSRecord_NSEC3PARAM : DNSRecord {

		public byte   HashAlgorithm  ;
		public byte   Flags  ;
		public ushort   Iterations  ;
		public byte[]   Salt  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.NSEC3PARAM);} }		
		public override string	Label {
			get {return ("NSEC3PARAM");} }	
		public override string	Description {
			get {return ("NSEC3PARAM");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("NSEC3PARAM", Domain);
			Canonicalize.Byte  (HashAlgorithm);
			Canonicalize.Byte  (Flags);
			Canonicalize.Int16  (Iterations);
			Canonicalize.Binary8  (Salt);
			return Canonicalize.Text;
            }

        public static DNSRecord_NSEC3PARAM Parse(Parse Parse) {
			DNSRecord_NSEC3PARAM NewRecord = new DNSRecord_NSEC3PARAM () ;
			
			NewRecord.HashAlgorithm = Parse.Byte  ();
			NewRecord.Flags = Parse.Byte  ();
			NewRecord.Iterations = Parse.Int16  ();
			NewRecord.Salt = Parse.Binary8  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteByte (HashAlgorithm);
			//Encode.Byte  (HashAlgorithm);
			Index.WriteByte (Flags);
			//Encode.Byte  (Flags);
			Index.WriteInt16 (Iterations);
			//Encode.Int16  (Iterations);
			Index.WriteByte ((byte)Salt.Length);
			Index.WriteData (Salt);
			//Encode.Binary8  (Salt);
            }

        // Convert from byte form
        public static  DNSRecord_NSEC3PARAM Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_NSEC3PARAM NewRecord = new DNSRecord_NSEC3PARAM () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.HashAlgorithm = Index.ReadByte ();
			NewRecord.Flags = Index.ReadByte ();
			NewRecord.Iterations = Index.ReadInt16 ();
			{
			int FieldLength = Index.ReadByte ();
			NewRecord.Salt = Index.ReadData (FieldLength);
			}
			

			return NewRecord;
            }

		}

	// TLSA 52 TLSA
	//     See RFC6698

	public class DNSRecord_TLSA : DNSRecord {

		public byte   CertificateUsage  ;
		public byte   Selector  ;
		public byte   MatchingType  ;
		public byte[]   Certificate  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.TLSA);} }		
		public override string	Label {
			get {return ("TLSA");} }	
		public override string	Description {
			get {return ("TLSA");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("TLSA", Domain);
			Canonicalize.Byte  (CertificateUsage);
			Canonicalize.Byte  (Selector);
			Canonicalize.Byte  (MatchingType);
			Canonicalize.Binary  (Certificate);
			return Canonicalize.Text;
            }

        public static DNSRecord_TLSA Parse(Parse Parse) {
			DNSRecord_TLSA NewRecord = new DNSRecord_TLSA () ;
			
			NewRecord.CertificateUsage = Parse.Byte  ();
			NewRecord.Selector = Parse.Byte  ();
			NewRecord.MatchingType = Parse.Byte  ();
			NewRecord.Certificate = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteByte (CertificateUsage);
			//Encode.Byte  (CertificateUsage);
			Index.WriteByte (Selector);
			//Encode.Byte  (Selector);
			Index.WriteByte (MatchingType);
			//Encode.Byte  (MatchingType);
			Index.WriteData (Certificate);
			//Encode.Binary  (Certificate);
            }

        // Convert from byte form
        public static  DNSRecord_TLSA Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_TLSA NewRecord = new DNSRecord_TLSA () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.CertificateUsage = Index.ReadByte ();
			NewRecord.Selector = Index.ReadByte ();
			NewRecord.MatchingType = Index.ReadByte ();
			NewRecord.Certificate = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// HIP 55 Host Identity Protocol
	//     See RFC5205

	public class DNSRecord_HIP : DNSRecord {

		public byte   HITLength  ;
		public byte   PublicKeyAlgorithm  ;
		public ushort   PublicKeyLength  ;
		public byte[]   HIT  ;
		public byte[]   PublicKey  ;
		public byte[]   RendezvousServers  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.HIP);} }		
		public override string	Label {
			get {return ("HIP");} }	
		public override string	Description {
			get {return ("Host Identity Protocol");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("HIP", Domain);
			Canonicalize.Byte  (HITLength);
			Canonicalize.Byte  (PublicKeyAlgorithm);
			Canonicalize.Int16  (PublicKeyLength);
			Canonicalize.LBinary  (HIT);
			Canonicalize.LBinary  (PublicKey);
			Canonicalize.Binary  (RendezvousServers);
			return Canonicalize.Text;
            }

        public static DNSRecord_HIP Parse(Parse Parse) {
			DNSRecord_HIP NewRecord = new DNSRecord_HIP () ;
			
			NewRecord.HITLength = Parse.Byte  ();
			NewRecord.PublicKeyAlgorithm = Parse.Byte  ();
			NewRecord.PublicKeyLength = Parse.Int16  ();
			NewRecord.HIT = Parse.LBinary  ();
			NewRecord.PublicKey = Parse.LBinary  ();
			NewRecord.RendezvousServers = Parse.Binary  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			//Encode.Byte  (HITLength);
			Index.WriteByte (PublicKeyAlgorithm);
			//Encode.Byte  (PublicKeyAlgorithm);
			//Encode.Int16  (PublicKeyLength);
			Index.Write (HITLength);
			Index.WriteData (HIT);
			//Encode.LBinary  (HIT);
			Index.Write (PublicKeyLength);
			Index.WriteData (PublicKey);
			//Encode.LBinary  (PublicKey);
			Index.WriteData (RendezvousServers);
			//Encode.Binary  (RendezvousServers);
            }

        // Convert from byte form
        public static  DNSRecord_HIP Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_HIP NewRecord = new DNSRecord_HIP () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.HITLength = Index.ReadByte ();
			NewRecord.PublicKeyAlgorithm = Index.ReadByte ();
			NewRecord.PublicKeyLength = Index.ReadInt16 ();
			// Binary - length specified by HITLength
			// Binary - length specified by PublicKeyLength
			NewRecord.RendezvousServers = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// SPF 99 Sender Policy Framework
	//     See RFC4408

	public class DNSRecord_SPF : DNSRecord {

		public List<string>   Text  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.SPF);} }		
		public override string	Label {
			get {return ("SPF");} }	
		public override string	Description {
			get {return ("Sender Policy Framework");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("SPF", Domain);
			Canonicalize.Strings  (Text);
			return Canonicalize.Text;
            }

        public static DNSRecord_SPF Parse(Parse Parse) {
			DNSRecord_SPF NewRecord = new DNSRecord_SPF () ;
			
			NewRecord.Text = Parse.Strings  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			foreach (string s in Text) {
				Index.WriteString8 (s);
				}
			//Encode.Strings  (Text);
            }

        // Convert from byte form
        public static  DNSRecord_SPF Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_SPF NewRecord = new DNSRecord_SPF () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Text = Index.ReadStrings (Length - (Index.Pointer - NewRecord.Start)) ;
			

			return NewRecord;
            }

		}

	// NID 104 
	//     See RFC6742

	public class DNSRecord_NID : DNSRecord {

		public ushort   Preference  ;
		public ulong   NodeID  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.NID);} }		
		public override string	Label {
			get {return ("NID");} }	
		public override string	Description {
			get {return ("");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("NID", Domain);
			Canonicalize.Int16  (Preference);
			Canonicalize.NodeID  (NodeID);
			return Canonicalize.Text;
            }

        public static DNSRecord_NID Parse(Parse Parse) {
			DNSRecord_NID NewRecord = new DNSRecord_NID () ;
			
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.NodeID = Parse.NodeID  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteInt64 (NodeID);
			//Encode.NodeID  (NodeID);
            }

        // Convert from byte form
        public static  DNSRecord_NID Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_NID NewRecord = new DNSRecord_NID () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.NodeID = Index.ReadNodeID ();
			

			return NewRecord;
            }

		}

	// L32 105 
	//     See RFC6742

	public class DNSRecord_L32 : DNSRecord {

		public ushort   Preference  ;
		public IPAddress   Locator  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.L32);} }		
		public override string	Label {
			get {return ("L32");} }	
		public override string	Description {
			get {return ("");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("L32", Domain);
			Canonicalize.Int16  (Preference);
			Canonicalize.IPv4  (Locator);
			return Canonicalize.Text;
            }

        public static DNSRecord_L32 Parse(Parse Parse) {
			DNSRecord_L32 NewRecord = new DNSRecord_L32 () ;
			
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.Locator = Parse.IPv4  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteIPv4 (Locator);
			//Encode.IPv4  (Locator);
            }

        // Convert from byte form
        public static  DNSRecord_L32 Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_L32 NewRecord = new DNSRecord_L32 () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.Locator = Index.ReadIPv4 ();
			

			return NewRecord;
            }

		}

	// L64 106 
	//     See RFC6742

	public class DNSRecord_L64 : DNSRecord {

		public ushort   Preference  ;
		public ulong   Locator  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.L64);} }		
		public override string	Label {
			get {return ("L64");} }	
		public override string	Description {
			get {return ("");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("L64", Domain);
			Canonicalize.Int16  (Preference);
			Canonicalize.NodeID  (Locator);
			return Canonicalize.Text;
            }

        public static DNSRecord_L64 Parse(Parse Parse) {
			DNSRecord_L64 NewRecord = new DNSRecord_L64 () ;
			
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.Locator = Parse.NodeID  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteInt64 (Locator);
			//Encode.NodeID  (Locator);
            }

        // Convert from byte form
        public static  DNSRecord_L64 Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_L64 NewRecord = new DNSRecord_L64 () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.Locator = Index.ReadNodeID ();
			

			return NewRecord;
            }

		}

	// LP 107 
	//     See RFC6742

	public class DNSRecord_LP : DNSRecord {

		public ushort   Preference  ;
		public Domain   FQDN  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.LP);} }		
		public override string	Label {
			get {return ("LP");} }	
		public override string	Description {
			get {return ("");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("LP", Domain);
			Canonicalize.Int16  (Preference);
			Canonicalize.Domain  (FQDN);
			return Canonicalize.Text;
            }

        public static DNSRecord_LP Parse(Parse Parse) {
			DNSRecord_LP NewRecord = new DNSRecord_LP () ;
			
			NewRecord.Preference = Parse.Int16  ();
			NewRecord.FQDN = Parse.Domain  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Preference);
			//Encode.Int16  (Preference);
			Index.WriteDomain (FQDN);
			//Encode.Domain  (FQDN);
            }

        // Convert from byte form
        public static  DNSRecord_LP Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_LP NewRecord = new DNSRecord_LP () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Preference = Index.ReadInt16 ();
			NewRecord.FQDN = Index.ReadDomain ();
			

			return NewRecord;
            }

		}

	// TKEY 249 Transaction Key
	//     See RFC2930

	public class DNSRecord_TKEY : DNSRecord {

		public Domain   Algorithm  ;
		public uint   Inception  ;
		public uint   Expiration  ;
		public ushort   Mode  ;
		public ushort   Error  ;
		public byte[]   KeyData  ;
		public byte[]   OtherData  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.TKEY);} }		
		public override string	Label {
			get {return ("TKEY");} }	
		public override string	Description {
			get {return ("Transaction Key");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("TKEY", Domain);
			Canonicalize.Domain  (Algorithm);
			Canonicalize.Time32  (Inception);
			Canonicalize.Time32  (Expiration);
			Canonicalize.Int16  (Mode);
			Canonicalize.Int16  (Error);
			Canonicalize.Binary16  (KeyData);
			Canonicalize.Binary16  (OtherData);
			return Canonicalize.Text;
            }

        public static DNSRecord_TKEY Parse(Parse Parse) {
			DNSRecord_TKEY NewRecord = new DNSRecord_TKEY () ;
			
			NewRecord.Algorithm = Parse.Domain  ();
			NewRecord.Inception = Parse.Time32  ();
			NewRecord.Expiration = Parse.Time32  ();
			NewRecord.Mode = Parse.Int16  ();
			NewRecord.Error = Parse.Int16  ();
			NewRecord.KeyData = Parse.Binary16  ();
			NewRecord.OtherData = Parse.Binary16  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (Algorithm);
			//Encode.Domain  (Algorithm);
			Index.WriteInt32 (Inception);
			//Encode.Time32  (Inception);
			Index.WriteInt32 (Expiration);
			//Encode.Time32  (Expiration);
			Index.WriteInt16 (Mode);
			//Encode.Int16  (Mode);
			Index.WriteInt16 (Error);
			//Encode.Int16  (Error);
			Index.WriteInt16 (KeyData.Length);
			Index.WriteData (KeyData);
			//Encode.Binary16  (KeyData);
			Index.WriteInt16 (OtherData.Length);
			Index.WriteData (OtherData);
			//Encode.Binary16  (OtherData);
            }

        // Convert from byte form
        public static  DNSRecord_TKEY Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_TKEY NewRecord = new DNSRecord_TKEY () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Algorithm = Index.ReadDomain ();
			NewRecord.Inception = Index.ReadTime32 ();
			NewRecord.Expiration = Index.ReadTime32 ();
			NewRecord.Mode = Index.ReadInt16 ();
			NewRecord.Error = Index.ReadInt16 ();
			{
			int FieldLength = Index.ReadInt16 ();
			NewRecord.KeyData = Index.ReadData (FieldLength);
			}
			{
			int FieldLength = Index.ReadInt16 ();
			NewRecord.OtherData = Index.ReadData (FieldLength);
			}
			

			return NewRecord;
            }

		}

	// TSIG 250 Transaction Signature
	//     See RFC2845

	public class DNSRecord_TSIG : DNSRecord {

		public Domain   Algorithm  ;
		public ulong   TimeSigned  ;
		public ushort   Fudge  ;
		public byte[]   MAC  ;
		public ushort   OriginalID  ;
		public ushort   Error  ;
		public byte[]   OtherData  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.TSIG);} }		
		public override string	Label {
			get {return ("TSIG");} }	
		public override string	Description {
			get {return ("Transaction Signature");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("TSIG", Domain);
			Canonicalize.Domain  (Algorithm);
			Canonicalize.Time48  (TimeSigned);
			Canonicalize.Int16  (Fudge);
			Canonicalize.Binary16  (MAC);
			Canonicalize.Int16  (OriginalID);
			Canonicalize.Int16  (Error);
			Canonicalize.Binary16  (OtherData);
			return Canonicalize.Text;
            }

        public static DNSRecord_TSIG Parse(Parse Parse) {
			DNSRecord_TSIG NewRecord = new DNSRecord_TSIG () ;
			
			NewRecord.Algorithm = Parse.Domain  ();
			NewRecord.TimeSigned = Parse.Time48  ();
			NewRecord.Fudge = Parse.Int16  ();
			NewRecord.MAC = Parse.Binary16  ();
			NewRecord.OriginalID = Parse.Int16  ();
			NewRecord.Error = Parse.Int16  ();
			NewRecord.OtherData = Parse.Binary16  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteDomain (Algorithm);
			//Encode.Domain  (Algorithm);
			Index.WriteInt48 (TimeSigned);
			//Encode.Time48  (TimeSigned);
			Index.WriteInt16 (Fudge);
			//Encode.Int16  (Fudge);
			Index.WriteInt16 (MAC.Length);
			Index.WriteData (MAC);
			//Encode.Binary16  (MAC);
			Index.WriteInt16 (OriginalID);
			//Encode.Int16  (OriginalID);
			Index.WriteInt16 (Error);
			//Encode.Int16  (Error);
			Index.WriteInt16 (OtherData.Length);
			Index.WriteData (OtherData);
			//Encode.Binary16  (OtherData);
            }

        // Convert from byte form
        public static  DNSRecord_TSIG Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_TSIG NewRecord = new DNSRecord_TSIG () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Algorithm = Index.ReadDomain ();
			NewRecord.TimeSigned = Index.ReadTime48 ();
			NewRecord.Fudge = Index.ReadInt16 ();
			{
			int FieldLength = Index.ReadInt16 ();
			NewRecord.MAC = Index.ReadData (FieldLength);
			}
			NewRecord.OriginalID = Index.ReadInt16 ();
			NewRecord.Error = Index.ReadInt16 ();
			{
			int FieldLength = Index.ReadInt16 ();
			NewRecord.OtherData = Index.ReadData (FieldLength);
			}
			

			return NewRecord;
            }

		}

	// URI 256 URI
	//     See Patrik_Faltstrom

	public class DNSRecord_URI : DNSRecord {

		public ushort   Priority  ;
		public ushort   Weight  ;
		public List<string>   Target  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.URI);} }		
		public override string	Label {
			get {return ("URI");} }	
		public override string	Description {
			get {return ("URI");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("URI", Domain);
			Canonicalize.Int16  (Priority);
			Canonicalize.Int16  (Weight);
			Canonicalize.Strings  (Target);
			return Canonicalize.Text;
            }

        public static DNSRecord_URI Parse(Parse Parse) {
			DNSRecord_URI NewRecord = new DNSRecord_URI () ;
			
			NewRecord.Priority = Parse.Int16  ();
			NewRecord.Weight = Parse.Int16  ();
			NewRecord.Target = Parse.Strings  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (Priority);
			//Encode.Int16  (Priority);
			Index.WriteInt16 (Weight);
			//Encode.Int16  (Weight);
			foreach (string s in Target) {
				Index.WriteString8 (s);
				}
			//Encode.Strings  (Target);
            }

        // Convert from byte form
        public static  DNSRecord_URI Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_URI NewRecord = new DNSRecord_URI () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Priority = Index.ReadInt16 ();
			NewRecord.Weight = Index.ReadInt16 ();
			NewRecord.Target = Index.ReadStrings (Length - (Index.Pointer - NewRecord.Start)) ;
			

			return NewRecord;
            }

		}

	// CAA 257 Certification Authority Restriction
	//     See RFC-ietf-pkix-caa-15

	public class DNSRecord_CAA : DNSRecord {

		public byte   Flags  ;
		public string   Tag  ;
		public string   Value  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.CAA);} }		
		public override string	Label {
			get {return ("CAA");} }	
		public override string	Description {
			get {return ("Certification Authority Restriction");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("CAA", Domain);
			Canonicalize.Byte  (Flags);
			Canonicalize.String  (Tag);
			Canonicalize.StringX  (Value);
			return Canonicalize.Text;
            }

        public static DNSRecord_CAA Parse(Parse Parse) {
			DNSRecord_CAA NewRecord = new DNSRecord_CAA () ;
			
			NewRecord.Flags = Parse.Byte  ();
			NewRecord.Tag = Parse.String  ();
			NewRecord.Value = Parse.StringX  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteByte (Flags);
			//Encode.Byte  (Flags);
			Index.WriteString8 (Tag);
			//Encode.String  (Tag);
			Index.WriteString (Value);
			//Encode.StringX  (Value);
            }

        // Convert from byte form
        public static  DNSRecord_CAA Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_CAA NewRecord = new DNSRecord_CAA () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.Flags = Index.ReadByte ();
			NewRecord.Tag = Index.ReadString ();
			NewRecord.Value = Index.ReadString (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// TA 32768 DNSSEC Trust Authorities
	//     See Sam_Weiler

	public class DNSRecord_TA : DNSRecord {

		public ushort   KeyTag  ;
		public byte   Algorithm  ;
		public byte   DigestType  ;
		public byte[]   Digest  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.TA);} }		
		public override string	Label {
			get {return ("TA");} }	
		public override string	Description {
			get {return ("DNSSEC Trust Authorities");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("TA", Domain);
			Canonicalize.Int16  (KeyTag);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Byte  (DigestType);
			Canonicalize.Hex  (Digest);
			return Canonicalize.Text;
            }

        public static DNSRecord_TA Parse(Parse Parse) {
			DNSRecord_TA NewRecord = new DNSRecord_TA () ;
			
			NewRecord.KeyTag = Parse.Int16  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.DigestType = Parse.Byte  ();
			NewRecord.Digest = Parse.Hex  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (KeyTag);
			//Encode.Int16  (KeyTag);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteByte (DigestType);
			//Encode.Byte  (DigestType);
			Index.WriteData (Digest);
			//Encode.Hex  (Digest);
			//Encode.  ();
            }

        // Convert from byte form
        public static  DNSRecord_TA Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_TA NewRecord = new DNSRecord_TA () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.KeyTag = Index.ReadInt16 ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.DigestType = Index.ReadByte ();
			NewRecord.Digest = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	// DLV 32769 DNSSEC Lookaside Validation
	//     See RFC4431

	public class DNSRecord_DLV : DNSRecord {

		public ushort   KeyTag  ;
		public byte   Algorithm  ;
		public byte   DigestType  ;
		public byte[]   Digest  ;

		public override DNSTypeCode		Code {
			get {return (DNSTypeCode.DLV);} }		
		public override string	Label {
			get {return ("DLV");} }	
		public override string	Description {
			get {return ("DNSSEC Lookaside Validation");} }

        // Convert to canonical form
        public override string Canonical () {
			Canonicalize Canonicalize = new Canonicalize ("DLV", Domain);
			Canonicalize.Int16  (KeyTag);
			Canonicalize.Byte  (Algorithm);
			Canonicalize.Byte  (DigestType);
			Canonicalize.Hex  (Digest);
			return Canonicalize.Text;
            }

        public static DNSRecord_DLV Parse(Parse Parse) {
			DNSRecord_DLV NewRecord = new DNSRecord_DLV () ;
			
			NewRecord.KeyTag = Parse.Int16  ();
			NewRecord.Algorithm = Parse.Byte  ();
			NewRecord.DigestType = Parse.Byte  ();
			NewRecord.Digest = Parse.Hex  ();

			return NewRecord;
            }

        // Convert to byte form
        public override void Encode(DNSBufferIndex Index) {
			//Encode Encode = new Encode ();
			Index.WriteInt16 (KeyTag);
			//Encode.Int16  (KeyTag);
			Index.WriteByte (Algorithm);
			//Encode.Byte  (Algorithm);
			Index.WriteByte (DigestType);
			//Encode.Byte  (DigestType);
			Index.WriteData (Digest);
			//Encode.Hex  (Digest);
            }

        // Convert from byte form
        public static  DNSRecord_DLV Decode (DNSBufferIndex Index, int Length) {
			DNSRecord_DLV NewRecord = new DNSRecord_DLV () ;
			NewRecord.Start = Index.Pointer;

			NewRecord.KeyTag = Index.ReadInt16 ();
			NewRecord.Algorithm = Index.ReadByte ();
			NewRecord.DigestType = Index.ReadByte ();
			NewRecord.Digest = Index.ReadData (Length - (Index.Pointer - NewRecord.Start));
			

			return NewRecord;
            }

		}

	}


