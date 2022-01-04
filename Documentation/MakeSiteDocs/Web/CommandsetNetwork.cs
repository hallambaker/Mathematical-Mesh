using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	

	//
	// WebNetwork
	//
	public static void WebNetwork(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/network.md");
		Examples._Output = _Output;
		Examples._WebNetwork(Examples);
		}
	public void _WebNetwork(CreateExamples Examples) {

			 MakeTitle ("network");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `network` command set is used to manage a network configuration catalog which contains\n{0}", _Indent);
			_Output.Write ("a entries describing how to access particular networks.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding networks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds a simple network entry to a catalog. This is typically\n{0}", _Indent, ToCommand("network add"));
			_Output.Write ("a WIfi network SSID and password:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellNetwork.NetworkAdd);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("More complicated network configurations are added using the {1} command:\n{0}", _Indent, ToCommand("network import"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellNetwork.NetworkImport);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Finding networks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command retreives a network entry by label:\n{0}", _Indent, ToCommand("network get"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellNetwork.NetworkGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Deleting networks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Network entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("network delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellNetwork.NetworkDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Listing networks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A complete list of networks is obtained using the  {1} command:\n{0}", _Indent, ToCommand("network list"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellNetwork.NetworkList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding devices\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellNetwork.NetworkList1);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Devices are given authorization to access the networks catalog using the \n{0}", _Indent);
			_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectJoinAuth );
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellNetwork.NetworkList2);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// NetworkReference
	//
	public static void NetworkReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/network.md");
		Examples._Output = _Output;
		Examples._NetworkReference(Examples);
		}
	public void _NetworkReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Network;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _NetworkAdd._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'network add' command is used to add a network entry to the catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that the options supported are limited. The  {1}\n{0}", _Indent, ToCommand("network import"));
			_Output.Write ("command should be used to add complex network entries.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellNetwork.NetworkAdd);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _NetworkDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'network delete' command deletes a network entry entry by means of \n{0}", _Indent);
			_Output.Write ("its unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellNetwork.NetworkDelete);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _NetworkGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'network get' command retrieves a network entry by means of its \n{0}", _Indent);
			_Output.Write ("unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellNetwork.NetworkGet);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _NetworkImport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'network import' command is used to add a network entry to the catalog\n{0}", _Indent);
			_Output.Write ("from a file\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellNetwork.NetworkImport);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _NetworkList._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'network list' command lists all data in the network catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellNetwork.NetworkList);
			_Output.Write ("\n{0}", _Indent);
				}
		}
