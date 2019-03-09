using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Protocol;
using  Goedel.Mesh.Protocol.Server;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class ExampleGenerator : global::Goedel.Registry.Script {

		

		//
		// ExamplesProfile
		//
		public static void ExamplesProfile (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesProfile.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Mesh Profiles\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Every Mesh user has a Mesh profile which contains all the configuration information\n{0}", _Indent);
				_Output.Write ("for all their devices and all their network services. For convenience, the mesh profile \n{0}", _Indent);
				_Output.Write ("is divided into four separate parts, the Master profile, the Personal Profile, Device \n{0}", _Indent);
				_Output.Write ("Profiles and Application Profiles as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Mesh Master Profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh Master Profile describes the criteria for validating an owner's personal \n{0}", _Indent);
				_Output.Write ("profile. In particular, the master profile specifies the Master Signature Key \n{0}", _Indent);
				_Output.Write ("that is used as the root of trust under which the master profile is validated and\n{0}", _Indent);
				_Output.Write ("a set of Administration Signature Keys under which the personal profile is \n{0}", _Indent);
				_Output.Write ("validated.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Master Signature Key is immutable. By definition, it is not possible to change \n{0}", _Indent);
				_Output.Write ("the Master Signature Key without creating a new master profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The UDF fingerprint of the Master Signature Key is the fingerprint of the Master\n{0}", _Indent);
				_Output.Write ("Profile and the Personal Profile created underneath it.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Alice creates the following Master Profile, it has a Master Signature \n{0}", _Indent);
				_Output.Write ("Key and a Master Recovery Key. There is one administration device specified, the \n{0}", _Indent);
				_Output.Write ("correcponding device profile is described in the next section.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceMasterProfile}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The UDF fingerprint of Alice's Master signature key is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceFingerprint}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A Master Profile MAY be revoked but never expires. It is the intended that a user\n{0}", _Indent);
				_Output.Write ("should not normally need to change their master profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The only means of expiring a master profile that is currently supported is to \n{0}", _Indent);
				_Output.Write ("sign a 'suicide note' for the profile. This is an assertion that the master \n{0}", _Indent);
				_Output.Write ("profile is invalid that has been signed by the user. An application MAY generate\n{0}", _Indent);
				_Output.Write ("such a suicide note at the time that the master profile is created and archive it\n{0}", _Indent);
				_Output.Write ("so that the profile owner's executors can revoke the profile after death.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceMasterProfileSuicide}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since a Master Signature Key is immutable, no provision is made for modifying a Master \n{0}", _Indent);
				_Output.Write ("Signature Key, nor is such provision possible. Should a user lose control of the private\n{0}", _Indent);
				_Output.Write ("keys listed in their master profile, the only remediation possible is to create a\n{0}", _Indent);
				_Output.Write ("new Master Signature Key and master profile and then persuade parties relying on the \n{0}", _Indent);
				_Output.Write ("original that it is the successor.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Mesh Device Profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To make use of the Mesh Profile, Alice needs to connect at least one device. Every device\n{0}", _Indent);
				_Output.Write ("profile has an encryption, signature and authentication key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to use her desktop personal computer as her first administration device.\n{0}", _Indent);
				_Output.Write ("Her device profile is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceDeviceProfile}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that each of the keys is a Diffie-Hellman Key. This enables the use\n{0}", _Indent);
				_Output.Write ("of distributed key generation techniques as described in part III. These will\n{0}", _Indent);
				_Output.Write ("be transitioned to Elliptic Curve Diffie Hellman keys for production use.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Mesh Personal Profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice's personal profile contains her master profile and a list of device profiles. \n{0}", _Indent);
				_Output.Write ("It is signed by her administration device using its signature key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice's personal profile specifies her master profile and the device profile of her \n{0}", _Indent);
				_Output.Write ("personal computer:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AlicePersonalProfile}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A personal profile instance MUST specify the device profile of the administration profile \n{0}", _Indent);
				_Output.Write ("that signed that instance. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Mesh Application Profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice also creates one or more application profiles, each of which are signed by her \n{0}", _Indent);
				_Output.Write ("administration key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice creates a credential catalog to allow her to create strong passwords with a work factor\n{0}", _Indent);
				_Output.Write ("of 2^128 and use them on multiple devices, in this case, her administration device and\n{0}", _Indent);
				_Output.Write ("her \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceApplicationProfile}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
