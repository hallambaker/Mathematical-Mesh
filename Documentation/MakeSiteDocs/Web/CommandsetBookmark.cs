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
		public static void WebBookmark(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/bookmark.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/bookmark.md" };
				obj._WebBookmark(Examples);
				}
			}
		public void _WebBookmark(CreateWeb Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// BookmarkReference
		//
		public static void BookmarkReference(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/bookmark.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/bookmark.md" };
				obj._BookmarkReference(Examples);
				}
			}
		public void _BookmarkReference(CreateWeb Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Bookmark;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _BookmarkAdd._DescribeCommand);
				 Describe(CommandSet, _BookmarkDelete._DescribeCommand);
				 Describe(CommandSet, _BookmarkGet._DescribeCommand);
				 Describe(CommandSet, _BookmarkDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
