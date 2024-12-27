namespace Goedel.Cryptography.Nist;
/// <summary>
/// Thrown when a <see cref="BitString"/> as hex cannot be parsed due to invalid length.
/// </summary>
public class InvalidBitStringLengthException : Exception {

    /// <summary>
    /// Constructor, return an instance for <paramref name="message"/>
    /// </summary>
    /// <param name="message">The message to display</param>
    public InvalidBitStringLengthException(string message)
        : base(message) {

        }
    }

