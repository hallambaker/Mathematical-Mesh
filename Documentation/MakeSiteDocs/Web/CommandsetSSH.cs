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
			_Output.Write ("The {1} command extracts the public key required top configure\n{0}", _Indent, ToCommand("ssh public"));
			_Output.Write ("an SSH client:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHPublic);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command extracts the private key required top configure\n{0}", _Indent, ToCommand("ssh private"));
			_Output.Write ("an SSH client:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHPrivate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If a script is being used to automate this process, the best practice is for the\n{0}", _Indent);
			_Output.Write ("script to first generate a random nonce and request that the private key file\n{0}", _Indent);
			_Output.Write ("be extracted encrypted under the nonce which can be discarded after the key is\n{0}", _Indent);
			_Output.Write ("successfully installed. [Not currently supported.]\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command with the '/client' option lists the authorized \n{0}", _Indent, ToCommand("ssh list"));
			_Output.Write ("clients keys in the profile. This may be used to generate the `authorized_keys` file \n{0}", _Indent);
			_Output.Write ("by specifying the SSH file format used by the particular SSH application in use.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Individual client entries may be added using the {1} command\n{0}", _Indent, ToCommand("ssh client"));
			_Output.Write ("which imports a client entry from a file in the specified format.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("[Not yet implemented, assume file format from extension/well known names.]\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHImport);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This command may be used to add SSH client public keys to the profile without adding\n{0}", _Indent);
			_Output.Write ("the private key. This provides a means of adding a legacy key that is not under Mesh control\n{0}", _Indent);
			_Output.Write ("to a Mesh profile. Attempts to access the public key work as normal:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Attempts to access the private key fail:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHGetPrivate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Client configurations may be deleted using the {1} command\n{0}", _Indent, ToCommand("ssh delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHDeleteList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Host Configuration\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Host configuration is not currently supported but is an obvious feature to add once\n{0}", _Indent);
			_Output.Write ("support is introduced for SSH certificates.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Managing Host Credentials\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command is used to add known hosts to the Mesh credential \n{0}", _Indent, ToCommand("ssh host"));
			_Output.Write ("catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHAddHost);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command with the '/host' option lists the known host keys \n{0}", _Indent, ToCommand("ssh list"));
			_Output.Write ("in the profile. This information is stored in the credential catalog and may also be \n{0}", _Indent);
			_Output.Write ("retrieved through the password commands.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHListHosts);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command returns the SSH parameters for a particular known host:\n{0}", _Indent, ToCommand("ssh known"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Apps.SSHKnown);
			_Output.Write ("\n{0}", _Indent);
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
			// ------------------ ssh client
			 Describe(CommandSet, _SSHClient._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ssh client command adds a client entry to the application catalog from a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHImport);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh create
			 Describe(CommandSet, _SSHCreate._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ssh create command creates a new SSH client entry.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh delete
			 Describe(CommandSet, _SSHDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ssh delete command deletes a client or host.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh get
			 Describe(CommandSet, _SSHGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ssh get command describes a client or host entry.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh host
			 Describe(CommandSet, _SSHHost._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ssh host command adds a host entry to the credential catalog from a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHAddHost);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ssh known
			 Describe(CommandSet, _SSHKnown._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH known command returns the SSH authentication data for the specified host\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Apps.SSHKnown);
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
			  ConsoleReference (Apps.SSHList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
