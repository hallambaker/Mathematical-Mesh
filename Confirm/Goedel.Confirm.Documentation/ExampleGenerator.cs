using  System.Text;
using  Goedel.Confirm;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace Goedel.Confirm.Documentation {
	/// <summary>A Goedel script.</summary>
	public partial class ExampleGenerator : global::Goedel.Registry.Script {
		/// <summary>Default constructor.</summary>
		public ExampleGenerator () : base () {
			}
		/// <summary>Constructor with output stream.</summary>
		/// <param name="Output">The output stream</param>
		public ExampleGenerator (TextWriter Output) : base (Output) {
			}

		

		//
		// AdminExamples
		//
		public void AdminExamples (ConfirmExamples Example) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Check service connection\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("It is often useful to be able to verify that a service is ready and willing\n{0}", _Indent);
			_Output.Write ("to perform transactions before attempting to perform one. Especially so\n{0}", _Indent);
			_Output.Write ("when the transaction requires considerable amounts of data and may require the \n{0}", _Indent);
			_Output.Write ("use of specific server determined authentication options.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request message is 'HelloRequest' and has no parameters:\n{0}", _Indent);
			 var Point = Example.Traces.Get (Example.LabelHello);
			 Example.Traces.Level = 0;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The response message specifies the protocol version(s) supported, the corresponding\n{0}", _Indent);
			_Output.Write ("encodings and bindings:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Enquirer posts request.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice attempts to log into her computer system as administrator. The site policy \n{0}", _Indent);
			_Output.Write ("requires that all administrative logins be confirmed via Mesh/Confirm. Alice's\n{0}", _Indent);
			_Output.Write ("confirmation account is alice@example.com. In this exchange, the computer Alice \n{0}", _Indent);
			_Output.Write ("is trying to access is the Enquirer, the device she uses to respond to the query \n{0}", _Indent);
			_Output.Write ("(her watch) is the Responder and the Mesh/Confirm service at example.com is the \n{0}", _Indent);
			_Output.Write ("broker.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The computer acting as Enquirer (example.net) creates a confirmation request as \n{0}", _Indent);
			_Output.Write ("follows:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n{0}", _Indent);
			_Output.Write ("<srml xmlns=\"http://hallambaker.com/Schemas/srml.xsd\">\n{0}", _Indent);
			_Output.Write ("  <h1>Grant Administrator</h1>\n{0}", _Indent);
			_Output.Write ("  <p>Host: example.net</p>\n{0}", _Indent);
			_Output.Write ("  <button value=\"Access\">Access</button>\n{0}", _Indent);
			_Output.Write ("</srml>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that it is not necessary to specify the reject option since this is \n{0}", _Indent);
			_Output.Write ("implicit.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request message is 'EnquireRequest' which contains an object signed by the\n{0}", _Indent);
			_Output.Write ("Enquirer that specifies the account the request is directed to and the \n{0}", _Indent);
			_Output.Write ("request text. \n{0}", _Indent);
			  Point = Example.Traces.Get (Example.LabelEnquire);
			 Example.Traces.Level = 1;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request is accepted and a success response returned specifying the transaction ID.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that while the requirement that request messages be authenticated by means\n{0}", _Indent);
			_Output.Write ("of a digital signature is within the scope of Mesh/Recrypt, the specification of\n{0}", _Indent);
			_Output.Write ("the filtering rules is not.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Responder fetches pending requests.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("At present, the only mechanism for determining if there are pending requests is by\n{0}", _Indent);
			_Output.Write ("polling. Provision of a push notification mechanism is an obvious priority for\n{0}", _Indent);
			_Output.Write ("future improvement of the protocol.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice's watch regularly polls the broker to determine if there are pending confirmation\n{0}", _Indent);
			_Output.Write ("requests.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Point = Example.Traces.Get (Example.LabelPending);
			 Example.Traces.Level = 0;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The response message contains the number of pending requests meeting the selection \n{0}", _Indent);
			_Output.Write ("criteria and the returned requests.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Each request is signed by the Enquirer that originally generated it.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Responder replies to request.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice selects the pending access request and grants herself access to the machine\n{0}", _Indent);
			_Output.Write ("she is attempting to log in to. Her watch creates a signed response message \n{0}", _Indent);
			_Output.Write ("containing the digest of the original request and her response \"Accept\".\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Point = Example.Traces.Get (Example.LabelRespond);
			 Example.Traces.Level = 0;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The response message tells Alice that the transaction completed successfully and\n{0}", _Indent);
			_Output.Write ("the broker has her acceptance message.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that in future versions of the protocol it may be desirable to make use of\n{0}", _Indent);
			_Output.Write ("additional affordances of the device such as the ability to perform biometric \n{0}", _Indent);
			_Output.Write ("capture such as fingerprint or facial recognition.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Another possibility is that the user might be asked to enter a one time use PIN \n{0}", _Indent);
			_Output.Write ("generated by the Enquirer, thus verifying that the user is indeed responding \n{0}", _Indent);
			_Output.Write ("to the confirmation request they believe they are responding to.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Enquirer fetches result\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The enquirer obtains the result of the confirmation request by polling using the \n{0}", _Indent);
			_Output.Write ("Status transaction.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Point = Example.Traces.Get (Example.LabelStatus);
			 Example.Traces.Level = 0;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since Alice has responded, the response message contains the signed result:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("As with the use of polling on the user side, it is obviously desirable to\n{0}", _Indent);
			_Output.Write ("eliminate the need for polling by introducing a callback registration \n{0}", _Indent);
			_Output.Write ("mechanism. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		}
	}
