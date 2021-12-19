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
	// WebPassword
	//
	public static void WebPassword(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/password.md");
		Examples._Output = _Output;
		Examples._WebPassword(Examples);
		}
	public void _WebPassword(CreateExamples Examples) {

			 MakeTitle ("password");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `password` command set contains commands for managing a catalog of username \n{0}", _Indent);
			_Output.Write ("and password entries protected by end to end encryption.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding passwords\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds a username/password entry to the\n{0}", _Indent, ToCommand("password add"));
			_Output.Write ("credentials catalog associated with a profile:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice adds the username and password for an ftp service to her catalog:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellPassword.PasswordAdd);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Synchronizing passwords to an application.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command lists all the passwords in the catalog:\n{0}", _Indent, ToCommand("password list"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellPassword.PasswordList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The output of the list command may be used to configure a user application \n{0}", _Indent);
			_Output.Write ("such as a Web browser that supports password management. But care is obviously\n{0}", _Indent);
			_Output.Write ("required as the passwords will only be as secure as the other application.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Finding passwords\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command retreives the username and password \n{0}", _Indent, ToCommand("password get"));
			_Output.Write ("values for a specified service:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellPassword.PasswordGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("### Using Credentials in scripts\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice can use Mesh to provide an *aide memoire* for credentials for access credentials\n{0}", _Indent);
			_Output.Write ("for sites she rarely visits. She can also use it as a tool to allow scripted access to\n{0}", _Indent);
			_Output.Write ("remote services requiring username and password authentication without putting those\n{0}", _Indent);
			_Output.Write ("credentials in the script itself.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The commands for doing this vary according to the scripting environment.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Windows\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("set credential = \"\"\n{0}", _Indent);
			_Output.Write ("for /f \"delims=\" %%a in ('meshman password get {1}')^\n{0}", _Indent, ShellPassword.PasswordSite);
			_Output.Write ("  do @set credential=%%a\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Most Unix shells, including Bash, the following syntax may be used:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("set credential=`meshman password get {1}`\n{0}", _Indent, ShellPassword.PasswordSite);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Updating passwords\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Having automated access to the ftp site, Alice doesn't need her password to be either\n{0}", _Indent);
			_Output.Write ("memorable or conveniently short. She decides to replace her bad password with a strong\n{0}", _Indent);
			_Output.Write ("password that is randomly generated:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellPassword.PasswordUpdate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Deleting passwords\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Password entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("password delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellPassword.PasswordDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding a Device.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("When a device is added, it gets a copy of the password file:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellPassword.PasswordAuth);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// PasswordReference
	//
	public static void PasswordReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/password.md");
		Examples._Output = _Output;
		Examples._PasswordReference(Examples);
		}
	public void _PasswordReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Password;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _PasswordAdd._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'password add' command is used to add credential entries to the catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellPassword.PasswordAdd);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _PasswordDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'password delete' command deletes a credential entry by means of the site identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellPassword.PasswordDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _PasswordGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'password get' command retrieves a credential entry  by means of the site identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellPassword.PasswordGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _PasswordDump._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'password list' command lists all data in the credential catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellPassword.PasswordList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
