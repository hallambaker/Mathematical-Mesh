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
		public static void WebProfile(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/profile.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/profile.md" };
				obj._WebProfile(Examples);
				}
			}
		public void _WebProfile(Examples Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the `profile` Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile` command set contains commands used to create and manage\n{0}", _Indent);
				_Output.Write ("Mesh profiles.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Contacting a Mesh Service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command contacts a Mesh service and returns\n{0}", _Indent, ToCommand("profile hello"));
				_Output.Write ("a description of the service parameters.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileHello);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If a Mesh account is specified, the tool attempts to connect to a Mesh service\n{0}", _Indent);
				_Output.Write ("at the associated domain. It is not necessary for the account to be registered\n{0}", _Indent);
				_Output.Write ("at the service when the request is made.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating a profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To begin using the Mesh, it is necessary for the user to create a Mesh profile.\n{0}", _Indent);
				_Output.Write ("This includes the steps of:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Create a Master profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Create a device profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Create a Mesh profile and make the current device an administrator.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Register the Mesh profile with a Mesh service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command performs all four of these functions.\n{0}", _Indent, ToCommand("profile create"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileMaster);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Synchronizing a profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command is used to synchronize the catalogs and \n{0}", _Indent, ToCommand("profile "));
				_Output.Write ("spools associated with a Mesh profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileSync);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Synchronization is also performed automatically before every command requiring \n{0}", _Indent);
				_Output.Write ("interaction with the Mesh service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Listing profiles installed on a machine\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command lists all the profiles available on the \n{0}", _Indent, ToCommand("profile list"));
				_Output.Write ("machine:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command provides a more detailed description of \n{0}", _Indent, ToCommand("profile dump"));
				_Output.Write ("a profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileDump);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Escrowing Profile Master Keys\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The more reliance that a user puts on a cryptographic infrastructure, the more \n{0}", _Indent);
				_Output.Write ("serious the consequences of the loss of the encryption and authentication keys.\n{0}", _Indent);
				_Output.Write ("As the recent episode of 'ransomware' attacks demonstrates, for most users, the\n{0}", _Indent);
				_Output.Write ("very worst security compromise that could affect them is the loss of the\n{0}", _Indent);
				_Output.Write ("pictures of their children when they were five years old.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command escrows the signature and encryption keys\n{0}", _Indent, ToCommand("profile "));
				_Output.Write ("of the user's master profile and returns a set of recovery shares. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileEscrow);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("By default, three recovery shares are created such that two shares are required to\n{0}", _Indent);
				_Output.Write ("recover the master keys.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Recovery of the master keys is performed by the {1}\n{0}", _Indent, ToCommand("profile recover"));
				_Output.Write ("command.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileRecover);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/verify` flag causes the tool to check that the keys can be correctly recovered\n{0}", _Indent);
				_Output.Write ("without actually installing on the machine.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Changing the Mesh Service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command allows a profile to be registered at a different\n{0}", _Indent, ToCommand("profile "));
				_Output.Write ("Mesh Service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileRegister);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Although the Mesh protocols are designed to allow a Mesh profile to be registered with\n{0}", _Indent);
				_Output.Write ("multiple services, this use is not currently implemented in the Mesh reference code.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Direct profile management\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A Mesh profile may be exported as a file using the {1} command:\n{0}", _Indent, ToCommand("profile "));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileExport);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} profile can then be used to import the file on another \n{0}", _Indent, ToCommand("profile "));
				_Output.Write ("machine:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileImport);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProfileReference
		//
		public static void ProfileReference(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/profile.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/profile.md" };
				obj._ProfileReference(Examples);
				}
			}
		public void _ProfileReference(Examples Examples) {

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
