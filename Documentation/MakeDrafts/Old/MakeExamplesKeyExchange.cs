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
		// MakeExamplesKeyExchange
		//
		public static void MakeExamplesKeyExchange (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\KeyExchangeExamples.md")) {
				var _Indent = ""; 
				 var Point = Example.KeyExchangeTraces.Get (Example.TraceDH);
				 Example.KeyExchangeTraces.Level = 0;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Initial Key Exchange Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice requests access to a service using her account identifier {1}.\n{0}", _Indent, Example.AccountID);
				_Output.Write ("She has already registered her Mesh personal profile with the service where it is bound\n{0}", _Indent);
				_Output.Write ("to her account identifier as the corresponding credential.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Key exchange request is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Keyu Exchange response is\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that the example has the witness value but does not authenticate the signed \n{0}", _Indent);
				_Output.Write ("result at present. Perhaps it would be better to create the witness value from the \n{0}", _Indent);
				_Output.Write ("ticket data which eliminates the need for authenticating the response??\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h2>Rekey Example\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("(TBS)\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
