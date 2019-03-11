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
		public static void WebMessage(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/message.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/message.md" };
				obj._WebMessage(Index);
				}
			}
		public void _WebMessage(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// MessageReference
		//
		public static void MessageReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/message.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/message.md" };
				obj._MessageReference(Index);
				}
			}
		public void _MessageReference(CreateWeb Index) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Message;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MessageContact._DescribeCommand);
				 Describe(CommandSet, _MessageConfirm._DescribeCommand);
				 Describe(CommandSet, _MessagePending._DescribeCommand);
				 Describe(CommandSet, _MessageStatus._DescribeCommand);
				 Describe(CommandSet, _MessageAccept._DescribeCommand);
				 Describe(CommandSet, _MessageReject._DescribeCommand);
				 Describe(CommandSet, _MessageBlock._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
