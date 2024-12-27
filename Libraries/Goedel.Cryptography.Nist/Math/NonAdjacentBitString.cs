namespace Goedel.Cryptography.Nist;

/// <summary>
/// Converts a <see cref="BigInteger"/> into Non-Adjacent Form so that in {-1, 0, 1} 
/// there are no consecutive nonzero values. This reduces the number
/// of meaningful bits when applying multiplication over ECC.
/// </summary>
public class NonAdjacentBitString {

    ///<summary>The bits</summary> 
    public int[] Bits { get { return _listBits.ToArray(); } }
    
    ///<summary>Length of bits</summary> 
    public int BitLength { get { return _listBits.Count; } }

    private List<int> _listBits;

    /// <summary>
    /// Converts a <see cref="BigInteger"/> into Non-Adjacent Form so that in {-1, 0, 1} there are no consecutive nonzero values. This reduces the number
    /// of meaningful bits when applying multiplication over ECC.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>An array containing only {-1, 0, 1} values.</returns>
    public NonAdjacentBitString(BigInteger value) {
        _listBits = new List<int>();
        var newValue = 0;
        var bits = new BitString(value).Bits;

        while (value > 0) {
            if (!value.IsEven) {
                newValue = 2 - (int)(value % 4);
                value -= newValue;
                }
            else {
                newValue = 0;
                }

            _listBits.Add(newValue);
            value >>= 1;
            }
        }
    }

