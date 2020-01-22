using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {
    public abstract class ContextAccountEntry : Disposable, IKeyLocate, IDare  {

        ///<summary>The member's device signature key</summary>
        protected KeyPair keySignature { get; set; }

        ///<summary>The group encryption key </summary>
        protected KeyPair keyEncryption { get; set; }

        #region Implement IKeyLocate
        public KeyPair GetByAccountEncrypt(string keyID) => throw new NotImplementedException();
        public KeyPair GetByAccountSign(string keyID) => throw new NotImplementedException();
        public KeyPair LocatePrivateKeyPair(string UDF) => throw new NotImplementedException();
        public KeyPair TryMatchRecipient(string keyID) => throw new NotImplementedException();
        #endregion



        #region Implement IDare

        // Bug: this is going to fail because information from the contact catalog is not available.


        /// <summary>
        /// Create a new DARE Message from the specified parameters.
        /// </summary>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="signingKey">The signature key.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        /// <returns></returns>
        public DareEnvelope DareEncode(
                    byte[] plaintext,
                    ContentMeta contentMeta = null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null,
                    List<string> recipients = null,
                    bool sign = false) {

            KeyPair signingKey = sign ? keySignature : null;
            List<KeyPair> encryptionKeys = null;

            if (recipients != null) {
                foreach (var recipient in recipients) {
                    encryptionKeys.Add(GetByAccountEncrypt(recipient));
                    }
                }


            var cryptoParameters = new CryptoParameters(signer: signingKey, recipients: null);
            return new DareEnvelope(cryptoParameters, plaintext, contentMeta, cloaked, dataSequences);

            }

        /// <summary>
        /// Decode a DARE envelope
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <returns>The plaintext payload data.</returns>
        public byte[] DareDecode(
                    DareEnvelope envelope,
                    bool verify = false) => envelope.GetPlaintext(this);

        #endregion

        }
    }
