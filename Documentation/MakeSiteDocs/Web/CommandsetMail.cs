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
	// WebMail
	//
	public static void WebMail(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/mail.md");
		Examples._Output = _Output;
		Examples._WebMail(Examples);
		}
	public void _WebMail(CreateExamples Examples) {

			 MakeTitle ("mail");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `mail` command set contains commands used to manage Internet mail \n{0}", _Indent);
			_Output.Write ("application profiles and to create and manage credentials for the \n{0}", _Indent);
			_Output.Write ("OpenPGP and S/MIME security enhancements for Internet mail.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The current commands represent a draft designed to demonstrate key management\n{0}", _Indent);
			_Output.Write ("functions that are related to Mesh functionality. Of course a full feature key manager\n{0}", _Indent);
			_Output.Write ("would also create and submit CSRs for S/MIME, upload key blobs to OpenPGP\n{0}", _Indent);
			_Output.Write ("key servers, support key rotation, etc. etc.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Multiple mail profiles may be connected to a single Mesh profile to\n{0}", _Indent);
			_Output.Write ("allow access to multiple accounts.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating a mail profile\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A mail application profile is added to a Mesh profile using the \n{0}", _Indent);
			_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("mail add"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.Mail);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The client attempts to obtain the network configuration for the inbound and\n{0}", _Indent);
			_Output.Write ("outbound mail services using [SRV auto \n{0}", _Indent);
			_Output.Write ("configuration](https://tools.ietf.org/html/draft-daboo-srv-email-02).\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alternatively, the configuration may be given explicitly using the form \n{0}", _Indent);
			_Output.Write ("\\<domain\\>:\\<port\\>:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.MailImport);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail profile only contains the network configuration information. Access \n{0}", _Indent);
			_Output.Write ("credentials for the inbound and outbound mail services must be configured in the\n{0}", _Indent);
			_Output.Write ("email application(s) from which they are used or in the Mesh credential manager.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Account profiles may be updated to change the network configuration using the\n{0}", _Indent);
			_Output.Write ("{1} command:\n{0}", _Indent, ToCommand("mail add"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.MailUpdate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Specifying no values causes the SRV auto configuration configuration data to be \n{0}", _Indent);
			_Output.Write ("used replacing the values previously set.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating an OpenPGP Key Set\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("S/MIME and OpenPGP keys are created automatically whenever a mail profile is \n{0}", _Indent);
			_Output.Write ("created.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The private key may be extracted from the profile in a variety of interchange\n{0}", _Indent);
			_Output.Write ("formats to allow installation in an application:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.MailOpenpgpSignP12);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The public key may be exported likewise:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.MailOpenpgpSign);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating an S/MIME Key Set\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The private key may be extracted from the profile in a variety of interchange\n{0}", _Indent);
			_Output.Write ("formats to allow installation in a key service:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.MailSmimeSign);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The public key may be exported likewise:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.MailSmimeSign);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Various key formats are supported for export of public and private keys allowing\n{0}", _Indent);
			_Output.Write ("their use in a wide variety of applications.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// MailReference
	//
	public static void MailReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/mail.md");
		Examples._Output = _Output;
		Examples._MailReference(Examples);
		}
	public void _MailReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Mail;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ 
			 Describe(CommandSet, _MailAdd._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail add command adds a mail entry to the application catalog using parameters\n{0}", _Indent);
			_Output.Write ("specified on the command line.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.Mail);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ Mail
			 Describe(CommandSet, _MailGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail get command reports the specified mail configuration data.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.MailGet);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ Mail
			 Describe(CommandSet, MailImport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail add command adds a mail entry to the application catalog using parameters\n{0}", _Indent);
			_Output.Write ("specified in a configuration file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.MailImport);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ Mail
			 Describe(CommandSet, _MailList._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail list command lists all the mail configurations in the applications catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.MailList);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ Mail
			_Output.Write ("\n{0}", _Indent);
			 Describe( CommandSet, _OpenpgpSign._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail openpgp sign command returns the OpenPGP signature key in a variety of\n{0}", _Indent);
			_Output.Write ("formats.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.MailOpenpgpSign);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ Mail
			 Describe( CommandSet, _OpenpgpEncrypt._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail openpgp sign command returns the OpenPGP encrypt key in a variety of\n{0}", _Indent);
			_Output.Write ("formats.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.MailOpenpgpEncrypt);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ Mail
			 Describe(CommandSet, _SmimeSign._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail openpgp sign command returns the S/MIME signature key in a variety of\n{0}", _Indent);
			_Output.Write ("formats.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.MailSmimeSign);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ Mail
			 Describe(CommandSet, _SmimeEncrypt._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The mail openpgp sign command returns the S/MIME encrypt key in a variety of\n{0}", _Indent);
			_Output.Write ("formats.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.MailSmimeEncrypt);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
