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
		// WebContainer
		//
		public static void WebContainer(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/container.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/container.md" };
				obj._WebContainer(Index);
				}
			}
		public void _WebContainer(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ContainerReference
		//
		public static void ContainerReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/container.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/container.md" };
				obj._ContainerReference(Index);
				}
			}
		public void _ContainerReference(CreateWeb Index) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Container;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerCreate._DescribeCommand);
				 Describe(CommandSet, _ContainerArchive._DescribeCommand);
				 Describe(CommandSet, _ContainerAppend._DescribeCommand);
				 Describe(CommandSet, _ContainerDelete._DescribeCommand);
				 Describe(CommandSet, _ContainerIndex._DescribeCommand);
				 Describe(CommandSet, _ContainerExtract._DescribeCommand);
				 Describe(CommandSet, _ContainerCopy._DescribeCommand);
				 Describe(CommandSet, _ContainerVerify._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
