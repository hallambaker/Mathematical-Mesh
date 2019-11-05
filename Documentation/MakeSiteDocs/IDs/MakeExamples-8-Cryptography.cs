using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
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
		// MakeCryptographyExamples
		//
		public void MakeCryptographyExamples (CreateExamples Example) {
			 ExamplesAdvancedCoGeneration(Example);
			 ExamplesAdvancedRecryption(Example);
			 ExamplesAdvancedQuantum(Example);
			}
		

		//
		// ExamplesAdvancedCoGeneration
		//
		public static void ExamplesAdvancedCoGeneration (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesAdvancedCoGeneration.md")) {
				var _Indent = ""; 
				_Output.Write ("##Example: Provisioning the Confirmation Service\n{0}", _Indent);
				 var Section = Example.CryptoCombine;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Alice provisions the confirmation service to her watch. The device profile\n{0}", _Indent);
				_Output.Write ("of the watch specifies an Ed25519 signature key. Note that for production use, Ed448 is\n{0}", _Indent);
				_Output.Write ("almost certainly prefered but Ed25519 has the advantage of more compact presentation.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Device Key\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("UDF Seed:       {1}\n{0}", _Indent, Section.SeedAliceDevice);
				_Output.Write ("Private Key:{1}\n{0}", _Indent, Section.KeyPairDevicePrivate.ToStringBase16FormatHex());
				_Output.Write ("Secret Scalar:\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Section.SecretScalarDevice);
				_Output.Write ("Public Key:{1}\n{0}", _Indent, Section.KeyPairDevice.PublicData.ToStringBase16FormatHex());
				_Output.Write ("Fingerprint:    {1}\n{0}", _Indent, Section.KeyPairDevice.UDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device could generate a signature key for the device and encrypt it\n{0}", _Indent);
				_Output.Write ("under the encryption key of the device. But this means that we cannot attribute signatures\n{0}", _Indent);
				_Output.Write ("to the watch with absolute certainty as the provisioning device has had knowledge of the \n{0}", _Indent);
				_Output.Write ("watch signature key. Nor do we wish to use the device signature key for the confirmation\n{0}", _Indent);
				_Output.Write ("service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Instead, the provisioning device generates an overlay keypair:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Device Key\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("UDF Seed:       {1}\n{0}", _Indent, Section.SeedAliceOverlay);
				_Output.Write ("Private Key:{1}\n{0}", _Indent, Section.KeyPairOverlayPrivate.ToStringBase16FormatHex());
				_Output.Write ("Secret Scalar:\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Section.SecretScalarOverlay);
				_Output.Write ("Public Key:{1}\n{0}", _Indent, Section.KeyPairOverlay.PublicData.ToStringBase16FormatHex());
				_Output.Write ("Fingerprint:    {1}\n{0}", _Indent, Section.KeyPairOverlay.UDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device can calculate the public key of the composite keypair\n{0}", _Indent);
				_Output.Write ("by adding the public keys of the device profile and the companion public key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Composite public key = Device + Overlay:{1}\n{0}", _Indent, Section.CombinedPublic.PublicData.ToStringBase16FormatHex());
				_Output.Write ("Fingerprint:    {1}\n{0}", _Indent, Section.CombinedPublic.UDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device encrypts the private key of the comanion keypair (or the seed from which it\n{0}", _Indent);
				_Output.Write ("was generated) under the encryption key of the device. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device calculates the private key of the composite keypair by \n{0}", _Indent);
				_Output.Write ("adding the two private key values modulo the order of the group and verifies that scalar \n{0}", _Indent);
				_Output.Write ("multiplication of the base point returns the composite public key value.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Composite Secret Scalar = Device + Overlay:\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Section.SecretScalarComposite);
				_Output.Write ("Fingerprint:    {1}\n{0}", _Indent, Section.CombinedPrivate.UDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// ExamplesAdvancedRecryption
		//
		public static void ExamplesAdvancedRecryption (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesAdvancedRecryption.md")) {
				var _Indent = ""; 
				 var Section = Example.CryptoGroup;
				_Output.Write ("##Example: Messaging group\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("NB: The current code implements encryption in the Elliptic Curve Ed25519, not the Montgomery\n{0}", _Indent);
				_Output.Write ("Curve X.25519 as it should. This will be lifted in the near future.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice creates an encryption keypair.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Group Key:{1}\n{0}", _Indent, Section.KeyPairGroupPrivate.ToStringBase16FormatHex());
				_Output.Write ("Value:\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Section.KeyPairGroupPrivateInt);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To verify the proper function of the group, Alice creates a test message and \n{0}", _Indent);
				_Output.Write ("encrypts it under the group key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Message = {1} as UTF8:{2}\n{0}", _Indent, Section.PlaintextText, Section.Plaintext.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Section.Envelope);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to add Bob to the group. She creates an encryption key for Bob:\n{0}", _Indent);
				_Output.Write ("The decryption key is specified in the same way as any other Ed25519 private key\n{0}", _Indent);
				_Output.Write ("using the hash of a private key seed value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Bob's Member Key:{1}\n{0}", _Indent, Section.KeyPairDevicePrivate.ToStringBase16FormatHex());
				_Output.Write ("Value:\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Section.KeyPairDevicePrivateInt);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The the recryption key is the group secret scalar minus  (mod p) the secret scalar of Bob's\n{0}", _Indent);
				_Output.Write ("private key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Bob's Service Key:\n{0}", _Indent);
				_Output.Write ("   [Not specified as a digest input value]\n{0}", _Indent);
				_Output.Write ("Value:\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Section.KeyPairServicePrivateInt);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To decrypt:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Member Agreement Value:{1}\n{0}", _Indent, Section.KeyPairDeviceWrapped.PartialDeviceEncoded.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Service Agreement Value:{1}\n{0}", _Indent, Section.KeyPairDeviceWrapped.PartialServiceEncoded.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key Agreement IKM:{1}\n{0}", _Indent, Section.KeyPairDeviceWrapped.Result.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This value allows the test message to be decrypted.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// ExamplesAdvancedQuantum
		//
		public static void ExamplesAdvancedQuantum (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesAdvancedQuantum.md")) {
				var _Indent = ""; 
				_Output.Write ("##Example: Creating a Quantum Resistant Signature Fingerprint\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to add a QRSF to her Mesh Profile. She creates\n{0}", _Indent);
				_Output.Write ("a 256 bit master secret.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedQuantumMasterSecret);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To enable recovery of the master key, Alice creates five keyshares with a quorum of three:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedQuantumShares);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice uses the master secret to derrive her private key values:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedQuantumPrivate);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("These values are used to generate the public key value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedQuantumPublic);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The QRSF contains the UDF fingerprint of the public key\n{0}", _Indent);
				_Output.Write ("value plus the XMSS parameters:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedQuantumPublicUDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice adds the QRSF to her profile and publishes it to a Mesh Service that is enrolled\n{0}", _Indent);
				_Output.Write ("in at least one multi-party notary scheme.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// Blahhh
		//
		public static void Blahhh (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\Blahhh.md")) {
				var _Indent = ""; 
				_Output.Write ("The Recryption entry consists of Bob's address, the recryption key and the decryption\n{0}", _Indent);
				_Output.Write ("key encrypted under Bob's encryption key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedRecryptionBobRecryptionEntry);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The group administration tool creates a notification request to tell Bob that\n{0}", _Indent);
				_Output.Write ("he has been made a member of the new group and signs it using the group signature\n{0}", _Indent);
				_Output.Write ("key. The recryption entry and the notification are then sent to the recryption\n{0}", _Indent);
				_Output.Write ("service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedRecryptionRecryptionAddMemberRequest);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The notification message contains a link to the test message. When he accepts\n{0}", _Indent);
				_Output.Write ("membership of the group, Bob clicks on the link to test that his membership\n{0}", _Indent);
				_Output.Write ("has been fully provisioned. Providing an explicit test mechanism avoids the problem\n{0}", _Indent);
				_Output.Write ("that might otherwise occur in which the message spool fills up with test messages \n{0}", _Indent);
				_Output.Write ("being posted.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bob's Web browser requests the recryption data for the test message. The request is \n{0}", _Indent);
				_Output.Write ("authenticated and encrypted under Bob's device keys. The plaintext of the message is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedRecryptionRecryptionRecryptionRequest);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The plaintext of the response contains the additional information Bob's Web browser\n{0}", _Indent);
				_Output.Write ("needs to complete the decryption process:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedRecryptionRecryptionRecryptionResponse);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Web browser decrypts the private key and uses it to calculate the decryption \n{0}", _Indent);
				_Output.Write ("value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, Example.AdvancedRecryptionDecryptionValue);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The key agreement value is obtained by point addition of the recryption and decryption\n{0}", _Indent);
				_Output.Write ("values:\n{0}", _Indent);
				}
			}
		}
	}