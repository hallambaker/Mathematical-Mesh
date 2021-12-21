using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Shell;
using  Goedel.Protocol;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	

	//
	// WebBookmark
	//
	public static void WebBookmark(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/bookmark.md");
		Examples._Output = _Output;
		Examples._WebBookmark(Examples);
		}
	public void _WebBookmark(CreateExamples Examples) {

			 MakeTitle ("bookmark");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `bookmark` command set is used to manage a bookmarks catalog which contains\n{0}", _Indent);
			_Output.Write ("a collection of bookmarks and citations and shares them between devices connected \n{0}", _Indent);
			_Output.Write ("to the profile with the relevant access authorization.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("It should be noted that by its very nature, a bookmark manager is most likely \n{0}", _Indent);
			_Output.Write ("to be useful within an application that uses bookmarks for navigation. The\n{0}", _Indent);
			_Output.Write ("commands provided in the 'meshman' tool are intended to support debuging and \n{0}", _Indent);
			_Output.Write ("maintenance of such applications and afford a means of interacting through scripts.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The term 'bookmark' is interpreted loosely to mean any piece of index information\n{0}", _Indent);
			_Output.Write ("that the user might want to index and add to a catalog for future use. This\n{0}", _Indent);
			_Output.Write ("includes traditional Web bookmarks and citations to academic articles.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The current version of the Mesh protocols only support access to a single personal \n{0}", _Indent);
			_Output.Write ("bookmark catalog but the approach could, in principle, be extanded to support multiple\n{0}", _Indent);
			_Output.Write ("named bookmark catalogs per user and catalogs sharted between multiple users.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, FutureFeature("Bookmark/Abstract", "The abstract and reaction features are not yet implemented"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, FutureFeature("Bookmark/JSON", "Allow upload of a JSON file with the bookmark entey"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding bookmarks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} command adds a bookmark entry to a catalog:\n{0}", _Indent, ToCommand("bookmark add"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellBookmark.BookmarkAdd);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The path mechanism is clearly clunky and should be eliminated in favor or a series of\n{0}", _Indent);
			_Output.Write ("hashtag type search terms which may be hierarchical if this seems useful.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The add command should be expanded to allow an abstract and reaction to be included.\n{0}", _Indent);
			_Output.Write ("So if I find material useful, I give it thumbs up, terrible, a thumbs down.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("It should also be possible to attach comments to bookmarks giving a longer explanation.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Finding bookmarks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command retreives a bookmark  by its index label:\n{0}", _Indent, ToCommand("bookmark get"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellBookmark.BookmarkGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Deleting bookmarks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bookmark entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("bookmark delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellBookmark.BookmarkDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Listing bookmarks\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A complete list of bookmarks is obtained using the  {1} command:\n{0}", _Indent, ToCommand("bookmark list"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellBookmark.BookmarkList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding devices\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellBookmark.BookmarkList1);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Devices are given authorization to access the bookmarks catalog using the \n{0}", _Indent);
			_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectJoinAuth );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The new device now has access to the Bookmarks catalog:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellBookmark.BookmarkList2);
				}
	

	//
	// BookmarkReference
	//
	public static void BookmarkReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/bookmark.md");
		Examples._Output = _Output;
		Examples._BookmarkReference(Examples);
		}
	public void _BookmarkReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Bookmark;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `bookmark` command set is used to manage a bookmarks catalog which contains\n{0}", _Indent);
			_Output.Write ("a collection of bookmarks and citations and shares them between devices connected \n{0}", _Indent);
			_Output.Write ("to the profile with the relevant access authorization.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("It should be noted that by its very nature, a bookmark manager is most likely \n{0}", _Indent);
			_Output.Write ("to be useful within an application that uses bookmarks for navigation. The\n{0}", _Indent);
			_Output.Write ("commands provided in the 'meshman' tool are intended to support debuging and \n{0}", _Indent);
			_Output.Write ("maintenance of such applications and afford a means of interacting through scripts.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _BookmarkAdd._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'bookmark add' command is used to add bookmarks to the catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The catalog labels, uri and title are specified as parameters.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("An abstract, comment and reaction tags may be specified as options.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellBookmark.BookmarkAdd);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _BookmarkDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'bookmark delete' command deletes a bookmark by means of its unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellBookmark.BookmarkDelete);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _BookmarkGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'bookmark get' command retrieves a bookmark by means of its unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellBookmark.BookmarkGet);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _NetworkImport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'bookmark import' command is used to add a bookmark entry to the catalog\n{0}", _Indent);
			_Output.Write ("from a file\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _BookmarkDump._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'bookmark list' command lists all data in the bookmark catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellBookmark.BookmarkList);
			_Output.Write ("\n{0}", _Indent);
				}
		}
