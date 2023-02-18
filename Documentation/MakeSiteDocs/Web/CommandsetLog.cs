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
	// WebLog
	//
	public static void WebLog(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/log.md");
		Examples._Output = _Output;
		Examples._WebLog(Examples);
		}
	public void _WebLog(CreateExamples Examples) {

			 MakeTitle ("log");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("**Under development**: This command set is currently under development and many\n{0}", _Indent);
			_Output.Write ("features are documented but not yet implemented. Use with care!\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `log` command set contains commands that create, read and write text data to DARE \n{0}", _Indent);
			_Output.Write ("log sequences..\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating a DARE log\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Appending a log item\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Listing data from a log\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// LogReference
	//
	public static void LogReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/log.md");
		Examples._Output = _Output;
		Examples._LogReference(Examples);
		}
	public void _LogReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Log;
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("**Under development**: This command set is currently under development and many\n{0}", _Indent);
			_Output.Write ("features are documented but not yet implemented. Use with care!\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `log` command set contains commands that create, read and write text data to DARE \n{0}", _Indent);
			_Output.Write ("log sequences..\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ log append
			 Describe(CommandSet, _LogAppend._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `log append` command appends a text entry to the specified DARE sequence.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ log create
			 Describe(CommandSet, _LogCreate._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ log list
			 Describe(CommandSet, _LogList._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `log list` command returns a list of items in the specified sequence..\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
