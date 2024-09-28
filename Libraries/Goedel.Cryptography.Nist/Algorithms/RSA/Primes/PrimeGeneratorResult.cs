
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Prime generator result.
/// </summary>
/// <param name="Primes">The prime pair</param>
/// <param name="AuxValues">The auxillary values.</param>
public record PrimeGeneratorResult (
            PrimePair Primes,
            AuxiliaryResult AuxValues
            ) {

    }

