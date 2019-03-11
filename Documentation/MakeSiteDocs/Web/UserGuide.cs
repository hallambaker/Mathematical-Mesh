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
		public static void Web(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("readme.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "readme.md" };
				obj._Web(Index);
				}
			}
		public void _Web(CreateWeb Index) {

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
		

		//
		// Features
		//
		public static void Features(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("festures.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "festures.md" };
				obj._Features(Index);
				}
			}
		public void _Features(CreateWeb Index) {

				_Output.Write ("# Feature Requests\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following features are planned but not yet implemented:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>Hash command set</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Allow processing of multiple files at once.</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Support SHA3 MACs, SHA256, etc digests.</dd>\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// UserGuide
		//
		public static void UserGuide(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/readme.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/readme.md" };
				obj._UserGuide(Index);
				}
			}
		public void _UserGuide(CreateWeb Index) {

				_Output.Write ("# meshman User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>[`key`](key.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Generate secrets and nonces. Split a secret into shares and recover secret from shares</dd>\n{0}", _Indent);
				_Output.Write ("<dt>[`hash`](hash.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Perform Content Digest and Message Authentication Code operations on the contents of a file</dd>\n{0}", _Indent);
				_Output.Write ("<dt>[`dare`](dare.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Encode and decode DARE messages</dd>\n{0}", _Indent);
				_Output.Write ("<dt>[`container`](container.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Encode and decode DARE containers</dd>\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// Reference
		//
		public static void Reference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/readme.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/readme.md" };
				obj._Reference(Index);
				}
			}
		public void _Reference(CreateWeb Index) {

				_Output.Write ("# meshman Reference Manual\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>[`key`](key.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Generate secrets and nonces. Split a secret into shares and recover secret from shares</dd>\n{0}", _Indent);
				_Output.Write ("<dt>[`hash`](hash.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Perform Content Digest and Message Authentication Code operations on the contents of a file</dd>\n{0}", _Indent);
				_Output.Write ("<dt>[`dare`](dare.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Encode and decode DARE messages</dd>\n{0}", _Indent);
				_Output.Write ("<dt>[`container`](container.md)</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Encode and decode DARE containers</dd>\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
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
				_Output.Write ("All commands (other than `help` and `about`) support the use of the 'verbose', \n{0}", _Indent);
				_Output.Write ("'report' and 'json' options.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*'/json' \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The '/json' flag takes precedence over the /verbose and /report options which\n{0}", _Indent);
				_Output.Write ("are ignored if '/json' is specified.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Specifying the /json flag causes the command output to be presented in JSON\n{0}", _Indent);
				_Output.Write ("format.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*'/verbose' \n{0}", _Indent);
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
		

		//
		// Describe
		//
		public void Describe (DescribeCommandSet CommandSet) {
			_Output.Write ("# {1}\n{0}", _Indent, CommandSet.Identifier);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			 CommandSet.Describe('/', _Output, false);
			_Output.Write ("````\n{0}", _Indent);
			}
		

		//
		// Describe
		//
		public void Describe (DescribeCommandSet CommandSet, DescribeCommand Command) {
			_Output.Write ("# {1} {2}\n{0}", _Indent, CommandSet.Identifier, Command.Identifier);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			 Command.Describe('/', _Output, false);
			_Output.Write ("````\n{0}", _Indent);
			}
		

		//
		// ConsoleExample
		//
		public void ConsoleExample (List<ExampleResult> exampleResults) {
			if (  (exampleResults == null)  ) {
				_Output.Write ("**Missing Example***\n{0}", _Indent);
				 Console.WriteLine ($"Missing example!"); return;
				}
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			foreach  (var exampleResult in exampleResults) {
				_Output.Write (">{1}\n{0}", _Indent, exampleResult.Command);
				_Output.Write ("{1}\n{0}", _Indent, exampleResult.ResultText);
				}
			_Output.Write ("````\n{0}", _Indent);
			}
		

		//
		// ConsoleJSON
		//
		public void ConsoleJSON (List<ExampleResult> exampleResults) {
			if (  (exampleResults == null)  ) {
				_Output.Write ("**Missing Example***\n{0}", _Indent);
				 Console.WriteLine ($"Missing example!"); return;
				}
			 var exampleResult = exampleResults[0];
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write (">{1} /json\n{0}", _Indent, exampleResult.Command);
			_Output.Write ("{1}\n{0}", _Indent, exampleResult.ResultJSON);
			_Output.Write ("````\n{0}", _Indent);
			}
		

		//
		// ConsoleReference
		//
		public void ConsoleReference (List<ExampleResult> exampleResults) {
			if (  (exampleResults == null)  ) {
				_Output.Write ("**Missing Example***\n{0}", _Indent);
				 Console.WriteLine ($"Missing example!"); return;
				}
			 var exampleResult = exampleResults[0];
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write (">{1}\n{0}", _Indent, exampleResult.Command);
			_Output.Write ("{1}", _Indent, exampleResult.ResultText);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Specifying the /json option returns a result of type {1}:\n{0}", _Indent, exampleResult.ResultType);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("````\n{0}", _Indent);
			_Output.Write (">{1} /json\n{0}", _Indent, exampleResult.Command);
			_Output.Write ("{1}\n{0}", _Indent, exampleResult.ResultJSON);
			_Output.Write ("````\n{0}", _Indent);
			}
		

		//
		// 
		//

			 public string ToCommand (string command) => "`" + command + "`";
			 public string ToCommand (string group, string command) => "`" + group + " " + command + "`";
		
		}
	}
