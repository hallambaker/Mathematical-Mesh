using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
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

	
	/// <summary>	
	/// MakeDare3Examples
	/// </summary>
	/// <param name="Example"></param>
	public void MakeDare3Examples (CreateExamples Example) {
		 DareEnvelopeJsonMini(Example);
		 DareSequenceJsonMini(Example);
		 DareEnvelopeBinaryMini(Example);
		 DareSequenceBinaryMini(Example);
		 Dare3JsonEnvelope(Example);
		 Dare3JsonSequence(Example);
		 Dare3BinaryEnvelope(Example);
		 Dare3BinarySequence(Example);
		 DareExchangedKeyGeneration(Example);
		 DareRecipientData(Example);
		 DareSaltConstruction(Example);
		 DarePayloadEncryption(Example);
		 DareEncryptionComplete(Example);
		 DareSignaturePreamble(Example);
		 DareSignatureTrailer(Example);
		 DareSignatureValue(Example);
		 DareSignatureInSequence(Example);
		 DareKeyDefinitions(Example);
		 DareEnvelopeTestVectors(Example);
		 DareSequenceTestVectors(Example);
		}
	

	//
	// DareEnvelopeJsonMini
	//
	public static void DareEnvelopeJsonMini(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareEnvelopeJsonMini.md");
		Example._Output = _Output;
		Example._DareEnvelopeJsonMini(Example);
		}
	public void _DareEnvelopeJsonMini(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Minimal DARE Envelope", Dare3.EnvelopeMini);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareSequenceJsonMini
	//
	public static void DareSequenceJsonMini(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSequenceJsonMini.md");
		Example._Output = _Output;
		Example._DareSequenceJsonMini(Example);
		}
	public void _DareSequenceJsonMini(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Minimal DARE Sequence", Dare3.SequenceMini);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareEnvelopeBinaryMini
	//
	public static void DareEnvelopeBinaryMini(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareEnvelopeBinaryMini.md");
		Example._Output = _Output;
		Example._DareEnvelopeBinaryMini(Example);
		}
	public void _DareEnvelopeBinaryMini(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Minimal DARE Envelope", Dare3.EnvelopeMini, binary:true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareSequenceBinaryMini
	//
	public static void DareSequenceBinaryMini(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSequenceBinaryMini.md");
		Example._Output = _Output;
		Example._DareSequenceBinaryMini(Example);
		}
	public void _DareSequenceBinaryMini(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Minimal DARE Sequence", Dare3.SequenceMini, binary:true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// Dare3JsonEnvelope
	//
	public static void Dare3JsonEnvelope(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Dare3JsonEnvelope.md");
		Example._Output = _Output;
		Example._Dare3JsonEnvelope(Example);
		}
	public void _Dare3JsonEnvelope(CreateExamples Example) {

			_Output.Write ("For example, the following envelope contains a payload containing the text \n{0}", _Indent);
			_Output.Write ("'{1}' and a header specifying that the content type is \n{0}", _Indent, DareResults.TestPayload2);
			_Output.Write ("{1}:\n{0}", _Indent, DareResults.TestPayloadMedia);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData(null, Dare3.Envelope2, true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// Dare3JsonSequence
	//
	public static void Dare3JsonSequence(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Dare3JsonSequence.md");
		Example._Output = _Output;
		Example._Dare3JsonSequence(Example);
		}
	public void _Dare3JsonSequence(CreateExamples Example) {

			_Output.Write ("For example, the following sequence contains the envelopes presented in the previous\n{0}", _Indent);
			_Output.Write ("two examples:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData(null, Dare3.Sequence2);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// Dare3BinaryEnvelope
	//
	public static void Dare3BinaryEnvelope(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Dare3BinaryEnvelope.md");
		Example._Output = _Output;
		Example._Dare3BinaryEnvelope(Example);
		}
	public void _Dare3BinaryEnvelope(CreateExamples Example) {

			_Output.Write ("For example, the binary encoding of the envelope shown in the previous example is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData(null,Dare3.Envelope2, binary:true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// Dare3BinarySequence
	//
	public static void Dare3BinarySequence(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Dare3BinarySequence.md");
		Example._Output = _Output;
		Example._Dare3BinarySequence(Example);
		}
	public void _Dare3BinarySequence(CreateExamples Example) {

			_Output.Write ("For example, the binary encoding of the sequence shown in the previous example is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("DARE Sequence in Binary Serialization", Dare3.Sequence2, binary:true);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareExchangedKeyGeneration
	//
	public static void DareExchangedKeyGeneration(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareExchangedKeyGeneration.md");
		Example._Output = _Output;
		Example._DareExchangedKeyGeneration(Example);
		}
	public void _DareExchangedKeyGeneration(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Exchanged Key", Dare3.ExchangedKey);
			 FormatData("Exchanged Key Identifier", Dare3.ExchangedKeyId);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareRecipientData
	//
	public static void DareRecipientData(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareRecipientData.md");
		Example._Output = _Output;
		Example._DareRecipientData(Example);
		}
	public void _DareRecipientData(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Recipient Public Key ", Dare3.Recipient.KeyIdentifier);
			 FormatData("Ephemeral Key Pair", Dare3.Recipient.Epk);
			 FormatData("SharedSecret", Dare3.SharedSecret);
			 FormatData("Wrapped Exchanged Key", Dare3.Recipient.WrappedBaseSeed);
			 FormatData("Recipient Information", Dare3.Recipient);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareSaltConstruction
	//
	public static void DareSaltConstruction(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSaltConstruction.md");
		Example._Output = _Output;
		Example._DareSaltConstruction(Example);
		}
	public void _DareSaltConstruction(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Salt", Dare3.Salt);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DarePayloadEncryption
	//
	public static void DarePayloadEncryption(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DarePayloadEncryption.md");
		Example._Output = _Output;
		Example._DarePayloadEncryption(Example);
		}
	public void _DarePayloadEncryption(CreateExamples Example) {

			_Output.Write ("The input to the KDF is the concatenation of the Salt value and the Exchanged Key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("KDF Input", Dare3.KDFIn);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since we require a 256 bit key and 96 bit nonce, 352 bits of KDF output are required:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("KDF Output = SHAKE256(KDF Input,352)", Dare3.KDFOut);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first 96 bits of the output provide the nonce, the following 256 bits provide the key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Encryption Nonce", Dare3.EncryptionIV);
			 FormatData("Encryption Key", Dare3.EncryptionKey);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The plaintext payload is the string '{1}'.\n{0}", _Indent, DareResults.TestPayload2);
			_Output.Write ("The ciphertext is obtained by applying AES-GCM to the plaintext payload using the key and \n{0}", _Indent);
			_Output.Write ("nonce derrived using the KDF and the Signed header as Associated Data.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Associated Data", Dare3.SignedContentMeta);
			 FormatData("Ciphertext", Dare3.EncryptedPayload);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareEncryptionComplete
	//
	public static void DareEncryptionComplete(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareEncryptionComplete.md");
		Example._Output = _Output;
		Example._DareEncryptionComplete(Example);
		}
	public void _DareEncryptionComplete(CreateExamples Example) {

			_Output.Write ("The complete encryption envelope is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("DARE Envelope With Encrypted Payload", Dare3.EnvelopedEncryption);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareSignaturePreamble
	//
	public static void DareSignaturePreamble(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSignaturePreamble.md");
		Example._Output = _Output;
		Example._DareSignaturePreamble(Example);
		}
	public void _DareSignaturePreamble(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Signature Preamble", Dare3.Preamble);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareSignatureValue
	//
	public static void DareSignatureValue(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSignatureValue.md");
		Example._Output = _Output;
		Example._DareSignatureValue(Example);
		}
	public void _DareSignatureValue(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Signed Header Digest", Dare3.SignedHeaderDigest);
			 FormatData("Payload Digest", Dare3.PayloadDigest);
			 FormatData("Signature Manifest", Dare3.Manifest);
			 FormatData("ContextString", Dare3.ContextString);
			 FormatData("Signature Key Id", Dare3.PreambleSignature.KeyIdentifier);
			 FormatData("Signature Value", Dare3.SignatureValue);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareSignatureTrailer
	//
	public static void DareSignatureTrailer(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSignatureTrailer.md");
		Example._Output = _Output;
		Example._DareSignatureTrailer(Example);
		}
	public void _DareSignatureTrailer(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Signature Trailer", Dare3.Trailer);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The complete envelope is thus:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData(null, Dare3.EnvelopedSigned);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareSignatureInSequence
	//
	public static void DareSignatureInSequence(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSignatureInSequence.md");
		Example._Output = _Output;
		Example._DareSignatureInSequence(Example);
		}
	public void _DareSignatureInSequence(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Signature In Sequence", Dare3.SignatureInSequence);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// DareKeyDefinitions
	//
	public static void DareKeyDefinitions(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareKeyDefinitions.md");
		Example._Output = _Output;
		Example._DareKeyDefinitions(Example);
		}
	public void _DareKeyDefinitions(CreateExamples Example) {

			_Output.Write ("~~~~\n{0}", _Indent);
			 FormatData("Recipient Public Key ", Dare3.RecipientPublicKey);
			 FormatData("Signature Key", Dare3.SignatureKey);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// DareEnvelopeTestVectors
	//
	public static void DareEnvelopeTestVectors(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareEnvelopeTestVectors.md");
		Example._Output = _Output;
		Example._DareEnvelopeTestVectors(Example);
		}
	public void _DareEnvelopeTestVectors(CreateExamples Example) {

			foreach  (var test in Dare3.EnvelopeTests) {
				  TestVector (test);
				}
				}
	

	//
	// DareSequenceTestVectors
	//
	public static void DareSequenceTestVectors(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\DareSequenceTestVectors.md");
		Example._Output = _Output;
		Example._DareSequenceTestVectors(Example);
		}
	public void _DareSequenceTestVectors(CreateExamples Example) {

			foreach  (var test in Dare3.SequenceTests) {
				  TestVector (test);
				}
				}
	
	/// <summary>	
	/// TestVector
	/// </summary>
	/// <param name="test"></param>
	public void TestVector (TestVector test) {
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("## {1}\n{0}", _Indent, test.Title);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("* Encryption Algorithm: {1}\n{0}", _Indent, test.EncryptionAlgorithm);
		_Output.Write ("* Encryption Algorithm: {1}\n{0}", _Indent, test.SignatureAlgorithm);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		}
	}
