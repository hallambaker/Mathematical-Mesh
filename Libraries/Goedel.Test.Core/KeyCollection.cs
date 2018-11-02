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
    public class MeshMachineTest : MeshMachineCore {


        Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();


        public MachineEnvironment MachineEnvironment;


        public override KeyCollection GetKeyCollection() => new KeyCollectionTest(this);

        /// <summary>
        /// Construct a unique test machine with the specified class name.
        /// Separate persistence stores will be created.
        /// </summary>
        /// <param name="Name"></param>
        public MeshMachineTest(MachineEnvironment machineEnvironment) :
            base(machineEnvironment.Path) => MachineEnvironment = machineEnvironment;


        public MeshMachineTest(string name="Default") : this (new MachineEnvironment(name)) {
            }


        public void Persist(KeyPair keyPair) {
            DictionaryKeyPairByUDF.Remove(keyPair.UDF);
            DictionaryKeyPairByUDF.Add(keyPair.UDF, keyPair);
            }


        public KeyPair GetPrivate(string UDF) {
            DictionaryKeyPairByUDF.TryGetValue(UDF, out var Result);
            return Result;
            }


        public override void OpenCatalog(Catalog catalog, string Name) {




            }


        }


    public class KeyCollectionTest : KeyCollectionCore {
        MeshMachineTest MeshMachine;

        public override string DirectoryKeys => MeshMachine.DirectoryKeys;


        public KeyCollectionTest(MeshMachineTest meshMachine) => MeshMachine = meshMachine;


        /// <summary>
        /// Add a keypair and bind it to the persistence store.
        /// </summary>
        /// <param name="keyPair">The key pair to add.</param>
        public override void Add(KeyPair keyPair) {
            if (keyPair.PersistPending) {
                MeshMachine.Persist(keyPair);
                base.Add(keyPair);
                }
            }


       }

    }
