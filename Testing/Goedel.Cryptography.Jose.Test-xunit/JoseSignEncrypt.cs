#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion



using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit;

public partial class TestCryptographyJose {

    public static TestCryptographyJose Test() => new();


    static string TestString = "This is a test";
    static string TestStringBad = "This is a Test"; // Flip one bit


    [Theory]
    [InlineData(CryptoAlgorithmId.Ed448)]
    [InlineData(CryptoAlgorithmId.Ed25519)]
    //[InlineData(CryptoAlgorithmID.X448)]
    //[InlineData(CryptoAlgorithmID.X25519)]
    [InlineData(CryptoAlgorithmId.DH)]
    [InlineData(CryptoAlgorithmId.RSAExch)]
    [InlineData(CryptoAlgorithmId.RSASign)]
    public void RoundTripKeyEphemeral(CryptoAlgorithmId cryptoAlgorithmID) {
        var key = KeyPair.Factory(cryptoAlgorithmID, keySecurity: KeySecurity.Ephemeral);
        var jsonPublic = Key.GetPublic(key);
        var key2 = jsonPublic.KeyPair;
        key.KeyIdentifier.TestEqual(key2.KeyIdentifier);

        Xunit.Assert.Throws<NotExportable>(() => Key.GetPrivate(key));

        //var key3 = jsonPrivate.KeyPair;
        //key.UDF.AssertEqual(key3.UDF);
        }

    [Theory]
    [InlineData(CryptoAlgorithmId.Ed448)]
    [InlineData(CryptoAlgorithmId.Ed25519)]
    //[InlineData(CryptoAlgorithmID.X448)]
    //[InlineData(CryptoAlgorithmID.X25519)]
    [InlineData(CryptoAlgorithmId.DH)]
    [InlineData(CryptoAlgorithmId.RSAExch)]
    [InlineData(CryptoAlgorithmId.RSASign)]
    public void RoundTripKeyExportable(CryptoAlgorithmId cryptoAlgorithmID) {



        var key = KeyPair.Factory(cryptoAlgorithmID, keySecurity: KeySecurity.Exportable);
        var jsonPublic = Key.GetPublic(key);
        var key2 = jsonPublic.KeyPair;
        key.KeyIdentifier.TestEqual(key2.KeyIdentifier);

        var jsonPrivate = Key.GetPrivate(key);
        var key3 = jsonPrivate.KeyPair;
        key.KeyIdentifier.TestEqual(key3.KeyIdentifier);
        }

    [Fact]
    public void Test_Jose_Encrypt() {

        // Limit - make use of KeyCollection.

        var JWE = new JoseWebEncryption(TestString, EncrypterKeyPair);
        var JWEText = JWE.ToString();
        var JWEProt = JWE.Protected.ToUTF8();

        var JWE2 = JoseWebEncryption.FromJson(JWEText.JsonReader(), false);
        var Data = JWE2.Decrypt(EncrypterKeyPair);
        var Text = Data.ToUTF8();

        (TestString == Text).TestTrue();
        }



    [Fact]
    public void Test_Jose_Encrypt_Symmetric() {

        var Key = Platform.GetRandomBits(256);
        var JWE = new JoseWebEncryption(TestString, Key);
        var JWEText = JWE.ToString();

        var JWE2 = JoseWebEncryption.FromJson(JWEText.JsonReader(), false);

        var Data = JWE2.Decrypt(Key);
        var Text = Data.ToUTF8();

        (TestString == Text).TestTrue();
        }


    [Fact]
    public void Test_Jose_Sign() {
        var JWS = new JoseWebSignature(TestString, SignerKeyPair);
        var JWSText = JWS.ToString();

        foreach (var Signer in JWS.Signatures) {
            var JWSProt = Signer.Protected.ToUTF8();
            }

        var JWS2 = JoseWebSignature.FromJson(JWSText.JsonReader(), false);

        var Verify1 = JWS2.Verify(SignerKeyPair);
        Verify1.TestTrue();

        JWS2.Payload = TestStringBad.ToBytes();
        var Verify2 = JWS2.Verify(SignerKeyPair);
        Verify2.TestFalse();
        }


    [Fact]
    public void Test_Jose_Sign_Encrypt() {

        var JWES = new JoseWebEncryption(TestString, EncrypterKeyPair, SignerKeyPair);
        var JWESText = JWES.ToString();
        var JWESProt = JWES.Protected.ToUTF8();

        foreach (var Signer in JWES.Signatures) {
            var JWSProt = Signer.Protected.ToUTF8();
            }

        var JWES2 = JoseWebEncryption.FromJson(JWESText.JsonReader(), false);

        var Data2 = JWES2.Decrypt(EncrypterKeyPair);
        var Text = Data2.ToUTF8();

        var Verify1 = JWES2.Verify(SignerKeyPair);

        (TestString == Text).TestTrue();
        Verify1.TestTrue();

        // Test: Check for a bad signature.
        }


    [Fact]
    public void Test_Write_RSA_Public() {
        var Key = new PublicKeyRSA(TestKeyPairRSA.PkixPublicKeyRsa);

        var Text = Key.ToJson();
        ("Test_Write_RSA_Public.jpub").WriteFileNew(Text);

        // TEST: check that the key can be read back and used???
        }

    [Fact]
    public void Test_Write_RSA_Private() {
        var Key = new PrivateKeyRSA(TestKeyPairRSA.PkixPrivateKeyRSA);

        var Text = Key.ToJson(true);
        ("Test_Write_RSA_Private.jprv").WriteFileNew(Text);

        // TEST: check that the key can be read back and used???
        }

    [Fact]
    public void Test_Write_DH_Public() {

        var Key = new PublicKeyDH(TestKeyPairDH.PKIXPublicKeyDH);

        var Text = Key.ToJson();
        ("Test_Write_DH_Public.jpub").WriteFileNew(Text);

        // TEST: check that the key can be read back and used???
        }

    [Fact]
    public void Test_Write_DH_Private() {
        var Key = new PrivateKeyDH(TestKeyPairDH.PKIXPrivateKeyDH);

        var Text = Key.ToJson(true);
        ("Test_Write_DH_Private.jprv").WriteFileNew(Text);

        // TEST: check that the key can be read back and used???
        }

    }
