using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// UserGuideWindows
		//
		public static void UserGuideWindows (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Platform/Windows.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Windows\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Windows Platform\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Using the Mesh on Windows\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Installation\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh distribution may be installed using the installer package or by manually\n{0}", _Indent);
				_Output.Write ("copying files from the Zip file\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Platform specific features\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Profile storage\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Key storage\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Further work\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Powershell Cmdlet\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("It would be very useful to be able to access Mesh features through Powershell <tt>Cmdlets</tt>.\n{0}", _Indent);
				_Output.Write ("The best way to do this would be to rework the PHB Command tool to generate Cmdlet classes \n{0}", _Indent);
				_Output.Write ("rather than commandline classes. This is explained in the \n{0}", _Indent);
				_Output.Write ("<a=\"https://msdn.microsoft.com/en-us/library/dd901838(v=vs.85).aspx\">Windows documentation</a>.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
