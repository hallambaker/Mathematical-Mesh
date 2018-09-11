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
		// MeshExamplesContainer
		//
		public static void MeshExamplesContainer (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesContainer.md")) {
				var _Indent = ""; 
				 var ExampleGenerator = new ExampleGenerator () { _Output = _Output };
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
				_Output.Write ("##Simple container\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("the following example shows a simple container with first frame and a single data frame:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}~~~~\n{0}", _Indent, Example.ContainerFramingSimple);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since there is no integrity check, there is no need for trailer entries.\n{0}", _Indent);
				_Output.Write ("The header values are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				ExampleGenerator.DumpHeaders (Example.ContainerHeadersSimple);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Payload and chain digests\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following example shows a chain container with a first frame and three \n{0}", _Indent);
				_Output.Write ("data frames. The headers of these frames is the same as before but the\n{0}", _Indent);
				_Output.Write ("frames now have trailers specifying the PayloadDigest and ChainDigest values:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				ExampleGenerator.DumpHeaders (Example.ContainerHeadersChain);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Merkle Tree\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following example shows a chain container with a first frame and six \n{0}", _Indent);
				_Output.Write ("data frames. The trailers now contain the TreePosition and TreeDigest\n{0}", _Indent);
				_Output.Write ("values:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				ExampleGenerator.DumpHeaders (Example.ContainerHeadersMerkleTree);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Signed container\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following example shows a tree container with a signature in the final record.\n{0}", _Indent);
				_Output.Write ("The signing key parameters are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.SignatureAliceKey));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The container headers and trailers are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				ExampleGenerator.DumpHeaders (Example.ContainerHeadersSigned);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Encrypted container\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following example shows a container in which all the frame payloads are encrypted \n{0}", _Indent);
				_Output.Write ("under the same master secret established in a key agreement specified in the first frame.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				ExampleGenerator.DumpHeaders (Example.ContainerHeadersEncryptSingleSession);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Here are the container bytes. Note that the content is now encrypted and has expanded by\n{0}", _Indent);
				_Output.Write ("25 bytes. These are the salt (16 bytes), the AES padding (4 bytes) and the \n{0}", _Indent);
				_Output.Write ("JSON-B framing (5 bytes).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.ContainerFramingEncrypted);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following example shows a container in which all the frame payloads are encrypted \n{0}", _Indent);
				_Output.Write ("under separate key agreements specified in the payload frames.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				ExampleGenerator.DumpHeaders (Example.ContainerHeadersEncryptIndependentSession);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// DumpHeaders
		//
		public void DumpHeaders (List<ContainerFrame> Frames) {
			foreach  (var Frame in Frames) {
				 DumpHeader (Frame);
				}
			}
		

		//
		// DumpHeader
		//
		public void DumpHeader (ContainerFrame Frame) {
			_Output.Write ("Frame {1}\n{0}", _Indent, Frame.Header.Index);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Frame.Header);
			_Output.Write ("\n{0}", _Indent);
			if (  (Frame.Trailer != null) ) {
				_Output.Write ("{1}\n{0}", _Indent, Frame.Trailer);
				} else {
				_Output.Write ("[Empty trailer]\n{0}", _Indent);
				}
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		}
	}
