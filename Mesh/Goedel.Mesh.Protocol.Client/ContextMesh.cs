using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

namespace Goedel.Mesh.Client {

    public partial class ContextMesh : Disposable {
        ///<summary>The Machine context.</summary>
        public IMeshMachineClient MeshMachine { get; }

        ///<summary>The master profile</summary>
        public ProfileMaster ProfileMesh { get; }

        ///<summary>The Device Entry in the CatalogHost</summary>
        public Connection Connection;


        ///<summary>Convenience property returning the device connections</summary>
        DeviceConnection DeviceConnection => Connection as DeviceConnection;

        ///<summary>For a non administrative device, the CatalogEntryDevice is in the 
        ///connection entry;</summary>
        public virtual CatalogEntryDevice CatalogEntryDevice => DeviceConnection.CatalogEntryDevice;

        /////<summary>The device profile to which the signature key is bound</summary>
        //public ProfileDevice profileDevice { get; }

        AssertionDevicePrivate AssertionDevicePrivate => assertionDevicePrivate ??
            AssertionDevicePrivate.Decode(
                MeshMachine, CatalogEntryDevice.EncryptedDevicePrivate).CacheValue(
                    out assertionDevicePrivate);

        AssertionDevicePrivate assertionDevicePrivate = null;

        ///<summary>The context as an administration context.</summary>
        public ContextMeshAdmin ContextMeshAdmin => this as ContextMeshAdmin;





        public ContextMesh(IMeshMachineClient meshMachine, Connection deviceConnection) {
            Assert.AssertNotNull(deviceConnection, NYI.Throw);

            MeshMachine = meshMachine;
            Connection = deviceConnection;

            ProfileMesh = ProfileMaster.Decode(Connection.EncodedProfileMaster);
            
            }

        // The account activation was not added to activations.

        public ContextAccountService GetContextAccountService(
                string localName=null,
                string accountName = null) {

            var activation = AssertionDevicePrivate.GetActivation(accountName);

            return new ContextAccountService(this, activation);

            }

        public static ContextAccountService ConnectService(
                string localName, 
                string accountName = null,
                string PIN = null) {

            throw new NYI();
            }
        }

    }
