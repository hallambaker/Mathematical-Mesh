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

namespace Goedel.Callsign;

public partial class ProfileResolver {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ProfileService> GetEnvelopedProfileAccount() => new(DareEnvelope);


    /// <summary>
    /// Default constructor, returns an empty instance.
    /// </summary>
    public ProfileResolver() {
        }



    /// <summary>
    /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
    /// </summary>
    /// <param name="secretSeed">The secret seed value.</param>
    /// <param name="keyCollection">The base key collection</param>
    /// <param name="persist">If true, persist the service record to the local machine
    /// <param name="envelopedProfileRegistry">The enveloped registry profile</param>
    /// store.</param>
    ProfileResolver(
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
    /// <param name="envelopedProfileRegistry">The enveloped registry profile.</param>
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
        return new ProfileResolver(envelopedProfileRegistry, secretSeed,
                    keyCollection, persist);
        }



    /// <summary>
    /// Create a new configuration of the resolver service.
    /// </summary>
    /// <param name="meshMachine">The Mesh Machine</param>
    /// <param name="envelopedProfileRegistry">The enveloped registry profile.</param>
    /// <param name="profileService">The service profile.</param>
    /// <param name="profileHost">The host profile.</param>
    /// <param name="activationDevice">The device activation.</param>
    /// <param name="connectionDevice">The device connection.</param>
    public static void CreateService(
                IMeshMachine meshMachine,
                Enveloped<ProfileAccount> envelopedProfileRegistry,
                out ProfileService profileService,
                out ProfileHost profileHost,
                out ActivationHost activationDevice,
                out ConnectionService connectionDevice) {

        profileService = Generate(envelopedProfileRegistry, meshMachine.KeyCollection);

        CreateService(meshMachine, profileService, out profileHost, out activationDevice,
            out connectionDevice);
        }

    }
