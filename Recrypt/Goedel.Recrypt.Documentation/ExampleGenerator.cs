using  System.Text;
using  Goedel.Recrypt;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace Goedel.Recrypt.Documentation {
	/// <summary>A Goedel script.</summary>
	public partial class ExampleGenerator : global::Goedel.Registry.Script {
		/// <summary>Default constructor.</summary>
		public ExampleGenerator () : base () {
			}
		/// <summary>Constructor with output stream.</summary>
		/// <param name="Output">The output stream</param>
		public ExampleGenerator (TextWriter Output) : base (Output) {
			}

		

		//
		// AdminExamples
		//
		public void AdminExamples (RecryptExamples Example) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Check service connection\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("It is often useful to be able to verify that a service is ready and willing\n{0}", _Indent);
			_Output.Write ("to perform transactions before attempting to perform one. Especially so\n{0}", _Indent);
			_Output.Write ("when the transaction requires considerable amounts of data and may require the \n{0}", _Indent);
			_Output.Write ("use of specific server determined authentication options.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request message is 'HelloRequest' and has no parameters:\n{0}", _Indent);
			 var Point = Example.Traces.Get (Example.LabelHello);
			 Example.Traces.Level = 0;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The response message specifies the protocol version(s) supported, the corresponding\n{0}", _Indent);
			_Output.Write ("encodings and bindings:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Create and populate a group\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first step in creating a recryption group is to create at least one\n{0}", _Indent);
			_Output.Write ("public key encryption keypair. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that a recryption group should be specified as some form of Mesh \n{0}", _Indent);
			_Output.Write ("profile. Whether this should be an application profile or a personal profile\n{0}", _Indent);
			_Output.Write ("is not yet clear. This part of the protocol is likely to change before\n{0}", _Indent);
			_Output.Write ("deployment.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice creates the recryption group and creates member entries for herself \n{0}", _Indent);
			_Output.Write ("and Bob. [[TBS: Need to add profiles for Alice and Bob at some point.\n{0}", _Indent);
			_Output.Write ("This needs thought.]\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request message is 'CreateGroupRequest' and specifies the initial data to be used\n{0}", _Indent);
			_Output.Write ("to populate the group.\n{0}", _Indent);
			 Point = Example.Traces.Get (Example.LabelCreate);
			 Example.Traces.Level = 1;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The response message returns success or the reason for failure\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Request Recyption\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To test the new group, Alice encrypts a message under the group public key\n{0}", _Indent);
			_Output.Write ("and sends it to Bob. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob receives the test message from Alice. To decrypt the message, Bob's client \n{0}", _Indent);
			_Output.Write ("requests the corresponding partial recryption information from the key server.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request message is 'RecryptDataRequest'. It specifies the Recipient data\n{0}", _Indent);
			_Output.Write ("from the encrypted message and Bob's recryption key identifier for that particular \n{0}", _Indent);
			_Output.Write ("key service.\n{0}", _Indent);
			 Point = Example.Traces.Get (Example.LabelRecrypt);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If the request is successful, the response 'RecryptDataResponse' is \n{0}", _Indent);
			_Output.Write ("returned containing the necessary partial decryption data and\n{0}", _Indent);
			_Output.Write ("user decryption entry\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("##Revoke Membership\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob leaves the company and Alice revokes the access to the recryption group\n{0}", _Indent);
			_Output.Write ("that she granted earlier. Note that this will not stop Bob from reading material \n{0}", _Indent);
			_Output.Write ("that he has already decrypted, it will only prevent him decrypting new material.\n{0}", _Indent);
			_Output.Write ("Nor will this prevent the use of the key material that was issued to Bob being \n{0}", _Indent);
			_Output.Write ("used to decrypt messages should the key service be breached.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The request message is 'UpdateMemberRequest'. This specifies which \n{0}", _Indent);
			_Output.Write ("member record in which group is to be updated and the new data to populate\n{0}", _Indent);
			_Output.Write ("the entry. \n{0}", _Indent);
			 Point = Example.Traces.Get (Example.LabelSuspend);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The response message returns success or the reason for failure\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		}
	}
