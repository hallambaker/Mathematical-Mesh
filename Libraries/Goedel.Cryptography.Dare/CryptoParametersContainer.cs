using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Dare {
    /// <summary>
    /// Specifies a set of cryptographic parameters to be used to create 
    /// CryptoStacks
    /// </summary>
    public partial class CryptoParametersContainer : CryptoParameters {

        bool ForcePolicy = false;
        DarePolicy Policy { get; set; }

        /// <summary>
        /// Create cryptoparameters for a new container.
        /// </summary>
        /// <param name="keyCollection">The resolution instance.</param>
        /// <param name="policy">The container security policy</param>
        public CryptoParametersContainer(
                    IKeyLocate keyCollection,
                    DarePolicy policy) {

            SetPolicy(keyCollection, policy);
            ForcePolicy = true;




            }

        /// <summary>
        /// Create cryptoparameters for a reopened container.
        /// </summary>
        /// <param name="keyCollection"></param>
        /// <param name="header">Header specifying the governing policy.</param>
        public CryptoParametersContainer(
                IKeyLocate keyCollection, 
                DareHeader header) {

            if (header.Policy != null) {
                SetPolicy(keyCollection, header.Policy);
                }
            else {
                // what to do if there is no policy? I guess we are just doing plaintext
                }


            throw new NYI();


            }



        /// <summary>
        /// Perform the steps necessary to 
        /// </summary>
        /// <param name="header"></param>
        public virtual void SetKeyExchange(DareHeader header) {

            header.Recipients = KeyExchange();
            if (ForcePolicy) {
                header.Policy = Policy;
                ForcePolicy = false;
                }

            }



        public void SetPolicy(
                    IKeyLocate keyCollection,
                    DarePolicy policy) {
            Policy = policy;

            }





        }
    }
