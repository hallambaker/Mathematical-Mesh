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
		// UserGuideCreate
		//
		public static void UserGuideCreate (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("UserGuide/Mesh/create.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Creating\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Creating and Managing Mesh Profiles\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Creating a Personal Profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Before creating a profile, we may want to check to see if the desired portal account\n{0}", _Indent);
				_Output.Write ("is available. The meshman verify command is used for this:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("CreateVerify"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To create a personal profile using the default cryptographic algorithms, the meshman\n{0}", _Indent);
				_Output.Write ("command personal create is used. The only parameter required is the portal account:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("Create1"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Registering and unregistering profiles at portals\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, ToDo ("MultipleRegistrations", "Test support for multiple profile registgrations."));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A profile may be registered at multiple portals. This provides additional security in\n{0}", _Indent);
				_Output.Write ("the case that the original portal selected becomes unavailable.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The meshman command personal register is used to register the profile at an \n{0}", _Indent);
				_Output.Write ("additional portal:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("CreateRegister"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The meshman command personal deregister is used to deregister the profile from a portal:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("CreateDeregister"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that even when a portal is deregistered from every portal it has been connected to, \n{0}", _Indent);
				_Output.Write ("the profile data is still stored locally.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Miscelaneous commands\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The personal sync command synchronizes the local copy of a personal profile and all \n{0}", _Indent);
				_Output.Write ("connected application profiles that the device is connected to:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("CreateSync"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The personal fingerprint command returns the fingerprint of a profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("CreateFingerprint"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The personal import and personal export commands are used to import and export profiles.\n{0}", _Indent);
				_Output.Write ("If the password option is specified, the corresponding cryptographic keys are \n{0}", _Indent);
				_Output.Write ("exported as well.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, ToDo ("Import/Export", "Implement/vet the use of the import and export commands."));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Using multiple personal and device profiles\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, ToDo ("MultipleProfiles", "Test support for use of multiple profiles."));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh reference libraries and the meshman tool are both designed to support\n{0}", _Indent);
				_Output.Write ("the use of multiple personal and device profiles. While these code paths\n{0}", _Indent);
				_Output.Write ("have been implemented in the code, testing the use of multiple profiles is \n{0}", _Indent);
				_Output.Write ("a very low priority at present and it is therefore recommended that these \n{0}", _Indent);
				_Output.Write ("features not be used.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
