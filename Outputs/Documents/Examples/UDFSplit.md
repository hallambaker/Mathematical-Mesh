
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  E2 36 94 A3  A4 BB 01 9E  DF 5B 11 FE  0E C7 0B 34
~~~~

This has the UDF representation:

4I3J-JI5E-XMAZ-5X23-CH7A-5RYL-GQ

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 300688925839545316632525865284484401972
a1 = 195041219115718837116637731412457697558
a2 = 329745915927071486842892820764541871571
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 144911327040458713665307202597947548087
f(2) = 308343193174576620920499574008726225837
f(3) = 110419790400022111471353764653284012208
f(4) = 231705852558672112244618989395157330214
f(5) = 331919012729588159776920640802577968348
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 6D 04 E8  0A 03 BE C3  04 6A 39 FE  5D 85 21 A1
  B7
f(2) = 
  31 E7 F8 BD  27 C8 6E D4  D1 3C 28 40  12 EC 05 03
  AD
f(3) = 
  32 53 12 13  FC F2 CB 37  05 55 25 D7  1E 43 71 30
  B0
f(4) = 
  33 AE 50 EC  89 82 D3 E9  A0 B5 32 C3  7F 8B 66 29
  26
f(5) = 
  34 F9 B5 46  CD 78 88 EC  A3 5C 4F 05  36 C3 E3 EC
  DC
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYG-2BHI-BIB3-5QYE-NI47-4XMF-EGQ3-O
f(2) = SAY6-P6F5-E7EG-5VGR-HQUE-AEXM-AUB2-2
f(3) = SAZF-GEQT-7TZM-WNYF-KUS5-OHSD-OEYL-A
f(4) = SAZ2-4UHM-RGBN-H2NA-WUZM-G74L-MYUS-M
f(5) = SA2P-TNKG-ZV4I-R3FD-LRHQ-KNWD-4PWN-Y
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
