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
		// UserGuideLinux
		//
		public static void UserGuideLinux (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Platform/Linux.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Linux\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Linux\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Using the Mesh on Linux\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Installation\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Currently only a tar file is provided.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Platform specific features\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Profile storage\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Profiles are stored in the directory <tt>~/.Mesh/Profiles</tt>.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Key storage\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Profiles are stored in the directory <tt>~/.Mesh/Keystore</tt>.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Further work\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Use of an encrypting file system to protect the keys is highly desirable. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("On Ubuntu, the <a=\"https://help.ubuntu.com/community/EncryptedPrivateDirectory\">Encrypted\n{0}", _Indent);
				_Output.Write ("Private Directory</a> <tt>~/.private</tt> seems to be ideal.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For this to be regarded as being supported, the meshman tool should support \n{0}", _Indent);
				_Output.Write ("configuration of encrypted file system directories with escrow of the private key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
