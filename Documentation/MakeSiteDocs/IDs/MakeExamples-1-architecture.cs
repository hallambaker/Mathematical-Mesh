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
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	 public static CreateExamples Instance (StreamWriter output) => new CreateExamples () {_Output = output};
	

	//
	// MakeArchitectureExamples
	//
	public void MakeArchitectureExamples (CreateExamples Example) {
		 Colophon(Example);
		 ArchitectureConnectPassword(Example);
		 ArchitectureCreateMesh(Example);
		 ArchitectureEncryptDecrypt(Example);
		 ArchitectureEscrow(Example);
		 ArchitectureRecovery(Example);
		 ArchitectureCredential(Example);
		 ArchitectureConnectDirect(Example);
		 ArchitectureConnectPin(Example);
		 ArchitectureConnectDisconnect(Example);
		 ArchitectureDisconnectWebDecrypts(Example);
		 ArchitectureDisconnectThresholdDecrypts(Example);
		 ArchitectureConfigSSH(Example);
		 ArchitectureContactRemote(Example);
		 ArchitectureConfirm(Example);
		 ArchitectureRecrypt(Example);
		 ArchVariousUDF(Example);
		 ArchitectureConnectEARLRaw(Example);
		 ArchitectureConnectEARL(Example);
		 ArchSIN(Example);
		}
	

	//
	// Colophon
	//
	public static void Colophon(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Colophon.md");
		Example._Output = _Output;
		Example._Colophon(Example);
		}
	public void _Colophon(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The examples in this document were created on {1}. \n{0}", _Indent, DateTime.Now.ToString());
			_Output.Write ("Out of {1} examples,\n{0}", _Indent, TestCLI.CountTotal);
			if (  (TestCLI.ErrorCountTotal ==0) ) {
				_Output.Write ("all passed.\n{0}", _Indent);
				} else {
				_Output.Write ("{1} failed.\n{0}", _Indent, TestCLI.ErrorCountTotal);
				}
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureCreateMesh
	//
	public static void ArchitectureCreateMesh(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureCreateMesh.md");
		Example._Output = _Output;
		Example._ArchitectureCreateMesh(Example);
		}
	public void _ArchitectureCreateMesh(CreateExamples Example) {

			_Output.Write ("The user specifies the initial account address to be used ({1}). Use of this address\n{0}", _Indent, AliceAccount);
			_Output.Write ("is of course dependent on authorization by the Mesh Service Provider ({1})\n{0}", _Indent, MeshServiceProvider);
			_Output.Write ("and is likely to require authentication and possibly payment.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.CreateAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The command returns the value of Alice's Mesh Account fingerprint {1}. \n{0}", _Indent, AliceFingerprint);
			_Output.Write ("This value is used as a unique identifier that is cryptographically bound to the signature key used\n{0}", _Indent);
			_Output.Write ("to authenticate the account profile.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureEncryptDecrypt
	//
	public static void ArchitectureEncryptDecrypt(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureEncryptDecrypt.md");
		Example._Output = _Output;
		Example._ArchitectureEncryptDecrypt(Example);
		}
	public void _ArchitectureEncryptDecrypt(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice encrypts the text file {1} to create an encrypted version\n{0}", _Indent, Account.EncryptSourceFile);
			_Output.Write ("readable only by Alice:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.ConsoleEncryptFile);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice can recover the file at any time using the decryption command:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.ConsoleDecryptFile);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Although the encrypted file can be accessed by Alice with precisely the same ease as the plaintext\n{0}", _Indent);
			_Output.Write ("version, the contents of the encrypted file are not readable by any other user of the machine unless \n{0}", _Indent);
			_Output.Write ("Alice explicitly grants access. The encrypted file may be stored on a shared drive, cloud file system\n{0}", _Indent);
			_Output.Write ("or removable storage without disclosing the contents.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureEscrow
	//
	public static void ArchitectureEscrow(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureEscrow.md");
		Example._Output = _Output;
		Example._ArchitectureEscrow(Example);
		}
	public void _ArchitectureEscrow(CreateExamples Example) {

			  ConsoleExample (Example.Account.ProfileEscrow);
				}
	

	//
	// ArchitectureRecovery
	//
	public static void ArchitectureRecovery(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureRecovery.md");
		Example._Output = _Output;
		Example._ArchitectureRecovery(Example);
		}
	public void _ArchitectureRecovery(CreateExamples Example) {

			_Output.Write ("{1}\n{0}", _Indent, Unfinished ("ArchitectureRecovery"));
			  ConsoleExample (Example.Account.ProfileRecover);
				}
	

	//
	// ArchitectureCredential
	//
	public static void ArchitectureCredential(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureCredential.md");
		Example._Output = _Output;
		Example._ArchitectureCredential(Example);
		}
	public void _ArchitectureCredential(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice adds the username and password she uses to access her weather service account \n{0}", _Indent);
			_Output.Write ("to her credentials catalog:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Account.PasswordAdd);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("As with all Mesh Catalogs, the catalog data is encrypted and cannot be accessed by any unauthorized\n{0}", _Indent);
			_Output.Write ("party including the Mesh Service Provider.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If needed, she can retrieve the credentials from the catalog by specifying the network\n{0}", _Indent);
			_Output.Write ("resource to which access is required:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Account.PasswordGet);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This capability provides a means of preventing one of the most common causes of enterprise password\n{0}", _Indent);
			_Output.Write ("breach in which a system administrator encodes the access credentials for a service into a \n{0}", _Indent);
			_Output.Write ("script used to access the service. A script containing a command to extract the credentials from\n{0}", _Indent);
			_Output.Write ("a Mesh catalog will only work for a user authorized to access the credentials in the Mesh.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureConnectDirect
	//
	public static void ArchitectureConnectDirect(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConnectDirect.md");
		Example._Output = _Output;
		Example._ArchitectureConnectDirect(Example);
		}
	public void _ArchitectureConnectDirect(CreateExamples Example) {

			_Output.Write ("The connection request is initiated on the device being connected:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.ConnectRequest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Using her administration device, Alice gets a list of pending requests. Seeing that\n{0}", _Indent);
			_Output.Write ("there is a pending request matching the witness value presented by the device, Alice\n{0}", _Indent);
			_Output.Write ("accepts the request, granting the new device the messaging and web roles:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Concat (Example.Connect.ConnectPending, Example.Connect.ConnectAccept) );
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice can now synchronize her newly connected device to her account:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.ConnectComplete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureConnectPin
	//
	public static void ArchitectureConnectPin(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConnectPin.md");
		Example._Output = _Output;
		Example._ArchitectureConnectPin(Example);
		}
	public void _ArchitectureConnectPin(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Alice begins the connection process by creating a one time use PIN authentication code \n{0}", _Indent);
			_Output.Write ("on her administration device. The PIN creation request specifies the rights to be granted\n{0}", _Indent);
			_Output.Write ("to the connecting device:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.ConnectPINCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A connection request is made on the connecting device as before except that this time \n{0}", _Indent);
			_Output.Write ("the PIN is specified. This time, only the 'threshold' right is granted.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.ConnectPINRequest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since the connection request is pre-authenticated by the PIN, it is not necessary for \n{0}", _Indent);
			_Output.Write ("Alice to review the connection request. The connection request is accepted \n{0}", _Indent);
			_Output.Write ("automatically when the administration device is synchronized:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.ConnectPINPending);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice can now synchronize her newly connected device to her account:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.ConnectPINComplete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Dynamic QRCode connection scheme uses exactly the same mechanism except that instead \n{0}", _Indent);
			_Output.Write ("of the PIN being presented to Alice in the form of an alphanumeric string, the connection\n{0}", _Indent);
			_Output.Write ("information is encoded as a URI and presented to the connecting device as a QR code.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The URI corresponding to the connection PIN is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Preformat);
			_Output.Write ("{1}\n{0}", _Indent, Connect.ConnectDynamicURI);
			_Output.Write ("{1}\n{0}", _Indent, Preformat);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureConnectPassword
	//
	public static void ArchitectureConnectPassword(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConnectPassword.md");
		Example._Output = _Output;
		Example._ArchitectureConnectPassword(Example);
		}
	public void _ArchitectureConnectPassword(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, because Alice granted the device the Web role, she can now access her credential \n{0}", _Indent);
			_Output.Write ("catalog and decrypt the file she encrypted on her first device from the new device:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.PasswordList2);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureConnectDisconnect
	//
	public static void ArchitectureConnectDisconnect(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConnectDisconnect.md");
		Example._Output = _Output;
		Example._ArchitectureConnectDisconnect(Example);
		}
	public void _ArchitectureConnectDisconnect(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice disconnects the new device:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.Disconnect);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureDisconnectWebDecrypts
	//
	public static void ArchitectureDisconnectWebDecrypts(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureDisconnectWebDecrypts.md");
		Example._Output = _Output;
		Example._ArchitectureDisconnectWebDecrypts(Example);
		}
	public void _ArchitectureDisconnectWebDecrypts(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The device can no longer access the password catalog, but it can still decrypt files:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.PasswordList2Disconnect);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureDisconnectThresholdDecrypts
	//
	public static void ArchitectureDisconnectThresholdDecrypts(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureDisconnectThresholdDecrypts.md");
		Example._Output = _Output;
		Example._ArchitectureDisconnectThresholdDecrypts(Example);
		}
	public void _ArchitectureDisconnectThresholdDecrypts(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The third device was connected with threshold rights, it is disconnected in the same\n{0}", _Indent);
			_Output.Write ("way as before.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.DisconnectThresh);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The device can no longer access the password catalog or decrypt files:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Connect.DisconnectThreshDecrypt);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureConfigSSH
	//
	public static void ArchitectureConfigSSH(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConfigSSH.md");
		Example._Output = _Output;
		Example._ArchitectureConfigSSH(Example);
		}
	public void _ArchitectureConfigSSH(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice creates an SSH profile within her Mesh on the administrative device making the \n{0}", _Indent);
			_Output.Write ("private key information available to devices she has connected to her Mesh with the \n{0}", _Indent);
			_Output.Write ("'web' access right.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Apps.SSHCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("She can extract the private key to configure her SSH clients:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Apps.SSHPrivate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("She can also extract her public key to configure her SSH server to allow access to \n{0}", _Indent);
			_Output.Write ("the machine:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Apps.SSHPublic);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Ideally these steps would be performed on Alice's behalf by an automated script\n{0}", _Indent);
			_Output.Write ("that detects the applications Alice has installed on her device and performs the\n{0}", _Indent);
			_Output.Write ("necessary configuration on her behalf. \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The SSH keys created on one device are available to every device connected by the 'web' access \n{0}", _Indent);
			_Output.Write ("right:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Apps.SSHConnect);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureContactRemote
	//
	public static void ArchitectureContactRemote(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureContactRemote.md");
		Example._Output = _Output;
		Example._ArchitectureContactRemote(Example);
		}
	public void _ArchitectureContactRemote(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address \n{0}", _Indent);
			_Output.Write ("({1}), she does not (yet) have permission to send any message to Bob\n{0}", _Indent, BobAccount);
			_Output.Write ("excepting a request to exchange contact information.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob sends Alice a contact exchange request:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Contact.ContactBobRequest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice checks his Mesh messages and approves Bob's request:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Contact.ContactAliceResponse);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob can now collect Alice's contact:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Contact.ContactBobFinal);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureConfirm
	//
	public static void ArchitectureConfirm(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConfirm.md");
		Example._Output = _Output;
		Example._ArchitectureConfirm(Example);
		}
	public void _ArchitectureConfirm(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice attempts to log into a secure console in the control room. The secure console recognizes \n{0}", _Indent);
			_Output.Write ("Alice but a second factor is required. The console issues a challenge to Alice at her\n{0}", _Indent);
			_Output.Write ("registered account asking if she would like to log into the secure console:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Confirm.ConfirmRequest);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice checks her pending messages and accepts the request:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Confirm.ConfirmAliceResponse);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The secure console verifies the response and grants access:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Confirm.ConfirmVerify);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchitectureRecrypt
	//
	public static void ArchitectureRecrypt(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureRecrypt.md");
		Example._Output = _Output;
		Example._ArchitectureRecrypt(Example);
		}
	public void _ArchitectureRecrypt(CreateExamples Example) {

			_Output.Write ("Alice creates the recryption group {1} to share confidential information with\n{0}", _Indent, GroupAccount);
			_Output.Write ("her closest friends:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Group.GroupCreate);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice encrypts a test file but she can't decrypt it because she hasn't added herself \n{0}", _Indent);
			_Output.Write ("to the group yet.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Group.GroupEncrypt);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice adds herself to the group, now she can decrypt:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Group.GroupAddAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("At this point, Bob can't encrypt or decrypt messages because he doesn't know the \n{0}", _Indent);
			_Output.Write ("public key and he isn't in the group. Alice could allow Bob to encrypt but not\n{0}", _Indent);
			_Output.Write ("decrypt by sending him the group contact information without a decryption share. \n{0}", _Indent);
			_Output.Write ("Instead she adds Bob to the group as a member:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Group.GroupAddBob);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Adding Bob to the group gives him immediate access to any file encrypted under\n{0}", _Indent);
			_Output.Write ("the group key without making any change to the encrypted files:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Group.GroupDecryptBobSuccess);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Removing Bob from the group immediately withdraws his access.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Group.GroupDeleteBob);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob cannot decrypt files encrypted under the group key any more. But he \n{0}", _Indent);
			_Output.Write ("still has access to the file {1} he decrypted earlier.\n{0}", _Indent, Group.GroupDecryptBobFile);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Example.Group.GroupDecryptBobRevoked);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The threshold key service acts as a policy enforcement point and can impose \n{0}", _Indent);
			_Output.Write ("additional accounting and authorization controls on the use of the decryption\n{0}", _Indent);
			_Output.Write ("service.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, the threshold key service might be configured to alert a \n{0}", _Indent);
			_Output.Write ("supervisor and/or deny decryption requests if a group member made an unusual \n{0}", _Indent);
			_Output.Write ("volume of requests in a short period.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// ArchVariousUDF
	//
	public static void ArchVariousUDF(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchVariousUDF.md");
		Example._Output = _Output;
		Example._ArchVariousUDF(Example);
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
	// ArchitectureConnectEARLRaw
	//
	public static void ArchitectureConnectEARLRaw(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConnectEARL-raw.md");
		Example._Output = _Output;
		Example._ArchitectureConnectEARLRaw(Example);
		}
	public void _ArchitectureConnectEARLRaw(CreateExamples Example) {

			_Output.Write ("{1}", _Indent, Connect.ConnectEARL);
				}
	

	//
	// ArchitectureConnectEARL
	//
	public static void ArchitectureConnectEARL(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchitectureConnectEARL.md");
		Example._Output = _Output;
		Example._ArchitectureConnectEARL(Example);
		}
	public void _ArchitectureConnectEARL(CreateExamples Example) {

			_Output.Write ("{1}\n{0}", _Indent, Preformat);
			_Output.Write ("{1}\n{0}", _Indent, Connect.ConnectEARL);
			_Output.Write ("{1}\n{0}", _Indent, Preformat);
				}
	

	//
	// ArchSIN
	//
	public static void ArchSIN(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ArchSIN.md");
		Example._Output = _Output;
		Example._ArchSIN(Example);
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
		}
