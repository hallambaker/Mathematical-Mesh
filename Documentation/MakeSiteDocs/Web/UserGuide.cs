using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
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
				_Output.Write ("meshman is a command line tool that provides access to the security tools\n{0}", _Indent);
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
				}
			}
		}
	}
