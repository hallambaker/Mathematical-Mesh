
# Elliptic Curve (ec)

# RFC 7748
# Elliptic Curves for Security
#
# https://tools.ietf.org/html/rfc7748
# https://www.rfc-editor.org/errata_search.php?rfc=7748

# Finite field with p
def FiniteField(p):
    class Fp:
        def __init__(self, val: int):
            assert isinstance(val, int)
            self.val = val
        def __add__(self, other):
            return Fp((self.val + other.val) % Fp.p)
        def __sub__(self, other):
            return Fp((self.val - other.val) % Fp.p)
        def __mul__(self, other):
            return Fp((self.val * other.val) % Fp.p)
        def __rmul__(self, n):
            return Fp((self.val * n) % Fp.p)
        def __pow__(self, e):
            return Fp(pow(self.val, e, Fp.p))
        def __repr__(self):
            return hex(self.val)
        def __int__(self):
            return int(self.val)
    Fp.p = p
    return Fp

# 5.  The X25519 and X448 Functions

def decodeLittleEndian(b, bits):
    return sum([ b[i] << 8*i for i in range((bits+7)//8) ])

def decodeUCoordinate(u, bits):
    u_list = [b for b in u]
    # Ignore any unused bits.
    if bits % 8:
        u_list[-1] &= (1 << (bits % 8)) - 1
    return decodeLittleEndian(u_list, bits)

def encodeUCoordinate(u, bits):
    return bytearray([ (u >> 8*i) & 0xff for i in range((bits+7)//8) ])

def decodeScalar25519(k):
    k_list = [b for b in k]
    k_list[0] &= 248
    k_list[31] &= 127
    k_list[31] |= 64
    return decodeLittleEndian(k_list, 255)

def decodeScalar448(k):
    k_list = [b for b in k]
    k_list[0] &= 252
    k_list[55] |= 128
    return decodeLittleEndian(k_list, 448)

def cswap(swap, x_2, x_3):
    "Conditional swap in constant time."
    dummy = swap * (x_2 - x_3)
    x_2 = x_2 - dummy
    x_3 = x_3 + dummy
    return x_2, x_3

def mul(k: int, u: int, bits: int, p: int, a24: int):
    Fp = FiniteField(p)
    x_1 = Fp(u)
    x_2 = Fp(1)
    z_2 = Fp(0)
    x_3 = Fp(u)
    z_3 = Fp(1)
    swap = 0

    for t in range(bits-1, -1, -1):
        k_t = (k >> t) & 1
        swap ^= k_t
        (x_2, x_3) = cswap(swap, x_2, x_3)
        (z_2, z_3) = cswap(swap, z_2, z_3)
        swap = k_t

        A = x_2 + z_2
        AA = A**2
        B = x_2 - z_2
        BB = B**2
        E = AA - BB
        C = x_3 + z_3
        D = x_3 - z_3
        DA = D * A
        CB = C * B
        x_3 = (DA + CB)**2
        z_3 = x_1 * (DA - CB)**2
        x_2 = AA * BB
        z_2 = E * (AA + a24 * E)

        aval = A.val


    x_2, x_3 = cswap(swap, x_2, x_3)
    z_2, z_3 = cswap(swap, z_2, z_3)
    res = x_2 * (z_2**(p - 2))
    return res

def x25519(k: bytes, u: bytes):
    # Curve25519 for the ~128-bit security level.
    # Computes u := k * u where k is the scalar and u is the u-coordinate.
    bits = 255
    k = decodeScalar25519(k)
    u = decodeUCoordinate(u, bits)
    p = 2**255 - 19
    a24 = 121665
    res = mul(k, u, bits, p, a24)
    return encodeUCoordinate(int(res), bits)

def x448(k: bytes, u: bytes):
    # Curve448 for the ~224-bit security level.
    bits = 448
    k = decodeScalar448(k)
    u = decodeUCoordinate(u, bits)
    p = 2**448 - 2**224 - 1
    a24 = 39081
    res = mul(k, u, bits, p, a24)
    return encodeUCoordinate(int(res), bits)


if __name__ == '__main__':
    import binascii

    k = binascii.unhexlify(
        b'a546e36bf0527c9d3b16154b82465edd62144c0ac1fc5a18506a2244ba449ac4')
    u = binascii.unhexlify(
        b'e6db6867583030db3594c1a424b15f7c726624ec26b3353b10a903a6d0ab1c4c')
    r = binascii.unhexlify(
        b'c3da55379de9c6908e94ea4df28d084f32eccf03491c71f754b4075577a28552')
    out = x25519(k, u)
    assert out == r
    print(out)

    k = binascii.unhexlify(
        b'4b66e9d4d1b4673c5ad22691957d6af5c11b6421e0ea01d42ca4169e7918ba0d')
    u = binascii.unhexlify(
        b'e5210f12786811d3f4b7959d0538ae2c31dbe7106fc03c3efc4cd549c715a413')
    r = binascii.unhexlify(
        b'95cbde9476e8907d7aade45cb4b873f88b595a68799fa152e6f8f7647aac7957')
    out = x25519(k, u)
    assert out == r
    print(out)

    k = binascii.unhexlify(
        b'0900000000000000000000000000000000000000000000000000000000000000')
    u = binascii.unhexlify(
        b'0900000000000000000000000000000000000000000000000000000000000000')
    r1 = binascii.unhexlify(
        b'422c8e7a6227d7bca1350b3e2bb7279f7897b87bb6854b783c60e80311ae3079')
    r1000 = binascii.unhexlify(
        b'684cf59ba83309552800ef566f2f4d3c1c3887c49360e3875f2eb94d99532c51')
    for i in range(1, 1001):
        k, u = x25519(k, u), k
        if i == 1: assert k == r1
        if i == 1000: assert k == r1000
    print(k)

    k = binascii.unhexlify(
        b'3d262fddf9ec8e88495266fea19a34d28882acef045104d0d1aae121' +
        b'700a779c984c24f8cdd78fbff44943eba368f54b29259a4f1c600ad3')
    u = binascii.unhexlify(
        b'06fce640fa3487bfda5f6cf2d5263f8aad88334cbd07437f020f08f9' +
        b'814dc031ddbdc38c19c6da2583fa5429db94ada18aa7a7fb4ef8a086')
    r = binascii.unhexlify(
        b'ce3e4ff95a60dc6697da1db1d85e6afbdf79b50a2412d7546d5f239f' +
        b'e14fbaadeb445fc66a01b0779d98223961111e21766282f73dd96b6f')
    out = x448(k, u)
    assert out == r
    print(out)

    k = binascii.unhexlify(
        b'203d494428b8399352665ddca42f9de8fef600908e0d461cb021f8c5' +
        b'38345dd77c3e4806e25f46d3315c44e0a5b4371282dd2c8d5be3095f')
    u = binascii.unhexlify(
        b'0fbcc2f993cd56d3305b0b7d9e55d4c1a8fb5dbb52f8e9a1e9b6201b' +
        b'165d015894e56c4d3570bee52fe205e28a78b91cdfbde71ce8d157db')
    r = binascii.unhexlify(
        b'884a02576239ff7a2f2f63b2db6a9ff37047ac13568e1e30fe63c4a7' +
        b'ad1b3ee3a5700df34321d62077e63633c575c1c954514e99da7c179d')
    out = x448(k, u)
    assert out == r
    print(out)

    k = binascii.unhexlify(
        b'05000000000000000000000000000000000000000000000000000000' +
        b'00000000000000000000000000000000000000000000000000000000')
    u = binascii.unhexlify(
        b'05000000000000000000000000000000000000000000000000000000' +
        b'00000000000000000000000000000000000000000000000000000000')
    r1 = binascii.unhexlify(
        b'3f482c8a9f19b01e6c46ee9711d9dc14fd4bf67af30765c2ae2b846a' +
        b'4d23a8cd0db897086239492caf350b51f833868b9bc2b3bca9cf4113')
    r1000 = binascii.unhexlify(
        b'aa3b4749d55b9daf1e5b00288826c467274ce3ebbdd5c17b975e09d4' +
        b'af6c67cf10d087202db88286e2b79fceea3ec353ef54faa26e219f38')
    for i in range(1, 1001):
        k, u = x448(k, u), k
        if i == 1: assert k == r1
        if i == 1000: assert k == r1000
    print(k)