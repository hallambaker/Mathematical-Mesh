using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// MeshExamplesMessageMail
		//
		public static void MeshExamplesMessageMail (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesDAREMessageMail.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, consider the following mail message:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}~~~~\n{0}", _Indent, Example.MailMessageAsRFC822);
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
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.MailMessageAsDAREPlaintext, false));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This contains the same information as before but the mail message headers are \n{0}", _Indent);
				_Output.Write ("now presented as  a list of Encoded Data Sequences.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamplesMessageEDS
		//
		public static void MeshExamplesMessageEDS (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesDAREMessageEDS.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The encoding of the 'From' header of the previous example as a plaintext EDS is as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.EDSText);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamplesMessageEncrypted
		//
		public static void MeshExamplesMessageEncrypted (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\MeshExamplesMessageEncrypted.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following is an encrypted version of the message shown earlier. \n{0}", _Indent);
				_Output.Write ("The payload and annotations have both increased in size as a result\n{0}", _Indent);
				_Output.Write ("of the block cipher padding. The header now\n{0}", _Indent);
				_Output.Write ("includes Recipients and Salt fields to enable the content to be decoded.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.MailMessageAsDAREEncrypted, false));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamplesMessage
		//
		public static void MeshExamplesMessage (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesDAREMessage.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Test Examples\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In the following examples, Alice's encryption private key parameters are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.DareMessageAliceKey));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write (" Alice's signature private key parameters are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.SignatureAliceKey));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The body of the test message is the UTF8 representation of the following string:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\"{1}\"\n{0}", _Indent, Example.DareMessageTest1.ToUTF8());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The EDS sequences, are the UTF8 representation of the following strings:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\"{1}\"\n{0}", _Indent, Example.DareMessageTest2.ToUTF8());
				_Output.Write ("\"{1}\"\n{0}", _Indent, Example.DareMessageTest3.ToUTF8());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Plaintext Message\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A plaintext message without associated EDS sequences is an empty header\n{0}", _Indent);
				_Output.Write ("followed by the message body:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.DAREMessageAtomic));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Plaintext Message with EDS\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If a plaintext message contains EDS sequences, these are also in plaintext:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.MessageAtomicDS));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Encrypted Message\n{0}", _Indent);
				 var CryptoStackEncrypt = Example.CryptoStackEncrypt;
				 var Recipient = CryptoStackEncrypt.Recipients[0] as Goedel.Test.Core.DareRecipientDebug;
				 var MessageEnc = Example.MessageEnc;
				 var Salt = MessageEnc.Header.Salt;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The creator generates a master session key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, CryptoStackEncrypt.MasterSecret.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For each recipient of the message:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The creator generates an ephemeral key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Recipient.EphemeralPrivate));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The key agreement value is calculated:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Recipient.KeyAgreement.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The key agreement value is used as the input to a HKDF key\n{0}", _Indent);
				_Output.Write ("derivation function with the info parameter \n{0}", _Indent);
				_Output.Write ("{1} to create the key used to wrap the master key:\n{0}", _Indent, DareRecipient.KDFSalt.ToUTF8());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Recipient.EncryptionKey.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The wrapped master key is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Recipient.WrappedMasterKey.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This information is used to calculate the Recipient information\n{0}", _Indent);
				_Output.Write ("shown in the example below.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To encrypt a message, we first generate a unique salt value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Salt.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The salt value and master key are used to generate the payload encryption\n{0}", _Indent);
				_Output.Write ("key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, CryptoStackEncrypt.KeyEncrypt.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since AES is a block cipher, we also require an initializarion vector:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, CryptoStackEncrypt.IV.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The output sequence is the encrypted bytes:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.MessageEnc.Body.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the message is not signed, there is no need for a trailer.\n{0}", _Indent);
				_Output.Write ("The completed message is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.MessageEnc));
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
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.DAREMessageAtomicSign));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Signed and Encrypted Message\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A signed and encrypted message is encrypted and then signed.\n{0}", _Indent);
				_Output.Write ("The signer proves knowledge of the payload plaintext by providing the\n{0}", _Indent);
				_Output.Write ("plaintext witness value.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.DAREMessageAtomicSignEncrypt));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
