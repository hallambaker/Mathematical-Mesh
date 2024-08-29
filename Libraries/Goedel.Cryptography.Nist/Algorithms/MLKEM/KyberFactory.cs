
namespace Goedel.Cryptography.Nist;


public class KyberFactory {
    private readonly IShaFactory _shaFactory;

    public KyberFactory(IShaFactory shaFactory) {
        _shaFactory = shaFactory;
        }

    public IMLKEM GetKyber(KyberParameterSet parameterSet) {
        var param = new KyberParameters(parameterSet);
        return new MLKEMInternal(param, _shaFactory);
        }
    }
