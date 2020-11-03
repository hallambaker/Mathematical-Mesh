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
namespace ExampleGenerator {
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
				_Output.Write ("Calendar entries are typically exchanged in iCal format. This is not currently\n{0}", _Indent);
				_Output.Write ("implemented and a placeholder format is implemented instead.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Adding calendars\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The {1} command adds a calendar entry to a catalog:\n{0}", _Indent, ToCommand("password add"));
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
				_Output.Write ("Devices are given authorization to access the calendars catalog using the \n{0}", _Indent);
				_Output.Write (" {1} command:\n{0}", _Indent, ToCommand("device auth"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write (" %  ConsoleExample (ShellCalendar.CalendarAuth);\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _CalendarAdd._DescribeCommand);
				 ConsoleReference (ShellCalendar.CalendarAdd);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _CalendarDelete._DescribeCommand);
				 ConsoleReference (ShellCalendar.CalendarDelete);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _CalendarGet._DescribeCommand);
				 ConsoleReference (ShellCalendar.CalendarGet);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _CalendarDump._DescribeCommand);
				 ConsoleReference (ShellCalendar.CalendarList);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
