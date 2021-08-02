using System;

using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Stub key collection used to prevent keys being written to persistent storage.
    /// </summary>
    public class KeyCollectionEphemeral : KeyCollection, IKeyCollection {

        /// <summary>
        /// Attempt to erase the private key with fingerprint <paramref name="udf"/> from the
        /// associated persistence store.
        /// </summary>
        /// <param name="udf"></param>
        /// <returns>True if the key was found, otherwise false.</returns>
        public void ErasePrivateKey(string udf) => throw new NotImplementedException();

        /// <summary>
        /// Locate the private key with fingerprint <paramref name="udf"/> and return
        /// the corresponding JSON description.
        /// </summary>
        /// <param name="udf">Key to locate</param>
        /// <returns>Exception <see cref="PrivateKeyNotFound"/> since there is no 
        /// backing store.</returns>
        public override IJson LocatePrivateKey(string udf) => throw new PrivateKeyNotFound();

        /// <summary>
        /// Persist the key pair specified by <paramref name="privateKey"/> and mark as exportable
        /// or non-exportable according to the value of <paramref name="Exportable"/>.
        /// </summary>
        /// <param name="udf">The UDF of the key</param>
        /// <param name="privateKey">The private key parameters.</param>
        /// <param name="Exportable">If true, the key is exportable.</param>
        public override void Persist(string udf, IPKIXPrivateKey privateKey, bool Exportable) =>
                throw new NotImplementedException();

        /// <summary>
        /// Persist the key pair specified by <paramref name="joseKey"/> and mark as exportable
        /// or non-exportable according to the value of <paramref name="exportable"/>.
        /// </summary>
        /// <param name="udf">The UDF of the key</param>
        /// <param name="joseKey">The private key parameters.</param>
        /// <param name="exportable">If true, the key is exportable.</param>
        public override void Persist(string udf, IJson joseKey, bool exportable) =>
            throw new NotImplementedException();

        /// <summary>
        /// Attempt to form a trust path for the key used to sign <paramref name="dareSignature"/>.
        /// </summary>
        /// <param name="dareSignature">The signature to validate.</param>
        /// <param name="anchor">If present specifies the fingerprint of a key that MUST anchor
        /// the trust path.</param>
        /// <returns>The result of the trust path analysis.</returns>
        public TrustResult ValidateTrustPath(DareSignature dareSignature, string anchor = null) =>
                throw new NotImplementedException();
        }
    }
