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
		public static void WebSSH(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/ssh.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/ssh.md" };
				obj._WebSSH(Index);
				}
			}
		public void _WebSSH(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SSHReference
		//
		public static void SSHReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/ssh.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/ssh.md" };
				obj._SSHReference(Index);
				}
			}
		public void _SSHReference(CreateWeb Index) {

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
