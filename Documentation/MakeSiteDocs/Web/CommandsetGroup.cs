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
		// WebGroup
		//
		public static void WebGroup (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/group.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// GroupReference
		//
		public static void GroupReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/group.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Profile;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _GroupCreate._DescribeCommand);
				 Describe(_Output, CommandSet, _GroupAdd._DescribeCommand);
				 Describe(_Output, CommandSet, _GroupDelete._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
