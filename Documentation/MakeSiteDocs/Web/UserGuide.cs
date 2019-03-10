using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Mesh.Test;
using  Goedel.Protocol;
using  Goedel.Command;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace MakeSiteDocs {
	public partial class MakeSiteDocs : global::Goedel.Registry.Script {

		

		//
		// WebDocs
		//
		public void WebDocs (CreateWeb Index) {
			 Web (Index);
			 UserGuide (Index);
			 Reference (Index);
			 WebKey (Index);
			 KeyReference (Index);
			 WebProfile (Index);
			 ProfileReference (Index);
			 WebSSH (Index);
			 SSHReference (Index);
			 WebBookmark (Index);
			 BookmarkReference (Index);
			 WebPassword (Index);
			 PasswordReference (Index);
			 WebNetwork (Index);
			 NetworkReference (Index);
			 WebMessage (Index);
			 MessageReference (Index);
			 WebMail (Index);
			 MailReference (Index);
			 WebHash (Index);
			 HashReference (Index);
			 WebGroup (Index);
			 GroupReference (Index);
			 WebDare (Index);
			 DareReference (Index);
			 WebContainer (Index);
			 ContainerReference (Index);
			 WebContact (Index);
			 ContactReference (Index);
			 WebCalendar (Index);
			 CalendarReference (Index);
			}
		

		//
		// Web
		//
		public static void Web (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("readme.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# meshman Documentation\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("'meshman' is a command line tool that provides access to the security tools\n{0}", _Indent);
				_Output.Write ("provided by the Mathematical Mesh. Providing these capabilities in a command\n{0}", _Indent);
				_Output.Write ("line tool makes it easy to access Mesh capabilities from scripting languages,\n{0}", _Indent);
				_Output.Write ("thus enabling scripts to be written to manage existing applications using\n{0}", _Indent);
				_Output.Write ("the Mesh.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The documentation is split into two parts:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The [User Guide](Guide) describes how to use the Mesh to perform specific tasks.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The [Reference Manual](Reference) provides a detailed description of the use of\n{0}", _Indent);
				_Output.Write ("specific commands.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UserGuide
		//
		public static void UserGuide (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/readme.md")) {
				var _Indent = ""; 
				_Output.Write ("# meshman User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[*Key*](key.md)\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Commands for creating keys, nonces and EARLs and secret sharing and recovery.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// Reference
		//
		public static void Reference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/readme.md")) {
				var _Indent = ""; 
				_Output.Write ("# meshman Reference Manual\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*about* \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*help*\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[*Key*](key.md)\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Commands for creating keys, nonces and EARLs and secret sharing and recovery.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Command format\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The command processor supports use of either UNIX or Windows syntax regardless\n{0}", _Indent);
				_Output.Write ("of the platform on which it is run. This allows scripts written on Unix to be\n{0}", _Indent);
				_Output.Write ("used on Windows and vice versa while allowing users to use the syntax they are \n{0}", _Indent);
				_Output.Write ("accustomed to use on a particular machine.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Common options\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("All commands support the use of the 'verbose', 'report' and 'json' options.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*'/json' '/nojson'* \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The '/json' flag takes precedence over the /verbose and /report options which\n{0}", _Indent);
				_Output.Write ("are ignored if '/json' is specified.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Specifying the /json flag causes the command output to be presented in JSON\n{0}", _Indent);
				_Output.Write ("format.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*'/verbose' '/noverbose'* \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The '/verbose' flag takes precedence over the /report option which is ignored if\n{0}", _Indent);
				_Output.Write ("'/verbose' is specified.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*'/report' '/noreport'* \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The /report flag is set by default. If /noreport is specified, the command is\n{0}", _Indent);
				_Output.Write ("executed without any output being made to the console.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// 
		//

			 public static void Describe (StreamWriter _Output, DescribeCommandSet CommandSet) {
			 var _Indent = "";
			_Output.Write ("# {1}\n{0}", _Indent, CommandSet.Identifier);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			 CommandSet.Describe('/', _Output, false);
			_Output.Write ("````\n{0}", _Indent);
			 }
			 public static void Describe (StreamWriter _Output, DescribeCommandSet CommandSet, DescribeCommand Command) {
			 var _Indent = "";
			_Output.Write ("# {1} {2}\n{0}", _Indent, CommandSet.Identifier, Command.Identifier);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			 Command.Describe('/', _Output, false);
			_Output.Write ("````\n{0}", _Indent);
			 }
			 public static void ConsoleExample (StreamWriter _Output, ExampleResult exampleResult) {
			 var _Indent = "";
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write (">{1}\n{0}", _Indent, exampleResult.Command);
			_Output.Write ("{1}\n{0}", _Indent, exampleResult.ResultText);
			_Output.Write ("````\n{0}", _Indent);
			 }
			 public static void ConsoleReference (StreamWriter _Output, ExampleResult exampleResult) {
			 var _Indent = "";
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write (">{1}\n{0}", _Indent, exampleResult.Command);
			_Output.Write ("{1}\n{0}", _Indent, exampleResult.ResultText);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Specifying the /json option returns a result of type {1}:\n{0}", _Indent, exampleResult.ResultType);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write (">{1} /json\n{0}", _Indent, exampleResult.Command);
			_Output.Write ("{1}\n{0}", _Indent, exampleResult.ResultJSON);
			_Output.Write ("````\n{0}", _Indent);
			 }
		
		}
	}
