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
		// WebContact
		//
		public static void WebContact(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/contact.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/contact.md" };
				obj._WebContact(Index);
				}
			}
		public void _WebContact(CreateWeb Index) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ContactReference
		//
		public static void ContactReference(CreateWeb Index) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/contact.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/contact.md" };
				obj._ContactReference(Index);
				}
			}
		public void _ContactReference(CreateWeb Index) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Contact;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _ContactAdd._DescribeCommand);
				 Describe(CommandSet, _ContactDelete._DescribeCommand);
				 Describe(CommandSet, _ContactdGet._DescribeCommand);
				 Describe(CommandSet, _ContactDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
