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
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	

	//
	// MakeSchemaExamples
	//
	public void MakeSchemaExamples (CreateExamples Example) {
		 SchemaAliceProfile(Example);
		 SchemaProfileService(Example);
		 SchemaEntryContact(Example);
		 SchemaEntryCredential(Example);
		 SchemaEntryBookmark(Example);
		 SchemaEntryPublication(Example);
		 SchemaEntryNetwork(Example);
		 SchemaEntryTask(Example);
		 SchemaDeriveTables(Example);
		 SchemaMessageIds(Example);
		 SchemaPINFunction(Example);
		 SchemaPINWitness(Example);
		 SchemaClientAuthKeyAgreement(Example);
		 SchemaDevice(Example);
		 DevicePreconfiguration(Example);
		 SchemaCode1(Example);
		 SchemaCode2(Example);
		 SchemaCode3(Example);
		 SchemaAliceDevice2(Example);
		 SchemaAliceActivationDevice2(Example);
		 SchemaAliceConnectionDevice2(Example);
		 SchemaAliceActivationDevice3(Example);
		 SchemaEntrySSH(Example);
		 SchemaEntryMail(Example);
		 SchemaConnectionHost(Example);
		 SchemaAccessCapability(Example);
		 SchemaNullCapability(Example);
		 SchemaEncryptCapability(Example);
		 SchemaPublicationCapability(Example);
		 SchemaSignCapability(Example);
		 SchemaKeyGenCapability(Example);
		 SchemaFairExchangeCapability(Example);
		}
	

	//
	// DescribeMessage
	//
	public void DescribeMessage (Goedel.Mesh.Message message) {
		 if (message == null) { ReportMissingExample(); return;}
		 Format(message);
		}
	

	//
	// SchemaAccessCapability
	//
	public static void SchemaAccessCapability(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaAccessCapability.md");
		Example._Output = _Output;
		Example._SchemaAccessCapability(Example);
		}
	public void _SchemaAccessCapability(CreateExamples Example) {

			 Unfinished ("SchemaAccessCapability");
				}
	

	//
	// SchemaNullCapability
	//
	public static void SchemaNullCapability(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaNullCapability.md");
		Example._Output = _Output;
		Example._SchemaNullCapability(Example);
		}
	public void _SchemaNullCapability(CreateExamples Example) {

			 Unfinished ("SchemaNullCapability");
				}
	

	//
	// SchemaEncryptCapability
	//
	public static void SchemaEncryptCapability(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaEncryptCapability.md");
		Example._Output = _Output;
		Example._SchemaEncryptCapability(Example);
		}
	public void _SchemaEncryptCapability(CreateExamples Example) {

			 Unfinished ("SchemaEncryptCapability");
				}
	

	//
	// SchemaSignCapability
	//
	public static void SchemaSignCapability(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaSignCapability.md");
		Example._Output = _Output;
		Example._SchemaSignCapability(Example);
		}
	public void _SchemaSignCapability(CreateExamples Example) {

			 Unfinished ("SchemaSignCapability");
				}
	

	//
	// SchemaKeyGenCapability
	//
	public static void SchemaKeyGenCapability(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaKeyGenCapability.md");
		Example._Output = _Output;
		Example._SchemaKeyGenCapability(Example);
		}
	public void _SchemaKeyGenCapability(CreateExamples Example) {

			 Unfinished ("SchemaKeyGenCapability");
				}
	

	//
	// SchemaFairExchangeCapability
	//
	public static void SchemaFairExchangeCapability(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaFairExchangeCapability.md");
		Example._Output = _Output;
		Example._SchemaFairExchangeCapability(Example);
		}
	public void _SchemaFairExchangeCapability(CreateExamples Example) {

			 Unfinished ("SchemaFairExchangeCapability");
				}
	

	//
	// SchemaPublicationCapability
	//
	public static void SchemaPublicationCapability(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaPublicationCapability.md");
		Example._Output = _Output;
		Example._SchemaPublicationCapability(Example);
		}
	public void _SchemaPublicationCapability(CreateExamples Example) {

			 Unfinished ("SchemaPublicationCapability");
				}
	

	//
	// SchemaCode1
	//
	public static void SchemaCode1(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaCode1.md");
		Example._Output = _Output;
		Example._SchemaCode1(Example);
		}
	public void _SchemaCode1(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("public static string GetEnvelopeId(string messageID) =>\n{0}", _Indent);
			_Output.Write ("            UDF.ContentDigestOfUDF(messageID);\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// SchemaCode2
	//
	public static void SchemaCode2(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaCode2.md");
		Example._Output = _Output;
		Example._SchemaCode2(Example);
		}
	public void _SchemaCode2(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("static string MakeID(string udf, string content) {{\n{0}", _Indent);
			_Output.Write ("    var (code, bds) = UDF.Parse(udf);\n{0}", _Indent);
			_Output.Write ("    return code switch\n{0}", _Indent);
			_Output.Write ("        {{\n{0}", _Indent);
			_Output.Write ("            UdfTypeIdentifier.Digest_SHA_3_512 => \n{0}", _Indent);
			_Output.Write ("                UDF.ContentDigestOfDataString(\n{0}", _Indent);
			_Output.Write ("                bds, content, cryptoAlgorithmId: \n{0}", _Indent);
			_Output.Write ("                    CryptoAlgorithmId.SHA_3_512),\n{0}", _Indent);
			_Output.Write ("            _ => UDF.ContentDigestOfDataString(\n{0}", _Indent);
			_Output.Write ("            bds, content, cryptoAlgorithmId: \n{0}", _Indent);
			_Output.Write ("                    CryptoAlgorithmId.SHA_2_512),\n{0}", _Indent);
			_Output.Write ("            }};\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// SchemaCode3
	//
	public static void SchemaCode3(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaCode3.md");
		Example._Output = _Output;
		Example._SchemaCode3(Example);
		}
	public void _SchemaCode3(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("alg =           UdfAlg (PIN)\n{0}", _Indent);
			_Output.Write ("pinData =       UdfBDS (PIN)\n{0}", _Indent);
			_Output.Write ("saltedPINData = MAC (Action, pinData)\n{0}", _Indent);
			_Output.Write ("saltedPIN =     UDFPresent (HMAC_SHA_2_512 + saltedPINData)\n{0}", _Indent);
			_Output.Write ("PinId =         UDFPresent (MAC (Account, saltedPINData))\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The issuer of the PIN code stores the value saltedPIN for retrieval using the \n{0}", _Indent);
			_Output.Write ("key PinId.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The witness value for a Dare Envelope with payload digest PayloadDigest \n{0}", _Indent);
			_Output.Write ("authenticated by a PIN code whose salted value is saltedPINData, issued \n{0}", _Indent);
			_Output.Write ("by account Account is given by PinWitness() as follows:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("witnessData =   Account.ToUTF8() + ClientNonce + PayloadDigest\n{0}", _Indent);
			_Output.Write ("witnessValue =  MAC (witnessData , saltedPINData)\n{0}", _Indent);
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
			_Output.Write ("For example, Alice creates a personal account:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Account.CreateAlice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The account profile created is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Format (AliceProfileAccount);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SchemaAliceDevice2
	//
	public static void SchemaAliceDevice2(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaAliceDevice2.md");
		Example._Output = _Output;
		Example._SchemaAliceDevice2(Example);
		}
	public void _SchemaAliceDevice2(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, the device profile corresponding to one of the devices belonging to Alice is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Format (Connect.AliceProfileDevice2);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SchemaAliceActivationDevice2
	//
	public static void SchemaAliceActivationDevice2(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaAliceActivationDevice2.md");
		Example._Output = _Output;
		Example._SchemaAliceActivationDevice2(Example);
		}
	public void _SchemaAliceActivationDevice2(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, Alice connects the device whose profile is shown above to her account:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  ConsoleExample (Connect.ConnectComplete);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The activation record granting the device rights to operate as a part\n{0}", _Indent);
			_Output.Write ("of the account is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Format (Connect.AliceActivationDevice2);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("And:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Format (Connect.AliceActivationAccount2);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SchemaAliceConnectionDevice2
	//
	public static void SchemaAliceConnectionDevice2(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaAliceConnectionDevice2.md");
		Example._Output = _Output;
		Example._SchemaAliceConnectionDevice2(Example);
		}
	public void _SchemaAliceConnectionDevice2(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ConnectionDevice assertion is used by the device to authenticate it to other \n{0}", _Indent);
			_Output.Write ("devices connected to the account. This connection assertion specifies the\n{0}", _Indent);
			_Output.Write ("Encryption, Authentication, and Signature keys the device is to use in the context of\n{0}", _Indent);
			_Output.Write ("the account and the list of roles that have been authorized for the device..\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Format (Connect.AliceConnectionDevice2);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The ConnectionService assertion is used to authenticate the device to the \n{0}", _Indent);
			_Output.Write ("Mesh service. In order to allow the assertion to fit in a single packet, it\n{0}", _Indent);
			_Output.Write ("is important that this assertion be as small as possible. Only the \n{0}", _Indent);
			_Output.Write ("Authentication key is specified.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The corresponding ConnectionService assertion is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Format (Connect.AliceConnectionService2);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SchemaAliceActivationDevice3
	//
	public static void SchemaAliceActivationDevice3(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaAliceActivationDevice3.md");
		Example._Output = _Output;
		Example._SchemaAliceActivationDevice3(Example);
		}
	public void _SchemaAliceActivationDevice3(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			  Format (Connect.AliceActivationAccount3);
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

			_Output.Write ("\n{0}", _Indent);
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

			 Format(Apps.NetworkCatalogEntry);
				}
	

	//
	// SchemaEntryPublication
	//
	public static void SchemaEntryPublication(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaEntryPublication.md");
		Example._Output = _Output;
		Example._SchemaEntryPublication(Example);
		}
	public void _SchemaEntryPublication(CreateExamples Example) {

			_Output.Write ("{1}\n{0}", _Indent, Unfinished ("SchemaEntryPublication"));
			 Format(Apps.PublicationEntry);
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

			 var message = Connect.ConnectRequestPIN;
			 var messageId = message?.MessageId;
			 var envelopeId = message?.EnvelopeId;
			 var responseId = message?.GetResponseId();
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("MessageID \n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, messageId);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("EnvelopeID \n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, envelopeId);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("ResponseID \n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, responseId);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
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

			 var message = Connect.ConnectRequestPIN;
			 var account = message.AccountAddress;
			 var pin = Connect.ConnectPINMessagePin.Pin;
			 var action = MeshConstants.MessagePINActionDevice;
			 var (code,key) = UDF.Parse(pin);
			 var saltedPINData = action.ToUTF8().GetMAC(key, CryptoAlgorithmId.HMAC_SHA_2_512);
			 var saltedPIN = MessagePin.SaltPIN (pin, action);
			 var PinId = MessagePin.GetPinId(pin, account);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, to generate saltedPIN for the pin\n{0}", _Indent);
			_Output.Write ("{1} used to authenticate a an action of type {2}:\n{0}", _Indent, pin, action);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("pin = {1}\n{0}", _Indent, pin);
			_Output.Write ("action = message.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("alg = UdfAlg (PIN)\n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, code);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("hashalg = default (alg, HMAC_SHA_2_512)\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("pinData = UdfBDS (PIN)\n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, key);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("saltedPINData \n{0}", _Indent);
			_Output.Write ("    = hashalg(pinData, hashalg);\n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, saltedPINData);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("saltedPIN = UDFPresent (hashalg + saltedPINData)\n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, saltedPIN);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The PinId binding the pin to the account {1} is\n{0}", _Indent, account);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Account =  {1} \n{0}", _Indent, account);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("PinId = UDFPresent (MAC (Account, saltedPINData))\n{0}", _Indent);
			_Output.Write ("    = {1}\n{0}", _Indent, PinId);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
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

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("witnessData = Account.ToUTF8() + ClientNonce + PayloadDigest\n{0}", _Indent);
			_Output.Write ("witnessValue =  MAC (witnessData , saltedPINData)\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
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

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("[To be specified]\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
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
			_Output.Write ("{1}\n{0}", _Indent, Unfinished ("SchemaMaster"));
			_Output.Write ("\n{0}", _Indent);
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

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Unfinished ("SchemaDevice"));
			_Output.Write ("\n{0}", _Indent);
			 Format(Connect.AliceProfileDevice2);
				}
	

	//
	// DevicePreconfiguration
	//
	public static void DevicePreconfiguration(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DevicePreconfiguration.md");
		Example._Output = _Output;
		Example._DevicePreconfiguration(Example);
		}
	public void _DevicePreconfiguration(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Format(Connect.ConnectStaticPreconfig);
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
			 var connectionDevice = catalogedDevice?.ConnectionDevice;
			 var connectionService = catalogedDevice?.ConnectionService;
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
			 Format(connectionDevice);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The authentication key on its own is specified in the service connection:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Format(connectionService);
			_Output.Write ("\n{0}", _Indent);
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
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The service profile\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Format(profileService);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("And there should be a connection of the host to the service but this isn't implemented yet:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 Format(null);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SchemaMessagePIN
	//
	public static void SchemaMessagePIN(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SchemaMessagePIN.md");
		Example._Output = _Output;
		Example._SchemaMessagePIN(Example);
		}
	public void _SchemaMessagePIN(CreateExamples Example) {

			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, when Alice reads the connection request from the device in the architecture \n{0}", _Indent);
			_Output.Write ("examples, a completion message is added to Alice's inbound spool so that the device is not \n{0}", _Indent);
			_Output.Write ("activated a second time by mistake:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 DescribeMessage (Connect.ConnectPINMessagePin);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The details of the presentation and verification of the PIN code\n{0}", _Indent);
			_Output.Write ("are further described in the section below.\n{0}", _Indent);
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
			_Output.Write ("Alice connects a watch to her account. Since the watch has a camera (to allow for \n{0}", _Indent);
			_Output.Write ("video calls) she can use the dynamic QR code connection mechanism.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The watch reads the QR code generated on Alice's watch. This contains\n{0}", _Indent);
			_Output.Write ("the device connection URI.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("QR = {{Connect.ConnectQRURI}}\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The URI tells the device the Mesh account to connect to and the PIN Code to be\n{0}", _Indent);
			_Output.Write ("used to authenticate the request. The device requesting the connection adds its\n{0}", _Indent);
			_Output.Write ("Profile device to create a RequestConnection message that will be presented to\n{0}", _Indent);
			_Output.Write ("the service as a Connect transaction request.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 DescribeMessage (Connect.ConnectRequestPIN);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The service generates an AcknowledgeConnection message which is returned to the\n{0}", _Indent);
			_Output.Write ("device requesting the connection (via the Connect transaction response) and\n{0}", _Indent);
			_Output.Write ("adds it to the inbound spool of the account for Alice's approval (or not).\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 DescribeMessage (Connect.ConnectPINAcknowledgeConnection);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice's administration device synchronizes to the service and receives the\n{0}", _Indent);
			_Output.Write ("connection request acknowledgement from the service. Since the request is \n{0}", _Indent);
			_Output.Write ("authenticated by a PIN code that has been marked for automatic execution, the\n{0}", _Indent);
			_Output.Write ("service can generate the assertions the device to participate in the account\n{0}", _Indent);
			_Output.Write ("and appends the corresponding RespondConnection message to the local delivery \n{0}", _Indent);
			_Output.Write ("spool.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 DescribeMessage (Connect.RespondConnectionPIN);
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
			_Output.Write ("\n{0}", _Indent);
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
			_Output.Write ("The console generates a confirmation request message:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 DescribeMessage (Confirm.RequestConfirmation);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice accepts the request and returns a ResponseConfirmation confirmation\n{0}", _Indent);
			_Output.Write ("containing both the request and the response:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 DescribeMessage (Confirm.ResponseConfirmation);
			_Output.Write ("\n{0}", _Indent);
				}
		}
