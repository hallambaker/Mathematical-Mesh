using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Portal;
using  Goedel.Mesh.Portal.Server;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// ExamplesMessaging
		//
		public static void ExamplesMessaging (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesMessaging.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Mesh Messaging\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh messaging services are very similar to Mesh catalog services but \n{0}", _Indent);
				_Output.Write ("with one important difference: Requests to append or update message \n{0}", _Indent);
				_Output.Write ("entries come from a third party that may prove untrustworthy. It is \n{0}", _Indent);
				_Output.Write ("therefore necessary to apply access control to inbound message requests.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The persistence store for a messaging service is called a spool. As with \n{0}", _Indent);
				_Output.Write ("the catalog store of a catalog service, the DARE Container format is designed\n{0}", _Indent);
				_Output.Write ("to support the requirements of managing a messaging service spool but \n{0}", _Indent);
				_Output.Write ("Mesh Services MAY use any persistence technology that meets their needs.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Some Mesh messaging services are standalone while others are closely \n{0}", _Indent);
				_Output.Write ("related to a catalog service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<li>Accepting a contact request message SHOULD result in an entry being \n{0}", _Indent);
				_Output.Write ("added to the user's contact catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<li>Accepting a recryption membership notification SHOULD result in\n{0}", _Indent);
				_Output.Write ("an entry being added to the recipient's credential catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<li>Accepting a device connection request MUST result in an entry being\n{0}", _Indent);
				_Output.Write ("added to the user's devices catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The PostUpdate method allows a Mesh client to reply to an inbound request \n{0}", _Indent);
				_Output.Write ("and post an entry to the accompanying catalog at the same time.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh messaging services adopt a four corner communication mode in which \n{0}", _Indent);
				_Output.Write ("the sender of a message forwards the request to their own Mesh Service \n{0}", _Indent);
				_Output.Write ("which in turn contacts the recipient's Mesh service to organize delivery.\n{0}", _Indent);
				_Output.Write ("As with any other four Mesh Service MAY act for both the sender and receiver \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The only circumstance in which the sender and recipient communicate \n{0}", _Indent);
				_Output.Write ("directly is in a two phase synchronous protocol in which a four corner first\n{0}", _Indent);
				_Output.Write ("phase is used to negotiate parameters for a direct connection in the second\n{0}", _Indent);
				_Output.Write ("phase.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Message Origination\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Messages are posted to the senders outbound Mesh Service using the Post method.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice meets Bob and they 'bump' phones performing a QR code exchange. To begin this exchange,\n{0}", _Indent);
				_Output.Write ("Alice's device generates a random one-time use passcode. Note that since this passcode\n{0}", _Indent);
				_Output.Write ("is only used to authenticate the exchange to mitigate abuse, a work\n{0}", _Indent);
				_Output.Write ("factor of 2^64 is more than sufficient.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("lYFAVLNJLkC\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The QR code is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[QR code image]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The decoded URI is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("mmm:alice@example.com.mmm-wekjhwkjehrkjwher:c:lYFAVLNJLkC\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob's phone reads the QR code and creates a contact request message containing \n{0}", _Indent);
				_Output.Write ("Bob's information. The contact request asks to be able to send various types of\n{0}", _Indent);
				_Output.Write ("message.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{BobContactPostRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Messages are subject to access control by both the inbound and outbound services.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob's Mesh Service checks to see if the rate of contact requests he has made in the \n{0}", _Indent);
				_Output.Write ("past is excessive. Finding that it is not, the contact request is accepted and placed in \n{0}", _Indent);
				_Output.Write ("the outbound messages queue.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob's service responds with a unique identifier that MAY be used to check on the status\n{0}", _Indent);
				_Output.Write ("of the message:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{BobContactPostRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A short while later, Bob's phone asks for a status update on the request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{BobContactStatusRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice has not responded yet (she is talking to Bob in person).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{BobContactStatusRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If Bob decides not to connect after all, he can cancel the request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Message Transit\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Passing of messages between Mesh Services is called transit.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To begin a message transfer, the outbound service makes a PostRequest to the \n{0}", _Indent);
				_Output.Write ("inbound service which contains the message headers and the maximum size of the\n{0}", _Indent);
				_Output.Write ("payload.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{OutboundPostRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The inbound service performs access control on the PostRequest according to site \n{0}", _Indent);
				_Output.Write ("policy which MAY include use any resources the inbound service chooses to use,\n{0}", _Indent);
				_Output.Write ("including:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Valid one time use authorization code issued by the recipient to the sender\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Credentials provided by the inbound service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* The sender's entry in the recipient's contact catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* The type of access requested.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The access control policy is set by the Mesh Service and the user. When setting an\n{0}", _Indent);
				_Output.Write ("access control policy, both should consider the likelihood that the recipient would \n{0}", _Indent);
				_Output.Write ("wish to accept the message and the risk of harm resulting.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Different users will naturally require different access policies. A celebrity receiving\n{0}", _Indent);
				_Output.Write ("hundreds of contacts a day is likely to require closer access control criteria than\n{0}", _Indent);
				_Output.Write ("a person receiving one request a week. A request to send email messages presents \n{0}", _Indent);
				_Output.Write ("a lower degree of risk than a request to send invoices or program code.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In this case, the request has been pre-approved by means of a one time use authentication\n{0}", _Indent);
				_Output.Write ("code provided by Alice's device. The inbound service has no means of verifying\n{0}", _Indent);
				_Output.Write ("the authentication code at this stage but accepts the request knowing that it\n{0}", _Indent);
				_Output.Write ("will be rejected by Alice's client if it proves to be bogus.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{OutboundPostResponse}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the contact request message is short, the inbound service authorizes the \n{0}", _Indent);
				_Output.Write ("outbound service to send the message body immediately. If the message was longer,\n{0}", _Indent);
				_Output.Write ("the inbound service might tell the outbound to defer delivery of the message body\n{0}", _Indent);
				_Output.Write ("which might be completed by means of an incremental transfer (e.g. in chunks of\n{0}", _Indent);
				_Output.Write ("4MB at a time).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This mechanism allows the same messaging protocol to be used to transfer messages\n{0}", _Indent);
				_Output.Write ("of a few bytes to multiple terabytes. A Mesh Service is not required to support \n{0}", _Indent);
				_Output.Write ("such messages however and particularly in the case of very large messages, may\n{0}", _Indent);
				_Output.Write ("delgate collection of the message payload to the destination device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Receiving Messages\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Pending messages are received by synchronizing the message spool of the device\n{0}", _Indent);
				_Output.Write ("with the message spool of the messaging service. This process is identical to \n{0}", _Indent);
				_Output.Write ("synchonizing a catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{SyncRequest}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("There is only one message in the contact request spool to be synchronized:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{SyncResponse}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A device MAY improve the user experience by requesting the service provide just the \n{0}", _Indent);
				_Output.Write ("headers of the queued messages or to filter messages of a particular type or which\n{0}", _Indent);
				_Output.Write ("have particular characteristics.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Responding to Messages\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("As previously noted, the response to a message request frequently entails an update\n{0}", _Indent);
				_Output.Write ("to the user's corresponding catalog. Otherwise, posting a response is the same as a \n{0}", _Indent);
				_Output.Write ("request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice's phone verifies the authentication code on Bob's request and automatically \n{0}", _Indent);
				_Output.Write ("approves it for the level of access Alice specified when they bumped phones. A new \n{0}", _Indent);
				_Output.Write ("contact entry is created together with a contact request message to be returned to Bob\n{0}", _Indent);
				_Output.Write ("notifying him that his request was approved by Alice and providing him with her details \n{0}", _Indent);
				_Output.Write ("for his contact catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{ContactAddResponse}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}