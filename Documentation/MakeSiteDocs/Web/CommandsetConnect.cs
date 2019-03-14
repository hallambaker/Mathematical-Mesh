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
		// WebConnect
		//
		public static void WebConnect(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/connect.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/connect.md" };
				obj._WebConnect(Examples);
				}
			}
		public void _WebConnect(CreateWeb Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the connect Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `connect` command set contains commands used to connect devices to a \n{0}", _Indent);
				_Output.Write ("profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Requesting a connection\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectPending);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectAccept);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectReject);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Requesting a connection using a PIN\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ConnectPending3);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ConnectReference
		//
		public static void ConnectReference(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/connect.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/connect.md" };
				obj._ConnectReference(Examples);
				}
			}
		public void _ConnectReference(CreateWeb Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Connect;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileConnect._DescribeCommand);
				  ConsoleReference (Examples.ConnectRequest);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfilePending._DescribeCommand);
				  ConsoleReference (Examples.ConnectPending);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileAccept._DescribeCommand);
				  ConsoleReference (Examples.ConnectAccept);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileReject._DescribeCommand);
				  ConsoleReference (Examples.ConnectReject);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileGetPIN._DescribeCommand);
				  ConsoleReference (Examples.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
