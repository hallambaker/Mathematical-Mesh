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
		// WebAccount
		//
		public static void WebAccount(CreateExamples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/profile.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/profile.md" };
				obj._WebAccount(Examples);
				}
			}
		public void _WebAccount(CreateExamples Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the `profile` Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `account` command set contains commands used to create and manage\n{0}", _Indent);
				_Output.Write ("Mesh accounts.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating a Mesh Account\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Create a new Mesh profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileCreateAlice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Add an account to the profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.CommandsAddAcountAlice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command registers a profile:\n{0}", _Indent, ToCommand("account service"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.CommandsAddServiceAlice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Or we can perform all three tasks at once by creating an account and registering it with a \n{0}", _Indent);
				_Output.Write ("service when we create the profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ProfileCreateBob);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Contacting a Mesh Service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Registering an account with a service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Synchronizing an account with a service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// AccountReference
		//
		public static void AccountReference(CreateExamples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/profile.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/profile.md" };
				obj._AccountReference(Examples);
				}
			}
		public void _AccountReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Account;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _AccountHello._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `account hello` command attempts to contact a Mesh service and reports the\n{0}", _Indent);
				_Output.Write ("service configuration if successful.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ProfileHello);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `account register` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _AccountSync._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `account sync` command \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _AccountGetPIN._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `account pin` command generates and registers a new PIN code that may be used\n{0}", _Indent);
				_Output.Write ("to authenticate a device connection request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/length` option specifies the length of the generated PIN in (significant)\n{0}", _Indent);
				_Output.Write ("characters.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The '/expire' option specifies an expiry time for the request as an integer \n{0}", _Indent);
				_Output.Write ("followed by the letter m, h or d for minutes, hours and days respectively.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleReference (Examples.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
