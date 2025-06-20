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


using Goedel.Contacts;

namespace Goedel.Mesh;

public record PrivateKeyEntry  {

    public string KeyId { get; }
    public string AccountId { get; }
    public ProfileAccount ProfileAccount { get; }

    public OnlineService Service { get; }
    public JsonWebKeySet JsonWebKeySet { get; }

    //KeyPair keyPair;
    //public KeyPair KeyPair => keyPair ?? GetKeyPair().CacheValue(out keyPair);
    public PrivateKeyEntry (
                    JsContact contact,
                    OnlineService service,
                    JsonWebKeySet jsonWebKeySet
                    )  {
        Service = service;
        JsonWebKeySet = jsonWebKeySet;
        ProfileAccount = null;

        foreach (var cryptoId in service.CryptoKeyIds.IfEnumerable()) {
            switch (cryptoId.Value) {
                case ContactConstant.OnlineServiceGroup: {
                    AccountId = cryptoId.Key;
                    break;
                    }
                case ContactConstant.CryptoKeyEncrypt: {
                    KeyId = cryptoId.Key;
                    break;
                    }
                }
            }
        }




    //public byte[] Decrypt(
    //                byte[] encryptedKey, 
    //                IAgreementData ephemeral = null, 
    //                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
    //                KeyAgreementResult partial = null, 
    //                byte[] salt = null) {
    //    return KeyPair.Decrypt(encryptedKey, ephemeral, algorithmID, partial, salt);

    //    throw new NotImplementedException();
    //    }


    public KeyPair GetKeyPair(IKeyCollection keyLocate) {
        Console.WriteLine(JsonWebKeySet.Data.ToUTF8());
        var enveloped = JsonObject.StreamParse<Enveloped>(JsonWebKeySet.Data);

        var keyData = enveloped.StreamParseTag<KeyData>(keyLocate);
        Console.WriteLine(JsonWebKeySet.Data.ToUTF8());
        return keyData.GetKeyPair(KeySecurity.Bound, keyLocate);
        }

    }
    
