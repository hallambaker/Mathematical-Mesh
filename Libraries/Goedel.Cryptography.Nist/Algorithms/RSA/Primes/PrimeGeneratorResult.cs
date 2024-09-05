
namespace Goedel.Cryptography.Nist;

public class PrimeGeneratorResult {
    public PrimePair Primes { get; }
    public AuxiliaryResult AuxValues { get; }
    public string ErrorMessage { get; }


    public PrimeGeneratorResult(PrimePair primes, AuxiliaryResult aux) {
        Primes = primes;
        AuxValues = aux;
        }

    public PrimeGeneratorResult(string error) {
        ErrorMessage = error;
        }
    }

