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
		public static void WebContainer (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/container.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// ContainerReference
		//
		public static void ContainerReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/container.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Container;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _ContainerCreate._DescribeCommand);
				 Describe(_Output, CommandSet, _ContainerArchive._DescribeCommand);
				 Describe(_Output, CommandSet, _ContainerAppend._DescribeCommand);
				 Describe(_Output, CommandSet, _ContainerDelete._DescribeCommand);
				 Describe(_Output, CommandSet, _ContainerIndex._DescribeCommand);
				 Describe(_Output, CommandSet, _ContainerExtract._DescribeCommand);
				 Describe(_Output, CommandSet, _ContainerCopy._DescribeCommand);
				 Describe(_Output, CommandSet, _ContainerVerify._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
