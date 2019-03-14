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
		// WebCalendar
		//
		public static void WebCalendar(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Guide/calendar.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Guide/calendar.md" };
				obj._WebCalendar(Examples);
				}
			}
		public void _WebCalendar(CreateWeb Examples) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("# Using the  Command Set\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The  command set contains commands that \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// CalendarReference
		//
		public static void CalendarReference(CreateWeb Examples) { /* XFile  */
				using (var _Output = new StreamWriter("Reference/calendar.md")) {
				var obj = new MakeSiteDocs() { _Output = _Output, _Indent = "", _Filename = "Reference/calendar.md" };
				obj._CalendarReference(Examples);
				}
			}
		public void _CalendarReference(CreateWeb Examples) {

				 var CommandSet = CommandLineInterpreter.DescribeCommandSet_Calendar;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Describe(CommandSet, _CalendarAdd._DescribeCommand);
				 Describe(CommandSet, _CalendarGet._DescribeCommand);
				 Describe(CommandSet, _CalendarDelete._DescribeCommand);
				 Describe(CommandSet, _CalendarDump._DescribeCommand);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
