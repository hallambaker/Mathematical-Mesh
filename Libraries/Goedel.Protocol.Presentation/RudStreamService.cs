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


//using Goedel.Protocol.Service;

#pragma warning disable CS1998

namespace Goedel.Protocol.Presentation;

/// <summary>
/// RUD service stream, exposes transaction dispatch methods.
/// </summary>
public class RudStreamService : RudStream, IJpcSession {

    ///<summary>The service instance.</summary> 
    public JpcInterface JpcInterface;


    ///<inheritdoc/>
    public string TargetAccount => Credential.Account;

    #region // Constructors

    /// <summary>
    /// Initialize a new stream instance as a child of <paramref name="parent"/> to support
    /// protocol <paramref name="protocol"/> 
    /// </summary>
    /// <param name="parent">The parent stream</param>
    /// <param name="protocol">The stream protocol</param>
    /// <param name="instance">The service instance</param>
    /// <param name="credentialSelf">Optional additional credential for self.</param>
    /// <param name="credentialOther">Optional additional credential for other.</param>
    /// <param name="accountAddress">Account address asserted</param>
    /// <param name="rudConnection">The parent connection (if specified, overrides <paramref name="parent"/></param>

    public RudStreamService(
            RudStream parent,
            string protocol,
            string instance = null,
            ICredentialPrivate credentialSelf = null,
            ICredentialPublic credentialOther = null,
            string accountAddress = null,
            RudConnection rudConnection = null) : base(
                parent, protocol, credentialSelf, credentialOther, rudConnection, accountAddress) {

        JpcInterface = RudConnection?.Listener.GetService(protocol, instance);
        //TargetAccount = CredentialOther.Account;

        }

    #endregion


    #region // Methods
    ///<inheritdoc cref="IJpcSession"/>
    public IJpcSession Rebind(ICredential credential) {
        return MakeStreamClient(Protocol, credential as ICredentialPrivate);
        }

    /// <summary>
    /// Wait to receive a request datagram on the stream.
    /// </summary>
    /// <returns>The task created.</returns>
    public async Task<DataGram> AsyncRequestDatagram() => throw new NYI();

    /// <summary>
    /// Wait to receive a parsed request object on the stream.
    /// </summary>
    /// <returns></returns>
    public async Task<JsonObject> AsyncRequestObject() => throw new NYI();

    /// <summary>
    /// Post the request <paramref name="tag"/> with data <paramref name="request"/> to
    /// the service bound to the stream.
    /// </summary>
    /// <param name="tag">Transaction name.</param>
    /// <param name="request">Transaction data</param>
    /// <returns>Result of posting data to the stream.</returns>
    public JsonObject Post(string tag, JsonObject request) => throw new System.NotImplementedException();

    /// <summary>
    /// Send the response datagram <paramref name="dataGram"/>
    /// </summary>
    /// <param name="dataGram">The datagram to send.</param>
    public void Respond(DataGram dataGram) => throw new NYI();

    /// <summary>
    /// Send the response object <paramref name="jsonObject"/>
    /// </summary>
    /// <param name="jsonObject">The object to send</param>
    public void Respond(JsonObject jsonObject) => throw new NYI();

    ///<inheritdoc/>
    public Task<JsonObject> PostAsync(string tag, JsonObject request) {
        throw new NotImplementedException();
        }
    #endregion
    }
