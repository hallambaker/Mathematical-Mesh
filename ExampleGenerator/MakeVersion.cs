// #using System.Text 
using  System.Text;
// #pclass ExampleGenerator Version 
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class Version : global::Goedel.Registry.Script {
		public Version () : base () {
			}
		public Version (TextWriter Output) : base (Output) {
			}

		// #method MakeVersion int Ignore 
		

		//
		// MakeVersion
		//
		public void MakeVersion (int Ignore) {
			//  
			_Output.Write ("\n{0}", _Indent);
			// namespace InternetDrafts { 
			_Output.Write ("namespace InternetDrafts {{\n{0}", _Indent);
			//     class Version { 
			_Output.Write ("    class Version {{\n{0}", _Indent);
			//         } 
			_Output.Write ("        }}\n{0}", _Indent);
			//     } 
			_Output.Write ("    }}\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		// #end pclass 
		}
	}
// #end using 
