using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// UserGuideRecrypt
		//
		public static void UserGuideRecrypt (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Apps/recrypt.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Recrypt\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mesh/Recrypt\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>End to End security done right\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh/Recrypt is a data level encryption infrastructure that allows encrypted data to\n{0}", _Indent);
				_Output.Write ("be shared with groups of users that change over time.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Previous data level encryption schemes, forced a choice between true end to end encryption\n{0}", _Indent);
				_Output.Write ("(provided by OpenPGP and S/MIME) and the ability to change groups over time (key manager\n{0}", _Indent);
				_Output.Write ("based CRM systems). Mesh/Recrypt provides both benefits at once through use of \n{0}", _Indent);
				_Output.Write ("<a=\"/Technical/Technology/recryption.html\">proxy re-encryption</a>, a form of \n{0}", _Indent);
				_Output.Write ("public key cryptography that uses three keys instead of the usual two.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In traditional public key encryption, the public key is used to encrypt data\n{0}", _Indent);
				_Output.Write ("and the private key is used to decrypt. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In the proxy re-encryption scheme used in Mesh/Recrypt, the public key is used to \n{0}", _Indent);
				_Output.Write ("encrypt data in the exact same way as for two key cryptography but the decryption\n{0}", _Indent);
				_Output.Write ("key is split into two parts. One half of which is held by the recipient and the \n{0}", _Indent);
				_Output.Write ("other half of which is sent to a recryption service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, ToDo ("RecryptDiagram","Here a Visio diagram of Proxy Re-encryption and the key server"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Decrypting encrypted data requires the use of both halves of the key. The recryption\n{0}", _Indent);
				_Output.Write ("service cannot decrypt data because it does not have access to the recipient's half\n{0}", _Indent);
				_Output.Write ("of the decryption key and the recipient can't decrypt the data unless the recryption\n{0}", _Indent);
				_Output.Write ("service performs its half of the work and returns the result to the recipient.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This approach has important benefits:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Data cannot be decrypted without the decryption key held by the recipient, thus\n{0}", _Indent);
				_Output.Write ("encryption end-to-end. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Even a total breach of the recryption service does not result in disclosure of\n{0}", _Indent);
				_Output.Write ("the data unless at least one recipient decryption key is also compromised.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Recipients may be added to a recryption group at any time and immediately gain access\n{0}", _Indent);
				_Output.Write ("to all data previously encrypted to the group.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* If a recipient is removed from a recryption group, the recyption service can\n{0}", _Indent);
				_Output.Write ("deny further access to the data encrypted under that group by refusing recryption \n{0}", _Indent);
				_Output.Write ("requests from that recipient.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* All access to encrypted data must be mediated through the recryption service.\n{0}", _Indent);
				_Output.Write ("The recryption service may therefore enforce audit and accounting controls, detect\n{0}", _Indent);
				_Output.Write ("and prevent suspicious behavior.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Creating a recryption group.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>meshapp</tt> tool is used to create and manage recryption groups. To use the \n{0}", _Indent);
				_Output.Write ("recryption features, the user must first create an account with the recryption service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("AccountAlice"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having created her account, Alice can now create (one or more) recyption groups. Alice\n{0}", _Indent);
				_Output.Write ("adds herself to the membership list:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("recryptCreate"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Membership of the recryption group is only necesary to decrypt (read) data. It \n{0}", _Indent);
				_Output.Write ("is not necessary to be a member of the recryption group to encrypt (write). \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob encrypts a document for the group users:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("recryptEncrypt"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("At this point, Mallet cannot read the document because he is not a member. But Alice\n{0}", _Indent);
				_Output.Write ("can add him:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("recryptAdd"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mallet can now decrypt the document:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("recryptDecrypt"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Remembering that Mallet is always the baddie, Alice removes him from the group:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("recryptDelete"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mallet cannot decrypt the document again but he may still have access if he saved the\n{0}", _Indent);
				_Output.Write ("copy he decrypted earlier:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("recryptDecryptFail"));
				}
			}
		}
	}
