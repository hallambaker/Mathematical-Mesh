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

using Goedel.Discovery;

using Xunit;

namespace Goedel.Mesh.Test;




public class DummyDnsService : IDnsPublisher {


    public Dictionary<string, DnsNode> DictionaryData { get;} = [];


    public DummyDnsService() {
        DnsClient.Default = new DummyDnsClient(this);
        }


    public void PublishRecords(
                IEnumerable<DNSItem> records) {
        foreach (DNSRecord record in records) {
            PublishRecord(record);
            }
        }

    public void PublishRecord(
                        DNSItem item) {




        if (item is DNSRecord record) {
            if (!DictionaryData.TryGetValue(item.Domain.Name, out var node)) {
                node = new DnsNode(item.Domain.Name);
                DictionaryData.Add(item.Domain.Name, node);
                }
            node.Add(record);
            }
        }


    public List<DNSRecord>? Query(
            DNSRequest request)=>
                DictionaryData.TryGetValue(request.Query.QName, out var dnsNode) ? 
                    dnsNode.Query(request) : null;

    }

public record DnsNode(string Domain) {


    public Dictionary<DNSTypeCode, List<DNSRecord>> DictionaryRecords { get; } = [];


    public void Erase(DNSTypeCode typeCode) =>
            DictionaryRecords.Remove(typeCode);
    
    public void Add(DNSRecord record) {
        if (!DictionaryRecords.TryGetValue(record.Code, out var records)) {
            records = [];
            DictionaryRecords.Add(record.Code, records);
            }
        records.Add(record);

        }

    public List<DNSRecord>? Query(
        DNSRequest request) =>
            DictionaryRecords.TryGetValue(request.Query.QType, out var records) ?
                records : null;






    }

public class DummyDnsClient : DnsClient {

    DummyDnsService DnsService { get; }

    public DummyDnsClient(
                    DummyDnsService service) {
        DnsService = service;
        }


    public override DNSContext GetContext() => new DummyDnsContext(DnsService);






    }


public class DummyDnsContext : DNSContext {
    DummyDnsService DnsService { get; }
    DNSRequest DNSRequest { get; set; }



    public DummyDnsContext(
                DummyDnsService service) {
        DnsService = service;
        }


    public override Task<DNSResponse> PublishRecords(
                            IEnumerable<DNSRecord> records) {
        DnsService.PublishRecords(records);


        var response = new DNSResponse();
        return Task.FromResult (response);
        }

    public override Task<DNSResponse> GetResponseAsync() {
        var records = DnsService.Query(DNSRequest);

        var response = new DNSResponse() {
            Answers = records is null ? [] : [.. records]
            };

        return Task.FromResult(response);
        }

    public override Task<byte[]> GetResponseRawAsync() {
        throw new NotImplementedException();
        }

    public override void SendRequest(DNSRequest request, int index = 0) {
        DNSRequest = request;
        }


    public override Task<IEnumerable<DNSRecord>> QueryRecord(
            string address,
            DNSTypeCode typeCode = DNSTypeCode.TXT) {


        throw new NYI();
        }



    }


//public class DummyDNSResponse : DNSResponse {
//    }