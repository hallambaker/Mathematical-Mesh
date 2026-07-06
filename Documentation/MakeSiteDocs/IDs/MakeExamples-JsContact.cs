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
		 JSContactSchema(Example);
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
		 JSContactComplete(Example);
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
		_Output.Write ("{1},\n{0}", _Indent, JSONDebugWriter.Write(example, true, 2));
		_Output.Write ("    ...\n{0}", _Indent);
		_Output.Write ("    }}\n{0}", _Indent);
		}
	
	/// <summary>	
	/// CardExample
	/// </summary>
	/// <param name="parent"></param>
	/// <param name="example1"></param>
	/// <param name="example2"></param>
	public void CardExample (string parent, JsonObject example1, JsonObject example2) {
		_Output.Write ("{{\n{0}", _Indent);
		_Output.Write ("  \"@type\":\"Card\",\n{0}", _Indent);
		_Output.Write ("  ...\n{0}", _Indent);
		_Output.Write ("  \"{1}\" : ", _Indent, parent);
		_Output.Write ("{1},\n{0}", _Indent, JSONDebugWriter.Write(example1, true, 2));
		_Output.Write ("  ...\n{0}", _Indent);
		_Output.Write ("{1},\n{0}", _Indent, JSONDebugWriter.Write(example2, true, 2));
		_Output.Write ("  ...\n{0}", _Indent);
		_Output.Write ("  }}\n{0}", _Indent);
		_Output.Write ("~~~~\n{0}", _Indent);
		}
	
	/// <summary>	
	/// StartCard
	/// </summary>
	/// <param name="ignore=true"></param>
	public void StartCard (bool ignore=true) {
		_Output.Write ("~~~~\n{0}", _Indent);
		_Output.Write ("{{\n{0}", _Indent);
		_Output.Write ("  \"@type\":\"Card\",\n{0}", _Indent);
		_Output.Write ("  ...\n{0}", _Indent);
		}
	
	/// <summary>	
	/// EndCard
	/// </summary>
	/// <param name="ignore=true"></param>
	public void EndCard (bool ignore=true) {
		_Output.Write ("  }}\n{0}", _Indent);
		_Output.Write ("~~~~\n{0}", _Indent);
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
			 // For example, Alice has many OpenPGP keys but only one that she uses with her email address alice@example.com
			 WriteTags (jscontact.Contact, ["email1", "emailKey", "emailKey1"]);
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
			 WriteTags (jscontact.Contact, ["ssh1", "sshKey1"]);
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
			 WriteTags (jscontact.Contact, ["group1", "email1", "git1", "ssh1"]);
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
			 WriteTags (jscontact.Contact, ["update1", "updateKey1"]);
				}
	

	//
	// JSContactSchema
	//
	public static void JSContactSchema(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactSchema.md");
		Example._Output = _Output;
		Example._JSContactSchema(Example);
		}
	public void _JSContactSchema(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Additional Card Properties\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The following properties are added to the Card object specified in [RFC9553].\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 jscontact.AnnotatedSchema.DocumentProperties(_Output, "Card",[ "updates", "serviceGroups"],
			        jscontact.Contact);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Extension to the EmailAddress Object\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The EmailAddress object specified in [RFC9553] is extended to add the specified property.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 jscontact.AnnotatedSchema.DocumentStructure(_Output, "EmailAddress", ["cryptoKeyIds"], 
			      jscontact.EmailAddress, writeHeading: false);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Extension to the OnlineService Object\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The OnlineService object specified in [RFC9553] is extended to add the specified property.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 jscontact.AnnotatedSchema.DocumentStructure(_Output, "OnlineService", ["cryptoKeyIds"],
			      jscontact.OnlineServiceWithKeys, writeHeading: false);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## New Object JsonWebKeySet\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The JsonWebKeySet object is added to the Card object with the following properties:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 jscontact.AnnotatedSchema.DocumentStructure(_Output, "JsonWebKeySet", null, 
			      jscontact.CryptoKeyWithJwk, writeHeading: false);;
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// JSContactComplete
	//
	public static void JSContactComplete(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactComplete.md");
		Example._Output = _Output;
		Example._JSContactComplete(Example);
		}
	public void _JSContactComplete(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			_Output.Write ("Alice's complete contact card is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{{jscontact.CompleteContact}}\n{0}", _Indent);
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
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, jscontact.EARL);
			_Output.Write ("~~~~\n{0}", _Indent);
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
	// JSContactSMIME
	//
	public static void JSContactSMIME(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSContactSMIME.md");
		Example._Output = _Output;
		Example._JSContactSMIME(Example);
		}
	public void _JSContactSMIME(CreateExamples Example) {

			 var jscontact = Example.JSContact;
			 WriteTags (jscontact.Contact, ["emailKey3", "emailKey4"]);
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
			 WriteTags (jscontact.Contact, ["emailKey1", "emailKey2"]);
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
			 WriteTags (jscontact.Contact, ["ssh1", "sshKey1", "sshKey2", "sshKey3"]);
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
			 WriteTags (jscontact.Contact, ["git1", "gitKey1"]);
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
			 WriteTags (jscontact.Contact, ["code1", "code2","codeSign1", "codeSign2"]);
				}
	
	/// <summary>	
	/// WriteTags
	/// </summary>
	/// <param name="contact"></param>
	/// <param name="include"></param>
	public void WriteTags (JsContact contact, List<string> include) {
		 StartCard ();
		 var trail = true;
		 WriteOut ("updates", contact.ServiceGroups, include, ref trail);
		 WriteOut ("serviceGroups", contact.ServiceGroups, include, ref trail, last:true);
		 WriteOut ("emails", contact.Emails, include, ref trail);
		 WriteOut ("onlineServices", contact.OnlineServices, include, ref trail);
		 WriteOut ("cryptoKeys", contact.CryptoKeys, include, ref trail, last:true);
		 EndCard ();
		}
	
	/// <summary>	
	/// 
	/// </summary>
		 public void WriteOut<T> (string tag, Dictionary<string,T> entries, 
		      List<string> include, ref bool trail, bool last=false) 
		      where T : JsonObject {
		if (  (JsContactResults.IsEmpty (include, entries))  ) {
			// [Suppress #{tag}]
			if (  trail ) {
				_Output.Write ("    ...\n{0}", _Indent);
				 trail = false;
				}
			 return;
			}
		_Output.Write ("  \"{1}\" : {{\n{0}", _Indent, tag);
		 var dots = true;
		foreach  (var entry in entries)  {
			if (  (JsContactResults.IsIncluded (include, entry.Key))  ) {
				 dots = true;
				_Output.Write ("    \"{1}\" : ", _Indent, entry.Key);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write(entry.Value, false, 3));
				} else if (  (dots) ) {
				 dots = false;
				_Output.Write ("    ...\n{0}", _Indent);
				}
			}
		if (  last ) {
			_Output.Write ("    }}\n{0}", _Indent);
			} else {
			_Output.Write ("    }},\n{0}", _Indent);
			}
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
	/// WriteEmails
	/// </summary>
	/// <param name="jsonKeys"></param>
	public void WriteEmails (Dictionary<string,EmailAddress> jsonKeys) {
		_Output.Write ("    \"emails\" : {{\n{0}", _Indent);
		 var sep = new Separator  (",\n");
		foreach  (var jsonKey in jsonKeys) {
			_Output.Write ("{1}", _Indent, sep);
			_Output.Write ("      \"{1}\" : {2}", _Indent, jsonKey.Key, JSONDebugWriter.Write(jsonKey.Value, false,4));
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
			_Output.Write ("      \"{1}\" : {2}", _Indent, jsonKey.Key, JSONDebugWriter.Write(jsonKey.Value, false,4));
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
			_Output.Write ("      \"{1}\" : {2}", _Indent, jsonKey.Key, JSONDebugWriter.Write(jsonKey.Value, false,4));
			}
		_Output.Write ("}}\n{0}", _Indent);
		}
	}
