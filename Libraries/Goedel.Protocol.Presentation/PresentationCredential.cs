using Goedel.Cryptography;


namespace Goedel.Protocol.Presentation {


    /// <summary>
    /// Base class for presentation credential
    /// </summary>
    public abstract class PresentationCredential {

        ///<summary>The signature key to sign under the credential.</summary> 
        protected abstract KeyPairAdvanced KeySignPrivate { get; }

        ///<summary>The private key exchange key.</summary> 
        protected abstract KeyPairAdvanced KeyExchangePrivate { get; }

        ///<summary>The signature verification key under the credential</summary> 
        public abstract KeyPairAdvanced KeySignPublic { get; }

        ///<summary>The public key exchange key.</summary> 
        public abstract KeyPairAdvanced KeyExchangePublic { get; }

        /// <summary>
        /// Obsolete, to be removed.
        /// </summary>
        /// <param name="jsonWriter"></param>
        public abstract void WriteClientCredential(JsonWriter jsonWriter);


        /// <summary>
        /// Write credential type specifier and credential to packet.
        /// </summary>
        /// <param name="writer">The packet writer</param>
        public abstract void WriteCredential(PacketWriter writer);
        }


    }
