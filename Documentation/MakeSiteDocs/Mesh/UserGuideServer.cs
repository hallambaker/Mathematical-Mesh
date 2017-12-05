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
		// UserGuideServer
		//
		public static void UserGuideServer (CreateExamples Index) { /* File  */
			using (var _Output = new StreamWriter ("Mesh/server.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Server\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Running a Mesh Server\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Supporting the Mesh Portal and other services.\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh reference software distribution currently contains a single server that supports all of the\n{0}", _Indent);
				_Output.Write ("services built using the Mesh Reference code. These are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>Mesh Portal service\n{0}", _Indent);
				_Output.Write ("<dd>Service supporting profile connection requests and all user interactions with the cryptomesh.\n{0}", _Indent);
				_Output.Write ("<dt>Mesh/Account Service\n{0}", _Indent);
				_Output.Write ("<dd>Is used to track account based data in all the Mesh services (except the portal service currently). \n{0}", _Indent);
				_Output.Write ("Implements the catalog services (Contacts, Calender, Bookmarks, Credentials).\n{0}", _Indent);
				_Output.Write ("<dt>Mesh/Recrypt Service\n{0}", _Indent);
				_Output.Write ("<dd>Provides the key service supporting proxy re-encryption\n{0}", _Indent);
				_Output.Write ("<dt>Mesh/Confirm Service\n{0}", _Indent);
				_Output.Write ("<dd>Supports the two factor authentication service.\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Starting the Combined server\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The server is started from the command line. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Server state is maintained in a set of append only log files. These are currently in JSON Log file format \n{0}", _Indent);
				_Output.Write ("but will eventually transition to use of the JSON Container Format.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
