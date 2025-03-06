using Goedel.Cryptography.PKIX;

namespace Goedel.Anything;


/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Helper {


    /// <summary>
    /// Return the DER encoding of the names <paramref name="dnsNames"/>
    /// </summary>
    /// <param name="dnsNames">List of DNS names to encode.</param>
    /// <returns>The DER encoding.</returns>
    public static byte[] GetSubjectAltNameDer(
                IEnumerable<string> dnsNames) {

        var subjectAltName = new SubjectAltName(dnsNames);

        var result = subjectAltName.DER();
        return result;
        }



    }


/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {




    }
