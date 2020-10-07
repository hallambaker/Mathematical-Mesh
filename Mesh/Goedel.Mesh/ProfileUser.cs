//  Copyright © 2020 Threshold Secrets llc
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

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    public partial class ProfileAccount {

        ///<summary>The actor type</summary> 
        public override MeshActor MeshActor => MeshActor.Account;

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ProfileAccount> EnvelopedProfileAccount =>
            envelopedProfileAccount ?? new Enveloped<ProfileAccount>(DareEnvelope).
                    CacheValue(out envelopedProfileAccount);
        Enveloped<ProfileAccount> envelopedProfileAccount;

        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileAccount() {
            }

        /// <summary>
        /// Construct a Profile Host instance  from a <see cref="PrivateKeyUDF"/>
        /// </summary>
        /// <param name="secretSeed">The secret seed value.</param>
        public ProfileAccount(
                    PrivateKeyUDF secretSeed) : base(secretSeed) {
            }


        }


    public partial class ProfileUser {





        /// <summary>
        /// Blank constructor for use by deserializers.
        /// </summary>
        public ProfileUser() {
            }

        /// <summary>
        /// Construct a new ProfileDevice instance from a <see cref="PrivateKeyUDF"/>
        /// seed.
        /// </summary>
        /// <param name="activationAccount">An activation account with full administrative privileges.</param>
        /// <param name="accountAddress">The account address</param>
        public ProfileUser(
                    ActivationAccount activationAccount,
                    string accountAddress) {
            AccountAddress = accountAddress;

            //Set the public key parameters
            ProfileSignature = new KeyData(activationAccount.ProfileSignatureKey);
            AccountEncryption = new KeyData(activationAccount.AccountEncryptionKey);
            AccountAuthentication = new KeyData(activationAccount.AccountAuthenticationKey);
            AccountSignature = new KeyData(activationAccount.AccountSignatureKey);

            // Sign the profile
            Envelope(activationAccount.ProfileSignatureKey);
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
