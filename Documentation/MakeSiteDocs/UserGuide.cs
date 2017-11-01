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
		// UserGuide
		//
		public static void UserGuide (CreateExamples Index) { /* File  */
			using (var _Output = new StreamWriter ("index.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>User Guide\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mathemetical Mesh User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Make computers easier to use by making computers secure\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh <li><a=\"Mesh/quickstart.html\">Quickstart guide</a> provides a brief introduction\n{0}", _Indent);
				_Output.Write ("to getting started with the Mesh.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The comprehensive user guide is divided into two parts, the Mesh User Guide describing\n{0}", _Indent);
				_Output.Write ("operations on the Mesh itself and the Applications User Guide describing the use of\n{0}", _Indent);
				_Output.Write ("Mesh enabled applications.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Mesh User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh User Guide describes the use of the Mesh itself, how to:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<ul>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Mesh/create.html\">Create Mesh Profiles.</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Mesh/connecting.html\">Connect Additional devices.</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Mesh/disaster.html\">Plan for disaster recovery.</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Mesh/server.html\">Set up a private Mesh service.</a>\n{0}", _Indent);
				_Output.Write ("</ul>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Applications User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Applications User Guide describes the configuration and use of Mesh \n{0}", _Indent);
				_Output.Write ("enabled applications.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<ul>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Apps/confirm.html\">Mesh/Confirm</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Apps/mail.html\">Mesh/Mail</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Apps/catalog.html\">Mesh/Catalog</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Apps/recrypt.html\">Mesh/Recrypt</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"Apps/ssh.html\">Mesh/SSH</a>\n{0}", _Indent);
				_Output.Write ("</ul>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
