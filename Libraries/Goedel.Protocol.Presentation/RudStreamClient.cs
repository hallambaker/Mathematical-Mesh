﻿#region // Copyright - MIT License
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


namespace Goedel.Protocol.Presentation;

/// <summary>
/// The client side of an RDP transactional stream.
/// </summary>
public class RudStreamClient : RudStream, IJpcSession {
    #region // Properties

    ///<inheritdoc/>
    public virtual string TargetAccount => throw new NYI();

    SemaphoreSlim SemaphoreSlim { get; } = new(1, 1);

    #endregion
    #region // Constructors

    /// <summary>
    /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
    /// protocol <paramref name="protocol"/> 
    /// </summary>
    /// <param name="parent">The parent stream</param>
    /// <param name="protocol">The stream protocol</param>
    /// <param name="credentialSelf">Optional additional credential for self.</param>
    /// <param name="credentialOther">Optional additional credential for other.</param>
    /// <param name="rudConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>

    public RudStreamClient(
            RudStream parent,
            string protocol,
             ICredentialPrivate credentialSelf = null,
            ICredentialPublic credentialOther = null,
            RudConnection rudConnection = null) : base(
                parent, protocol, credentialSelf, credentialOther, rudConnection) {
        }

    #endregion
    #region // Methods

    async Task<bool> Initialize() {
        if (RudConnection is ConnectionInitiator initiator) {
            var serviceDescription = await DnsClient.ResolveServiceAsync(initiator.Domain, Protocol, port: 15099);
            Uri = serviceDescription.GetUri(initiator.Instance);
            }
        Initialized = true;

        return true;
        }

    /// <summary>
    /// Post the transaction <paramref name="tag"/> with data <paramref name="request"/>
    /// to the stream and await the response.
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public JsonObject Post(string tag, JsonObject request) {
        var task = base.PostAsync(tag, request);
        task.Wait();
        return task.Result;
        }

    ///<inheritdoc/>
    public override async Task<JsonObject> PostAsync(string tag, JsonObject request) {
        if (!Initialized) {
            await Initialize();
            }

        await SemaphoreSlim.WaitAsync();

        // We only have one outstanding 
        try {
            return await base.PostAsync(tag, request);
            }
        finally {
            SemaphoreSlim.Release();
            }
        }

    ///<inheritdoc cref="IJpcSession"/>
    public IJpcSession Rebind(ICredential credential) {
        return MakeStreamClient(Protocol, credential as ICredentialPrivate);
        }


    #endregion
    }
