//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Cryptography.Jose;
using Goedel.Mesh;

namespace Goedel.Callsign;

public partial class ProfileResolver {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ProfileService> GetEnvelopedProfileAccount() => new(DareEnvelope);

    public ProfileResolver() {
        }

    /// <summary>
    /// Construct a Profile Account instance  from <paramref name="accountAddress"/>.
    /// </summary>
    /// <param name="accountAddress">The account address</param>
    /// <param name="activationAccount">The activation used to create the account data.</param>
    public ProfileResolver(
                string accountAddress,
                Enveloped<ProfileAccount> envelopedProfileRegistry,
                ActivationCommon activationAccount) {
        EnvelopedProfileRegistry = envelopedProfileRegistry;
        ProfileSignature = new KeyData(activationAccount.ProfileSignatureKey);

        CommonEncryption = new KeyData(activationAccount.CommonEncryptionKey);
        CommonAuthentication = new KeyData(activationAccount.CommonAuthenticationKey);


        Envelope(activationAccount.ProfileSignatureKey);
        }

    /// <summary>
    /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
    /// </summary>
    /// <param name="secretSeed">The secret seed value.</param>
    /// <param name="keyCollection">The base key collection</param>
    /// <param name="persist">If true, persist the service record to the local machine
    /// store.</param>
    ProfileResolver(
                string accountAddress,
                Enveloped<ProfileAccount> envelopedProfileRegistry,
                PrivateKeyUDF secretSeed,
                IKeyCollection keyCollection,
                bool persist = false) : base(secretSeed, keyCollection, persist) {

        EnvelopedProfileRegistry = envelopedProfileRegistry;
        Envelope(KeyProfileSign);

        }


    /// <summary>
    /// Generate profile specific keys.
    /// </summary>
    protected override void Generate() {
        base.Generate();
        }




    /// <summary>
    /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
    /// seed.
    /// </summary>
    /// <param name="secretSeed">The secret seed value.</param>
    /// <param name="algorithmEncrypt">The encryption algorithm.</param>
    /// <param name="algorithmSign">The signature algorithm</param>
    /// <param name="algorithmAuthenticate">The signature algorithm</param>
    /// <param name="bits">The size of key to generate in bits/</param>
    /// <param name="keyCollection">The keyCollection to manage and persist the generated keys.</param>
    /// <param name="persist">If <see langword="true"/> persist the secret seed value to
    /// <paramref name="keyCollection"/>.</param>
    /// <returns>The created profile.</returns>
    public static ProfileResolver Generate(
                string resolverAddress,
                Enveloped<ProfileAccount> envelopedProfileRegistry,
                IKeyCollection keyCollection,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                int bits = 256,
                PrivateKeyUDF secretSeed = null,
                bool persist = false) {
        secretSeed ??= new PrivateKeyUDF(
            udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount, secret: null, algorithmEncrypt: algorithmEncrypt,
            algorithmSign: algorithmSign, algorithmAuthenticate: algorithmAuthenticate, bits: bits);
        return new ProfileResolver(resolverAddress, envelopedProfileRegistry, 
                    secretSeed, keyCollection, persist);
        }




    /// <summary>
    /// Verify the profile to check that it is correctly signed and consistent.
    /// </summary>
    /// <returns></returns>
    public override void Validate() {
        base.Validate();

        //AccountEncryptionKey.PublicOnly.AssertTrue(InvalidProfile.Throw);
        //AdministratorSignatureKey.PublicOnly.AssertTrue(InvalidProfile.Throw);

        }


    }
