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
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// MakeUDFExamples
		//
		public void MakeUDFExamples (CreateExamples Example) {
			 UDFVariousUDF(Example);
			 UDFNonce(Example);
			 UDFOID(Example);
			 UDFEncrypt(Example);
			 UDFShare(Example);
			 UDFDigest(Example);
			 UDFDigestURI(Example);
			 UDFDigestLocator(Example);
			 UDFDigestEARLRAW(Example);
			 UDFDigestEARLLocator(Example);
			 UDFDigestEARL(Example);
			 UDFsin(Example);
			 UDFURIEBNF(Example);
			 UDFTableReservedId(Example);
			 UDFShamirRecovery(Example);
			 UDFSplit(Example);
			 UDFDigestLong(Example);
			 UDFAuthenticatorLong(Example);
			 UDFDigestResolution(Example);
			 UDFEncryptedResolution(Example);
			 UDFAuthenticator(Example);
			 UDFDeriveCFRG(Example);
			 UDFDeriveNIST(Example);
			 UDFDeriveRSA(Example);
			 UDFDeriveAny(Example);
			}
		

		//
		// UDFVariousUDF
		//
		public static void UDFVariousUDF (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFVariousUDF.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFNonce.Key);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFSecret.Key);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFSecret.Shares[0]);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultDigestSHA2.Digest);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultDigestSHA3.Digest);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultCommitSHA2.Digest);
				_Output.Write ("{1}\n{0}", _Indent, Example.PublicKeyed25519.UDFValue);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFNonce
		//
		public static void UDFNonce (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFNonce.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Nonce UDF:\n{0}", _Indent);
				_Output.Write ("  {1}\n{0}", _Indent, Example.ResultUDFNonce.Key);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFOID
		//
		public static void UDFOID (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFOID.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Given the following Ed25519 public key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.PublicKeyed25519.PublicData.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The equivalent DER encoding is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.PublicKeyed25519.KeyInfoData.DER().ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To encode this key as a UDF OID sequence we prepend the value {1}\n{0}", _Indent, UDFTypeIdentifier.OID);
				_Output.Write ("and convert to Base32:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.PublicKeyed25519.UDFValue);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The corresponding UDF content digest value is more compact and allows us to identify the \n{0}", _Indent);
				_Output.Write ("key unambiguously but does not provide the value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.PublicKeyed25519.UDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFEncrypt
		//
		public static void UDFEncrypt (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFEncrypt.md")) {
				var _Indent = ""; 
				 var data = UDF.Parse (Example.ResultUDFSecret.Key, out var code);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("KeyValue:{1}\n{0}", _Indent, data.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Encryption/Authenticator UDF:\n{0}", _Indent);
				_Output.Write ("  {1}\n{0}", _Indent, Example.ResultUDFSecret.Key);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFShare
		//
		public static void UDFShare (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFShare.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Key:     {1}\n{0}", _Indent, Example.ResultUDFSecret.Key);
				_Output.Write ("Share 0: {1}\n{0}", _Indent, Example.ResultUDFSecret.Shares[0]);
				_Output.Write ("Share 1: {1}\n{0}", _Indent, Example.ResultUDFSecret.Shares[1]);
				_Output.Write ("Share 2: {1}\n{0}", _Indent, Example.ResultUDFSecret.Shares[2]);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFDigest
		//
		public static void UDFDigest (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDigest.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("SHA-2-512: {1}\n{0}", _Indent, Example.ResultDigestSHA2.Digest);
				_Output.Write ("SHA-3-512: {1}\n{0}", _Indent, Example.ResultDigestSHA3.Digest);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFAuthenticator
		//
		public static void UDFAuthenticator (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFAuthenticator.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("SHA-2-512: {1}\n{0}", _Indent, Example.ResultCommitSHA2.Digest);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFDigestURI
		//
		public static void UDFDigestURI (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDigestURI.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("udf:{1}\n{0}", _Indent, Example.ResultDigestSHA2.Digest);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFDigestLocator
		//
		public static void UDFDigestLocator (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDigestLocator.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("udf://example.com/{1}\n{0}", _Indent, Example.ResultDigestSHA2.Digest);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFDigestEARLRAW
		//
		public static void UDFDigestEARLRAW (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDigestEARL-raw.md")) {
				var _Indent = ""; 
				_Output.Write ("udf://example.com/{1}", _Indent, Example.ResultUDFEARL.Key);
				}
			}
		

		//
		// UDFDigestEARL
		//
		public static void UDFDigestEARL (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDigestEARL.md")) {
				var _Indent = ""; 
				_Output.Write ("To generate the paper invoice, Example.com first creates a new encryption key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFEARL.Key);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("One or more electronic forms of the invoice are encrypted under the key \n{0}", _Indent);
				_Output.Write ("{1} and placed on the Example.com Web site so that \n{0}", _Indent, Example.ResultUDFEARL.Key);
				_Output.Write ("the appropriate version is returned if Alice scans the QR code.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The key is then converted to form an EARL for the example.com UDF resolution service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("udf://example.com/{1}\n{0}", _Indent, Example.ResultUDFEARL.Key);
				}
			}
		

		//
		// UDFDigestEARLLocator
		//
		public static void UDFDigestEARLLocator (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDigestEARLLocator.md")) {
				var _Indent = ""; 
				_Output.Write ("The UDF EARL locator shown above is resolved by first determining the Web Service\n{0}", _Indent);
				_Output.Write ("Endpoint for the mmm-udf service for the domain example.com.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Discover (\"example.com\", \"mmm-udf\") = \n{0}", _Indent);
				_Output.Write ("https://example.com/.well-known/mmm-udf/\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Next the fingerprint of the source UDF is obtained.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("UDF ({1}) =\n{0}", _Indent, Example.ResultUDFEARL.Key);
				_Output.Write ("{1}\n{0}", _Indent, Example.ResultUDFEARL.Identifier);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Combining the Web Service Endpoint and the fingerprint of the source UDF provides\n{0}", _Indent);
				_Output.Write ("the URI from which the content is obtained using the normal HTTP GET method:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("https://example.com/.well-known/mmm-udf/{1}\n{0}", _Indent, Example.ResultUDFEARL.Identifier);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UDFsin
		//
		public static void UDFsin (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFsin.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Example Inc holds the domain name example.com and has deployed a \n{0}", _Indent);
				_Output.Write ("private CA whose root of trust is a PKIX certificate with the UDF fingerprint \n{0}", _Indent);
				_Output.Write ("MB2GK-6DUF5-YGYYL-JNY5E-RWSHZ.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice is an employee of Example Inc., she uses three email addresses:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>alice@example.com\n{0}", _Indent);
				_Output.Write ("<dd>A regular email address (not a SIN).\n{0}", _Indent);
				_Output.Write ("<dt>alice@mm--mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com\n{0}", _Indent);
				_Output.Write ("<dd>A strong email address that is backwards compatible.\n{0}", _Indent);
				_Output.Write ("<dt>alice@example.com.mm--mb2gk-6duf5-ygyyl-jny5e-rwshz\n{0}", _Indent);
				_Output.Write ("<dd>A strong email address that is backwards incompatible.\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UDFDeriveCFRG
		//
		public static void UDFDeriveCFRG (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDeriveCFRG.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("An X25519 key may be derived as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X25519.UDF);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("IKM =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X25519.IKM.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("salt =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X25519.Salt.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("PRK =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X25519.PRK.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("OKM =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X25519.OKM.ToStringBase16FormatHex());
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X25519.Key.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Derivation of an X448 key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X448.UDF);
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.X448.Key.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Derivation of an Ed25519 key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Ed25519.UDF);
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Ed25519.Key.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Derivation of an Ed448 key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Ed448.UDF);
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Ed448.Key.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UDFDeriveNIST
		//
		public static void UDFDeriveNIST (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDeriveNIST.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A P-256 key may be derived as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P256.UDF);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("IKM =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P256.IKM.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("salt =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P256.Salt.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("PRK =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P256.PRK.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("OKM =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P256.OKM.ToStringBase16FormatHex());
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P256.Key);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Derivation of a P-384 key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P384.UDF);
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P384.Key);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Derivation of a P-521 key:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P521.UDF);
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.P521.Key);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UDFDeriveRSA
		//
		public static void UDFDeriveRSA (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDeriveRSA.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("An RSA-2048 may be derived as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.UDF);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("IKM =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.IKM.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("salt =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.Salt.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Generation of the PRK as before]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Info(p) = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.Info_P.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("OKM(p) =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.OKM_P.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Info(q) = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.Info_Q.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("OKM(q) =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.OKM_Q.ToStringBase16FormatHex());
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key P = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.P);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key Q = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.RSA2048.Q);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UDFDeriveAny
		//
		public static void UDFDeriveAny (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDeriveAny.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Fingerprint =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Any_RSA2048.UDF);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To generate an RSA-2048 key\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("salt =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Any_RSA2048.Salt.ToStringBase16FormatHex());
				_Output.Write ("	\n{0}", _Indent);
				_Output.Write ("Key P = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Any_RSA2048.P);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key Q = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Any_RSA2048.Q);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To generate an X25519 key\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("salt =\n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Any_RSA2048.Salt.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key = \n{0}", _Indent);
				_Output.Write ("    {1}\n{0}", _Indent, Example.UDFResults.Derive.Any_x25519.Key);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UDFSplit
		//
		public static void UDFSplit (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFSplit.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to encrypt an important document and split the encryption key so that\n{0}", _Indent);
				_Output.Write ("there are five key shares, three of which will be required to recover the key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Alice's master secret is{1}\n{0}", _Indent, Example.UDFSplitSecret.Key.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This has the UDF representation:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Example.UDFSplitSecret.UDFKey);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The master secret is converted to an integer applying network byte order conventions.\n{0}", _Indent);
				_Output.Write ("Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.\n{0}", _Indent);
				_Output.Write ("The resulting value becomes the polynomial value a0.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since a threshold of three shares is required, we will need a second order polynomial.\n{0}", _Indent);
				_Output.Write ("The co-efficients of the polynomial a1, a2 are random numbers smaller than the \n{0}", _Indent);
				_Output.Write ("modulus:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("a0 = {1}\n{0}", _Indent, Example.UDFSplitPolynomial[0]);
				_Output.Write ("a1 = {1}\n{0}", _Indent, Example.UDFSplitPolynomial[1]);
				_Output.Write ("a2 = {1}\n{0}", _Indent, Example.UDFSplitPolynomial[2]);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("f(1) = {1}\n{0}", _Indent, Example.UDFSplitShares[0].Value);
				_Output.Write ("f(2) = {1}\n{0}", _Indent, Example.UDFSplitShares[1].Value);
				_Output.Write ("f(3) = {1}\n{0}", _Indent, Example.UDFSplitShares[2].Value);
				_Output.Write ("f(4) = {1}\n{0}", _Indent, Example.UDFSplitShares[3].Value);
				_Output.Write ("f(5) = {1}\n{0}", _Indent, Example.UDFSplitShares[4].Value);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The first byte of each share specifies the recovery information (quorum, x value), the\n{0}", _Indent);
				_Output.Write ("remaining bytes specify the share value in network byte order:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("f(1) = {1}\n{0}", _Indent, Example.UDFSplitShares[0].Key.ToStringBase16FormatHex());
				_Output.Write ("f(2) = {1}\n{0}", _Indent, Example.UDFSplitShares[1].Key.ToStringBase16FormatHex());
				_Output.Write ("f(3) = {1}\n{0}", _Indent, Example.UDFSplitShares[2].Key.ToStringBase16FormatHex());
				_Output.Write ("f(4) = {1}\n{0}", _Indent, Example.UDFSplitShares[3].Key.ToStringBase16FormatHex());
				_Output.Write ("f(5) = {1}\n{0}", _Indent, Example.UDFSplitShares[4].Key.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The UDF presentation of the key shares is thus:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("f(1) = {1}\n{0}", _Indent, Example.UDFSplitShares[0].UDFKey);
				_Output.Write ("f(2) = {1}\n{0}", _Indent, Example.UDFSplitShares[1].UDFKey);
				_Output.Write ("f(3) = {1}\n{0}", _Indent, Example.UDFSplitShares[2].UDFKey);
				_Output.Write ("f(4) = {1}\n{0}", _Indent, Example.UDFSplitShares[3].UDFKey);
				_Output.Write ("f(5) = {1}\n{0}", _Indent, Example.UDFSplitShares[4].UDFKey);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To recover the value f(0) from any three shares, we need to fit a polynomial curve to \n{0}", _Indent);
				_Output.Write ("the three points and use it to calculate the value at x=0 using the Lagrange polynomial\n{0}", _Indent);
				_Output.Write ("basis.\n{0}", _Indent);
				}
			}
		

		//
		// UDFDigestLong
		//
		public static void UDFDigestLong (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFDigestLong.md")) {
				var _Indent = ""; 
				 var instance = Instance (_Output);
				 var DataString = "UDF Data Value";
				 var Data = DataString.ToUTF8();
				 var ContentType = "text/plain";
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In the following examples, &<Content-ID> is the UTF8 encoding of the string \n{0}", _Indent);
				_Output.Write ("\"{1}\" and &<Data> is the UTF8 encoding of the string \"{2}\"\n{0}", _Indent, ContentType, DataString);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Data = {1}\n{0}", _Indent,  DataString.ToUTF8().ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("ContentType = {1}\n{0}", _Indent, ContentType.ToUTF8().ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Using SHA-2-512 Digest\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 instance.MakeUTFExtendedExample (DataString, CryptoAlgorithmID.SHA_2_512, null);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This fingerprint MAY be specified with higher or lower precision as appropriate.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>100 bit precision\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.ContentDigestOfDataString(Data, ContentType, 100));
				_Output.Write ("<dt>120 bit precision\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.ContentDigestOfDataString(Data, ContentType, 120));
				_Output.Write ("<dt>200 bit precision\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.ContentDigestOfDataString(Data, ContentType, 200));
				_Output.Write ("<dt>260 bit precision\n{0}", _Indent);
				_Output.Write ("<dd>{1}\n{0}", _Indent, UDF.ContentDigestOfDataString(Data, ContentType, 260));
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Using SHA-3-512 Digest\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 instance.MakeUTFExtendedExample (DataString, CryptoAlgorithmID.SHA_3_512, null);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Using SHA-2-512 Digest with Compression \n{0}", _Indent);
				 var DataStringc2 = $"UDF Compressed Document {4187123}";
				 var Datac2 = DataStringc2.ToUTF8();
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The content data \"{1}\" produces a UDF Content Digest SHA-2-512 binary value \n{0}", _Indent, DataStringc2);
				_Output.Write ("with 20 trailing zeros and is therefore presented using compressed presentation:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Data = \"{1}\"\n{0}", _Indent, Datac2.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The UTF8 Content Digest is given as:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 instance.MakeUTFExtendedExample (DataStringc2, CryptoAlgorithmID.SHA_2_512, null);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("###Using SHA-3-512 Digest with Compression \n{0}", _Indent);
				 var DataStringc3 = $"UDF Compressed Document {774665}";
				 var Datac3 = DataStringc3.ToUTF8();
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The content data \"{1}\" produces a UDF Content Digest SHA-3-512 binary value \n{0}", _Indent, DataStringc3);
				_Output.Write ("with 20 trailing zeros and is therefore presented using compressed presentation:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Data = {1}\n{0}", _Indent, Datac3.ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The UTF8 SHA-3-512 Content Digest is\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, UDF.ContentDigestOfDataString(Datac3, ContentType, 140, CryptoAlgorithmID.SHA_3_512));
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MakeUTFExtendedExample
		//
		public void MakeUTFExtendedExample (string DataString, CryptoAlgorithmID cryptoAlgorithmID, string key) {
			 var DataBytes = DataString.ToUTF8();
			 var ContentType = "text/plain";
			 var HashData = DataBytes.GetDigest(cryptoAlgorithmID);
			 var UDFDataBuffer = UDF.UDFBuffer(HashData, ContentType);
			 byte[] UDFData ;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("H(&<Data>) = ", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, HashData.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("&<Content-ID> + ‘:’ + H(&<Data>) =  ", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, UDFDataBuffer.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			if (  (key == null) ) {
				 UDFData = UDFDataBuffer.GetDigest(cryptoAlgorithmID);
				_Output.Write ("H(&<Content-ID> + ‘:’ + H(&<Data>)) =  ", _Indent);
				} else {
				 var keyBytes = key.ToUTF8();
				 var macKey = UDF.KeyStringToKey(key,512);
				 UDFData = UDFDataBuffer.GetMAC(macKey, CryptoAlgorithmID.HMAC_SHA_2_512);
				 var keyDerive = new KeyDeriveHKDF(keyBytes, KeyDerive.KeyedUDFMaster, CryptoAlgorithmID.HMAC_SHA_2_512);
				_Output.Write ("PRK(Key) =  ", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, keyDerive.PRK.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("HKDF(Key) =  ", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, macKey.ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("MAC(&<key>, &<Content-ID> + ‘:’ + H(&<Data>)) =  ", _Indent);
				}
			 var binaryUDF = UDF.DigestToUDFBinary (HashData, ContentType, 140, cryptoAlgorithmID, key);
			_Output.Write ("{1}\n{0}", _Indent, UDFData.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The prefixed Binary Data Sequence is thus{1}\n{0}", _Indent, binaryUDF.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The 125 bit fingerprint value is {1}\n{0}", _Indent, UDF.PresentationBase32 (binaryUDF, 140));
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// UDFAuthenticatorLong
		//
		public static void UDFAuthenticatorLong (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFAuthenticatorLong.md")) {
				var _Indent = ""; 
				 var instance = Instance (_Output);
				 var key = "NDD7-6CMX-H2FW-ISAL-K4VB-DQ3E-PEDM";
				 var DataString = "Konrad is the traitor";
				 var Data = DataString.ToUTF8();
				 var ContentType = "text/plain";
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("In the following example, &<Content-ID> is the UTF8 encoding of the string \n{0}", _Indent);
				_Output.Write ("\"{1}\" and &<Data> is the UTF8 encoding of the string \"{2}\".\n{0}", _Indent, ContentType, DataString);
				_Output.Write ("The randomly chosen key is {1}.\n{0}", _Indent, key);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Data = {1}\n{0}", _Indent,  DataString.ToUTF8().ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("ContentType = {1}\n{0}", _Indent, ContentType.ToUTF8().ToStringBase16FormatHex());
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key =  {1}\n{0}", _Indent,  key.ToUTF8().ToStringBase16FormatHex());
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Processing is performed in the same manner as an unkeyed fingerprint except that\n{0}", _Indent);
				_Output.Write ("compression is never used:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 instance.MakeUTFExtendedExample (DataString, CryptoAlgorithmID.SHA_2_512, key);
				}
			}
		

		//
		// UDFTableReservedId
		//
		public static void UDFTableReservedId (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFTableReservedId.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("Code  Description                      Reference\n{0}", _Indent);
				_Output.Write ("---  -------------------               ---------\n{0}", _Indent);
				_Output.Write ("00   HMAC and SHA-2-512                [This document]\n{0}", _Indent);
				_Output.Write ("32   HKDF-AES-512                      [This document]\n{0}", _Indent);
				_Output.Write ("80   SHA-3-512                         [This document] \n{0}", _Indent);
				_Output.Write ("81   SHA-3-512 with 20 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("82   SHA-3-512 with 30 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("82   SHA-3-512 with 40 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("83   SHA-3-512 with 50 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("96   SHA-2-512                         [This document]\n{0}", _Indent);
				_Output.Write ("97   SHA-2-512 with 20 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("98   SHA-2-512 with 30 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("99   SHA-2-512 with 40 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("100  SHA-2-512 with 50 trailing zeros  [This document]\n{0}", _Indent);
				_Output.Write ("104  Random nonce                      [This document]\n{0}", _Indent);
				_Output.Write ("144  Shamir Secret Share               [This document]\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFURIEBNF
		//
		public static void UDFURIEBNF (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFURIEBNF.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("URI           = \"UDF:\" udf [ \"?\" query ] [ \"\" fragment ]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("udf           = name-form / locator-form\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("name-form     = udf-value\n{0}", _Indent);
				_Output.Write ("locator-form  = \"//\" authority \"/\" udf-value\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("authority     = host \n{0}", _Indent);
				_Output.Write ("host          = reg-name\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFShamirRecovery
		//
		public static void UDFShamirRecovery (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFShamirRecovery.md")) {
				var _Indent = ""; 
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("using System;\n{0}", _Indent);
				_Output.Write ("using System.Collections.Generic;\n{0}", _Indent);
				_Output.Write ("using System.Numerics;\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("namespace Examples {{\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("    class Examples {{\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("        /// <summary>\n{0}", _Indent);
				_Output.Write ("        /// Combine a set of <paramref name=\"n\"/> points (x, f(x))\n{0}", _Indent);
				_Output.Write ("        /// on a polynomial of degree <paramref name=\"n\"/> in a \n{0}", _Indent);
				_Output.Write ("        /// discrete field modulo prime <paramref name=\"p\"/> to \n{0}", _Indent);
				_Output.Write ("        /// recover the value f(0) using Lagrange basis polynomials.\n{0}", _Indent);
				_Output.Write ("        /// </summary>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"fx\">The values f(x).</param>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"x\">The values for x.</param>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"p\">The modulus.</param>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"n\">The polynomial degree.</param>\n{0}", _Indent);
				_Output.Write ("        /// <returns>The value f(0).</returns>\n{0}", _Indent);
				_Output.Write ("        static BigInteger CombineNK(\n{0}", _Indent);
				_Output.Write ("                    BigInteger[] fx,\n{0}", _Indent);
				_Output.Write ("                    int[] x,\n{0}", _Indent);
				_Output.Write ("                    BigInteger p,\n{0}", _Indent);
				_Output.Write ("                    int n) {{\n{0}", _Indent);
				_Output.Write ("            if (fx.Length < n) {{\n{0}", _Indent);
				_Output.Write ("                throw new Exception(\"Insufficient shares\");\n{0}", _Indent);
				_Output.Write ("                }}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("            BigInteger accumulator = 0;\n{0}", _Indent);
				_Output.Write ("            for (var formula = 0; formula < n; formula++) {{\n{0}", _Indent);
				_Output.Write ("                var value = fx[formula];\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("                BigInteger numerator = 1, denominator = 1;\n{0}", _Indent);
				_Output.Write ("                for (var count = 0; count < n; count++) {{\n{0}", _Indent);
				_Output.Write ("                    if (formula == count) {{\n{0}", _Indent);
				_Output.Write ("                        continue;  // If not the same value\n{0}", _Indent);
				_Output.Write ("                        }}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("                    var start = x[formula];\n{0}", _Indent);
				_Output.Write ("                    var next = x[count];\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("                    numerator = (numerator * -next) % p;\n{0}", _Indent);
				_Output.Write ("                    denominator = (denominator * (start - next)) % p;\n{0}", _Indent);
				_Output.Write ("                    }}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("                var InvDenominator = ModInverse(denominator, p);\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("                accumulator = Modulus((accumulator + \n{0}", _Indent);
				_Output.Write ("                    (fx[formula] * numerator * InvDenominator)), p);\n{0}", _Indent);
				_Output.Write ("                }}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("            return accumulator;\n{0}", _Indent);
				_Output.Write ("            }}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("        /// <summary>\n{0}", _Indent);
				_Output.Write ("        /// Compute the modular multiplicative inverse of the value \n{0}", _Indent);
				_Output.Write ("        /// <paramref name=\"k\"/> modulo <paramref name=\"p\"/>\n{0}", _Indent);
				_Output.Write ("        /// </summary>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"k\">The value to find the inverse of</param>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"p\">The modulus.</param>\n{0}", _Indent);
				_Output.Write ("        /// <returns></returns>\n{0}", _Indent);
				_Output.Write ("        static BigInteger ModInverse(\n{0}", _Indent);
				_Output.Write ("                    BigInteger k, \n{0}", _Indent);
				_Output.Write ("                    BigInteger p) {{\n{0}", _Indent);
				_Output.Write ("            var m2 = p - 2;\n{0}", _Indent);
				_Output.Write ("            if (k < 0) {{\n{0}", _Indent);
				_Output.Write ("                k = k + p;\n{0}", _Indent);
				_Output.Write ("                }}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("            return BigInteger.ModPow(k, m2, p);\n{0}", _Indent);
				_Output.Write ("            }}\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("        /// <summary>\n{0}", _Indent);
				_Output.Write ("        /// Calculate the modulus of a number with correct handling \n{0}", _Indent);
				_Output.Write ("        /// for negative numbers.\n{0}", _Indent);
				_Output.Write ("        /// </summary>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"x\">Value</param>\n{0}", _Indent);
				_Output.Write ("        /// <param name=\"p\">The modulus.</param>\n{0}", _Indent);
				_Output.Write ("        /// <returns>x mod p</returns>\n{0}", _Indent);
				_Output.Write ("        public static BigInteger Modulus(\n{0}", _Indent);
				_Output.Write ("                    BigInteger x, \n{0}", _Indent);
				_Output.Write ("                    BigInteger p) {{\n{0}", _Indent);
				_Output.Write ("            var Result = x % p;\n{0}", _Indent);
				_Output.Write ("            return Result.Sign >= 0 ? Result : Result + p;\n{0}", _Indent);
				_Output.Write ("            }}\n{0}", _Indent);
				_Output.Write ("        }}\n{0}", _Indent);
				_Output.Write ("    }}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				}
			}
		

		//
		// UDFEncryptedResolution
		//
		public static void UDFEncryptedResolution (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\UDFEncryptedResolution.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// UDFDigestResolution
		//
		public static void UDFDigestResolution(CreateExamples Example) { /* XFile  */
				using (var _Output = new StreamWriter("Examples\\UDFDigestResolution.md")) {
				var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\UDFDigestResolution.md" };
				obj._UDFDigestResolution(Example);
				}
			}
		public void _UDFDigestResolution(CreateExamples Example) {

					}
		

		//
		// MeshExamplesSIN
		//
		public static void MeshExamplesSIN (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesSIN.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A SIN is an Internet Identifier that contains a fingerprint of a root of \n{0}", _Indent);
				_Output.Write ("trust that may be used to verify the interpretation of the identifier. This \n{0}", _Indent);
				_Output.Write ("section describes the manner in which SINs are used. The following section describes \n{0}", _Indent);
				_Output.Write ("their construction using Uniform Data Fingerprints [I-D.hallambaker-udf]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Example Inc holds the domain name example.com and has deployed a private \n{0}", _Indent);
				_Output.Write ("CA whose root of trust is a PKIX certificate with the UDF fingerprint MB2GK-6DUF5-YGYYL-JNY5E-RWSHZ.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice is an employee of Example Inc., she uses three email addresses:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>alice@example.com\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dd>A regular email address (not a SIN).\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dt>alice@mm--mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dd>A strong email address that is backwards compatible.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dt>alice@example.com.mm--mb2gk-6duf5-ygyyl-jny5e-rwshz\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dd>A strong email address that is backwards incompatible.\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("All three forms of the address are valid RFC822 addresses and may be used in a legacy \n{0}", _Indent);
				_Output.Write ("email client, stored in an address book application, etc. But the ability of a legacy \n{0}", _Indent);
				_Output.Write ("client to make use of the address differs. Addresses of the first type may always be used. \n{0}", _Indent);
				_Output.Write ("Addresses of the second type may only be used if an appropriate MX record is provisioned. \n{0}", _Indent);
				_Output.Write ("Addresses of the third type will always fail unless the resolver understands that it is a \n{0}", _Indent);
				_Output.Write ("SIN requiring special processing.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When specified as the destination address in a Mail User Application (MUA), these addresses \n{0}", _Indent);
				_Output.Write ("have the following interpretations:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("alice@example.com\n{0}", _Indent);
				_Output.Write ("Send mail to Alice without requiring security enhancements.\n{0}", _Indent);
				_Output.Write ("alice@mm--mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com\n{0}", _Indent);
				_Output.Write ("Send mail to Alice. If the MUA is SIN-Aware, it MUST resolve the security policy specified \n{0}", _Indent);
				_Output.Write ("by the fingerprint and apply security enhancements as mandated by that policy.\n{0}", _Indent);
				_Output.Write ("alice@example.com.mm--mb2gk-6duf5-ygyyl-jny5e-rwshz\n{0}", _Indent);
				_Output.Write ("Only send mail to Alice if the MUA is SIN-Aware, it MUST resolve the security policy \n{0}", _Indent);
				_Output.Write ("specified by the fingerprint and apply security enhancements as mandated by that policy.\n{0}", _Indent);
				_Output.Write ("These rules allow Bob to send email to Alice with either ‘best effort’ security or \n{0}", _Indent);
				_Output.Write ("mandatory security as the circumstances demand\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MeshExamplesSIN2
		//
		public static void MeshExamplesSIN2 (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\ExamplesSIN2.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A security policy may be implicit or explicit depending on the root of trust referenced and the context in which it is used.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Since many Internet applications are already designed to make use of a PKIX based trust infrastructure, the fingerprint of a PKIX root of trust provides sufficient information to deduce an appropriate security policy in many instances. For example:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("https://mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com/\n{0}", _Indent);
				_Output.Write ("Connect to example.com using a TLS connection with a certificate that is valid in a chain of trust that contains a certificate with the fingerprint mb2gk.\n{0}", _Indent);
				_Output.Write ("IMAP Server: mb2gk-6duf5-ygyyl-jny5e-rwshz.example.com\n{0}", _Indent);
				_Output.Write ("Connect to the IMAP server example.com over a TLS connection with a certificate that is valid in a chain of trust that contains a certificate with the fingerprint mb2gk.\n{0}", _Indent);
				_Output.Write ("mailto:alice@example.com.mm--mb2gk-6duf5-ygyyl-jny5e-rwshz\n{0}", _Indent);
				_Output.Write ("Encrypt mail messages using S/MIME using an S/MIME certificate that is valid in a chain of trust that contains a certificate with the fingerprint mb2gk.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// MeshManToolFile
		//
		public static void MeshManToolFile (CreateExamples Example) { /* File  */
			using (var _Output = new StreamWriter ("Examples\\MeshManToolFile.md")) {
				var _Indent = ""; 
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The file command set supports the following operations on files:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<dl>\n{0}", _Indent);
				_Output.Write ("<dt>random\n{0}", _Indent);
				_Output.Write ("<dd>Return a randomized string\n{0}", _Indent);
				_Output.Write ("<dt>digest\n{0}", _Indent);
				_Output.Write ("<dd>Calculate the digest value of the input data\n{0}", _Indent);
				_Output.Write ("<dt>commit\n{0}", _Indent);
				_Output.Write ("<dd>Calculate a commitment value for the input data\n{0}", _Indent);
				_Output.Write ("<dt>encode\n{0}", _Indent);
				_Output.Write ("</dl>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Command random\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The random command returns a randomized string in UDF format containing at\n{0}", _Indent);
				_Output.Write ("least 117 bits of random data.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The random command may be used to in scripts to generate temporary passwords \n{0}", _Indent);
				_Output.Write ("that are to be deleted as soon as the script completes.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("For example, Alice wants to export her GPG key from her Mesh profile to a local\n{0}", _Indent);
				_Output.Write ("file that can be input to her GPG mail application. She enters the following \n{0}", _Indent);
				_Output.Write ("commands:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("While this approach successfully configures her mail application, her private key\n{0}", _Indent);
				_Output.Write ("was written to the hard drive of the machine in the process. Even though she\n{0}", _Indent);
				_Output.Write ("used the delete command to remove the file containg the private key, this is\n{0}", _Indent);
				_Output.Write ("unlikely to prevent recovery using forensic tools on the storage media.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Encrypting the private key file under a randomly generated password is a\n{0}", _Indent);
				_Output.Write ("much more robust approach. But only if we make sure that our password does\n{0}", _Indent);
				_Output.Write ("not get written out to the disk either.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<ul>\n{0}", _Indent);
				_Output.Write ("<li>Disable the shell command history feature.\n{0}", _Indent);
				_Output.Write ("<li>Generate a random password.\n{0}", _Indent);
				_Output.Write ("<li>Export the private key encrypted under the random password.\n{0}", _Indent);
				_Output.Write ("<li>Import the private key to the application.\n{0}", _Indent);
				_Output.Write ("<li>Delete the private key file.\n{0}", _Indent);
				_Output.Write ("<li>Restart the machine to erase the password from memory.\n{0}", _Indent);
				_Output.Write ("</ul>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This is achieved using the following shell commands:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("export HISTFILE=/dev/null\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Command digest\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("##Command commit\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		}
	}
