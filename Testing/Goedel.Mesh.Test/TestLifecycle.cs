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


namespace Goedel.Mesh.Test;

public static class Crypto {

    static int IDCount = 0;
    public static string MakeUnique(this string Base) {
        var Count = Interlocked.Increment(ref IDCount);
        var Split = Base.Split('@');

        return Split[0] + "_" + Count.ToString() + "@" + Split[1];
        }


    static Crypto() {
        }


    public static void Test_EncryptDecrypt(this KeyPair KeyPair) {

        var Key = Platform.GetRandomBits(256);

        KeyPair.Encrypt(Key, out var Exchange, out var Ephemeral);
        var Result = KeyPair.Decrypt(Exchange, Ephemeral);

        Key.IsEqualTo(Result).TestTrue();

        }


    public static void Test_Lifecycle(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
        Test_LifecycleMaster(CryptoAlgorithmID, keyCollection, KeySize);
        Test_LifecycleAdmin(CryptoAlgorithmID, keyCollection, KeySize);
        Test_LifecycleDevice(CryptoAlgorithmID, keyCollection, KeySize);
        Test_LifecycleEphemeral(CryptoAlgorithmID, keyCollection, KeySize);
        Test_LifecycleExportable(CryptoAlgorithmID, keyCollection, KeySize);
        }



    public static void Test_LifecycleMaster(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
        bool Exportable = true;
        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Master, keyCollection, keySize: KeySize);
        Encrypter.Test_EncryptDecrypt();
        TestExport(Encrypter, Exportable);
        CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
        }

    public static void Test_LifecycleAdmin(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
        bool Exportable = false;
        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Admin, keyCollection, keySize: KeySize);
        Encrypter.Test_EncryptDecrypt();
        TestExport(Encrypter, Exportable);
        CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
        }



    public static void Test_LifecycleDevice(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
        bool Exportable = false;
        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Device, keyCollection, keySize: KeySize);
        Encrypter.Test_EncryptDecrypt();
        TestExport(Encrypter, Exportable);
        CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
        }


    /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
    /// fails as the key is never written to the local store</summary>
    /// <param name="CryptoAlgorithmID"></param>
    public static void Test_LifecycleEphemeral(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
        bool Exportable = false;
        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Ephemeral, keyCollection, keySize: KeySize);
        Encrypter.Test_EncryptDecrypt();
        TestExport(Encrypter, Exportable);
        CheckPersisted(Encrypter.KeyIdentifier, keyCollection, false, Exportable);
        }

    /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
    /// fails as the key is never written to the local store</summary>
    /// <param name="CryptoAlgorithmID"></param>
    public static void Test_LifecycleExportable(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
        bool Exportable = true;
        var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.ExportableStored, keyCollection, keySize: KeySize);
        Encrypter.Test_EncryptDecrypt();
        TestExport(Encrypter, Exportable);
        CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
        }


    static void TestExport(KeyPair keyPair, bool Succeed) {

        IPKIXPrivateKey Private = null;
        try {
            Private = keyPair.PKIXPrivateKey;
            Succeed.TestTrue();
            }
        catch (NotExportable) {
            Succeed.TestFalse();
            Private.TestNull();
            }

        }


    /// <summary>
    /// Check persistence of the key, that it can be found in the local store and
    /// then that it cannot be found after deletion.
    /// </summary>
    /// <param name="UDF"></param>
    static void CheckPersisted(string UDF, KeyCollection keyCollection, bool persisted, bool exportable) {

        keyCollection.LocatePrivateKeyPair(UDF, out var key);
        if (!persisted) {
            key.TestNull();
            return;
            }
        TestExport(key as KeyPair, exportable);
        }



    }
