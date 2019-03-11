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
		// WebNetwork
		//
		public static void WebNetwork(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/network.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/network.md" };
				obj._WebNetwork(Index);
				}
			}
		public void _WebNetwork(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// NetworkReference
		//
		public static void NetworkReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/network.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/network.md" };
				obj._NetworkReference(Index);
				}
			}
		public void _NetworkReference(CreateWeb Index) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Network;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _NetworkAdd._DescribeCommand);
				 Describe(CommandSet, _NetworkGet._DescribeCommand);
				 Describe(CommandSet, _NetworkDelete._DescribeCommand);
				 Describe(CommandSet, _NetworkDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
