using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	

	//
	// WebContact
	//
	public static void WebContact(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/contact.md");
		Examples._Output = _Output;
		Examples._WebContact(Examples);
		}
	public void _WebContact(CreateExamples Examples) {

			 MakeTitle ("contact");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `contact` command set is used to manage the user's contacts catalogue.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The contacts catalogue plays an important role in Mesh messaging as it is used to \n{0}", _Indent);
			_Output.Write ("manage the security policy for sending outbound messages and is one of the\n{0}", _Indent);
			_Output.Write ("sources used to compile the access control authorizations (i.e. spam filtering) \n{0}", _Indent);
			_Output.Write ("on inbound messages.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Mesh Service cannot read the contacts catalog entries themselves but\n{0}", _Indent);
			_Output.Write ("the data in the contact catalog is used to compile the access catalog entries\n{0}", _Indent);
			_Output.Write ("that grant the service the ability to act on the account holder's behalf..\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Although the `meshman` tool is capable of adding, deleting and retrieving\n{0}", _Indent);
			_Output.Write ("contact entries, it is intended to serve as a component to be used to build user\n{0}", _Indent);
			_Output.Write ("interfaces rather than a contact book designed for daily use.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, FutureFeature("Contact/Auth", "Specify messaging authorizations"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding contacts from a file\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds contact information to the catalog directly.\n{0}", _Indent, ToCommand("contact import"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The file {1} contains Carol's contact information in\n{0}", _Indent, CarolContactFile);
			_Output.Write ("JSON format:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("[Carol's contact information]\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice adds Carol's contact information to her contact catalog directly:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactAdd);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The  {1} command is used to inport a contact and mark it as \n{0}", _Indent, ToCommand("contact self"));
			_Output.Write ("being the user's own contact details:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactAddSelf);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Exchanging contacts with other users.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Every Mesh Messaging communication is mediated through access control. Unlike\n{0}", _Indent);
			_Output.Write ("a telephone number, a postal or email address, mere knowledge of a Mesh\n{0}", _Indent);
			_Output.Write ("Messaging address does not grant the ability to use it to send a message. This\n{0}", _Indent);
			_Output.Write ("makes exchange of contact information considerably easier since we are only\n{0}", _Indent);
			_Output.Write ("concerned with the authenticity and accuracy of the identity claims made, \n{0}", _Indent);
			_Output.Write ("the mesh address information itself is not confidential.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Contacts may be acquired from other users through a variety of approaches. If the \n{0}", _Indent);
			_Output.Write ("parties meet in person, the exchange may be performed through a QR code or near\n{0}", _Indent);
			_Output.Write ("field communication exchange. If they are remote from each other, a network\n{0}", _Indent);
			_Output.Write ("mediated exchange may be used.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Exchange need not be reciprocated. A unidirectional exchange may be effected by\n{0}", _Indent);
			_Output.Write ("means of a URI or QR code printed on a business card or a Web site.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("### Remote Contact Exchange\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The  {1} command begins a remote contact exchange.\n{0}", _Indent, ToCommand("message contact"));
			_Output.Write ("This form of exchange allows exchange of contact information between users\n{0}", _Indent);
			_Output.Write ("who are not present in the same location.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To request an exchange of contact information with Alice, Bob specifies her \n{0}", _Indent);
			_Output.Write ("Mesh account address:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactBobRequest );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice accepts the contact exchange with the {1} \n{0}", _Indent, ToCommand("message accept"));
			_Output.Write ("command. She can now check Bob's contact appears in her contacts catalog \n{0}", _Indent);
			_Output.Write ("with the {1} command:\n{0}", _Indent, ToCommand("contact list"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactAliceResponse );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since Bob initiated the contact exchange, the authorization to accept \n{0}", _Indent);
			_Output.Write ("Alice's contact information is implicit in Bobs original command. All he needs\n{0}", _Indent);
			_Output.Write ("to do is synchronize his device with the service and Alice's contact\n{0}", _Indent);
			_Output.Write ("information appears in his catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactBobFinal );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("### Dynamic Contact Exchange\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Dynamic Contact Exchange is designed for situations where the parties are\n{0}", _Indent);
			_Output.Write ("present in the same physical location. The contact exchange being typically mediated\n{0}", _Indent);
			_Output.Write ("by means of a QR code or near field communication interaction.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Carol begins a dynamic contact exchange with the {1} \n{0}", _Indent, ToCommand("contact dynamic"));
			_Output.Write ("command.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactCarolDynamicPin );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The URI generated by the contact dynamic command is really intended to be presented as\n{0}", _Indent);
			_Output.Write ("a QR code or other machine readable form. In this case the URI is entered into the\n{0}", _Indent);
			_Output.Write ("meshman tool directly using the {1} command \n{0}", _Indent, ToCommand("message contact"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice can accept the contact using either the {1} \n{0}", _Indent, ToCommand("contact fetch"));
			_Output.Write ("command if she wants to accept Carol's contact without reciprocating or\n{0}", _Indent);
			_Output.Write ("the {1} if she wants to provide Carol with her\n{0}", _Indent, ToCommand("contact exchange"));
			_Output.Write ("contact information. In this case she authorizes a mutual exchange\n{0}", _Indent);
			_Output.Write ("adding Carol to her contacts catalog:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Concat (Contact.ContactCarolDynamicFetch, Contact.ContactCarolListAlice));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Carol can now complete the interaction by synchronizing one of her devices:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Concat (Contact.ContactCarolDynamicAliceGet, Contact.ContactCarolListCarol));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("### Static Exchange\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The static contact exchange allows a QR code or other machine readable presentation\n{0}", _Indent);
			_Output.Write ("of a URI to be used to publish a contact in a form that allows another to add it to their\n{0}", _Indent);
			_Output.Write ("catalog. Such a code might be printed on a business card for example.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Doug creates a static contact URI with the {1} command:\n{0}", _Indent, ToCommand("contact static"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactDougStaticUri );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice scans the URI printed on Doug's business card and collects the contact information.\n{0}", _Indent);
			_Output.Write ("using the {1} command:\n{0}", _Indent, ToCommand("contact fetch"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Concat (Contact.ContactDougStaticFetch, Contact.ContactStaticListAlice));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Finding contacts\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command retreives a contact by the contact's \n{0}", _Indent, ToCommand("contact get"));
			_Output.Write ("email address or label:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Listing contacts\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A complete list of contacts is obtained using the  {1} command:\n{0}", _Indent, ToCommand("contact list"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Deleting contacts\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Contact entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("contact delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Contact.ContactDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding devices\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The device Alice5 was connected to her account without the contact catalog right.\n{0}", _Indent);
			_Output.Write ("Requests to access the contacts catalog fail:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellContact.ContactList1);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ability to selectively grant access to devices allows realization of the 'least \n{0}", _Indent);
			_Output.Write ("privilege' principal in which each user and device is granted the bare minimum\n{0}", _Indent);
			_Output.Write ("of functionality required to perform their task. What the device does not know, the\n{0}", _Indent);
			_Output.Write ("device cannot disclose.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Devices are given authorization to access the contacts catalog using the \n{0}", _Indent);
			_Output.Write (" {1} command.\n{0}", _Indent, ToCommand("device auth"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectJoinAuth );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The newly authorized device can now access the contacts catalog:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellContact.ContactList2);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ContactReference
	//
	public static void ContactReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/contact.md");
		Examples._Output = _Output;
		Examples._ContactReference(Examples);
		}
	public void _ContactReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Contact;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ contact delete
			 Describe(CommandSet, _ContactDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact delete' command deletes a contact entry entry by means of \n{0}", _Indent);
			_Output.Write ("its unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (Contact.ContactDelete);
			_Output.Write ("\n{0}", _Indent);
			// ------------------  contact dynamic
			 Describe(CommandSet, _ContactDynamic._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact dynamic' command creates a dynamic contact URI such as\n{0}", _Indent);
			_Output.Write ("might be presented to another user as a QR code. The URI combines the\n{0}", _Indent);
			_Output.Write ("location data for the contact with an PIN that may\n{0}", _Indent);
			_Output.Write ("be used to authenticate the response in a mutual exchange.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (Contact.ContactCarolDynamicPin);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ contact exchange
			 Describe(CommandSet, _ContactExchange._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact exchange' command is used to complete a mutual contact exchange\n{0}", _Indent);
			_Output.Write ("by means of a dynamic URI.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (Contact.ContactCarolDynamicFetch);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ contact fetch
			 Describe(CommandSet, _ContactFetch._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact fetch' command is used to acquire a dynamic or static contact\n{0}", _Indent);
			_Output.Write ("presented as a URI or QR code without reciprocating the exchange.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (Contact.ContactDougStaticFetch);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ contact get
			 Describe(CommandSet, _ContactGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact get' command retrieves a contact entry by means of its \n{0}", _Indent);
			_Output.Write ("unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (Contact.ContactGet);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ contact import
			 Describe(CommandSet, _ContactImport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact import' command is used to add a contact entry to the catalog\n{0}", _Indent);
			_Output.Write ("from a file\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (Contact.ContactImport);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ contact list
			 Describe(CommandSet, _ContactDump._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact list' command lists all data in the contact catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (Contact.ContactCarolListAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ contact static
			 Describe(CommandSet, _ContactStatic._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'contact static' command creates a URI from which a static QR code may be created\n{0}", _Indent);
			_Output.Write ("to allow contact information to be published on a business card etc. in machine\n{0}", _Indent);
			_Output.Write ("readable form.\n{0}", _Indent);
			 ConsoleReference (Contact.ContactDougStaticUri);
			_Output.Write ("\n{0}", _Indent);
				}
		}
