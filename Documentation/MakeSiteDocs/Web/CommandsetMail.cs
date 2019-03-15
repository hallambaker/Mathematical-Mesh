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
		// WebMail
		//
		public static void WebMail(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/mail.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/mail.md" };
				obj._WebMail(Examples);
				}
			}
		public void _WebMail(Examples Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// MailReference
		//
		public static void MailReference(Examples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/mail.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/mail.md" };
				obj._MailReference(Examples);
				}
			}
		public void _MailReference(Examples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Mail;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _MailAdd._DescribeCommand);
				 Describe(CommandSet, _MailUpdate._DescribeCommand);
				 Describe(CommandSet, _SMIMEPrivate._DescribeCommand);
				 Describe(CommandSet, _SMIMEPublic._DescribeCommand);
				 Describe( CommandSet, _PGPPrivate._DescribeCommand);
				 Describe( CommandSet, _PGPPublic._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
