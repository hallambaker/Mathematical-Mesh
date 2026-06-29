using Goedel.Protocol;

using System.Net;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Contacts;




public partial class JsDevice {

    /// <summary>Return the first network entry for a network of type <paramref name="type"/></summary>
    /// <param name="type">The network to return.</param>
    /// <returns>The network value, if found.</returns>
    public Network? GetNetworkType(string type) {
        foreach (var network in Services.IfEnumerable()) {
            if (network.Value.Identifier == type) {
                return network.Value;
                }
            }

        return null;
        }

    }
