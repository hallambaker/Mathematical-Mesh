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
	}
