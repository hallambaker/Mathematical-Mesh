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
		// WebContact
		//
		public static void WebContact (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/contact.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// ContactReference
		//
		public static void ContactReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/contact.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Profile;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ContactAdd._DescribeCommand);
				 Describe(_Output, CommandSet, _ContactDelete._DescribeCommand);
				 Describe(_Output, CommandSet, _ContactdGet._DescribeCommand);
				 Describe(_Output, CommandSet, _ContactDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
