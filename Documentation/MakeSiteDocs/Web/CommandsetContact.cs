using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// WebContact
		//
		public static void WebContact(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/contact.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/contact.md" };
			obj._WebContact(Examples);
			}
		public void _WebContact(CreateExamples Examples) {

				 MakeTitle ("contacts");
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `contacts` command set is used to manage the user's contacts catalogue.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The contacts catalogue plays an important role in Mesh messaging as it is used to \n{0}", _Indent);
				_Output.Write ("determine the security policy for sending outbound messages and is one of the\n{0}", _Indent);
				_Output.Write ("sources used to perform access control (i.e. spam filtering) on inbound messages.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Although the `meshman` tool is capable of adding, deleting and retrieving\n{0}", _Indent);
				_Output.Write ("contact entries, it is intended to serve as a component to be used to build user\n{0}", _Indent);
				_Output.Write ("interfaces rather than a tool designed for daily use.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds a contact entry to a catalog from\n{0}", _Indent, ToCommand("contact add"));
				_Output.Write ("a file. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellContact.ContactAdd);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The file {1} contains Carol's contact information in\n{0}", _Indent, CarolContactFile);
				_Output.Write ("JSON format:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("[Carol's contact information]\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `/self` option is used to mark the contact as being the user's own contact\n{0}", _Indent);
				_Output.Write ("details:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellContact.ContactAddSelf);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Contacts may also be added by accepting contact request messages using the \n{0}", _Indent);
				_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("message accept"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellContact.ContactAccept);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Finding contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command retreives a contact by the contact's \n{0}", _Indent, ToCommand("contact get"));
				_Output.Write ("email address or label:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellContact.ContactGet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Listing contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A complete list of contacts is obtained using the  {1} command:\n{0}", _Indent, ToCommand("contact list"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellContact.ContactList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Deleting contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Contact entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("contact delete"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellContact.ContactDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding devicesF\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Devices are given authorization to access the contacts catalog using the \n{0}", _Indent);
				_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write (" %  ConsoleExample (ShellContact.ContactAuth);\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write (" The newly authorized device can now access the contacts catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write (" %  ConsoleExample (ShellContact.ContactList2);\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ContactReference
		//
		public static void ContactReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/contact.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/contact.md" };
			obj._ContactReference(Examples);
			}
		public void _ContactReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Contact;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactAdd._DescribeCommand);
				 ConsoleReference (ShellContact.ContactAdd);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactDelete._DescribeCommand);
				 ConsoleReference (ShellContact.ContactDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactGet._DescribeCommand);
				 ConsoleReference (ShellContact.ContactGet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactDump._DescribeCommand);
				 ConsoleReference (ShellContact.ContactList);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
