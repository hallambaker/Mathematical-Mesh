using Goedel.Mesh.Shell;
using System.IO;
namespace ExampleGenerator {
    public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// WebBookmark
		//
		public static void WebBookmark(CreateExamples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/bookmark.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Guide/bookmark.md" };
				obj._WebBookmark(Examples);
				}
			}
		public void _WebBookmark(CreateExamples Examples) {

				 MakeTitle ("bookmark");
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The `bookmark` command set is used to manage a bookmarks catalog which contains\n{0}", _Indent);
				_Output.Write ("a collection of bookmarks and citations and shares them between devices connected \n{0}", _Indent);
				_Output.Write ("to the profile with the relevant access authorization.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The term 'bookmark' is interpreted loosely to mean any piece of index information\n{0}", _Indent);
				_Output.Write ("that the user might want to index and add to a catalog for future use. This\n{0}", _Indent);
				_Output.Write ("includes traditional Web bookmarks and citations to academic articles.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The current version of the Mesh protocols only support access to a single personal \n{0}", _Indent);
				_Output.Write ("bookmark catalog but the approach could, in principle, be extanded to support multiple\n{0}", _Indent);
				_Output.Write ("named bookmark catalogs per user and catalogs sharted between multiple users.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding bookmarks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds a bookmark entry to a catalog:\n{0}", _Indent, ToCommand("bookmark add"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.BookmarkAdd);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Finding bookmarks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1}  command retreives a bookmark  by its index label:\n{0}", _Indent, ToCommand("bookmark get"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.BookmarkGet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Deleting bookmarks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bookmark entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("bookmark delete"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.BookmarkDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Listing bookmarks\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A complete list of bookmarks is obtained using the  {1} command:\n{0}", _Indent, ToCommand("bookmark list"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.BookmarkList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Devices are given authorization to access the bookmarks catalog using the \n{0}", _Indent);
				_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.BookmarkAuth);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The new device now has access to the Bookmarks catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Examples.BookmarkList2);
					}
		

		//
		// BookmarkReference
		//
		public static void BookmarkReference(CreateExamples Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/bookmark.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Reference/bookmark.md" };
				obj._BookmarkReference(Examples);
				}
			}
		public void _BookmarkReference(CreateExamples Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Network;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _BookmarkAdd._DescribeCommand);
				 ConsoleReference (Examples.BookmarkAdd);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _BookmarkDelete._DescribeCommand);
				 ConsoleReference (Examples.BookmarkDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _BookmarkGet._DescribeCommand);
				 ConsoleReference (Examples.BookmarkGet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _BookmarkDump._DescribeCommand);
				 ConsoleReference (Examples.BookmarkList);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
