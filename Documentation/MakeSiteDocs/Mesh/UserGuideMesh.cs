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
		// UserGuideMesh
		//
		public static void UserGuideMesh (CreateExamples Index) { /* File  */
			using (var _Output = new StreamWriter ("Mesh/index.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Mesh User Guide\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mesh User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Make computers easier to use by making computers secure\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This guide describes how to:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<ul>\n{0}", _Indent);
				_Output.Write ("<li><a=\"create.html\">Create Mesh Profiles.</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"connecting.html\">Connect Additional devices.</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"disaster.html\">Plan for disaster recovery.</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"server.html\">Set up a private Mesh service.</a>\n{0}", _Indent);
				_Output.Write ("</ul>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
