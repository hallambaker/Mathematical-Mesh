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
		// ExamplesAdvancedSplitting
		//
		public static void ExamplesAdvancedSplitting (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesAdvancedSplitting.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Example: Securing a recovery record\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to protect her recovery record using a set of five key shares, three of which\n{0}", _Indent);
				_Output.Write ("will be required to recover the key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice's master secret is\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecoveryMaster);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The master secret is converted to an integer applying network byte order conventions.\n{0}", _Indent);
				_Output.Write ("Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.\n{0}", _Indent);
				_Output.Write ("The resulting value becomes the polynomial value a0.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since a threshold of {1} shares is required, we will need a third order polynomial.\n{0}", _Indent, Example.AdvancedRecoveryThreshold);
				_Output.Write ("The co-efficients of the polynomial a1, a2, a3 are random numbers smaller than the \n{0}", _Indent);
				_Output.Write ("modulus:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecoveryPolynomial);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The master secret is the value f(0). The key shares are the values f(1), f(2)...f(5):\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecoveryShareValues);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The first byte of each share specifies the recovery information (quorum, x value), the\n{0}", _Indent);
				_Output.Write ("remaining bytes specify the share value in network byte order:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecoverySharesHex);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The key shares are encoded in Base32 for user presentation:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecoveryBase32);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To recover the value f(0) from any three shares, we need to fit a polynomial curve to \n{0}", _Indent);
				_Output.Write ("the three points and use it to calculate the value at x=0 using the Lagrange polynomial\n{0}", _Indent);
				_Output.Write ("basis.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// ExamplesAdvancedCoGeneration
		//
		public static void ExamplesAdvancedCoGeneration (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesAdvancedCoGeneration.md")) {
				var _Indent = ""; 
				_Output.Write ("##Example: Provisioning the Confirmation Service\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Alice provisions the confirmation service to her watch. The device profile\n{0}", _Indent);
				_Output.Write ("of the watch specifies an Ed25519 signature key. Note that for production use, Ed448 is\n{0}", _Indent);
				_Output.Write ("almost certainly prefered but Ed25519 has the advantage of more compact presentation.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedCogenDeviceProfile);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device could generate a signature key for the device and encrypt it\n{0}", _Indent);
				_Output.Write ("under the encryption key of the device. But this means that we cannot attribute signatures\n{0}", _Indent);
				_Output.Write ("to the watch with absolute certainty as the provisioning device has had knowledge of the \n{0}", _Indent);
				_Output.Write ("watch signature key. Nor do we wish to use the device signature key for the confirmation\n{0}", _Indent);
				_Output.Write ("service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Instead, the provisioning device generates a companion keypair. A random seed is generated.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedCogenPrivateKeySeed);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A key derrivation function (HKDF) is used to derrive a 255 bit secret scalar.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedCogenPrivateKeyValue);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device can calculate the public key of the composite keypair\n{0}", _Indent);
				_Output.Write ("by adding the public keys of the device profile and the companion public key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedCogenCompositeKey);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device encrypts the private key of the comanion keypair under the encryption\n{0}", _Indent);
				_Output.Write ("key of the device. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedCogenPrivateKeySeedEncrypted);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The provisioning device calculates the private key of the composite keypair by \n{0}", _Indent);
				_Output.Write ("adding the two private key values and verifies that scalar multiplication of\n{0}", _Indent);
				_Output.Write ("the base point returns the composite public key value.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// ExamplesAdvancedRecryption
		//
		public static void ExamplesAdvancedRecryption (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesAdvancedRecryption.md")) {
				var _Indent = ""; 
				_Output.Write ("##Example: Messaging group\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice creates a recryption group. The group encryption and signature key parameters are:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionGroup);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To verify the proper function of the group, Alice creates a test message and \n{0}", _Indent);
				_Output.Write ("encrypts it under the group key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionMessagePlaintext);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionMessageEncrypted);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to add Bob to the group. Bob's recryption profile is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionBobProfile);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The decryption key is specified in the same way as any other Ed25519 private key\n{0}", _Indent);
				_Output.Write ("using the hash of a private key seed value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionBobDecryptionKey);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The the recryption key is the group secret scalar minus  (mod p)  the secret scalar of Bob's\n{0}", _Indent);
				_Output.Write ("private key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionBobRecryptionKey);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Recryption entry consists of Bob's address, the recryption key and the decryption\n{0}", _Indent);
				_Output.Write ("key encrypted under Bob's encryption key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionBobRecryptionEntry);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The group administration tool creates a notification request to tell Bob that\n{0}", _Indent);
				_Output.Write ("he has been made a member of the new group and signs it using the group signature\n{0}", _Indent);
				_Output.Write ("key. The recryption entry and the notification are then sent to the recryption\n{0}", _Indent);
				_Output.Write ("service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionRecryptionAddMemberRequest);
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
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionRecryptionRecryptionRequest);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The plaintext of the response contains the additional information Bob's Web browser\n{0}", _Indent);
				_Output.Write ("needs to complete the decryption process:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionRecryptionRecryptionResponse);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Web browser decrypts the private key and uses it to calculate the decryption \n{0}", _Indent);
				_Output.Write ("value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionDecryptionValue);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The key agreement value is obtained by point addition of the recryption and decryption\n{0}", _Indent);
				_Output.Write ("values:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedRecryptionKeyAgreementValue);
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
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedQuantumMasterSecret);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To enable recovery of the master key, Alice creates five keyshares with a quorum of three:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedQuantumShares);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice uses the master secret to derrive her private key values:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedQuantumPrivate);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("These values are used to generate the public key value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedQuantumPublic);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The QRSF contains the UDF fingerprint of the public key\n{0}", _Indent);
				_Output.Write ("value plus the XMSS parameters:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.AdvancedQuantumPublicUDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice adds the QRSF to her profile and publishes it to a Mesh Service that is enrolled\n{0}", _Indent);
				_Output.Write ("in at least one multi-party notary scheme.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
