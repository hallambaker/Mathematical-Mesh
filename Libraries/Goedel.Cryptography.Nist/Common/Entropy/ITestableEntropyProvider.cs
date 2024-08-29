namespace Goedel.Cryptography.Nist;
/// <summary>
/// Allows for adding specific entropy to a provider
/// </summary>
public interface ITestableEntropyProvider {
        /// <summary>
        /// Add entropy
        /// </summary>
        /// <param name="entropy">The <see cref="BitString"/> to add</param>
        void AddEntropy(BitString entropy);

        void AddEntropy(BigInteger entropy);
        }
    
