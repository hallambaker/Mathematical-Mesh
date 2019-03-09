using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// ExampleSession
		//
		public static void ExampleSession (CreateExamples Examples) { /* File  */
			using (var _Output = new StreamWriter ("examplesession.mdx")) {
				var _Indent = ""; 
				_Output.Write ("{1}\n{0}", _Indent, Examples.Example("IndexSet"));
				}
			}
		}
	}
