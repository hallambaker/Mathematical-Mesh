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
using Goedel.Cryptography;

namespace Goedel.Mesh;


public partial class CryptoKeyIndex {

    /// <summary>The cataloged contact.</summary>
    public CatalogedContact CatalogedContact { get; set; }

    /// <summary>Constructor used for deserialization.</summary>
    public CryptoKeyIndex() {
        }

    /// <summary>Constructor, retun an instance from <paramref name="service"/> for the
    /// shae <paramref name="shareId"/></summary>
    /// <param name="service">The service.</param>
    /// <param name="shareId">The Key share identifier.</param>
    public CryptoKeyIndex(OnlineService service, string shareId) {
        KeyShareId = shareId;
        foreach (var cryptoId in service.CryptoKeyIds.IfEnumerable()) {
            switch (cryptoId.Value) {
                case ContactConstant.OnlineServiceGroup: {
                    AccountId = cryptoId.Key;
                    break;
                    }
                case ContactConstant.CryptoKeyEncrypt: {
                    PublicKeyId = cryptoId.Key;
                    break;
                    }
                }
            }
        }

    /// <summary>Get keypair for this entry from <paramref name="keyCollection"/></summary>
    /// <param name="keyCollection">The key collection to search.</param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public KeyPair GetKeyPair(IKeyCollection keyCollection) {
        var contact = CatalogedContact.JsContact;
        if (contact.OnlineServices == null | contact.CryptoKeys == null) {
            return null;
            }

        if (!contact.CryptoKeys.TryGetValue(KeyShareId, out var keyShare)) {
            return null;
            }
        var jsonWebKeySet = keyShare as JsonWebKeySet;

        //Console.WriteLine(jsonWebKeySet.Data.ToUTF8());
        var enveloped = StreamParse<Enveloped>(jsonWebKeySet.Data);

        var keyData = enveloped.StreamParseTag<KeyData>(keyCollection);
        //Console.WriteLine(jsonWebKeySet.Data.ToUTF8());
        return keyData.GetKeyPair(KeySecurity.Bound, keyCollection);



        throw new NYI();
        }

    }


/// <summary>Private key entry record.</summary>
public record PrivateKeyEntry  {

    /// <summary>The key identifier.</summary>
    public string KeyId { get; }

    /// <summary>The account</summary>
    public string AccountId { get; }

    /// <summary>The account profile.</summary>
    public ProfileAccount ProfileAccount { get; }

    /// <summary>The online service.</summary>
    public OnlineService Service { get; }

    /// <summary>The JWK</summary>
    public JsonWebKeySet JsonWebKeySet { get; }

    /// <summary>Constructor.</summary>
    /// <param name="contact"></param>
    /// <param name="service"></param>
    /// <param name="jsonWebKeySet"></param>
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


    /// <summary>Get keypair for this entry from <paramref name="keyLocate"/></summary>
    /// <param name="keyLocate">The key collection to search.</param>
    /// <returns></returns>

    public KeyPair GetKeyPair(IKeyCollection keyLocate) {
        //Console.WriteLine(JsonWebKeySet.Data.ToUTF8());
        var enveloped = JsonObject.StreamParse<Enveloped>(JsonWebKeySet.Data);

        var keyData = enveloped.StreamParseTag<KeyData>(keyLocate);
        //Console.WriteLine(JsonWebKeySet.Data.ToUTF8());
        return keyData.GetKeyPair(KeySecurity.Bound, keyLocate);
        }

    }
    
