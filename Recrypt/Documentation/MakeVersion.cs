// #using System.Text 
using  System.Text;
// #using Goedel.Recrypt 
using  Goedel.Recrypt;
// #using Goedel.Protocol 
using  Goedel.Protocol;
// #pclass ExampleGenerator ExampleGenerator 
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {
		public ExampleGenerator () : base () {
			}
		public ExampleGenerator (TextWriter Output) : base (Output) {
			}

		//  
		//  
		// #method RecryptExamplesWeb CreateExamples Example 
		

		//
		// RecryptExamplesWeb
		//
		public void RecryptExamplesWeb (CreateExamples Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ##Protocol Overview 
			_Output.Write ("#Protocol Overview\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Here we put a description of the basic protocol  
			_Output.Write ("Here we put a description of the basic protocol \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Connection Establishment 
			_Output.Write ("##Connection Establishment\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// This part of the specification should be separated into a generic  
			_Output.Write ("This part of the specification should be separated into a generic \n{0}", _Indent);
			// building block for reuse in other protocols. 
			_Output.Write ("building block for reuse in other protocols.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service discovery mechanism described in  
			_Output.Write ("The service discovery mechanism described in \n{0}", _Indent);
			// [!draft-hallambaker-json-web-service-02] is used. 
			_Output.Write ("[!draft-hallambaker-json-web-service-02] is used.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Hello transaction MAY be used to determine specific  
			_Output.Write ("The Hello transaction MAY be used to determine specific \n{0}", _Indent);
			// features of the particular Web Service. 
			_Output.Write ("features of the particular Web Service.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The client request is: 
			_Output.Write ("The client request is:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% var Point = Example.Traces.Get (Example.LabelHello); 
			 var Point = Example.Traces.Get (Example.LabelHello);
			// #% Example.Traces.Level = 0; 
			 Example.Traces.Level = 0;
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service responds with a description of the service. This  
			_Output.Write ("The service responds with a description of the service. This \n{0}", _Indent);
			// description MUST specify at least one supported protocol 
			_Output.Write ("description MUST specify at least one supported protocol\n{0}", _Indent);
			// version. 
			_Output.Write ("version.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A typical client response is: 
			_Output.Write ("A typical client response is:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// All versions of the protocol SHALL support the Hello transaction. 
			_Output.Write ("All versions of the protocol SHALL support the Hello transaction.\n{0}", _Indent);
			// A service MUST support the use of JSON encoding for the  
			_Output.Write ("A service MUST support the use of JSON encoding for the \n{0}", _Indent);
			// Hello transaction regardless of version.  
			_Output.Write ("Hello transaction regardless of version. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The set of encodings supportted by a protocol version is  
			_Output.Write ("The set of encodings supportted by a protocol version is \n{0}", _Indent);
			// specified in the Encodings field. The encodings field MAY  
			_Output.Write ("specified in the Encodings field. The encodings field MAY \n{0}", _Indent);
			// be omitted if only JSON is supported. 
			_Output.Write ("be omitted if only JSON is supported.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A service SHOULD support at least one protocol version with  
			_Output.Write ("A service SHOULD support at least one protocol version with \n{0}", _Indent);
			// JSON encoding. 
			_Output.Write ("JSON encoding.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Example.Traces.Level = 5; 
			 Example.Traces.Level = 5;
			// [Note that for the sake of concise presentation, the HTTP binding 
			_Output.Write ("[Note that for the sake of concise presentation, the HTTP binding\n{0}", _Indent);
			// information is omitted from future examples.] 
			_Output.Write ("information is omitted from future examples.]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		// #end pclass 
		}
	}
//  
