using  System.Text;
using  System.Numerics;
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
			 ExamplesThreshold(Example);
			 ExamplesThresholdSig(Example);
			}
		

		//
		// ExamplesAdvancedCoGeneration
		//
		public static void ExamplesAdvancedCoGeneration(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ExamplesAdvancedCoGeneration.md");
			Example._Output = _Output;
			Example._ExamplesAdvancedCoGeneration(Example);
			}
		public void _ExamplesAdvancedCoGeneration(CreateExamples Example) {

					}
		

		//
		// ExamplesAdvancedRecryption
		//
		public static void ExamplesAdvancedRecryption(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ExamplesAdvancedRecryption.md");
			Example._Output = _Output;
			Example._ExamplesAdvancedRecryption(Example);
			}
		public void _ExamplesAdvancedRecryption(CreateExamples Example) {

					}
		

		//
		// ExamplesThreshold
		//
		public static void ExamplesThreshold(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ExamplesThreshold.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ExamplesThreshold.md" };
			obj._ExamplesThreshold(Example);
			}
		public void _ExamplesThreshold(CreateExamples Example) {

				 var threshold = Example.Threshold;
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Threshold Key Generation\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### X25519\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeKeyGen (threshold.KeyGenX25519);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### X448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeKeyGen (threshold.KeyGenX448);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Ed25519\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeKeyGen (threshold.KeyGenEd25519);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Ed448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeKeyGen (threshold.KeyGenEd448);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Threshold Decryption\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Direct Key Splitting X25519\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeDecryptSplitting (threshold.DecryptX25519);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Direct Decryption X25519\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeDecryptUse (threshold.DecryptX25519);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Direct Key Splitting X448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeDecryptSplitting (threshold.DecryptX448);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Direct Decryption X448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				DescribeDecryptUse (threshold.DecryptX448);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Shamir Secret Sharing X448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[TBS]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Lagrange Decryption X448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[TBS]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// DescribeDecryptUse
		//
		public void DescribeDecryptUse (Decrypt Decrypt) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The means of encryption is unchanged. We begin by generating an ephemeral \n{0}", _Indent);
			_Output.Write ("key pair:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKey (Decrypt.KeyE);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The key agreement result is given by multiplying the public key of the encryption \n{0}", _Indent);
			_Output.Write ("pair by the secret scalar of the ephemeral key to obtain the u-coordinate of the result.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeValue (Decrypt.KeyEA.XTag, Decrypt.KeyEA.X) ;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The u-coordinate is encoded in the usual fashion (i.e. without specifying the sign of v).\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Decrypt.KeyEA.Public.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The first decryption contribution is generated from the secret scalar of the first key\n{0}", _Indent);
			_Output.Write ("share and the public key of the ephemeral.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The outputs from the Montgomery Ladder are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeValue ("x_2", Decrypt.KeyE1.X2);
			 DescribeValue ("z_2", Decrypt.KeyE1.Z2);
			 DescribeValue ("x_3", Decrypt.KeyE1.X3);
			 DescribeValue ("z_3", Decrypt.KeyE1.Z3);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The coordinates of the corresponding point are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeValue ("u", Decrypt.KeyE1.X);
			 DescribeValue ("v", Decrypt.KeyE1.Y);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The encoding of this point specifies the u coordinate and the sign (oddness) of the \n{0}", _Indent);
			_Output.Write ("v coordinate:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Decrypt.KeyE1.Public.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The second decryption contribution is generated from the secret scalar of the second key\n{0}", _Indent);
			_Output.Write ("share and the public key of the ephemeral in the same way:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeValue ("u", Decrypt.KeyE2.X);
			 DescribeValue ("v", Decrypt.KeyE2.Y);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Decrypt.KeyE2.Public.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To obtain the key agreement value, we add the two decryption contributions:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeValue ("u", Decrypt.KeyE12.X);
			 DescribeValue ("v", Decrypt.KeyE12.Y);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This returns the same u coordinate value as before, allowing us to obtain the encoding \n{0}", _Indent);
			_Output.Write ("of the key agreement value and decrypt the message.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// DescribeDecryptSplitting
		//
		public void DescribeDecryptSplitting (Decrypt Decrypt) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The encryption key pair is\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKey (Decrypt.KeyA);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To create n key shares we first create n-1 key pairs in the normal fashion. Since \n{0}", _Indent);
			_Output.Write ("these key pairs are only used for decryption operations, it is not necessary to \n{0}", _Indent);
			_Output.Write ("calculate the public components:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKeyPrivate (Decrypt.Key1);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The secret scalar of the final key share is the secret scalar of the base key minus\n{0}", _Indent);
			_Output.Write ("the sum of the secret scalars of the other shares modulo the group order:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Scalar_2 = (Scalar_A - Scalar_1) mod L\n{0}", _Indent);
			 DescribeResult (Decrypt.Key2.Scalar) ;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("This is encoded as a binary integer in little endian format:\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, Decrypt.Key2.Private.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// DescribeKeyGen
		//
		public void DescribeKeyGen (KeyGen KeyGen) {
			_Output.Write ("The key parameters of the first key contribution are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKey (KeyGen.Key1);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The key parameters of the second key contribution are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKey (KeyGen.Key2);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The composite private key is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Scalar_A = (Scalar_1 + Scalar_2) mod L\n{0}", _Indent);
			 DescribeResult (KeyGen.KeyA.Scalar) ;
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Encoded Composite Private Key:\n{0}", _Indent);
			_Output.Write ("{1}\n{0}", _Indent, KeyGen.KeyA.Private.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The composite public key is:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Point_A = Point_1 + Point_2\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			 DescribeValue (KeyGen.KeyA.XTag, KeyGen.KeyA.X) ;
			 DescribeValue (KeyGen.KeyA.YTag, KeyGen.KeyA.Y) ;
			// {KeyGen.KeyA.XTag}: #{}
			// {KeyGen.KeyA.YTag}: #{KeyGen.KeyA.Y}
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Encoded Public{1}\n{0}", _Indent, KeyGen.KeyA.Public.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			if (  (KeyGen.KeyA.IsCurveX)  ) {
				_Output.Write ("Note that in this case, the unsigned representation of the key is used as\n{0}", _Indent);
				_Output.Write ("the composite key is intended for unsigned CurveX key agreement. If the\n{0}", _Indent);
				_Output.Write ("result is intended for use as a key contribution, the signed representation\n{0}", _Indent);
				_Output.Write ("is required.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			}
		

		//
		// DescribeResult
		//
		public void DescribeResult (string tag, string text) {
			 var ptag = (tag + " = ").PadRight (8);
			 var wrapped = text.Wrap(ptag, indent:12);
			_Output.Write ("{1}", _Indent, wrapped);
			}
		

		//
		// DescribeResult
		//
		public void DescribeResult (string tag, BigInteger number) {
			 DescribeResult (tag, number.ToString());
			}
		

		//
		// DescribeResult
		//
		public void DescribeResult (string text) {
			 var wrapped = text.Wrap("    =", indent:8);
			_Output.Write ("{1}", _Indent, wrapped);
			}
		

		//
		// DescribeResult
		//
		public void DescribeResult (BigInteger number) {
			 DescribeResult (number.ToString());
			}
		

		//
		// DescribeValue
		//
		public void DescribeValue (string tag, string text) {
			 var ptag = ("    " + tag + ":").PadRight (20);
			 var wrapped = text.Wrap(ptag, indent:8);
			_Output.Write ("{1}", _Indent, wrapped);
			}
		

		//
		// DescribeValue
		//
		public void DescribeValue (string tag, BigInteger number) {
			 DescribeValue (tag, number.ToString());
			}
		

		//
		// DescribeKeyPrivate
		//
		public void DescribeKeyPrivate (CurveKey Key) {
			_Output.Write ("{1} ({2})\n{0}", _Indent, Key.Name, Key.Curve);
			 DescribeValue ("UDF", Key.UDF);
			 DescribeValue ("Scalar", Key.Scalar);
			//    UDF:        #{Key.UDF}
			//    Scalar:     #{Key.Scalar}
			_Output.Write ("    Encoded Private{1}\n{0}", _Indent, Key.Private.ToStringBase16FormatHex());
			}
		

		//
		// DescribeKey
		//
		public void DescribeKey (CurveKey Key) {
			DescribeKeyPrivate (Key);
			 DescribeValue (Key.XTag, Key.X);
			 DescribeValue (Key.YTag, Key.Y);
			//    #{Key.XTag}: #{Key.X}
			//    #{Key.YTag}: #{Key.Y}
			_Output.Write ("    Encoded Public{1}\n{0}", _Indent, Key.Public.ToStringBase16FormatHex());
			}
		

		//
		// ExamplesThresholdSig
		//
		public static void ExamplesThresholdSig(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\ExamplesThresholdSig.md");			var obj = new CreateExamples() { _Output = _Output, _Indent = "", _Filename = "Examples\\ExamplesThresholdSig.md" };
			obj._ExamplesThresholdSig(Example);
			}
		public void _ExamplesThresholdSig(CreateExamples Example) {

				_Output.Write ("## Direct Threshold Signature Ed25519\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				Describe (Example.ThresholdSignature.UnanimousEd25519);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Direct Threshold Signature Ed448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				Describe (Example.ThresholdSignature.UnanimousEd448);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Shamir Threshold Signature Ed25519\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				Describe (Example.ThresholdSignature.QuorateEd25519);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("## Shamir Threshold Signature Ed448\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				Describe (Example.ThresholdSignature.QuorateEd448);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// Describe
		//
		public void Describe (Quorate sig) {
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The administrator creates the composite key pair\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKey (sig.KeyAggregate);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Three key shares are required for Alice, Bob and Carol with a threshold of two. \n{0}", _Indent);
			_Output.Write ("The parameters of the Shamir Secret Sharing polynomial are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("a0", sig.A0);
			 DescribeResult ("a1", sig.A1);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The key share values for the participants are\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("xa", sig.Xa);
			 DescribeResult ("ya", sig.Ya);
			_Output.Write ("\n{0}", _Indent);
			 DescribeResult ("xb", sig.Xb);
			 DescribeResult ("yb", sig.Yb);
			_Output.Write ("\n{0}", _Indent);
			 DescribeResult ("xc", sig.Xc);
			 DescribeResult ("yc", sig.Yc);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice and Carol are selected to sign the message \"{1}\"\n{0}", _Indent, sig.TestData);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The Lagrange coefficients are:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("la", sig.La);
			 DescribeResult ("lc", sig.Lc);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice and Carol select their values ra, rc\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("ra", sig.Ra);
			_Output.Write ("Ra = {1}\n{0}", _Indent, sig.RRa.ToStringBase16FormatHex());
			_Output.Write ("\n{0}", _Indent);
			 DescribeResult ("rc", sig.Rc);
			_Output.Write ("Rc = {1}\n{0}", _Indent, sig.RRc.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The composite value R = R<sub>a</sub> + R<sub>c</sub>\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("R =  {1}\n{0}", _Indent, sig.R.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The value k is \n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("k", sig.K);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The values R and k (or the document to be signed) and the \n{0}", _Indent);
			_Output.Write ("Lagrange coefficients are passed to Alice and Carol who use them to \n{0}", _Indent);
			_Output.Write ("calculate their secret scalar values:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("sa", sig.Sa);
			 DescribeResult ("sc", sig.Sc);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The signature contributions can now be calulated:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("Sa", sig.SSa);
			 DescribeResult ("Sc", sig.SSc);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The dealer calculates the composite value S = S<sub>a</sub> + S<sub>b</sub>\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			 DescribeResult ("S", sig.S);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The dealer checks to see that the signature verifies:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("S.B = R + kA = \n{0}", _Indent);
			 DescribeValue ("X", sig.SBX);
			 DescribeValue ("X", sig.SBY);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		

		//
		// Describe
		//
		public void Describe (Unanimous sig) {
			_Output.Write ("The signers are Alice and Bob's Threshold Signature Service 'Bob'. Each creates a key pair:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKey (sig.KeyAlice);
			DescribeKey (sig.KeyBob);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("The composite Signature Key A = A<sub>a</sub> + A<sub>b</sub>\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			DescribeKey (sig.KeyAggregate);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("To sign the text \"{1}\", Alice first generates her value r\n{0}", _Indent, sig.TestData);
			_Output.Write ("and multiplies it by the base point to obtain the value R<sub>a</sub>:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Alice:\n{0}", _Indent);
			 DescribeValue ("r_a", sig.Ra);
			_Output.Write ("R_a =  {1}\n{0}", _Indent, sig.RRa.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice passes her value R<sub>A</sub> to Bob along with the other \n{0}", _Indent);
			_Output.Write ("parameters required to calculate i. Bob then calculates his\n{0}", _Indent);
			_Output.Write ("value R<sub>A</sub> and multiplies it by the base point to obtain \n{0}", _Indent);
			_Output.Write ("the value R<sub>b</sub>:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Bob:\n{0}", _Indent);
			 DescribeValue ("r_b", sig.Rb);
			_Output.Write ("R_b =  {1}\n{0}", _Indent, sig.RRb.ToStringBase16FormatHex());
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob can now calculate the composite value R = R<sub>a</sub> + R<sub>b</sub>\n{0}", _Indent);
			_Output.Write ("and thus the value k.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("R =  {1}\n{0}", _Indent, sig.R.ToStringBase16FormatHex());
			 DescribeValue ("k", sig.K);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Bob calculates his signature scalar contribution and returns the value to Alice:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Bob:\n{0}", _Indent);
			 DescribeValue ("S_b", sig.SSb);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice can now calculate her signature scalar contribution and thus the signature \n{0}", _Indent);
			_Output.Write ("scalar S.\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("Alice:\n{0}", _Indent);
			 DescribeValue ("S_a", sig.SSa);
			 DescribeValue ("S", sig.S);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("Alice checks to see that the signature verifies:\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("S.B = R + kA = \n{0}", _Indent);
			 DescribeValue ("X", sig.SBX);
			 DescribeValue ("Y", sig.SBY);
			_Output.Write ("~~~~\n{0}", _Indent);
			}
		

		//
		// ExamplesAdvancedQuantum
		//
		public static void ExamplesAdvancedQuantum(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ExamplesAdvancedQuantum.md");
			Example._Output = _Output;
			Example._ExamplesAdvancedQuantum(Example);
			}
		public void _ExamplesAdvancedQuantum(CreateExamples Example) {

				_Output.Write ("##Example: Creating a Quantum Resistant Signature Fingerprint\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice decides to add a QRSF to her Mesh Profile. She creates\n{0}", _Indent);
				_Output.Write ("a 256 bit master secret.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, ShellKey.AdvancedQuantumMasterSecret);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To enable recovery of the master key, Alice creates five keyshares with a quorum of three:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, ShellKey.AdvancedQuantumShares);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice uses the master secret to derrive her private key values:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, ShellKey.AdvancedQuantumPrivate);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("These values are used to generate the public key value:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, ShellKey.AdvancedQuantumPublic);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The QRSF contains the UDF fingerprint of the public key\n{0}", _Indent);
				_Output.Write ("value plus the XMSS parameters:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("TBS: {1}\n{0}", _Indent, ShellKey.AdvancedQuantumPublicUDF);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice adds the QRSF to her profile and publishes it to a Mesh Service that is enrolled\n{0}", _Indent);
				_Output.Write ("in at least one multi-party notary scheme.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
