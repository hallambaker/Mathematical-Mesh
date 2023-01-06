//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Utilities;

using Goedel.Protocol;

using System;
using System.Collections.Generic;
using System.Net;
using Goedel.Mesh;

namespace Goedel.Presence;


public abstract partial class PresenceProtocol {

    static PresenceProtocol() {
        _Initialize();
        }


    }


public partial class PresenceFromClient : Request {

    #region // Properties

    ///<summary>The source endpoint address.</summary> 
    public IPEndPoint SourceEndPoint { get; set; }


    #endregion 

    #region // Destructor
    #endregion 

    #region // Constructors
    #endregion 

    #region // Implement Interface: Ixxx
    #endregion 

    #region // Methods 

    /// <summary>
    /// Convert the message to bytes.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public byte[] ToBytes(byte[] token) {
        var result = new byte[1024];
        //Array.Copy (token, result, token.Length);


        var stream = new MemoryStream (result);
        var writer = new JsonBWriter(stream);

        // Write the initial token to the stream
        stream.Write (token, 0, token.Length);

        Serialize(writer, true);


        return result;
        }

    /// <summary>
    /// Parse decrypted message bytes.
    /// </summary>
    /// <returns>The parsed message.</returns>
    public static PresenceFromClient FromBytes(byte[] data, int offset) {
        var stream = new MemoryStream (data, offset, data.Length-offset);
        var reader = new JsonBcdReader(stream);

        var result = PresenceFromClient.FromJson (reader, true);
        return result;
        }


    #endregion 
    }

public partial class PresenceFromService : Response {

    #region // Properties

    ///<summary>The UDP endpoing to which the message is to be sent.</summary> 
    public IPEndPoint Destination { get; set; }

    ///<summary>The packets encoding this message.</summary> 
    public List<byte[]> Packets { get; set; }
    #endregion

    #region // Destructor
    #endregion

    #region // Constructors
    #endregion

    #region // Implement Interface: Ixxx
    #endregion

    #region // Methods 

    /// <summary>
    /// Convert the message to plaintext bytes.
    /// </summary>
    /// <returns></returns>
    public List<byte[]> ToBytes() {

        //Array.Copy (token, result, token.Length);


        var stream = new MemoryStream();
        var writer = new JsonBWriter(stream);

        // Write the initial token to the stream
        Serialize(writer, true);


        if (stream.Length > 1024) {
            throw new NYI();
            // To Do: support for multiple packets from service to client.
            }
        var result = new List<byte[]>();
        var buffer = stream.GetBuffer();

        var packet = new byte[1024];
        Array.Copy(buffer, packet, stream.Length);
        result.Add(packet);

        return result;
        }

    /// <summary>
    /// Parse decrypted message bytes.
    /// </summary>
    /// <returns>The parsed message.</returns>
    public static PresenceFromService FromBytes(byte[] data, int offset) {


        var stream = new MemoryStream(data, offset, data.Length - offset);
        var reader = new JsonBcdReader(stream);

        var result = PresenceFromService.FromJson(reader, true);
        return result;
        }

    #endregion 
    }



public partial class UdpEndpoint {

    /// <summary>
    /// Default constructor used for serialization.
    /// </summary>
    public UdpEndpoint() {
        }

    /// <summary>
    /// Constructor returning a new instance for the endpoing <paramref name="endPoint"/>
    /// </summary>
    /// <param name="endPoint">The IP endpoint.</param>
    public UdpEndpoint(IPEndPoint endPoint) {
        IpAddress = endPoint.Address.GetAddressBytes();
        Port = endPoint.Port;


        }


    }
