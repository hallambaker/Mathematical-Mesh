using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// WebNetwork
		//
		public static void WebNetwork(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/network.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/network.md" };
			obj._WebNetwork(Examples);
			}
		public void _WebNetwork(CreateExamples Examples) {

				 MakeTitle ("network");
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `network` command set is used to manage a network configuration catalog which contains\n{0}", _Indent);
				_Output.Write ("a entries describing how to access particular networks.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding networks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds a network entry to a catalog:\n{0}", _Indent, ToCommand("network add"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.NetworkAdd);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Finding networks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1}  command retreives a network entry by label:\n{0}", _Indent, ToCommand("network get"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.NetworkGet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Deleting networks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Network entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("network delete"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.NetworkDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Listing networks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A complete list of networks is obtained using the  {1} command:\n{0}", _Indent, ToCommand("network list"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.NetworkList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Devices are given authorization to access the networks catalog using the \n{0}", _Indent);
				_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write (" %  ConsoleExample (Examples.NetworkAuth);\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// NetworkReference
		//
		public static void NetworkReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/network.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/network.md" };
			obj._NetworkReference(Examples);
			}
		public void _NetworkReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Network;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _NetworkAdd._DescribeCommand);
				 ConsoleReference (Examples.NetworkAdd);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _NetworkDelete._DescribeCommand);
				 ConsoleReference (Examples.NetworkDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _NetworkGet._DescribeCommand);
				 ConsoleReference (Examples.NetworkGet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _NetworkDump._DescribeCommand);
				 ConsoleReference (Examples.NetworkList);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
