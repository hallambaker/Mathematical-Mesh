namespace Goedel.Cryptography.Nist;

/// <summary>
/// Extensions working on BitArrays.
/// </summary>
public static class BitArrayExtensions {
    
    ///<summary>Number of bits in a byte.</summary> 
    public const int BITSINBYTE = 8;

    /* DEF (1/10/2017) -- 
        In BitArray...
        0-bit = least significant
        n-bit = most significant
        Which is reversed from the way CAVS thinks about it
        So we're going backwards here
    */


    /// <summary>
    /// Extract the sub array from <paramref name="bArray"/> starting at <paramref name="startIndex"/>
    /// for <paramref name="length"/> bits.
    /// </summary>
    /// <param name="bArray">The array to extract from.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="length">The number of bits.</param>
    /// <returns>The extracted array.</returns>
    public static BitArray SubArray(this BitArray bArray, int startIndex, int length) {
        //if (startIndex + length > bArray.Count)
        //{
        //    throw new IndexOutOfRangeException();
        //}

        var copy = new BitArray(length);
        for (int i = startIndex, j = 0; j < length; i++, j++) {
            copy[j] = bArray[i];
            }
        return copy;
        }

    /// <summary>
    /// Concatenate <paramref name="bArray"/> and <paramref name="bitsToAdd"/> and return
    /// the array.
    /// </summary>
    /// <param name="bArray">First array.</param>
    /// <param name="bitsToAdd">Array to append.</param>
    /// <returns>The result.</returns>
    public static BitArray Concatenate(this BitArray bArray, BitArray bitsToAdd) {
        var boolArray = new bool[bArray.Length + bitsToAdd.Length];
        bArray.CopyTo(boolArray, 0);
        bitsToAdd.CopyTo(boolArray, bArray.Length);

        return new BitArray(boolArray);
        }

    /// <summary>
    /// Return the reverse of the bit array <paramref name="bArray"/>
    /// </summary>
    /// <param name="bArray">The array to reverse.</param>
    /// <returns>The result.</returns>
    public static BitArray Reverse(this BitArray bArray) {
        return MsbLsbConversionHelpers.ReverseBitArrayBits(bArray);
        }

    }

