using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

namespace Goedel.Mesh.Protocol.Client {
    public class ContextAdmin {

        AdminEntry AdminEntry;

        ///<summary>The master profile</summary>
        public ProfileMaster ProfileMaster { get; }

        ///<summary>The device profile to which the signature key is bound</summary>
        public ProfileDevice ProfileDevice { get; }

        public string Local => AdminEntry.Local;

        IMeshMachineClient MeshMachineClient { get; }

        /// <summary>
        /// Construct a ContextAdmin from the AdminEntry stored on the specified meshMachine
        /// </summary>
        /// <param name="meshMachine"></param>
        /// <param name="local"></param>
        public ContextAdmin(IMeshMachineClient meshMachine, string local = null) :
                this (meshMachine, meshMachine.GetAdmin(local)) {
            
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminEntry"></param>
        public ContextAdmin (
                IMeshMachineClient meshMachine,
                AdminEntry adminEntry
                ) {
            Assert.AssertNotNull(AdminEntry, NYI.Throw);

            MeshMachineClient = meshMachine;
            AdminEntry = adminEntry;
            ProfileMaster = ProfileMaster.Decode(adminEntry.EncodedProfileMaster);
            ProfileDevice = ProfileDevice.Decode(adminEntry.EncodedProfileDevice);
            // Here recover / reconstruct the signature key
            }

        /// <summary>
        /// Add the account <paramref name="accountEntry"/> to the master profile
        /// </summary>
        /// <param name="accountEntry">Description of the account to add</param>
        public void Add(AccountEntry accountEntry) {

            }

        /// <summary>
        /// Sign the specified device connection
        /// </summary>
        /// <param name="assertionDeviceConnection"></param>
        public void Sign(AssertionDeviceConnection assertionDeviceConnection) {

            }

        }
    }
