using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Protocol.Exchange {

    /// <summary>
    /// A key exchange client
    /// </summary>
    public class KeyExchangeClient {

        KeyExchangeService KeyExchangeService;

        string AccountID;

        /// <summary>
        /// Connect up to the specified Mesh Portal
        /// </summary>
        /// <param name="Service">The service to connect to.</param> 
        /// <param name="AccountID">The identity to claim.</param>
        public KeyExchangeClient (string Service = null, string AccountID = null) {
            if (Service == null) {
                AccountID.SplitAccountID(out var Account, out Service);
                }
            Assert.NotNull(Service, InvalidAddress.Throw);

            this.AccountID = AccountID;
            KeyExchangeService = KeyExchangePortal.Default.GetService(Service);
            }


        //public ExchangeTicket GetTicket (KeyPair KeyPair) {

        //    var ClientID = Key.GetPublic(KeyPair);


        //    return GetTicket(ClientID);
        //    }

        /// <summary>
        /// Get ticket for Client
        /// </summary>
        /// <param name="ClientID">ClientID to generate ticket for.</param>
        /// <returns>The generated ticket.</returns>
        public ExchangeTicket GetTicket (CryptoProviderRecryption ClientID) {

            var Ephemeral = ClientID.MakeEphemeral();

            var KeyExchangeRequest = new ExchangeRequest() {
                ClientCredential = Key.FactoryPublic(ClientID.KeyPair),
                ClientNonce = Key.FactoryPublic(Ephemeral.KeyPair)
                };


            var Response = KeyExchangeService.Exchange(KeyExchangeRequest);

            // 


            return new ExchangeTicket(Response);
            }

        }

    }
