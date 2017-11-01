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
		// UserGuideMail
		//
		public static void UserGuideMail (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Apps/mail.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>Email\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Using the Mesh to secure email\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>S/MIME, OpenPGP and beyond\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("End-to-end email encryption has been available to expert users for over 25 years. But \n{0}", _Indent);
				_Output.Write ("using end-to-end encrypted email has been a challenge to say the least. S/MIME requires\n{0}", _Indent);
				_Output.Write ("the user to obtain a digital certificate from a Certificate Authority and renew it\n{0}", _Indent);
				_Output.Write ("regularly. OpenPGP requires the user to learn an arcane set of instructions and lore.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Recently, applications such as Signal have proved that end-to-end encrypted messaging\n{0}", _Indent);
				_Output.Write ("can be just as easy as using regular email. But there is a catch and it is a big one,\n{0}", _Indent);
				_Output.Write ("each of the new 'easy to use' messaging systems introduced is a closed system with one\n{0}", _Indent);
				_Output.Write ("set of services connecting users. Some of the systems are open source, you can set up \n{0}", _Indent);
				_Output.Write ("your own network if you like but you won't have anyone to talk to.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh/Mail is a Mesh application that makes use of S/MIME and OpenPGP to encrypt email\n{0}", _Indent);
				_Output.Write ("end to end as easy as sending a regular email message. You don't need to change your\n{0}", _Indent);
				_Output.Write ("email provider and if you install the mail encryption proxy, you can use virtually \n{0}", _Indent);
				_Output.Write ("any email client produced in the last 20 years without modification.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This document describes the use of Mesh/Mail to create the credentials used to encrypt\n{0}", _Indent);
				_Output.Write ("and sign email.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The mail encryption proxy which makes use of end-to-end email encryption transparent \n{0}", _Indent);
				_Output.Write ("requires revision to make it compatible with the current version of the Mesh reference\n{0}", _Indent);
				_Output.Write ("code. This will be made available at a later date.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Creating an email application profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the mail client is supported by the Mesh Reference Code, The client can be configured to\n{0}", _Indent);
				_Output.Write ("use end-to-end encrypted email with the <tt>mail create</tt> command:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("MailCreate"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The meshman tool reads the email client configuration files, enumerates the accounts\n{0}", _Indent);
				_Output.Write ("and creates a Mesh profile containing S/MIME and OpenPGP keys for each.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Currently a self signed S/MIME certificate is created. A future version of the tool\n{0}", _Indent);
				_Output.Write ("will allow users to enroll for a free S/MIME certificate from Comodo Group Inc.:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("MailCreateCA"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Configuring an unsupported mail client\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Currently, the only mail client supported by the reference library is Windows Live Mail\n{0}", _Indent);
				_Output.Write ("which has since been replaced by Windows Mail. Enabling support for Outlook and Windows Mail\n{0}", _Indent);
				_Output.Write ("is a high priority.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Support may be added for almost any email client however, provided that it supports \n{0}", _Indent);
				_Output.Write ("configuration through a command line or shell interface of some sort.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To extract the users private key, we first generate a temporary password using the keygen\n{0}", _Indent);
				_Output.Write ("command.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("MailKeygen"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("We can then extract the private key encrypted under the temporary password which will be\n{0}", _Indent);
				_Output.Write ("passed to the application we are to configure.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("MailGet"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("More information on creating scripts for the shells supported on various platforms can be \n{0}", _Indent);
				_Output.Write ("found in the <a=\"/UserGuide/Platform/\">Platforms section</a> of this guyide.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
