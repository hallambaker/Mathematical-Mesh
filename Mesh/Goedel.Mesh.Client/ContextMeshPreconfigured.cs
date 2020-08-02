﻿using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Base context for interacting with a preconfigured device
    /// </summary>
    public class ContextMeshPreconfigured : ContextAccount {

        ///<summary>Convenience accessor for the pending context.</summary>
        public CatalogedPreconfigured CatalogedPreconfigured
                    => CatalogedMachine as CatalogedPreconfigured;


        public override Profile Profile => throw new NotImplementedException();

        public override Connection Connection => throw new NotImplementedException();

        public override Dictionary<string, StoreFactoryDelegate> DictionaryStoreDelegates => throw new NotImplementedException();


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="meshHost">The Mesh host</param>
        /// <param name="catalogedMachine">The pending connection description.</param>
        public ContextMeshPreconfigured(MeshHost meshHost, CatalogedMachine catalogedMachine) :
                    base(meshHost, catalogedMachine) {
            }



        /// <summary>
        /// Attempt to connect to a personal Mesh by polling various services. 
        /// </summary>
        /// <returns>If successfull returns an ContextAccount instance to allow access
        /// to the connected account. Otherwise, a null value is returned.</returns>
        public ContextMeshPending Poll() {

            // attempt to connect to service specified in DevicePreconfiguration

            var meshClient = MeshMachine.GetMeshClient(
                    CatalogedPreconfigured.AccountAddress, null, null);

            //var envelopeID = Message.GetEnvelopeId(CatalogedPreconfigured.PublicationId);
            var claimRequest = new PollClaimRequest() {
                TargetAccountAddress = CatalogedPreconfigured.AccountAddress,
                PublicationId = CatalogedPreconfigured.PublicationId
                };

            var claimResponse = meshClient.PollClaim(claimRequest);

            if (claimResponse == null) {
                return null;
                }

            var messageClaim = MeshItem.Decode(claimResponse.EnvelopedMessageClaim, KeyCollection) as MessageClaim;
            messageClaim.AssertNotNull(InvalidServiceResponse.Throw); // should never be null


            // Verify request.ServiceAuthenticate & request.AccountAddress
            // Verify request.DeviceAuthenticate & request.AccountAddress
            messageClaim.Verify(
                    CatalogedPreconfigured.ServiceAuthenticator,
                    CatalogedPreconfigured.DeviceAuthenticator).AssertTrue(RefusedPINInvalid.Throw);

            Console.WriteLine($"Have been claimed by {messageClaim.Sender}");

            // Create a pending connection entry.
            var profileDevice = CatalogedPreconfigured.ProfileDevice;
            var catalogedPending = new CatalogedPending() {
                ID = profileDevice.UDF,
                DeviceUDF = profileDevice.UDF,
                AccountAddress = messageClaim.Sender,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                EnvelopedMessageConnectionResponse = claimResponse.EnvelopedMessageClaim
                //EnvelopedProfileMaster = response.EnvelopedProfileMaster,
                //EnvelopedAccountAssertion = response.EnvelopedAccountAssertion
                };

            var context = new ContextMeshPending(MeshHost, catalogedPending);

            // persist - might balk on reuse of ID
            MeshHost.Register(catalogedPending, context);

            return context;




            //throw new NYI();
            }


        /// <summary>
        /// Attempt to connect to a personal Mesh by polling various services. 
        /// </summary>
        /// <returns>If successfull returns an ContextAccountService instance to allow access
        /// to the connected account. Otherwise, a null value is returned.</returns>
        public ContextUser Complete() {
            var Pending = Poll();
            if (Pending != null) {
                return Pending.Complete ();
                }
            return null;
            }


        /// <summary>
        /// Write the device configuration <paramref name="devicePreconfiguration"/> to
        /// the Mesh host <paramref name="meshHost"/>.
        /// </summary>
        /// <param name="meshHost">The Mesh host to be written to.</param>
        /// <param name="devicePreconfiguration">The preconfiguration data.</param>
        /// <returns>Context for the preconfigured device.</returns>
        public static ContextMeshPreconfigured Install(
                    MeshHost meshHost,
                    DevicePreconfiguration devicePreconfiguration) {

            var privateKeyUDF = devicePreconfiguration.PrivateKey as PrivateKeyUDF;
            (var accountAddress, var key) = MeshUri.ParseConnectUri(devicePreconfiguration.ConnectUri);

            // Note that we process the devicePreconfiguration values so that the device itself
            // does not have a machine readable value for the secret key.
            var publicationID = UDF.SymetricKeyId(key);
            var serviceAuthenticator = CatalogedPublication.GetServiceAuthenticator(key);
            var deviceAuthenticator = CatalogedPublication.GetDeviceAuthenticator(key);

            var profileDevice = new ProfileDevice(privateKeyUDF, meshHost.KeyCollection);
            profileDevice.PersistSeed(meshHost.KeyCollection);

            // create a Mesh Host entry.

            var catalogedPreconfig = new CatalogedPreconfigured() {
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                ID = profileDevice.UDF,
                ServiceAuthenticator = serviceAuthenticator,
                DeviceAuthenticator = deviceAuthenticator,
                PublicationId = publicationID,
                AccountAddress = accountAddress
                };

            // add to the catalog.
            var context = new ContextMeshPreconfigured(meshHost, catalogedPreconfig);
            meshHost.Register(catalogedPreconfig, context);

            return context;

            }

        public override string GetAccountAddress() => throw new NotImplementedException();
        }
    }
