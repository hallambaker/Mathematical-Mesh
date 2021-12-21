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
	// WebGroup
	//
	public static void WebGroup(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/group.md");
		Examples._Output = _Output;
		Examples._WebGroup(Examples);
		}
	public void _WebGroup(CreateExamples Examples) {

			 MakeTitle ("group");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The group command set is used to manage recryption groups\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("In traditional public key encryption, the public key is used to encrypt data\n{0}", _Indent);
			_Output.Write ("and the private key is used to decrypt. In the proxy re-encryption scheme used \n{0}", _Indent);
			_Output.Write ("in the Mesh, the public key is used to encrypt data in the exact same way as \n{0}", _Indent);
			_Output.Write ("for two key cryptography but the decryption key is split into two parts. One \n{0}", _Indent);
			_Output.Write ("half of which is held by the recipient and the other half of which is sent \n{0}", _Indent);
			_Output.Write ("to a recryption service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Decrypting encrypted data requires the use of both halves of the key. The recryption\n{0}", _Indent);
			_Output.Write ("service cannot decrypt data because it does not have access to the recipient's half\n{0}", _Indent);
			_Output.Write ("of the decryption key and the recipient can't decrypt the data unless the recryption\n{0}", _Indent);
			_Output.Write ("service performs its half of the work and returns the result to the recipient.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This approach has important benefits:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* Data cannot be decrypted without the decryption key held by the recipient, thus\n{0}", _Indent);
			_Output.Write ("encryption end-to-end. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* Even a total breach of the recryption service does not result in disclosure of\n{0}", _Indent);
			_Output.Write ("the data unless at least one recipient decryption key is also compromised.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* Recipients may be added to a recryption group at any time and immediately gain access\n{0}", _Indent);
			_Output.Write ("to all data previously encrypted to the group.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* If a recipient is removed from a recryption group, the recyption service can\n{0}", _Indent);
			_Output.Write ("deny further access to the data encrypted under that group by refusing recryption \n{0}", _Indent);
			_Output.Write ("requests from that recipient.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* All access to encrypted data must be mediated through the recryption service.\n{0}", _Indent);
			_Output.Write ("The recryption service may therefore enforce audit and accounting controls, detect\n{0}", _Indent);
			_Output.Write ("and prevent suspicious behavior.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("From the user's point of view, management of recryption groups is essentially the \n{0}", _Indent);
			_Output.Write ("same as management of groups in traditional access control. The principal difference\n{0}", _Indent);
			_Output.Write ("being that there is no cryptographically enforced means of denying access to a \n{0}", _Indent);
			_Output.Write ("specific group of users as is provided in traditional Access Control List schemes.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To implement access restrictions of the form 'allow access to a file to every member\n{0}", _Indent);
			_Output.Write ("of the red team who is not a member of the blue team', it would be necessary to create \n{0}", _Indent);
			_Output.Write ("and maintain a 'red not blue' group. Fortunately, the need for access control \n{0}", _Indent);
			_Output.Write ("restrictions of this form do not appear to be frequently realized in practice.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating a Recryption Group\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Recryption groups are created using the {1} command:\n{0}", _Indent, ToCommand("group create"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This command creates the group {1}. Since Alice created the\n{0}", _Indent, GroupAccount);
			_Output.Write ("account she is the administrator.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("At this point, the group has no members. Bob can encrypt a file under the group\n{0}", _Indent);
			_Output.Write ("public key but he is unable to read it:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupEncrypt);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Even though Alice is the group administrator, she cannot decrypt the file by default:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupDecryptAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice adds herself to the group, now she can decrypt:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupAddAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding users\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command is used to add users to the group:\n{0}", _Indent, ToCommand("group add"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice adds Bob as a member of the group:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupAddBob);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob can now decrypt the file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupDecryptBobSuccess);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Reporting users\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command returns a list of group members:\n{0}", _Indent, ToCommand("group list"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The group currently has one administrator and one member.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command returns information about a particular member.\n{0}", _Indent, ToCommand("group get"));
			_Output.Write ("If the service hosting the key service tracks key operations, this might report the\n{0}", _Indent);
			_Output.Write ("number of documents a user has viewed.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Deleting users\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Users may be removed from a recryption group using the {1} command:\n{0}", _Indent, ToCommand("group delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupDeleteBob);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob is no longer a member of the group and his decryption request now fails:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Group.GroupDecryptBobRevoked);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// GroupReference
	//
	public static void GroupReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/group.md");
		Examples._Output = _Output;
		Examples._GroupReference(Examples);
		}
	public void _GroupReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Group;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe( CommandSet);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ group add
			 Describe( CommandSet, _GroupAdd._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `group add` command adds a user to a group.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first required parameter specifies the name of the group, the second required parameter \n{0}", _Indent);
			_Output.Write ("specifies the name of the user to be added.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Group.GroupAddBob);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ group create
			 Describe( CommandSet, _GroupCreate._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `group create` command creates a group.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The parameters for group creation are the same as for account creation. This allows a group\n{0}", _Indent);
			_Output.Write ("to be used to share a calendar or password catalog etc.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Group.GroupCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ group delete
			 Describe( CommandSet, _GroupDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `group reject` command deletes a user from a group account.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first required parameter specifies the name of the group, the second required parameter \n{0}", _Indent);
			_Output.Write ("specifies the name of the user to be removed.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To delete the group account itself, the 'account delete' command is required.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Group.GroupDeleteBob);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ group get
			 Describe( CommandSet, _GroupGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `group get` command returns details of the sepcified group member.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first required parameter specifies the name of the group, the second required parameter \n{0}", _Indent);
			_Output.Write ("specifies the name of the user whose information is requested.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Group.GroupGet);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ group list
			 Describe( CommandSet, _GroupList._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `group reject` command lists the names of the users in the specified group.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first parameter specifies the name of the group.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleReference (Group.GroupList);
			_Output.Write ("\n{0}", _Indent);
				}
		}
