using Goedel.Cryptography.PKIX;

namespace Goedel.Anything;


/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Helper {



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
