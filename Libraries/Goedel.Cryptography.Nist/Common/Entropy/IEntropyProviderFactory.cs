namespace Goedel.Cryptography.Nist;
/// <summary>
/// Interface for retrieving a <see cref="IEntropyProvider"/> based on use case.
/// </summary>
public interface IEntropyProviderFactory {
        /// <summary>
        /// Gets an <see cref="IEntropyProvider"/>
        /// </summary>
        /// <param name="providerType">The type of provider to retrieve</param>
        /// <returns></returns>
        IEntropyProvider GetEntropyProvider(EntropyProviderTypes providerType);
        }
    
