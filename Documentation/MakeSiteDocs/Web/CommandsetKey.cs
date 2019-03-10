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
		// WebKey
		//
		public static void WebKey (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/key.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the Key Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Key command set contains commands that operate on cryptographic keys and\n{0}", _Indent);
				_Output.Write ("nonces.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Keys and nonces may be generated with any desired precision \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// KeyReference
		//
		public static void KeyReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/key.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Key;
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _KeyNonce._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `nonce` command returns a randomized nonce value formatted as a UDF nonce type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Nonce values should be used when it is important that a value be unpredictable but \n{0}", _Indent);
				_Output.Write ("does not need to be kept secret. For example, the challenge in a challenge/response\n{0}", _Indent);
				_Output.Write ("protocol.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _KeySecret._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `secret` command returns a randomized secret value formatted as a UDF Encryption \n{0}", _Indent);
				_Output.Write ("key type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _KeyEarl._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `earl` command returns a randomized secret value and a fingerprint of the secret \n{0}", _Indent);
				_Output.Write ("value, formatted as a UDF Encryption key type and Content Digest Type\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _KeyShare._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `share` command returns a randomized secret value and a set of shares for the secret\n{0}", _Indent);
				_Output.Write ("formatted as a UDF Encryption key type and Share types\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _KeyRecover._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `recover` command combines the specified set of share to recover the original secret \n{0}", _Indent);
				_Output.Write ("value as a UDF Encryption key type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
