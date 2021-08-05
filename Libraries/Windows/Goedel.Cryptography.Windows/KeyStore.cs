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



namespace Goedel.Cryptography.Windows {
    //class KeyStore {

    //    readonly static byte[] EntropyBytes = "Mathematical Mesh Encrypted Key".ToBytes();
    //    const string DirectoryUserPrivate = @"Microsoft\Crypto\Mesh";
    //    static string KeystoreUserPrivate;

    //    const string ExportFalse = "NO-EXPORT";
    //    const string ExportTrue = "Exportable";

    //    static KeyStore() {
    //        var AppData = Environment.GetFolderPath(
    //                    Environment.SpecialFolder.ApplicationData);
    //        KeystoreUserPrivate = Path.Combine(AppData, DirectoryUserPrivate);
    //        }


    //    static string FileName(string UDF) => Path.Combine(KeystoreUserPrivate, UDF);

    //    /// <summary>
    //    /// Write a key to the machine keystore
    //    /// </summary>
    //    /// <param name="Data">The key data</param>
    //    /// <param name="KeySecurity">The storage security level</param>
    //    public static void WriteToKeyStore(IPKIXPrivateKey Data, KeySecurity KeySecurity) {

    //        if (!KeySecurity.IsPersisted()) {
    //            return;
    //            }
    //        var UDF = Data.UDF();
    //        var Description = (KeySecurity.IsExportable() ? ExportTrue : ExportFalse) +
    //                " Private Key " + UDF;
    //        var JoseKey = Key.Factory(Data);
    //        var Plaintext = JoseKey.ToJson(true);
    //        var CipherText = DPAPI.Encrypt(Plaintext, Description: Description, EntropyBytes: EntropyBytes);
    //        var File = FileName(UDF);

    //        var Directory = System.IO.Directory.CreateDirectory(KeystoreUserPrivate);
    //        File.WriteFileNew(CipherText);
    //        }

    //    /// <summary>
    //    /// Retrieve record from the local key store. 
    //    /// </summary>
    //    /// <param name="UDF">The key identifier</param>
    //    /// <param name="KeyType">Key type, if known</param>
    //    /// <returns></returns>
    //    public static KeyPair FindInKeyStore(string UDF,
    //            CryptoAlgorithmID KeyType = CryptoAlgorithmID.Default) {

    //        var File = FileName(UDF);
    //        byte[] Data = new byte[0xffff]; // Max size for key file is 64Kb
    //        int Length;

    //        try {
    //            using (var Stream = File.OpenFileReadShared()) {
    //                Length = Stream.Read(Data, 0, Data.Length);
    //                }
    //            }
    //        catch {
    //            return null;
    //            }

    //        var CipherText = new byte[Length];
    //        Array.Copy(Data, CipherText, Length);

    //        //string Description;
    //        var Plaintext = DPAPI.Decrypt(CipherText, out var Description, EntropyBytes);
    //        var PlaintextText = Plaintext.ToUTF8();
    //        var JoseKey = Key.FromJSON(PlaintextText.JSONReader());


    //        var Exportable = Description.StartsWith(ExportTrue);

    //        return JoseKey.GetKeyPair();
    //        }

    //    /// <summary>
    //    /// Erase Key record from the local key store. 
    //    /// </summary>
    //    /// <param name="UDF">The key identifier</param>
    //    /// <param name="KeyType">Key type, if known</param>
    //    /// <returns></returns>
    //    public static bool EraseFromDevice(string UDF,
    //            CryptoAlgorithmID KeyType = CryptoAlgorithmID.Default) {
    //        var FilePath = FileName(UDF);

    //        File.Delete(FilePath);


    //        return false;
    //        }


    //    }
    }