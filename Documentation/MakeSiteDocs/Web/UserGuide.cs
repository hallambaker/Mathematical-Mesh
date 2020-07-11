using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Mesh.Test;
using  Goedel.Protocol;
using  Goedel.Command;
using  Goedel.Test.Core ;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// WebDocs
		//
		public void WebDocs (CreateExamples Index) {
			 Web (Index);
			 UserGuide (Index);
			 Reference (Index);
			 WebKey (Index);
			 KeyReference (Index);
			 WebHash (Index);
			 HashReference (Index);
			 WebDare (Index);
			 DareReference (Index);
			 WebContainer (Index);
			 ContainerReference (Index);
			 WebProfile (Index);
			 ProfileReference (Index);
			 WebConnect (Index);
			 ConnectReference (Index);
			
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
			 WebGroup (Index);
			 GroupReference (Index);
			 WebContact (Index);
			 ContactReference (Index);
			 WebCalendar (Index);
			 CalendarReference (Index);
			}
		

		//
		// Web
		//
		public static void Web(CreateExamples Index) { /* XFile  */
			using var _Output = new StreamWriter("readme.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "readme.md" };
			obj._Web(Index);
			}
		public void _Web(CreateExamples Index) {

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
		public static void Features(CreateExamples Index) { /* XFile  */
			using var _Output = new StreamWriter("festures.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "festures.md" };
			obj._Features(Index);
			}
		public void _Features(CreateExamples Index) {

				_Output.Write ("# Feature Requests\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following features are planned but not yet implemented:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>General</dt>\n{0}", _Indent);
				_Output.Write ("<dd>toplevel 'pending' command to return all pending messages, contacts and connection</dd>\n{0}", _Indent);
				_Output.Write ("<dt>Hash command set</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Allow processing of multiple files at once.</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Support SHA3 MACs, SHA256, etc digests.</dd>\n{0}", _Indent);
				_Output.Write ("<dt>Dare command set</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Implement EARL mechanism</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Write out transaction completion to log</dd>\n{0}", _Indent);
				_Output.Write ("<dt>Container command set</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Summarize container</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Mark container as spool, catalog, log, archive</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Erase message from container by overwritting salt, data</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Index functionality.\n{0}", _Indent);
				_Output.Write ("<dd>Log file handling - find log entry, report last n entries, etc.</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Exctact messages, not just files</dd>\n{0}", _Indent);
				_Output.Write ("<dt>Messaging</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Support wildcard contacts. </dd>\n{0}", _Indent);
				_Output.Write ("<dd>Option to not accept reciprocal contact requests.</dd>\n{0}", _Indent);
				_Output.Write ("<dd>Blocklists for message requests.</dd>\n{0}", _Indent);
				_Output.Write ("<dt>SSH</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Support encryption of private key export</dd>\n{0}", _Indent);
				_Output.Write ("<dd>sSupport for the device authorization command</dd>\n{0}", _Indent);
				_Output.Write ("<dt>Device Groups</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Allow groups of devices to be specified for management purposes</dd>\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Futures:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Mail messaging\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Instant messaging\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Cloud file sharing/storage\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Synchronous\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Chat\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Voice\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Video\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// UserGuide
		//
		public static void UserGuide(CreateExamples Index) { /* XFile  */
			using var _Output = new StreamWriter("Guide/readme.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/readme.md" };
			obj._UserGuide(Index);
			}
		public void _UserGuide(CreateExamples Index) {

				_Output.Write ("# meshman User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				foreach  (var entry in CommandLineInterpreter.Entries) {
					if (  (entry.Value is DescribeCommandSet) ) {
						_Output.Write ("<dt><a href=\"{1}.md\">{2}</a>\n{0}", _Indent, entry.Key, entry.Key);
						_Output.Write ("<dd>{1}\n{0}", _Indent, entry.Value.Brief);
						}
					}
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// Reference
		//
		public static void Reference(CreateExamples Index) { /* XFile  */
			using var _Output = new StreamWriter("Reference/readme.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/readme.md" };
			obj._Reference(Index);
			}
		public void _Reference(CreateExamples Index) {

				_Output.Write ("# meshman Reference Manual\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				foreach  (var entry in CommandLineInterpreter.Entries) {
					if (  (entry.Value is DescribeCommandSet) ) {
						_Output.Write ("<dt><a href=\"{1}.md\">{2}</a>\n{0}", _Indent, entry.Key, entry.Key);
						_Output.Write ("<dd>{1}\n{0}", _Indent, entry.Value.Brief);
						}
					}
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
		// DescribeMessage
		//
		public void DescribeMessage (ExampleResult Result) {
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"helptext\">\n{0}", _Indent);
			_Output.Write ("<over>\n{0}", _Indent);
			_Output.Write ("[NYI]\n{0}", _Indent);
			_Output.Write ("<over>\n{0}", _Indent);
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			}
		

		//
		// Describe
		//
		public void Describe (DescribeCommandSet CommandSet) {
			_Output.Write ("# {1}\n{0}", _Indent, CommandSet.Identifier);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"helptext\">\n{0}", _Indent);
			_Output.Write ("<over>\n{0}", _Indent);
			 CommandSet.Describe('/', _Output, false);
			_Output.Write ("<over>\n{0}", _Indent);
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			}
		

		//
		// Describe
		//
		public void Describe (DescribeCommandSet CommandSet, DescribeCommand Command) {
			_Output.Write ("# {1} {2}\n{0}", _Indent, CommandSet.Identifier, Command.Identifier);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"helptext\">\n{0}", _Indent);
			_Output.Write ("<over>\n{0}", _Indent);
			 Command.Describe('/', _Output, false);
			_Output.Write ("<over>\n{0}", _Indent);
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			}
		

		//
		// Format
		//
		public void Format (JsonObject data) {
			_Output.Write ("{1}\n{0}", _Indent, Preformat);
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (data));
			_Output.Write ("{1}\n{0}", _Indent, Preformat);
			}
		

		//
		//  "Check example"
		//

			 public bool ExampleInvalid(List<ExampleResult> examples, int item=0, int trace=0) {
			 if (examples == null) {return true;}
			 if (item >= examples.Count-1 ) {return true;}
			 if (trace >= examples[item].Traces.Count-1 ) {return true;}
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("[Example missing]\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 return false;
			 }
		
		

		//
		// DescribeRequestBinding
		//
		public void DescribeRequestBinding (Trace trace) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, trace.GetRequest());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// DescribeResponseBinding
		//
		public void DescribeResponseBinding (Trace trace) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, trace.GetResponse());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// DescribeRequestBinding
		//
		public void DescribeRequestBinding (List<ExampleResult> exampleResults) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// DescribeResponseBinding
		//
		public void DescribeResponseBinding (List<ExampleResult> exampleResults) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// DescribeRequest
		//
		public void DescribeRequest (List<ExampleResult> exampleResults) {
			}
		

		//
		// DescribeResponse
		//
		public void DescribeResponse (List<ExampleResult> exampleResults) {
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
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"terminal\">\n{0}", _Indent);
			foreach  (var exampleResult in exampleResults) {
				_Output.Write ("<cmd>{1}> {2}\n{0}", _Indent, exampleResult.MachineName, exampleResult.Command);
				_Output.Write ("<rsp>{1}", _Indent, exampleResult.ResultText);
				}
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
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
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"terminal\">\n{0}", _Indent);
			_Output.Write ("<cmd>{1}> {2} /json\n{0}", _Indent, exampleResult.MachineName, exampleResult.Command);
			_Output.Write ("<rsp>{1}\n{0}", _Indent, exampleResult.ResultJSON);
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
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
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"terminal\">\n{0}", _Indent);
			_Output.Write ("<cmd>{1}> {2}\n{0}", _Indent, exampleResult.MachineName, exampleResult.Command);
			_Output.Write ("<rsp>{1}", _Indent, exampleResult.ResultText);
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Specifying the /json option returns a result of type {1}:\n{0}", _Indent, exampleResult.ResultType);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"terminal\">\n{0}", _Indent);
			_Output.Write ("<cmd>{1}> {2} /json\n{0}", _Indent, exampleResult.MachineName, exampleResult.Command);
			_Output.Write ("<rsp>{1}\n{0}", _Indent, exampleResult.ResultJSON);
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// MakeTitle
		//
		public void MakeTitle (string title) {
			_Output.Write ("<title>{1}\n{0}", _Indent, title);
			_Output.Write ("# Using the {1} Command Set\n{0}", _Indent, title);
			}
		

		//
		// 
		//

			 public string ToCommand (string command) => "`" + command + "`";
			 public string ToCommand (string group, string command) => "`" + group + " " + command + "`";
		
		}
	}
