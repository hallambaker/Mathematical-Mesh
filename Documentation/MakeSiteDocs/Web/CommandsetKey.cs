using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// WebKey
		//
		public static void WebKey(CreateExamples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/key.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/key.md" };
				obj._WebKey(Examples);
				}
			}
		public void _WebKey(CreateExamples Examples) {

				 MakeTitle ("key");
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `key` command set contains commands that operate on cryptographic secrets and\n{0}", _Indent);
				_Output.Write ("nonces.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Generating Secrets and Nonces\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Secrets and nonces both consist of a randomly generated sequence of bits. The\n{0}", _Indent);
				_Output.Write ("only distinction made between a secret and a nonce is the uses that may be \n{0}", _Indent);
				_Output.Write ("made of them. For example, a secret value must not be passed in clear text in \n{0}", _Indent);
				_Output.Write ("any circumstances. The visual distinction between these uses afforded by UDF \n{0}", _Indent);
				_Output.Write ("presentation aids application debugging and audit.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to generate a new random nonce value:\n{0}", _Indent, ToCommand("key nonce"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeyNonce);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Base32 presentation of a nonce value will always begin with the letter N.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("By default, a 128 bit nonce is generated but nonces of any length may be\n{0}", _Indent);
				_Output.Write ("generated using the `/bits` option:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeyNonce256);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Secrets are generated in the same way using the command `key secret`:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeySecret);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Base32 presentation of a secret value will always begin with the letter E.\n{0}", _Indent);
				_Output.Write ("Again, any output length can be requested up to the platform limit:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeySecret256);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Generating EARL values\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("An Encrypted Authenticated Resource locator is a form of URI that specifies \n{0}", _Indent);
				_Output.Write ("a means of locating and decrypting content stored on a remote Web service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The EARL itself specifies a domain name and a secret. The content is stored\n{0}", _Indent);
				_Output.Write ("on the Web Service under a label that is the Content Digest of the secret.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("EARLs may be generated using the {1} command to generate\n{0}", _Indent, ToCommand("key earl"));
				_Output.Write ("a new secret/digest pair which are then used to process the content data:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeyEarl);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alternatively, the {1} command may be used to perform both operations:\n{0}", _Indent, ToCommand("dare earl"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.DareEarl);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Sharing and recovering secrets\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Secret sharing splits a secret into a set of shares such that the original\n{0}", _Indent);
				_Output.Write ("secret can be recovered from a chosen number of shares called the quorum.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command creates a secret and splits it into the specified\n{0}", _Indent, ToCommand("key share"));
				_Output.Write ("number of shares with the specified quorum for recovery. By default, a 128\n{0}", _Indent);
				_Output.Write ("bit secret is created and three shares are created with a quorum of two:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeyShare);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The first UDF output is the secret key, followed by the key identifier \n{0}", _Indent);
				_Output.Write ("two shares. The different outputs are easily distinguished by their first \n{0}", _Indent);
				_Output.Write ("letter. As with every meshman command, the `/json` option may be used to \n{0}", _Indent);
				_Output.Write ("obtain the result as a JSON structure:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleJSON (Examples.KeyShare);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The original secret may be recovered from a sufficient number of shares to\n{0}", _Indent);
				_Output.Write ("meet the quorum using the {1}:\n{0}", _Indent, ToCommand("key recover"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.KeyRecover);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("As with secret generation, larger or smaller secrets may be created but due\n{0}", _Indent);
				_Output.Write ("to a limitation in the implementation of the key sharing algorithm, the secret \n{0}", _Indent);
				_Output.Write ("must be of length 512 bits or less and the number of bits is rounded up to\n{0}", _Indent);
				_Output.Write ("the nearest multiple of 32 bits.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, we can create a 192 bit secret and share it five ways with a quorum\n{0}", _Indent);
				_Output.Write ("of three:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeyShare2);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("It is also possible to share a specified secret. This allows a secret to be \n{0}", _Indent);
				_Output.Write ("shared multiple times creating independent key sets. If we re-share the secret\n{0}", _Indent);
				_Output.Write ("created earlier to create three shares with a quorum of two, the shares will\n{0}", _Indent);
				_Output.Write ("be different:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.KeyShare3);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// KeyReference
		//
		public static void KeyReference(CreateExamples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/key.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/key.md" };
				obj._KeyReference(Examples);
				}
			}
		public void _KeyReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Key;
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Key command set contains commands that operate on cryptographic keys and\n{0}", _Indent);
				_Output.Write ("nonces.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _KeyNonce._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `key nonce` command returns a randomized nonce value formatted as a UDF nonce type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Nonce values should be used when it is important that a value be unpredictable but \n{0}", _Indent);
				_Output.Write ("does not need to be kept secret. For example, the challenge in a challenge/response\n{0}", _Indent);
				_Output.Write ("protocol.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.KeyNonce);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _KeySecret._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `key secret` command returns a randomized secret value formatted as a UDF Encryption \n{0}", _Indent);
				_Output.Write ("key type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.KeySecret);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _KeyEarl._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `key earl` command returns a randomized secret value and a fingerprint of the secret \n{0}", _Indent);
				_Output.Write ("value, formatted as a UDF Encryption key type and Content Digest Type\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.KeyEarl);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _KeyShare._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `key share` command returns a randomized secret value and a set of shares for the secret\n{0}", _Indent);
				_Output.Write ("formatted as a UDF Encryption key type and Share types\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.KeyShare);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _KeyRecover._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `key recover` command combines the specified set of share to recover the original secret \n{0}", _Indent);
				_Output.Write ("value as a UDF Encryption key type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.KeyRecover);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
