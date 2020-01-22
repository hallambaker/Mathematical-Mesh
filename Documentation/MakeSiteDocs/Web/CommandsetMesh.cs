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
		// WebProfile
		//
		public static void WebProfile(CreateExamples Examples) { /* XFile  */
            using var _Output = new StreamWriter("Guide/profile.md");
            var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/profile.md" };
            obj._WebProfile(Examples);
            }
		public void _WebProfile(CreateExamples Examples) {

				 MakeTitle ("profile");
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
				_Output.Write ("* Create a Mesh Account\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Create a Mesh profile and make the current device an administrator.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Register the Mesh profile with a Mesh service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command creates a profile:\n{0}", _Indent, ToCommand("profile create"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileCreateAlice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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
		public static void ProfileReference(CreateExamples Examples) { /* XFile  */
            using var _Output = new StreamWriter("Reference/profile.md");
            var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/profile.md" };
            obj._ProfileReference(Examples);
            }
		public void _ProfileReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Mesh;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MeshCreate._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile create` command creates a new Mesh master profile and \n{0}", _Indent);
				_Output.Write ("(optionally) registers it with a Mesh service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("By default, the default device profile of the current account is registered as an\n{0}", _Indent);
				_Output.Write ("administrator device of the newly created profile. If no default device exists, a \n{0}", _Indent);
				_Output.Write ("new device profile is created. The `/new` option may be used to force a new device\n{0}", _Indent);
				_Output.Write ("profile to be created.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/did` and `/dd` options specify an identifier and description for the device if\n{0}", _Indent);
				_Output.Write ("a new profile is created. Otherwise, platform defaults are used.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Cryptographic algorithms to be used for the signature and encryption algorithms \n{0}", _Indent);
				_Output.Write ("may be specified using the `/alg` option.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileCreateAlice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MeshEscrow._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile escrow` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileEscrow);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MeshExport._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile export` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileExport);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MeshGet._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile get` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileDump);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MeshImport._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile import` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileImport);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MeshList._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile list` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MeshRecover._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `profile recover` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileRecover);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
