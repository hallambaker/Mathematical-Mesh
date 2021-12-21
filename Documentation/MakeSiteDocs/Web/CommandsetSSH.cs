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
	// WebSSH
	//
	public static void WebSSH(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/ssh.md");
		Examples._Output = _Output;
		Examples._WebSSH(Examples);
		}
	public void _WebSSH(CreateExamples Examples) {

			 MakeTitle ("SSH");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH command set contains commands that \n{0}", _Indent);
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
			_Output.Write ("The {1} command adds an SSH profile named `ssh` to a Mesh account:\n{0}", _Indent, ToCommand("ssh create"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since the command creates a new application catalog, the command must be given to \n{0}", _Indent);
			_Output.Write ("an administration device.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Client Configuration\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Adding an SSH profile causes a public keypair to be created for use with SSH. To make use \n{0}", _Indent);
			_Output.Write ("of this keypair for device authentication with legacy applications typically requires the\n{0}", _Indent);
			_Output.Write ("public and/or private keys to be extracted in a format supported by the application.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command extracts the private key required top configure\n{0}", _Indent, ToCommand("ssh private"));
			_Output.Write ("an SSH client:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHPrivate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command extracts the public key required top configure\n{0}", _Indent, ToCommand("ssh public"));
			_Output.Write ("an SSH client:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHPublic);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If a script is being used to automate this process, the best practice is for the\n{0}", _Indent);
			_Output.Write ("script to first generate a random nonce and request that the private key file\n{0}", _Indent);
			_Output.Write ("be extracted encrypted under the nonce which can be discarded after the key is\n{0}", _Indent);
			_Output.Write ("successfully installed. [Not currently supported.]\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Configuring authentication entries on hosts and clients\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command is run on a host to update mesh key entries \n{0}", _Indent, ToCommand("ssh merge client"));
			_Output.Write ("in the `authorized_keys` file using information from the specified mesh portal.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, if the `authorized_keys` file has an entry for Alice's Mesh profile\n{0}", _Indent);
			_Output.Write ("(`alice@example.com.mm--ssss`), the corresponding profile is fetched and the \n{0}", _Indent);
			_Output.Write ("corresponding SSH device public keys added:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHMergeClients);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command reads the `known_hosts` file on a client machine and adds\n{0}", _Indent, ToCommand("ssh merge host"));
			_Output.Write ("the listed hosts to the user's ssh catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHMergeHosts);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Client Key management\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("SSH keys belonging to the user that are not part of the Mesh profile may be added using the \n{0}", _Indent);
			_Output.Write ("{1}  command.\n{0}", _Indent, ToCommand("ssh import"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHImport);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHAddClient);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The list of known clients may be returned in various formats using the {1}  command.\n{0}", _Indent, ToCommand("ssh show client"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHList);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHDelete);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHMergeClients);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Host Key Management\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command adds specific host entries to the user's SSH profile.\n{0}", _Indent, ToCommand("ssh add host"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHAddHost);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The current list of known hosts in the SSH catalog is returned by the {1} \n{0}", _Indent, ToCommand("ssh show known"));
			_Output.Write ("command.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHListHosts);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHMergeHosts);
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
			_Output.Write ("The {1}  command is used *from an administration device* to \n{0}", _Indent, ToCommand("device auth /ssh"));
			_Output.Write ("enable use of ssh on the machine:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectSSHAuth );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Once the device has been authorized, the client machine can start using SSH immediately:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHAuthProof);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SSHReference
	//
	public static void SSHReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/ssh.md");
		Examples._Output = _Output;
		Examples._SSHReference(Examples);
		}
	public void _SSHReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_SSH;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh add client
			 Describe(CommandSet, _SSHAddClient._DescribeCommand);
			  ConsoleReference (Apps.SSHAddClient);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh add host
			 Describe(CommandSet, _SSHAddHost._DescribeCommand);
			  ConsoleReference (Apps.SSHAddHost);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh create
			 Describe(CommandSet, _SSHCreate._DescribeCommand);
			  ConsoleReference (Apps.SSHCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh delete
			 Describe(CommandSet, _SSHDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHDelete);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh import
			 Describe(CommandSet, _SSHImport._DescribeCommand);
			  ConsoleReference (Apps.SSHImport);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh get
			 Describe(CommandSet, _SSHGet._DescribeCommand);
			  ConsoleReference (Apps.SSHGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh list
			 Describe(CommandSet, _SSHList._DescribeCommand);
			  ConsoleReference (Apps.SSHList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh merge client
			 Describe(CommandSet, _SSHMergeClients._DescribeCommand);
			  ConsoleReference (Apps.SSHMergeClients);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh merge host
			 Describe(CommandSet, _SSHMergeHosts._DescribeCommand);
			  ConsoleReference (Apps.SSHMergeHosts);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh private
			 Describe(CommandSet, _SSHPrivate._DescribeCommand);
			  ConsoleReference (Apps.SSHPrivate);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh public 
			 Describe(CommandSet, _SSHPublic._DescribeCommand);
			  ConsoleReference (Apps.SSHPublic);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
