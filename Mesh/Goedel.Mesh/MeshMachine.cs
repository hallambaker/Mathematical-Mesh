using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using System;
using System.Text;
using Goedel.Utilities;


namespace Goedel.Mesh {

    /// <summary>
    /// Return a new IMeshMachine.
    /// </summary>
    /// <returns>The created instance.</returns>
    public delegate IMeshMachine GetMachineDelegate();


    /// <summary>
    /// Support class for MeshMachine containing static methods and delegate dispatch.
    /// </summary>
    public static class MeshMachine {

        ///<summary>The default number of bits in a master key.</summary>
        public static int DefaultMasterKeyBits = 256;

        ///<summary>Factory returning an IMeshMachine instance</summary>
        public static GetMachineDelegate IMeshMachineFactory;

        ///<summary>Path to directory where the profiles are stored.</summary>
        public static string DirectoryProfiles;


        }

    /// <summary>
    /// Interface exposed by all Mesh Machine classes.
    /// </summary>
    public interface IMeshMachine {

        ///<summary>The directory the Mesh data is stored in.</summary>
        string DirectoryMesh { get; }

        ///<summary>The key collection to use.</summary>
        KeyCollection KeyCollection { get; }

        /// <summary>
        /// Factory method to generate a keypair of a type specified by <paramref name="algorithmID"/>
        /// and the specified parameters using the default implementation registered with the
        /// KeyPair type.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <returns>The created key pair</returns>
        KeyPair CreateKeyPair(
                    CryptoAlgorithmID algorithmID,
                    KeySecurity keySecurity,
                    int keySize = 0,
                    KeyUses keyUses = KeyUses.Any);

        }





    }
