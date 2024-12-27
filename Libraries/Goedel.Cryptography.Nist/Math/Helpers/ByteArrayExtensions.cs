namespace Goedel.Cryptography.Nist;
/// <summary>
/// bigInteger is little endian when dealing with byte-arrays, CAVS code thinks about byte array representations as big endian
/// The BigInteger structure expects the individual bytes in a byte array to appear in little-endian order 
/// (that is, the lower-order bytes of the value precede the higher-order bytes)
/// also always want to return an array of the size of bArrayA, which means we might need to pad 
/// </summary>
public static class ByteArrayExtensions {


    /// <summary>
    /// 
    /// </summary>
    /// <param name="bArrayA"></param>
    /// <param name="bArrayB"></param>
    /// <returns></returns>
    public static byte[] Concatenate(this byte[] bArrayA, byte[] bArrayB) {
        var bArray = new byte[bArrayA.Length + bArrayB.Length];
        bArrayA.CopyTo(bArray, 0);
        bArrayB.CopyTo(bArray, bArrayA.Length);

        return bArray;
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bArray"></param>
    /// <param name="partitionLength"></param>
    /// <returns></returns>
    public static byte[][] Partition(this byte[] bArray, int partitionLength) {
        var partition = new byte[bArray.Length / partitionLength][];
        var mainIndex = 0;
        var partitionIndex = 0;

        foreach (var b in bArray) {
            if (partitionIndex == 0) {
                partition[mainIndex] = new byte[partitionLength];
                }

            partition[mainIndex][partitionIndex++] = b;

            if (partitionIndex == partitionLength) {
                partitionIndex = 0;
                mainIndex++;
                }
            }

        return partition;
        }

 
    }

