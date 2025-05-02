using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	
	/// <summary>	
	/// MakeJSContactExamples
	/// </summary>
	/// <param name="Example"></param>
	public void MakeJSContactExamples (CreateExamples Example) {
		 JSContactKeys(Example);
		 JSContactJWK(Example);
		 JSContactEARL(Example);
		 JSContactDNS(Example);
		 JSContactGroups(Example);
		 JSContactUpdate(Example);
		 JSContactSMIME(Example);
		 JSContactOpenPGP(Example);
		 JSContactSSH(Example);
		 JSContactCode(Example);
		 JSContactCommit(Example);
		}
	
	/// <summary>	
	/// MakeEarlExamples
	/// </summary>
	/// <param name="Example"></param>
	public void MakeEarlExamples (CreateExamples Example) {
		 EarlExamples(Example);
		 EarlExamplesLocator(Example);
		 EarlExamplesName(Example);
		 Type0Envelope(Example);
		 Type0Meta(Example);
		 Type1Envelope(Example);
		 EarlKeyDerivation(Example);
		 Type0Nonce(Example);
		 EarlEncryption(Example);
		 EarlLocator(Example);
		 EarlAuthenticatedLocator(Example);
		 Unprotected(Example);
		 EarlManifest(Example);
		 SignedEnvelope25519(Example);
		 SignedEnvelope448(Example);
		}
	
	/// <summary>	
	/// MakeDareExamples
	/// </summary>
	/// <param name="Example"></param>
	public void MakeDareExamples (CreateExamples Example) {
		 MeshExamplesMessageMail(Example);
		 MeshExamplesMessageEDS(Example);
		 MeshExamplesMessageEncrypted(Example);
		 DareSchemaCatalog(Example);
		 DareSchemaSpool(Example);
		 ExamplesDAREMessage(Example);
		 MeshExamplesContainer(Example);
		}
	
	/// <summary>	
	/// WriteBytesHex
	/// </summary>
	/// <param name="data"></param>
	public void WriteBytesHex (byte[] data) {
		if (  (data != null) ) {
			_Output.Write ("{1}\n{0}", _Indent, data.ToStringBase16FormatHex());
			} else {
			_Output.Write ("$$$ Missing data $$$\n{0}", _Indent);
			}
		}
	
	/// <summary>	
	/// CardExample
	/// </summary>
	/// <param name="parent"></param>
	/// <param name="example"></param>
	public void CardExample (string parent, JsonObject example) {
		_Output.Write ("{{\n{0}", _Indent);
		_Output.Write ("    \"@type\":\"Card\",\n{0}", _Indent);
		_Output.Write ("    ...\n{0}", _Indent);
		_Output.Write ("    \"{1}\" : ", _Indent, parent);
		_Output.Write ("{1},\n{0}", _Indent, JSONDebugWriter.Write(example));
		_Output.Write ("    ...\n{0}", _Indent);
		_Output.Write ("    }}\n{0}", _Indent);
		}
	

	//
	// JSContactKeys
	//
	public static void JSContactKeys(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactKeys.md");
		Example._Output = _Output;
		Example._JSContactKeys(Example);
		}
	public void _JSContactKeys(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			 // For example, Bob is trying to send an encrypted email to Alice, her 
			 //contact card lists two X.509v3 certificates but only one is an encryption 
			 // certificate with the JWK use parameter:
			_Output.Write ("~~~~\n{0}", _Indent);
			 CardExample ("emails", jscontact.EmailAddress);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactJWK
	//
	public static void JSContactJWK(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactJWK.md");
		Example._Output = _Output;
		Example._JSContactJWK(Example);
		}
	public void _JSContactJWK(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			 Write(jscontact.JSContactSmime, true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactEARL
	//
	public static void JSContactEARL(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactEARL.md");
		Example._Output = _Output;
		Example._JSContactEARL(Example);
		}
	public void _JSContactEARL(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			 var earl = Example.Earl;
			_Output.Write ("{1}\n{0}", _Indent, jscontact.EARL);
				}
	

	//
	// JSContactDNS
	//
	public static void JSContactDNS(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactDNS.md");
		Example._Output = _Output;
		Example._JSContactDNS(Example);
		}
	public void _JSContactDNS(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			 var earl = Example.Earl;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("_jscontact.{1} TXT \"jscontact={2}\"\n{0}", _Indent, CreateExamples.DnsHandleAlice, jscontact.EARL);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactGroups
	//
	public static void JSContactGroups(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactGroups.md");
		Example._Output = _Output;
		Example._JSContactGroups(Example);
		}
	public void _JSContactGroups(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			// {JSONDebugWriter.Write(jscontact.Group)}
			 CardExample ("groups", jscontact.Group);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Each group identifier is specified as an online service:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 Write(jscontact.GroupMembers, true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactUpdate
	//
	public static void JSContactUpdate(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactUpdate.md");
		Example._Output = _Output;
		Example._JSContactUpdate(Example);
		}
	public void _JSContactUpdate(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{{\n{0}", _Indent);
			_Output.Write ("    \"@type\":\"Card\",\n{0}", _Indent);
			_Output.Write ("    ...\n{0}", _Indent);
			 WriteUpdates(jscontact.Contact.Updates);
			_Output.Write ("    ...\n{0}", _Indent);
			 WriteCryptoKeys(jscontact.UpdateKeys);
			_Output.Write ("    ...\n{0}", _Indent);
			_Output.Write ("    }}\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactSMIME
	//
	public static void JSContactSMIME(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactSMIME.md");
		Example._Output = _Output;
		Example._JSContactSMIME(Example);
		}
	public void _JSContactSMIME(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			 Write(jscontact.JSContactSmime, true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactOpenPGP
	//
	public static void JSContactOpenPGP(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactOpenPGP.md");
		Example._Output = _Output;
		Example._JSContactOpenPGP(Example);
		}
	public void _JSContactOpenPGP(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			 Write(jscontact.JSContactOpenpgp, true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactSSH
	//
	public static void JSContactSSH(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactSSH.md");
		Example._Output = _Output;
		Example._JSContactSSH(Example);
		}
	public void _JSContactSSH(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			 Write(jscontact.Ssh);
			_Output.Write ("\n{0}", _Indent);
			 Write(jscontact.SshKeys);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactCommit
	//
	public static void JSContactCommit(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactCommit.md");
		Example._Output = _Output;
		Example._JSContactCommit(Example);
		}
	public void _JSContactCommit(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			 Write(jscontact.Commit);
			_Output.Write ("\n{0}", _Indent);
			 Write(jscontact.CommitKeys);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSContactCode
	//
	public static void JSContactCode(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactCode.md");
		Example._Output = _Output;
		Example._JSContactCode(Example);
		}
	public void _JSContactCode(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("~~~~\n{0}", _Indent);
			 Write(jscontact.CodeSign);
			_Output.Write ("\n{0}", _Indent);
			 Write(jscontact.CodeSignKeys);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	
	/// <summary>	
	/// Write
	/// </summary>
	/// <param name="services"></param>
	/// <param name="part=false"></param>
	public void Write (Dictionary<string,OnlineService> services, bool part=false) {
		_Output.Write ("{{\n{0}", _Indent);
		_Output.Write ("    \"@type\":\"Card\",\n{0}", _Indent);
		_Output.Write ("    ...\n{0}", _Indent);
		_Output.Write ("    \"onlineServices\" : {{", _Indent);
		 var sep = new Separator (",\n");
		foreach  (var service in services) {
			_Output.Write ("{1}", _Indent, sep);
			_Output.Write ("\"{1}\" : {2}", _Indent, service.Key, JSONDebugWriter.Write(service.Value, false));
			}
		if (  (part)  ) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("...\n{0}", _Indent);
			}
		_Output.Write ("}}\n{0}", _Indent);
		}
	
	/// <summary>	
	/// Write
	/// </summary>
	/// <param name="jsonKeys"></param>
	/// <param name="part=false"></param>
	public void Write (Dictionary<string,CryptoKey> jsonKeys, bool part=false) {
		_Output.Write ("{{\n{0}", _Indent);
		_Output.Write ("    \"@type\":\"Card\",\n{0}", _Indent);
		_Output.Write ("    ...\n{0}", _Indent);
		_Output.Write ("    \"cryptoKeys\" : {{", _Indent);
		 var sep = new Separator  (",\n");
		foreach  (var jsonKey in jsonKeys) {
			_Output.Write ("{1}", _Indent, sep);
			_Output.Write ("\"{1}\" : {2}", _Indent, jsonKey.Key, JSONDebugWriter.Write(jsonKey.Value, false));
			}
		if (  (part)  ) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("...\n{0}", _Indent);
			}
		_Output.Write ("}}\n{0}", _Indent);
		}
	
	/// <summary>	
	/// WriteUpdates
	/// </summary>
	/// <param name="jsonKeys"></param>
	public void WriteUpdates (Dictionary<string,Update> jsonKeys) {
		_Output.Write ("    \"updates\" : {{\n{0}", _Indent);
		 var sep = new Separator  (",\n");
		foreach  (var jsonKey in jsonKeys) {
			_Output.Write ("{1}", _Indent, sep);
			_Output.Write ("\"{1}\" : {2}", _Indent, jsonKey.Key, JSONDebugWriter.Write(jsonKey.Value, false));
			}
		_Output.Write ("}}\n{0}", _Indent);
		}
	
	/// <summary>	
	/// WriteCryptoKeys
	/// </summary>
	/// <param name="jsonKeys"></param>
	public void WriteCryptoKeys (Dictionary<string,CryptoKey> jsonKeys) {
		_Output.Write ("    \"cryptoKeys\" : {{\n{0}", _Indent);
		 var sep = new Separator  (",\n");
		foreach  (var jsonKey in jsonKeys) {
			_Output.Write ("{1}", _Indent, sep);
			_Output.Write ("\"{1}\" : {2}", _Indent, jsonKey.Key, JSONDebugWriter.Write(jsonKey.Value, false));
			}
		_Output.Write ("}}\n{0}", _Indent);
		}
	

	//
	// EarlExamples
	//
	public static void EarlExamples(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlExamples.md");
		Example._Output = _Output;
		Example._EarlExamples(Example);
		}
	public void _EarlExamples(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlLocator);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlName);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlJSContact);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("All three forms refer to the exact same data object. The first two forms are URLs\n{0}", _Indent);
			_Output.Write ("that indicate that the corresponding ciphertext MAY be retreived via HTTPS at:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.LocatorUri);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlExamplesLocator
	//
	public static void EarlExamplesLocator(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlExamplesLocator.md");
		Example._Output = _Output;
		Example._EarlExamplesLocator(Example);
		}
	public void _EarlExamplesLocator(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlLocator);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// EarlExamplesName
	//
	public static void EarlExamplesName(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlExamplesName.md");
		Example._Output = _Output;
		Example._EarlExamplesName(Example);
		}
	public void _EarlExamplesName(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlName);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// Type0Envelope
	//
	public static void Type0Envelope(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type0Envelope.md");
		Example._Output = _Output;
		Example._Type0Envelope(Example);
		}
	public void _Type0Envelope(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, the payload:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\"{1}\" =\n{0}", _Indent, Example.TestFile1Text);
			_Output.Write ("{1}\n{0}", _Indent, earl.Payload.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Is encoded as a Type 0 envelope without metadata by concatenating \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* ???\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* The envelope type identifier (0), \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate an empty metadata field,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of payload bytes ({1}) followed by the payload bytes.\n{0}", _Indent, earl.Payload.Length);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EnvelopeContent.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Type0Meta
	//
	public static void Type0Meta(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type0Meta.md");
		Example._Output = _Output;
		Example._Type0Meta(Example);
		}
	public void _Type0Meta(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The same payload as before MAY be enveloped with the following metadata:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ProtectedHeaderJson);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The enveloped content is as before except that the metadata field is now specified:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.BytesMeta.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Type1Envelope
	//
	public static void Type1Envelope(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type1Envelope.md");
		Example._Output = _Output;
		Example._Type1Envelope(Example);
		}
	public void _Type1Envelope(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\"{1}\"\n{0}", _Indent, earl.FirstChunk);
			_Output.Write ("\"{1}\"\n{0}", _Indent, earl.SecondChunk);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Is encoded as a Type 1 envelope by concatenating:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* ???\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* The envelope type identifier (1), \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate an empty unprotected header field,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of metadata bytes followed by the metadata,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of bytes in the first chunk followed by the first chunk,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of bytes in the second chunk followed by the second chunk,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate the end of the payload section,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate an empty trailer field.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.BytesUnsigned.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlKeyDerivation
	//
	public static void EarlKeyDerivation(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlKeyDerivation.md");
		Example._Output = _Output;
		Example._EarlKeyDerivation(Example);
		}
	public void _EarlKeyDerivation(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The content digest of the envelope shown in the first example is computed using SHAK256:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ContentDigest.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first byte of the result is set to the type identifier {1}, truncated\n{0}", _Indent, earl.VersionTag);
			_Output.Write ("to the desired precision ({1} bits):\n{0}", _Indent, earl.Precision);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ContentDigestTruncated.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The multipurpose key presentation is the result presented in Base32 with the characters \n{0}", _Indent);
			_Output.Write ("grouped into sets of four with dashes:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlPath);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that since there is an odd number of 20-bit segments in this example, only \n{0}", _Indent);
			_Output.Write ("the upper half of the last byte is recorded in the key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 var path = earl.EarlPath.FromBase32(partial: true);
			_Output.Write ("{1}\n{0}", _Indent, path.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The EARL forms consist of the scheme name, authority section (if specified) and the \n{0}", _Indent);
			_Output.Write ("presentation form of the multi-purpose key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlLocator);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlName);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlJSContact);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Type0Nonce
	//
	public static void Type0Nonce(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type0Nonce.md");
		Example._Output = _Output;
		Example._Type0Nonce(Example);
		}
	public void _Type0Nonce(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If a different nonce is specified in the metadata:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ProtectedHeaderJson2);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A different multi-purpose key is derived:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.WithNonce.Uri);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlEncryption
	//
	public static void EarlEncryption(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlEncryption.md");
		Example._Output = _Output;
		Example._EarlEncryption(Example);
		}
	public void _EarlEncryption(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since the encryption algorithm is AES-GCM with a 96 nonce and a 256 bit key,\n{0}", _Indent);
			_Output.Write ("it is necessary to generate 44 bytes to encrypt the enveloped data.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The key derrivation function, SHAKE-256 is applied to the multi-purpose key \n{0}", _Indent);
			_Output.Write ("of the first example to obtain 44 bytes of output:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.AesKeyNonce.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first 32 bytes of the result are the AES-GCM encryption key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("encryption key =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.AesKeyNonce[0..32].ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The final 12 bytes of the result are the AES-GCM nonce:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("encryption nonce = \n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.AesKeyNonce[32..].ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The enveloped plaintext data is encrypted under AES-GCM with the specified key and \n{0}", _Indent);
			_Output.Write ("nonce to produce the ciphertext:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("ciphertext = \n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Ciphertext.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// EarlLocator
	//
	public static void EarlLocator(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlLocator.md");
		Example._Output = _Output;
		Example._EarlLocator(Example);
		}
	public void _EarlLocator(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first locator value is computed from the multi-purpose key using the  \n{0}", _Indent);
			_Output.Write ("locator digest function, in this case SHA-3-256:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("locator1 =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Locator1.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The locator value is computed from the first locator value using the  \n{0}", _Indent);
			_Output.Write ("locator digest function, in this case SHA-3-256:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("locator =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Locator1.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The locator URI is a HTTPS well-known service in which the final element of the\n{0}", _Indent);
			_Output.Write ("path is the base64url encoded locator value.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("EARL =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.LocatorUri);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlAuthenticatedLocator
	//
	public static void EarlAuthenticatedLocator(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlAuthenticatedLocator.md");
		Example._Output = _Output;
		Example._EarlAuthenticatedLocator(Example);
		}
	public void _EarlAuthenticatedLocator(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("access authenticator =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Password);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Unprotected
	//
	public static void Unprotected(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Unprotected.md");
		Example._Output = _Output;
		Example._Unprotected(Example);
		}
	public void _Unprotected(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Unprotected Header =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.Header);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlManifest
	//
	public static void EarlManifest(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlManifest.md");
		Example._Output = _Output;
		Example._EarlManifest(Example);
		}
	public void _EarlManifest(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Metadata digest =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.MetadataDigest.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Payload digest =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.PayloadDigest.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Manifest =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.Manifest.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SignedEnvelope25519
	//
	public static void SignedEnvelope25519(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SignedEnvelope25519.md");
		Example._Output = _Output;
		Example._SignedEnvelope25519(Example);
		}
	public void _SignedEnvelope25519(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Ed25519 private key =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, (earl.SignatureEd25519 as KeyPairEd25519).PrivateKey.Secret.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The trailer contains a Signatures property with a single entry specifying the key \n{0}", _Indent);
			_Output.Write ("identifier of the signing key and the signature value:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Trailer =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.Trailer);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SignedEnvelope448
	//
	public static void SignedEnvelope448(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SignedEnvelope448.md");
		Example._Output = _Output;
		Example._SignedEnvelope448(Example);
		}
	public void _SignedEnvelope448(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The process for signing with an Ed448 key is identical except that achieving the\n{0}", _Indent);
			_Output.Write ("higher work factor requires use of a 512 bit digest:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Unprotected Header =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.SignedEd448.Header);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The private key used to generate the signature in this example is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Ed448 private key =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, (earl.SignatureEd448 as KeyPairEd448).PrivateKey.Secret.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The signature value is specified in the trailer as before:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Trailer =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.SignedEd448.Trailer);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// DareSchemaCatalog
	//
	public static void DareSchemaCatalog(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSchemaCatalog.md");
		Example._Output = _Output;
		Example._DareSchemaCatalog(Example);
		}
	public void _DareSchemaCatalog(CreateExamples Example) {

			 Unfinished ("DareSchemaCatalog");
				}
	

	//
	// DareSchemaSpool
	//
	public static void DareSchemaSpool(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSchemaSpool.md");
		Example._Output = _Output;
		Example._DareSchemaSpool(Example);
		}
	public void _DareSchemaSpool(CreateExamples Example) {

			 Unfinished ("DareSchemaSpool");
				}
	

	//
	// MeshExamplesContainer
	//
	public static void MeshExamplesContainer(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ExamplesContainer.md");
		Example._Output = _Output;
		Example._MeshExamplesContainer(Example);
		}
	public void _MeshExamplesContainer(CreateExamples Example) {

			_Output.Write ("The data payloads in all the following examples are identical, only the\n{0}", _Indent);
			_Output.Write ("authentication and/or encryption is different. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* Frame 0 is omitted in each case\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* Frame 1..n consists of 300 bytes being the byte sequence 00, 01, 02, etc. \n{0}", _Indent);
			_Output.Write ("repeating after 256 bytes.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For conciseness, the raw data format is omitted for examples after the first, except\n{0}", _Indent);
			_Output.Write ("where the data payload has been transformed, (i.e. encrypted).\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Simple sequence\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following example shows a simple sequence with first frame and a single data frame:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}~~~~\n{0}", _Indent, Dare.ContainerFramingSimple);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since there is no integrity check, there is no need for trailer entries.\n{0}", _Indent);
			_Output.Write ("The header values are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			DumpHeaders (Dare.ContainerHeadersSimple);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Payload and chain digests\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following example shows a chain sequence with a first frame and three \n{0}", _Indent);
			_Output.Write ("data frames. The headers of these frames is the same as before but the\n{0}", _Indent);
			_Output.Write ("frames now have trailers specifying the PayloadDigest and ChainDigest values:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			DumpHeaders (Dare.ContainerHeadersChain);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Merkle Tree\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following example shows a chain sequence with a first frame and six \n{0}", _Indent);
			_Output.Write ("data frames. The trailers now contain the TreePosition and TreeDigest\n{0}", _Indent);
			_Output.Write ("values:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			DumpHeaders (Dare.ContainerHeadersMerkleTree);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Signed sequence\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following example shows a tree sequence with a signature in the final record.\n{0}", _Indent);
			_Output.Write ("The signing key parameters are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.SignatureAliceKey));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The sequence headers and trailers are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			DumpHeaders (Dare.ContainerHeadersSigned);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Encrypted sequence\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following example shows a sequence in which all the frame payloads are encrypted \n{0}", _Indent);
			_Output.Write ("under the same base seed established in a key agreement specified in the first frame.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			DumpHeaders (Dare.ContainerHeadersEncryptSingleSession);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Here are the sequence bytes. Note that the content is now encrypted and has expanded by\n{0}", _Indent);
			_Output.Write ("25 bytes. These are the salt (16 bytes), the AES padding (4 bytes) and the \n{0}", _Indent);
			_Output.Write ("JSON-B framing (5 bytes).\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Dare.ContainerFramingEncrypted);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following example shows a sequence in which all the frame payloads are encrypted \n{0}", _Indent);
			_Output.Write ("under separate key agreements specified in the payload frames.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			DumpHeaders (Dare.ContainerHeadersEncryptIndependentSession);
			_Output.Write ("\n{0}", _Indent);
				}
	
	/// <summary>	
	/// DumpHeaders
	/// </summary>
	/// <param name="Frames"></param>
	public void DumpHeaders (List<SequenceFrame> Frames) {
		 if (Frames == null) {ReportMissing(); return;}
		foreach  (var Frame in Frames) {
			 DumpHeader (Frame);
			}
		}
	
	/// <summary>	
	/// DumpHeader
	/// </summary>
	/// <param name="Frame"></param>
	public void DumpHeader (SequenceFrame Frame) {
		 if (Frame == null) {ReportMissing(); return;}
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("Frame {1}\n{0}", _Indent, Frame.Header.SequenceInfo.Index);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("~~~~\n{0}", _Indent);
		_Output.Write ("{1}\n{0}", _Indent,  JSONDebugWriter.Write (Frame.Header));
		_Output.Write ("\n{0}", _Indent);
		if (  (Frame.Trailer != null) ) {
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write(Frame.Trailer));
			} else {
			_Output.Write ("[Empty trailer]\n{0}", _Indent);
			}
		_Output.Write ("~~~~\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		}
	

	//
	// MeshExamplesMessageMail
	//
	public static void MeshExamplesMessageMail(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ExamplesDAREMessageMail.md");
		Example._Output = _Output;
		Example._MeshExamplesMessageMail(Example);
		}
	public void _MeshExamplesMessageMail(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, consider the following mail message:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}~~~~\n{0}", _Indent, Dare.MailMessageAsRFC822);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Existing encryption approaches require that header fields such as the subject line be encrypted \n{0}", _Indent);
			_Output.Write ("with the body of the message or not encrypted at all. Neither approach is satisfactory.\n{0}", _Indent);
			_Output.Write ("In this example, the subject line gives away important information that the sender\n{0}", _Indent);
			_Output.Write ("probably assumed would be encrypted. But if the subject line is encrypted together with the\n{0}", _Indent);
			_Output.Write ("message body, a mail client must retrieve at least part of the message body to provide a \n{0}", _Indent);
			_Output.Write ("'folder' view.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The plaintext form of the equivalent DARE Message encoding is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.MailMessageAsDAREPlaintext, false));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This contains the same information as before but the data we might wish to encrypt to\n{0}", _Indent);
			_Output.Write ("protect the confidentiality of the payload is separated from data required for \n{0}", _Indent);
			_Output.Write ("processing.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// MeshExamplesMessageEDS
	//
	public static void MeshExamplesMessageEDS(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ExamplesDAREMessageEDS.md");
		Example._Output = _Output;
		Example._MeshExamplesMessageEDS(Example);
		}
	public void _MeshExamplesMessageEDS(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The encoding of the 'From' header of the previous example as a plaintext EDS is as follows:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Dare.EDSText);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// MeshExamplesMessageEncrypted
	//
	public static void MeshExamplesMessageEncrypted(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\MeshExamplesMessageEncrypted.md");
		Example._Output = _Output;
		Example._MeshExamplesMessageEncrypted(Example);
		}
	public void _MeshExamplesMessageEncrypted(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following is an encrypted version of the message shown earlier. \n{0}", _Indent);
			_Output.Write ("The payload and annotations have both increased in size as a result\n{0}", _Indent);
			_Output.Write ("of the block cipher padding. The header now\n{0}", _Indent);
			_Output.Write ("includes Recipients and Salt fields to enable the content to be decoded.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.MailMessageAsDAREEncrypted, false));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For efficiency of processing, the ContentMetaData is presented in plaintext.\n{0}", _Indent);
			_Output.Write ("This header could be encrypted as an EDS sequence and presented as a \n{0}", _Indent);
			_Output.Write ("cloaked header.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ExamplesDAREMessage
	//
	public static void ExamplesDAREMessage(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ExamplesDAREMessage.md");
		Example._Output = _Output;
		Example._ExamplesDAREMessage(Example);
		}
	public void _ExamplesDAREMessage(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("#Test Examples\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("In the following examples, Alice's encryption private key parameters are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.DareMessageAliceKey));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write (" Alice's signature private key parameters are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.SignatureAliceKey));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The body of the test message is the UTF8 representation of the following string:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\"{1}\"\n{0}", _Indent, Dare.DareMessageTest1.ToUTF8());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The EDS sequences, are the UTF8 representation of the following strings:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\"{1}\"\n{0}", _Indent, Dare.DareMessageTest2.ToUTF8());
			_Output.Write ("\"{1}\"\n{0}", _Indent, Dare.DareMessageTest3.ToUTF8());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Plaintext Message\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A plaintext message without associated EDS sequences is an empty header\n{0}", _Indent);
			_Output.Write ("followed by the message body:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.DAREMessageAtomic));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Plaintext Message with EDS\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If a plaintext message contains EDS sequences, these are also in plaintext:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.MessageAtomicDS));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Encrypted Message\n{0}", _Indent);
			 var CryptoStackEncrypt = Dare.CryptoStackEncrypt;
			 var encHeader = Dare.MailMessageAsDAREEncrypted?.Header;
			 var Recipient = encHeader?.Recipients?[0] as Goedel.Test.Core.DareRecipientDebug;
			 var MessageEnc = Dare.MessageEnc;
			 var Salt = MessageEnc?.Header?.Salt;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The creator generates a base seed:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (CryptoStackEncrypt?.BaseSeed);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For each recipient of the message:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The creator generates an ephemeral key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Recipient?.EphemeralPrivate));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The key agreement value is calculated:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (Recipient?.KeyAgreement);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The key agreement value is used as the input to a HKDF key\n{0}", _Indent);
			_Output.Write ("derivation function with the info parameter \n{0}", _Indent);
			_Output.Write ("{1} to create the key used to wrap the base seed:\n{0}", _Indent, DareRecipient.KDFInfo.ToUTF8());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (Recipient?.EncryptionKey);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The wrapped base seed is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (Recipient?.WrappedBaseSeed);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This information is used to calculate the Recipient information\n{0}", _Indent);
			_Output.Write ("shown in the example below.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To encrypt a message, we first generate a unique salt value:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (Salt);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The base seed and salt value are used to generate the payload encryption\n{0}", _Indent);
			_Output.Write ("key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (CryptoStackEncrypt?.KeyEncrypt);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since AES is a block cipher, we also require an initializarion vector:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (CryptoStackEncrypt?.IV);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The output sequence is the encrypted bytes:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 WriteBytesHex (Dare.MessageEnc?.Body);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since the message is not signed, there is no need for a trailer.\n{0}", _Indent);
			_Output.Write ("The completed message is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.MessageEnc));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Signed Message\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Signed messages specify the digest algorithm to be used in the header and\n{0}", _Indent);
			_Output.Write ("the signature value in the trailer. Note that the digest algorithm is not optional\n{0}", _Indent);
			_Output.Write ("since it serves as notice that a decoder should digest the payload value \n{0}", _Indent);
			_Output.Write ("to enable signature verification.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.DAREMessageAtomicSign));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Signed and Encrypted Message\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A signed and encrypted message is encrypted and then signed.\n{0}", _Indent);
			_Output.Write ("The signer proves knowledge of the payload plaintext by providing the\n{0}", _Indent);
			_Output.Write ("plaintext witness value.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Dare.DAREMessageAtomicSignEncrypt));
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	}
