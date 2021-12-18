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

	

	//
	// MakeDareExamples
	//
	public void MakeDareExamples (CreateExamples Example) {
		 MeshExamplesMessageMail(Example);
		 MeshExamplesMessageEDS(Example);
		 MeshExamplesMessageEncrypted(Example);
		 DareSchemaCatalog(Example);
		 DareSchemaSpool(Example);
		 ExamplesDAREMessage(Example);
		 MeshExamplesContainer(Example);
		}
	

	//
	// WriteBytesHex
	//
	public void WriteBytesHex (byte[] data) {
		if (  (data != null) ) {
			_Output.Write ("{1}\n{0}", _Indent, data.ToStringBase16FormatHex());
			} else {
			_Output.Write ("$$$ Missing data $$$\n{0}", _Indent);
			}
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
	

	//
	// DumpHeaders
	//
	public void DumpHeaders (List<SequenceFrame> Frames) {
		 if (Frames == null) {ReportMissing(); return;}
		foreach  (var Frame in Frames) {
			 DumpHeader (Frame);
			}
		}
	

	//
	// DumpHeader
	//
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
