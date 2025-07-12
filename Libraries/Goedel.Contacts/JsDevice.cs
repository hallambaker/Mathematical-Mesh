using Goedel.Cryptography;
using Goedel.Protocol;

using System.Net;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Contacts;


//public partial class JWK {
//    }




public partial class JsProvision {


    public JsProvision() { 
        }

    public JsProvision(JsDevice jsDevice) {
        JsDevice = jsDevice;
        PrivateKeys = [];
        }

    public string AddPhysicalEthernet(string? mac = null) {
        var id = Udf.Nonce();
        var network = new NetworkEthernet() {
            Kind = ContactConstant.KindInternet,
            Identifier = ContactConstant.PhysicalEthernet,
            EUI = mac
            };


        JsDevice.Network ??= [];
        JsDevice.Network.Add(id, network);


        return id;
        }

    public string AddPhysicalWiFi(string ssid, string? mac = null) {
        var id = Udf.Nonce();
        var network = new NetworkWiFi() {
            Kind = ContactConstant.KindInternet,
            Identifier = ContactConstant.PhysicalWiFi,
            EUI = mac,
            SSID = ssid
            };

        if (mac != null) {
            network.Endpoints = [mac];
            }

        JsDevice.Network ??= [];
        JsDevice.Network.Add(id, network);


        return id;
        }


    public string AddOnboarding(
                    string service,
                    List<string> endpoints,
                    JWK keypair,
                    byte[] credential,
                    string contentType
                    ) {
        var id = AddCredential (keypair, credential, contentType);
        var id2 = Udf.Nonce();

        JsDevice.Services ??= [];
        var network = new Network() {
            Kind = ContactConstant.KindOnboarding,
            Identifier = ContactConstant.OnlineServiceOnboard,
            Endpoints = endpoints,
            Keys = new Dictionary<string, string>() {
                    { id, ContactConstant.CryptoKeySeed}
                }
            };

        JsDevice.Services.Add(id2, network);

        return id;
        }

    /// <summary>
    /// Add credentials to support onboarding via MeshOnboard
    /// </summary>
    public string AddCredential (
                    JWK keypair,
                    byte[] credential,
                    string contentType
                    ) {
        var id = Udf.Nonce();


        JsDevice.CryptoKeys ??= [];
        PrivateKeys ??= [];

        var publicKey = new JsonWebKeySet () {
            Data = credential,
            MediaType = contentType
            };

        //var keypair1 = keypair.GetKeyPair(KeySecurity.Exportable);
        var privateKey = new JsonWebKeySet() {
            MediaType = contentType,
            JsonWebKeys = [keypair]
            };

        JsDevice.CryptoKeys.Add(id, publicKey);
        PrivateKeys.Add(id, privateKey);

        return id;
        }




    //public Network? GetNetworkType(string type) {
    //    foreach (var network in JsDevice.Services.IfEnumerable()) {
    //        if (network.Value.Identifier == type) {
    //            return network.Value;
    //            }
    //        }

    //    return null;
    //    }
    }




public partial class JsDevice {


    public Network? GetNetworkType(string type) {
        foreach (var network in Services.IfEnumerable()) {
            if (network.Value.Identifier == type) {
                return network.Value;
                }
            }

        return null;
        }

    }
