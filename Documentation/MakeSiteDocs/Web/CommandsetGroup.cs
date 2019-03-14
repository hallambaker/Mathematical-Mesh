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
		public static void WebGroup(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/group.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/group.md" };
				obj._WebGroup(Examples);
				}
			}
		public void _WebGroup(CreateWeb Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating a Recryption Group\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupCreate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("can encrypt a message\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice can decrypt because she is the admin\n{0}", _Indent);
				_Output.Write (" {1} \n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupDecryptAlice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob cannot:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupDecryptBob1);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding users\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupAdd);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob can:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupDecryptBob2);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Reporting users\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupList1);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Deleting users\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob can:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupDecryptBob3);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.GroupList2);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// GroupReference
		//
		public static void GroupReference(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/group.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/group.md" };
				obj._GroupReference(Examples);
				}
			}
		public void _GroupReference(CreateWeb Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Group;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe( CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe( CommandSet, _GroupCreate._DescribeCommand);
				 Describe( CommandSet, _GroupAdd._DescribeCommand);
				 Describe( CommandSet, _GroupDelete._DescribeCommand);
				 Describe( CommandSet, _GroupList._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
