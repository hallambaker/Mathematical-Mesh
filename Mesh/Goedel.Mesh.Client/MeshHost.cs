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

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {

    // This is the operation point to address merging the mesh and account profiles.


    /// <summary>
    /// Manages the host catalog, i.e. the catalog of Meshes that the device is 
    /// connected to.
    /// 
    /// 
    /// This should be merged with CatalogHost.
    /// 
    /// </summary>
    public class MeshHost : Disposable {

        #region // fields and properties

        ///<summary>The Mesh machine client.</summary>
        public IMeshMachineClient MeshMachine;

        ///<summary>The host persistence container.</summary> 
        public PersistHost ContainerHost { get; }

        ///<summary>The Key Collection of the Mesh Machine.</summary>
        public IKeyCollection KeyCollection => MeshMachine.KeyCollection;

        //keyCollection ??
        //        new KeyCollectionClient(this, MeshMachine.KeyCollection).CacheValue(out keyCollection);
        //KeyCollection keyCollection;


        #endregion
        #region // Boilerplate for disposal etc.
        ///<summary>Disposal routine.</summary>
        protected override void Disposing() => ContainerHost.Dispose();
        #endregion
        #region // Constructors and factories

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine">The Mesh Machine.</param>
        /// <param name="containerHost">The host catalog.</param>
        public MeshHost(PersistHost containerHost, IMeshMachineClient meshMachine) {
            this.MeshMachine = meshMachine;
            ContainerHost = containerHost;

            foreach (var entry in containerHost.ObjectIndex) {
                var catalogedMachine = entry.Value.JsonObject as CatalogedMachine;
                Register(catalogedMachine);
                //Console.WriteLine($"Container  {entry.Key}  of {entry.Value.GetType()}");
                }

            }

        ContextAccount Register(CatalogedMachine catalogedMachine) {
            switch (catalogedMachine) {
                // consider adding a machine catalog entry for a group...
                case CatalogedStandard standardEntry: {
                    var context = new ContextUser(this, standardEntry);
                    Register(context);
                    return context;
                    }
                case CatalogedPending pendingEntry: {
                    var context = new ContextMeshPending(this, pendingEntry);
                    Register(context);
                    return context;
                    }
                default:
                return null;
                }
            }

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public static MeshHost GetCatalogHost(IMeshMachine meshMachine) {
            var meshMachineClient = meshMachine as IMeshMachineClient;
            return meshMachineClient.MeshHost;

            }

        #endregion
        #region // Methods



        ///<summary>Dictionary mapping mesh UDF to Context.</summary>
        protected Dictionary<string, ContextAccount> DictionaryUDFContextMesh = new();

        ///<summary>Dictionary mapping mesh local name to Context.</summary>
        protected Dictionary<string, ContextAccount> DictionaryLocalContextMesh = new();

        void Register(ContextAccount contextMesh) {
            var machine = contextMesh.CatalogedMachine;
            DictionaryUDFContextMesh.Remove(machine.Id);
            DictionaryUDFContextMesh.Add(machine.Id, contextMesh);

            if (contextMesh.AccountAddress != null) {
                DictionaryLocalContextMesh.AddSafe(contextMesh.AccountAddress, contextMesh);
                }
            if (contextMesh.Profile != null) {
                DictionaryUDFContextMesh.AddSafe(contextMesh.Profile.Udf, contextMesh);
                }

            if (machine.Local != null) {
                DictionaryLocalContextMesh.AddSafe(machine.Local, contextMesh);
                }
            }

        /// <summary>
        /// Unregister the mesh <paramref name="contextMesh"/>.
        /// </summary>
        /// <param name="contextMesh">The mesh to be deleted.</param>
        public void Deregister(ContextAccount contextMesh) {
            var machine = contextMesh.CatalogedMachine;
            DictionaryUDFContextMesh.Remove(machine.Id);

            if (contextMesh.AccountAddress != null) {
                DictionaryLocalContextMesh.Remove(contextMesh.AccountAddress);
                }
            if (contextMesh.Profile != null) {
                DictionaryUDFContextMesh.Remove(contextMesh.Profile.Udf);
                }

            if (machine.Local != null) {
                DictionaryLocalContextMesh.Remove(machine.Local);
                }
            }


        /// <summary>
        /// Locate context by UDF or localname. The context acquired is owned by the MeshHost instance
        /// and MUST NOT be disposed of by the caller.
        /// </summary>
        /// <param name="key">The UDF or name to resolve.</param>
        /// <param name="useLocal">If true, match against UDF or local name. Otherwise
        /// match on UDF alone.</param>
        /// <returns>The context, if a matching context is found. Otherwise null.</returns>
        public ContextAccount LocateMesh(string key, bool useLocal = true) {
            key.AssertNotNull(MeshNotFound.Throw);


            if (DictionaryUDFContextMesh.TryGetValue(key, out var context)) {
                return context;
                }

            if (useLocal && DictionaryLocalContextMesh.TryGetValue(key, out context)) {
                return context;
                }

            return null;
            }


        /// <summary>
        /// Register <paramref name="catalogItem"/> in the host catalog.
        /// </summary>
        /// <param name="catalogItem">The item to be created.</param>
        /// <param name="create">If true, a new item will be created if it does not
        /// already exist.</param>
        /// <param name="context">The dynamic context that interfaces to the catalog item.</param>
        public void Register(HostCatalogItem catalogItem, ContextAccount context, bool create = true) {

            // persist the permanent record.
            ContainerHost.Update(catalogItem, create);
            if (context != null) {
                Register(context);
                }
            //if (machine.JsonObject is CatalogedMachine catalogedMachine) {
            //    Register(catalogedMachine);
            //    }

            //// register the dynamic context


            }


        /// <summary>
        /// Delete <paramref name="key"/> from the host catalog.
        /// </summary>
        /// <param name="key">The profile to delete</param>
        public virtual void Delete(string key) =>
                ContainerHost.Delete(key);
        #endregion





        /// <summary>
        /// Create a new Mesh master profile and bind to a Mesh service at <paramref name="accountAddress"/>.
        /// </summary>
        ///<param name="accountAddress">Account address to bind to.</param>
        /// <param name="localName">Local name for easy reference.</param>
        /// <param name="accountSeed">Specifies the secret seed and algorithms used to generate private keys.</param>
        /// <param name="profileDevice">Specify the device profile. This allows use of a device 
        /// profile bound to the machine hardware.</param>
        /// <param name="rights">The rights to be granted to the initial connected device.</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextUser CreateMesh(
                string accountAddress,
                string localName = null,
                PrivateKeyUDF accountSeed = null,
                ProfileDevice profileDevice = null,
                List<string> rights = null) {

            // Generate the initial seed for the account if not already specified.
            accountSeed ??= new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);
            //Screen.WriteLine($"***** Secret Seed = {accountSeed.PrivateValue}");

            // Generate a device profile if needed
            var persistDevice = profileDevice == null;
            profileDevice ??= ProfileDevice.Generate(
                algorithmSign: accountSeed.AlgorithmSignID,
                algorithmEncrypt: accountSeed.AlgorithmEncryptID,
                algorithmAuthenticate: accountSeed.AlgorithmAuthenticateID);

            // Check that the profile is valid before using it.
            profileDevice.Validate();

            // Create the set of cryptographic keys to initialize the account.
            // create the root activation.
            var activationRoot = new ActivationAccount(KeyCollection, accountSeed) {
                DefaultActive = true
                
                };
            //activationRoot.Envelope();


            //activationRoot.DareEnvelope = new DareEnvelope() {
            //    JsonObject = activationRoot
            //    };
            // create the initial profile
            var profileUser = new ProfileUser(accountAddress, activationRoot);

            Screen.WriteLine(profileUser.ToString());

            // Check that the profile is valid before using it.
            profileUser.Validate();
            //profileUser.Activate(KeyCollection);
            // Create the account directory.
            ContextUser.CreateDirectory(this, profileUser, activationRoot, KeyCollection);


            rights ??= new List<string> {
                Rights.IdRolesSuper,
                Rights.IdRolesAdmin,
                Rights.IdRolesWeb
                };


            var activationDevice = new ActivationDevice(profileDevice);

            //var activationAccount = MakeActivationAccount(profileDevice, activationDevice, roles, transactContextAccount);
            //activationDevice.Envelope();

            // create a Cataloged activationRoot.Device entry for the admin device
            var catalogedDevice = activationRoot.CreateCataloguedDevice(
                    profileUser, profileDevice, activationDevice, activationRoot,
                    activationRoot.AdministratorSignatureKey);



            //new CatalogedDevice() {
            //    EnvelopedProfileUser = profileUser.EnvelopedProfileAccount,
            //    EnvelopedProfileDevice = profileDevice.EnvelopedProfileDevice,
            //    EnvelopedActivationDevice = activationDevice.EnvelopedActivationDevice,
            //    EnvelopedActivationAccount = activationRoot.EnvelopedActivationAccount
            //    };

            // Create the host catalog entry and apply to the context user.
            var catalogedMachine = new CatalogedStandard() {
                Id = profileDevice.Udf,
                Local = localName,
                CatalogedDevice = catalogedDevice,
                EnvelopedProfileAccount = profileUser.EnvelopedProfileAccount
                };



            //Persist the results.
            if (persistDevice) {
                profileDevice.PersistSeed(KeyCollection);
                }
            KeyCollection.Persist(profileUser.Udf, accountSeed, false);

            var contextUser = new ContextUser(this, catalogedMachine) {
                ActivationAccount = activationRoot
                };
            //contextUser.ActivationAccount.ProfileSignatureKey =
            //    activationRoot.ProfileSignatureKey;

            // Set the service 
            contextUser.SetService(accountAddress);

            // Add the catalog device under the new user context.
            var transactRequest = contextUser.TransactBegin();


            catalogedMachine.CatalogedDevice = activationRoot.MakeCatalogedDevice(
                profileDevice, profileUser, rights, transactRequest, activationDevice);


            var catalogDevice = transactRequest.GetCatalogDevice();
            transactRequest.CatalogUpdate(catalogDevice, catalogedMachine.CatalogedDevice);
            transactRequest.Transact();

            // Register the mesh description on the local machine.
            Register(catalogedMachine, contextUser);

            return contextUser;
            }


        /// <summary>
        /// Create a new management context for the specified Mesh profile.
        /// </summary>
        /// <param name="localName">The friendly name for the profile</param>
        /// <param name="admin">Enable administration privileges (if available).</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextAccount GetContextMesh(string localName = null, bool admin = true) {

            admin.Future();

            var key = localName ?? ContainerHost?.DefaultEntry?.Id;
            return key == null ? null : LocateMesh(key);
            }

        /// <summary>
        /// Attempt to complete the connection to a Mesh profile. If successful. update the local host persistence store
        /// and return a context for the newly acquired connection. Otherwise return null.
        /// </summary>
        /// <param name="localName"></param>
        /// <returns>Context for the newly bound account.</returns>
        public ContextUser Complete(
                string localName = null) {

            var machine = ContainerHost.GetForCompletion(localName);

            switch (machine) {
                case CatalogedPending catalogedPending: {
                    var contextPending = LocateMesh(catalogedPending.Id) as ContextMeshPending;
                    return contextPending.Complete();
                    }
                case CatalogedPreconfigured catalogedPreconfigured: {
                    var contextPreconfigured = new ContextMeshPreconfigured(this, catalogedPreconfigured);
                    return contextPreconfigured.Complete();
                    }
                }
            return null;
            }




        /// <summary>
        /// Begin connection to a service.
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextMeshPending Connect(
                string accountAddress,
                string localName = null,
                string pin = null,
                List<string> rights = null) => ContextMeshPending.ConnectService(this, accountAddress, localName, pin,
                    rights: rights);

        /// <summary>
        /// Begin connection to a service.
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextMeshPending Join(
                string uriAddress,
                string localName = null,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

            algorithmSign.Future();
            algorithmEncrypt.Future();
            algorithmAuthenticate.Future();

            (var accountAddress, var pin) = MeshUri.ParseConnectUri(uriAddress);

            // connect to alice@example.com using pin NACE-ZMVM-L6FV-NCHE-LY
            return ContextMeshPending.ConnectService(this, accountAddress, localName, pin);

            }

        /// <summary>
        /// Install a pre-configured device profile. This is typically performed during 
        /// manufacture.
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextMeshPreconfigured Install(
                string filename,
                string localName = null,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

            filename.Future();
            algorithmSign.Future();
            algorithmEncrypt.Future();
            algorithmAuthenticate.Future();

            // read the device file
            var devicePreconfiguration = DevicePreconfiguration.FromFile(filename);

            // create a ContextMeshPending for it.
            var context = ContextMeshPreconfigured.Install(this, devicePreconfiguration);
            return context;

            }


        /// <summary>
        /// Create a new Mesh master profile and account without binding to a service
        /// </summary>
        /// <returns>Context for administering the Mesh account</returns>
        public ContextUser CreateMeshWithAccount(
                string localName,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

            algorithmSign.Future();
            algorithmEncrypt.Future();
            algorithmAuthenticate.Future();


            var contextMeshAdmin = CreateMesh(localName);

            throw new NYI();
            //return contextMeshAdmin.CreateAccount(localName);

            }

        }
    }
