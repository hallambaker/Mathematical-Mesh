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
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// WebContainer
		//
		public static void WebContainer(CreateExamples Examples) { /* XFile  */
				using var _Output = new StreamWriter("Guide/container.md");
			Examples._Output = _Output;
			Examples._WebContainer(Examples);
			}
		public void _WebContainer(CreateExamples Examples) {

				 MakeTitle ("container");
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container` command set contains commands that operate on DARE Containers.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Creating Containers\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Containers are created with either the {1} or \n{0}", _Indent, ToCommand("container create"));
				_Output.Write ("{1}. Both commands create a container with the \n{0}", _Indent, ToCommand("container archive"));
				_Output.Write ("specified cryptographic enhancements. The {1}\n{0}", _Indent, ToCommand("container archive"));
				_Output.Write ("command additionally adds the specified file(s) to the container to create \n{0}", _Indent);
				_Output.Write ("a container archive.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerCreate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*catalog* *spool* *archive* *log*\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The cryptographic enhancements specified when a container is created have the \n{0}", _Indent);
				_Output.Write ("same format and function as for DARE Messages but their scope is the container\n{0}", _Indent);
				_Output.Write ("as a whole.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Alice creates an encrypted container readable by anyone who is a\n{0}", _Indent);
				_Output.Write ("member of the group {1};\n{0}", _Indent, GroupAccount);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerCreateEncrypt);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since it is rarely desirable to sign every entry in a container, signatures\n{0}", _Indent);
				_Output.Write ("are typically added to a container when entries or indexes are added. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} creates a new container, adds the\n{0}", _Indent, ToCommand("container archive"));
				_Output.Write ("specified file(s) as entries and appends an index as the final record:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchive);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("An archive may be signed and encrypted:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchiveEnhance);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The signature on a signed archive is calculated over the final apex of the \n{0}", _Indent);
				_Output.Write ("Merkel tree. Thus a single signature verification may be used to validate\n{0}", _Indent);
				_Output.Write ("any or all entries in the container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Reading Containers\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command verifies the contents of a container: \n{0}", _Indent, ToCommand("container verify"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchiveVerify);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The verification performed depends on the type of authentication applied to the\n{0}", _Indent);
				_Output.Write ("container and whether the verifier can provide the necessary authentication or\n{0}", _Indent);
				_Output.Write ("decryption keys.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container extract"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("One or more container entries may be extracted to a file using the  \n{0}", _Indent);
				_Output.Write ("{1} command. If the container is an archive, all\n{0}", _Indent, ToCommand("container extract"));
				_Output.Write ("the files are extracted by default:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchiveExtractAll);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alternatively, the `/file` option may be used to extract a specific file:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchiveExtractFile);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Writing to Containers\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds an entry to a container:\n{0}", _Indent, ToCommand("container append"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerAppend);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If no security enhancements are specified, the default enhancements specified \n{0}", _Indent);
				_Output.Write ("in the index entry are applied.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container delete"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds an entry to a container\n{0}", _Indent, ToCommand("container delete"));
				_Output.Write ("marking an entry as deleted:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Marking an entry for deletion does not cause the entry itself to be modified.\n{0}", _Indent);
				_Output.Write ("The entry is merely marked as having been deleted. To erase the entry contents,\n{0}", _Indent);
				_Output.Write ("it is necessary to either make a copy of the container using the `/purge`\n{0}", _Indent);
				_Output.Write ("option to reclaim the space used by deleted entries or to use the \n{0}", _Indent);
				_Output.Write ("`/erase` or `overwrite` options.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds an index entry to the end of\n{0}", _Indent, ToCommand("container index"));
				_Output.Write ("container:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerIndex);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The index entry may be complete, providing an index of the entire file \n{0}", _Indent);
				_Output.Write ("or incremental, only indexing the items added since the last index was created.\n{0}", _Indent);
				_Output.Write ("Indexing containers allows the contents to be efficiently retrieved.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Copying Containers\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command makes a copy of a container with\n{0}", _Indent, ToCommand("container copy"));
				_Output.Write ("the specified filtering rules. By default, no changes are made except to \n{0}", _Indent);
				_Output.Write ("collect tree index fields dispersed throughout the container with an index \n{0}", _Indent);
				_Output.Write ("at the end:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchiveCopy);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The copy command may be used to encrypt or decrypt the container contents during \n{0}", _Indent);
				_Output.Write ("the copy:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchiveCopyDecrypt);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The copy command may also be used to reclaim space used by deleted items:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (ShellSequence.ContainerArchiveCopyPurge);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ContainerReference
		//
		public static void ContainerReference(CreateExamples Examples) { /* XFile  */
				using var _Output = new StreamWriter("Reference/container.md");
			Examples._Output = _Output;
			Examples._ContainerReference(Examples);
			}
		public void _ContainerReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Container;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerCreate._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container create` command creates a container with the specified cryptographic\n{0}", _Indent);
				_Output.Write ("enhancements.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerCreate);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerArchive._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container archive` command creates a container with the specified cryptographic\n{0}", _Indent);
				_Output.Write ("enhancements and adds the spefied file(s).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerArchive);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerVerify._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container verify` command verifies the authentication data of the specified \n{0}", _Indent);
				_Output.Write ("container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerArchiveVerify);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerExtract._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container extract` command extracts the specified container entries and writes them\n{0}", _Indent);
				_Output.Write ("to files.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerArchiveExtractAll);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerAppend._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container append` command appends the specified file to the container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerAppend);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerDelete._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container delete` command marks the specified file entry as deleted in the\n{0}", _Indent);
				_Output.Write ("container but does not erase the data from the file.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerIndex._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container index` command appends an index record to the end of the container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerIndex);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerCopy._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container copy` command copies a container applying the specified filtering \n{0}", _Indent);
				_Output.Write ("and indexing criteria.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (ShellSequence.ContainerArchiveCopy);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
