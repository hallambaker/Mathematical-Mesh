using Goedel.Cryptography;

namespace Goedel.Contacts;

//public partial class JWK {
//    }




public partial class JsProvision {

    /// <summary>Constructor, returns an empty instance.</summary>
    public JsProvision() { 
        }

    /// <summary>Constructor returning a provisioning statement using the device template 
    /// <paramref name="jsDevice"/>.</summary>
    /// <param name="jsDevice">Template describing the common features of the device to be provisioned.</param>
    public JsProvision(JsDevice jsDevice) {
        JsDevice = jsDevice;
        PrivateKeys = [];
        }

    /// <summary>Add a physical ethernet connection with MAC <paramref name="mac"/></summary>
    /// <param name="mac">The MAC address to add</param>
    /// <returns>The entry identifier.</returns>
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

    /// <summary>Add a physical Wifi connection with SSID <paramref name="ssid"/> and
    /// MAC <paramref name="mac"/></summary>
    /// <param name="ssid">The SSID the device will listen on.</param>
    /// <param name="mac">The MAC address to add</param>
    /// <returns>The entry identifier.</returns>
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

    /// <summary>Add an onboarding protocol.</summary>
    /// <param name="service">The service name.</param>
    /// <param name="endpoints">The endpoint.</param>
    /// <param name="keypair">The keypair</param>
    /// <param name="credential">The credential</param>
    /// <param name="contentType">Content type for the onboarding entry.</param>
    /// <returns>The entry identifier.</returns>
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



    }
