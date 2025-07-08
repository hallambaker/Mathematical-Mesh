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



public record TestServiceStubs (
                    string Domain = "example.com",
                    bool Dns = true,
                    bool Earl = true,
                    bool Device = true
            ) {

    }

public class MeshTestSetSerialized : MeshTestSet {
    public virtual TestEnvironmentBase GetTestEnvironment() =>
            new TestEnvironmentCommon(this) {
                JpcConnection = Protocol.JpcConnection.Serialized
                };
    }

public class MeshTestSet : UnitTestSet {

    public static TestServiceStubs TestServiceStubsDefault = new();

    public TestServiceStubs TestServiceStubs { get; }
    public string WorkingDirectory { get; }

    public string Instance => Seed.Seed;


    public string DirectoryPath => Seed.Directory;


    public IDnsPublisher DnsPublisher { get; }
    public DnsClient DnsClient { get;}


    public EarlDispatch EarlPublisher { get {
            if (earlPublisher != null) {
                return earlPublisher;
                }
            GetEarl();
            return earlPublisher;
            }
        }
    EarlDispatch earlPublisher;
    public EarlClient EarlClient {
        get {
            if (earlClient != null) {
                return earlClient;
                }
            GetEarl();
            return earlClient;
            }
        }
    EarlClient earlClient;


    public DeviceConnectClient DeviceConnectClient {
        get {
            if (deviceConnectClient != null) {
                return deviceConnectClient;
                }
            GetDevice();
            return deviceConnectClient;
            }
        }
    DeviceConnectClient deviceConnectClient;
    public DeviceConnectServer DeviceConnectServer {
        get {
            if (deviceConnectServer != null) {
                return deviceConnectServer;
                }
            GetDevice();
            return deviceConnectServer;
            }
        }
    DeviceConnectServer deviceConnectServer;

    protected override void Disposing() {
        testEnvironment?.Dispose();
        testEnvironment = null;
        base.Disposing();
        }


    public MeshTestSet(
                    TestServiceStubs testServiceStubs= null) {
        TestServiceStubs = testServiceStubs ?? TestServiceStubsDefault;



        if (TestServiceStubs.Dns) {
            var dummyDns = new DummyDnsService();
            DnsClient = dummyDns.DnsClient;
            DnsPublisher = dummyDns;
            InitializeDNS(dummyDns);
            }
        else {
            DnsClient = new DnsClientUDP();
            }

        }



    void GetEarl() {
        if (TestServiceStubs.Earl) {
            earlPublisher = new EarlDispatchCached(TestServiceStubs.Domain, Instance);
            earlClient = new EarlClientDirect(earlPublisher, DnsClient);
            }
        else {
            earlClient = new EarlClientHttp(DnsClient, Instance);
            }

        }

    void GetDevice() {
        if (TestServiceStubs.Device) {
            deviceConnectServer = new(Instance);
            deviceConnectClient = new(deviceConnectServer);
            }
        else {
            throw new NYI();
            }

        }


    public TestEnvironmentBase TestEnvironment => testEnvironment ??
                GetTestEnvironment().CacheValue(out testEnvironment);
    TestEnvironmentBase testEnvironment;


    public virtual TestEnvironmentBase GetTestEnvironment() =>
                new TestEnvironmentCommon(this);


    public override void StartTest(params object[] parameters) {
        Seed = DeterministicSeed.AutoClean(parameters);
        testEnvironment = GetTestEnvironment();
        }

    protected override void EndTest() {
        testEnvironment?.Dispose();
        testEnvironment = null;
        }


    public void InitializeDNS(DummyDnsService dummyDns) {

        var records = new List<DNSRecord>() {

            new DNSRecord_A() {
                Domain = new ("example.com"),
                Address = IPAddress.Parse("127.0.0.1")
                },
            new DNSRecord_A() {
                Domain = new ("mmm.example.com"),
                Address = IPAddress.Parse("127.0.0.1")
                },
            new DNSRecord_A() {
                Domain = new ("host1.example.com"),
                Address = IPAddress.Parse("127.0.0.1")
                },
            new DNSRecord_SRV() {
                Domain = new ("_mmm._tcp.example.com"),
                Priority = 1,
                Weight = 1,
                Port = 15099,
                Target = new ("host1.example.com")
                }
            };

        ushort Truncate(int value) => (ushort)value;

        dummyDns.PublishRecords(records);
        }

    }



