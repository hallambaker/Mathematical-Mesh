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
namespace Goedel.Cryptography.Jose;

/// <summary>
/// Interface providing key activation functions. This interface is supported
/// by PrivateKeyUDF allowing keys to be derived from a pair of seeds. Devices
/// whose keys are bound to an HSM should provide a class exposing the IActivate
/// interface that exposes the necessary functionality for key location,
/// activation and use.
/// </summary>
public interface IActivate {

    ///<summary>The encryption algorithm identifier</summary>
    CryptoAlgorithmId AlgorithmEncryptID { get; }

    ///<summary>The signature algorithm identifier</summary>
    CryptoAlgorithmId AlgorithmSignID { get; }

    ///<summary>The authentication algorithm identifier</summary>
    CryptoAlgorithmId AlgorithmAuthenticateID { get; }


    /// <summary>
    /// Generate a composite private key by generating private keys by means
    /// of the activation seed <paramref name="activationSeed"/> and the
    /// class instance generator.
    /// </summary>
    /// <param name="activationSeed">The activation seed value.</param>
    /// <param name="keyCollection">The key collection to register the private key to</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="saltSuffix">The salt suffix for use in key derrivation.</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm.</param>
    /// <returns>The generated ephemeral key.</returns>
    KeyPair ActivatePrivate(
        string activationSeed,
        IKeyLocate keyCollection,
        KeyUses keyUses, string saltSuffix,
        CryptoAlgorithmId cryptoAlgorithmID);

    }

public partial class PrivateKeyUDF : IActivate {


    ///<summary>The encryption algorithm identifier</summary>
    public CryptoAlgorithmId AlgorithmEncryptID =>
        AlgorithmEncrypt != null ? AlgorithmEncrypt.FromJoseID() : CryptoAlgorithmId.Default;

    ///<summary>The signature algorithm identifier</summary>
    public CryptoAlgorithmId AlgorithmSignID =>
        AlgorithmSign != null ? AlgorithmSign.FromJoseID() : CryptoAlgorithmId.Default;

    ///<summary>The authentication algorithm identifier</summary>
    public CryptoAlgorithmId AlgorithmAuthenticateID =>
        AlgorithmAuthenticate != null ? AlgorithmAuthenticate.FromJoseID() : CryptoAlgorithmId.Default;


    /// <summary>
    /// Basic constructor for deserialization
    /// </summary>
    public PrivateKeyUDF() {
        }

    /// <summary>
    /// Constructor generating a new instance with a private key derrived from the
    /// seed  <paramref name="secret"/> if not null or a random value otherwise.
    /// </summary>
    /// <param name="udf">The secret seed specified as a UDF.</param>
    /// <param name="udfAlgorithmIdentifier">The type of master secret.</param>
    /// <param name="secret">The master secret as a byte array.</param>
    /// <param name="algorithmEncrypt">The encryption algorithm.</param>
    /// <param name="algorithmSign">The signature algorithm</param>
    /// <param name="algorithmAuthenticate">The signature algorithm</param>
    /// <param name="bits">The size of key to generate in bits/</param>
    /// 
    public PrivateKeyUDF(
                string udf = null,
            UdfAlgorithmIdentifier udfAlgorithmIdentifier = UdfAlgorithmIdentifier.Any,
            byte[] secret = null,
            CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
            int bits = 256) {

        if (udf == null) {
            PrivateValue = udf ?? UDF.DerivedKey(udfAlgorithmIdentifier,
                data: secret ?? Platform.GetRandomBits(bits));
            }
        else {
            PrivateValue = udf;
            (udfAlgorithmIdentifier, _) = UDF.ParseUdfAlgorithmIdentifier(udf);
            }

        KeyType = udfAlgorithmIdentifier.ToString();
        AlgorithmSign = algorithmSign.ToJoseID();
        AlgorithmEncrypt = algorithmEncrypt.ToJoseID();
        AlgorithmAuthenticate = algorithmAuthenticate.ToJoseID();
        }


    ///// <summary>
    ///// Constructor generating a new instance with a private key derrived from the
    ///// value  <paramref name="udf"/> if not null or a random value otherwise.
    ///// </summary>
    ///// <param name="udf">The UDF encoding of the secret value.</param>
    ///// <param name="algorithmEncrypt">The encryption algorithm.</param>
    ///// <param name="algorithmSign">The signature algorithm</param>
    ///// <param name="algorithmAuthenticate">The signature algorithm</param>
    //public PrivateKeyUDF(
    //        string udf,
    //        CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
    //        CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
    //        CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default
    //        ) : this (algorithmEncrypt: algorithmEncrypt,
    //            algorithmSign: algorithmSign, algorithmAuthenticate: algorithmAuthenticate,
    //                udf: udf) {
    //    }

    /// <summary>
    /// Generate a composite private key by generating private keys by means
    /// of the activation seed <paramref name="activationSeed"/> and the
    /// class instance generator.
    /// </summary>
    /// <param name="activationSeed">The activation seed value.</param>
    /// <param name="keyCollection">The key collection to register the private key to</param>
    /// <param name="keyUses">The permitted key uses.</param>
    /// <param name="saltSuffix">The salt suffix for use in key derrivation.</param>
    /// <param name="cryptoAlgorithmID">The cryptographic algorithm.</param>
    /// <returns>The generated ephemeral key.</returns>
    public KeyPair ActivatePrivate(
                string activationSeed,
                IKeyLocate keyCollection,
                KeyUses keyUses, string saltSuffix,
                CryptoAlgorithmId cryptoAlgorithmID) {
        var baseKey = UDF.DeriveKey(PrivateValue, keyCollection,
                KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, saltSuffix) as KeyPairAdvanced;

        //Console.WriteLine($"Private: Base-{baseKey.UDF} Seed-{activationSeed} Type-{meshKeyType}");

        var activationKey = UDF.DeriveKey(activationSeed, keyCollection,
                KeySecurity.Ephemeral, keyUses: keyUses, cryptoAlgorithmID, saltSuffix) as KeyPairAdvanced;



        var combinedKey = activationKey.Combine(baseKey, keyUses: keyUses);

        //Console.WriteLine($"   result {combinedKey}");

        return combinedKey;
        }


    }
