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
using Goedel.Utilities;

namespace Goedel.Mesh {


    public partial class ProfileUser {
        ///<summary>The account signature key</summary> 
        public KeyPair AccountSignatureKey => accountSignatureKey ??
            ProfileSignature.GetKeyPair().CacheValue(out accountSignatureKey);
        KeyPair accountSignatureKey;


        ///<summary>The account escrow key</summary> 
        public KeyPair EscrowEncryptionKey => escrowEncryptionKey ??
            EscrowEncryption.GetKeyPair().CacheValue(out escrowEncryptionKey);
        KeyPair escrowEncryptionKey;

        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileUser() {
            }

        /// <summary>
        /// Construct a Profile Account instance  from <paramref name="accountAddress"/>.
        /// </summary>
        /// <param name="accountAddress">The account address</param>
        /// <param name="activationAccount">The activation used to create the account data.</param>        
        public ProfileUser(string accountAddress,
                    ActivationAccount activationAccount) : base(accountAddress, activationAccount) {


            AccountSignature = new KeyData(activationAccount.AccountSignatureKey);
            // Sign the profile
            Envelope(activationAccount.ProfileSignatureKey);
            }

        /// <summary>
        /// Verify the profile to check that it is correctly signed and consistent.
        /// </summary>
        /// <returns></returns>
        public override void Validate() {
            base.Validate();

            AccountAuthenticationKey.PublicOnly.AssertTrue(InvalidProfile.Throw);
            AccountSignatureKey.PublicOnly.AssertTrue(InvalidProfile.Throw);

            }


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units.The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Profile User");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            builder.AppendIndent(indent, $"KeyOfflineSignature: {ProfileSignature.Udf} ");
            builder.AppendIndent(indent, $"AccountAddress : {AccountAddress} ");
            builder.AppendIndent(indent, $"KeyEncryption:       {AccountEncryption.Udf} ");

            }
        }
    }
