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
		public static void WebGroup(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/group.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/group.md" };
				obj._WebGroup(Index);
				}
			}
		public void _WebGroup(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// GroupReference
		//
		public static void GroupReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/group.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/group.md" };
				obj._GroupReference(Index);
				}
			}
		public void _GroupReference(CreateWeb Index) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Group;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe( CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe( CommandSet, _GroupCreate._DescribeCommand);
				 Describe( CommandSet, _GroupAdd._DescribeCommand);
				 Describe( CommandSet, _GroupDelete._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
