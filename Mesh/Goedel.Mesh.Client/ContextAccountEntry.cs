using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Base class from which Contexts for Accounts and Groups are derrived. These are
    /// separate contexts but share functions and thus code.
    /// </summary>
    public abstract class ContextAccountEntry : Disposable, IKeyLocate {

        ///<summary>The member's device signature key</summary>
        protected KeyPair keySignature { get; set; }

        ///<summary>The group encryption key </summary>
        protected KeyPair keyEncryption { get; set; }

        #region Implement IKeyLocate


        /// <summary>
        /// Resolve a public encryption key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public KeyPair GetByAccountEncrypt(string keyID) => throw new NotImplementedException();

        /// <summary>
        /// Resolve a public signature key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public KeyPair GetByAccountSign(string keyID) => throw new NotImplementedException();

        /// <summary>
        /// Attempt to obtain a private key with identifier <paramref name="keyID"/>.
        /// </summary>
        /// <param name="keyID">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public KeyPair LocatePrivateKeyPair(string keyID) => throw new NotImplementedException();

        /// <summary>
        /// Attempt to obtain a recipient with identifier <paramref name="keyID"/>.
        /// </summary>
        /// <param name="keyID">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public CryptoKey TryMatchRecipient(string keyID) => throw new NotImplementedException();
        #endregion



        #region Implement IDare

        // Bug: this is going to fail because information from the contact catalog is not available.


        /// <summary>
        /// Create a new DARE Envelope from the specified parameters.
        /// </summary>
        /// <param name="plaintext">The payload plaintext. If specified, the plaintext will be used to
        /// create the message body. Otherwise the body is specified by calls to the Process method.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        /// as an EDSS header entry.</param>
        /// <param name="recipients">If specified, encrypt the envelope with decryption blobs
        /// for the specified recipients.</param>
        /// <param name="sign">If true sign the envelope.</param>
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
        /// <param name="verify">It true, verify the signature first.</param>
        /// <returns>The plaintext payload data.</returns>
        public byte[] DareDecode(
                    DareEnvelope envelope,
                    bool verify = false) => envelope.GetPlaintext(this);

        #endregion

        }
    }
