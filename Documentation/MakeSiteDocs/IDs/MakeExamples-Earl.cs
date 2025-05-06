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
	/// MakeEarlExamples
	/// </summary>
	/// <param name="Example"></param>
	public void MakeEarlExamples (CreateExamples Example) {
		 EarlExamples(Example);
		 EarlExamplesLocator(Example);
		 EarlExamplesName(Example);
		 Type0Envelope(Example);
		 Type0Meta(Example);
		 Type1Envelope(Example);
		 EarlKeyDerivation(Example);
		 Type0Nonce(Example);
		 EarlEncryption(Example);
		 EarlLocator(Example);
		 EarlAuthenticatedLocator(Example);
		 Unprotected(Example);
		 EarlManifest(Example);
		 SignedEnvelope25519(Example);
		 SignedEnvelope448(Example);
		}
	

	//
	// EarlExamples
	//
	public static void EarlExamples(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlExamples.md");
		Example._Output = _Output;
		Example._EarlExamples(Example);
		}
	public void _EarlExamples(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlLocator);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlName);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlJSContact);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("All three forms refer to the exact same data object. The first two forms are URLs\n{0}", _Indent);
			_Output.Write ("that indicate that the corresponding ciphertext MAY be retreived via HTTPS at:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.LocatorUri);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlExamplesLocator
	//
	public static void EarlExamplesLocator(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlExamplesLocator.md");
		Example._Output = _Output;
		Example._EarlExamplesLocator(Example);
		}
	public void _EarlExamplesLocator(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlLocator);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// EarlExamplesName
	//
	public static void EarlExamplesName(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlExamplesName.md");
		Example._Output = _Output;
		Example._EarlExamplesName(Example);
		}
	public void _EarlExamplesName(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlName);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// Type0Envelope
	//
	public static void Type0Envelope(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type0Envelope.md");
		Example._Output = _Output;
		Example._Type0Envelope(Example);
		}
	public void _Type0Envelope(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("For example, the payload:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\"{1}\" =\n{0}", _Indent, Example.TestFile1Text);
			_Output.Write ("{1}\n{0}", _Indent, earl.Payload.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Is encoded as a Type 0 envelope without metadata by concatenating \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* ???\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* The envelope type identifier (0), \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate an empty metadata field,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of payload bytes ({1}) followed by the payload bytes.\n{0}", _Indent, earl.Payload.Length);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EnvelopeContent.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Type0Meta
	//
	public static void Type0Meta(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type0Meta.md");
		Example._Output = _Output;
		Example._Type0Meta(Example);
		}
	public void _Type0Meta(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The same payload as before MAY be enveloped with the following metadata:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ProtectedHeaderJson);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The enveloped content is as before except that the metadata field is now specified:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.BytesMeta.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Type1Envelope
	//
	public static void Type1Envelope(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type1Envelope.md");
		Example._Output = _Output;
		Example._Type1Envelope(Example);
		}
	public void _Type1Envelope(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\"{1}\"\n{0}", _Indent, earl.FirstChunk);
			_Output.Write ("\"{1}\"\n{0}", _Indent, earl.SecondChunk);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Is encoded as a Type 1 envelope by concatenating:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* ???\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* The envelope type identifier (1), \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate an empty unprotected header field,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of metadata bytes followed by the metadata,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of bytes in the first chunk followed by the first chunk,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a varint specifying the number of bytes in the second chunk followed by the second chunk,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate the end of the payload section,\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("* a zero length byte to indicate an empty trailer field.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.BytesUnsigned.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlKeyDerivation
	//
	public static void EarlKeyDerivation(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlKeyDerivation.md");
		Example._Output = _Output;
		Example._EarlKeyDerivation(Example);
		}
	public void _EarlKeyDerivation(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The content digest of the envelope shown in the first example is computed using SHAK256:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ContentDigest.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first byte of the result is set to the type identifier {1}, truncated\n{0}", _Indent, earl.VersionTag);
			_Output.Write ("to the desired precision ({1} bits):\n{0}", _Indent, earl.Precision);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ContentDigestTruncated.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The multipurpose key presentation is the result presented in Base32 with the characters \n{0}", _Indent);
			_Output.Write ("grouped into sets of four with dashes:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlPath);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Note that since there is an odd number of 20-bit segments in this example, only \n{0}", _Indent);
			_Output.Write ("the upper half of the last byte is recorded in the key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 var path = earl.EarlPath.FromBase32(partial: true);
			_Output.Write ("{1}\n{0}", _Indent, path.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The EARL forms consist of the scheme name, authority section (if specified) and the \n{0}", _Indent);
			_Output.Write ("presentation form of the multi-purpose key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlLocator);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlName);
			_Output.Write ("{1}\n{0}", _Indent, earl.EarlJSContact);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Type0Nonce
	//
	public static void Type0Nonce(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Type0Nonce.md");
		Example._Output = _Output;
		Example._Type0Nonce(Example);
		}
	public void _Type0Nonce(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("If a different nonce is specified in the metadata:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.ProtectedHeaderJson2);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("A different multi-purpose key is derived:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.WithNonce.Uri);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlEncryption
	//
	public static void EarlEncryption(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlEncryption.md");
		Example._Output = _Output;
		Example._EarlEncryption(Example);
		}
	public void _EarlEncryption(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Since the encryption algorithm is AES-GCM with a 96 nonce and a 256 bit key,\n{0}", _Indent);
			_Output.Write ("it is necessary to generate 44 bytes to encrypt the enveloped data.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The key derrivation function, SHAKE-256 is applied to the multi-purpose key \n{0}", _Indent);
			_Output.Write ("of the first example to obtain 44 bytes of output:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.AesKeyNonce.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first 32 bytes of the result are the AES-GCM encryption key:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("encryption key =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.AesKeyNonce[0..32].ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The final 12 bytes of the result are the AES-GCM nonce:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("encryption nonce = \n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.AesKeyNonce[32..].ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The enveloped plaintext data is encrypted under AES-GCM with the specified key and \n{0}", _Indent);
			_Output.Write ("nonce to produce the ciphertext:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("ciphertext = \n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Ciphertext.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// EarlLocator
	//
	public static void EarlLocator(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlLocator.md");
		Example._Output = _Output;
		Example._EarlLocator(Example);
		}
	public void _EarlLocator(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first locator value is computed from the multi-purpose key using the  \n{0}", _Indent);
			_Output.Write ("locator digest function, in this case SHA-3-256:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("locator1 =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Locator1.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The locator value is computed from the first locator value using the  \n{0}", _Indent);
			_Output.Write ("locator digest function, in this case SHA-3-256:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("locator =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Locator1.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The locator URI is a HTTPS well-known service in which the final element of the\n{0}", _Indent);
			_Output.Write ("path is the base64url encoded locator value.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("EARL =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.LocatorUri);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlAuthenticatedLocator
	//
	public static void EarlAuthenticatedLocator(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlAuthenticatedLocator.md");
		Example._Output = _Output;
		Example._EarlAuthenticatedLocator(Example);
		}
	public void _EarlAuthenticatedLocator(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("access authenticator =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Password);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// Unprotected
	//
	public static void Unprotected(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\Unprotected.md");
		Example._Output = _Output;
		Example._Unprotected(Example);
		}
	public void _Unprotected(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Unprotected Header =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.Header);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// EarlManifest
	//
	public static void EarlManifest(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\EarlManifest.md");
		Example._Output = _Output;
		Example._EarlManifest(Example);
		}
	public void _EarlManifest(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Metadata digest =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.MetadataDigest.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Payload digest =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.PayloadDigest.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Manifest =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.Manifest.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SignedEnvelope25519
	//
	public static void SignedEnvelope25519(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SignedEnvelope25519.md");
		Example._Output = _Output;
		Example._SignedEnvelope25519(Example);
		}
	public void _SignedEnvelope25519(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Ed25519 private key =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, (earl.SignatureEd25519 as KeyPairEd25519).PrivateKey.Secret.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The trailer contains a Signatures property with a single entry specifying the key \n{0}", _Indent);
			_Output.Write ("identifier of the signing key and the signature value:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Trailer =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.Signed25519.Trailer);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	

	//
	// SignedEnvelope448
	//
	public static void SignedEnvelope448(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\SignedEnvelope448.md");
		Example._Output = _Output;
		Example._SignedEnvelope448(Example);
		}
	public void _SignedEnvelope448(CreateExamples Example) {

			 var earl = Example.Earl;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The process for signing with an Ed448 key is identical except that achieving the\n{0}", _Indent);
			_Output.Write ("higher work factor requires use of a 512 bit digest:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Unprotected Header =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.SignedEd448.Header);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The private key used to generate the signature in this example is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Ed448 private key =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, (earl.SignatureEd448 as KeyPairEd448).PrivateKey.Secret.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The signature value is specified in the trailer as before:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Trailer =\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, earl.SignedEd448.Trailer);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
				}
	}
