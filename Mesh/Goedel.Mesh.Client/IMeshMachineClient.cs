using Goedel.Cryptography;
using Goedel.Protocol;

namespace Goedel.Mesh.Client {
    /// <summary>
    /// Interface exposing the properties and methods required to obtain a Mesh Client.
    /// </summary>
    public interface IMeshMachineClient : IMeshMachine {
        ///<summary>Direct access to the Catalog, should remove this</summary>
        MeshHost MeshHost { get; }

        /// <summary>
        /// Return a MeshService client for the service ID <paramref name="accountAddress"/>.
        /// </summary>
        /// <returns>The client instance.</returns>
        MeshServiceClient GetMeshClient(string accountAddress);
        }
    }
