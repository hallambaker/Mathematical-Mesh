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
		public static void WebDare(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/dare.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/dare.md" };
				obj._WebDare(Index);
				}
			}
		public void _WebDare(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// DareReference
		//
		public static void DareReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/dare.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/dare.md" };
				obj._DareReference(Index);
				}
			}
		public void _DareReference(CreateWeb Index) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Dare;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe( CommandSet, _FileEncrypt._DescribeCommand);
				 Describe(CommandSet, _FileDecrypt._DescribeCommand);
				 Describe(CommandSet, _FileVerify._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
