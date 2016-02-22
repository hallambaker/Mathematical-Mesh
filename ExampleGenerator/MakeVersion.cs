// #using System.Text 
using  System.Text;
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
		//  
		//  
		// #method MeshExamples CreateExamples Example 
		

		//
		// MeshExamples
		//
		public void MeshExamples (CreateExamples Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			// ##Protocol Overview 
			_Output.Write ("#Protocol Overview\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Creating a new user profile 
			_Output.Write ("##Creating a new user profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Creating a new portal account 
			_Output.Write ("##Creating a new portal account\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A user interacts with a Mesh service through a Mesh portal provider  
			_Output.Write ("A user interacts with a Mesh service through a Mesh portal provider \n{0}", _Indent);
			// with which she establishes a portal account.  
			_Output.Write ("with which she establishes a portal account. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// For user convenience, a portal account identifier has the familiar  
			_Output.Write ("For user convenience, a portal account identifier has the familiar \n{0}", _Indent);
			// <username>@<domain> format established in [~RFC822]. 
			_Output.Write ("<username>@<domain> format established in [~RFC822].\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// For example Alice selects #{CreateExamples.NameService} as her  
			_Output.Write ("For example Alice selects {1} as her \n{0}", _Indent, CreateExamples.NameService);
			// portal provider and chooses the account name #{CreateExamples.NameAccount}. 
			_Output.Write ("portal provider and chooses the account name {1}.\n{0}", _Indent, CreateExamples.NameAccount);
			// Her portal account identifier is #{CreateExamples.NameAccount}. 
			_Output.Write ("Her portal account identifier is {1}.\n{0}", _Indent, CreateExamples.NameAccount);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A user MAY establish accounts with multiple portal providers 
			_Output.Write ("A user MAY establish accounts with multiple portal providers\n{0}", _Indent);
			// and/or change their portal provider at any time they choose. 
			_Output.Write ("and/or change their portal provider at any time they choose.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Checking Account Identifier for uniqueness 
			_Output.Write ("###Checking Account Identifier for uniqueness\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% var ValidatePoint = Example.Traces.Get ("Validate"); 
			 var ValidatePoint = Example.Traces.Get ("Validate");
			// #% var ValidateRequest = ValidatePoint.Messages [0]; 
			 var ValidateRequest = ValidatePoint.Messages [0];
			//  
			_Output.Write ("\n{0}", _Indent);
			// <pre> 
			_Output.Write ("<pre>\n{0}", _Indent);
			// #{ValidateRequest.StringHTTP(false)} 
			_Output.Write ("{1}\n{0}", _Indent, ValidateRequest.StringHTTP(false));
			// </pre> 
			_Output.Write ("</pre>\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Publishing a new user profile 
			_Output.Write ("###Publishing a new user profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Connecting a device profile to a user profile 
			_Output.Write ("##Connecting a device profile to a user profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Adding an application profile to a user profile 
			_Output.Write ("##Adding an application profile to a user profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Updating an application profile 
			_Output.Write ("##Updating an application profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Creating a recovery profile 
			_Output.Write ("##Creating a recovery profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Recovering a profile 
			_Output.Write ("##Recovering a profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Accidents happen and so do disasters. For most users and most applications, 
			_Output.Write ("Accidents happen and so do disasters. For most users and most applications,\n{0}", _Indent);
			// data loss is a much more important concern than data disclosure. The option  
			_Output.Write ("data loss is a much more important concern than data disclosure. The option \n{0}", _Indent);
			// of using a robust key recovery mechanism is therefore essential for use of  
			_Output.Write ("of using a robust key recovery mechanism is therefore essential for use of \n{0}", _Indent);
			// strong cryptography is to become ubiquitous. 
			_Output.Write ("strong cryptography is to become ubiquitous.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// There are of course circumstances in which some users may prefer to risk 
			_Output.Write ("There are of course circumstances in which some users may prefer to risk\n{0}", _Indent);
			// losing some of their data rather than risk disclosure. Since any key recovery 
			_Output.Write ("losing some of their data rather than risk disclosure. Since any key recovery\n{0}", _Indent);
			// infrastructure necessarily introduces the risk of  
			_Output.Write ("infrastructure necessarily introduces the risk of \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A Mesh profile  
			_Output.Write ("A Mesh profile \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
		//  
		// #end pclass 
		}
	}
// #end using 
