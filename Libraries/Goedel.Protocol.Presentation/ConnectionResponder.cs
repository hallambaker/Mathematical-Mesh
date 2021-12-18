#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Goedel.Cryptography;
using Goedel.Cryptography.Jose;


namespace Goedel.Protocol.Presentation;

/// <summary>
/// Presentation host connection. Tracks the state of a host connection.
/// </summary>
public partial class ConnectionResponder : RudConnection {

    #region // Properties

    ///<inheritdoc/> 
    public override byte[] ClientKeyIn => ClientKeyClientToHost;
    ///<inheritdoc/>
    public override byte[] ClientKeyOut => ClientKeyHostToClient;
    ///<inheritdoc/> 
    public override byte[] MutualKeyIn => MutualKeyClientToHost;
    ///<inheritdoc/>
    public override byte[] MutualKeyOut => MutualKeyHostToClient;
    ///<inheritdoc/> 
    public override ICredentialPublic HostCredential => CredentialSelf;
    ///<inheritdoc/> 
    public override ICredentialPublic ClientCredential => CredentialOther;





    ///<summary>The source Id to be used by this responder when returning packets.</summary> 

    public StreamId SourceId;

    static List<PacketExtension> EphemeralExtensionsCurrent;

    static List<KeyPairAdvanced> EphemeralsPrevious;

    static List<KeyPairAdvanced> EphemeralsCurrent;

    //static DateTime EphemeralsCreated;

    static DateTime EphemeralsExpire;

    static readonly TimeSpan EphemeralValidity = new(1, 0, 0);

    #endregion
    #region // Constructors

    /// <summary>
    /// Constructor for a connection host instance connected to <paramref name="listener"/>
    /// </summary>
    /// <param name="listener">The listener this connection is to service.</param>
    /// <param name="packetIn">The packet resulting in creation of the responder.</param>
    public ConnectionResponder(Listener listener,
            Packet packetIn = null) {
        Listener = listener;
        CredentialSelf = Listener?.CredentialSelf;

        if (packetIn != null) {
            //LocalStreamId = StreamId.GetStreamId();
            //ReturnStreamId = LocalStreamId.GetValue();

            PacketIn = packetIn;
            }

        }

    #endregion
    #region // Methods 
    /// <summary>
    /// Generate a new set of ephemerals
    /// </summary>
    public virtual void RollEphemerals() {
        EphemeralsPrevious = EphemeralsCurrent;
        var ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
        EphemeralsCurrent = new List<KeyPairAdvanced> { ephemeral };
        var extension = new PacketExtension() {
            Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
            Value = ephemeral.IKeyAdvancedPublic.Encoding
            };

        EphemeralExtensionsCurrent = new List<PacketExtension> { extension };
        //EphemeralsCreated = DateTime.Now;
        EphemeralsExpire = DateTime.Now + EphemeralValidity;
        }


    /// <summary>
    /// Add a challenge value over the current state to <paramref name="extensions"/>
    /// </summary>
    /// <param name="extensions">List of extensions to add the ephemerals to.</param>
    public override void AddChallenge(
            List<PacketExtension> extensions) {

        }


    ///<inheritdoc/>
    public override void AddEphemerals(byte[] destinationId, List<PacketExtension> extensions) {
        if (EphemeralsCurrent == null | DateTime.Now > EphemeralsExpire) {
            RollEphemerals();
            }
        foreach (var ephemeral in EphemeralExtensionsCurrent) {
            extensions.Add(ephemeral);
            }
        }

    ///<inheritdoc/>
    public override void MutualKeyExchange(string keyId) {
        var privateEphemeral = EphemeralsCurrent[0];  // hack, should pull ephemeral properly by Id.
        MutualKeyExchange(privateEphemeral, CredentialOther.AuthenticationPublic);
        }

    #endregion
    }
