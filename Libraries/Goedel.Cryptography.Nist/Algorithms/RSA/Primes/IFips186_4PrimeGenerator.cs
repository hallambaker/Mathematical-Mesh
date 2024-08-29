
namespace Goedel.Cryptography.Nist;

public interface IFips186_4PrimeGenerator : IPrimeGenerator {
        PrimeGeneratorResult GeneratePrimesFips186_4(PrimeGeneratorParameters param);
        }
    
