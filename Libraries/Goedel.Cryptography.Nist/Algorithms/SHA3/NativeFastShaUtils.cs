namespace Goedel.Cryptography.Nist;

/// <summary>
/// Utility class manipulating bits and bytes
/// </summary>
public static class NativeFastShaUtils {

    /// <summary>
    /// Unpack the unsigned 32 bit integer <paramref name="n"/> to the byte array
    /// <paramref name="bs"/> beginning at offset <paramref name="off"/>
    /// </summary>
    /// <param name="n">The source</param>
    /// <param name="bs">The destination</param>
    /// <param name="off">The byte offset at the destination.</param>
    public static void UInt32_To_BE(uint n, byte[] bs, int off) {
        bs[off] = (byte)(n >> 24);
        bs[off + 1] = (byte)(n >> 16);
        bs[off + 2] = (byte)(n >> 8);
        bs[off + 3] = (byte)(n);
        }

    /// <summary>
    /// Return an unsigned 32 bit integer from the byte array
    /// <paramref name="bs"/> beginning at offset <paramref name="off"/>
    /// </summary>
    /// <param name="bs">The source</param>
    /// <param name="off">The byte offset at the source.</param>
    /// <returns>The result</returns>
    public static uint BE_To_UInt32(byte[] bs, int off) {
        return (uint)bs[off] << 24
               | (uint)bs[off + 1] << 16
               | (uint)bs[off + 2] << 8
               | (uint)bs[off + 3];
        }

    /// <summary>
    /// Return an unsigned 64 bit integer from the byte array
    /// <paramref name="bs"/> beginning at offset <paramref name="off"/>
    /// </summary>
    /// <param name="bs">The source</param>
    /// <param name="off">The byte offset at the source.</param>
    /// <returns>The result</returns>
    public static ulong LE_To_UInt64(byte[] bs, int off) {
        uint lo = LE_To_UInt32(bs, off);
        uint hi = LE_To_UInt32(bs, off + 4);
        return ((ulong)hi << 32) | (ulong)lo;
        }

    static uint LE_To_UInt32(byte[] bs, int off) {
        return (uint)bs[off]
               | (uint)bs[off + 1] << 8
               | (uint)bs[off + 2] << 16
               | (uint)bs[off + 3] << 24;
        }

    /// <summary>
    /// Unpack a sequence of unsigned 64 bit long values from <paramref name="ns"/>
    /// to the byte array <paramref name="bs"/>
    /// </summary>
    /// <param name="ns">Source</param>
    /// <param name="nsOff">Source offset index</param>
    /// <param name="nsLen">Source length</param>
    /// <param name="bs">Destination</param>
    /// <param name="bsOff">Destination offset</param>
    public static void UInt64_To_LE(ulong[] ns, int nsOff, int nsLen, byte[] bs, int bsOff) {
        for (int i = 0; i < nsLen; ++i) {
            UInt64_To_LE(ns[nsOff + i], bs, bsOff);
            bsOff += 8;
            }
        }

    /// <summary>
    /// Unpack the unsigned 64 bit integer <paramref name="n"/> to the byte array
    /// <paramref name="bs"/> beginning at offset <paramref name="off"/>
    /// </summary>
    /// <param name="n">The source</param>
    /// <param name="bs">The destination</param>
    /// <param name="off">The byte offset at the destination.</param>
    public static void UInt64_To_LE(ulong n, byte[] bs, int off) {
        UInt32_To_LE((uint)(n), bs, off);
        UInt32_To_LE((uint)(n >> 32), bs, off + 4);
        }

    static void UInt32_To_LE(uint n, byte[] bs, int off) {
        bs[off] = (byte)(n);
        bs[off + 1] = (byte)(n >> 8);
        bs[off + 2] = (byte)(n >> 16);
        bs[off + 3] = (byte)(n >> 24);
        }
    }

