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
		public static void WebDare (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/dare.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// DareReference
		//
		public static void DareReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/dare.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Dare;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _FileEncrypt._DescribeCommand);
				 Describe(_Output, CommandSet, _FileDecrypt._DescribeCommand);
				 Describe(_Output, CommandSet, _FileVerify._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
