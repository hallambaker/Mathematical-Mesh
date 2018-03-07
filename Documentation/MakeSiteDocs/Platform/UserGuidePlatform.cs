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
		// UserGuidePlatform
		//
		public static void UserGuidePlatform (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Platform/index.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Platforms\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mesh Platform Specific Features\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The goal of the Mesh is to make computers easier to use by making them more secure.\n{0}", _Indent);
				_Output.Write ("In order to achieve this goal, Mesh applications must look like and behave in the \n{0}", _Indent);
				_Output.Write ("fashion that the user expects on that platform.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Equally importantly, one of the objectives of developing the Mesh is to make use of\n{0}", _Indent);
				_Output.Write ("security capabilities provided by the platform. If a Mesh application is running on\n{0}", _Indent);
				_Output.Write ("Windows, cryptographic keys should be stored in the Windows keystore, if a Mesh application\n{0}", _Indent);
				_Output.Write ("is running on OSX, cryptographic keys should be stored in the keykeychain, etc.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For this reason, the Mesh Reference Libraries have been carefully structured to\n{0}", _Indent);
				_Output.Write ("allow key functionality to be tightly integrated to the host platform. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Platforms\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The following platforms are anticipated:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt><a=\"Windows.html\">Windows</a>\n{0}", _Indent);
				_Output.Write ("<dd>Version 7.0 and higher. Makes use of the Windows Registry and Key Store for \n{0}", _Indent);
				_Output.Write ("storing profiles and private keys.\n{0}", _Indent);
				_Output.Write ("<dt><a=\"OSX.html\">OSX</a>\n{0}", _Indent);
				_Output.Write ("<dd>Currently only supported via the Linux distribution. Addition of support for\n{0}", _Indent);
				_Output.Write ("use of the keychain is highly desirable.\n{0}", _Indent);
				_Output.Write ("<dt><a=\"Linux.html\">Linux</a>\n{0}", _Indent);
				_Output.Write ("<dd>Testing using Ubuntu. Profiles and private keys are stored in files in the\n{0}", _Indent);
				_Output.Write ("users home directory.\n{0}", _Indent);
				_Output.Write ("<dt><a=\"Docker.html\">Docker</a>\n{0}", _Indent);
				_Output.Write ("<dd>Use of a Docker container to host Mesh Portal and Application Servers. This is\n{0}", _Indent);
				_Output.Write ("currently experimental.\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Current Status\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("At present, many of these goals are 'aspirational' rather than actual. These pages \n{0}", _Indent);
				_Output.Write ("provide architectural notes for developers who may be interested in implementation.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh Reference code is being developed on a Windows platform using .Net \n{0}", _Indent);
				_Output.Write ("Framework 4.7. It is to be expected that the Windows version of the code will always\n{0}", _Indent);
				_Output.Write ("be the most up to date and tightly integrated with the platform features.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Previous versions of the code libraries have been ported to Linux and tested \n{0}", _Indent);
				_Output.Write ("successfully. Extending the build system to create a Linux distribution with a\n{0}", _Indent);
				_Output.Write ("Debian installation package is a near term priority. This will in turn facilitate\n{0}", _Indent);
				_Output.Write ("distribution of the server code as a Docker container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Integration with the OSX platform is currently a low priority due to the fact that\n{0}", _Indent);
				_Output.Write ("while the Linux code will run on OSX, the reverse is not the case.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
