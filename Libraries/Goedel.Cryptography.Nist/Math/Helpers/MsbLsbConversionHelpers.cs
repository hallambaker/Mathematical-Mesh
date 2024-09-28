
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Conversion helpers for big vs little endian.
/// </summary>
public static class MsbLsbConversionHelpers {

    /// <summary>
    /// Create a new array of bytes in the reverse order to <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">The input array.</param>
    /// <returns>The input array bytes in reverse order.</returns>
    public static byte[] ReverseByteOrder(byte[] bytes)=>
                bytes.Reverse().ToArray();

    /// <summary>
    /// Create a new array of bits in the reverse order to <paramref name="array"/>.
    /// </summary>
    /// <param name="array">The input array.</param>
    /// <returns>The input array bits in reverse order.</returns>
    public static BitArray ReverseBitArrayBits(BitArray array) {
        BitArray copy = new BitArray(array);

        int length = copy.Length;
        int mid = (length / 2);

        for (int i = 0; i < mid; i++) {
            bool bit = copy[i];
            copy[i] = copy[length - i - 1];
            copy[length - i - 1] = bit;
            }

        return copy;
        }

    /// <summary>
    /// Convert the MSB array <paramref name="msBytes"/> a binary array in LSB order.
    /// </summary>
    /// <param name="msBytes">The MSB array.</param>
    /// <returns>The bit array.</returns>
    public static BitArray MostSignificantByteArrayToLeastSignificantBitArray(byte[] msBytes) {
        // Get the LSB of the MSB byte array, so both bits and bytes are LS
        var leastSignificantByteArray = ReverseByteOrder(msBytes);

        // Create a BitArray with the Least Signficiant Byte array
        return new BitArray(leastSignificantByteArray);
        }

    /// <summary>
    /// Convert the MSB array <paramref name="msBytes"/> a binary array in MSB order.
    /// </summary>
    /// <param name="msBytes">The MSB array.</param>
    /// <returns>The bit array.</returns>
    public static BitArray MostSignificantByteArrayToMostSignificantBitArray(byte[] msBytes) {
        // Get the most significant byte array as a least significant bit array
        var leastSignificantBitArray = MostSignificantByteArrayToLeastSignificantBitArray(msBytes);

        // switch the bits for a most significant bit array
        return ReverseBitArrayBits(leastSignificantBitArray);
        }

    /// <summary>
    /// Convert the LSB array <paramref name="msBytes"/> a binary array in LSB order.
    /// </summary>
    /// <param name="lsBytes">The MSB array.</param>
    /// <returns>The bit array.</returns>
    public static BitArray LeastSignificantByteArrayToLeastSignificantBitArray(byte[] lsBytes) {
        return new BitArray(lsBytes);
        }

    /// <summary>
    /// Convert the LSB array <paramref name="msBytes"/> a binary array in MSB order.
    /// </summary>
    /// <param name="lsBytes">The MSB array.</param>
    /// <returns>The bit array.</returns>
    public static BitArray LeastSignificantByteArrayToMostSignificantBitArray(byte[] lsBytes) {
        var lsBitArray = new BitArray(lsBytes);

        // the reverse of the LSb BitArray is a MSb BitArray
        return ReverseBitArrayBits(lsBitArray);
        }

    /// <summary>
    /// Gets a <see cref="BitArray"/> from a string of 1s and 0s.  The first bit in the string is the least significant.
    ///
    /// <example>
    ///     "1000000" -> [true, false, false, false, false, false, false, false] -> 1
    ///     "0000001" -> [false, false, false, false, false, false, false, true] -> 128
    /// </example>
    /// 
    /// </summary>
    /// <param name="onesAndZeroes">The string to get a <see cref="BitArray"/> from.</param>
    /// <returns><see cref="BitArray"/> representation of string where the first bit in the input string is the least significant.</returns>
    /// <exception cref="ArgumentNullException">When input string is null.</exception>
    /// <exception cref="ArgumentException">When input string has invalid characters.</exception>
    public static BitArray GetBitArrayFromStringOf1sAnd0s(string onesAndZeroes) {
        if (string.IsNullOrEmpty(onesAndZeroes)) {
            throw new ArgumentNullException(nameof(onesAndZeroes));
            }

        // Remove spaces
        onesAndZeroes = onesAndZeroes.Replace(" ", "");

        // Check string is made up of only ones and zeroes
        Regex rgx = new Regex("[^01]");
        if (rgx.IsMatch(onesAndZeroes)) {
            throw new ArgumentException($"{nameof(onesAndZeroes)} contains invalid characters.  Only spaces (' '), 0, and 1 should be present within string");
            }

        int length = onesAndZeroes.Length;

        bool[] boolArray = new bool[length];
        for (int i = 0; i < length; i++) {
            boolArray[i] = onesAndZeroes[i] == '1';
            }

        return new BitArray(boolArray);
        }

    /// <summary>
    /// Gets a <see cref="BitArray"/> from a string of 1s and 0s.  The first bit in the string is the most significant.
    ///
    /// <example>
    ///     "0000001" -> [true, false, false, false, false, false, false, false] -> 1
    ///     "1000000" -> [false, false, false, false, false, false, false, true] -> 128
    /// </example>
    /// 
    /// </summary>
    /// <param name="onesAndZeroes">The string to get a <see cref="BitArray"/> from.</param>
    /// <returns><see cref="BitArray"/> representation of string where the first bit in the input string is the most significant.</returns>
    /// <exception cref="ArgumentNullException">When input string is null.</exception>
    /// <exception cref="ArgumentException">When input string has invalid characters.</exception>
    public static BitArray GetBitArrayFromStringOf1sAnd0sReversed(string onesAndZeroes) {
        return ReverseBitArrayBits(GetBitArrayFromStringOf1sAnd0s(onesAndZeroes));
        }
    }

