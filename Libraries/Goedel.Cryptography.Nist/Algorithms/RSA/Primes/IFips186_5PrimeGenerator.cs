
namespace Goedel.Cryptography.Nist;

public interface IFips186_5PrimeGenerator : IPrimeGenerator {
        PrimeGeneratorResult GeneratePrimesFips186_5(PrimeGeneratorParameters param);
        }
    
