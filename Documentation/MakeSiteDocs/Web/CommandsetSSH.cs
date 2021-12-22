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
			_Output.Write ("* Client Authentication keys\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* Host Authentication keys\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Client Authentication public keypairs are used to authenticate a client to a host. \n{0}", _Indent);
			_Output.Write ("These are the keys whose private components are stored in user local storage and \n{0}", _Indent);
			_Output.Write ("whose public components appear in generate the <tt>authorized_keys</tt> file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Host Authentication keypairs are used to authenticate a host to a client. These are \n{0}", _Indent);
			_Output.Write ("keys whose private components are stored in a system wide storage and whose public \n{0}", _Indent);
			_Output.Write ("components appear in the <tt>known_hosts</tt> file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating an SSH profile\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds an SSH profile named `ssh` to a Mesh account:\n{0}", _Indent, ToCommand("ssh create"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since the command creates a new application catalog entry, the command must be given to \n{0}", _Indent);
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
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Host Configuration\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Host configuration is not currently supported but is an obvious feature to add once\n{0}", _Indent);
			_Output.Write ("support is introduced for SSH certificates.\n{0}", _Indent);
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
			_Output.Write ("{1} and {2}  commands.\n{0}", _Indent, ToCommand("ssh add client"), ToCommand("ssh import client"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} adds key parameters specified on the command line.\n{0}", _Indent, ToCommand("ssh add client"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHAddClient);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} adds key parameters specified in a separate file. A \n{0}", _Indent, ToCommand("ssh import client"));
			_Output.Write ("variety of SSH key formats is supported by means of options:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHImport);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("SSH client keys mayt be fetched using the {1} command:\n{0}", _Indent, ToCommand("ssh get"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The list of authorized clients may be returned in various formats using the {1}  command\n{0}", _Indent, ToCommand("ssh list"));
			_Output.Write ("with the /client option.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A client key may be deleted using the  {1}  command:\n{0}", _Indent, ToCommand("ssh delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Finally, the {1} command performs a two way merge of keys from\n{0}", _Indent, ToCommand("ssh merge client"));
			_Output.Write ("a authorized clients file and the ssh catalog entries:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHMergeClients);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Host Key Management\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command adds specific host entries to the user's SSH profile.\n{0}", _Indent, ToCommand("ssh add host"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHAddHost);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The list of known hosts may be returned in various formats using the {1}  command\n{0}", _Indent, ToCommand("ssh list"));
			_Output.Write ("with the /host option.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHListHosts);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Finally, the {1} command performs a two way merge of keys from\n{0}", _Indent, ToCommand("ssh merge host"));
			_Output.Write ("a known hosts file and the ssh catalog entries:\n{0}", _Indent);
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
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh add client
			 Describe(CommandSet, _SSHAddClient._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The add client command adds a client entry to the catalog from a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHAddClient);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh add host
			 Describe(CommandSet, _SSHAddHost._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The add client command adds a client entry to the catalog from a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHAddHost);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh create
			 Describe(CommandSet, _SSHCreate._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH create command creates an SSH application store.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh delete
			 Describe(CommandSet, _SSHDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH delete command deletes a client or host.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHDelete);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh import
			 Describe(CommandSet, _SSHImport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH import command imports data from a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHImport);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh get
			 Describe(CommandSet, _SSHGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH get command describes a client or host entry.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh list
			 Describe(CommandSet, _SSHList._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH get command lists the client and/or host entries.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If the /client option is specified, only client entries are shown. If the /host option is\n{0}", _Indent);
			_Output.Write ("specified, only host entries are shown. In all other cases, both types of entry are shown.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh merge client
			 Describe(CommandSet, _SSHMergeClients._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The merge client command performs a two-way merge of data in the specified authorized \n{0}", _Indent);
			_Output.Write ("clients file with the SSH catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHMergeClients);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh merge host
			 Describe(CommandSet, _SSHMergeHosts._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The merge client command performs a two-way merge of data in the specified known \n{0}", _Indent);
			_Output.Write ("hosts file with the SSH catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHMergeHosts);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh private
			 Describe(CommandSet, _SSHPrivate._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ssh private command exports the private key data of the device on which it is \n{0}", _Indent);
			_Output.Write ("executed in a range of formats.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHPrivate);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh public 
			 Describe(CommandSet, _SSHPublic._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ssh private command exports the public key data of the device on which it is \n{0}", _Indent);
			_Output.Write ("executed in a range of formats.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
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
