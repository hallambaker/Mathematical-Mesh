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
		// UserGuideDocker
		//
		public static void UserGuideDocker (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Platform/Docker.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Docker\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Docker Platform\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Running Mesh Servers under Docker.\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A dockerized version of the server code would asssit with the move to production\n{0}", _Indent);
				_Output.Write ("and is therefore planned.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Installation\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("TBS\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Platform specific features\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("There are no platform specific features, the code is the same as for Linux.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
