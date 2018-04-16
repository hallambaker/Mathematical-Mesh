using  System.Text;
using  Goedel.Mesh;
using  Goedel.Mesh.Portal;
using  Goedel.Mesh.Portal.Server;
using  Goedel.Protocol;
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
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
		// MakeVersion
		//
		public void MakeVersion (int Ignore) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("namespace InternetDrafts {{\n{0}", _Indent);
			_Output.Write ("    class Version {{\n{0}", _Indent);
			_Output.Write ("        }}\n{0}", _Indent);
			_Output.Write ("    }}\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// MeshExamplesWeb
		//
		public static void MeshExamplesWeb (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesWeb.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Password Management\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to use the Mesh to manage her Web usernames and passwords.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("She creates two accounts:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* example.com: username 'alice', password 'secret'\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* cnn.com: username 'alice1', password 'secret'\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The JSON encoding of the password data is as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Example.PasswordProfile1.Private.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The JSON encoded password data is then encrypted and stored in an\n{0}", _Indent);
				_Output.Write ("application profile as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Example.PasswordProfile1}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("As we saw earlier, Alice really needs to start using stronger passwords. \n{0}", _Indent);
				_Output.Write ("Fortunately, having access to a password manager means that Alice doesn't\n{0}", _Indent);
				_Output.Write ("need to remember different passwords for every site she uses any more.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In addition to offering to use the Mesh to remember passwords, a Web\n{0}", _Indent);
				_Output.Write ("browser can offer to automatically generate a password for a site.\n{0}", _Indent);
				_Output.Write ("This can be a much stronger password than the user would normally want\n{0}", _Indent);
				_Output.Write ("to choose if they had to remember it.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice chooses to use password generation. Her password manager profile is\n{0}", _Indent);
				_Output.Write ("updated to reflect this new choice.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Example.PasswordProfile2.Private.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice is happy to use the password manager for her general Web sites but\n{0}", _Indent);
				_Output.Write ("not for the password she uses to log in to her bank account. When asked\n{0}", _Indent);
				_Output.Write ("if the password should be stored in the Mesh, Alice declines and asks \n{0}", _Indent);
				_Output.Write ("not to be asked in the future.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Example.PasswordProfile3.Private.ToString()}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamples
		//
		public static void MeshExamples (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\Examples.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Protocol Overview\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Account request does not specify the portal in the request body,\n{0}", _Indent);
				_Output.Write ("only the HTTP package includes this information. This is probably a bug.]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Creating a new portal account\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A user interacts with a Mesh service through a Mesh portal provider \n{0}", _Indent);
				_Output.Write ("with which she establishes a portal account. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For user convenience, a portal account identifier has the familiar \n{0}", _Indent);
				_Output.Write ("<<username>@<<domain> format established in [~RFC822].\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example Alice selects {1} as her \n{0}", _Indent, CreateExamples.NameService);
				_Output.Write ("portal provider and chooses the account name {1}.\n{0}", _Indent, CreateExamples.NameAccount);
				_Output.Write ("Her portal account identifier is {1}.\n{0}", _Indent, CreateExamples.NameAccount);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A user MAY establish accounts with multiple portal providers\n{0}", _Indent);
				_Output.Write ("and/or change their portal provider at any time they choose.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Checking Account Identifier for uniqueness\n{0}", _Indent);
				 var Point = Example.Traces.Get (Example.LabelValidate);
				 Example.Traces.Level = 0;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The first step in creating a new account is to check to see if the\n{0}", _Indent);
				_Output.Write ("chosen account identifier is available. This allows a client to \n{0}", _Indent);
				_Output.Write ("validate user input and if necessary warn the user that they need \n{0}", _Indent);
				_Output.Write ("to choose a new account identifier when the data is first entered.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The ValidateRequest message contains the requested account identifier\n{0}", _Indent);
				_Output.Write ("and an optional language parameter to allow the service to provide\n{0}", _Indent);
				_Output.Write ("informative error messages in a language the user understands. The\n{0}", _Indent);
				_Output.Write ("Language field contains a list of ISO language identifier codes \n{0}", _Indent);
				_Output.Write ("in order of preference, most preferred first.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The ValidateResponse message returns the result of the validation\n{0}", _Indent);
				_Output.Write ("request in the Valid field. Note that even if the value true is returned,\n{0}", _Indent);
				_Output.Write ("a subsequent account creation request MAY still fail.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
				_Output.Write ("\n{0}", _Indent);
				 Example.Traces.Level = 5;
				_Output.Write ("[Note that for the sake of concise presentation, the HTTP binding\n{0}", _Indent);
				_Output.Write ("information is omitted from future examples.]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Creating a new user profile\n{0}", _Indent);
				 Point = Example.Traces.Get (Example.LabelCreatePersonal);
				 var CreateRequest = Point.Messages[0].Payload as Goedel.Mesh.Portal.CreateRequest;
				 var SignedProfile = CreateRequest?.Profile as SignedPersonalProfile;
				 var Profile = SignedProfile?.PersonalProfile;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The first step in creating a new personal profile is to create a\n{0}", _Indent);
				_Output.Write ("Master Profile object. This contains the long term Master Signing\n{0}", _Indent);
				_Output.Write ("Key that will remain constant for the life of the profile, at least \n{0}", _Indent);
				_Output.Write ("one Online Signature Key to be used for administering the personal\n{0}", _Indent);
				_Output.Write ("profile and (optionally), one or more master escrow keys.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For convenience, the descriptions of the Master Signing Key, \n{0}", _Indent);
				_Output.Write ("Online Signing Keys and Escrow Keys typically include PKIX \n{0}", _Indent);
				_Output.Write ("certificates signed by the Master Signing Key. This allows \n{0}", _Indent);
				_Output.Write ("PKIX based applications to make use of PKIX certificate chains\n{0}", _Indent);
				_Output.Write ("to express the same trust relationships described in the Mesh.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Profile?.MasterProfile));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Master Profile is always signed using the Master Signing Key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Profile?.SignedMasterProfile));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the device used to create the personal profile is typically\n{0}", _Indent);
				_Output.Write ("connected to the profile, a Device profile entry is created \n{0}", _Indent);
				_Output.Write ("for it. This contains a Device Signing Key, a Device Encryption Key\n{0}", _Indent);
				_Output.Write ("and a Device Authentication Key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 var DeviceProfile = Profile?.Devices[0];
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (DeviceProfile?.SignedData));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Device Profile is signed using the Device Signing Key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (DeviceProfile));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A personal profile would typically contain at least one application\n{0}", _Indent);
				_Output.Write ("when first created. For the sake of demonstration, we will do this later.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The personal profile thus consists of the master profile and \n{0}", _Indent);
				_Output.Write ("the device profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Profile));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The personal profile is then signed using the Online Signing Key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (SignedProfile));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Publishing a new user profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Once the signed personal profile is created, the client can finaly\n{0}", _Indent);
				_Output.Write ("make the request for the service to create the account. The request object \n{0}", _Indent);
				_Output.Write ("contains the requested account identifier and profile:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service reports the success (or failure) of the account creation\n{0}", _Indent);
				_Output.Write ("request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Connecting a device profile to a user profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Connecting a device to a profile requires the client on the new\n{0}", _Indent);
				_Output.Write ("device to interact with a client on a device that has administration capabilities,\n{0}", _Indent);
				_Output.Write ("i.e. it has access to an Online Signing Key. Since clients cannot \n{0}", _Indent);
				_Output.Write ("interact directly with other clients, a service is required to \n{0}", _Indent);
				_Output.Write ("mediate the connection. This service is provided by a Mesh portal\n{0}", _Indent);
				_Output.Write ("provider.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("All service transactions are initiated by the clients. First the \n{0}", _Indent);
				_Output.Write ("connecting device posts ConnectStart, after which it may poll for the\n{0}", _Indent);
				_Output.Write ("outcome of the connection request using ConnectStatus.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Periodically, the Administration Device polls for a list of pending\n{0}", _Indent);
				_Output.Write ("connection requests using ConnectPending. After posting a request,\n{0}", _Indent);
				_Output.Write ("the administration device posts the result using ConnectComplete:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Connecting                  Mesh                 Administration\n{0}", _Indent);
				_Output.Write ("  Device                   Service                   Device\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("	|                         |                         |\n{0}", _Indent);
				_Output.Write ("	|      ConnectStart       |                         |\n{0}", _Indent);
				_Output.Write ("	| ----------------------> |                         |\n{0}", _Indent);
				_Output.Write ("	|                         |      ConnectPending     |\n{0}", _Indent);
				_Output.Write ("	|                         | <---------------------- |\n{0}", _Indent);
				_Output.Write ("	|                         |                         |\n{0}", _Indent);
				_Output.Write ("	|                         |      ConnectComplete    |\n{0}", _Indent);
				_Output.Write ("	|                         | <---------------------- |\n{0}", _Indent);
				_Output.Write ("	|      ConnectStatus      |                         |\n{0}", _Indent);
				_Output.Write ("	| ----------------------> |                         |\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The first step in the process is for the client to generate a\n{0}", _Indent);
				_Output.Write ("device profile. Ideally the device profile is bound to the device\n{0}", _Indent);
				_Output.Write ("in a read-only fashion such that applications running on the \n{0}", _Indent);
				_Output.Write ("device can make use of the deencryption and authentication keys\n{0}", _Indent);
				_Output.Write ("but these private keys cannot be extracted from the device:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.Shell2.DeviceProfile));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device profile is then signed:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.Shell2.DeviceProfile.SignedDeviceProfile));
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Profile Authentication\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("One of the main architecutral principles of the Mesh is \n{0}", _Indent);
				_Output.Write ("bilateral authentication. Every device that is connected to a \n{0}", _Indent);
				_Output.Write ("Mesh profile MUST authenticate the profile it is connecting\n{0}", _Indent);
				_Output.Write ("to and every Mesh profile administrator MUST authenticate devices\n{0}", _Indent);
				_Output.Write ("that are connected.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having created the necessary profile, the device MUST verify \n{0}", _Indent);
				_Output.Write ("that it is connecting to the correct Mesh profile. The best \n{0}", _Indent);
				_Output.Write ("mechanism for achieving this purpose depends on the capabilities \n{0}", _Indent);
				_Output.Write ("of the device being connected. The administration device \n{0}", _Indent);
				_Output.Write ("obviously requires some means of communicating with the \n{0}", _Indent);
				_Output.Write ("user to serve its function. But the device being connected may\n{0}", _Indent);
				_Output.Write ("have a limited display capability or no user interaction \n{0}", _Indent);
				_Output.Write ("capability at all.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("####Interactive Devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the device has user input and display capabilities, it can\n{0}", _Indent);
				_Output.Write ("verify that it is connecting to the correct display by first\n{0}", _Indent);
				_Output.Write ("requesting the user enter the portal account of the profile \n{0}", _Indent);
				_Output.Write ("they wish to connect to, retreiving the profile associated \n{0}", _Indent);
				_Output.Write ("with the device and displaying the profile fingerprint. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Point = Example.Traces.Get (Example.LabelConnectRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The client requests the profile for the requested account name:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response contains the requested profile information.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having received the profile data, the user can then \n{0}", _Indent);
				_Output.Write ("verify that the device is attempting to \n{0}", _Indent);
				_Output.Write ("connect to the correct profile by verifying that the \n{0}", _Indent);
				_Output.Write ("fingerprint shown by the device attempting to connect is\n{0}", _Indent);
				_Output.Write ("correct.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("####Constrained Interaction Devices\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Connection of an Internet of Things 'IoT' device that does \n{0}", _Indent);
				_Output.Write ("not have the ability to accept user input requires a mechanism\n{0}", _Indent);
				_Output.Write ("by which the user can identify the device they wish to connect \n{0}", _Indent);
				_Output.Write ("to their profile and a mechanism to authenticate the profile \n{0}", _Indent);
				_Output.Write ("to the device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the connecting device has a wired communication capability\n{0}", _Indent);
				_Output.Write ("such as a USB port, this MAY be used to effect the device \n{0}", _Indent);
				_Output.Write ("connection using a standardized interaction profile. But \n{0}", _Indent);
				_Output.Write ("an increasing number of constrained IoT devices are only \n{0}", _Indent);
				_Output.Write ("capable of wireless communication.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Configuration of such devices for the purpose of the Mesh requires\n{0}", _Indent);
				_Output.Write ("that we also consider configuration of the wireless networking\n{0}", _Indent);
				_Output.Write ("capabilities at the same time. The precise mechanism by which \n{0}", _Indent);
				_Output.Write ("this is achieved is therefore outside the scope of this particular \n{0}", _Indent);
				_Output.Write ("document. However prototypes have been built and are being considered\n{0}", _Indent);
				_Output.Write ("that make use of some or all of the following communication techniques:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Wired serial connection (RS232, RS485).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* DHCP signalling.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Machine readable device identifiers (barcodes, QRCodes).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Default device profile installed during manufacture.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Optical communication path using camera on administrative device\n{0}", _Indent);
				_Output.Write ("and status light on connecting device to communicate the device \n{0}", _Indent);
				_Output.Write ("identifier, challenge nonce and confirm profile fingerprint.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("* Speech output on audio capable connecting device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Connection request\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("After the user verifies the device fingerprint as correct, the \n{0}", _Indent);
				_Output.Write ("client posts a device connection request to the portal:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[2].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The portal verifies that the request is accepable and returns \n{0}", _Indent);
				_Output.Write ("the transaction result:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[3].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Administrator Polls Pending Connections\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The client can poll the portal for the status of pending requests\n{0}", _Indent);
				_Output.Write ("at any time (modulo any service throttling restrictions at the \n{0}", _Indent);
				_Output.Write ("service side). But the request status will only change when\n{0}", _Indent);
				_Output.Write ("an update is posted by an administration device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the user is typically connecting a device to their profile,\n{0}", _Indent);
				_Output.Write ("the next step in connecting the device is to start the administration\n{0}", _Indent);
				_Output.Write ("client. When started, the client polls for pending connection \n{0}", _Indent);
				_Output.Write ("requests using ConnectPendingRequest.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Point = Example.Traces.Get (Example.LabelConnectPending);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service responds with a list of pending requests:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Administrator updates and publishes the personal profile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device profile is added to the Personal profile which is\n{0}", _Indent);
				_Output.Write ("then signed by the online signing key. The administration\n{0}", _Indent);
				_Output.Write ("client publishes the updated profile to the Mesh through the\n{0}", _Indent);
				_Output.Write ("portal:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Point = Example.Traces.Get (Example.LabelConnectAccept);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("As usual, the service returns the response code:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Administrator posts completion request.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having accepted the device and connected it to the profile, the\n{0}", _Indent);
				_Output.Write ("administration client creates and signs a connection completion\n{0}", _Indent);
				_Output.Write ("result which is posted to the portal using ConnectCompleteRequest:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[2].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Again, the service returns the response code:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[3].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Connecting device polls for status update.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("As stated previously, the connecting device polls the portal \n{0}", _Indent);
				_Output.Write ("periodically to determine the status of the pending request\n{0}", _Indent);
				_Output.Write ("using ConnectStatusRequest:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Point = Example.Traces.Get (Example.LabelConnectComplete);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the response is that the connection status has not changed,\n{0}", _Indent);
				_Output.Write ("the service MAY return a response that specifies a minimum \n{0}", _Indent);
				_Output.Write ("retry interval. In this case however there is a connection result: \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Should probably unpack further.]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Adding an application profile to a user profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Application profiles are published separately from the \n{0}", _Indent);
				_Output.Write ("personal profile to which they are linked. This allows a \n{0}", _Indent);
				_Output.Write ("device to be given administration capability for a particular\n{0}", _Indent);
				_Output.Write ("application without granting administration capability for \n{0}", _Indent);
				_Output.Write ("the profile itself and the ability to connect additional \n{0}", _Indent);
				_Output.Write ("profiles and devices.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Another advantage of this separation is that an application \n{0}", _Indent);
				_Output.Write ("profile might be managed by a separate party. In an enterprise,\n{0}", _Indent);
				_Output.Write ("the application profile for a user's corporate email account \n{0}", _Indent);
				_Output.Write ("could be managed by the corporate IT department.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A user MAY have multiple application profiles for the same\n{0}", _Indent);
				_Output.Write ("application. If a user has three email accounts, they would \n{0}", _Indent);
				_Output.Write ("have three email application profiles, one for each account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In this example, the user has requested a PaswordProfile to be\n{0}", _Indent);
				_Output.Write ("created. When populated, this records the usernames and passwords\n{0}", _Indent);
				_Output.Write ("for the various Web sites that the user has created accounts at \n{0}", _Indent);
				_Output.Write ("and has requested the Web browser store in the Mesh.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Unlike a traditional password management service, the data stored\n{0}", _Indent);
				_Output.Write ("the Password Profile is encrypted end to end and can only be \n{0}", _Indent);
				_Output.Write ("decrypted by the devices that hold a decryption key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{{Example.PasswordProfile1}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The application profile is published to the Mesh in the same\n{0}", _Indent);
				_Output.Write ("way as any other profile update, via a a Publish transaction:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("% Point = Example.Traces.Get (Example.LabelApplicationWeb1);\n{0}", _Indent);
				_Output.Write ("{{Point.Messages[0].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service returns a status response.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{{Point.Messages[1].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that the degree of verification to be performed by the service\n{0}", _Indent);
				_Output.Write ("when an application profile is published is an open question.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having created the application profile, the administration client\n{0}", _Indent);
				_Output.Write ("adds it to the personal profile and publishes it:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{{Point.Messages[0].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that if the publication was to happen in the reverse order,\n{0}", _Indent);
				_Output.Write ("with the personal profile being published before the application\n{0}", _Indent);
				_Output.Write ("profile, the personal profile might be rejected by the portal for \n{0}", _Indent);
				_Output.Write ("inconsistency as it links to a non existent application profile.\n{0}", _Indent);
				_Output.Write ("Though the value of such a check is debatable. It might well\n{0}", _Indent);
				_Output.Write ("be preferable to not make such checks as it permits an application\n{0}", _Indent);
				_Output.Write ("profile to have a degree of anonymity.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{{Point.Messages[1].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Creating a recovery profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh invites users to put all their data eggs in one cryptographic\n{0}", _Indent);
				_Output.Write ("basket. If the private keys in their master profile are lost, they\n{0}", _Indent);
				_Output.Write ("could lose all their digital assets.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The debate over the desirability of key escrow is a complex one.\n{0}", _Indent);
				_Output.Write ("Not least because voluntary key escrow by the user to protect\n{0}", _Indent);
				_Output.Write ("the user's digital assets is frequently conflated with mechanisms\n{0}", _Indent);
				_Output.Write ("to support 'Lawful Access' through government managed backdoors.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Accidents happen and so do disasters. For most users and most applications,\n{0}", _Indent);
				_Output.Write ("data loss is a much more important concern than data disclosure. The option \n{0}", _Indent);
				_Output.Write ("of using a robust key recovery mechanism is therefore essential for use of \n{0}", _Indent);
				_Output.Write ("strong cryptography is to become ubiquitous.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("There are of course circumstances in which some users may prefer to risk\n{0}", _Indent);
				_Output.Write ("losing some of their data rather than risk disclosure. Since any key recovery\n{0}", _Indent);
				_Output.Write ("infrastructure necessarily introduces the risk of coercion, the\n{0}", _Indent);
				_Output.Write ("choice of whether to use key recovery or not is left to the user to \n{0}", _Indent);
				_Output.Write ("decide.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mesh permits users to escrow their private keys in the Mesh itself\n{0}", _Indent);
				_Output.Write ("in an OfflineEscrowEntry. Such entries are encrypted using the\n{0}", _Indent);
				_Output.Write ("strongest degree of encryption available under a symmetric key. \n{0}", _Indent);
				_Output.Write ("The symmetric key is then in turn split using Shamir secret\n{0}", _Indent);
				_Output.Write ("sharing using an n of m threshold scheme.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The OfflineEscrowEntry identifier is a UDF fingerprint of the symmetric\n{0}", _Indent);
				_Output.Write ("key used to encrypt the data. This guarantees that a party that has the\n{0}", _Indent);
				_Output.Write ("decryption key has the ability to locate the corresponding Escrow\n{0}", _Indent);
				_Output.Write ("entry.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The OfflineEscrowEntry is published using the usual Publish\n{0}", _Indent);
				_Output.Write ("transaction:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Point = Example.Traces.Get (Example.LabelEscrow);
				_Output.Write ("{{Point.Messages[0].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response indicates success or failure:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{{Point.Messages[1].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Recovering a profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To recover a profile, the user MUST supply the necessary number of \n{0}", _Indent);
				_Output.Write ("secret shares. These are then used to calculate the UDF fingerprint\n{0}", _Indent);
				_Output.Write ("to use as the locator in a Get transaction:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Point = Example.Traces.Get (Example.LabelRecover);
				_Output.Write ("{{Point.Messages[0].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the transaction succeeds, GetResponse is returned with the \n{0}", _Indent);
				_Output.Write ("requested data.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{{Point.Messages[1].String()}}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The client can now decrypt the OfflineEscrowEntry to recover the \n{0}", _Indent);
				_Output.Write ("private key(s).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
