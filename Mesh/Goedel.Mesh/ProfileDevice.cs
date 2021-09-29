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



using System.Text;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
namespace Goedel.Mesh {


    public partial class ProfileDevice {
        #region // Properties
        ///<summary>The base device encryption key</summary> 
        public KeyPair KeyEncrypt { get; private set; }
        ///<summary>The base device signature key</summary> 
        public KeyPair KeySignature { get; private set; }
        ///<summary>The base device authentication key</summary> 
        public KeyPair KeyAuthentication { get; private set; }

        ///<summary>The actor type</summary> 
        public override MeshActor MeshActor => MeshActor.Device;


        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileDevice> GetEnvelopedProfileDevice() => new(DareEnvelope);

        #endregion
        #region // Constructors

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileDevice() {
            }

        /// <summary>
        /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        public ProfileDevice(
                    PrivateKeyUDF secretSeed) : base(secretSeed) {
            }

        #endregion
        #region // Methods 



        /// <summary>
        /// Generate profile specific keys.
        /// </summary>
        protected override void Generate() {
            base.Generate();
            (KeyEncrypt, Encryption) = SecretSeed.GenerateContributionKey(
                    MeshKeyType, MeshActor, MeshKeyOperation.Encrypt);
            (KeySignature, Signature) = SecretSeed.GenerateContributionKey(
                    MeshKeyType, MeshActor, MeshKeyOperation.Sign);
            (KeyAuthentication, Authentication) = SecretSeed.GenerateContributionKey(
                    MeshKeyType, MeshActor, MeshKeyOperation.Authenticate);
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
        /// <returns>The created profile.</returns>
        public static ProfileDevice Generate(
                    CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                    int bits = 256,
                    PrivateKeyUDF secretSeed = null) {
            secretSeed ??= new PrivateKeyUDF(
                udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileDevice, secret: null, algorithmEncrypt: algorithmEncrypt,
                algorithmSign: algorithmSign, algorithmAuthenticate: algorithmAuthenticate, bits: bits);
            return new ProfileDevice(secretSeed);
            }




        /// <summary>
        /// Verify the profile to check that it is correctly signed and consistent.
        /// </summary>
        /// <returns></returns>
        public override void Validate() {
            base.Validate();
            Signature.GetKeyPair().PublicOnly.AssertTrue(InvalidProfile.Throw);
            Encryption.GetKeyPair().PublicOnly.AssertTrue(InvalidProfile.Throw);
            Authentication.GetKeyPair().PublicOnly.AssertTrue(InvalidProfile.Throw);
            }



        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="RespondConnection"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        /// <remarks>This is one of the few convenience decoders that cannot be replaced because
        /// ProfileDevice is frequently passed as a Publication.</remarks>
        public static new ProfileDevice Decode(DareEnvelope envelope,
                    IKeyCollection keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as ProfileDevice;


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Profile Device");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"ProfileSignature: {ProfileSignature.Udf} ");

            builder.AppendIndent(indent, $"KeySignature:        {Signature.Udf} ");
            builder.AppendIndent(indent, $"KeyEncryption:       {Encryption.Udf} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {Authentication.Udf} ");

            }


        #endregion
        }

    }
