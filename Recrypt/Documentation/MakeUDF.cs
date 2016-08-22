// #using System.Text 
using  System.Text;
// #using Goedel.Recrypt 
using  Goedel.Recrypt;
// #using Goedel.Protocol 
using  Goedel.Protocol;
// #pclass ExampleGenerator ExampleGeneratorUDF 
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGeneratorUDF : global::Goedel.Registry.Script {
		public ExampleGeneratorUDF () : base () {
			}
		public ExampleGeneratorUDF (TextWriter Output) : base (Output) {
			}

		//  
		//  
		// #method UDFExamplesWeb CreateExamples Example 
		

		//
		// UDFExamplesWeb
		//
		public void UDFExamplesWeb (CreateExamples Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####V5 Fingerprint calculation and presentation 
			_Output.Write ("##V5 Fingerprint calculation and presentation\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A V5 fingerprint value is a sequence of bits that provides a sufficiently  
			_Output.Write ("A V5 fingerprint value is a sequence of bits that provides a sufficiently \n{0}", _Indent);
			// unique identifier for a public key. In addition to generating and accepting  
			_Output.Write ("unique identifier for a public key. In addition to generating and accepting \n{0}", _Indent);
			// the text string presentation used in earlier versions of OpenPGP applications 
			_Output.Write ("the text string presentation used in earlier versions of OpenPGP applications\n{0}", _Indent);
			// MAY support such additional presentation formats as are found to be useful. 
			_Output.Write ("MAY support such additional presentation formats as are found to be useful.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Conforming V5 OpenPGP implementations MUST support the V5 Fingerprint 
			_Output.Write ("Conforming V5 OpenPGP implementations MUST support the V5 Fingerprint\n{0}", _Indent);
			// text presentation format for display and entry of fingerprint values. 
			_Output.Write ("text presentation format for display and entry of fingerprint values.\n{0}", _Indent);
			// Support for all other fingerprint values is optional. 
			_Output.Write ("Support for all other fingerprint values is optional.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######V5 Fingerprint value calculation 
			_Output.Write ("###V5 Fingerprint value calculation\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The OpenPGP V5 fingerprint value is calculated as follows 
			_Output.Write ("The OpenPGP V5 fingerprint value is calculated as follows\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Fingerprint = <Version-ID> + H (<Content-ID>  + ‘:’ + H(<data>)) 
			_Output.Write ("Fingerprint = <Version-ID> + H (<Content-ID>  + ‘:’ + H(<data>))\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Where: 
			_Output.Write ("Where:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Version-ID = 0x60 
			_Output.Write ("Version-ID = 0x60\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Content-ID = "application/pgp-v5-key"  
			_Output.Write ("Content-ID = \"application/pgp-v5-key\" \n{0}", _Indent);
			// 		<<MIME Content-Type string TBS by IANA>> 
			_Output.Write ("		<<MIME Content-Type string TBS by IANA>>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// H(x) = SHA-2-512(x) 
			_Output.Write ("H(x) = SHA-2-512(x)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// <data> = <pgp-v5-key> 
			_Output.Write ("<data> = <pgp-v5-key>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// <pgp-v5-key> =  
			_Output.Write ("<pgp-v5-key> = \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// a.1) 0x99 (1 octet) 
			_Output.Write ("a.1) 0x99 (1 octet)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// a.2) high-order length octet of (b)-(d) (1 octet) 
			_Output.Write ("a.2) high-order length octet of (b)-(d) (1 octet)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// a.3) low-order length octet of (b)-(d) (1 octet) 
			_Output.Write ("a.3) low-order length octet of (b)-(d) (1 octet)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// b) version number = 5 (1 octet); 
			_Output.Write ("b) version number = 5 (1 octet);\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// c) algorithm (1 octet): 17 = DSA (example); 
			_Output.Write ("c) algorithm (1 octet): 17 = DSA (example);\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// d) Algorithm-specific fields. 
			_Output.Write ("d) Algorithm-specific fields.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The value of Version-ID is intentionally chosen so that 
			_Output.Write ("The value of Version-ID is intentionally chosen so that\n{0}", _Indent);
			// the first character of every V5 fingerprint in the text presentation  
			_Output.Write ("the first character of every V5 fingerprint in the text presentation \n{0}", _Indent);
			// format is 'M', a character that is guaranteed not to appear in a V4  
			_Output.Write ("format is 'M', a character that is guaranteed not to appear in a V4 \n{0}", _Indent);
			// or earlier fingerprint format where hexadecimal values were used. 
			_Output.Write ("or earlier fingerprint format where hexadecimal values were used.\n{0}", _Indent);
			// Thus ensuring that V5 fingerprints are not accidentally confused. 
			_Output.Write ("Thus ensuring that V5 fingerprints are not accidentally confused.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The construction of the data sequence over which the hash value  
			_Output.Write ("The construction of the data sequence over which the hash value \n{0}", _Indent);
			// is calculated follows the construction used in V4 with the omission 
			_Output.Write ("is calculated follows the construction used in V4 with the omission\n{0}", _Indent);
			// of the key creation timestamp field. This ensures that a given set  
			_Output.Write ("of the key creation timestamp field. This ensures that a given set \n{0}", _Indent);
			// of public key parameters has exactly one V5 fingerprint value. 
			_Output.Write ("of public key parameters has exactly one V5 fingerprint value.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Content-ID is a MIME content type identifier that indicates that 
			_Output.Write ("The Content-ID is a MIME content type identifier that indicates that\n{0}", _Indent);
			// fingerprint value is of data in the pgp-v5-key format specified  
			_Output.Write ("fingerprint value is of data in the pgp-v5-key format specified \n{0}", _Indent);
			// above and is intended for use with an OpenPGP application.  
			_Output.Write ("above and is intended for use with an OpenPGP application. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// If a fingerprint value is to be calculated for a public key value  
			_Output.Write ("If a fingerprint value is to be calculated for a public key value \n{0}", _Indent);
			// specified in a different format (e.g. a PKIX certificate or key) 
			_Output.Write ("specified in a different format (e.g. a PKIX certificate or key)\n{0}", _Indent);
			// or for a future version of OpenPGP with a different <data> format, 
			_Output.Write ("or for a future version of OpenPGP with a different <data> format,\n{0}", _Indent);
			// a different Content-ID value MUST be used. 
			_Output.Write ("a different Content-ID value MUST be used.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######V5 Fingerprint Text Presentation. 
			_Output.Write ("###V5 Fingerprint Text Presentation.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Binary Fingerprint Value is truncated to an integer multiple  
			_Output.Write ("The Binary Fingerprint Value is truncated to an integer multiple \n{0}", _Indent);
			// of 25 bits regardless of the intended output presentation.   
			_Output.Write ("of 25 bits regardless of the intended output presentation.  \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The output of the hash function is truncated to a sequence of n bits  
			_Output.Write ("The output of the hash function is truncated to a sequence of n bits \n{0}", _Indent);
			// by first selecting the first n/8 bytes of the output function. If n  
			_Output.Write ("by first selecting the first n/8 bytes of the output function. If n \n{0}", _Indent);
			// is an integer multiple of 8, no additional bits are required and  
			_Output.Write ("is an integer multiple of 8, no additional bits are required and \n{0}", _Indent);
			// this is the result. Otherwise the remaining bits are taken from the  
			_Output.Write ("this is the result. Otherwise the remaining bits are taken from the \n{0}", _Indent);
			// most significant bits of the next byte and any unused bits set to 0. 
			_Output.Write ("most significant bits of the next byte and any unused bits set to 0.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// For example, to truncate the byte sequence [a0, b1, c2, d3, e4] to  
			_Output.Write ("For example, to truncate the byte sequence [a0, b1, c2, d3, e4] to \n{0}", _Indent);
			// 25 bits. 25/8 = 3 bytes with 1 bit remaining, the first three bytes  
			_Output.Write ("25 bits. 25/8 = 3 bytes with 1 bit remaining, the first three bytes \n{0}", _Indent);
			// of the truncated sequence is [a0, b1, c2] and the final byte is  
			_Output.Write ("of the truncated sequence is [a0, b1, c2] and the final byte is \n{0}", _Indent);
			// e4 AND 80 = 80 which we add to the previous result to obtain the  
			_Output.Write ("e4 AND 80 = 80 which we add to the previous result to obtain the \n{0}", _Indent);
			// final truncated sequence of [a0, b1, c2, 80] 
			_Output.Write ("final truncated sequence of [a0, b1, c2, 80]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A modified version of Base32 [!RFC4648] encoding is used to present  
			_Output.Write ("A modified version of Base32 [!RFC4648] encoding is used to present \n{0}", _Indent);
			// the fingerprint in text form grouping the output text into groups of  
			_Output.Write ("the fingerprint in text form grouping the output text into groups of \n{0}", _Indent);
			// five characters separated by a dash ‘-‘.  
			_Output.Write ("five characters separated by a dash ‘-‘. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ## IANA Requirements 
			_Output.Write ("# IANA Requirements\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Register a new content type for application/pgp-v5-key  
			_Output.Write ("Register a new content type for application/pgp-v5-key \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		// #end pclass 
		}
	}
//  
