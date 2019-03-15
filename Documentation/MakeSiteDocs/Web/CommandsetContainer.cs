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
		// WebContainer
		//
		public static void WebContainer(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/container.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/container.md" };
				obj._WebContainer(Examples);
				}
			}
		public void _WebContainer(Examples Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the `container Command Set\n{0}", _Indent);
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
				 ConsoleExample (Examples.ContainerCreate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*catalog* *spool* *archive* *log*\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The cryptographic enhancements specified when a container is created have the \n{0}", _Indent);
				_Output.Write ("same format and function as for DARE Messages but their scope is the container\n{0}", _Indent);
				_Output.Write ("as a whole.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Alice creates an encrypted container readable by anyone who is a\n{0}", _Indent);
				_Output.Write ("member of the group {1};\n{0}", _Indent, Examples.GroupAccount);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerCreateEncrypt);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since it is rarely desirable to sign every entry in a container, signatures\n{0}", _Indent);
				_Output.Write ("are typically added to a container when entries or indexes are added. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} creates a new container, adds the\n{0}", _Indent, ToCommand("container archive"));
				_Output.Write ("specified file(s) as entries and appends an index as the final record:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchive);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The archive may be signed and encrypted:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchiveEnhance);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Reading Containers\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container verify"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchiveVerify);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container extract"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchiveExtractAll);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchiveExtractFile);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Writing to Containers\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container append"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerAppend);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container delete"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container index"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerIndex);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Copying Containers\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} \n{0}", _Indent, ToCommand("container copy"));
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchiveCopy);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchiveCopyDecrypt);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleExample (Examples.ContainerArchiveCopyPurge);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ContainerReference
		//
		public static void ContainerReference(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/container.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/container.md" };
				obj._ContainerReference(Examples);
				}
			}
		public void _ContainerReference(Examples Examples) {

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
				 ConsoleReference (Examples.ContainerCreate);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerArchive._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container archive` command creates a container with the specified cryptographic\n{0}", _Indent);
				_Output.Write ("enhancements and adds the spefied file(s).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.ContainerArchive);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerVerify._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container verify` command verifies the authentication data of the specified \n{0}", _Indent);
				_Output.Write ("container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.ContainerArchiveVerify);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerExtract._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container extract` command extracts the specified container entries and writes them\n{0}", _Indent);
				_Output.Write ("to files.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.ContainerArchiveExtractAll);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerAppend._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container append` command appends the specified file to the container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.ContainerAppend);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerDelete._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container delete` command marks the specified file entry as deleted in the\n{0}", _Indent);
				_Output.Write ("container but does not erase the data from the file.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.ContainerDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerIndex._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container index` command appends an index record to the end of the container.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.ContainerIndex);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContainerCopy._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `container copy` command copies a container applying the specified filtering \n{0}", _Indent);
				_Output.Write ("and indexing criteria.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 ConsoleReference (Examples.ContainerArchiveCopy);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
