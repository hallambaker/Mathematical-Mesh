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
		// WebBookmark
		//
		public static void WebBookmark (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Guide/bookmark.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// BookmarkReference
		//
		public static void BookmarkReference (CreateWeb Index) { /* File  */
			using (var _Output = new StreamWriter ("Reference/bookmark.md")) {
				var _Indent = ""; 
				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Bookmark;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(_Output, CommandSet, _BookmarkAdd._DescribeCommand);
				 Describe(_Output, CommandSet, _BookmarkDelete._DescribeCommand);
				 Describe(_Output, CommandSet, _BookmarkGet._DescribeCommand);
				 Describe(_Output, CommandSet, _BookmarkDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
