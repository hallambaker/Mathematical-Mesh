using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
using  Goedel.Mesh.Shell;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// MakeSchemaExamples
		//
		public void MakeSchemaExamples (CreateExamples Example) {
			 SchemaAliceProfile(Example);
			 SchemaAliceDeviceCoffee(Example);
			 SchemaAliceActivationCoffee(Example);
			 SchemaConnectionCoffee(Example);
			 SchemaAliceActivationWatch(Example);
			 SchemaProfileService(Example);
			 SchemaConnectionHost(Example);
			 SchemaEntrySSH(Example);
			 SchemaEntryMail(Example);
			 SchemaEntryContact(Example);
			 SchemaEntryCredential(Example);
			 SchemaEntryNetwork(Example);
			 SchemaEntryTask(Example);
			 SchemaDeriveTables(Example);
			 SchemaMessageIds(Example);
			 SchemaPINFunction(Example);
			 SchemaPINWitness(Example);
			 SchemaClientAuthKeyAgreement(Example);
			 SchemaDevice(Example);
			 SchemaAccount(Example);
			 SchemaService(Example);
			 SchemaMessageCompletion(Example);
			 SchemaMessageConnection(Example);
			 SchemaMessageContact(Example);
			 SchemaMessageConfirmation(Example);
			}
		

		//
		// DescribeMessage
		//
		public void DescribeMessage (Goedel.Mesh.Message message) {
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("<div=\"helptext\">\n{0}", _Indent);
			_Output.Write ("<over>\n{0}", _Indent);
			_Output.Write ("[NYI]\n{0}", _Indent);
			_Output.Write ("<over>\n{0}", _Indent);
			_Output.Write ("</div>\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			}
		

		//
		// SchemaAliceProfile
		//
		public static void SchemaAliceProfile(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaAliceProfile.md");
			Example._Output = _Output;
			Example._SchemaAliceProfile(Example);
			}
		public void _SchemaAliceProfile(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, the personal account profile Alice created is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  Format (AliceProfileAccount);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaAliceDeviceCoffee
		//
		public static void SchemaAliceDeviceCoffee(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaAliceDeviceCoffee.md");
			Example._Output = _Output;
			Example._SchemaAliceDeviceCoffee(Example);
			}
		public void _SchemaAliceDeviceCoffee(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				  Format (Connect.AliceProfileDeviceCoffee);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaAliceActivationCoffee
		//
		public static void SchemaAliceActivationCoffee(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaAliceActivationCoffee.md");
			Example._Output = _Output;
			Example._SchemaAliceActivationCoffee(Example);
			}
		public void _SchemaAliceActivationCoffee(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				  Format (Connect.AliceActivationDeviceCoffee);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaConnectionCoffee
		//
		public static void SchemaConnectionCoffee(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaConnectionCoffee.md");
			Example._Output = _Output;
			Example._SchemaConnectionCoffee(Example);
			}
		public void _SchemaConnectionCoffee(CreateExamples Example) {

				  Format (Connect.AliceConnectionDeviceCoffee);
					}
		

		//
		// SchemaAliceActivationWatch
		//
		public static void SchemaAliceActivationWatch(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaAliceActivationWatch.md");
			Example._Output = _Output;
			Example._SchemaAliceActivationWatch(Example);
			}
		public void _SchemaAliceActivationWatch(CreateExamples Example) {

				  Format (Connect.AliceActivationDeviceWatch);
					}
		

		//
		// SchemaProfileService
		//
		public static void SchemaProfileService(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaProfileService.md");
			Example._Output = _Output;
			Example._SchemaProfileService(Example);
			}
		public void _SchemaProfileService(CreateExamples Example) {

				  Format (Service.ProfileService);
					}
		

		//
		// SchemaConnectionHost
		//
		public static void SchemaConnectionHost(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaConnectionHost.md");
			Example._Output = _Output;
			Example._SchemaConnectionHost(Example);
			}
		public void _SchemaConnectionHost(CreateExamples Example) {

				  Format (Service.ConnectionHost);
					}
		

		//
		// SchemaEntrySSH
		//
		public static void SchemaEntrySSH(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntrySSH.md");
			Example._Output = _Output;
			Example._SchemaEntrySSH(Example);
			}
		public void _SchemaEntrySSH(CreateExamples Example) {

				 Format(Apps.SSHCatalogEntry);
					}
		

		//
		// SchemaEntryMail
		//
		public static void SchemaEntryMail(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntryMail.md");
			Example._Output = _Output;
			Example._SchemaEntryMail(Example);
			}
		public void _SchemaEntryMail(CreateExamples Example) {

				 Format(Apps.MailCatalogEntry);
					}
		

		//
		// SchemaEntryBookmark
		//
		public static void SchemaEntryBookmark(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntryBookmark.md");
			Example._Output = _Output;
			Example._SchemaEntryBookmark(Example);
			}
		public void _SchemaEntryBookmark(CreateExamples Example) {

				 Format(Apps.BookmarkCatalogEntry);
					}
		

		//
		// SchemaEntryContact
		//
		public static void SchemaEntryContact(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntryContact.md");
			Example._Output = _Output;
			Example._SchemaEntryContact(Example);
			}
		public void _SchemaEntryContact(CreateExamples Example) {

				 Format(Apps.ContactCatalogEntry);
					}
		

		//
		// SchemaEntryCredential
		//
		public static void SchemaEntryCredential(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntryCredential.md");
			Example._Output = _Output;
			Example._SchemaEntryCredential(Example);
			}
		public void _SchemaEntryCredential(CreateExamples Example) {

				 Format(Apps.CredentialCatalogEntry);
					}
		

		//
		// SchemaEntryNetwork
		//
		public static void SchemaEntryNetwork(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntryNetwork.md");
			Example._Output = _Output;
			Example._SchemaEntryNetwork(Example);
			}
		public void _SchemaEntryNetwork(CreateExamples Example) {

				 Format(Apps.CredentialNetworkEntry);
					}
		

		//
		// SchemaEntryTask
		//
		public static void SchemaEntryTask(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntryTask.md");
			Example._Output = _Output;
			Example._SchemaEntryTask(Example);
			}
		public void _SchemaEntryTask(CreateExamples Example) {

				 Format(Apps.TaskCatalogEntry);
					}
		

		//
		// SchemaDeriveTables
		//
		public static void SchemaDeriveTables(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaDeriveTables.md");
			Example._Output = _Output;
			Example._SchemaDeriveTables(Example);
			}
		public void _SchemaDeriveTables(CreateExamples Example) {

					}
		

		//
		// SchemaMessageIds
		//
		public static void SchemaMessageIds(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaMessageIds.md");
			Example._Output = _Output;
			Example._SchemaMessageIds(Example);
			}
		public void _SchemaMessageIds(CreateExamples Example) {

				_Output.Write ("[To be specified]\n{0}", _Indent);
					}
		

		//
		// SchemaPINFunction
		//
		public static void SchemaPINFunction(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaPINFunction.md");
			Example._Output = _Output;
			Example._SchemaPINFunction(Example);
			}
		public void _SchemaPINFunction(CreateExamples Example) {

				_Output.Write ("[To be specified]\n{0}", _Indent);
					}
		

		//
		// SchemaPINWitness
		//
		public static void SchemaPINWitness(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaPINWitness.md");
			Example._Output = _Output;
			Example._SchemaPINWitness(Example);
			}
		public void _SchemaPINWitness(CreateExamples Example) {

				_Output.Write ("[To be specified]\n{0}", _Indent);
					}
		

		//
		// SchemaClientAuthKeyAgreement
		//
		public static void SchemaClientAuthKeyAgreement(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaClientAuthKeyAgreement.md");
			Example._Output = _Output;
			Example._SchemaClientAuthKeyAgreement(Example);
			}
		public void _SchemaClientAuthKeyAgreement(CreateExamples Example) {

				_Output.Write ("[To be specified]\n{0}", _Indent);
					}
		

		//
		// SchemaMaster
		//
		public static void SchemaMaster(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaMaster.md");
			Example._Output = _Output;
			Example._SchemaMaster(Example);
			}
		public void _SchemaMaster(CreateExamples Example) {

				 Format(AliceProfileAccount);
					}
		

		//
		// SchemaDevice
		//
		public static void SchemaDevice(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaDevice.md");
			Example._Output = _Output;
			Example._SchemaDevice(Example);
			}
		public void _SchemaDevice(CreateExamples Example) {

				 Format(AliceProfileDeviceCoffee);
					}
		

		//
		// SchemaAccount
		//
		public static void SchemaAccount(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaAccount.md");
			Example._Output = _Output;
			Example._SchemaAccount(Example);
			}
		public void _SchemaAccount(CreateExamples Example) {

				 var resultCreateAccount = ProfileCreateAlice?[0].Result as ResultCreateAccount;
				 var profileUser = resultCreateAccount?.ProfileAccount;
				 var activationUser = resultCreateAccount?.ActivationDevice;
				 var catalogedDevice = AliceProfiles?.CatalogedDevice;
				 var connectionUser = catalogedDevice?.ConnectionUser;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The account profile specifies the online and offline signature keys used to maintain the\n{0}", _Indent);
				_Output.Write ("profile and the encryption key to be used by the account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(profileUser);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Each device connected to the account requires an activation record. This specifies the \n{0}", _Indent);
				_Output.Write ("key contribtions added to the manufacturer device profile keys:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(activationUser);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The resulting key set is specified in the device connection:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(connectionUser);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("All the above plus the ProfileDevice are combined to form the CatalogedDevice entry:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(catalogedDevice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaService
		//
		public static void SchemaService(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaService.md");
			Example._Output = _Output;
			Example._SchemaService(Example);
			}
		public void _SchemaService(CreateExamples Example) {

				 var response = ResultHello?.Response;
				 var profileService = response?.EnvelopedProfileService.Decode();
				 var profileHost = response?.EnvelopedProfileHost.Decode();
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(profileService);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The host also has a profile\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(profileHost);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("And there should be a connection of the host to the service but this isn't implemented yet:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(null);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaMessageCompletion
		//
		public static void SchemaMessageCompletion(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaMessageCompletion.md");
			Example._Output = _Output;
			Example._SchemaMessageCompletion(Example);
			}
		public void _SchemaMessageCompletion(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having processed a message, a completion message is added to the spool so that other devices \n{0}", _Indent);
				_Output.Write ("can see that it has been read.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, when Alice reads the connection request from the device in the architecture \n{0}", _Indent);
				_Output.Write ("examples, a completion message is added to Alice's inbound spool so that the device is not \n{0}", _Indent);
				_Output.Write ("activated a second time by mistake:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Connect.ConnectPINCompleteWitness);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaMessageConnection
		//
		public static void SchemaMessageConnection(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaMessageConnection.md");
			Example._Output = _Output;
			Example._SchemaMessageConnection(Example);
			}
		public void _SchemaMessageConnection(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The connection process begins with the assignment of a time-limited PIN value. This is\n{0}", _Indent);
				_Output.Write ("described in a Message sent by the administration device to allow other admin devices\n{0}", _Indent);
				_Output.Write ("to accept the request made.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Connect.ConnectPINMessagePin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The initial request is sent to the service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Connect.ConnectRequestWitness);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service returns an acknowledgement giving the Witness value. Note that this is not a 'reply'\n{0}", _Indent);
				_Output.Write ("since it comes from the service, not the user.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Connect.AcknowledgeConnectionWitness);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaMessageContact
		//
		public static void SchemaMessageContact(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaMessageContact.md");
			Example._Output = _Output;
			Example._SchemaMessageContact(Example);
			}
		public void _SchemaMessageContact(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob asks Alice to send her contact details and sends his.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Contact.BobRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice responds with her details:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Contact.AliceResponse);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Note that this exchange could be performed automatically on Alice's behalf by the service if she \n{0}", _Indent);
				_Output.Write ("delegates this action to it.]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaMessageConfirmation
		//
		public static void SchemaMessageConfirmation(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaMessageConfirmation.md");
			Example._Output = _Output;
			Example._SchemaMessageConfirmation(Example);
			}
		public void _SchemaMessageConfirmation(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The confirmation request\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Confirm.RequestConfirmation);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The confirmation response\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Confirm.ResponseConfirmation);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
