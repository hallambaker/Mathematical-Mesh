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


using System;
using System.Collections.Generic;
using System.Net;

using Goedel.Utilities;


namespace Goedel.Protocol.Presentation;

/// <summary>
/// Port identifier. Specifies an IP address and port number.
/// </summary>
public record PortId {

    #region // Properties
    ///<summary>The IP address.</summary> 
    public IPAddress IPAddress;

    ///<summary>The port number.</summary> 
    public int Port;

    #endregion
    }

/// <summary>
/// Port history. Used to track possible abuse.
/// </summary>
public record PortHistory {
    #region // Properties
    ///<summary>Time at which the last challenge was issued.</summary> 
    public DateTime LastChallenge;

    ///<summary>Number of challenges issued.</summary> 
    public int Challenges;

    ///<summary>Number of refusals made.</summary> 
    public int Refusals;
    #endregion
    #region // Methods 

    /// <summary>
    /// Constructor, initialize the last challenge time to now.
    /// </summary>
    public PortHistory() => LastChallenge = DateTime.Now;

    #endregion
    }



/// <summary>
/// Base class for presentation listeners.
/// </summary>
public abstract partial class Listener : Disposable {
    #region // Properties

    ///<summary>The list of RUD providers.</summary> 
    public List<RudProvider> Providers { get; }

    ///<summary>Private credential of self.</summary> 
    public virtual ICredentialPrivate CredentialSelf { get; }
    ///<summary>Packet reader delegate to use.</summary> 
    public static PacketReaderFactoryDelegate PacketReaderFactory { get; set; }
        = PacketReader.Factory;

    #endregion
    #region // Constructors

    ///<summary>Dictionary mapping inbound source Ids to sessions.</summary> 
    public Dictionary<StreamId, RudStream> DictionaryStreamsInbound = new();

    /// <summary>
    /// Base constructor, populate the common properties.
    /// </summary>
    /// <param name="credentialSelf">The credential used by the listener.</param>
    /// <param name="providers">The listener service providers.</param>
    public Listener(ICredentialPrivate credentialSelf,
        List<RudProvider> providers) {
        CredentialSelf = credentialSelf;
        Providers = providers;
        }


    #endregion
    #region // Methods 
    /// <summary>
    /// Create a challenge value over the packet <paramref name="packetRequest"/> and
    /// payload <paramref name="payload"/> and return as a list of packet extensions.
    /// </summary>
    /// <param name="packetRequest">The packet request.</param>
    /// <param name="payload">The payload.</param>
    /// <returns>List of challenge tokens.</returns>
    public abstract List<PacketExtension> MakeChallenge(
        Packet packetRequest,
        byte[] payload = null);

    /// <summary>
    /// Verify the challenge data in <paramref name="packetRequest"/> returning true if
    /// verification succeeds, false otherwise.
    /// </summary>
    /// <param name="packetRequest">The packet to be validated.</param>
    /// <returns>True if challenge was valid, otherwise false.</returns>
    public abstract bool VerifyChallenge(
        Packet packetRequest);

    /// <summary>
    /// Accept the inbound connection request described in <paramref name="packetRequest"/>.
    /// </summary>
    /// <param name="packetRequest">Parsed inbound request packet.</param>
    /// <returns>The host connection. This may be used to wait for inbound requests from the 
    /// connection.</returns>
    public abstract RudStream AcceptConnection(
                Packet packetRequest);

    /// <summary>
    /// Create a stream according to the parameters specified in <paramref name="packetExtensions"/>.
    /// If <paramref name="rudConnection"/> is not null, the new stream is the primary stream of
    /// the connection. Otherwise, <paramref name="parentStream"/> must be non null and the stream is
    /// made a child stream.
    /// </summary>
    /// <param name="packetExtensions">Extensions describing the stream to create (if found)</param>
    /// <param name="rudConnection">The RUD connection.</param>
    /// <param name="parentStream">The parent stream</param>
    /// <returns>The child stream (if created)</returns>
    public abstract RudStream AcceptStream(List<PacketExtension> packetExtensions,
            RudConnection rudConnection = null, RudStream parentStream = null);

    /// <summary>
    /// Defer creation of a host connection by sending a challenge to the source.
    /// </summary>
    /// <param name="packetRequest">Parsed inbound request packet.</param>
    public virtual RudStream GetTemporaryResponder(
                Packet packetRequest) => throw new NYI();

    /// <summary>
    /// Return a provider for protocol <paramref name="protocol"/>. If multiple
    /// providers are specified, return the instance <paramref name="instance"/>
    /// </summary>
    /// <param name="protocol">The protocol identifier.</param>
    /// <param name="instance">The service instance.</param>
    /// <returns>Provider interface for the specified service.</returns>
    public JpcInterface GetService(string protocol, string instance = null) {
        foreach (var provider in Providers) {
            if (provider.JpcInterface.GetWellKnown == protocol) {
                return provider.JpcInterface;
                }
            }
        return null;
        }

    #endregion


    }
