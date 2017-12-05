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
		// UserGuideSSH
		//
		public static void UserGuideSSH (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("Apps/ssh.md")) {
				var _Indent = ""; 
				_Output.Write ("<title>SSH\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Mesh/SSH\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4>Automating best practices for SSH credential management\n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("SSH is one of the most successful applications that provides strong cryptographic\n{0}", _Indent);
				_Output.Write ("protections today. It is certainly the first and so far only cryptographic application\n{0}", _Indent);
				_Output.Write ("to become so ubiquitous as to replace its insecure predecessor (telnet). \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Despite this success, SSH can be tricky to deploy and not through any fault of the \n{0}", _Indent);
				_Output.Write ("design of the application. Configuring SSH access to a machine that you are accessing\n{0}", _Indent);
				_Output.Write ("via SSH is an inherently tricky task: Any error in the configuration may render the \n{0}", _Indent);
				_Output.Write ("machine unavailable.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Another major weakness in the use of SSH is that following best practices for key\n{0}", _Indent);
				_Output.Write ("management such as using a different authentication key on each client device is\n{0}", _Indent);
				_Output.Write ("tedious at best. Most worrying of all is the fact that much of the advice given on\n{0}", _Indent);
				_Output.Write ("'how to configure SSH' is written from the perspective of <i>how to get SSH to work<i>\n{0}", _Indent);
				_Output.Write ("rather than <i>how to make an SSH configuration secure<i>.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Most people who use SSH reguilarly have developed a set of scripts to perform routine\n{0}", _Indent);
				_Output.Write ("administrative tasks. But while writing a script is a trivial task, debugging and \n{0}", _Indent);
				_Output.Write ("checking for security vulnerabilities is certainly not.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Transferring configuration and administration tasks to the Mesh provides an approach\n{0}", _Indent);
				_Output.Write ("that is considerably more robust than a shell script is likely to provide and is \n{0}", _Indent);
				_Output.Write ("far more likely to attract the third party review necessary to build confidence in\n{0}", _Indent);
				_Output.Write ("its security.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Managing SSH Configuration using the Mesh.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("SSH profiles are created using the <tt>meshman</tt> tool. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("SSHCreate"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Whenever an SSH profile is created, a separate keypair is created for every device\n{0}", _Indent);
				_Output.Write ("connected to the profile. This mitigates the consequences of a device being lost\n{0}", _Indent);
				_Output.Write ("or stolen. The device key for the compromised device can be removed from the \n{0}", _Indent);
				_Output.Write ("profile without affecting any other device. Investigation of possibly unauthorized logins\n{0}", _Indent);
				_Output.Write ("can be focused on those from the compromised device alone.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<b>Limitation</b>: At present, adding an SSH application profile to a personal profile \n{0}", _Indent);
				_Output.Write ("causes an SSH device entry to be created for every device connected to the profile. \n{0}", _Indent);
				_Output.Write ("Implementation of device groups in the meshman tool would allow this limitation to\n{0}", _Indent);
				_Output.Write ("be lifted.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, ToDo("AddDevice", "In SSH, extend meshman to allow devices to be added and removed from the SSH profile independently of the personal."));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since SSH authentication is bidirectional, an SSH profile is used to manage two separate\n{0}", _Indent);
				_Output.Write ("sets of public keys.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>Client Authentication keys\n{0}", _Indent);
				_Output.Write ("<dd>Public keypairs used to authenticate a client to a host. These are the keys whose\n{0}", _Indent);
				_Output.Write ("private components are stored in user local storage and whose public components \n{0}", _Indent);
				_Output.Write ("appear in generate the <tt>authorized_keys</tt> file.\n{0}", _Indent);
				_Output.Write ("<dt>Host Authentication keys\n{0}", _Indent);
				_Output.Write ("<dd>Public keypairs used to authenticate a host to a client. These are keys whose\n{0}", _Indent);
				_Output.Write ("private components are stored in a system wide storage and whose public components\n{0}", _Indent);
				_Output.Write ("appear in the <tt>known_hosts</tt> file.\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh sync</tt> command causes the latest version of the user's SSH application profile\n{0}", _Indent);
				_Output.Write ("to be fetched from the portal and used to update the user's <tt>authorized_keys</tt> \n{0}", _Indent);
				_Output.Write ("and <tt>known_hosts</tt> files.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("SSHSync"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh sync</tt> command allows the user to connect from any device connected to\n{0}", _Indent);
				_Output.Write ("their personal profile to any other device connected to their personal profile that\n{0}", _Indent);
				_Output.Write ("supports SSH.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("While these capabilities are sufficient for many users, they do not meet the needs of\n{0}", _Indent);
				_Output.Write ("a developer or administrator who needs to access machines that they either cannot\n{0}", _Indent);
				_Output.Write ("connect or do not want to connect to their personal profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Host Authentication keys\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh known</tt> command adds hosts from the user's ssh profile to their known_hosts\n{0}", _Indent);
				_Output.Write ("file on the machine.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("SSHKnown"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh add</tt> command adds host entries from the machine to the user's SSH profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("SSHKnownAdd"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h1>Client Authentication keys\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh auth</tt> command updates mesh key entries in the <tt>authorized_keys</tt>\n{0}", _Indent);
				_Output.Write ("file using information from the specified mesh portal.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, if the <tt>authorized_keys</tt> file has an entry for Alice's Mesh profile\n{0}", _Indent);
				_Output.Write ("(<tt>alice@example.com.mm--ssss</tt>), the corresponding profile is fetched and the \n{0}", _Indent);
				_Output.Write ("corresponding SSH device public keys added:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS the initial SSH file\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("SSHAuth"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS the expanded SSH file\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh public</tt> command writes the SSH public device key for the current device to a file.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("SSHPublic"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh private</tt> command writes the SSH device private key for the current device to a file\n{0}", _Indent);
				_Output.Write ("in various private key file formats.\n{0}", _Indent);
				_Output.Write ("When using this command to script configuration of SSH clients, the private key SHOULD always\n{0}", _Indent);
				_Output.Write ("be encrypted under a suitably secure password. The <tt>keygen</tt> command may be used\n{0}", _Indent);
				_Output.Write ("to generate a strong temporary password for this purpose.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("SSHPrivate"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
