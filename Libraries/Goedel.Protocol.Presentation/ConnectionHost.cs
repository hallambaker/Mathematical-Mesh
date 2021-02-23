using System.Threading.Tasks;

namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// Presentation host connection. Tracks the state of a host connection.
    /// </summary>
    public abstract partial class ConnectionHost : Connection {
        ///<inheritdoc/> 
        public override byte[] ClientKeyIn => ClientKeyClientToHost;
        ///<inheritdoc/>
        public override byte[] ClientKeyOut => ClientKeyHostToClient;
        ///<inheritdoc/> 
        public override byte[] MutualKeyIn => MutualKeyClientToHost;
        ///<inheritdoc/>
        public override byte[] MutualKeyOut => MutualKeyHostToClient;
        ///<inheritdoc/> 
        public override Credential HostCredential => CredentialSelf;
        ///<inheritdoc/> 
        public override Credential ClientCredential => CredentialOther;


        public abstract Task<byte[]> Receive();

        public abstract void Reply(byte[] payload);
        }

    }
