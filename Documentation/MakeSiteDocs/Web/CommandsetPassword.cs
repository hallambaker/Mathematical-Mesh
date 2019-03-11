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
		// WebPassword
		//
		public static void WebPassword(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/password.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/password.md" };
				obj._WebPassword(Index);
				}
			}
		public void _WebPassword(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// PasswordReference
		//
		public static void PasswordReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/password.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/password.md" };
				obj._PasswordReference(Index);
				}
			}
		public void _PasswordReference(CreateWeb Index) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Password;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _PasswordAdd._DescribeCommand);
				 Describe(CommandSet, _PasswordGet._DescribeCommand);
				 Describe(CommandSet, _PasswordDelete._DescribeCommand);
				 Describe(CommandSet, _PasswordDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
