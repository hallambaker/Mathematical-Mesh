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

using System.IO;

using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Mesh.Client;
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

namespace Goedel.Mesh;

/// <summary>
/// The  Mesh server.
/// </summary>
public class MeshMachineCoreServer : Disposable, IMeshMachine {

    #region // Properties

    ///<summary>The directory used to store the master data.</summary>
    public virtual string DirectoryMaster { get; }

    ///<summary>The directory used to store the account mesh data.</summary>
    public virtual string DirectoryMesh { get; }

    ///<summary>The directory used to store host keys.</summary>
    public virtual string DirectoryKeys { get; }

    ///<summary>The host key collection.</summary>
    public virtual IKeyCollection KeyCollection { get; }

    ///<summary>The IANA media type for the host file data.</summary>
    public const string FileTypeHost = "application/mmm-host";
    #endregion

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="directory">Directory to store the server information.</param>
    public MeshMachineCoreServer(string directory) {
        KeyCollection = GetKeyCollection();

        if (directory != null) {
            DirectoryMaster = directory;
            DirectoryMesh = Path.Combine(directory, "Profiles");
            DirectoryKeys = Path.Combine(directory, "Keys");

            }
        else {
            var keyCollectionCore = KeyCollection as KeyCollectionCore;
            DirectoryMesh = keyCollectionCore.DirectoryMesh;
            DirectoryKeys = keyCollectionCore.DirectoryKeys;
            }
        Directory.CreateDirectory(DirectoryMesh);
        Directory.CreateDirectory(DirectoryKeys);
        }



    #region // Disposing (Currently null)
    //protected override void Disposing() {
    //    //CatalogHost.Dispose();
    //    }
    #endregion

    public virtual IKeyCollection GetKeyCollection() => new KeyCollectionCore();


    #region // Implementation
    ///<inheritdoc/>
    public virtual string GetFilePath(string filepath) => filepath;


    /// <summary>
    /// Generate a keypair of a type specified by <paramref name="algorithmID"/> and bind to the 
    /// KeyCollection of the machine instance.
    /// </summary>
    /// <param name="algorithmID">The type of keypair to create.</param>
    /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <returns>The created key pair</returns>
    public virtual KeyPair CreateKeyPair(
                CryptoAlgorithmId algorithmID,
                KeySecurity keySecurity,
                int keySize = 0,
                KeyUses keyUses = KeyUses.Any) => KeyPair.Factory(algorithmID, keySecurity,
                    KeyCollection, keySize, keyUses);


    ///// <summary>
    ///// Factory constructor.
    ///// </summary>
    ///// <returns></returns>
    //public static IMeshMachine GetMachine() => new MeshMachineCore();


    ///<inheritdoc cref="IMeshMachine"/>
    public virtual MeshServiceClient GetMeshClient(
            ICredentialPrivate credential,
            string service,
            string accountAddress) {

        var meshServiceBinding = new ConnectionInitiator(
        credential, service, null, TransportType.Http, MeshServiceClient.WellKnown);

        return meshServiceBinding.GetClient<MeshServiceClient>();
        }

    ///<inheritdoc cref="IMeshMachine"/>
    public virtual ICredentialPrivate GetCredential(string deviceUdf, string connectionUdf) => throw new NYI();



    #endregion
    }

/// <summary>
/// 
/// </summary>
/// <remarks>This implementation does not currently support concurrent access to the Mesh profile files
/// from separate processes. This support should be added my introducing a system wide lock that is
/// obtained before attempting a write operation and while opening a container.</remarks>
public class MeshMachineCore : MeshMachineCoreServer, IMeshMachineClient {

    #region // Properties
    ///<summary>The Mesh host catalog</summary>
    public MeshHost MeshHost { get; }

    ///<summary>The file name of the host catalog.</summary>
    public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");

    #endregion
    #region // Disposing

    /// <summary>
    /// Disposing routine. Feee internal resources  and shut down the Mesh Host.
    /// </summary>
    protected override void Disposing() => MeshHost.Dispose();
    #endregion

    /// <summary>
    /// Constructor, creating a service instance using <paramref name="directory"/>
    /// to store persistent data.
    /// </summary>
    /// <param name="directory">Directory to store persistence data.</param>
    public MeshMachineCore(string directory = null) : base(directory) {
        // Read the container to get the directories.
        var containerHost = new PersistHost(FileNameHost, FileTypeHost,
            fileStatus: FileStatus.ConcurrentLocked,
            containerType: SequenceType.Merkle);

        MeshHost = new MeshHost(containerHost, this);
        }

    #region // Convenience accessors



    #endregion


    #region // Implementation


    ///<inheritdoc/>
    public override ICredentialPrivate GetCredential(string deviceUdf, string connectionUdf) {

        if (!MeshHost.ContainerHost.ObjectIndex.TryGetValue(connectionUdf, out var Service)) {
            return null;
            }
        var catalogedMachine = Service.JsonObject as CatalogedService;
        var deviceKeySeed = KeyCollection.LocatePrivateKey(deviceUdf) as PrivateKeyUDF;


        var profileHost = catalogedMachine?.EnvelopedProfileHost?.Decode(KeyCollection);
        var profileService = catalogedMachine?.EnvelopedProfileService?.Decode(KeyCollection);
        var baseDecrypt = deviceKeySeed.GenerateContributionKeyPair(MeshKeyType.Base,
                MeshActor.Host, MeshKeyOperation.Encrypt);
        KeyCollection.Add(baseDecrypt);

        var activationDevice = catalogedMachine?.EnvelopedActivationHost?.Decode(KeyCollection);

        activationDevice.Activate(deviceKeySeed);

        var connectionDevice = catalogedMachine?.EnvelopedConnectionService?.Decode();


        return new MeshCredentialPrivate(
            profileHost,
            connectionDevice,
            null,
            activationDevice.DeviceAuthentication);

        }



    #endregion

    }

