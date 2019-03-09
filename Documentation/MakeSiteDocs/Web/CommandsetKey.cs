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
				_Output.Write ("````\n{0}", _Indent);
				 CommandLineInterpreter.DescribeCommandSet_Key.Describe('/', _Output);
				_Output.Write ("````\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// KeyReference
		//
		public static void KeyReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/key.md")) {
				var _Indent = ""; 
				_Output.Write ("# Key Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## key nonce\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The nonce command creates a randomized nonce value formatted as a UDF Nonce Type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Nonce values should be used when it is important that a value be unpredictable but \n{0}", _Indent);
				_Output.Write ("does not need to be kept secret. For example, the challenge in a challenge/response\n{0}", _Indent);
				_Output.Write ("protocol.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## key secret\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The secret command creates a randomized secret value formatted as a UDF Encryption \n{0}", _Indent);
				_Output.Write ("Key Type.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## key earl\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## key share\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## key recover\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
