using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	

	//
	// ToDo
	//
	public static void ToDo (CreateExamples Examples) { /* File  */
		using var _Output = new StreamWriter ("todo.md");
			var _Indent = ""; 
			_Output.Write ("<title>User Guide\n{0}", _Indent);
			_Output.Write ("<titlebanner><h1>To Do List\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("<h4>Issues noted in the documentation.\n{0}", _Indent);
			_Output.Write ("</titlebanner>\n{0}", _Indent);
			_Output.Write ("<leftmain>\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("<h1>Current count {1}\n{0}", _Indent, Examples.ToDoList.Count);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("<ul>\n{0}", _Indent);
			foreach  (var Entry in Examples.ToDoList) {
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<li><b>{1}</b>{2}\n{0}", _Indent, Entry.Key, Entry.Value);
				_Output.Write ("\n{0}", _Indent);
				}
			_Output.Write ("</ul>\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Examples.ToDoList = null; // Cause future attempts to add entries to cause an error.
	
			}
		}
