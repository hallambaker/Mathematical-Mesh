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
		// UserGuideConfirm
		//
		public static void UserGuideConfirm (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Apps/confirm.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Confirm\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mesh/Confirm\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Second factor authentication done right\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This document provides an introduction to the Mesh/Confirm application. For a\n{0}", _Indent);
				_Output.Write ("more complete description and a detailed reference guide, consult the \n{0}", _Indent);
				_Output.Write ("<a=\"/Documents/draft-hallambaker-mesh-confirm.html\">Internet Draft</a>.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Traditional second factor authentication mechanism offer limited security and are \n{0}", _Indent);
				_Output.Write ("tedious to use.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Any security mechanism that requires users to carry an additional item is inevitably\n{0}", _Indent);
				_Output.Write ("inconvenient. When an employee arrives at a facility having forgotten their token,\n{0}", _Indent);
				_Output.Write ("an employer has no choice but to allow them access or lose the employee's work for\n{0}", _Indent);
				_Output.Write ("that day.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("One Time Passcode (OTP) tokens using a clock or a button to advance a four, six or\n{0}", _Indent);
				_Output.Write ("eight digit passcode provide a reasonably high degree of confidence that the token was\n{0}", _Indent);
				_Output.Write ("at least involved in the authentication process in some fashion. Secure use of OTP \n{0}", _Indent);
				_Output.Write ("tokens require users to be aware of and detect man-in-the-middle attacks,\n{0}", _Indent);
				_Output.Write ("an impossible task in many of the applications for which they are commonly used.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("'Smartokens' such as a smartcard or USB token using public key technology provide a \n{0}", _Indent);
				_Output.Write ("more reliable means of  authentication than OTP tokens but typically require \n{0}", _Indent);
				_Output.Write ("installation of third party drivers  and software and all the reliability issues \n{0}", _Indent);
				_Output.Write ("that inevitably incurs. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Most users who use an OTP token have a smart phone that has a display, a means of \n{0}", _Indent);
				_Output.Write ("keyboard input and network connectivity. We can use these devices to emulate the \n{0}", _Indent);
				_Output.Write ("obsolete OTP token technology created in the 1970s or we can use these capabilities\n{0}", _Indent);
				_Output.Write ("to address the actual problem we are trying to solve.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh/Confirm is a second factor authentication mechanism that allows an Enquirer\n{0}", _Indent);
				_Output.Write ("to request confirmation of a specific action. The User is then asked if they wish\n{0}", _Indent);
				_Output.Write ("to confirm that action and their signed response is returned to the Enquirer.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<img=\"/Graphics/Confirm.svg\">\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The user experience is straightforward. They are asked a question with two options\n{0}", _Indent);
				_Output.Write ("(accept or reject) and they give their response.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<img=\"/Graphics/ConfirmSummary.svg\">\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Using the confirmation service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Use of the confirmation service requires the user to have a Mesh/Account with that service.\n{0}", _Indent);
				_Output.Write ("Alice creates an account using the meshapp tool:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("AccountAlice"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To request a confirmation from Alice, the Enquirer must know Alice's account. We assume \n{0}", _Indent);
				_Output.Write ("that this has been configured out of band through some previous interaction.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Enquirer requests posts a confirmation request to Alice's account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("ConfirmPost"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Enquirer can poll to determine the status of the request immediately but this doesn't\n{0}", _Indent);
				_Output.Write ("return Alice's response because she hasn't given it yet:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("ConfirmStatus1"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The user side of the confirmation service is intended for implementation as a GUI \n{0}", _Indent);
				_Output.Write ("application on a moble device such as a phone or watch. For purposes of demonstration,\n{0}", _Indent);
				_Output.Write ("we use the command line client:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice requests a list of pending confirmation requests.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("ConfirmPending"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice accepts the request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("ConfirmAccept"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When the Enquirer polls a second time, Alice's response is returned:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("ConfirmStatus2"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
