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
	// WebArchive
	//
	public static void WebArchive(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/archive.md");
		Examples._Output = _Output;
		Examples._WebArchive(Examples);
		}
	public void _WebArchive(CreateExamples Examples) {

			 MakeTitle ("archive");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("**Under development**: This command set is currently under development and many\n{0}", _Indent);
			_Output.Write ("features are documented but not yet implemented. Use with care!\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `archive` command set contains commands that encode, decode and verify \n{0}", _Indent);
			_Output.Write ("DARE envelopes and sequences.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Encoding, decoding and verifying individual files in a DARE envelope.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}, {2} and\n{0}", _Indent, ToCommand("dare encode"), ToCommand("dare decode"));
			_Output.Write ("{1} commands are used to encode files as DARE Messages,\n{0}", _Indent, ToCommand("dare verify"));
			_Output.Write ("decode and verify them respectively. If the '/encrypt' option is specified,\n{0}", _Indent);
			_Output.Write ("the contents are encrypted under the corresponding encryption key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (Account.ConsoleEncryptFile);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("By default, a content digest is calculated over the contents. This may be \n{0}", _Indent);
			_Output.Write ("suppressed using the `/nohash` flag.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The data contents may be encrypted and authenticated under a specified symmetric key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareSymmetric);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Specifying a directory instead of a file causes all the files in the directory to be \n{0}", _Indent);
			_Output.Write ("encoded:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareSub);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Files may also be signed using the user's Mesh signature key and/or encrypted for one\n{0}", _Indent);
			_Output.Write ("or more recipients. In this example, Alice creates a message intended for Bob.\n{0}", _Indent);
			_Output.Write ("Alice signs the message with her private signature key and encrypts it under Bob's\n{0}", _Indent);
			_Output.Write ("public encryption key.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareMesh);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("### Verifying a DARE message.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command is used to verify the signature and \n{0}", _Indent, ToCommand("dare verify"));
			_Output.Write ("digest values on a DARE Message without decoding the message body:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareVerifyDigest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The command to verify a signed message is identical:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareVerifySigned);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Messages that are encrypted and authenticated under a specified symmetric key \n{0}", _Indent);
			_Output.Write ("may be verified at the plaintext level if the key is known or the ciphertext \n{0}", _Indent);
			_Output.Write ("level otherwise.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareVerifySymmetric);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareVerifySymmetricUnknown);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("### Decoding a DARE message to a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command is used to decode and verify DARE Messages:\n{0}", _Indent, ToCommand("dare decode"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareDecodePlaintext);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To decode a message encrypted under a symmetric key, we must specify the key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareDecodeSymmetric);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If the message is encrypted under our private encryption key, the tool will locate\n{0}", _Indent);
			_Output.Write ("the necessary decryption key(s) automatically:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareDecodePrivate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating an EARL.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command is used to create an EARL:\n{0}", _Indent, ToCommand("dare earl"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareEarl);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A new secret is generated with the specified number of bits, this is then used\n{0}", _Indent);
			_Output.Write ("to generate the key identifier and encrypt the input file to a file with the\n{0}", _Indent);
			_Output.Write ("name of the key identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `/log` option causes the filename, encryption key and other details of\n{0}", _Indent);
			_Output.Write ("the transaction to be written to a DARE Sequence Log.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareEARLLog);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `/new` option causes the file to be encoded if and only if it has not \n{0}", _Indent);
			_Output.Write ("been processed already.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellDare.DareEARLLogNew);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Creating Sequences\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Sequences are created with the {1},\n{0}", _Indent, ToCommand("dare create"));
			_Output.Write ("{1} or {2} commands. \n{0}", _Indent, ToCommand("dare archive"), ToCommand("dare log"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1} creates a sequence that is specialized\n{0}", _Indent, ToCommand("dare archive"));
			_Output.Write ("for use as a DARE archive while {1} creates a \n{0}", _Indent, ToCommand("dare log"));
			_Output.Write ("sequence that is specialized for use as an event log. \n{0}", _Indent);
			_Output.Write ("{1} creates an unspecialized sequence.\n{0}", _Indent, ToCommand("dare sequence"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A sequence may have a security policy specified when it is created. If\n{0}", _Indent);
			_Output.Write ("no encryption or signature policy is specified on creation, the entries\n{0}", _Indent);
			_Output.Write ("appended to the sequence will not be encrypted or signed \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The cryptographic enhancements specified when a sequence is created have the \n{0}", _Indent);
			_Output.Write ("same format and function as for DARE Messages but their scope is the sequence\n{0}", _Indent);
			_Output.Write ("as a whole.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, Alice creates an encrypted sequence readable by anyone who is a\n{0}", _Indent);
			_Output.Write ("member of the group {1};\n{0}", _Indent, GroupAccount);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceCreateEncrypt);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since it is rarely desirable to sign every entry in a sequence, signatures\n{0}", _Indent);
			_Output.Write ("are typically added to a sequence when entries or indexes are added. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("### Archives\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} creates a new archive, adds the\n{0}", _Indent, ToCommand("dare archive"));
			_Output.Write ("specified file(s) as entries and appends an index as the final record:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchive);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("An archive may be signed and encrypted:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchiveEnhance);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The signature on a signed archive is calculated over the final apex of the \n{0}", _Indent);
			_Output.Write ("Merkel tree. Thus a single signature verification may be used to validate\n{0}", _Indent);
			_Output.Write ("any or all entries in the sequence.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Reading Sequences\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command used to verify enveloped is also used to\n{0}", _Indent, ToCommand("dare verify"));
			_Output.Write ("verify the contents of a sequence: \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchiveVerify);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The verification performed depends on the type of authentication applied to the\n{0}", _Indent);
			_Output.Write ("sequence and whether the verifier can provide the necessary authentication or\n{0}", _Indent);
			_Output.Write ("decryption keys.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("One or more sequence entries may be extracted to a file using the  \n{0}", _Indent);
			_Output.Write ("{1} command. If the sequence is an archive, all\n{0}", _Indent, ToCommand("dare extract"));
			_Output.Write ("the files are extracted by default:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchiveExtractAll);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alternatively, the `/file` option may be used to extract a specific file:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchiveExtractFile);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Writing to Sequences \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds an entry to a sequence:\n{0}", _Indent, ToCommand("dare append"));
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceAppend);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If no security enhancements are specified, the default enhancements specified \n{0}", _Indent);
			_Output.Write ("in the index entry are applied.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds an entry to a sequence\n{0}", _Indent, ToCommand("dare delete"));
			_Output.Write ("marking an entry as deleted:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Marking an entry for deletion does not cause the entry itself to be modified.\n{0}", _Indent);
			_Output.Write ("The entry is merely marked as having been deleted. To erase the entry contents,\n{0}", _Indent);
			_Output.Write ("it is necessary to either make a copy of the sequence using the `/purge`\n{0}", _Indent);
			_Output.Write ("option to reclaim the space used by deleted entries or to use the \n{0}", _Indent);
			_Output.Write ("`/erase` or `overwrite` options.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds an index entry to the end of\n{0}", _Indent, ToCommand("dare index"));
			_Output.Write ("sequence:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceIndex);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The index entry may be complete, providing an index of the entire file \n{0}", _Indent);
			_Output.Write ("or incremental, only indexing the items added since the last index was created.\n{0}", _Indent);
			_Output.Write ("Indexing sequences allows the contents to be efficiently retrieved.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Copying and Purging Sequences\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command makes a copy of a sequence with\n{0}", _Indent, ToCommand("dare copy"));
			_Output.Write ("the specified filtering rules. By default, no changes are made except to \n{0}", _Indent);
			_Output.Write ("collect tree index fields dispersed throughout the sequence with an index \n{0}", _Indent);
			_Output.Write ("at the end:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchiveCopy);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command may be used to encrypt or decrypt the sequence contents during \n{0}", _Indent, ToCommand("dare copy"));
			_Output.Write ("the copy:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchiveCopyDecrypt);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command may also be used to reclaim space used by deleted items\n{0}", _Indent, ToCommand("dare copy"));
			_Output.Write ("by specifying the '/purge' option:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleExample (ShellSequence.SequenceArchiveCopyPurge);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that it is not possible to purge a file in place writing the output to the input file\n{0}", _Indent);
			_Output.Write ("using this command.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchiveReference
	//
	public static void ArchiveReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/archive.md");
		Examples._Output = _Output;
		Examples._ArchiveReference(Examples);
		}
	public void _ArchiveReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Archive;
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("**Under development**: This command set is currently under development and many\n{0}", _Indent);
			_Output.Write ("features are documented but not yet implemented. Use with care!\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare` command set contains commands that encode, decode and verify \n{0}", _Indent);
			_Output.Write ("DARE envelopes and sequences.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ archive append
			 Describe(CommandSet, ArchiveAppend._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare append` command appends the specified file to the sequence.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellSequence.SequenceAppend);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ ArchiveCreate create
			 Describe(CommandSet, _ArchiveCreate._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare archive` command creates an archive sequence with the specified cryptographic\n{0}", _Indent);
			_Output.Write ("enhancements. If a file or directory is specified, they are added to the archive and\n{0}", _Indent);
			_Output.Write ("an index appended to the end.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellSequence.SequenceArchive);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ archive copy
			 Describe(CommandSet, _ArchiveCopy._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare copy` command copies a sequence applying the specified filtering \n{0}", _Indent);
			_Output.Write ("and indexing criteria.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellSequence.SequenceArchiveCopy);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ archive delete
			 Describe(CommandSet, _ArchiveDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare delete` command marks the specified file entry as deleted in the\n{0}", _Indent);
			_Output.Write ("sequence but does not erase the data from the file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellSequence.SequenceDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ archive dir
			 Describe(CommandSet, _ArchiveDir._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare delete` command marks the specified file entry as deleted in the\n{0}", _Indent);
			_Output.Write ("sequence but does not erase the data from the file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellSequence.SequenceDelete);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ dare extract
			 Describe(CommandSet, _ArchiveExtract._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare extract` command extracts the specified sequence entries and writes them\n{0}", _Indent);
			_Output.Write ("to files.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellSequence.SequenceArchiveExtractFile);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			// ------------------ dare index
			 Describe(CommandSet, _ArchiveIndex._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `dare index` command appends an index record to the end of the sequence.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellSequence.SequenceIndex);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
