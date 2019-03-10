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
		public static void WebMail (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/mail.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MailReference
		//
		public static void MailReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/mail.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Profile;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _MailAdd._DescribeCommand);
				 Describe(_Output, CommandSet, _MailUpdate._DescribeCommand);
				 Describe(_Output, CommandSet, _SMIMEPrivate._DescribeCommand);
				 Describe(_Output, CommandSet, _SMIMEPublic._DescribeCommand);
				 Describe(_Output, CommandSet, _PGPPrivate._DescribeCommand);
				 Describe(_Output, CommandSet, _PGPPublic._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
