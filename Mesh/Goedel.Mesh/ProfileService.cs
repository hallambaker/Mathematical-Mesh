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


namespace Goedel.Mesh;

public partial class ProfileService {
    #region // Properties
    ///<summary>The actor type</summary> 
    public override MeshActor MeshActor => MeshActor.Service;

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<ProfileService> GetEnvelopedProfileService() => new(DareEnvelope);

    ///<summary>The service signature key</summary> 
    public KeyPair KeySignature { get; private set; }

    ///<summary>The service encryption key</summary> 
    public KeyPair KeyEncryption { get; private set; }

    ///<summary>The service authentication key</summary> 
    public KeyPair KeyAuthentication { get; private set; }
    #endregion
    #region // Constructors
    /// <summary>
    /// Blank constructor for use by deserializers.
    /// </summary>
    public ProfileService() { }

    /// <summary>
    /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
    /// </summary>
    /// <param name="secretSeed">The secret seed value.</param>
    /// <param name="keyCollection">The base key collection</param>
    /// <param name="persist">If true, persist the service record to the local machine
    /// store.</param>
    protected ProfileService(
                PrivateKeyUDF secretSeed,
                IKeyCollection keyCollection,
                bool persist = false) : base(secretSeed, keyCollection, persist) {
        }
    #endregion
    #region // Methods 

    /// <summary>
    /// Generate profile specific keys.
    /// </summary>
    protected override void Generate() {
        base.Generate();
        (KeySignature, ServiceSignature) = SecretSeed.GenerateContributionKey(
                MeshKeyType, MeshActor, MeshKeyOperation.Sign);
        (KeyAuthentication, ServiceAuthentication) = SecretSeed.GenerateContributionKey(
                MeshKeyType, MeshActor, MeshKeyOperation.Authenticate);
        (KeyEncryption, ServiceEncryption) = SecretSeed.GenerateContributionKey(
                MeshKeyType, MeshActor, MeshKeyOperation.Encrypt);
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
    public static ProfileService Generate(
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
        return new ProfileService(secretSeed, keyCollection, persist);
        }

    public static void CreateService(
                IMeshMachine meshMachine,
                out ProfileService profileService,
                out ProfileHost profileHost,
                out ActivationHost activationDevice,
                out ConnectionService connectionDevice) {

        // Create the service profile
        profileService = ProfileService.Generate(meshMachine.KeyCollection);

        // Create a host profile and add create a connection to the host.
        profileHost = ProfileHost.CreateHost(meshMachine);
        activationDevice = new ActivationHost(profileHost, profileService.UdfString);
        activationDevice.Envelope(encryptionKey: profileHost.KeyEncrypt);
        // Persist the profile keys
        profileService.PersistSeed(meshMachine.KeyCollection);
        profileHost.PersistSeed(meshMachine.KeyCollection);

        // Need to envelope the activation device under device key.

        activationDevice.Activate(profileHost.SecretSeed);
        var connectionDevice1 = activationDevice.Connection;
        connectionDevice = new ConnectionService() {
            ProfileUdf = profileHost.UdfString,
            Subject = connectionDevice1.Authentication.CryptoKey.KeyIdentifier,
            Authority = profileService.UdfString,

            Authentication = connectionDevice1.Authentication
            };

        // Strip and sign the device connection.
        connectionDevice.Strip();
        profileService.Sign(connectionDevice, ObjectEncoding.JSON_B);


        }


    /// <summary>
    /// Constructor create service with the signature key <paramref name="keySign"/>
    /// </summary>
    /// <param name="keySign">The offline signature key.</param>
    /// <param name="keyEncrypt">The service encryption key.</param>
    public ProfileService(KeyPair keySign, KeyPair keyEncrypt) {
        KeySignature = keySign;
        KeyEncryption = keyEncrypt;

        ProfileSignature = new KeyData(keySign.KeyPairPublic());
        ServiceEncryption = new KeyData(keyEncrypt.KeyPairPublic());
        }


    /// <summary>
    /// Sign a host connection.
    /// </summary>
    /// <param name="connection">The connection to sign.</param>
    /// <param name="objectEncoding">The encoding for the connection object.</param>
    public void Sign(Connection connection, ObjectEncoding objectEncoding) =>
        connection.Envelope(KeySignature, objectEncoding:
                    objectEncoding);
    #endregion
    }
