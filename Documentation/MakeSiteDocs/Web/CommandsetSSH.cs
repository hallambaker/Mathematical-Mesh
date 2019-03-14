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
		// WebSSH
		//
		public static void WebSSH(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/ssh.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/ssh.md" };
				obj._WebSSH(Examples);
				}
			}
		public void _WebSSH(CreateWeb Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
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
				_Output.Write ("Since SSH authentication is bidirectional, an SSH profile is used to manage two separate\n{0}", _Indent);
				_Output.Write ("sets of public keys.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>Client Authentication keys</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Public keypairs used to authenticate a client to a host. These are the keys whose\n{0}", _Indent);
				_Output.Write ("private components are stored in user local storage and whose public components \n{0}", _Indent);
				_Output.Write ("appear in generate the <tt>authorized_keys</tt> file.</dd>\n{0}", _Indent);
				_Output.Write ("<dt>Host Authentication keys</dt>\n{0}", _Indent);
				_Output.Write ("<dd>Public keypairs used to authenticate a host to a client. These are keys whose\n{0}", _Indent);
				_Output.Write ("private components are stored in a system wide storage and whose public components\n{0}", _Indent);
				_Output.Write ("appear in the <tt>known_hosts</tt> file.</dd>\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating an SSH profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("SSH profiles are created using the <tt>meshman</tt> tool. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.SSHCreate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Key Registration\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.SSHPrivate);
				  ConsoleExample (Examples.SSHPublic);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Client Authentication keys\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `ssh auth` command updates mesh key entries in the `authorized_keys`\n{0}", _Indent);
				_Output.Write ("file using information from the specified mesh portal.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, if the `authorized_keys` file has an entry for Alice's Mesh profile\n{0}", _Indent);
				_Output.Write ("(`alice@example.com.mm--ssss`), the corresponding profile is fetched and the \n{0}", _Indent);
				_Output.Write ("corresponding SSH device public keys added:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.SSHClientAuth);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Host Authentication keys\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh add</tt> command adds host entries from the machine to the user's SSH profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.SSHAddHost);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.SSHShowKnown);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The <tt>ssh known</tt> command adds hosts from the user's ssh profile to their known_hosts\n{0}", _Indent);
				_Output.Write ("file on the machine.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.SSHAddKnown);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Additional Devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Whenever an SSH profile is created, a separate keypair is created for every device\n{0}", _Indent);
				_Output.Write ("connected to the profile. This mitigates the consequences of a device being lost\n{0}", _Indent);
				_Output.Write ("or stolen. The device key for the compromised device can be removed from the \n{0}", _Indent);
				_Output.Write ("profile without affecting any other device. Investigation of possibly unauthorized logins\n{0}", _Indent);
				_Output.Write ("can be focused on those from the compromised device alone.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.AppConnectSSH1);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.AppConnectSSH2);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SSHReference
		//
		public static void SSHReference(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/ssh.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/ssh.md" };
				obj._SSHReference(Examples);
				}
			}
		public void _SSHReference(CreateWeb Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_SSH;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _SSHCreate._DescribeCommand);
				 Describe(CommandSet, _SSHPrivate._DescribeCommand);
				 Describe(CommandSet, _SSHPublic._DescribeCommand);
				 Describe(CommandSet, _SSHAddHost._DescribeCommand);
				 Describe(CommandSet, _SSHMergeKnown._DescribeCommand);
				 Describe(CommandSet, _SSHAddClient._DescribeCommand);
				 Describe(CommandSet, _SSHKnown._DescribeCommand);
				 Describe(CommandSet, _SSHAuth._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
