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
		// UserGuideApps
		//
		public static void UserGuideApps (CreateExamples Index) { /* File  */
			using (var _Output = new StreamWriter ("Apps/index.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Applications\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Applications User Guide\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Mesh/Confirm Mesh/Credential Mesh/Mail Mesh/Recrypt Mesh/SSH\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This Applications User Guide describes the configuration and use of Mesh \n{0}", _Indent);
				_Output.Write ("with applications:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<ul>\n{0}", _Indent);
				_Output.Write ("<li><a=\"mail.html\">Mesh/Mail</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"ssh.html\">Mesh/SSH</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"catalog.html\">Mesh/Catalog</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"confirm.html\">Mesh/Confirm</a>\n{0}", _Indent);
				_Output.Write ("<li><a=\"recrypt.html\">Mesh/Recrypt</a>\n{0}", _Indent);
				_Output.Write ("</ul>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
