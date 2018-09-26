using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {

    /// <summary>
    /// Class that represents a device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public class ContextDevice {

        public ProfileDevice ProfileDevice { get;}
        public DareMessage ProfileDeviceSigned => ProfileDevice.ProfileDeviceSigned;

        public ContextDevice(IMeshMachine machine = null, string AccountID = null, string ProfileID = null) {
            }


        ContextDevice(ProfileDevice ProfileDevice) {
            }

        public static ContextDevice Generate(
                IMeshMachine machine = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            machine = machine ?? MeshMachine.Default;
            var KeyCollection = machine.GetKeyCollection();

            // Create the key set. 
            // Hack: hard coded to RSA for ease of debugging
            var keySign = KeyPair.Factory(CryptoAlgorithmID.Ed448, KeySecurity.Device, KeyCollection, Sign: true, Exchange: false);
            var keyEncrypt = KeyPair.Factory(CryptoAlgorithmID.Ed448, KeySecurity.Device, KeyCollection, Sign: false, Exchange:true);
            var keyAuthenticate = KeyPair.Factory(CryptoAlgorithmID.Ed448, KeySecurity.Device, KeyCollection, Sign: true);

            // Generate the profile
            var Profile = Mesh.ProfileDevice.Generate(
                        keySign.KeyPairPublic(), keyEncrypt.KeyPairPublic(), keyAuthenticate.KeyPairPublic());

            // Register the profile locally
            machine.Register(Profile);

            return new ContextDevice(Profile);

            }

        public ContextMaster GenerateMaster(
            IMeshMachine machine = null,
            CryptoAlgorithmID AlgorithmSign = CryptoAlgorithmID.Default,
            CryptoAlgorithmID AlgorithmEncrypt = CryptoAlgorithmID.Default) => throw new NYI();

        public string Connect(string account) => throw new NYI();

        public bool Complete(string account) => throw new NYI();

        }



    }
