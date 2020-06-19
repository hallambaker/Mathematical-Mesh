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

        ///<summary>The enclosing mesh context.</summary>
        public abstract ContextMesh ContextMesh { get; }

        ///<summary>The enclosing mesh context as an administrative context (if rights granted.</summary>
        protected ContextMeshAdmin ContextMeshAdmin => ContextMesh as ContextMeshAdmin;

        ///<summary>The Machine context.</summary>
        protected IMeshMachineClient MeshMachine => ContextMesh.MeshMachine;

        ///<summary>The key collection for use with the context.</summary>
        protected KeyCollection KeyCollection => ContextMesh.KeyCollection;




        ///<summary>The member's device signature key</summary>
        protected KeyPair KeySignature { get; set; }

        ///<summary>The group encryption key </summary>
        protected KeyPair KeyEncryption { get; set; }

        ///<summary>The directory containing the catalogs related to the account.</summary>
        public virtual string StoresDirectory { get; set; }

        ///<summary>Dictionary locating the stores connected to the context.</summary>
        protected Dictionary<string, SyncStatus> DictionaryStores = new Dictionary<string, SyncStatus>();

        ///<summary>The cryptographic parameters for reading/writing to account containers</summary>
        protected CryptoParameters ContainerCryptoParameters;


        ///<summary>Returns the network catalog for the account</summary>
        public CatalogCapability GetCatalogCapability() => GetStore(CatalogCapability.Label) as CatalogCapability;


        #region // Store management

        /// <summary>
        /// Return a <see cref="ConstraintsSelect"/> instance that requests synchronization to the
        /// remote store whose status is described by <paramref name="statusRemote"/>.
        /// </summary>
        /// <param name="statusRemote">Status of the remote store.</param>
        /// <returns>The selection constraints.</returns>
        public ConstraintsSelect GetStoreStatus(ContainerStatus statusRemote) {
            if (DictionaryStores.TryGetValue(statusRemote.Container, out var syncStore)) {
                var storeLocal = syncStore.Store;

                return storeLocal.FrameCount >= statusRemote.Index ? null :
                    new ConstraintsSelect() {
                        Container = statusRemote.Container,
                        IndexMax = statusRemote.Index,
                        IndexMin = (int)storeLocal.FrameCount
                        };
                }

            else {
                using var storeLocal = new Store(StoresDirectory, statusRemote.Container,
                            decrypt: false, create: false);
                //Console.WriteLine($"Container {statusRemote.Container}   Local {storeLocal.FrameCount} Remote {statusRemote.Index}");
                return storeLocal.FrameCount >= statusRemote.Index ? null :
                    new ConstraintsSelect() {
                        Container = statusRemote.Container,
                        IndexMax = statusRemote.Index,
                        IndexMin = (int)storeLocal.FrameCount
                        };
                }
            }

        /// <summary>
        /// Update the store according to the values <paramref name="containerUpdate"/>.
        /// </summary>
        /// <param name="containerUpdate">The update to apply.</param>
        /// <returns>The number of envelopes successfully added.</returns>
        public int UpdateStore(ContainerUpdate containerUpdate) {
            int count = 0;
            if (DictionaryStores.TryGetValue(containerUpdate.Container, out var syncStore)) {
                var store = syncStore.Store;
                foreach (var entry in containerUpdate.Envelopes) {
                    if (entry.Index == 0) {
                        throw new NYI();
                        }

                    count++;
                    store.AppendDirect(entry);
                    }
                return count;
                }

            else {
                // we have zero envelopes being returned in this update.

                Store.Append(StoresDirectory, containerUpdate.Envelopes, containerUpdate.Container);
                return containerUpdate.Envelopes.Count;
                }

            }

        /// <summary>
        /// Return a <see cref="Store"/> instance for the store named <paramref name="name"/>. If the
        /// parameter <paramref name="blind"/> is true, only the sequence header values are read.
        /// </summary>
        /// <param name="name">The store to open.</param>
        /// <param name="blind">If true, only the sequence header values are read</param>
        /// <returns>The <see cref="Store"/> instance.</returns>
        public Store GetStore(string name, bool blind = false) {
            if (DictionaryStores.TryGetValue(name, out var syncStore)) {
                if (!blind & (syncStore.Store is CatalogBlind)) {
                    // if we have a blind store from a sync operation but need a populated one,
                    // remake it.
                    syncStore.Store.Dispose();
                    syncStore.Store = MakeStore(name);
                    }
                return syncStore.Store;
                }

            //Console.WriteLine($"Open store {name} on {MeshMachine.DirectoryMesh}");

            var store = blind ? new CatalogBlind(StoresDirectory, name) : MakeStore(name);
            syncStore = new SyncStatus(store);

            DictionaryStores.Add(name, syncStore);
            return syncStore.Store;
            }

        /// <summary>
        /// Create a new instance bound to the specified core within this account context.
        /// </summary>
        /// <param name="name">The name of the store to bind.</param>
        /// <returns>The store instance.</returns>
        protected virtual Store MakeStore(string name) => name switch
            {
                CatalogCapability.Label => new CatalogCapability(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                _ => throw new NYI(),
                };
        #endregion



        #region Implement IKeyLocate


        /// <summary>
        /// Resolve a public encryption key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public CryptoKey GetByAccountEncrypt(string keyID) => throw new NotImplementedException();

        /// <summary>
        /// Resolve a public signature key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public CryptoKey GetByAccountSign(string keyID) => throw new NotImplementedException();

        /// <summary>
        /// Attempt to obtain a private key with identifier <paramref name="keyID"/>.
        /// </summary>
        /// <param name="keyID">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public CryptoKey LocatePrivateKeyPair(string keyID) => throw new NotImplementedException();

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


            true.AssertFalse(); // This method has serious issues.

            KeyPair signingKey = sign ? KeySignature : null;
            List<CryptoKey> encryptionKeys = null;

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
