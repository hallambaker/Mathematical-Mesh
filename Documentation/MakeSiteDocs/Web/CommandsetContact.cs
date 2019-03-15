using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace MakeSiteDocs {
	public partial class MakeSiteDocs : global::Goedel.Registry.Script {

		

		//
		// WebContact
		//
		public static void WebContact(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/contact.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/contact.md" };
				obj._WebContact(Examples);
				}
			}
		public void _WebContact(Examples Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the `contacts` Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `contacts` command set is used to manage the user's contacts catalogue.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The contacts catalogue plays an important role in Mesh messaging as it is used to \n{0}", _Indent);
				_Output.Write ("determine the security policy for sending outbound messages and is one of the\n{0}", _Indent);
				_Output.Write ("sources used to perform access control (i.e. spam filtering) on inbound messages.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds a contact entry to a catalog:\n{0}", _Indent, ToCommand("contact add"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ContactAdd);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Contacts may also be added by accepting contact request messages:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContactPending);
				 ConsoleExample (Examples.ContactAccept);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Finding contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command retreives a contact by the contact's \n{0}", _Indent, ToCommand("contact get"));
				_Output.Write ("email address or label:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ContactGet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Listing contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A complete list of contacts is obtained using the  {1} command:\n{0}", _Indent, ToCommand("contact list"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ContactList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Deleting contacts\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Contact entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("contact delete"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.ContactDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Devices are given authorization to access the contacts catalog using the \n{0}", _Indent);
				_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write (" %  ConsoleExample (Examples.ContactAuth);\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ContactReference
		//
		public static void ContactReference(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/contact.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/contact.md" };
				obj._ContactReference(Examples);
				}
			}
		public void _ContactReference(Examples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Contact;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactAdd._DescribeCommand);
				 ConsoleReference (Examples.ContactAdd);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactDelete._DescribeCommand);
				 ConsoleReference (Examples.ContactDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactGet._DescribeCommand);
				 ConsoleReference (Examples.ContactGet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactDump._DescribeCommand);
				 ConsoleReference (Examples.ContactList);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
