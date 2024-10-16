using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
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
	// WebHash
	//
	public static void WebHash(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/hash.md");
		Examples._Output = _Output;
		Examples._WebHash(Examples);
		}
	public void _WebHash(CreateExamples Examples) {

			 MakeTitle ("hash");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `hash` command set contains commands that perform Content Digest and \n{0}", _Indent);
			_Output.Write ("Message Authentication Code operations on the contents of a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Calculating Content Digests\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command calculates the UDF value of a file:\n{0}", _Indent, ToCommand("hash udf"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.HashUDF2);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("In this case, the file `{1}` contains the text `\"{2}\"`.\n{0}", _Indent, TestFile1, TestText1);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("By default, a SHA-2-512 digest is created and the IANA Media Type parameter is\n{0}", _Indent);
			_Output.Write ("determined from the file extension of the file being processed. These defaults\n{0}", _Indent);
			_Output.Write ("may be overriden using the `/cty` and `/alg` options:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.HashUDF3);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("By default, UDF values are given to 140 bit precision. Higher precision may be\n{0}", _Indent);
			_Output.Write ("specified with the `/bits' option:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.HashUDF200);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If the expected digest value is specified, this is used to check the calculated value:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.HashUDFExpect);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command calculates the SHA-2-512 digest and\n{0}", _Indent, ToCommand("hash digest"));
			_Output.Write ("returns it in hexadecimal form:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.HashDigest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Additional digest algorithms may be specified using the `/alg` option:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.HashDigests);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Calculating UDF Message Authentication Codes\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command calculates a Message Authentication Code (MAC)\n{0}", _Indent, ToCommand("hash mac"));
			_Output.Write ("over the file contents and presents it in UDF format:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A MAC may be used to create a keyed commitment value that can be used to provide\n{0}", _Indent);
			_Output.Write ("proof that a document existed at a particular time without revealing information \n{0}", _Indent);
			_Output.Write ("that might allow disclosure of a short or otherwise predictable document by a \n{0}", _Indent);
			_Output.Write ("brute force attack.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If no key is specified, a random secret is generated:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.MAC1);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A key may be specified using the `/key` option:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.MAC2);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If the expected digest value is specified, this is used to check the calculated value:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellHash.MAC3);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// HashReference
	//
	public static void HashReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/hash.md");
		Examples._Output = _Output;
		Examples._HashReference(Examples);
		}
	public void _HashReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Hash;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe( CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `hash` command set contains commands that perform Content Digest and \n{0}", _Indent);
			_Output.Write ("Message Authentication Code operations on the contents of a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe( CommandSet, _HashDigest._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `hash digest` command returns the Content digest of the specified input \n{0}", _Indent);
			_Output.Write ("file according to the digest algorithm specifiedwith the `/alg` option.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellHash.HashDigest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `/alg` option allows the digest algorithm to be specified.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe( CommandSet, _HashMac._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `hash mac` command returns the UDF Message Authentication Code of the specified \n{0}", _Indent);
			_Output.Write ("input file according to the precision, IANA media type and digest algorithm specified\n{0}", _Indent);
			_Output.Write ("with the `/bits`, `/cty` and `/alg` options.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If a no key is specified, a new key is randomly generated, otherwise the specified \n{0}", _Indent);
			_Output.Write ("key is used. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If a MAC value is specified, it is compared to the calculated value and the value\n{0}", _Indent);
			_Output.Write ("true returned if and only if it matches the value specified.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first value returned is the MAC value. The second value returned is the nonce\n{0}", _Indent);
			_Output.Write ("used as a key.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellHash.MAC1);
			_Output.Write ("\n{0}", _Indent);
			 Describe( CommandSet, _HashUDF._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `hash udf` command returns the UDF Content digest of the specified input \n{0}", _Indent);
			_Output.Write ("file according to the precision, IANA media type and digest algorithm specified\n{0}", _Indent);
			_Output.Write ("with the `/bits`, `/cty` and `/alg` options.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellHash.HashUDF2);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
