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
	// WebCalendar
	//
	public static void WebCalendar(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Guide/calendar.md");
		Examples._Output = _Output;
		Examples._WebCalendar(Examples);
		}
	public void _WebCalendar(CreateExamples Examples) {

			 MakeTitle ("calendar");
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `calendar` command set is used to manage a calendar configuration catalog which contains\n{0}", _Indent);
			_Output.Write ("a entries describing how to access particular calendars.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("It should be noted that by its very nature, a calendar tool is most likely \n{0}", _Indent);
			_Output.Write ("to be useful within a calendar application. The\n{0}", _Indent);
			_Output.Write ("commands provided in the 'meshman' tool are intended to support debuging and \n{0}", _Indent);
			_Output.Write ("maintenance of such applications and afford a means of interacting through scripts.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("As with bookmarks, calendar entries should be considered as including all forms of\n{0}", _Indent);
			_Output.Write ("task announcement, including those that are not appointments and do not take place at\n{0}", _Indent);
			_Output.Write ("a fixed time.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, Alice might send messages to Bob telling him that she wants to meet\n{0}", _Indent);
			_Output.Write ("him the next day at 3pm or that she would like to meet at a time convenient to him\n{0}", _Indent);
			_Output.Write ("within the next week. Carol migt send a message to Bob telling him to buy more\n{0}", _Indent);
			_Output.Write ("lawn and leaf bags when he is in a store that sells them.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The format of all these tasks is 'when condition X is met do Y', and it makes \n{0}", _Indent);
			_Output.Write ("good sense to use the same application for all of them, particularly when that\n{0}", _Indent);
			_Output.Write ("application is running on a device that constantly tracks its current location, not\n{0}", _Indent);
			_Output.Write ("just the current time.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding calendar entries\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1} and {2} command \n{0}", _Indent, ToCommand("password add"), ToCommand("password import"));
			_Output.Write ("add calendar entries to a catalog. The add command creates an entry from\n{0}", _Indent);
			_Output.Write ("the command line options. The import command adds an entry from a file.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The catalog entry is specified in a file containing the calendar entry data. Currently,\n{0}", _Indent);
			_Output.Write ("only JSON entry files are supported.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, FutureFeature("Calendar/iCal", "Allow iCal description of the entry to add."));
			_Output.Write ("Calendar entries are typically exchanged in iCal format. This is not currently\n{0}", _Indent);
			_Output.Write ("implemented and a placeholder format is implemented instead.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellCalendar.CalendarAdd);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Finding calendars\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The {1}  command retreives a calendar entry by label:\n{0}", _Indent, ToCommand("password get"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellCalendar.CalendarGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Deleting calendars\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Calendar entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("calendar delete"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellCalendar.CalendarDelete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Listing calendars\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A complete list of calendars is obtained using the  {1} command:\n{0}", _Indent, ToCommand("calendar list"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellCalendar.CalendarList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("## Adding devices\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellCalendar.CalendarList1);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Devices are given authorization to access the calendars catalog using the \n{0}", _Indent);
			_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectJoinAuth );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The new device now has access to the Calendar catalog:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (ShellCalendar.CalendarList2);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// CalendarReference
	//
	public static void CalendarReference(CreateExamples Examples) { /* XFile  */
			using var _Output = new StreamWriter("Reference/calendar.md");
		Examples._Output = _Output;
		Examples._CalendarReference(Examples);
		}
	public void _CalendarReference(CreateExamples Examples) {

			 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Calendar;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The `calendar` command set is used to manage a calendar configuration catalog which contains\n{0}", _Indent);
			_Output.Write ("a entries describing how to access particular calendars.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("It should be noted that by its very nature, a calendar tool is most likely \n{0}", _Indent);
			_Output.Write ("to be useful within a calendar application. The\n{0}", _Indent);
			_Output.Write ("commands provided in the 'meshman' tool are intended to support debuging and \n{0}", _Indent);
			_Output.Write ("maintenance of such applications and afford a means of interacting through scripts.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _CalendarAdd._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'calendar add' command is used to add appointment and task entries to the catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The catalog entry is specified as a file. The file type is automatically inferred from\n{0}", _Indent);
			_Output.Write ("the extension or may be overridden with the '/format' option.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/id' option may be used to specify a unique identifier for the entry.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellCalendar.CalendarAdd);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _CalendarDelete._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'calendar delete' command deletes an appointment or task entry by means of \n{0}", _Indent);
			_Output.Write ("its unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellCalendar.CalendarDelete);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _CalendarGet._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'calendar get' command retrieves an appointment or task entry by means of its \n{0}", _Indent);
			_Output.Write ("unique catalog identifier.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellCalendar.CalendarGet);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _CalendarImport._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'calendar import' command is used to add appointment and task entries to the catalog\n{0}", _Indent);
			_Output.Write ("from a file\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The catalog entry is specified as a file. The file type is automatically inferred from\n{0}", _Indent);
			_Output.Write ("the extension or may be overridden with the '/format' option.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The '/id' option may be used to specify a unique identifier for the entry.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellCalendar.CalendarAdd);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Describe(CommandSet, _CalendarDump._DescribeCommand);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 'calendar list' command lists all data in the calendar catalog.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 ConsoleReference (ShellCalendar.CalendarList);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
		}
