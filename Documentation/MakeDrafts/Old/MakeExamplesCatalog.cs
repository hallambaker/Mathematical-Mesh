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
		// ExamplesCatalog
		//
		public static void ExamplesCatalog (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesCatalog.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Mesh Catalogs\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A Mesh Catalog Service contains a set of entries that are created by the user\n{0}", _Indent);
				_Output.Write ("for their own use.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A catalog entry MUST be signed by the signature key of a device that is specified in\n{0}", _Indent);
				_Output.Write ("the user's Personal Profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Each entry in a Mesh catalog has a unique identifier that acts as its primary key. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Mesh catalogs are typically compact and updated infrequently. Given current storage\n{0}", _Indent);
				_Output.Write ("costs and typical network bandwidth, it is to be expected that most users will be\n{0}", _Indent);
				_Output.Write ("best served by a model in which every device contains a complete copy of the user's\n{0}", _Indent);
				_Output.Write ("catalog(s) that are of interest to it rather than support a model in which connected\n{0}", _Indent);
				_Output.Write ("devices hunt an peck for the desired records on the server. Such an approach is in \n{0}", _Indent);
				_Output.Write ("any case likely to be impossible for the majority of Mesh applications in which the \n{0}", _Indent);
				_Output.Write ("server content is end-to-end encrypted.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Synchronizing a Device to a Catalog\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Synchronization of the catalog data stored on a device with that stored by the\n{0}", _Indent);
				_Output.Write ("Mesh service is bidirectional. Catalog updates stored on the device are merged\n{0}", _Indent);
				_Output.Write ("with those stored on the service and any conflicts reported to the user.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Each device that has the access privilege to update catalog entries thus has two\n{0}", _Indent);
				_Output.Write ("separate queues, one containing a (possibly incomplete) copy of the append-only\n{0}", _Indent);
				_Output.Write ("log held by the service, the other containing updates that have been made on \n{0}", _Indent);
				_Output.Write ("the device but have not yet been accepted by the service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When a device synchronizes, it:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Uploads update requests from the device to the service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Downloads relevant updates from the service to the device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Devices MAY perform these operations in either order or simultaneously (if the \n{0}", _Indent);
				_Output.Write ("service permits). But regardless of the order in which these are performed \n{0}", _Indent);
				_Output.Write ("by a particular device, there is only one catalog and it is maintaind by the service. \n{0}", _Indent);
				_Output.Write ("Thus all updates that are accepted SHALL be applied to the catalog after all\n{0}", _Indent);
				_Output.Write ("the previous updates.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since every object has a distinct and independent lifecycle in the Mesh persistence\n{0}", _Indent);
				_Output.Write ("model, detecting a conflict early on in the synchronization process does not \n{0}", _Indent);
				_Output.Write ("invalidate updates to other objects which are independent.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, consider the scenario in which Alice synchronizes two devices to\n{0}", _Indent);
				_Output.Write ("her credential catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice is already using the password management features of her browser but this \n{0}", _Indent);
				_Output.Write ("service does not provide end-to-end encryption. Alice's Mesh client provides a \n{0}", _Indent);
				_Output.Write ("feature that allows her to export the usernames and passwords from her browser\n{0}", _Indent);
				_Output.Write ("and store them in a Mesh catalog.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice's first device creates two credential entries.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceCredential1}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When multiple catalog entries are being encrypted at the same time, these MAY be\n{0}", _Indent);
				_Output.Write ("encrypted under a single key agreement or under a separate key agreement for \n{0}", _Indent);
				_Output.Write ("each entry. Here, a single key agreement is shared:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceCredential1Request}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the catalog is empty, the service accepts the update entries and responds \n{0}", _Indent);
				_Output.Write ("with the catalog index before and after the items were accepted.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceCredential1Response}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice then attempts to syncrhonize a second device. The browser on the second device \n{0}", _Indent);
				_Output.Write ("has two entries, one of which maches an entry in the first and the other of\n{0}", _Indent);
				_Output.Write ("which is different:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceCredential2}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When the service responds to the second request, the first entry is rejected as\n{0}", _Indent);
				_Output.Write ("a possible conflict and the second is accepted. Note that even though the \n{0}", _Indent);
				_Output.Write ("username/password values are identical, the service does not know this because they\n{0}", _Indent);
				_Output.Write ("are end-to-end encrypted and the service does not have a decryption key. The service\n{0}", _Indent);
				_Output.Write ("responds with a list of the frame numbers of the rejected entries.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceCredential1Response}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Entries are deleted from a catalog with the delete method. The request specifies \n{0}", _Indent);
				_Output.Write ("the catalog to be updated and the list of entries to be deleted:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{AliceDeleteCredential}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
