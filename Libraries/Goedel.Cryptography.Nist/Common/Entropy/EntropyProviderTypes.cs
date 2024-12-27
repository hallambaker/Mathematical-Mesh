namespace Goedel.Cryptography.Nist;

/// <summary>
/// The supported entropy providers.
/// </summary>
public enum EntropyProviderTypes {
    /// <summary>
    /// Allows for the setting/injection of specific entropy for testing purposes
    /// </summary>
    Testable,
    /// <summary>
    /// Uses a Random number generator for entropy retrieval.
    /// </summary>
    Random
    }

