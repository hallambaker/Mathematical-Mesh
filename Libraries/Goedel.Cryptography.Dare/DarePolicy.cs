using System;
using System.Collections.Generic;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {


    public partial class DarePolicy {

        public bool Encrypt => throw new NYI();

        public IKeyLocate KeyLocate { get; set; }

        public CryptoParameters GetCryptoParameters() => throw new NYI();


        public DarePolicy(
                        IKeyLocate keyCollection = null,
                        List<string> recipients = null,
                        List<string> signers = null,
                        CryptoKey recipient = null,
                        CryptoKey signer = null,
                        CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                        CryptoAlgorithmId digestID = CryptoAlgorithmId.NULL) => throw new NYI();

        }

    }
