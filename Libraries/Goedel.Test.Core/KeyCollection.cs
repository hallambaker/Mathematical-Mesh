using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Test.Core {


    /// <summary>
    /// Test machine. The cryptographic keys and persistence stores are only 
    /// stored as in-memory structures and never written to disk.
    /// </summary>
    public class MeshMachineTest : IMeshMachine {

        Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();

        public KeyCollection KeyCollection {
            get {
                keyCollection = keyCollection ?? new KeyCollectionTest(this);
                return keyCollection;
                }
            }

        KeyCollection keyCollection;

        public MachineEnvironment MachineEnvironment;
        /// <summary>
        /// Construct a unique test machine with the specified class name.
        /// Separate persistence stores will be created.
        /// </summary>
        /// <param name="Name"></param>
        public MeshMachineTest(MachineEnvironment machineEnvironment = null, string name="Test") => 
                    MachineEnvironment = machineEnvironment ?? new MachineEnvironment(name);

        public void Register(ProfileDevice Device) {
            }
        public void Register(ProfileMaster Device) {
            }
        public void Register(ProfileApplication Device) {
            }


        public void Persist(KeyPair keyPair) {
            DictionaryKeyPairByUDF.Remove(keyPair.UDF);
            DictionaryKeyPairByUDF.Add(keyPair.UDF, keyPair);
            }


        public KeyPair GetPrivate(string UDF) {
            DictionaryKeyPairByUDF.TryGetValue(UDF, out var Result);
            return Result;
            }

        }


    public class KeyCollectionTest : KeyCollectionCore {
        MeshMachineTest MeshMachine;

        static string _DirectoryKeys;
        static string _DirectoryMesh;

        public override string DirectoryKeys => _DirectoryKeys;
        public override string DirectoryMesh => _DirectoryMesh;



        public KeyCollectionTest(MeshMachineTest meshMachine) {
            MeshMachine = meshMachine;
            _DirectoryKeys = Path.Combine(MeshMachine.MachineEnvironment.Path, "Keys");
            _DirectoryMesh = Path.Combine(MeshMachine.MachineEnvironment.Path, "Profiles");
            }


        /// <summary>
        /// Add a keypair and bind it to the persistence store.
        /// </summary>
        /// <param name="keyPair">The key pair to add.</param>
        public override void Add(KeyPair keyPair) {
            if (keyPair.KeySecurity.IsPersisted()) {
                MeshMachine.Persist(keyPair);
                base.Add(keyPair);
                }
            }


        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="ID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override KeyPair MatchPrivateSign(string ID) {
            var Result = MeshMachine.GetPrivate(ID);
            Result = Result ?? base.MatchPrivateSign(ID);
            return Result;
            }

       }

    }
