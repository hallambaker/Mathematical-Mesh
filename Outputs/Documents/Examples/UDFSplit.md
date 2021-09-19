
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  97 7E DC 3B  BB C0 4E FE  04 D2 BA 10  4B 1C 36 63
~~~~

This has the UDF representation:

S57N-YO53-YBHP-4BGS-XIIE-WHBW-MM

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 201372123630378260423122634962223511139
a1 = 149693465408489936381877631903229243725
a2 = 78093401751222944032050659386247949623
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 88876623869152677373676318819932492980
f(2) = 132567927610372982388331321450137374067
f(3) = 332446034854039175467087642852838154400
f(4) = 7946211758274329683196068164498410965
f(5) = 179915559085893835426780419680422778283
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 42 DD 03  DF 55 A2 C0  92 CF E3 B1  0B AA D0 D4
  B4
f(2) = 
  31 63 BB A7  76 0C 41 C0  FE E0 CA 19  7A AF 37 CD
  73
f(3) = 
  32 FA 1A C6  FF DF 9D 50  42 37 85 F3  5D 58 51 20
  A0
f(4) = 
  33 05 FA 62  7C CF B5 6E  5C D4 17 3E  B3 A6 1C CD
  D5
f(5) = 
  34 87 5A 79  EC DC 8A 1B  4E B6 7D FB  7D 98 9A D5
  AB
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYE-FXID-35K2-FQES-Z7R3-CC5K-2DKL-I
f(2) = SAYW-HO5H-OYGE-DQH6-4DFB-S6VP-G7GX-G
f(3) = SAZP-UGWG-77PZ-2UCC-G6C7-GXKY-KEQK-A
f(4) = SAZQ-L6TC-PTH3-K3S4-2QLT-5M5G-DTG5-K
f(5) = SA2I-OWTZ-5TOI-UG2O-WZ67-W7MY-TLK2-W
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
