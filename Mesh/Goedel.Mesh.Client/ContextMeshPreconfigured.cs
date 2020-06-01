using Goedel.Cryptography;
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
    public class ContextMeshPreconfigured : ContextMesh {

        ///<summary>Convenience accessor for the pending context.</summary>
        public CatalogedPreconfigured CatalogedPreconfigured
                    => CatalogedMachine as CatalogedPreconfigured;


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


            // no request waiting? return


            // Verify request.ServiceAuthenticate & request.AccountAddress
            // Verify request.DeviceAuthenticate & request.AccountAddress


            // Generate the PIN code value from secret and request.AccountAddress

            // Post connection request


            // Make request to the user service


            // Success? create a pending connection entry.



            throw new NYI();
            }



        public static ContextMeshPreconfigured Install (
                        MeshHost meshHost,
                        DevicePreconfiguration devicePreconfiguration) {

            var privateKeyUDF = devicePreconfiguration.PrivateKey as PrivateKeyUDF;
            (var accountAddress, var key) = MeshUri.ParseConnectUri(devicePreconfiguration.ConnectUri);

            // Note that we process the devicePreconfiguration values so that the device itself
            // does not have a machine readable value for the secret key.
            var publicationID = UDF.SymetricKeyId(key);
            var serviceAuthenticator = CatalogedPublication.GetServiceAuthenticator(key);
            var deviceAuthenticator = CatalogedPublication.GetDeviceAuthenticator(key);

            var profileDevice = new ProfileDevice(privateKeyUDF, meshHost.KeyCollection, true);

            // create a Mesh Host entry.
            
            var catalogedPreconfig = new CatalogedPreconfigured() {
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                ID = profileDevice.UDF,
                ServiceAuthenticator = serviceAuthenticator,
                DeviceAuthenticator = deviceAuthenticator,
                PublicationID = publicationID,
                AccountAddress = accountAddress
                };

            // add to the catalog.
            var context = new ContextMeshPreconfigured(meshHost, catalogedPreconfig);
            meshHost.Register(catalogedPreconfig, context);

            return context;

            }


        }
    }
