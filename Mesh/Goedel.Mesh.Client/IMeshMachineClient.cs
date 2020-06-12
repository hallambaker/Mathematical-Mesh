using Goedel.Cryptography;

namespace Goedel.Mesh.Client {
    /// <summary>
    /// Interface exposing the properties and methods required to obtain a Mesh Client.
    /// </summary>
    public interface IMeshMachineClient : IMeshMachine {
        ///<summary>Direct access to the Catalog, should remove this</summary>
        MeshHost MeshHost { get; }

        /// <summary>
        /// Return a MeshService client for the service ID <paramref name="accountAddress"/>
        /// using the authentication key <paramref name="keyAuthentication"/> and credential
        /// <paramref name="assertionAccountConnection"/>. 
        /// </summary>
        /// <param name="accountAddress">The service identifier to connect to.</param>
        /// <param name="keyAuthentication">The private key to be used for authentication
        /// (encryption).</param>
        /// <param name="assertionAccountConnection">The credential binding the device
        /// to the account.</param>
        /// <param name="profile">The profile. This is required when requesting
        /// an inbound connection or requesting that a new account be created and optional
        /// otherwise.</param>
        /// <returns></returns>
        MeshService GetMeshClient(
                string accountAddress,
                KeyPair keyAuthentication,
                ConnectionAccount assertionAccountConnection,
                Profile profile = null);
        }
    }
