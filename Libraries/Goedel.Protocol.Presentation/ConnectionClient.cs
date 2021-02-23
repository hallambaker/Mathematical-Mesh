

using System.Threading.Tasks;

namespace Goedel.Protocol.Presentation {





    /// <summary>
    /// Client side connection state.
    /// </summary>
    public enum ClientState {
        ///<summary>Initial state, sending either Initial or Cloaked.</summary> 
        Initial,
        ///<summary>Host challenge received, sending answer.</summary> 
        Challenge,
        ///<summary>Connection established, sending packets.</summary> 
        Write,
        ///<summary>Connection terminated, cannot be used further.</summary> 
        Abort
        }


    /// <summary>
    /// Presentation client connection. Tracks the state of a client connection.
    /// </summary>
    public abstract partial class ConnectionClient : Connection {
        ///<inheritdoc/>
        public override byte[] ClientKeyIn => ClientKeyHostToClient;
        ///<inheritdoc/>
        public override byte[] ClientKeyOut => ClientKeyClientToHost;
        ///<inheritdoc/>
        public override byte[] MutualKeyIn => MutualKeyHostToClient;
        ///<inheritdoc/> 
        public override byte[] MutualKeyOut => MutualKeyClientToHost;
        ///<inheritdoc/>
        public override Credential HostCredential => CredentialOther;
        ///<inheritdoc/>
        public override Credential ClientCredential => CredentialSelf;

        ///<summary>The current state of this client.</summary> 
        ClientState clientState;



        public abstract Task<byte[]> Transact(byte[] payload);


        }

    }
