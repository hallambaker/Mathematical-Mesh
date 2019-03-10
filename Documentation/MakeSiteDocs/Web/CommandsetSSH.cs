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
		public static void WebSSH (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/ssh.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// SSHReference
		//
		public static void SSHReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/ssh.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_SSH;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _SSHCreate._DescribeCommand);
				 Describe(_Output, CommandSet, _SSHPrivate._DescribeCommand);
				 Describe(_Output, CommandSet, _SSHPublic._DescribeCommand);
				 Describe(_Output, CommandSet, _SSHAddHost._DescribeCommand);
				 Describe(_Output, CommandSet, _SSHMergeKnown._DescribeCommand);
				 Describe(_Output, CommandSet, _SSHAddClient._DescribeCommand);
				 Describe(_Output, CommandSet, _SSHKnown._DescribeCommand);
				 Describe(_Output, CommandSet, _SSHAuth._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
