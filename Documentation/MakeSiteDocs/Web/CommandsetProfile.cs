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
		// WebProfile
		//
		public static void WebProfile(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/profile.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/profile.md" };
				obj._WebProfile(Examples);
				}
			}
		public void _WebProfile(CreateWeb Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating a profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileMaster);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileDevice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Listing profiles installed on a machine\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileDump);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Escrowing Profile Master Keys\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileEscrow);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileRecover);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Exporting and Importing Profiles\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileExport);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileImport);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Using a Mesh Service Directly\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileHello);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileRegister);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to :\n{0}", _Indent, ToCommand("connect "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileSync);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProfileReference
		//
		public static void ProfileReference(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/profile.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/profile.md" };
				obj._ProfileReference(Examples);
				}
			}
		public void _ProfileReference(CreateWeb Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Profile;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MasterCreate._DescribeCommand);
				  ConsoleReference (Examples.ProfileMaster);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _DeviceCreate._DescribeCommand);
				  ConsoleReference (Examples.ProfileDevice);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileHello._DescribeCommand);
				  ConsoleReference (Examples.ProfileHello);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileRegister._DescribeCommand);
				  ConsoleReference (Examples.ProfileRegister);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileSync._DescribeCommand);
				  ConsoleReference (Examples.ProfileSync);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileList._DescribeCommand);
				  ConsoleReference (Examples.ProfileList);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileDump._DescribeCommand);
				  ConsoleReference (Examples.ProfileDump);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileEscrow._DescribeCommand);
				  ConsoleReference (Examples.ProfileEscrow);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileRecover._DescribeCommand);
				  ConsoleReference (Examples.ProfileRecover);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileExport._DescribeCommand);
				  ConsoleReference (Examples.ProfileExport);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ProfileImport._DescribeCommand);
				  ConsoleReference (Examples.ProfileImport);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
