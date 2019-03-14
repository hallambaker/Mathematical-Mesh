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
		// WebPassword
		//
		public static void WebPassword(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/password.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/password.md" };
				obj._WebPassword(Examples);
				}
			}
		public void _WebPassword(CreateWeb Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding passwords\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having created her application service account, Alice can add a credential. In this\n{0}", _Indent);
				_Output.Write ("case it is the username and password for an ftp service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.PasswordAdd);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Finding passwords\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having added the password to her profile, Alice can retrieve it when needed.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.PasswordGet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("She can also list all the passwords in her catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.PasswordList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Using the password catalog in this fashion provides a reminder. But what Alice really\n{0}", _Indent);
				_Output.Write ("wants to be able to do is to automate the process of using the ftp client to upload \n{0}", _Indent);
				_Output.Write ("files without having to enter her password each time or (worse) include the password\n{0}", _Indent);
				_Output.Write ("in the script:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Updating passwords\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having automated access to the ftp site, Alice doesn't need her password to be either\n{0}", _Indent);
				_Output.Write ("memorable or conveniently short. She decides to replace her bad password with a strong\n{0}", _Indent);
				_Output.Write ("password that is randomly generated:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.PasswordUpdate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Deleting passwords\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Password entries may be deleted using the \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.PasswordDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding a Device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When a device is added, all the passwords are copied\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.AppConnectPassword);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// PasswordReference
		//
		public static void PasswordReference(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/password.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/password.md" };
				obj._PasswordReference(Examples);
				}
			}
		public void _PasswordReference(CreateWeb Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Password;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _PasswordAdd._DescribeCommand);
				 Describe(CommandSet, _PasswordGet._DescribeCommand);
				 Describe(CommandSet, _PasswordDelete._DescribeCommand);
				 Describe(CommandSet, _PasswordDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
