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
		// WebMessage
		//
		public static void WebMessage (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/message.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MessageReference
		//
		public static void MessageReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/message.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Profile;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _MessageContact._DescribeCommand);
				 Describe(_Output, CommandSet, _MessageConfirm._DescribeCommand);
				 Describe(_Output, CommandSet, _MessagePending._DescribeCommand);
				 Describe(_Output, CommandSet, _MessageStatus._DescribeCommand);
				 Describe(_Output, CommandSet, _MessageAccept._DescribeCommand);
				 Describe(_Output, CommandSet, _MessageReject._DescribeCommand);
				 Describe(_Output, CommandSet, _MessageBlock._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
