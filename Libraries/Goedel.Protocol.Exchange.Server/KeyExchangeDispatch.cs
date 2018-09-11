//using System;
//using System.Collections.Generic;
//using Goedel.Utilities;
//using Goedel.Cryptography;
//using Goedel.Cryptography.Jose;

//namespace Goedel.Protocol.Exchange.Server {

    

//    /// <summary>
//    /// The service persistence provider. This will eventually be the interface to 
//    /// account stores, etc. 
//    /// </summary>
//    public class PublicKeyExchangeServiceProvider : KeyExchangeServiceProvider {

//        /// <summary>
//        /// The recryption service provider.
//        /// </summary>
//        public CryptoProviderRecryption RecryptionProvider;


//        /// <summary>
//        /// Initialize a Mesh Service Provider.
//        /// </summary>
//        /// <param name="Domain">The domain of the service provider.</param>
//        public PublicKeyExchangeServiceProvider (string Domain) {

//            // Get the host identity key credential.
//            RecryptionProvider = CryptoCatalog.Default.GetRecryption(CryptoAlgorithmID.DH);
//            RecryptionProvider.Generate(KeySecurity.Exportable, 2048);

//            }

//        }
//    /// <summary>
//    /// The session class implements the Mesh session.
//    /// </summary>
//    public class PublicKeyExchangeService : KeyExchangeService {
//        PublicKeyExchangeServiceProvider Provider;

//        /// <summary>List of encryption algorithms supported for use with ticket</summary>
//        public List<String> Encryption = new List<string> { "A256CBC-HS512" };

//        /// <summary>List of authenticaiton algorithms supported for use with ticket</summary>
//        public List<String> Authentication = new List<string> { "HS512" };

//        /// <summary>
//        /// The key exchange service dispatcher.
//        /// </summary>
//        /// <param name="Host">The service provider.</param>
//        /// <param name="Session">The authentication context.</param>
//        public PublicKeyExchangeService (PublicKeyExchangeServiceProvider Host, JPCSession Session) {
//            this.Provider = Host;
//            Host.Interfaces.Add(this);
//            Host.Service = this;
//            }

//        /// <summary>
//        /// Dispatch a key exchange request. 
//        /// </summary>
//        /// <param name="Request">The request data</param>
//        /// <returns>The exchange response</returns>
//        public override ExchangeResponse Exchange (ExchangeRequest Request) {
//            // Is the request authenticated? If so it is signed under a ticket

//            // Validate the identity key (if provided)


//            // Construct the Exchange key
//            var ClientID = Request.ClientCredential.GetKeyPair() as KeyPairDH;
//            var ClientNonce = Request.ClientNonce.GetKeyPair() as KeyPairDH;

//            var Combined = ClientID.Combine(ClientNonce);


//            // Generate an Ephemeral key
//            var EphemeralProvider = Provider.RecryptionProvider.MakeEphemeral();

//            // Construct the Service Exchange key


//            var Exchange = EphemeralProvider.Exchange(Combined);
//            // Perform the Key Exchange


//            // Generate the Witness Value
//            var KeyDerive = Exchange.KeyDerive;
//            var Witness = KeyDerive.Derive("witness".ToBytes());

//            // Generate the Ticket


//            // Generate the response
//            var Response = new ExchangeResponse() {
//                Ticket = "Opaque value outside scope of specification".ToBytes(),
//                Witness = Witness,
//                ServerCredential = Key.FactoryPublic(Provider.RecryptionProvider.KeyPair),
//                ServerNonce = Key.FactoryPublic(EphemeralProvider.KeyPair),
//                Encryption = Encryption,
//                Authentication = Authentication
//                };

//            // Authenticate the Response under the new ticket



//            return Response;
//            }



//        /// <summary>
//        /// Perform a key exchange request. 
//        /// </summary>
//        /// <param name="Request">The request data</param>
//        /// <returns>The response</returns>
//        public virtual ExchangeResponse Rekey (ExchangeRequest Request) {
//            // Is the request authenticated? If so it is signed under a ticket

//            // Construct the Exchange key


//            // Generate an Ephemeral key


//            // Construct the Service Exchange key


//            // Perform the Key Exchange


//            // Generate the Witness Value


//            // Generate the Ticket


//            // Generate the response
//            var Response = new ExchangeResponse() {
//                Ticket = null,
//                Witness = null,
//                ServerNonce = null,
//                Encryption = Encryption,
//                Authentication = Authentication
//                };

//            // Authenticate the Response under the OLD ticket



//            return Response;
//            }

//        }

//    }