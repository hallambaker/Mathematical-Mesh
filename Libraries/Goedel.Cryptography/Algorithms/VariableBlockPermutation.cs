#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Goedel.Utilities;

namespace Goedel.Cryptography.Algorithms;

/// <summary>
/// Short block permutation.
/// </summary>
public class ShortBlockPermute {
    #region // Properties
    ///<summary>The bitmask masking the lower n bits of the data channel</summary> 
    public ulong Mask;

    ///<summary>The number of bits to permute.</summary> 
    public int Bits;

    ///<summary>The number of rounds to perform.</summary> 
    public int Rounds;


    ///<summary>The key schedule, this is stored for reuse.</summary> 
    ulong[] keySchedule;

    int[] rotateSchedule;
    #endregion

    #region // Constructors

    /// <summary>
    /// Constructor, creates a permutation function mapping an input of 
    /// length <paramref name="bits"/> to an output of length <paramref name="bits"/>
    /// according to the value of <paramref name="key"/>.
    /// <para>Once the key schedule is set up, calls to Permute will always return
    /// a different output if the low order bits <paramref name="bits"/> are 
    /// different and the same otherwise.</para>
    /// </summary>
    /// <param name="key"></param>
    /// <param name="bits"></param>
    /// <param name="rounds"></param>
    public ShortBlockPermute(byte[] key, int bits, int rounds = 0) {

        (bits <= 64).AssertTrue(NYI.Throw); ; // Block size is 64 bits or less.
        Bits = bits;

        // If not specified, set the number of rounds to be the number of bits plus 12
        // This is arbitrary at this point.
        Rounds = rounds > 0 ? rounds : Bits + 12;
        (Rounds <= 255).AssertTrue(NYI.Throw); ; // Number of rounds is 255 or less.

        // Create the bitmask
        Mask = 1;
        for (var i = 1; i < Bits; i++) {
            Mask |= Mask >> 1;
            }

        // Create the key schedule. This is almost certainly more baroque than needed.
        keySchedule = new ulong[Rounds];
        rotateSchedule = new int[Rounds];
        var kdf = new KeyDeriveHKDF(key, "ShortBlockPermute");
        var info = new byte[1];
        for (var i = 0; i < Rounds; i++) {
            info[0] = (byte)i;
            var bytes = kdf.Derive(info, 8).BigEndianInt(8);
            keySchedule[i] = Mask & bytes;
            rotateSchedule[i] = (int)bytes % Bits;
            }
        }
    #endregion
    #region // Private methods 

    ulong Rotate(ulong input, int bits) =>
            input << bits | (input >> Bits - bits);

    #endregion
    #region // Public methods 

    /// <summary>
    /// Permute the lower n bits of <paramref name="input"/> according to the 
    /// schedule established by the constructor.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public ulong Permute(ulong input) {
        var data = input & Mask;

        unchecked {
            // If I did this right, each of the three operations is reversible and no data is lost.
            // The operations are chosen to provide non-linearity relative to each other while
            // working the key at each step.
            for (var i = 0; i < Rounds; i++) {
                data ^= keySchedule[i];
                data &= Mask;                   // for clarity, can remove
                data = Rotate(data, rotateSchedule[i]);
                data &= Mask;                   // for clarity, can remove
                data += keySchedule[i];
                data &= Mask;                   // This one is essential.
                }
            }
        return data;
        }

    /// <summary>
    /// A depermutation function could be implemented but that would encourage people
    /// to use this for encrypting data. This is implemented here for use in testing.
    /// </summary>
    /// <param name="input">The cipertext.</param>
    /// <returns>The depermuted input.</returns>
    public ulong Depermute(ulong input) {
        var data = input & Mask;

        unchecked {
            // If I did this right, each of the three operations is reversible and no data is lost.
            // The operations are chosen to provide non-linearity relative to each other while
            // working the key at each step.
            for (var i = 0; i < Rounds; i++) {
                data += keySchedule[i];
                data &= Mask;                   // This one is essential.
                data = Rotate(data, rotateSchedule[i]);
                data &= Mask;                   // for clarity, can remove
                data ^= keySchedule[i];
                data &= Mask;                   // for clarity, can remove
                }
            }
        return data;
        }
    #endregion
    }
