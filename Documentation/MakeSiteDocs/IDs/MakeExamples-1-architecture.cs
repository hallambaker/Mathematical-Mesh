using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Mesh.Test;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		 public static CreateExamples Instance (StreamWriter output) => new CreateExamples () {_Output = output};
		

		//
		// MakeArchitectureExamples
		//
		public void MakeArchitectureExamples (CreateExamples Example) {
			 Colophon(Example);
			 ArchVariousUDF(Example);
			 ArchitectureCreateMesh(Example);
			 ArchitectureAddAccount(Example);
			 ArchitectureAddService(Example);
			 ArchitectureCredential(Example);
			 ArchitectureConnectDirect(Example);
			 ArchitectureConnectPIN(Example);
			 ArchitectureConnectQR(Example);
			 ArchitectureContactRequest(Example);
			 ArchitectureConnectEARL(Example);
			 ArchitectureRecrypt(Example);
			 ArchitectureEscrow(Example);
			 ArchitectureRecovery(Example);
			 ArchitectureConnectEARL(Example);
			 ArchSIN(Example);
			 ArchitectureContactDefinition(Example);
			}
		

		//
		// ArchVariousUDF
		//
		public static void ArchVariousUDF(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchVariousUDF.md")) {
				Example._ArchVariousUDF(Example);
				}
			}
		public void _ArchVariousUDF(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, Preformat);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFNonce.Key);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFSecret.Key);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFSecret.Shares[0]);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultDigestSHA2.Digest);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultDigestSHA3.Digest);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultCommitSHA2.Digest);
				_Output.Write ("{1}\n{0}", _Indent, Preformat);
					}
		

		//
		// ArchitectureConnectEARL
		//
		public static void ArchitectureConnectEARL(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureConnectEARL.md")) {
				Example._ArchitectureConnectEARL(Example);
				}
			}
		public void _ArchitectureConnectEARL(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, Preformat);
				_Output.Write ("{1}\n{0}", _Indent, Example.DeviceCreateUDF);
				_Output.Write ("{1}\n{0}", _Indent, Preformat);
					}
		

		//
		// ArchSIN
		//
		public static void ArchSIN(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchSIN.md")) {
				Example._ArchSIN(Example);
				}
			}
		public void _ArchSIN(CreateExamples Example) {

				 var aliceSIN = "mm--" + Example.AliceProfileUDF.ToLower();
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>alice@example.com\n{0}", _Indent);
				_Output.Write ("<dd>Alice's regular email address (not a SIN). \n{0}", _Indent);
				_Output.Write ("<dt>alice@{1}.example.com\n{0}", _Indent, aliceSIN);
				_Output.Write ("<dd>A strong email address for Alice that can be used by a regular email client.\n{0}", _Indent);
				_Output.Write ("<dt>alice@example.com.{1}\n{0}", _Indent, aliceSIN);
				_Output.Write ("<dd>A strong email address for Alice that can only used by an email client that can process SINs.\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
					}
		

		//
		// Colophon
		//
		public static void Colophon(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\Colophon.md")) {
				Example._Colophon(Example);
				}
			}
		public void _Colophon(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The examples in this document were created on {1}. \n{0}", _Indent, DateTime.Now.ToString());
				_Output.Write ("Out of {1} examples, {2} were not functional.\n{0}", _Indent, TestCLI.CountTotal, TestCLI.ErrorCountTotal);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Note: Example data is now being produced using the mesh command line tool which is currently\n{0}", _Indent);
				_Output.Write ("substantially less complete than the Mesh reference code it is intended to provide an interface\n{0}", _Indent);
				_Output.Write ("to. As a result, the documentation currently lags the code by more than is usual.]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ArchitectureCreateMesh
		//
		public static void ArchitectureCreateMesh(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureCreateMesh.md")) {
				Example._ArchitectureCreateMesh(Example);
				}
			}
		public void _ArchitectureCreateMesh(CreateExamples Example) {

				  ConsoleExample (Example.ProfileCreateAlice);
					}
		

		//
		// ArchitectureAddAccount
		//
		public static void ArchitectureAddAccount(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureAddAccount.md")) {
				Example._ArchitectureAddAccount(Example);
				}
			}
		public void _ArchitectureAddAccount(CreateExamples Example) {

				  ConsoleExample (Example.CommandsAddAcountAlice);
					}
		

		//
		// ArchitectureAddService
		//
		public static void ArchitectureAddService(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureAddService.md")) {
				Example._ArchitectureAddService(Example);
				}
			}
		public void _ArchitectureAddService(CreateExamples Example) {

				  ConsoleExample (Example.CommandsAddServiceAlice);
					}
		

		//
		// ArchitectureCredential
		//
		public static void ArchitectureCredential(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureCredential.md")) {
				Example._ArchitectureCredential(Example);
				}
			}
		public void _ArchitectureCredential(CreateExamples Example) {

				  ConsoleExample (Example.PasswordSequence);
					}
		

		//
		// ArchitectureConnectDirect
		//
		public static void ArchitectureConnectDirect(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureConnectDirect.md")) {
				Example._ArchitectureConnectDirect(Example);
				}
			}
		public void _ArchitectureConnectDirect(CreateExamples Example) {

				_Output.Write ("The connection request is initiated on the device being connected:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.ConnectRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Using her administration device, Alice gets a list of pending requests. Seeing that\n{0}", _Indent);
				_Output.Write ("there is a pending request matching the witness value presented by the device, Alice\n{0}", _Indent);
				_Output.Write ("accepts it:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Concat (Example.ConnectPending, Example.ConnectAccept) );
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The new device will now synchronize automatically in response to any Mesh commands. For example, \n{0}", _Indent);
				_Output.Write ("listing the password catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.PasswordList2);
					}
		

		//
		// ArchitectureConnectPIN
		//
		public static void ArchitectureConnectPIN(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureConnectPIN.md")) {
				Example._ArchitectureConnectPIN(Example);
				}
			}
		public void _ArchitectureConnectPIN(CreateExamples Example) {

				_Output.Write ("The PIN connection mechanism begins with the issue of the PIN:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.ConnectGetPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The PIN code is transmitted out of band to the device being connected:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.ConnectPin);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since the request was pre-authorized, it is not necessary for Alice to explicitly\n{0}", _Indent);
				_Output.Write ("accept the connection request but the administration device is needed to create\n{0}", _Indent);
				_Output.Write ("the connection assertion:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.ConnectPending3);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("We can check the device connection by attempting to synchronize to the profile account:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.ConnectSyncPIN);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Note that this connection mechanism could be adapted to allow a device with a \n{0}", _Indent);
				_Output.Write ("camera affordance to connect by scanning a QR code on the administration device.\n{0}", _Indent);
					}
		

		//
		// ArchitectureConnectQR
		//
		public static void ArchitectureConnectQR(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureConnectQR.md")) {
				Example._ArchitectureConnectQR(Example);
				}
			}
		public void _ArchitectureConnectQR(CreateExamples Example) {

				_Output.Write ("To use the device QR code connection mechanism, we require a Web service that will host\n{0}", _Indent);
				_Output.Write ("the connection document {1} and a MeshService account that the device will attempt to \n{0}", _Indent, EARLService);
				_Output.Write ("complete the connection by requesting synchronization {1}.\n{0}", _Indent, PollService);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To begin the process we generate a new random key and combine it with the service\n{0}", _Indent);
				_Output.Write ("to create an EARL:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, DeviceCreateUDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Next a device profile is created and preregistered on with the Mesh Service that will\n{0}", _Indent);
				_Output.Write ("provide the hailing service. Since we are only preparing one device it is convenient to\n{0}", _Indent);
				_Output.Write ("do this on the device itself. In a manufacturing scenario, these steps would typically \n{0}", _Indent);
				_Output.Write ("be performed offline in bulk.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.DeviceEarl1);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Once initialized the device attempts to poll the service for a connection each time it\n{0}", _Indent);
				_Output.Write ("is powered on, when a connection button affordance on the device is pressed or at\n{0}", _Indent);
				_Output.Write ("other times as agreed with the Mesh Service Provider:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.DeviceEarl2);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To connect the device to her profile, Alice scans the device with her administration \n{0}", _Indent);
				_Output.Write ("device to obtain the UDF. The administration device retrieves the connection description, \n{0}", _Indent);
				_Output.Write ("decrypts it and then uses the information in the description to create the necessary\n{0}", _Indent);
				_Output.Write ("Device Connection Assertion and connect to the device hailing Mesh Service Account to \n{0}", _Indent);
				_Output.Write ("complete the process:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.DeviceEarl3);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When the device next attempts to connect to the hailing service, it receives the Device \n{0}", _Indent);
				_Output.Write ("Connection Assertion:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.DeviceEarl4);
					}
		

		//
		// ArchitectureContactDefinition
		//
		public static void ArchitectureContactDefinition(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureContactDefinition.md")) {
				Example._ArchitectureContactDefinition(Example);
				}
			}
		public void _ArchitectureContactDefinition(CreateExamples Example) {

				_Output.Write ("Alice creates a contact entry for herself:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.ContactAddSelf);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ArchitectureContactRequest
		//
		public static void ArchitectureContactRequest(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureContactRequest.md")) {
				Example._ArchitectureContactRequest(Example);
				}
			}
		public void _ArchitectureContactRequest(CreateExamples Example) {

				_Output.Write ("Bob requests Alice add him to her contacts catalog:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.ContactRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When Alice next checks her messages, she sees the pending contact request from Bob and accepts\n{0}", _Indent);
				_Output.Write ("it. Bob's contact details are added to her catalog and Bob receives a response containing\n{0}", _Indent);
				_Output.Write ("Alice's credentials:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Concat (Example.ContactPending, Example.ContactAccept));
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ArchitectureRecrypt
		//
		public static void ArchitectureRecrypt(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureRecrypt.md")) {
				Example._ArchitectureRecrypt(Example);
				}
			}
		public void _ArchitectureRecrypt(CreateExamples Example) {

				_Output.Write ("Alice creates the recryption group {1} to share confidential information with\n{0}", _Indent, GroupService);
				_Output.Write ("her closest friends:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.GroupCreate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob encrypts a test file but he can't decrypt it because he isn't in the group:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.GroupEncrypt);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since she is the group administrator, Alice can decrypt the\n{0}", _Indent);
				_Output.Write ("test file using the group decryption key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.GroupDecryptAlice);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Adding Bob to the group gives him immediate access to any file encrypted under\n{0}", _Indent);
				_Output.Write ("the group key without making any change to the encrypted files:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.GroupDecryptBob2);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Removing Bob from the group immediately withdraws his access.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.GroupDelete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob cannot decrypt any more files (but he may have kept copies of files he decrypted \n{0}", _Indent);
				_Output.Write ("earlier).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Example.GroupDecryptBob3);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ArchitectureEscrow
		//
		public static void ArchitectureEscrow(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureEscrow.md")) {
				Example._ArchitectureEscrow(Example);
				}
			}
		public void _ArchitectureEscrow(CreateExamples Example) {

				  ConsoleExample (Example.ProfileEscrow);
					}
		

		//
		// ArchitectureRecovery
		//
		public static void ArchitectureRecovery(CreateExamples Example) { /* XFile  */
				using (Example._Output = new StreamWriter("Examples\\ArchitectureRecovery.md")) {
				Example._ArchitectureRecovery(Example);
				}
			}
		public void _ArchitectureRecovery(CreateExamples Example) {

				  ConsoleExample (Example.ProfileRecover);
					}
		}
	}
