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
		// WebMail
		//
		public static void WebMail(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/mail.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/mail.md" };
			obj._WebMail(Examples);
			}
		public void _WebMail(CreateExamples Examples) {

				 MakeTitle ("mail");
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `mail` command set contains commands used to manage Internet mail \n{0}", _Indent);
				_Output.Write ("application profiles and to create and manage credentials for the \n{0}", _Indent);
				_Output.Write ("OpenPGP and S/MIME security enhancements for Internet mail.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Multiple mail profiles may be connected to a single Mesh profile to\n{0}", _Indent);
				_Output.Write ("allow access to multiple accounts.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating a mail profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A mail application profile is added to a Mesh profile using the \n{0}", _Indent);
				_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("mail add"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailAdd);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The client attempts to obtain the network configuration for the inbound and\n{0}", _Indent);
				_Output.Write ("outbound mail services using [SRV auto \n{0}", _Indent);
				_Output.Write ("configuration](https://tools.ietf.org/html/draft-daboo-srv-email-02).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alternatively, the configuration may be given explicitly using the form \n{0}", _Indent);
				_Output.Write ("\\<domain\\>:\\<port\\>:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailAddExplicit);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The mail profile only contains the network configuration information. Access \n{0}", _Indent);
				_Output.Write ("credentials for the inbound and outbound mail services must be configured in the\n{0}", _Indent);
				_Output.Write ("email application(s) from which they are used or in the Mesh credential manager.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Account profiles may be updated to change the network configuration using the\n{0}", _Indent);
				_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("mail add"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailUpdate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Specifying no values causes the SRV auto configuration configuration data to be \n{0}", _Indent);
				_Output.Write ("used replacing the values previously set.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating an OpenPGP Key Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("An OpenPGP public key pair for encryption and authentication may be added to the\n{0}", _Indent);
				_Output.Write ("profile when it is created or as a later update using the `/openpgp` option:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailUpdateOpenPGP);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The private key may be extracted from the profile in a variety of interchange\n{0}", _Indent);
				_Output.Write ("formats to allow installation in a key service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailOpenPGPPrivate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The public key may be exported likewise:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailOpenPGPPublic);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating an S/MIME Key Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("An S/MIME public key pair for encryption and authentication may be added to the\n{0}", _Indent);
				_Output.Write ("profile when it is created or as a later update using the `/smime` option:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailUpdateSMIME);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("By default, a self signed certificate is created.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1}  causes a certificate request to be sent to the\n{0}", _Indent, ToCommand("mail smime validate"));
				_Output.Write ("specified Certificate Authority service via ACME:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailSMIMECA);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Responding to the validation challenge requires an access credential for the \n{0}", _Indent);
				_Output.Write ("inbound email service to be specified.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The private key may be extracted from the profile in a variety of interchange\n{0}", _Indent);
				_Output.Write ("formats to allow installation in a key service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailSMIMEPrivate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The public key may be exported likewise:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (ShellMail.MailSMIMEPublic);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// MailReference
		//
		public static void MailReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/mail.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/mail.md" };
			obj._MailReference(Examples);
			}
		public void _MailReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Mail;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MailAdd._DescribeCommand);
				 Describe(CommandSet, _MailUpdate._DescribeCommand);
				 Describe(CommandSet, _SMIMEPrivate._DescribeCommand);
				 Describe(CommandSet, _SMIMEPublic._DescribeCommand);
				 Describe( CommandSet, _PGPPrivate._DescribeCommand);
				 Describe( CommandSet, _PGPPublic._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
