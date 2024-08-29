
namespace Goedel.Cryptography.Nist;

public enum PrimeGenModes {
    [EnumMember(Value = "invalid")]
    Invalid,

    [EnumMember(Value = "provable")]
    RandomProvablePrimes,

    [EnumMember(Value = "probable")]
    RandomProbablePrimes,

    [EnumMember(Value = "provableWithProvableAux")]
    RandomProvablePrimesWithAuxiliaryProvablePrimes,

    [EnumMember(Value = "probableWithProvableAux")]
    RandomProbablePrimesWithAuxiliaryProvablePrimes,

    [EnumMember(Value = "probableWithProbableAux")]
    RandomProbablePrimesWithAuxiliaryProbablePrimes
    }

