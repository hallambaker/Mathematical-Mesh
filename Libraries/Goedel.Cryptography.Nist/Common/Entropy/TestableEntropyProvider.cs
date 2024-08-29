﻿namespace Goedel.Cryptography.Nist;
public class TestableEntropyProvider : IEntropyProvider {
    private readonly bool _throwWhenRequestingMoreBitsThanAvailable;
    private readonly List<BitString> _entropyBitStrings = new List<BitString>();
    private readonly List<BigInteger> _entropyBigIntegers = new List<BigInteger>();

    public TestableEntropyProvider() {
        _throwWhenRequestingMoreBitsThanAvailable = true;
        }

    public TestableEntropyProvider(bool throwWhenRequestingMoreBitsThanAvailable) {
        _throwWhenRequestingMoreBitsThanAvailable = throwWhenRequestingMoreBitsThanAvailable;
        }

    public void AddEntropy(BitString entropy) {
        _entropyBitStrings.Add(entropy);
        }

    public void AddEntropy(BigInteger entropy) {
        _entropyBigIntegers.Add(entropy);
        }

    public BitString GetEntropy(int numberOfBits) {
        if (_entropyBitStrings.Count == 0) {
            throw new Exception("No Entropy exists within provider");
            }

        if (_throwWhenRequestingMoreBitsThanAvailable && numberOfBits > _entropyBitStrings[0].BitLength) {
            throw new ArgumentException($"{nameof(numberOfBits)} ({numberOfBits}) requested does not meet the number of bits in {nameof(_entropyBitStrings)} ({_entropyBitStrings[0].BitLength})");
            }

        var entropy = _entropyBitStrings[0];
        _entropyBitStrings.RemoveAt(0);

        return entropy;
        }

    public BigInteger GetEntropy(BigInteger minInclusive, BigInteger maxInclusive) {
        if (_entropyBigIntegers.Count == 0) {
            throw new Exception("No Entropy exists within provider");
            }

        if (_entropyBigIntegers[0] < minInclusive) {
            throw new ArgumentException($"Value {nameof(_entropyBigIntegers)} is less than {nameof(minInclusive)}");
            }

        if (_entropyBigIntegers[0] > maxInclusive) {
            throw new ArgumentException($"Value {nameof(_entropyBigIntegers)} is greater than {nameof(maxInclusive)}");
            }

        var entropy = _entropyBigIntegers[0];
        _entropyBigIntegers.RemoveAt(0);

        return entropy;
        }
    }

