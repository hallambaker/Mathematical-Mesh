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
			 SchemaMaster(Example);
			 SchemaDevice(Example);
			 SchemaAccount(Example);
			 SchemaDevicePrivate(Example);
			 SchemaDeviceConnection(Example);
			 SchemaService(Example);
			 SchemaEntryDevice(Example);
			 SchemaEntryContact(Example);
			 SchemaEntryCredential(Example);
			 SchemaEntryNetwork(Example);
			 SchemaEntryBookmark(Example);
			 SchemaEntryTask(Example);
			 SchemaEntrySSH(Example);
			 SchemaEntryMail(Example);
			 SchemaMessageConnection(Example);
			 SchemaMessageContact(Example);
			 SchemaMessageConfirmation(Example);
			 SchemaMessageCompletion(Example);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[This is to be eliminated]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				 var catalogedDevice = AliceProfiles?.CatalogedDevice;
				 var profileDevice = catalogedDevice?.ProfileDevice;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice's Device Profile specifies keys for encryption, signature and exchange:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(profileDevice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				 var resultCreateAccount = ProfileCreateAlice[0].Result as ResultCreateAccount;
				 var profileUser = resultCreateAccount.ProfileUser;
				 var activationUser = resultCreateAccount.ActivationDevice;
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
				 var profileService = response.EnvelopedProfileService.Decode();
				 var profileHost = response.EnvelopedProfileHost.Decode();
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
		// SchemaDevicePrivate
		//
		public static void SchemaDevicePrivate(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaDevicePrivate.md");
			Example._Output = _Output;
			Example._SchemaDevicePrivate(Example);
			}
		public void _SchemaDevicePrivate(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("*****************Remove\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// SchemaDeviceConnection
		//
		public static void SchemaDeviceConnection(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaDeviceConnection.md");
			Example._Output = _Output;
			Example._SchemaDeviceConnection(Example);
			}
		public void _SchemaDeviceConnection(CreateExamples Example) {

				_Output.Write ("*****************Remove\n{0}", _Indent);
					}
		

		//
		// SchemaEntryDevice
		//
		public static void SchemaEntryDevice(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\SchemaEntryDevice.md");
			Example._Output = _Output;
			Example._SchemaEntryDevice(Example);
			}
		public void _SchemaEntryDevice(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, "SchemaEntryDevice".Task("SchemaEntryDevice"));
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

				 Format(ContactGet[0].ResultEntry?.CatalogEntry);
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

				 Format(PasswordGet[0].ResultEntry?.CatalogEntry);
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

				 Format(NetworkGet[0].ResultEntry?.CatalogEntry);
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

				 Format(BookmarkGet[0].ResultEntry?.CatalogEntry);
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

				 Format(CalendarGet[0].ResultEntry?.CatalogEntry);
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

				 Format(SSHCreate[0].ResultSSH?.CatalogEntry);
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

				 Format(MailAdd[0].ResultMail?.CatalogEntry);
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
				 DescribeMessage (ConnectPending[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The initial request is sent to the service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (ConnectPending[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service returns an acknowledgement giving the Witness value. Note that this is not a 'reply'\n{0}", _Indent);
				_Output.Write ("since it comes from the service, not the user.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (ConnectPending[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Note, this mechanism should be revised to ensure that there is perfect forward secrecy. The \n{0}", _Indent);
				_Output.Write ("device should provide a nonce key as a mixin]\n{0}", _Indent);
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
				 DescribeMessage (ContactPending[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice responds with her details:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (ContactPending[0]);
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
				 DescribeMessage (ConfirmPending[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The confirmation response\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (ConfirmPending[0]);
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
				_Output.Write ("can see that it has been read:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (ConfirmGetReject[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
