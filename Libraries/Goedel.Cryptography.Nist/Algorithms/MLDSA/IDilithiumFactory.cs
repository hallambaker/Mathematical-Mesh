
namespace Goedel.Cryptography.Nist;


public interface IDilithiumFactory {
    IMLDSA GetDilithium(DilithiumParameterSet parameterSet);
    }
