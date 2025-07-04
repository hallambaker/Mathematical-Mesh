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

namespace Goedel.Mesh.Test;


public class TestContext {


    public string WorkingDirectory { get; }

    public string Instance { get; }


    public IDnsPublisher dnsPublisher { get; }
    public DnsClient DnsClient { get;}


    public EarlDispatch EarlPublisher { get; }
    public EarlClient EarlClient { get;}





    public DeviceConnectClient DeviceConnectClient { get;}


    public DeviceConnectServer DeviceConnectServer { get; }




    public TestContext(string instance,
        string domain = "example.com",
                    bool dns=true, bool earl=true, bool device=true) {
        Instance = instance;


        if (dns) {
            var dummyDns = new DummyDnsService();
            DnsClient = dummyDns.DnsClient;
            dnsPublisher = dummyDns;
            }
        else {
            DnsClient = new DnsClientUDP();
            }

        if (earl) {
            EarlPublisher = new EarlDispatchCached(domain, instance);
            EarlClient = new EarlClientDirect(EarlPublisher, DnsClient);
            }
        else {
            EarlClient = new EarlClientHttp(DnsClient, instance);
            }

        if (device) {
            DeviceConnectServer = new(Instance);
            DeviceConnectClient = new(DeviceConnectServer);
            }
        else {
            throw new NYI();
            }



        }



    }



