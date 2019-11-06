def decodeLittleEndian(b, bits):
    return sum([b[i] << 8*i for i in range((bits+7)/8)])

def decodeUCoordinate(u, bits):
    u_list = [ord(b) for b in u]
    # Ignore any unused bits.
    if bits % 8:
        u_list[-1] &= (1<<(bits%8))-1
    return decodeLittleEndian(u_list, bits)

def encodeUCoordinate(u, bits):
    u = u % p
    return ''.join([chr((u >> 8*i) & 0xff)
                    for i in range((bits+7)/8)])


def decodeScalar25519(k):
    k_list = [ord(b) for b in k]
    k_list[0] &= 248
    k_list[31] &= 127
    k_list[31] |= 64
    return decodeLittleEndian(k_list, 255)

def decodeScalar448(k):
    k_list = [ord(b) for b in k]
    k_list[0] &= 252
    k_list[55] |= 128
    return decodeLittleEndian(k_list, 448)


def cswap(swap, x_2, x_3):
    dummy = mask(swap) & (x_2 ^ x_3)
    x_2 = x_2 ^ dummy
    x_3 = x_3 ^ dummy
    return (x_2, x_3)


def scale (u, bits):
   x_1 = u
   x_2 = 1
   z_2 = 0
   x_3 = u
   z_3 = 1
   swap = 0

   for t = bits-1 down to 0:
       k_t = (k >> t) & 1
       swap ^= k_t
       // Conditional swap; see text below.
       (x_2, x_3) = cswap(swap, x_2, x_3)
       (z_2, z_3) = cswap(swap, z_2, z_3)
       swap = k_t

       A = x_2 + z_2
       AA = A^2
       B = x_2 - z_2
       BB = B^2
       E = AA - BB
       C = x_3 + z_3
       D = x_3 - z_3
       DA = D * A
       CB = C * B
       x_3 = (DA + CB)^2
       z_3 = x_1 * (DA - CB)^2
       x_2 = AA * BB
       z_2 = E * (AA + a24 * E)

   // Conditional swap; see text below.
   (x_2, x_3) = cswap(swap, x_2, x_3)
   (z_2, z_3) = cswap(swap, z_2, z_3)
   Return x_2 * (z_2^(p - 2))