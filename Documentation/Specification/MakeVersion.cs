// #using System.Text 
using  System.Text;
// #using Goedel.Mesh 
using  Goedel.Mesh;
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
		// #method MeshExamplesWeb CreateExamples Example 
		

		//
		// MeshExamplesWeb
		//
		public void MeshExamplesWeb (CreateExamples Example) {
			//  
			_Output.Write ("\n{0}", _Indent);
			// ##Password Management 
			_Output.Write ("#Password Management\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alice decides to use the Mesh to manage her Web usernames and passwords. 
			_Output.Write ("Alice decides to use the Mesh to manage her Web usernames and passwords.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// She creates two accounts: 
			_Output.Write ("She creates two accounts:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * example.com: username 'alice', password 'secret' 
			_Output.Write ("* example.com: username 'alice', password 'secret'\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * cnn.com: username 'alice1', password 'secret' 
			_Output.Write ("* cnn.com: username 'alice1', password 'secret'\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The JSON encoding of the password data is as follows: 
			_Output.Write ("The JSON encoding of the password data is as follows:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Example.PasswordProfilePrivate1} 
			_Output.Write ("{1}\n{0}", _Indent, Example.PasswordProfilePrivate1);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The JSON encoded password data is then encrypted and stored in an 
			_Output.Write ("The JSON encoded password data is then encrypted and stored in an\n{0}", _Indent);
			// application profile as follows: 
			_Output.Write ("application profile as follows:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Example.PasswordProfile} 
			_Output.Write ("{1}\n{0}", _Indent, Example.PasswordProfile);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// As we saw earlier, Alice really needs to start using stronger passwords.  
			_Output.Write ("As we saw earlier, Alice really needs to start using stronger passwords. \n{0}", _Indent);
			// Fortunately, having access to a password manager means that Alice doesn't 
			_Output.Write ("Fortunately, having access to a password manager means that Alice doesn't\n{0}", _Indent);
			// need to remember different passwords for every site she uses any more. 
			_Output.Write ("need to remember different passwords for every site she uses any more.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// In addition to offering to use the Mesh to remember passwords, a Web 
			_Output.Write ("In addition to offering to use the Mesh to remember passwords, a Web\n{0}", _Indent);
			// browser can offer to automatically generate a password for a site. 
			_Output.Write ("browser can offer to automatically generate a password for a site.\n{0}", _Indent);
			// This can be a much stronger password than the user would normally want 
			_Output.Write ("This can be a much stronger password than the user would normally want\n{0}", _Indent);
			// to choose if they had to remember it. 
			_Output.Write ("to choose if they had to remember it.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alice chooses to use password generation. Her password manager profile is 
			_Output.Write ("Alice chooses to use password generation. Her password manager profile is\n{0}", _Indent);
			// updated to reflect this new choice. 
			_Output.Write ("updated to reflect this new choice.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Example.PasswordProfilePrivate2} 
			_Output.Write ("{1}\n{0}", _Indent, Example.PasswordProfilePrivate2);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Alice is happy to use the password manager for her general Web sites but 
			_Output.Write ("Alice is happy to use the password manager for her general Web sites but\n{0}", _Indent);
			// not for the password she uses to log in to her bank account. When asked 
			_Output.Write ("not for the password she uses to log in to her bank account. When asked\n{0}", _Indent);
			// if the password should be stored in the Mesh, Alice declines and asks  
			_Output.Write ("if the password should be stored in the Mesh, Alice declines and asks \n{0}", _Indent);
			// not to be asked in the future. 
			_Output.Write ("not to be asked in the future.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Example.PasswordProfilePrivate3} 
			_Output.Write ("{1}\n{0}", _Indent, Example.PasswordProfilePrivate3);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #end method 
			}
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
			// [Account request does not specify the portal in the request body, 
			_Output.Write ("[Account request does not specify the portal in the request body,\n{0}", _Indent);
			// only the HTTP package includes this information. This is probably a bug.] 
			_Output.Write ("only the HTTP package includes this information. This is probably a bug.]\n{0}", _Indent);
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
			// <<username>@<<domain> format established in [~RFC822]. 
			_Output.Write ("<<username>@<<domain> format established in [~RFC822].\n{0}", _Indent);
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
			// #% var Point = Example.Traces.Get (Example.LabelValidate); 
			 var Point = Example.Traces.Get (Example.LabelValidate);
			// #% Example.Traces.Level = 0; 
			 Example.Traces.Level = 0;
			//  
			_Output.Write ("\n{0}", _Indent);
			// The first step in creating a new account is to check to see if the 
			_Output.Write ("The first step in creating a new account is to check to see if the\n{0}", _Indent);
			// chosen account identifier is available. This allows a client to  
			_Output.Write ("chosen account identifier is available. This allows a client to \n{0}", _Indent);
			// validate user input and if necessary warn the user that they need  
			_Output.Write ("validate user input and if necessary warn the user that they need \n{0}", _Indent);
			// to choose a new account identifier when the data is first entered. 
			_Output.Write ("to choose a new account identifier when the data is first entered.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The ValidateRequest message contains the requested account identifier 
			_Output.Write ("The ValidateRequest message contains the requested account identifier\n{0}", _Indent);
			// and an optional language parameter to allow the service to provide 
			_Output.Write ("and an optional language parameter to allow the service to provide\n{0}", _Indent);
			// informative error messages in a language the user understands. The 
			_Output.Write ("informative error messages in a language the user understands. The\n{0}", _Indent);
			// Language field contains a list of ISO language identifier codes  
			_Output.Write ("Language field contains a list of ISO language identifier codes \n{0}", _Indent);
			// in order of preference, most preferred first. 
			_Output.Write ("in order of preference, most preferred first.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The ValidateResponse message returns the result of the validation 
			_Output.Write ("The ValidateResponse message returns the result of the validation\n{0}", _Indent);
			// request in the Valid field. Note that even if the value true is returned, 
			_Output.Write ("request in the Valid field. Note that even if the value true is returned,\n{0}", _Indent);
			// a subsequent account creation request MAY still fail. 
			_Output.Write ("a subsequent account creation request MAY still fail.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
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
			// ####Creating a new user profile 
			_Output.Write ("##Creating a new user profile\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelCreatePersonal); 
			 Point = Example.Traces.Get (Example.LabelCreatePersonal);
			// #% Point = Example.Traces.Get (Example.LabelCreatePersonal); 
			 Point = Example.Traces.Get (Example.LabelCreatePersonal);
			// #% var CreateRequest = Point.Messages[0].Payload as Goedel.Mesh.CreateRequest; 
			 var CreateRequest = Point.Messages[0].Payload as Goedel.Mesh.CreateRequest;
			// #% var SignedProfile = CreateRequest.Profile as SignedPersonalProfile; 
			 var SignedProfile = CreateRequest.Profile as SignedPersonalProfile;
			// #% var Profile = SignedProfile.Signed; 
			 var Profile = SignedProfile.PersonalProfile;
			//  
			_Output.Write ("\n{0}", _Indent);
			// The first step in creating a new personal profile is to create a 
			_Output.Write ("The first step in creating a new personal profile is to create a\n{0}", _Indent);
			// Master Profile object. This contains the long term Master Signing 
			_Output.Write ("Master Profile object. This contains the long term Master Signing\n{0}", _Indent);
			// Key that will remain constant for the life of the profile, at least  
			_Output.Write ("Key that will remain constant for the life of the profile, at least \n{0}", _Indent);
			// one Online Signature Key to be used for administering the personal 
			_Output.Write ("one Online Signature Key to be used for administering the personal\n{0}", _Indent);
			// profile and (optionally), one or more master escrow keys. 
			_Output.Write ("profile and (optionally), one or more master escrow keys.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// For convenience, the descriptions of the Master Signing Key,  
			_Output.Write ("For convenience, the descriptions of the Master Signing Key, \n{0}", _Indent);
			// Online Signing Keys and Escrow Keys typically include PKIX  
			_Output.Write ("Online Signing Keys and Escrow Keys typically include PKIX \n{0}", _Indent);
			// certificates signed by the Master Signing Key. This allows  
			_Output.Write ("certificates signed by the Master Signing Key. This allows \n{0}", _Indent);
			// PKIX based applications to make use of PKIX certificate chains 
			_Output.Write ("PKIX based applications to make use of PKIX certificate chains\n{0}", _Indent);
			// to express the same trust relationships described in the Mesh. 
			_Output.Write ("to express the same trust relationships described in the Mesh.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (Profile.PersonalMasterProfile)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Profile.PersonalMasterProfile));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Master Profile is always signed using the Master Signing Key: 
			_Output.Write ("The Master Profile is always signed using the Master Signing Key:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (Profile.SignedMasterProfile)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Profile.SignedMasterProfile));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Since the device used to create the personal profile is typically 
			_Output.Write ("Since the device used to create the personal profile is typically\n{0}", _Indent);
			// connected to the profile, a Device profile entry is created  
			_Output.Write ("connected to the profile, a Device profile entry is created \n{0}", _Indent);
			// for it. This contains a Device Signing Key, a Device Encryption Key 
			_Output.Write ("for it. This contains a Device Signing Key, a Device Encryption Key\n{0}", _Indent);
			// and a Device Authentication Key: 
			_Output.Write ("and a Device Authentication Key:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% var DeviceProfile = Profile.Devices[0]; 
			 var DeviceProfile = Profile.Devices[0];
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (DeviceProfile.Data)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (DeviceProfile.DeviceProfile));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Device Profile is signed using the Device Signing Key: 
			_Output.Write ("The Device Profile is signed using the Device Signing Key:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (DeviceProfile)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (DeviceProfile));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A personal profile would typically contain at least one application 
			_Output.Write ("A personal profile would typically contain at least one application\n{0}", _Indent);
			// when first created. For the sake of demonstration, we will do this later. 
			_Output.Write ("when first created. For the sake of demonstration, we will do this later.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The personal profile thus consists of the master profile and  
			_Output.Write ("The personal profile thus consists of the master profile and \n{0}", _Indent);
			// the device profile: 
			_Output.Write ("the device profile:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (Profile)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Profile));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The personal profile is then signed using the Online Signing Key: 
			_Output.Write ("The personal profile is then signed using the Online Signing Key:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (SignedProfile)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (SignedProfile));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Publishing a new user profile 
			_Output.Write ("###Publishing a new user profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Once the signed personal profile is created, the client can finaly 
			_Output.Write ("Once the signed personal profile is created, the client can finaly\n{0}", _Indent);
			// make the request for the service to create the account. The request object  
			_Output.Write ("make the request for the service to create the account. The request object \n{0}", _Indent);
			// contains the requested account identifier and profile: 
			_Output.Write ("contains the requested account identifier and profile:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service reports the success (or failure) of the account creation 
			_Output.Write ("The service reports the success (or failure) of the account creation\n{0}", _Indent);
			// request: 
			_Output.Write ("request:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Connecting a device profile to a user profile 
			_Output.Write ("##Connecting a device profile to a user profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Connecting a device to a profile requires the client on the new 
			_Output.Write ("Connecting a device to a profile requires the client on the new\n{0}", _Indent);
			// device to interact with a client on a device that has administration capabilities, 
			_Output.Write ("device to interact with a client on a device that has administration capabilities,\n{0}", _Indent);
			// i.e. it has access to an Online Signing Key. Since clients cannot  
			_Output.Write ("i.e. it has access to an Online Signing Key. Since clients cannot \n{0}", _Indent);
			// interact directly with other clients, a service is required to  
			_Output.Write ("interact directly with other clients, a service is required to \n{0}", _Indent);
			// mediate the connection. This service is provided by a Mesh portal 
			_Output.Write ("mediate the connection. This service is provided by a Mesh portal\n{0}", _Indent);
			// provider. 
			_Output.Write ("provider.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// All service transactions are initiated by the clients. First the  
			_Output.Write ("All service transactions are initiated by the clients. First the \n{0}", _Indent);
			// connecting device posts ConnectStart, after which it may poll for the 
			_Output.Write ("connecting device posts ConnectStart, after which it may poll for the\n{0}", _Indent);
			// outcome of the connection request using ConnectStatus. 
			_Output.Write ("outcome of the connection request using ConnectStatus.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Periodically, the Administration Device polls for a list of pending 
			_Output.Write ("Periodically, the Administration Device polls for a list of pending\n{0}", _Indent);
			// connection requests using ConnectPending. After posting a request, 
			_Output.Write ("connection requests using ConnectPending. After posting a request,\n{0}", _Indent);
			// the administration device posts the result using ConnectComplete: 
			_Output.Write ("the administration device posts the result using ConnectComplete:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// Connecting                  Mesh                 Administration 
			_Output.Write ("Connecting                  Mesh                 Administration\n{0}", _Indent);
			//   Device                   Service                   Device 
			_Output.Write ("  Device                   Service                   Device\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// 	|                         |                         | 
			_Output.Write ("	|                         |                         |\n{0}", _Indent);
			// 	|      ConnectStart       |                         | 
			_Output.Write ("	|      ConnectStart       |                         |\n{0}", _Indent);
			// 	| ----------------------> |                         | 
			_Output.Write ("	| ----------------------> |                         |\n{0}", _Indent);
			// 	|                         |      ConnectPending     | 
			_Output.Write ("	|                         |      ConnectPending     |\n{0}", _Indent);
			// 	|                         | <---------------------- | 
			_Output.Write ("	|                         | <---------------------- |\n{0}", _Indent);
			// 	|                         |                         | 
			_Output.Write ("	|                         |                         |\n{0}", _Indent);
			// 	|                         |      ConnectComplete    | 
			_Output.Write ("	|                         |      ConnectComplete    |\n{0}", _Indent);
			// 	|                         | <---------------------- | 
			_Output.Write ("	|                         | <---------------------- |\n{0}", _Indent);
			// 	|      ConnectStatus      |                         | 
			_Output.Write ("	|      ConnectStatus      |                         |\n{0}", _Indent);
			// 	| ----------------------> |                         | 
			_Output.Write ("	| ----------------------> |                         |\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The first step in the process is for the client to generate a 
			_Output.Write ("The first step in the process is for the client to generate a\n{0}", _Indent);
			// device profile. Ideally the device profile is bound to the device 
			_Output.Write ("device profile. Ideally the device profile is bound to the device\n{0}", _Indent);
			// in a read-only fashion such that applications running on the  
			_Output.Write ("in a read-only fashion such that applications running on the \n{0}", _Indent);
			// device can make use of the deencryption and authentication keys 
			_Output.Write ("device can make use of the deencryption and authentication keys\n{0}", _Indent);
			// but these private keys cannot be extracted from the device: 
			_Output.Write ("but these private keys cannot be extracted from the device:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (Example.SignedDeviceProfile2.Data)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.SignedDeviceProfile2.DeviceProfile));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The device profile is then signed: 
			_Output.Write ("The device profile is then signed:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{JSONDebugWriter.Write (Example.SignedDeviceProfile2)} 
			_Output.Write ("{1}\n{0}", _Indent, JSONDebugWriter.Write (Example.SignedDeviceProfile2));
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Profile Authentication 
			_Output.Write ("###Profile Authentication\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// One of the main architecutral principles of the Mesh is  
			_Output.Write ("One of the main architecutral principles of the Mesh is \n{0}", _Indent);
			// bilateral authentication. Every device that is connected to a  
			_Output.Write ("bilateral authentication. Every device that is connected to a \n{0}", _Indent);
			// Mesh profile MUST authenticate the profile it is connecting 
			_Output.Write ("Mesh profile MUST authenticate the profile it is connecting\n{0}", _Indent);
			// to and every Mesh profile administrator MUST authenticate devices 
			_Output.Write ("to and every Mesh profile administrator MUST authenticate devices\n{0}", _Indent);
			// that are connected. 
			_Output.Write ("that are connected.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Having created the necessary profile, the device MUST verify  
			_Output.Write ("Having created the necessary profile, the device MUST verify \n{0}", _Indent);
			// that it is connecting to the correct Mesh profile. The best  
			_Output.Write ("that it is connecting to the correct Mesh profile. The best \n{0}", _Indent);
			// mechanism for achieving this purpose depends on the capabilities  
			_Output.Write ("mechanism for achieving this purpose depends on the capabilities \n{0}", _Indent);
			// of the device being connected. The administration device  
			_Output.Write ("of the device being connected. The administration device \n{0}", _Indent);
			// obviously requires some means of communicating with the  
			_Output.Write ("obviously requires some means of communicating with the \n{0}", _Indent);
			// user to serve its function. But the device being connected may 
			_Output.Write ("user to serve its function. But the device being connected may\n{0}", _Indent);
			// have a limited display capability or no user interaction  
			_Output.Write ("have a limited display capability or no user interaction \n{0}", _Indent);
			// capability at all. 
			_Output.Write ("capability at all.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ########Interactive Devices 
			_Output.Write ("####Interactive Devices\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// If the device has user input and display capabilities, it can 
			_Output.Write ("If the device has user input and display capabilities, it can\n{0}", _Indent);
			// verify that it is connecting to the correct display by first 
			_Output.Write ("verify that it is connecting to the correct display by first\n{0}", _Indent);
			// requesting the user enter the portal account of the profile  
			_Output.Write ("requesting the user enter the portal account of the profile \n{0}", _Indent);
			// they wish to connect to, retreiving the profile associated  
			_Output.Write ("they wish to connect to, retreiving the profile associated \n{0}", _Indent);
			// with the device and displaying the profile fingerprint.  
			_Output.Write ("with the device and displaying the profile fingerprint. \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelConnectRequest); 
			 Point = Example.Traces.Get (Example.LabelConnectRequest);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The client requests the profile for the requested account name: 
			_Output.Write ("The client requests the profile for the requested account name:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The response contains the requested profile information. 
			_Output.Write ("The response contains the requested profile information.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Having received the profile data, the user can then  
			_Output.Write ("Having received the profile data, the user can then \n{0}", _Indent);
			// verify that the device is attempting to  
			_Output.Write ("verify that the device is attempting to \n{0}", _Indent);
			// connect to the correct profile by verifying that the  
			_Output.Write ("connect to the correct profile by verifying that the \n{0}", _Indent);
			// fingerprint shown by the device attempting to connect is 
			_Output.Write ("fingerprint shown by the device attempting to connect is\n{0}", _Indent);
			// correct. 
			_Output.Write ("correct.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #########Constrained Interaction Devices 
			_Output.Write ("####Constrained Interaction Devices\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Connection of an Internet of Things 'IoT' device that does  
			_Output.Write ("Connection of an Internet of Things 'IoT' device that does \n{0}", _Indent);
			// not have the ability to accept user input requires a mechanism 
			_Output.Write ("not have the ability to accept user input requires a mechanism\n{0}", _Indent);
			// by which the user can identify the device they wish to connect  
			_Output.Write ("by which the user can identify the device they wish to connect \n{0}", _Indent);
			// to their profile and a mechanism to authenticate the profile  
			_Output.Write ("to their profile and a mechanism to authenticate the profile \n{0}", _Indent);
			// to the device. 
			_Output.Write ("to the device.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// If the connecting device has a wired communication capability 
			_Output.Write ("If the connecting device has a wired communication capability\n{0}", _Indent);
			// such as a USB port, this MAY be used to effect the device  
			_Output.Write ("such as a USB port, this MAY be used to effect the device \n{0}", _Indent);
			// connection using a standardized interaction profile. But  
			_Output.Write ("connection using a standardized interaction profile. But \n{0}", _Indent);
			// an increasing number of constrained IoT devices are only  
			_Output.Write ("an increasing number of constrained IoT devices are only \n{0}", _Indent);
			// capable of wireless communication. 
			_Output.Write ("capable of wireless communication.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Configuration of such devices for the purpose of the Mesh requires 
			_Output.Write ("Configuration of such devices for the purpose of the Mesh requires\n{0}", _Indent);
			// that we also consider configuration of the wireless networking 
			_Output.Write ("that we also consider configuration of the wireless networking\n{0}", _Indent);
			// capabilities at the same time. The precise mechanism by which  
			_Output.Write ("capabilities at the same time. The precise mechanism by which \n{0}", _Indent);
			// this is achieved is therefore outside the scope of this particular  
			_Output.Write ("this is achieved is therefore outside the scope of this particular \n{0}", _Indent);
			// document. However prototypes have been built and are being considered 
			_Output.Write ("document. However prototypes have been built and are being considered\n{0}", _Indent);
			// that make use of some or all of the following communication techniques: 
			_Output.Write ("that make use of some or all of the following communication techniques:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Wired serial connection (RS232, RS485). 
			_Output.Write ("* Wired serial connection (RS232, RS485).\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * DHCP signalling. 
			_Output.Write ("* DHCP signalling.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Machine readable device identifiers (barcodes, QRCodes). 
			_Output.Write ("* Machine readable device identifiers (barcodes, QRCodes).\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Default device profile installed during manufacture. 
			_Output.Write ("* Default device profile installed during manufacture.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Optical communication path using camera on administrative device 
			_Output.Write ("* Optical communication path using camera on administrative device\n{0}", _Indent);
			// and status light on connecting device to communicate the device  
			_Output.Write ("and status light on connecting device to communicate the device \n{0}", _Indent);
			// identifier, challenge nonce and confirm profile fingerprint. 
			_Output.Write ("identifier, challenge nonce and confirm profile fingerprint.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// * Speech output on audio capable connecting device. 
			_Output.Write ("* Speech output on audio capable connecting device.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Connection request 
			_Output.Write ("###Connection request\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// After the user verifies the device fingerprint as correct, the  
			_Output.Write ("After the user verifies the device fingerprint as correct, the \n{0}", _Indent);
			// client posts a device connection request to the portal: 
			_Output.Write ("client posts a device connection request to the portal:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[2].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[2].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The portal verifies that the request is accepable and returns  
			_Output.Write ("The portal verifies that the request is accepable and returns \n{0}", _Indent);
			// the transaction result: 
			_Output.Write ("the transaction result:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[3].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[3].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Administrator Polls Pending Connections 
			_Output.Write ("###Administrator Polls Pending Connections\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The client can poll the portal for the status of pending requests 
			_Output.Write ("The client can poll the portal for the status of pending requests\n{0}", _Indent);
			// at any time (modulo any service throttling restrictions at the  
			_Output.Write ("at any time (modulo any service throttling restrictions at the \n{0}", _Indent);
			// service side). But the request status will only change when 
			_Output.Write ("service side). But the request status will only change when\n{0}", _Indent);
			// an update is posted by an administration device. 
			_Output.Write ("an update is posted by an administration device.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Since the user is typically connecting a device to their profile, 
			_Output.Write ("Since the user is typically connecting a device to their profile,\n{0}", _Indent);
			// the next step in connecting the device is to start the administration 
			_Output.Write ("the next step in connecting the device is to start the administration\n{0}", _Indent);
			// client. When started, the client polls for pending connection  
			_Output.Write ("client. When started, the client polls for pending connection \n{0}", _Indent);
			// requests using ConnectPendingRequest. 
			_Output.Write ("requests using ConnectPendingRequest.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelConnectPending); 
			 Point = Example.Traces.Get (Example.LabelConnectPending);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service responds with a list of pending requests: 
			_Output.Write ("The service responds with a list of pending requests:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Administrator updates and publishes the personal profile. 
			_Output.Write ("###Administrator updates and publishes the personal profile.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The device profile is added to the Personal profile which is 
			_Output.Write ("The device profile is added to the Personal profile which is\n{0}", _Indent);
			// then signed by the online signing key. The administration 
			_Output.Write ("then signed by the online signing key. The administration\n{0}", _Indent);
			// client publishes the updated profile to the Mesh through the 
			_Output.Write ("client publishes the updated profile to the Mesh through the\n{0}", _Indent);
			// portal: 
			_Output.Write ("portal:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelConnectPublish); 
			 Point = Example.Traces.Get (Example.LabelConnectPublish);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// As usual, the service returns the response code: 
			_Output.Write ("As usual, the service returns the response code:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Administrator posts completion request. 
			_Output.Write ("###Administrator posts completion request.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Having accepted the device and connected it to the profile, the 
			_Output.Write ("Having accepted the device and connected it to the profile, the\n{0}", _Indent);
			// administration client creates and signs a connection completion 
			_Output.Write ("administration client creates and signs a connection completion\n{0}", _Indent);
			// result which is posted to the portal using ConnectCompleteRequest: 
			_Output.Write ("result which is posted to the portal using ConnectCompleteRequest:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelConnectAccept); 
			 Point = Example.Traces.Get (Example.LabelConnectAccept);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Again, the service returns the response code: 
			_Output.Write ("Again, the service returns the response code:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// ######Connecting device polls for status update. 
			_Output.Write ("###Connecting device polls for status update.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// As stated previously, the connecting device polls the portal  
			_Output.Write ("As stated previously, the connecting device polls the portal \n{0}", _Indent);
			// periodically to determine the status of the pending request 
			_Output.Write ("periodically to determine the status of the pending request\n{0}", _Indent);
			// using ConnectStatusRequest: 
			_Output.Write ("using ConnectStatusRequest:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelConnectStatus); 
			 Point = Example.Traces.Get (Example.LabelConnectStatus);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// If the response is that the connection status has not changed, 
			_Output.Write ("If the response is that the connection status has not changed,\n{0}", _Indent);
			// the service MAY return a response that specifies a minimum  
			_Output.Write ("the service MAY return a response that specifies a minimum \n{0}", _Indent);
			// retry interval. In this case however there is a connection result:  
			_Output.Write ("retry interval. In this case however there is a connection result: \n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// [Should probably unpack further.] 
			_Output.Write ("[Should probably unpack further.]\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Adding an application profile to a user profile 
			_Output.Write ("##Adding an application profile to a user profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Application profiles are published separately from the  
			_Output.Write ("Application profiles are published separately from the \n{0}", _Indent);
			// personal profile to which they are linked. This allows a  
			_Output.Write ("personal profile to which they are linked. This allows a \n{0}", _Indent);
			// device to be given administration capability for a particular 
			_Output.Write ("device to be given administration capability for a particular\n{0}", _Indent);
			// application without granting administration capability for  
			_Output.Write ("application without granting administration capability for \n{0}", _Indent);
			// the profile itself and the ability to connect additional  
			_Output.Write ("the profile itself and the ability to connect additional \n{0}", _Indent);
			// profiles and devices. 
			_Output.Write ("profiles and devices.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Another advantage of this separation is that an application  
			_Output.Write ("Another advantage of this separation is that an application \n{0}", _Indent);
			// profile might be managed by a separate party. In an enterprise, 
			_Output.Write ("profile might be managed by a separate party. In an enterprise,\n{0}", _Indent);
			// the application profile for a user's corporate email account  
			_Output.Write ("the application profile for a user's corporate email account \n{0}", _Indent);
			// could be managed by the corporate IT department. 
			_Output.Write ("could be managed by the corporate IT department.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// A user MAY have multiple application profiles for the same 
			_Output.Write ("A user MAY have multiple application profiles for the same\n{0}", _Indent);
			// application. If a user has three email accounts, they would  
			_Output.Write ("application. If a user has three email accounts, they would \n{0}", _Indent);
			// have three email application profiles, one for each account. 
			_Output.Write ("have three email application profiles, one for each account.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// In this example, the user has requested a PaswordProfile to be 
			_Output.Write ("In this example, the user has requested a PaswordProfile to be\n{0}", _Indent);
			// created. When populated, this records the usernames and passwords 
			_Output.Write ("created. When populated, this records the usernames and passwords\n{0}", _Indent);
			// for the various Web sites that the user has created accounts at  
			_Output.Write ("for the various Web sites that the user has created accounts at \n{0}", _Indent);
			// and has requested the Web browser store in the Mesh. 
			_Output.Write ("and has requested the Web browser store in the Mesh.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Unlike a traditional password management service, the data stored 
			_Output.Write ("Unlike a traditional password management service, the data stored\n{0}", _Indent);
			// the Password Profile is encrypted end to end and can only be  
			_Output.Write ("the Password Profile is encrypted end to end and can only be \n{0}", _Indent);
			// decrypted by the devices that hold a decryption key. 
			_Output.Write ("decrypted by the devices that hold a decryption key.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			// #{Example.PasswordProfile} 
			_Output.Write ("{1}\n{0}", _Indent, Example.PasswordProfile);
			// ~~~~ 
			_Output.Write ("~~~~\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The application profile is published to the Mesh in the same 
			_Output.Write ("The application profile is published to the Mesh in the same\n{0}", _Indent);
			// way as any other profile update, via a a Publish transaction: 
			_Output.Write ("way as any other profile update, via a a Publish transaction:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelApplicationPublish); 
			 Point = Example.Traces.Get (Example.LabelApplicationPublish);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The service returns a status response. 
			_Output.Write ("The service returns a status response.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Note that the degree of verification to be performed by the service 
			_Output.Write ("Note that the degree of verification to be performed by the service\n{0}", _Indent);
			// when an application profile is published is an open question. 
			_Output.Write ("when an application profile is published is an open question.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// Having created the application profile, the administration client 
			_Output.Write ("Having created the application profile, the administration client\n{0}", _Indent);
			// adds it to the personal profile and publishes it: 
			_Output.Write ("adds it to the personal profile and publishes it:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelApplicationProfile); 
			 Point = Example.Traces.Get (Example.LabelApplicationProfile);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// Note that if the publication was to happen in the reverse order, 
			_Output.Write ("Note that if the publication was to happen in the reverse order,\n{0}", _Indent);
			// with the personal profile being published before the application 
			_Output.Write ("with the personal profile being published before the application\n{0}", _Indent);
			// profile, the personal profile might be rejected by the portal for  
			_Output.Write ("profile, the personal profile might be rejected by the portal for \n{0}", _Indent);
			// inconsistency as it links to a non existent application profile. 
			_Output.Write ("inconsistency as it links to a non existent application profile.\n{0}", _Indent);
			// Though the value of such a check is debatable. It might well 
			_Output.Write ("Though the value of such a check is debatable. It might well\n{0}", _Indent);
			// be preferable to not make such checks as it permits an application 
			_Output.Write ("be preferable to not make such checks as it permits an application\n{0}", _Indent);
			// profile to have a degree of anonymity. 
			_Output.Write ("profile to have a degree of anonymity.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Creating a recovery profile 
			_Output.Write ("##Creating a recovery profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Mesh invites users to put all their data eggs in one cryptographic 
			_Output.Write ("The Mesh invites users to put all their data eggs in one cryptographic\n{0}", _Indent);
			// basket. If the private keys in their master profile are lost, they 
			_Output.Write ("basket. If the private keys in their master profile are lost, they\n{0}", _Indent);
			// could lose all their digital assets. 
			_Output.Write ("could lose all their digital assets.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The debate over the desirability of key escrow is a complex one. 
			_Output.Write ("The debate over the desirability of key escrow is a complex one.\n{0}", _Indent);
			// Not least because voluntary key escrow by the user to protect 
			_Output.Write ("Not least because voluntary key escrow by the user to protect\n{0}", _Indent);
			// the user's digital assets is frequently conflated with mechanisms 
			_Output.Write ("the user's digital assets is frequently conflated with mechanisms\n{0}", _Indent);
			// to support 'Lawful Access' through government managed backdoors. 
			_Output.Write ("to support 'Lawful Access' through government managed backdoors.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
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
			// infrastructure necessarily introduces the risk of coercion, the 
			_Output.Write ("infrastructure necessarily introduces the risk of coercion, the\n{0}", _Indent);
			// choice of whether to use key recovery or not is left to the user to  
			_Output.Write ("choice of whether to use key recovery or not is left to the user to \n{0}", _Indent);
			// decide. 
			_Output.Write ("decide.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The Mesh permits users to escrow their private keys in the Mesh itself 
			_Output.Write ("The Mesh permits users to escrow their private keys in the Mesh itself\n{0}", _Indent);
			// in an OfflineEscrowEntry. Such entries are encrypted using the 
			_Output.Write ("in an OfflineEscrowEntry. Such entries are encrypted using the\n{0}", _Indent);
			// strongest degree of encryption available under a symmetric key.  
			_Output.Write ("strongest degree of encryption available under a symmetric key. \n{0}", _Indent);
			// The symmetric key is then in turn split using Shamir secret 
			_Output.Write ("The symmetric key is then in turn split using Shamir secret\n{0}", _Indent);
			// sharing using an n of m threshold scheme. 
			_Output.Write ("sharing using an n of m threshold scheme.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The OfflineEscrowEntry identifier is a UDF fingerprint of the symmetric 
			_Output.Write ("The OfflineEscrowEntry identifier is a UDF fingerprint of the symmetric\n{0}", _Indent);
			// key used to encrypt the data. This guarantees that a party that has the 
			_Output.Write ("key used to encrypt the data. This guarantees that a party that has the\n{0}", _Indent);
			// decryption key has the ability to locate the corresponding Escrow 
			_Output.Write ("decryption key has the ability to locate the corresponding Escrow\n{0}", _Indent);
			// entry. 
			_Output.Write ("entry.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// The OfflineEscrowEntry is published using the usual Publish 
			_Output.Write ("The OfflineEscrowEntry is published using the usual Publish\n{0}", _Indent);
			// transaction: 
			_Output.Write ("transaction:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelEscrow); 
			 Point = Example.Traces.Get (Example.LabelEscrow);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The response indicates success or failure: 
			_Output.Write ("The response indicates success or failure:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// ####Recovering a profile 
			_Output.Write ("##Recovering a profile\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// To recover a profile, the user MUST supply the necessary number of  
			_Output.Write ("To recover a profile, the user MUST supply the necessary number of \n{0}", _Indent);
			// secret shares. These are then used to calculate the UDF fingerprint 
			_Output.Write ("secret shares. These are then used to calculate the UDF fingerprint\n{0}", _Indent);
			// to use as the locator in a Get transaction: 
			_Output.Write ("to use as the locator in a Get transaction:\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #% Point = Example.Traces.Get (Example.LabelRecover); 
			 Point = Example.Traces.Get (Example.LabelRecover);
			// #{Point.Messages[0].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[0].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// If the transaction succeeds, GetResponse is returned with the  
			_Output.Write ("If the transaction succeeds, GetResponse is returned with the \n{0}", _Indent);
			// requested data. 
			_Output.Write ("requested data.\n{0}", _Indent);
			//  
			_Output.Write ("\n{0}", _Indent);
			// #{Point.Messages[1].String()} 
			_Output.Write ("{1}\n{0}", _Indent, Point.Messages[1].String());
			//  
			_Output.Write ("\n{0}", _Indent);
			// The client can now decrypt the OfflineEscrowEntry to recover the  
			_Output.Write ("The client can now decrypt the OfflineEscrowEntry to recover the \n{0}", _Indent);
			// private key(s). 
			_Output.Write ("private key(s).\n{0}", _Indent);
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
