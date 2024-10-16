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


namespace Goedel.Protocol;

/// <summary>
/// Base class for all JPC server classes.
/// </summary>
public abstract class JpcInterface : Disposable {

    /////<summary>List of DNS domains serviced by this interface.</summary> 
    //public List<string> Domains { get; set; }

    /// <summary>
    /// The WellKnown service name for HTTP and DNS prefix use.
    /// </summary>
    public abstract string GetWellKnown {
        get;
        }

    /// <summary>
    /// The WellKnown service name for HTTP and DNS prefix use.
    /// </summary>
    public abstract string GetDiscovery {
        get;
        }

    /// <summary>
    /// Dispatch Class. Reads input from the provided reader and attempts to
    /// dispatch a method in response. Note that the calling routine may throw 
    /// an error. This must be caught and processed by the host dispatch class.
    /// </summary>
    /// <param name="Session">The service session that is to handle the request.</param>
    /// <param name="jsonReader">The input stream to be read</param>
    /// <returns>The response to the request.</returns>
    public abstract Goedel.Protocol.JsonObject Dispatch(IJpcSession Session,
        JsonReader jsonReader);


    /// <summary>
    /// Parse the input stream <paramref name="jsonReader"/> and return the token 
    /// identifying the method and the parsed request data.
    /// </summary>
    /// <param name="jsonReader">The input stream to be read</param>
    /// <returns>The parsed request.</returns>
    /// <exception cref="UnknownOperation">Thrown if am unknown operation is attempted.</exception>
    public (string, JsonObject) GetRequest(
            JsonReader jsonReader) {

        jsonReader.StartObject();
        string token = jsonReader.ReadToken();

        if (!GetTagDictionary().TryGetValue(token, out var factory)) {
            throw new UnknownOperation();
            }

        var request = factory();
        request.Deserialize(jsonReader);

        return (token, request);
        }




    /// <summary>
    /// Return a client tapping the service API directly without serialization bound to
    /// the session <paramref name="jpcSession"/>. This is intended for use in testing etc.
    /// </summary>
    /// <param name="jpcSession">Session to which requests are to be bound.</param>
    /// <returns>The direct client instance.</returns>
    public abstract Goedel.Protocol.JpcClientInterface GetDirect(IJpcSession jpcSession);

    ///// <summary>
    ///// Return a JpcSession for the service.
    ///// </summary>
    ///// <returns></returns>
    //public abstract IJpcSession GetSession();

    ///<summary>Tag dictionary mapping operation tags to requests.</summary> 
    public abstract Dictionary<string, JsonFactoryDelegate> GetTagDictionary();
    }

/// <summary>
/// Base class for all JPC client classes.
/// </summary>
public abstract class JpcClientInterface {

    /// <summary>
    /// The WellKnown service name for HTTP and DNS prefix use.
    /// </summary>
    public abstract string GetWellKnown {
        get;
        }

    /// <summary>
    /// The WellKnown service name for HTTP and DNS prefix use.
    /// </summary>
    public abstract string GetDiscovery {
        get;
        }





    /// <summary>
    /// The active JpcSession.
    /// </summary>		
    public virtual IJpcSession JpcSession { get; set; }


    ///<inheritdoc cref="IJpcSession"/>
    public virtual void Rebind(ICredential credential) =>
        JpcSession = JpcSession.Rebind(credential);

    }

