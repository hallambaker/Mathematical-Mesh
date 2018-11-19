using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Protocol.Client {



    /// <summary>
    /// Class that represents an administrator device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public class ContextMaster : ContextAdministrator {
        public ContextDevice ContextDevice { get; }

        public override IMeshMachine Machine => ContextDevice.Machine;
        public override ProfileDevice ProfileDevice => ContextDevice.ProfileDevice;
        public virtual ProfileMaster ProfileMaster { get; }


        public string UDF => ProfileMaster.UDF;

        /// <summary>
        /// Generate 
        /// </summary>
        /// <param name="contextDevice"></param>
        /// <param name="keyPublicSign"></param>
        /// <param name="keyPublicEncrypt"></param>
        public ContextMaster(
                ContextDevice contextDevice,
                ProfileMaster profileMaster
                ) {
            ContextDevice = contextDevice;
            ProfileMaster = profileMaster;
            }


        public ContextMaster(
                    IMeshMachine machine = null, string accountID = null, string profileID = null) : 
                base (machine, accountID, profileID){
            }

        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage MakeAdministrator(ProfileDevice Profile) => throw new NYI();




        public (DareMessage, KeyShare[]) Escrow(int shares, int quorum, int bits = 128) {

            var secret = new Secret(bits);
            var keyShares = secret.Split(shares, quorum);
            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC);

            var MasterSignatureKeyPair = KeyCollection.LocatePrivate(ProfileMaster.MasterSignatureKey.UDF);
            var MasterSignatureKey = Key.FactoryPrivate(MasterSignatureKeyPair);
            var MasterEscrowKeys = new List<Key>();

            var EscrowedKeySet = new EscrowedKeySet() {
                MasterSignatureKey = MasterSignatureKey,
                MasterEscrowKeys = MasterEscrowKeys
                };

            var message = new DareMessage(cryptoStack, EscrowedKeySet.GetJson(true));

            return (message, keyShares);
            }




        }
    }
