using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;


namespace Goedel.Mesh {

    public delegate IMeshMachine GetMachineDelegate();

    public static class MeshMachine {
        public static GetMachineDelegate GetMachine;


        public static string DirectoryProfiles;

        }

    public interface IMeshMachine {

        string DirectoryMesh { get; }


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



        void OpenCatalog(Catalog catalog, string name);

        //void Register(DareEnvelope entry);




        //AssertionAccount GetConnection(
        //            string accountName = null,
        //            string deviceUDF = null);



        }

    }
