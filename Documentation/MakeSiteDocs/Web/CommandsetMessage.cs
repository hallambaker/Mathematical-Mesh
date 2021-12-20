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
	// WebMessage
	//
	public static void WebMessage(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/message.md");
		Examples._Output = _Output;
		Examples._WebMessage(Examples);
		}
	public void _WebMessage(CreateExamples Examples) {

			 MakeTitle ("message");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message` command set contains commands that send, receive and respond to \n{0}", _Indent);
			_Output.Write ("Mesh transactional messages. Currently, two Mesh messaging applications are defined:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("<dl>\n{0}", _Indent);
			_Output.Write ("<dt>Contact\n{0}", _Indent);
			_Output.Write ("<dd>Contact messages allow exchange of contact information. If a contact request\n{0}", _Indent);
			_Output.Write ("is accepted, the contact details are added to the recipient's contact catalog.\n{0}", _Indent);
			_Output.Write ("<dt>Confirmation\n{0}", _Indent);
			_Output.Write ("<dd>Confirmation messages allow authorized senders to ask for a specific request \n{0}", _Indent);
			_Output.Write ("to be accepted or denied. If the recpient replies to a confirmation message, a\n{0}", _Indent);
			_Output.Write ("signed response is returned stating the user's response.\n{0}", _Indent);
			_Output.Write ("</dl>\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("# Contact Request\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Contacts catalog plays an important role in Mesh messaging as it is used to\n{0}", _Indent);
			_Output.Write ("determine the recipient's security policy to be applied to outbound messages and \n{0}", _Indent);
			_Output.Write ("perform access control on inbound messages.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Having created a Mesh profile, Bob asks Alice to add him to her contacts catalog\n{0}", _Indent);
			_Output.Write ("using the {1} command:\n{0}", _Indent, ToCommand("message contact"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellMessage.ContactRequest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice reviews her pending messages using the {1} command:\n{0}", _Indent, ToCommand("message pending"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellMessage.ContactPending);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice sees the request from Bob and accepts it with the {1} command:\n{0}", _Indent, ToCommand("message accept"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellMessage.ContactAccept);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob's contact information has been added to Alice's address book:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellMessage.ContactCatalogList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob can find out if Alice has accepted his contact request using the \n{0}", _Indent);
			_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("message status"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellMessage.ContactGetResponse);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice has accepted Bob's request and added him to her contacts list. She has also sent\n{0}", _Indent);
			_Output.Write ("Bob a contact request which for the sake of convenience, is accepted automatically.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice isn't required to accept contact requests. She rejects the request from Mallet \n{0}", _Indent);
			_Output.Write ("using the {1} command:\n{0}", _Indent, ToCommand("message reject"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellMessage.ContactReject);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For good measure, she decides to block further requests:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellMessage.ContactBlock);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Mesh Confirmation protocol allows a message sender to ask the recipient a short\n{0}", _Indent);
			_Output.Write ("question. If the user chooses to respond, the sender receives back a non-repudiable \n{0}", _Indent);
			_Output.Write ("answer to the question.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Currently, questions and responses are constrained to the simple binary choice \n{0}", _Indent);
			_Output.Write ("Accept or Reject. It is possible that future versions of the protocol will permit \n{0}", _Indent);
			_Output.Write ("more complex questions to be asked but such extension will only be considered after \n{0}", _Indent);
			_Output.Write ("the base protocol has been extensively field tested.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Confirmation requests provide a superset of the funtionality afforded by traditional\n{0}", _Indent);
			_Output.Write ("second factor authentication systems. As with a second factor authentication system,\n{0}", _Indent);
			_Output.Write ("a confirmation response provides proof that the user approved a request but unlike\n{0}", _Indent);
			_Output.Write ("traditional systems, the proof provided is non repudiable and demonstrates that\n{0}", _Indent);
			_Output.Write ("a specific request was approved using a specific device belonging to the user.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("As with the Mesh Contact application, the Confirmation application is designed for \n{0}", _Indent);
			_Output.Write ("implementation on personal mobile devices such as watches or smartphonees making full \n{0}", _Indent);
			_Output.Write ("use of the available graphics and other affordances.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("# ConfirmationRequest\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The confirmation message exchange provides a form of second factor authentication in\n{0}", _Indent);
			_Output.Write ("which the user provides explicit, non-repudiable authorization for a specific action.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice sends Bob an email asking him to buy some equipment costing $6,000. Since this\n{0}", _Indent);
			_Output.Write ("is a significant sum, Bob needs an authorization for the purchase. He sends Alice\n{0}", _Indent);
			_Output.Write ("a confirmation request `{1}` using the  \n{0}", _Indent, ShellMessage.BobPurchase);
			_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("message confirm"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellMessage.ConfirmRequest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice reviews her pending messages using the using the {1} command:\n{0}", _Indent, ToCommand("message pending"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellMessage.ConfirmPending);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice she accepts Bob's request using the {1} command:\n{0}", _Indent, ToCommand("message pending"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellMessage.ConfirmAccept);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob receives Alice's approval using the {1} command:\n{0}", _Indent, ToCommand("message status"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellMessage.ConfirmGetAccept);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("In a full workflow system, Bob might include the response from Alice in a message to\n{0}", _Indent);
			_Output.Write ("the accounts department asking them to place the order.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice can also reject requests using the {1} command:\n{0}", _Indent, ToCommand("message reject"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellMessage.ConfirmReject);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob receives a reply telling him the request was rejected:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellMessage.ConfirmGetReject);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("As with all Mesh messages, confirmation requests are subject to access control.\n{0}", _Indent);
			_Output.Write ("When Mallet attempts to make a request of Alice, it is rejected because Alice\n{0}", _Indent);
			_Output.Write ("hasn't accepted his credentials or authorized him to send confirmation requests:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellMessage.ConfirmMallet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Mallet cannot respond to the request sent by Bob because he can't read Alice's\n{0}", _Indent);
			_Output.Write ("messages to discover the request to reply to. Nor can he create a valid signature\n{0}", _Indent);
			_Output.Write ("on the response should this information be accidentally disclosed.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// MessageReference
	//
	public static void MessageReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/message.md");
		Examples._Output = _Output;
		Examples._MessageReference(Examples);
		}
	public void _MessageReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Message;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message` command set contains commands that send, receive and respond to \n{0}", _Indent);
			_Output.Write ("Mesh transactional messages.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ message accept
			 Describe(CommandSet, _MessageAccept._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message accept` command accepts a confirmation request. A request message is\n{0}", _Indent);
			_Output.Write ("created, signed under the device key and returned to the recipient's service\n{0}", _Indent);
			_Output.Write ("provider for forwarding to the requestor.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The confirmation request to be accepted is specified by its message identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The required parameter is the message identifier of the request to be accepted.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellMessage.ContactAccept);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ message block
			 Describe(CommandSet, _MessageBlock._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message block` command adds a party to the user's blocklist.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The required parameter is the identifier of the party to be blocked. This may\n{0}", _Indent);
			_Output.Write ("be a local name defined in the contacts book or an address.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellMessage.ContactBlock);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ message confirm
			 Describe(CommandSet, _MessageConfirm._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message confirm` command initiates a confirmation interaction by sending a\n{0}", _Indent);
			_Output.Write ("confirmation request to the named party.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first parameter is required and specifies the intended recipient.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The second parameter specifies the request text and is currently required but\n{0}", _Indent);
			_Output.Write ("may become optional if alternative means of specifying the request text are \n{0}", _Indent);
			_Output.Write ("supported.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellMessage.ConfirmRequest);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ message contact
			 Describe(CommandSet, _MessageContact._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message contact` command  initiates a contact interaction by sending a\n{0}", _Indent);
			_Output.Write ("confirmation request to the named party.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first parameter is required and specifies the intended recipient.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellMessage.ContactRequest);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ message pending
			 Describe(CommandSet, _MessagePending._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message pending` command returns all pending messages in the spool. It\n{0}", _Indent);
			_Output.Write ("is used in the same way as the `device pending` command except that it causes\n{0}", _Indent);
			_Output.Write ("all pending messages matching the specified criteria to be returned, not just\n{0}", _Indent);
			_Output.Write ("the pending messages.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'read' and 'unread' flags may be used to filter responses to return messages\n{0}", _Indent);
			_Output.Write ("that have been read or are unread. By default, only unread messages are returned.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellMessage.ContactPending);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ message reject
			 Describe(CommandSet, _MessageReject._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message reject` command rejects a confirmation request. A request message is\n{0}", _Indent);
			_Output.Write ("created, signed under the device key and returned to the recipient's service\n{0}", _Indent);
			_Output.Write ("provider for forwarding to the requestor.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The confirmation request to be rejected is specified by its message identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The required parameter is the message identifier of the request to be rejected.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellMessage.ContactReject);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ message status
			 Describe(CommandSet, _MessageStatus._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `message status` command returns the status of a previously sent confirmation\n{0}", _Indent);
			_Output.Write ("request.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The confirmation request to be queried is specified by its message identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (ShellMessage.ConfirmGetAccept);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
