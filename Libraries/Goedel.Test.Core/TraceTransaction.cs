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

namespace Goedel.Test.Core;

public class TraceTransaction {

    public byte[] Request;
    public byte[] Response;
    public Response ResponseObject;
    public Goedel.Protocol.Request RequestObject;

    public string XMLRequest => GetRequest();
    public string XMLResponse => GetResponse();

    public string GetRequest() => RequestText;
    public string GetResponse() => ResponseText;

    public string RequestText;
    public string ResponseText;

    public List<Packet> RequestPackets;
    public List<Packet> ResponsePackets;

    public TraceTransaction(byte[] request, byte[] response, JpcInterface service) {
        Request = request;
        Response = response;
        RequestText = Request.ToUTF8();
        ResponseText = Response.ToUTF8();

        //JsonReader.Trace = true;

        var jsonReader = Request.JsonReader();
        jsonReader.StartObject();
        string token = jsonReader.ReadToken();
        service.GetTagDictionary().TryGetValue(token, out var factory);
        var requestObject = factory();
        requestObject.Deserialize(jsonReader);

        RequestObject = requestObject as Request;
        ResponseObject = Goedel.Protocol.Response.FromJson(Response.JsonReader(), true);
        }




    }
