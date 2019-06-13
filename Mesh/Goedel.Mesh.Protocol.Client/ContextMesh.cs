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
                MeshMachine, CatalogEntryDevice.EnvelopedDevicePrivate).CacheValue(
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




        }


    public class ContextMeshPending : ContextMesh {
        public string ServiceID;
        public MeshService MeshClient;

        public ContextMeshPending(IMeshMachineClient meshMachine, Connection deviceConnection) :
                    base(meshMachine, deviceConnection) {
            }



        public static ContextMeshPending ConnectService(
        IMeshMachineClient meshMachine,
        string serviceID,
        string localName = null,
        string PIN = null,
        CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
        CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
        CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            var profileDevice = ProfileDevice.Generate(meshMachine,
                algorithmSign: algorithmSign, algorithmEncrypt: algorithmEncrypt,
                algorithmAuthenticate: algorithmAuthenticate);

            return ConnectService(meshMachine, profileDevice, serviceID, localName, PIN);
            }

        

        public static ContextMeshPending ConnectService(
                IMeshMachineClient meshMachine,
                ProfileDevice profileDevice,
                string serviceID,
                string localName = null,
                string PIN = null) {

            // generate MessageConnectionRequestClient
            var messageConnectionRequestClient = new MessageConnectionRequest() {
                ServiceID = serviceID,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                ClientNonce = CryptoCatalog.GetBits(128),
                PinUDF = UDF.PIN2PinID(PIN)
                };

            

            var keyAuthentication = meshMachine.KeyCollection.LocatePrivate(
                        profileDevice.KeyAuthentication.UDF);

            var messageConnectionRequestClientEncoded = messageConnectionRequestClient.Encode(keyAuthentication);

            // Acquire ephemeral client. This will only be used for the Connect and Complete methods.
            var meshClient = meshMachine.GetMeshClient(serviceID, keyAuthentication, null);

            var connectRequest = new ConnectRequest() {
                MessageConnectionRequestClient = messageConnectionRequestClientEncoded
                };

            var response = meshClient.Connect(connectRequest);

            // create the pending connection here

            var connection = new PendingConnection() {
                ID = profileDevice.UDF,
                DeviceUDF = profileDevice.UDF,
                EnvelopedMessageConnectionRequest = response.MessageConnectionRequest,
                };

            meshMachine.Register(connection);

            return new ContextMeshPending(meshMachine, connection);

            }

        /// <summary>
        /// Complete the pending connection request.
        /// </summary>
        /// <returns>If successfull returns an ContextAccountService instance to allow access
        /// to the connected account. Otherwise, a null value is returned.</returns>
        public ContextAccountService Complete() {
            throw new NYI();
            }

        //protected MeshService GetMeshClient(string serviceID) => 
        //    MeshMachine.GetMeshClient(serviceID, KeyAuthentication,
        //        ActivationAccount.AssertionAccountConnection, ContextMesh.ProfileMesh);

        }
    }
