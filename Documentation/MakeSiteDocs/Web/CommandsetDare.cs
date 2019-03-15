using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace MakeSiteDocs {
	public partial class MakeSiteDocs : global::Goedel.Registry.Script {

		

		//
		// WebDare
		//
		public static void WebDare(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/dare.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/dare.md" };
				obj._WebDare(Examples);
				}
			}
		public void _WebDare(Examples Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `dare` command set contains commands that encode, decode and verify \n{0}", _Indent);
				_Output.Write ("DARE messages.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Encoding a file as a DARE message.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to encode files as DARE Messages:\n{0}", _Indent, ToCommand("dare encode"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DarePlaintext);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In this case, the file `{1}` contains the text `\"{2}\"`.\n{0}", _Indent, Examples.TestFile1, Examples.TestText1);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("By default, a content digest is calculated over the contents. This may be \n{0}", _Indent);
				_Output.Write ("suppressed using the `/nohash` flag.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The data contents may be encrypted and authenticated under a specified symmetric key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareSymmetric);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Specifying a directory instead of a file causes all the files in the directory to be \n{0}", _Indent);
				_Output.Write ("encoded:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareSub);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Files may also be signed using the user's Mesh signature key and/or encrypted for one\n{0}", _Indent);
				_Output.Write ("or more recipients. In this example, Alice creates a message intended for Bob.\n{0}", _Indent);
				_Output.Write ("Alice signs the message with her private signature key and encrypts it under Bob's\n{0}", _Indent);
				_Output.Write ("public encryption key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareMesh);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Verifying a DARE message.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to verify the signature and \n{0}", _Indent, ToCommand("dare verify"));
				_Output.Write ("digest values on a DARE Message without decoding the message body:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareVerifyDigest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The command to verify a signed message is identical:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareVerifySigned);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Messages that are encrypted and authenticated under a specified symmetric key \n{0}", _Indent);
				_Output.Write ("may be verified at the plaintext level if the key is known or the ciphertext \n{0}", _Indent);
				_Output.Write ("level otherwise.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareVerifySymmetric);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareVerifySymmetricUnknown);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Decoding a DARE message to a file.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to decode and verify DARE Messages:\n{0}", _Indent, ToCommand("dare decode"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareDecodePlaintext);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To decode a message encrypted under a symmetric key, we must specify the key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareDecodeSymmetric);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the message is encrypted under our private encryption key, the tool will locate\n{0}", _Indent);
				_Output.Write ("the necessary decryption key(s) automatically:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareDecodePrivate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating an EARL.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to create an EARL:\n{0}", _Indent, ToCommand("dare earl"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareEarl);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A new secret is generated with the specified number of bits, this is then used\n{0}", _Indent);
				_Output.Write ("to generate the key identifier and encrypt the input file to a file with the\n{0}", _Indent);
				_Output.Write ("name of the key identifier.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/log` option causes the filename, encryption key and other details of\n{0}", _Indent);
				_Output.Write ("the transaction to be written to a DARE Container Log.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareEARLLog);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/new` option causes the file to be encoded if and only if it has not \n{0}", _Indent);
				_Output.Write ("been processed already.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareEARLLogNew);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// DareReference
		//
		public static void DareReference(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/dare.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/dare.md" };
				obj._DareReference(Examples);
				}
			}
		public void _DareReference(Examples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Dare;
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `dare` command set contains commands that encode, decode and verify \n{0}", _Indent);
				_Output.Write ("DARE messages.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DareEncode._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `dare encode` command encrypts a file and writes the output to a DARE Message.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the input file specified is a file, the tool processes that file. If the\n{0}", _Indent);
				_Output.Write ("input file is a directory, the tool processes all the files in the directory. If the\n{0}", _Indent);
				_Output.Write ("`/sub` option is specified, subdirectories are processed recursively.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("By default, a digest value is calculated over the message body (i.e. the ciphertext\n{0}", _Indent);
				_Output.Write ("if it is encrypted). This may be suppressed using the `/nohash` option.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The tool attempts to determine the IANA media type of the file from the file \n{0}", _Indent);
				_Output.Write ("extension. This may be overriden using the /cty `option`.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Encryption and Signature enhancements may be specified with the `/sign` and \n{0}", _Indent);
				_Output.Write ("`/encrypt` options. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Key parameters that have the form of a UDF secret (Exxx-xxxx-...) are interpreted\n{0}", _Indent);
				_Output.Write ("as symmetric encryption keys and used to encrypt the contents directly.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Key parameters that have the form of an Internet user account (\\<user\\>@\\<domain\\> are \n{0}", _Indent);
				_Output.Write ("resolved according to the currently active key collection.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The active key collection may be overriden using the `/mesh` option.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Algorithms for public key operations are inferred from the keys provided. The \n{0}", _Indent);
				_Output.Write ("`\\alg` option may be used to override the inferred or default algorithms.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/out` option may be used to specify the output file name. Otherwise the output\n{0}", _Indent);
				_Output.Write ("file name is the input file name with the additional extension `.dare`.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.DareSymmetric);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DareDecode._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `dare decode` command decodes the specified input file using keys found in the\n{0}", _Indent);
				_Output.Write ("currently active key collection.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The active key collection may be overriden using the `/mesh` option.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/out` option may be used to specify the output file name. Otherwise the output\n{0}", _Indent);
				_Output.Write ("file name is the input file name stripped of the extension `.dare` if present or\n{0}", _Indent);
				_Output.Write ("with the extension `.undare` otherwise.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.DareDecodeSymmetric);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DareVerify._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `dare decode` command verifies the specified input file using keys found in the\n{0}", _Indent);
				_Output.Write ("currently active key collection and reports success or failure.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The active key collection may be overriden using the `/mesh` option.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.DareVerifySymmetric);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DareEARL._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to encode an input file and return\n{0}", _Indent, ToCommand("dare earl"));
				_Output.Write ("(or log) the corresponding identifier information in a format that enables use\n{0}", _Indent);
				_Output.Write ("as an Encrypted Authenticated Resource Locator.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the input file specified is a file, the tool processes that file. If the\n{0}", _Indent);
				_Output.Write ("input file is a directory, the tool processes all the files in the directory. If the\n{0}", _Indent);
				_Output.Write ("`/sub` option is specified, subdirectories are processed recursively.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the `/log` or `/new` option is specified, the filename, encryption key and other details of\n{0}", _Indent);
				_Output.Write ("each completed transaction are written to a DARE Container Log. If `/log` is specified, the \n{0}", _Indent);
				_Output.Write ("file is always processed. If `/new` is specified, files are only\n{0}", _Indent);
				_Output.Write ("processed if there is no existing entry in the specified log.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The log file must be initialized before use (eg. using the {1} \n{0}", _Indent, ToCommand("container create"));
				_Output.Write ("command). Log entries are written with the cryptographic enhancements specified in\n{0}", _Indent);
				_Output.Write ("the container using the active key collection.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The active key collection may be overriden using the `/mesh` option.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.DareEarl);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
