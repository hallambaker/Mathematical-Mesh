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
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;

namespace Goedel.Test;


public class CryptoParametersTest : CryptoParameters {

    KeyCollection KeyCollection => KeyLocate as KeyCollectionCore;

    public CryptoParametersTest(
                List<string> recipients = null,
                List<string> signers = null,
                CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                CryptoAlgorithmId digestID = CryptoAlgorithmId.NULL) :
        base(new KeyCollectionCore(), recipients, signers, encryptID: encryptID, digestID: digestID) {
        }

    protected override void AddEncrypt(string AccountId) => AddEncrypt(AccountId, true);

    public void AddEncrypt(string AccountId, bool Register = true) {
        EncryptionKeys ??= new List<CryptoKey>();

        var Keypair = new KeyPairDH();
        var Pub = Keypair.KeyPairPublic();
        var PublicKeyKeypair = Keypair.KeyPairPublic();
        EncryptionKeys.Add(PublicKeyKeypair);

        //Console.WriteLine($"Keypair is {Keypair.UDF}");
        //Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
        //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

        if (Register) {
            KeyCollection.Add(Keypair);
            }

        }

    protected override void AddSign(string accountId) => AddSign(accountId, true);
    public void AddSign(string accountId, bool register) {
        SignerKeys ??= new List<CryptoKey>();

        var Keypair = KeyPair.KeyPairFactoryRSA(keyType: KeySecurity.Ephemeral);
        var PublicKeyKeypair = Keypair.KeyPairPublic();
        SignerKeys.Add(Keypair);

        //Console.WriteLine($"Keypair is {Keypair.UDF}");
        //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

        if (register) {
            KeyCollection.Add(Keypair);
            }
        }

    }



public class TestKeys {

    public KeyCollection KeyCollection;

    public List<KeyPair> EncryptionKeys;
    public List<KeyPair> SignerKeys;

    public TestKeys(KeyCollection keyCollection = null) => KeyCollection = keyCollection ?? KeyCollection.Default;

    public void AddEncrypt(bool register = true) {
        EncryptionKeys ??= new List<KeyPair>();

        var Keypair = new KeyPairDH();
        var Public = Keypair.PKIXPublicKeyDH;
        var PublicKeyKeypair = KeyPairDH.KeyPairPublicFactory(Public);
        EncryptionKeys.Add(PublicKeyKeypair);

        //Console.WriteLine($"Keypair is {Keypair.UDF}");
        //Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
        //Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

        if (register) {
            KeyCollection.Default.Add(Keypair);
            }
        }

    public void AddSign(bool register = true) {
        SignerKeys ??= new List<KeyPair>();

        throw new NYI();
        }
    }
