
namespace Goedel.Cryptography.Nist;


public class DilithiumFactory : IDilithiumFactory {
    private readonly IShaFactory _shaFactory;
    private readonly IEntropyProvider _entropyProvider;

    public DilithiumFactory(IShaFactory shaFactory, IEntropyProvider entropyProvider) {
        _shaFactory = shaFactory;
        _entropyProvider = entropyProvider;
        }

    public IMLDSA GetDilithium(DilithiumParameterSet parameterSet) {
        return new Dilithium(new DilithiumParameters(parameterSet), _shaFactory, _entropyProvider);
        }
    }
