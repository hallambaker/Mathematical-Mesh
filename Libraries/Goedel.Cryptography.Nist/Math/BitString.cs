using Helper = Goedel.Cryptography.Nist.MsbLsbConversionHelpers;

namespace Goedel.Cryptography.Nist;
/// <summary>
/// Bit and Byte functions manipulation functions.
/// NOTE:
///     Input/Output of bits is always:
///         LSb to MSb - least significant bit first (index 0), most significant bit last (last index)
///     Everything else (bytes, hex, etc):
///         MSB to LSB - most significant Byte first (index 0), least significant Byte last (last index)
/// </summary>
public class BitString {
    ///<summary>Number of bytes per digit.</summary> 
    public const int BYTESPERDIGIT = 4;

    ///<summary>Number of bits in Byte.</summary> 
    public const int BITSINBYTE = 8;
    private readonly BitArray _bits;

    #region Constructors

    /// <summary>
    /// Create an instance of <paramref name="bitCount"/> bits.
    /// </summary>
    /// <param name="bitCount">The number of bits.</param>
    public BitString(int bitCount) {
        _bits = new BitArray(bitCount);
        }

    /// <summary>
    /// Create <see cref="BitString"/> expecting <paramref name="msBytes"/> in Most Significant Byte (MSB) order.
    /// </summary>
    /// <param name="msBytes">The MSB bytes to use in the LSb <see cref="BitString"/></param>
    public BitString(byte[] msBytes) {
        _bits = Helper.MostSignificantByteArrayToLeastSignificantBitArray(msBytes);
        }

    /// <summary>
    /// Create <see cref="BitString"/> expecting <see cref="BitArray"/> in Least Signficant bit (LSb) order.
    /// </summary>
    /// <param name="bits">The LSb bits to use in the <see cref="BitString"/></param>
    public BitString(BitArray bits) {
        _bits = bits;
        }

    /// <summary>
    /// Converts BigInteger to BitString with proper byte orientation
    /// </summary>
    /// <param name="bigInt">The value to convert.</param>
    /// <param name="bitLength">The number of bits to convert.</param>
    /// <param name="allowRemoval">If true allow removal of empty byte added to
    /// avoid twos complement issues..</param>
    public BitString(BigInteger bigInt, int bitLength = 0, bool allowRemoval = true) {
        byte[] bytesInLSB = bigInt.ToByteArray();

        // Sometimes, BigInteger -> byte[] adds an empty byte on the end to help
        // distinguish between two's complement for positive and negative.
        // Whenever it appears, we can just remove it safely.
        if (allowRemoval) {
            if (bytesInLSB[bytesInLSB.Length - 1] == 0) {
                var list = bytesInLSB.ToList();
                list.RemoveAt(list.Count - 1);
                bytesInLSB = list.ToArray();
                }
            }

        if (bytesInLSB.Length * BITSINBYTE < bitLength) {
            BitArray bytesAsBitsLsb = new BitArray(bytesInLSB);
            BitArray holdLsb = new BitArray(bitLength);
            for (int i = 0; i < bytesAsBitsLsb.Length; i++) {
                holdLsb[i] = bytesAsBitsLsb[i];
                }

            _bits = holdLsb;
            }
        else {
            _bits = new BitArray(bytesInLSB);
            }
        }

    /// <summary>
    /// Create a <see cref="BitString"/> using MSB hex.
    /// </summary>
    /// <param name="hexMSB">The MSB hexadecimal string</param>
    /// <param name="bitLength">The length of the resulting <see cref="BitString"/> by taking that amount of MSBs</param>
    /// <param name="truncateBitsFromEndOfLastByte">When the bitLength is not a multiple of 8, the hex needs to be truncated in the last byte. This parameter determines which side of the last byte is truncated</param>
    public BitString(string hexMSB, int bitLength = -1, bool truncateBitsFromEndOfLastByte = true) {
        if (string.IsNullOrEmpty(hexMSB) || bitLength == 0) {
            _bits = new BitArray(0);
            return;
            }

        hexMSB = hexMSB.Replace(" ", "");
        int numberChars = hexMSB.Length;

        if (numberChars % 2 != 0) {
            throw new InvalidBitStringLengthException($"{nameof(BitString)}s are expected to have an even number of hex characters. Value was \"{hexMSB}\".");
            }

        byte[] bytesInMSB = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2) {
            bytesInMSB[i / 2] = Convert.ToByte(hexMSB.Substring(i, 2), 16);
            }

