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
		// UserGuideOSX
		//
		public static void UserGuideOSX (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Platform/OSX.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>OSX\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mac OSX Platform\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Using the Mesh on Mac.\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This guide describes features of the Mesh that are specific to the Mac OSX platform.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that this guide does not cover the use of Mesh on iOS. Since there is at present\n{0}", _Indent);
				_Output.Write ("no GUI interface for the Mesh supported on any platform, the only use that can be made\n{0}", _Indent);
				_Output.Write ("of the Mesh on iOS is through direct support by a Mesh enabnled iOS application.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Installation\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Currently only a tar file is provided.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Platform specific features\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Curently there are none and the OSX version is identical to ther Linux version.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Profile storage\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("See the linux version.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Key storage\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("See the linux version\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Further work\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The main OSX development priority is to make use of the key chain for storage of \n{0}", _Indent);
				_Output.Write ("user's private keys and certificates.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
