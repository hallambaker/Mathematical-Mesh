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


using System.Collections.Generic;
using System.Numerics;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public partial class KeyShare {
        ///<inheritdoc/>
        public override KeyPair GetKeyPair(
                    KeySecurity keySecurity,
                    IKeyLocate keyCollection = null) {
            var share = Share.GetKeyPair(keySecurity, keyCollection) as KeyPairAdvanced;
            var primary = PublicPrimary.GetKeyPair(keySecurity, keyCollection);

            //Screen.WriteLine($"   Device Key = {share.IKeyAdvancedPrivate.Private}");

            return new KeyPairServiced(primary, share, ServiceAddress, keyCollection);
            //current: here
            }

        }


    /// <summary>
    ///  A serviced KeyPair
    /// </summary>
    public class KeyPairServiced : KeyPair {

        #region // Properties
        ///<inheritdoc/>
        public override KeyUses KeyUses => Share.KeyUses;

        ///<inheritdoc/>
        public override int LengthSignature => Share.LengthSignature;

        ///<inheritdoc/>
        public override SubjectPublicKeyInfo KeyInfoData => Primary.KeyInfoData;

        /////<inheritdoc/>
        //public override SubjectPublicKeyInfo PrivateKeyInfoData => Share.PrivateKeyInfoData;

        ///<inheritdoc/>
        public override IPKIXPrivateKey PKIXPrivateKey => Share.PKIXPrivateKey;

        ///<inheritdoc/>
        public override IPkixPublicKey PkixPublicKey => Primary.PkixPublicKey;

        ///<inheritdoc/>
        public override bool PublicOnly => Share.PublicOnly;

        ///<summary>The key share</summary> 
        public KeyPair Share { get; }

        ///<summary>The key share</summary> 
        public KeyPair Primary { get; }


        ///<summary>The service address</summary> 
        public string ServiceAddress { get; }

        IKeyLocate KeyCollection { get; }
        #endregion
        #region // Constructors

        /// <summary>
        /// Constructor returning a serviced key pair with public parameters <paramref name="primary"/>
        /// and share <paramref name="share"/>.
        /// </summary>
        /// <param name="primary">The public parameters of the shared key.</param>
        /// <param name="share">The threshold share.</param>
        /// <param name="serviceAddress">The service account to which requests should be directed.</param>
        /// <param name="keyCollection">The key collection to be used to obtain the client.</param>
        public KeyPairServiced(
                KeyPair primary, 
                KeyPairAdvanced share,
                string serviceAddress,
                IKeyLocate keyCollection) {
            Primary = primary;
            Share = share;
            ServiceAddress = serviceAddress;
            KeyCollection = keyCollection;

            //(KeyCollection as IMeshClient).AssertNotNull(NYI.Throw);
            }

        #endregion
        #region // Public key methods (pass through to Primary).
        
        ///<inheritdoc/>
        public override void Encrypt(
            byte[] key, 
            out byte[] exchange, 
            out KeyPair ephemeral, 
            byte[] salt = null) => Share.Encrypt (key, out exchange, out ephemeral, salt);
        
        ///<inheritdoc/>
        public override KeyPair KeyPairPublic() => Share.KeyPairPublic();
        
        ///<inheritdoc/>
        public override bool VerifyHash(
            byte[] digest, 
            byte[] signature, 
            CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, 
            byte[] context = null) => Share.VerifyHash (digest, signature, algorithmID, context);


        #endregion
        #region // Private key methods (require service interaction

        ///<inheritdoc/>
        public override byte[] Decrypt(
                byte[] encryptedKey,
                KeyPair ephemeral = null,
                CryptoAlgorithmId algorithmID =
                CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null,
                byte[] salt = null) {

            //Screen.WriteLine($"Remote Decrypt {ServiceAddress} Public {Primary.KeyIdentifier} Share {Share.KeyIdentifier}");

            //current
            var partial1 = KeyCollection.RemoteAgreement(ServiceAddress, 
                ephemeral as KeyPairAdvanced, Share.KeyIdentifier);


            return Share.Decrypt(encryptedKey, ephemeral, algorithmID, partial1, salt);


            //var partial2 = Share.Agreement(ephemeral);

            //return partial2.Decrypt(encryptedKey, ephemeral, partial2, salt);
            }


        //KeyAgreementResult RemoteAgreement(
        //        string accountAddress,
        //        string keyId,
        //        KeyPair ephemeral,
        //        BigInteger? lagrange = null) {

        //    lagrange.Future();

        //    // current: this is where decryption capabilities are used
        //    var operation = new CryptographicOperationKeyAgreement() {
        //        KeyId = keyId,
        //        PublicKey = Key.GetPublic(ephemeral)
        //        };

        //    var operateRequest = new OperateRequest() {
        //        AccountAddress = accountAddress,
        //        Operations = new List<CryptographicOperation>() {
        //            operation
        //            }
        //        };


        //    var client = KeyCollection.MeshClient;
        //    var response = client.Operate(operateRequest);

        //    var result = response.Results[0] as CryptographicResultKeyAgreement;

        //    return result.KeyAgreement.KeyAgreementResult;
        //    }



        ///<inheritdoc/>
        public override KeyAgreementResult Agreement(KeyPair keyPair) => Share.Agreement(keyPair);


        ///<inheritdoc/>
        public override void Persist(KeyCollection keyCollection) => throw new System.NotImplementedException();
        
        ///<inheritdoc/>
        public override byte[] SignHash(
            byte[] data, 
            CryptoAlgorithmId algorithmID = 
            CryptoAlgorithmId.Default, 
            byte[] context = null) => 
                throw new System.NotImplementedException();


        #endregion



        }


    }