        if (bitLength < 0) {
            _bits = Helper.MostSignificantByteArrayToLeastSignificantBitArray(bytesInMSB);
            }
        else {

            var bitsNeeded = System.Math.Min(bitLength, numberChars * BITSINBYTE / 2);

            var bitsInMSB = Helper.MostSignificantByteArrayToMostSignificantBitArray(bytesInMSB);
            var truncatedBits = new BitArray(bitsNeeded);

            if (truncateBitsFromEndOfLastByte) {
                for (var i = 0; i < bitsNeeded; i++) {
                    truncatedBits[i] = bitsInMSB[i];
                    }
                }
            else {
                var firstBits = bitsNeeded - (bitsNeeded % 8);
                for (var i = 0; i < firstBits; i++) {
                    truncatedBits[i] = bitsInMSB[i];
                    }

                var skippedBits = (bytesInMSB.Length * BITSINBYTE) - bitsNeeded;
                for (var i = firstBits; i < bitsNeeded; i++) {
                    truncatedBits[i] = bitsInMSB[i + skippedBits];
                    }
                }

            _bits = Helper.ReverseBitArrayBits(truncatedBits);
            }
        }

    //public BitString(byte[] bytesToConcatenate, int bitLengthToHit) {
    //    var maxBytes = bitLengthToHit.CeilingDivide(BITSINBYTE);
    //    var bytes = new byte[maxBytes];

    //    for (var i = 0; i < maxBytes; i++) {
    //        bytes[i] = bytesToConcatenate[i % bytesToConcatenate.Length];
    //        }

    //    var shortenedBits = Helper.MostSignificantByteArrayToLeastSignificantBitArray(bytes);
    //    if (shortenedBits.Length > bitLengthToHit) {
    //        shortenedBits = shortenedBits.SubArray(0, bitLengthToHit);
    //        }

    //    _bits = shortenedBits;
    //    }
    #endregion Constructors

    #region Conversions

    /// <summary>
    /// Returns bytes based on <see cref="Bits"/> in MSB.
    /// </summary>
    /// <remarks>
    /// Bytes are by default in Most Significant Byte order.  
    /// If true is provided to function, returned in Least Significant Byte order.
    /// </remarks>
    /// <param name="reverseBytes">Should the bytes be reverse in the array?  (Changes from MSB to LSB)</param>
    /// <returns>Byte array of <see cref="Bits"/> bits.</returns>
    public byte[] ToBytes(bool reverseBytes = false) {
        if (Bits.Length == 0) {
            return new byte[0];
            }

        byte[] bytes = new byte[(Bits.Length - 1) / BITSINBYTE + 1];
        _bits.CopyTo(bytes, 0);

        // Note bytes are currently in LSB, 
        // class inputs/outputs byte arrays in MSB by default, 
        //  so if reverse is specified, return as is, 
        //  otherwise reverse the LSB to get MSB and return that
        if (reverseBytes) {
            return bytes;
            }
        else {
            return bytes.Reverse().ToArray();
            }
        }

    /// <summary>
    /// return the bit string as padded bytes.
    /// </summary>
    /// <param name="flipLastByte">If true flip the last byte.</param>
    /// <returns>The result</returns>
    public byte[] GetPaddedBytes(bool flipLastByte = false) {
        if (BitLength % 8 == 0) {
            return ToBytes();
            }

        if (flipLastByte) {
            return PadToNextByteBoundry(this).ToBytes();
            //return PadToNextByteBoundry(this, false).ToBytes();
            //var padded = PadToNextByteBoundry(this).ToBytes();
            //padded[padded.Length-1] = MsbLsbConversionHelpers.ReverseBitArrayBits(new BitArray(padded.TakeLast(1).ToArray())).ToBytes()[0];
            //return padded;
            }
        else {
            return PadToNextByteBoundry(this).ToBytes();
            }
        }

    /// <summary>
    /// Convert to a positive big integer.
    /// </summary>
    /// <returns>The result</returns>
    public BigInteger ToPositiveBigInteger() {
        //var padding = BITSINBYTE - (BitLength % BITSINBYTE) + BITSINBYTE;
        var padding = BITSINBYTE - (BitLength % BITSINBYTE);

        // Add an empty byte (or more) to the beginning to get rid of two's complement
        var paddedBitString = ConcatenateBits(Zeroes(padding), this);
        return new BigInteger(paddedBitString.ToBytes(true));
        }

    /// <summary>
    /// Convert to a hex string.
    /// </summary>
    /// <returns>The result</returns>
    public string ToHex() {
        if (BitLength == 0) {
            return "";
            }

        var bytes = new byte[] { };

        // Make a padded BitString if the length isn't % 8
        if (BitLength % 8 != 0) {
            var padding = BITSINBYTE - BitLength % BITSINBYTE;
            var paddedBS = new BitString(BitLength + padding);

            for (var i = 0; i < BitLength; i++) {
                paddedBS.Set(i + padding, Bits[i]);
                }

            bytes = paddedBS.ToBytes();
            }
        else {
            bytes = ToBytes();
            }

        StringBuilder hex = new StringBuilder(bytes.Length * 2);
        for (int index = 0; index < bytes.Length; index++) {
            hex.AppendFormat("{0:x2}", bytes[index]);
            }

        return hex.ToString().ToUpper();
        }

    #endregion Conversions

    #region Logical Operators


    /// <summary>
    /// Adds two bit strings together - e.g. "11" (3) + 111 (7) = 1010 (10).
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static BitString BitStringAddition(BitString left, BitString right) {
        left = left.GetDeepCopy();
        right = right.GetDeepCopy();

        PadShorterBitStringWithZeroes(ref left, ref right);

        int length = left.BitLength; // they are now of equal length, doesn't matter which is used
        int carry = 0;
        List<bool> bits = new List<bool>();

        // Add all bits one by one
        for (int i = 0; i < length; i++) {
            int firstBit = left.Bits[i] ? 1 : 0;
            int secondBit = right.Bits[i] ? 1 : 0;

            bool sum = (firstBit ^ secondBit ^ carry) == 1;

            bits.Add(sum);

            carry = (firstBit & secondBit) | (secondBit & carry) | (firstBit & carry);
            }

        // if overflow, then add a bit
        if (carry == 1) {
            bits.Add(true);
            }

        return new BitString(new BitArray(bits.ToArray()));
        }


    #endregion Logical Operators

    #region Getters and Setters
    /// <summary>
    /// In LSb
    /// </summary>
    public BitArray Bits {
        get { return _bits; }
        }

    /// <summary>
    /// Return the length in bits.
    /// </summary>
    public int BitLength {
        get { return _bits.Length; }
        }


    /// <summary>
    /// Return a deep copy of this array
    /// </summary>
    /// <returns>The copy.</returns>
    public BitString GetDeepCopy() {
        return new BitString(new BitArray(_bits));
        }

    /// <summary>
    /// Set the bit at index <paramref name="bitIndex"/> to <paramref name="value"/>.
    /// </summary>
    /// <param name="bitIndex">The index</param>
    /// <param name="value">The value.</param>
    /// <returns>True if successful, otherwise false.</returns>
    public bool Set(int bitIndex, bool value) {
        if ((bitIndex < 0) || (bitIndex >= BitLength)) {
            return false;
            }
        _bits[bitIndex] = value;

        return true;
        }

    /// <summary>
    /// Get the most significant bits of the bit string <paramref name="bitString"/>.
    /// </summary>
    /// <param name="numBits">Number of bits</param>
    /// <param name="bitString">Bit string to process.</param>
    /// <returns>The bit string.</returns>
    public static BitString GetMostSignificantBits(int numBits, BitString bitString) {
        return Substring(bitString, bitString.BitLength - numBits, numBits);
        }

    /// <summary>
    /// Get the most significant bits of this bit string.
    /// </summary>
    /// <param name="numBits">Number of bits</param>
    /// <returns>The bit string.</returns>
    public BitString GetMostSignificantBits(int numBits) {
        return BitString.GetMostSignificantBits(numBits, this);
        }

    /// <summary>
    /// Get the least significant bits of the bit string <paramref name="bitString"/>.
    /// </summary>
    /// <param name="numBits">Number of bits</param>
    /// <param name="bitString">Bit string to process.</param>
    /// <returns>The bit string.</returns>
    public static BitString GetLeastSignificantBits(int numBits, BitString bitString) {
        return BitString.Substring(bitString, 0, numBits);
        }

    /// <summary>
    /// Get the least significant bits of this bit string.
    /// </summary>
    /// <param name="numBits">Number of bits</param>
    /// <returns>The bit string.</returns>
    public BitString GetLeastSignificantBits(int numBits) {
        return BitString.GetLeastSignificantBits(numBits, this);
        }
    #endregion Getters and Setters

    #region Concatenation

    /// <summary>
    /// Append bits from <paramref name="bitsToAppend"/>
    /// </summary>
    /// <param name="bitsToAppend">The bits to append.</param>
    /// <returns>The appended bits.</returns>
    public BitString ConcatenateBits(BitString bitsToAppend) {
        return ConcatenateBits(this, bitsToAppend);
        }


    /// <summary>
    /// Concatenates two <see cref="BitString"/>.
    /// </summary>
    /// <example>
    ///     mostSignificantBits = "0010" (4)
    ///     leastSignificantBits = "1000" (1)
    ///     result = 10000010 (65)
    /// </example>
    /// <param name="mostSignificantBits">The bits that will be most significant after concatenation.</param>
    /// <param name="leastSignificantBits">The bits that will be least significant after concatenation.</param>
    /// <returns>The concatenated <see cref="BitString"/></returns>
    public static BitString ConcatenateBits(BitString mostSignificantBits, BitString leastSignificantBits) {
        bool[] bits = new bool[mostSignificantBits.BitLength + leastSignificantBits.BitLength];
        leastSignificantBits.Bits.CopyTo(bits, 0);
        mostSignificantBits.Bits.CopyTo(bits, leastSignificantBits.BitLength);
        return new BitString(new BitArray(bits));
        }
    #endregion Concatentation

    #region Substring
    /// <summary>
    /// Gets substring of a BitString from the LSB direction.
    /// </summary>
    /// <param name="bsToSub">BitString to pull bits from.</param>
    /// <param name="startIndex">Least significant bit is 0 index.</param>
    /// <param name="numberOfBits">Amount of bits to pull.</param>
    /// <returns></returns>
    public static BitString Substring(BitString bsToSub, int startIndex, int numberOfBits) {
        if ((startIndex > bsToSub.BitLength - 1) || startIndex < 0) {
            throw new ArgumentOutOfRangeException($"{nameof(startIndex)} out of range");
            }
        if (startIndex + numberOfBits > bsToSub.BitLength) {
            throw new ArgumentOutOfRangeException($"does not contain enough elements to pull {numberOfBits} starting at {startIndex}");
            }

        bool[] newBits = new bool[numberOfBits];
        for (int i = 0; i < numberOfBits; i++) {
            newBits[i] = bsToSub.Bits[startIndex + i];
            }

        return new BitString(new BitArray(newBits));
        }



    /// <summary>
    /// Gets a substring of bits from the MSB direction. 
    /// </summary>
    /// <param name="bsToSub">BitString to pull bits from.</param>
    /// <param name="startIndex">Start index from the MSB side. Most significant bit is index 0.</param>
    /// <param name="numberOfBits"></param>
    /// <returns>The result</returns>
    public static BitString MSBSubstring(BitString bsToSub, int startIndex, int numberOfBits) {
        return Substring(bsToSub, bsToSub.BitLength - startIndex - numberOfBits, numberOfBits);
        }

    /// <summary>
    /// Return the most significant bit string.
    /// </summary>
    /// <param name="startIndex">The start index</param>
    /// <param name="numberOfBits">The number of bits.</param>
    /// <returns>The result</returns>
    public BitString MSBSubstring(int startIndex, int numberOfBits) {
        return MSBSubstring(this, startIndex, numberOfBits);
        }
    #endregion Substring

    #region Padding
    /// <summary>
    /// Takes a BitString and adds LSbs to make the BitString hit a byte boundry.  
    /// Returns the original BitString if already at a byte boundry.
    /// </summary>
    /// <param name="bs">The BitString to pad.</param>
    /// <param name="padOntoLsb">Flag</param>
    /// <returns></returns>
    public static BitString PadToNextByteBoundry(BitString bs, bool padOntoLsb = true) {
        return PadToModulus(bs, BITSINBYTE, padOntoLsb);
        }

    /// <summary>
    /// Takes a BitString and adds LSBs (or MSBs when <paramref name="padOntoLsb"/> is false) to make 
    /// the BitString hit (BitString % modulus = 0)
    /// </summary>
    /// <param name="bs">The BitString to pad</param>
    /// <param name="modulus">The modulus to pad the bitstring such that BitString % modulusToHit = 0</param>
    /// <param name="padOntoLsb">When true bits are added on the least significant end, the most significant end otherwise.</param>
    /// <returns>The padded BitString</returns>
    public static BitString PadToModulus(BitString bs, int modulus, bool padOntoLsb = true) {
        if (bs.BitLength % modulus == 0) {
            return bs;
            }

        var bitsToAdd = (modulus - bs.BitLength % modulus);

        return padOntoLsb ?
            bs.ConcatenateBits(new BitString(bitsToAdd)) :
            new BitString(bitsToAdd).ConcatenateBits(bs);
        }


    #endregion Padding
    ///<inheritdoc/>
    public override int GetHashCode() { // Must override this since we override equals.
        return this.ToHex().GetHashCode();
        }

    ///<inheritdoc/>
    public override bool Equals(object obj) {
        var otherBitString = obj as BitString;
        if (otherBitString == null) {
            return false;
            }

        if (this.BitLength != otherBitString.BitLength) {
            return false;
            }

        var copiedBits = new BitArray(this.Bits);
        var comparison = copiedBits.Xor(otherBitString.Bits);

        foreach (bool val in comparison) {
            if (val) {
                return false;
                }
            }

        return true;
        }


    /// <summary>
    /// Return an array of zero bits.
    /// </summary>
    /// <param name="length">Length of the array.</param>
    /// <returns>The result.</returns>
    public static BitString Zeroes(int length) {
        var bits = new BitArray(length);
        bits.SetAll(false);
        return new BitString(bits);
        }



    #region Private methods
    private static void PadShorterBitStringWithZeroes(ref BitString inputA, ref BitString inputB) {
        if (inputA.BitLength == inputB.BitLength) {
            return;
            }

        if (inputA.BitLength > inputB.BitLength) {
            inputB = PadShorterBitStringWithZeroes(inputA, inputB);
            }
        else {
            inputA = PadShorterBitStringWithZeroes(inputB, inputA);
            }
        }

    private static BitString PadShorterBitStringWithZeroes(BitString longerBitString, BitString shorterBitString) {
        BitArray newArray = new BitArray(longerBitString.BitLength);
        for (int i = 0; i < shorterBitString.BitLength; i++) {
            newArray[i] = shorterBitString.Bits[i];
            }

        return new BitString(newArray);
        }


    #endregion Private methods
    }

