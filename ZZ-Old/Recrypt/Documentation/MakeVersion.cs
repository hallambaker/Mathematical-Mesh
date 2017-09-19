// #using System.Text 
using  System.Text;
// #using Goedel.Recrypt 
using  Goedel.Recrypt;
// #using Goedel.Protocol 
using  Goedel.Protocol;
// #pclass ExampleGenerator ExampleGenerator 
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {
		public ExampleGenerator () : base () {
			}
		public ExampleGenerator (TextWriter Output) : base (Output) {
			}

		//  
		//  
		// #method RecryptExamplesWeb CreateExamples Example 
		

		//
		// RecryptExamplesWeb
		//
		public void RecryptExamplesWeb (CreateExamples Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ##Mesh/Recrypt  
			_Output.Write ("#Mesh/Recrypt \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Mesh/Recrypt is a messaging infrastructure built on the Mathematical  
			_Output.Write ("Mesh/Recrypt is a messaging infrastructure built on the Mathematical \n{0}", _Indent);
			// Mesh infrastructure that supports end-to-end encryption with: 
			_Output.Write ("Mesh infrastructure that supports end-to-end encryption with:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// *   Confidential Document Control 
			_Output.Write ("*   Confidential Document Control\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// *   Asynchronous messaging (e.g. mail, mailing lists) 
			_Output.Write ("*   Asynchronous messaging (e.g. mail, mailing lists)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// *   Synchronous messaging (e.g. chat, voice, video) 
			_Output.Write ("*   Synchronous messaging (e.g. chat, voice, video)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Mesh/Recrypt builds on the same suite of existing Internet standards  
			_Output.Write ("Mesh/Recrypt builds on the same suite of existing Internet standards \n{0}", _Indent);
			// and specifications as the Mathematical Mesh. These include: 
			_Output.Write ("and specifications as the Mathematical Mesh. These include:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * All messages and data structures are encoded using either JSON  
			_Output.Write ("* All messages and data structures are encoded using either JSON \n{0}", _Indent);
			// encoding or the extended JSON-C encoding that offers efficient binary 
			_Output.Write ("encoding or the extended JSON-C encoding that offers efficient binary\n{0}", _Indent);
			// encoding and compression of field tags and strings. 
			_Output.Write ("encoding and compression of field tags and strings.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * All services are implemented as Web Services using HTTP transport and 
			_Output.Write ("* All services are implemented as Web Services using HTTP transport and\n{0}", _Indent);
			// TLS for transport layer security. 
			_Output.Write ("TLS for transport layer security.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Message layer security is provided using JOSE signature and  
			_Output.Write ("* Message layer security is provided using JOSE signature and \n{0}", _Indent);
			// Encryption. 
			_Output.Write ("Encryption.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Uniform Data Fingerprints are used to identify public keys 
			_Output.Write ("* Uniform Data Fingerprints are used to identify public keys\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Use of DNS SRV records for Web Service discovery 
			_Output.Write ("* Use of DNS SRV records for Web Service discovery\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Use of the .well-known convention to specify the Web Service  
			_Output.Write ("* Use of the .well-known convention to specify the Web Service \n{0}", _Indent);
			// endpoint. 
			_Output.Write ("endpoint.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// One significant limitation in the current implementation is that it  
			_Output.Write ("One significant limitation in the current implementation is that it \n{0}", _Indent);
			// uses traditional Diffie Hellman key exchange in a finite field rather 
			_Output.Write ("uses traditional Diffie Hellman key exchange in a finite field rather\n{0}", _Indent);
			// than the newly defined CFRG elliptic curve algorithms. This is due to 
			_Output.Write ("than the newly defined CFRG elliptic curve algorithms. This is due to\n{0}", _Indent);
			// the version of the development environment having not caught up with  
			_Output.Write ("the version of the development environment having not caught up with \n{0}", _Indent);
			// the development of the new standards yet. 
			_Output.Write ("the development of the new standards yet.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// For clarity, the use of the command line tool 'recrypt' is shown. For 
			_Output.Write ("For clarity, the use of the command line tool 'recrypt' is shown. For\n{0}", _Indent);
			// most production use, a GUI interface or integration of the recryption 
			_Output.Write ("most production use, a GUI interface or integration of the recryption\n{0}", _Indent);
			// functions into the document editing and/or viewing tools would be  
			_Output.Write ("functions into the document editing and/or viewing tools would be \n{0}", _Indent);
			// preferred. 
			_Output.Write ("preferred.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #### Scenario 
			_Output.Write ("## Scenario\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//    Since Confidential Document Control is the application that is not  
			_Output.Write ("   Since Confidential Document Control is the application that is not \n{0}", _Indent);
			//    currently supported by existing open standards, we present this as  
			_Output.Write ("   currently supported by existing open standards, we present this as \n{0}", _Indent);
			//    the example use case. The extension of the approach to other  
			_Output.Write ("   the example use case. The extension of the approach to other \n{0}", _Indent);
			//    messaging modalities will be considered separately. 
			_Output.Write ("   messaging modalities will be considered separately.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//    In the following examples, the named parties have the following  
			_Output.Write ("   In the following examples, the named parties have the following \n{0}", _Indent);
			//    roles: 
			_Output.Write ("   roles:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// :Alice 
			_Output.Write (":Alice\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ::The owner and administrator of the recryption group  
			_Output.Write ("::The owner and administrator of the recryption group \n{0}", _Indent);
			//    'private#alice@example.com'. She decides who is permitted to read  
			_Output.Write ("   'privatealice@example.com'. She decides who is permitted to read \n{0}", _Indent);
			//    documents that have been encrypted to this group and generates the  
			_Output.Write ("   documents that have been encrypted to this group and generates the \n{0}", _Indent);
			//    necessary recryption keys. 
			_Output.Write ("   necessary recryption keys.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// :Bob 
			_Output.Write (":Bob\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ::The person Alice grants read access to her controlled documents. 
			_Output.Write ("::The person Alice grants read access to her controlled documents.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// :Service 
			_Output.Write (":Service\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ::The service that enforces control of controlled documents. 
			_Output.Write ("::The service that enforces control of controlled documents.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Note that the Service is only one part of the CDC infrastructure.  
			_Output.Write ("Note that the Service is only one part of the CDC infrastructure. \n{0}", _Indent);
			// Alice sets policy for who is permitted access to the controlled  
			_Output.Write ("Alice sets policy for who is permitted access to the controlled \n{0}", _Indent);
			// documents using the recrypt tool. The service is responsible for  
			_Output.Write ("documents using the recrypt tool. The service is responsible for \n{0}", _Indent);
			// enforcement of that policy. 
			_Output.Write ("enforcement of that policy.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Parties create a Mesh personal profile 
			_Output.Write ("##Parties create a Mesh personal profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alice creates a Mesh personal profile with a Mesh/Recrypt profile.  
			_Output.Write ("Alice creates a Mesh personal profile with a Mesh/Recrypt profile. \n{0}", _Indent);
			// This can be done using a Mesh profile management tool or the recrypt 
			_Output.Write ("This can be done using a Mesh profile management tool or the recrypt\n{0}", _Indent);
			// tool. The recrypt tool generates a Mesh/Recrypt profile by default: 
			_Output.Write ("tool. The recrypt tool generates a Mesh/Recrypt profile by default:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// recrypt /personal alice@example.com 
			_Output.Write ("recrypt /personal alice@example.com\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Bob and Carol do likewise but using a different Mesh portal. 
			_Output.Write ("Bob and Carol do likewise but using a different Mesh portal.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// recrypt /personal bob@example.net 
			_Output.Write ("recrypt /personal bob@example.net\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// recrypt /personal carol@example.net 
			_Output.Write ("recrypt /personal carol@example.net\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// At this point Alice, Bob and Carol have established a persistent personal PKI. 
			_Output.Write ("At this point Alice, Bob and Carol have established a persistent personal PKI.\n{0}", _Indent);
			// Since it is the only profile each has established for the account they  
			_Output.Write ("Since it is the only profile each has established for the account they \n{0}", _Indent);
			// are using on the computer, it is automatically registered as the default 
			_Output.Write ("are using on the computer, it is automatically registered as the default\n{0}", _Indent);
			// profile for that account and does not need to be specified in future  
			_Output.Write ("profile for that account and does not need to be specified in future \n{0}", _Indent);
			// commands. 
			_Output.Write ("commands.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To simplify future examples, we assume that Alice and Bob have established 
			_Output.Write ("To simplify future examples, we assume that Alice and Bob have established\n{0}", _Indent);
			// each other's profiles as trustworthy via some out of band process.  
			_Output.Write ("each other's profiles as trustworthy via some out of band process. \n{0}", _Indent);
			// This might be through a direct trust model (i.e. exchange of profile  
			_Output.Write ("This might be through a direct trust model (i.e. exchange of profile \n{0}", _Indent);
			// fingerprints), a brokered trust mode (e.g. a certificate issued by a CA) 
			_Output.Write ("fingerprints), a brokered trust mode (e.g. a certificate issued by a CA)\n{0}", _Indent);
			// or some other mechanism to be determined. 
			_Output.Write ("or some other mechanism to be determined.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To use the protocol, the recyption service also requires a Mesh/Recrypt 
			_Output.Write ("To use the protocol, the recyption service also requires a Mesh/Recrypt\n{0}", _Indent);
			// profile containing a public key to use for encryption. For simplicity  
			_Output.Write ("profile containing a public key to use for encryption. For simplicity \n{0}", _Indent);
			// we assume that this is a WebPKI certificate using an appropriate validation 
			_Output.Write ("we assume that this is a WebPKI certificate using an appropriate validation\n{0}", _Indent);
			// mechanism (e.g. Extended Validation). 
			_Output.Write ("mechanism (e.g. Extended Validation).\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Alice creates a recryption group 
			_Output.Write ("##Alice creates a recryption group\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To create a recryption group, Alice just needs to specify the name for  
			_Output.Write ("To create a recryption group, Alice just needs to specify the name for \n{0}", _Indent);
			// the group. Since this is a group for Alice's personal use, and the 
			_Output.Write ("the group. Since this is a group for Alice's personal use, and the\n{0}", _Indent);
			// recryption service will be managed by her Mesh portal, she chooses  
			_Output.Write ("recryption service will be managed by her Mesh portal, she chooses \n{0}", _Indent);
			// the name private#alice@example.com. 
			_Output.Write ("the name privatealice@example.com.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// [The extent to which this convention is useful and/or requires enforcement 
			_Output.Write ("[The extent to which this convention is useful and/or requires enforcement\n{0}", _Indent);
			// steps to be taken by portals is not currently understood. It seems 
			_Output.Write ("steps to be taken by portals is not currently understood. It seems\n{0}", _Indent);
			// like a good idea but might not be.] 
			_Output.Write ("like a good idea but might not be.]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// recrypt /newgroup private#alice@example.com 
			_Output.Write ("recrypt /newgroup privatealice@example.com\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// As with any other Mesh profile, the recryption group has both a friendly 
			_Output.Write ("As with any other Mesh profile, the recryption group has both a friendly\n{0}", _Indent);
			// name and a UDF fingerprint. 
			_Output.Write ("name and a UDF fingerprint.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The recryption group contains a master signature key and an encryption 
			_Output.Write ("The recryption group contains a master signature key and an encryption\n{0}", _Indent);
			// key and is signed under the signature key: 
			_Output.Write ("key and is signed under the signature key:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// Recrypt profile... 
			_Output.Write ("Recrypt profile...\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The newly created recryption profile is published to both the recryption  
			_Output.Write ("The newly created recryption profile is published to both the recryption \n{0}", _Indent);
			// service and the Mesh Portal. Note that even though the Mesh Portal and  
			_Output.Write ("service and the Mesh Portal. Note that even though the Mesh Portal and \n{0}", _Indent);
			// Recryption Service are both provided by the same domain (example.com),  
			_Output.Write ("Recryption Service are both provided by the same domain (example.com), \n{0}", _Indent);
			// these are distinct Web Services and may be hosted on separate machines. 
			_Output.Write ("these are distinct Web Services and may be hosted on separate machines.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Since the use of a recryption group is a stored data encryption application 
			_Output.Write ("Since the use of a recryption group is a stored data encryption application\n{0}", _Indent);
			// and Alice has opted to create a personal escrow key, the recrypt client 
			_Output.Write ("and Alice has opted to create a personal escrow key, the recrypt client\n{0}", _Indent);
			// also  
			_Output.Write ("also \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Alice encrypts a document 
			_Output.Write ("##Alice encrypts a document\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alice creates a text document containing the text 'this is a test' and 
			_Output.Write ("Alice creates a text document containing the text 'this is a test' and\n{0}", _Indent);
			// saves it under the filename text.txt. 
			_Output.Write ("saves it under the filename text.txt.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To encrypt the document to the recryption group, Alice specifies the  
			_Output.Write ("To encrypt the document to the recryption group, Alice specifies the \n{0}", _Indent);
			// file she wishes to encrypt and the name of the group: 
			_Output.Write ("file she wishes to encrypt and the name of the group:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// recrypt /encrypt private#alice@example.com test.txt 
			_Output.Write ("recrypt /encrypt privatealice@example.com test.txt\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The recryption client fetches the current recryption group profile from  
			_Output.Write ("The recryption client fetches the current recryption group profile from \n{0}", _Indent);
			// the Mesh Portal and verifies that it meets the relevant trust criteria. 
			_Output.Write ("the Mesh Portal and verifies that it meets the relevant trust criteria.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Since private#alice@example.com is a sub-account of alice@example.com 
			_Output.Write ("Since privatealice@example.com is a sub-account of alice@example.com\n{0}", _Indent);
			// which Alice trusts because it is her own account. It suffices for the  
			_Output.Write ("which Alice trusts because it is her own account. It suffices for the \n{0}", _Indent);
			// client to verify that Alice's current Mesh profile has an entry 
			_Output.Write ("client to verify that Alice's current Mesh profile has an entry\n{0}", _Indent);
			// for the recryption group and has a valid signature. 
			_Output.Write ("for the recryption group and has a valid signature.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Having acquired the recryption group profile, the client  
			_Output.Write ("Having acquired the recryption group profile, the client \n{0}", _Indent);
			// extracts the group encryption key and uses it to create a JOSE  
			_Output.Write ("extracts the group encryption key and uses it to create a JOSE \n{0}", _Indent);
			// encrypted message: 
			_Output.Write ("encrypted message:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// TBS 
			_Output.Write ("TBS\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The encrypted data is a wrapper that specifies the content  
			_Output.Write ("The encrypted data is a wrapper that specifies the content \n{0}", _Indent);
			// metadata. 
			_Output.Write ("metadata.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// TBS 
			_Output.Write ("TBS\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The encrypted document is saved as test.txt.jcd (Jose Controlled Document) 
			_Output.Write ("The encrypted document is saved as test.txt.jcd (Jose Controlled Document)\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The message format has been designed to permit authenticated and 
			_Output.Write ("The message format has been designed to permit authenticated and\n{0}", _Indent);
			// encrypted messages to be generated and recieved as message streams  
			_Output.Write ("encrypted messages to be generated and recieved as message streams \n{0}", _Indent);
			// without the need to buffer content. A protected message consists  
			_Output.Write ("without the need to buffer content. A protected message consists \n{0}", _Indent);
			// of a list containing the following items in order: 
			_Output.Write ("of a list containing the following items in order:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Header specifying the information necessary to decrypt the  
			_Output.Write ("* Header specifying the information necessary to decrypt the \n{0}", _Indent);
			//   message and the authentication algorithm. 
			_Output.Write ("  message and the authentication algorithm.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * The encrypted data. 
			_Output.Write ("* The encrypted data.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Trailer specifying the authentication value. 
			_Output.Write ("* Trailer specifying the authentication value.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// One disadvantage of using JSON encoding in an encryption scheme 
			_Output.Write ("One disadvantage of using JSON encoding in an encryption scheme\n{0}", _Indent);
			// is that the need to encode binary data as Base63 encoded strings 
			_Output.Write ("is that the need to encode binary data as Base63 encoded strings\n{0}", _Indent);
			// incurs a 33% inflation penalty on each pass. For this reason,  
			_Output.Write ("incurs a 33% inflation penalty on each pass. For this reason, \n{0}", _Indent);
			// Mesh/Recrypt applications are required to accept (but not generate) 
			_Output.Write ("Mesh/Recrypt applications are required to accept (but not generate)\n{0}", _Indent);
			// the JSON-B and JSON-C encodings which permit binary data to be  
			_Output.Write ("the JSON-B and JSON-C encodings which permit binary data to be \n{0}", _Indent);
			// encoded directly. 
			_Output.Write ("encoded directly.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Alice adds Bob and Carol to the recryption group 
			_Output.Write ("##Alice adds Bob and Carol to the recryption group\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alice adds Bob and Carol to the recryption tool by specifying their 
			_Output.Write ("Alice adds Bob and Carol to the recryption tool by specifying their\n{0}", _Indent);
			// profile identifiers: 
			_Output.Write ("profile identifiers:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// recrypt add private#alice@example.com bob@example.net 
			_Output.Write ("recrypt add privatealice@example.com bob@example.net\n{0}", _Indent);
			// recrypt add private#alice@example.com carol@example.net 
			_Output.Write ("recrypt add privatealice@example.com carol@example.net\n{0}", _Indent);
			// ~~~~  
			_Output.Write ("~~~~ \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To add each user the client: 
			_Output.Write ("To add each user the client:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Acquires and validates the user's Mesh profile 
			_Output.Write ("* Acquires and validates the user's Mesh profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Obtains the private key for the recryption group  
			_Output.Write ("* Obtains the private key for the recryption group \n{0}", _Indent);
			// (stored on the machine). 
			_Output.Write ("(stored on the machine).\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Creates a recryption entry as described earlier. 
			_Output.Write ("* Creates a recryption entry as described earlier.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Encrypts recryption entry under the encryption key of the 
			_Output.Write ("* Encrypts recryption entry under the encryption key of the\n{0}", _Indent);
			// recryption service. 
			_Output.Write ("recryption service.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Publishes the encrypted recryption entry to the service  
			_Output.Write ("* Publishes the encrypted recryption entry to the service \n{0}", _Indent);
			// using a secure channel (HTTPS to the Server WebPKI certificate). 
			_Output.Write ("using a secure channel (HTTPS to the Server WebPKI certificate).\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The encrypted recryption entry is: 
			_Output.Write ("The encrypted recryption entry is:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// TBS 
			_Output.Write ("TBS\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The encrypted content within the recryption entry is: 
			_Output.Write ("The encrypted content within the recryption entry is:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// TBS 
			_Output.Write ("TBS\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Bob decrypts a document 
			_Output.Write ("##Bob decrypts a document\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alice sends the encrypted controlled document to Bob by whichever  
			_Output.Write ("Alice sends the encrypted controlled document to Bob by whichever \n{0}", _Indent);
			// means is most convenient. Alice might send the document to Bob by email,  
			_Output.Write ("means is most convenient. Alice might send the document to Bob by email, \n{0}", _Indent);
			// hand him a USB thumdrive or just save the document to an enterprise file  
			_Output.Write ("hand him a USB thumdrive or just save the document to an enterprise file \n{0}", _Indent);
			// server that Bob has access to. 
			_Output.Write ("server that Bob has access to.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To read the document, Bob must decrypt it. Ideally the encryption and  
			_Output.Write ("To read the document, Bob must decrypt it. Ideally the encryption and \n{0}", _Indent);
			// decryption of documents would be handled transparently by the application 
			_Output.Write ("decryption of documents would be handled transparently by the application\n{0}", _Indent);
			// and/or platform. Instead Bob uses the recrypt tool: 
			_Output.Write ("and/or platform. Instead Bob uses the recrypt tool:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// recrypt /decrypt test.txt.jcd 
			_Output.Write ("recrypt /decrypt test.txt.jcd\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To decrypt the document, the client: 
			_Output.Write ("To decrypt the document, the client:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Reads the document header to determine that it is a recrypted document 
			_Output.Write ("* Reads the document header to determine that it is a recrypted document\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Obtain a recryption grant from the recryption service indicated. This  
			_Output.Write ("* Obtain a recryption grant from the recryption service indicated. This \n{0}", _Indent);
			// is encrypted under Bob's encryption key. 
			_Output.Write ("is encrypted under Bob's encryption key.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Decrypt the recryption grant and the user portion of the recryption private key 
			_Output.Write ("* Decrypt the recryption grant and the user portion of the recryption private key\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Combine the user and service data 
			_Output.Write ("* Combine the user and service data\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Decrypt the message 
			_Output.Write ("* Decrypt the message\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The recryption service may require Bob to authenticate before the recryption  
			_Output.Write ("The recryption service may require Bob to authenticate before the recryption \n{0}", _Indent);
			// grant is provided. This prevents denial of service attacks on the service  
			_Output.Write ("grant is provided. This prevents denial of service attacks on the service \n{0}", _Indent);
			// and allows the service to enforce quotas and/or accountability controls. 
			_Output.Write ("and allows the service to enforce quotas and/or accountability controls.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Bob uses multiple devices 
			_Output.Write ("##Bob uses multiple devices\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Recryption may be used to support multiple devices in more than one way. 
			_Output.Write ("Recryption may be used to support multiple devices in more than one way.\n{0}", _Indent);
			// The approach that is most appropriate depends on the precise use scenario. 
			_Output.Write ("The approach that is most appropriate depends on the precise use scenario.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The simplest method of supporting multiple devices is for Alice to create  
			_Output.Write ("The simplest method of supporting multiple devices is for Alice to create \n{0}", _Indent);
			// multiple recryption entries for Bob, one for each of his authorized devices. 
			_Output.Write ("multiple recryption entries for Bob, one for each of his authorized devices.\n{0}", _Indent);
			// Alice might prefer this approach despite the additional work for her  
			_Output.Write ("Alice might prefer this approach despite the additional work for her \n{0}", _Indent);
			// because it allows her to decide which of Bob's devices are authorized to  
			_Output.Write ("because it allows her to decide which of Bob's devices are authorized to \n{0}", _Indent);
			// read the documents she controls. The chief limitation of this approach is 
			_Output.Write ("read the documents she controls. The chief limitation of this approach is\n{0}", _Indent);
			// that Bob must obtain Alice's approval to add or remove devices. 
			_Output.Write ("that Bob must obtain Alice's approval to add or remove devices.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// In a more sophisticated approach, Bob administers his own recryption group 
			_Output.Write ("In a more sophisticated approach, Bob administers his own recryption group\n{0}", _Indent);
			// and creates recryption keys for each device that is not to be an administrator 
			_Output.Write ("and creates recryption keys for each device that is not to be an administrator\n{0}", _Indent);
			// device for the group. These are called standard devices. 
			_Output.Write ("device for the group. These are called standard devices.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To read Alice's document on a standard device, the device must first obtain 
			_Output.Write ("To read Alice's document on a standard device, the device must first obtain\n{0}", _Indent);
			// the recryption key from Alice's recryption service as before, then contact  
			_Output.Write ("the recryption key from Alice's recryption service as before, then contact \n{0}", _Indent);
			// Bob's recryption service to decrypt the recryption grant. 
			_Output.Write ("Bob's recryption service to decrypt the recryption grant.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// [It is not clear at this stage how much data this leaks to the client and  
			_Output.Write ("[It is not clear at this stage how much data this leaks to the client and \n{0}", _Indent);
			// to what extent Bob is trusting the recryption service to enforce policy. Each  
			_Output.Write ("to what extent Bob is trusting the recryption service to enforce policy. Each \n{0}", _Indent);
			// ordinary device gains access to Bob's decryption key for the group. Instead of 
			_Output.Write ("ordinary device gains access to Bob's decryption key for the group. Instead of\n{0}", _Indent);
			// using recryption to control access to the document itself, this approach uses  
			_Output.Write ("using recryption to control access to the document itself, this approach uses \n{0}", _Indent);
			// recryption to control access to the recryption grant used to unlock the  
			_Output.Write ("recryption to control access to the recryption grant used to unlock the \n{0}", _Indent);
			// document.] 
			_Output.Write ("document.]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// [For the most sensitive documents, Bob can reduce the degree of trust in 
			_Output.Write ("[For the most sensitive documents, Bob can reduce the degree of trust in\n{0}", _Indent);
			// the recryption service by obtaining his recryption private user key for a  
			_Output.Write ("the recryption service by obtaining his recryption private user key for a \n{0}", _Indent);
			// group and creating a recryption keyset for that device. The principal  
			_Output.Write ("group and creating a recryption keyset for that device. The principal \n{0}", _Indent);
			// disadvantage of this approach is that this requires Alice and Bob to perform 
			_Output.Write ("disadvantage of this approach is that this requires Alice and Bob to perform\n{0}", _Indent);
			// an administration operation when the group is created and each time the  
			_Output.Write ("an administration operation when the group is created and each time the \n{0}", _Indent);
			// keys are changed. Another disadvantage is that if Bob has ten devices  
			_Output.Write ("keys are changed. Another disadvantage is that if Bob has ten devices \n{0}", _Indent);
			// and is a member of a hundred recryption groups, he will need to administer 
			_Output.Write ("and is a member of a hundred recryption groups, he will need to administer\n{0}", _Indent);
			// a thousand individual recryption entries.] 
			_Output.Write ("a thousand individual recryption entries.]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Alice revokes Carol’s group membership 
			_Output.Write ("##Alice revokes Carol’s group membership\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// At minimum, revoking Carol read access to the group requires the client  
			_Output.Write ("At minimum, revoking Carol read access to the group requires the client \n{0}", _Indent);
			// to inform the recryption service that the entry for Carol should be deleted. 
			_Output.Write ("to inform the recryption service that the entry for Carol should be deleted.\n{0}", _Indent);
			// Relying on the recryption service to enforce the policy change requires 
			_Output.Write ("Relying on the recryption service to enforce the policy change requires\n{0}", _Indent);
			// the service to be trusted which may or may not be acceptable. 
			_Output.Write ("the service to be trusted which may or may not be acceptable.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// If the confidential data being controlled is particularly sensitive, Alice 
			_Output.Write ("If the confidential data being controlled is particularly sensitive, Alice\n{0}", _Indent);
			// can block access to any new material encrypted under the group with a  
			_Output.Write ("can block access to any new material encrypted under the group with a \n{0}", _Indent);
			// rollover of the group key and set of recryption keys. A client might 
			_Output.Write ("rollover of the group key and set of recryption keys. A client might\n{0}", _Indent);
			// perform such a key rollover by default if the number of entries in the 
			_Output.Write ("perform such a key rollover by default if the number of entries in the\n{0}", _Indent);
			// group is small.  
			_Output.Write ("group is small. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Bob loses a device 
			_Output.Write ("##Bob loses a device\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The loss of a device requires Bob to perform the same tasks as Alice did 
			_Output.Write ("The loss of a device requires Bob to perform the same tasks as Alice did\n{0}", _Indent);
			// to remove Carol from the recryption group. 
			_Output.Write ("to remove Carol from the recryption group.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Bob visits a hostile environment 
			_Output.Write ("##Bob visits a hostile environment\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// If Bob knows that he is going to be visiting an environment where his device 
			_Output.Write ("If Bob knows that he is going to be visiting an environment where his device\n{0}", _Indent);
			// may be searched by agents who may coerce him to reveal any decryption keys,  
			_Output.Write ("may be searched by agents who may coerce him to reveal any decryption keys, \n{0}", _Indent);
			// he may avoid disclosure of confidential material by removing the device from  
			_Output.Write ("he may avoid disclosure of confidential material by removing the device from \n{0}", _Indent);
			// the recryption group and deleting all the unencrypted confidential from it. 
			_Output.Write ("the recryption group and deleting all the unencrypted confidential from it.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Bob access to the confidential material may be quickly restored through 
			_Output.Write ("Bob access to the confidential material may be quickly restored through\n{0}", _Indent);
			// the introduction of a trusted third party. Before leaving, Bob creates  
			_Output.Write ("the introduction of a trusted third party. Before leaving, Bob creates \n{0}", _Indent);
			// a recryption entry, and encrypts it under an encryption key unique to  
			_Output.Write ("a recryption entry, and encrypts it under an encryption key unique to \n{0}", _Indent);
			// the device he is to use. This information is sent to the trusted third  
			_Output.Write ("the device he is to use. This information is sent to the trusted third \n{0}", _Indent);
			// party via a secure channel. To regain access to the material, Bob must 
			_Output.Write ("party via a secure channel. To regain access to the material, Bob must\n{0}", _Indent);
			// convince the trusted third party that he is safe and not in a situation  
			_Output.Write ("convince the trusted third party that he is safe and not in a situation \n{0}", _Indent);
			// he is subject to coertion. 
			_Output.Write ("he is subject to coertion.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		// #method RecryptExamplesWebOLD CreateExamples Example 
		

		//
		// RecryptExamplesWebOLD
		//
		public void RecryptExamplesWebOLD (CreateExamples Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			// ##Protocol Overview 
			_Output.Write ("#Protocol Overview\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Here we put a description of the basic protocol  
			_Output.Write ("Here we put a description of the basic protocol \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Connection Establishment 
			_Output.Write ("##Connection Establishment\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// This part of the specification should be separated into a generic  
			_Output.Write ("This part of the specification should be separated into a generic \n{0}", _Indent);
			// building block for reuse in other protocols. 
			_Output.Write ("building block for reuse in other protocols.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service discovery mechanism described in  
			_Output.Write ("The service discovery mechanism described in \n{0}", _Indent);
			// [!draft-hallambaker-json-web-service-02] is used. 
			_Output.Write ("[!draft-hallambaker-json-web-service-02] is used.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Hello transaction MAY be used to determine specific  
			_Output.Write ("The Hello transaction MAY be used to determine specific \n{0}", _Indent);
			// features of the particular Web Service. 
			_Output.Write ("features of the particular Web Service.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The client request is: 
			_Output.Write ("The client request is:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% var Point = Example.Traces.Get (Example.LabelHello); 
			 var Point = Example.Traces.Get (Example.LabelHello);
			// #% Example.Traces.Level = 0; 
			 Example.Traces.Level = 0;
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service responds with a description of the service. This  
			_Output.Write ("The service responds with a description of the service. This \n{0}", _Indent);
			// description MUST specify at least one supported protocol 
			_Output.Write ("description MUST specify at least one supported protocol\n{0}", _Indent);
			// version. 
			_Output.Write ("version.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A typical client response is: 
			_Output.Write ("A typical client response is:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// All versions of the protocol SHALL support the Hello transaction. 
			_Output.Write ("All versions of the protocol SHALL support the Hello transaction.\n{0}", _Indent);
			// A service MUST support the use of JSON encoding for the  
			_Output.Write ("A service MUST support the use of JSON encoding for the \n{0}", _Indent);
			// Hello transaction regardless of version.  
			_Output.Write ("Hello transaction regardless of version. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The set of encodings supportted by a protocol version is  
			_Output.Write ("The set of encodings supportted by a protocol version is \n{0}", _Indent);
			// specified in the Encodings field. The encodings field MAY  
			_Output.Write ("specified in the Encodings field. The encodings field MAY \n{0}", _Indent);
			// be omitted if only JSON is supported. 
			_Output.Write ("be omitted if only JSON is supported.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A service SHOULD support at least one protocol version with  
			_Output.Write ("A service SHOULD support at least one protocol version with \n{0}", _Indent);
			// JSON encoding. 
			_Output.Write ("JSON encoding.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Example.Traces.Level = 5; 
			 Example.Traces.Level = 5;
			// [Note that for the sake of concise presentation, the HTTP binding 
			_Output.Write ("[Note that for the sake of concise presentation, the HTTP binding\n{0}", _Indent);
			// information is omitted from future examples.] 
			_Output.Write ("information is omitted from future examples.]\n{0}", _Indent);
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
