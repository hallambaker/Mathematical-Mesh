
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  B7 09 B0 9C  F8 6F 7C 58  CB E4 6C 1D  B1 AC 5A 8F
~~~~

This has the UDF representation:

W4E3-BHHY-N56F-RS7E-NQO3-DLC2-R4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 243299036040937073522404887771113872015
a1 = 181818669924433089445047362467436105976
a2 = 245535397126762237299404847959967359575
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 330370736171193936803482490766749126059
f(2) = 227948496713098347756620574818782676239
f(3) = 276314684587588769845193747358982734062
f(4) = 135186932873726739605827400955581088021
f(5) = 144847608492450720501896143040345949623
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 F8 8B 16  DF E9 A2 E5  C1 A6 3D 60  29 28 28 CD
  AB
f(2) = 
  31 AB 7D 48  97 5F B2 81  C0 58 16 8D  EF 5E 48 05
  0F
f(3) = 
  32 CF E0 45  C3 5A 9E 50  54 E1 6F F5  70 54 0A 00
  EE
f(4) = 
  33 65 B4 0E  63 DA 66 51  7F 42 49 96  AC 09 6E C1
  15
f(5) = 
  34 6C F8 A2  78 DF 0A 85  3F 7A A3 71  A2 7E 76 45
  B7
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYP-RCYW-37U2-FZOB-UY6W-AKJI-FDG2-W
f(2) = SAY2-W7KI-S5P3-FAOA-LALI-3326-JACQ-6
f(3) = SAZM-7YCF-YNNJ-4UCU-4FX7-K4CU-BIAO-4
f(4) = SAZW-LNAO-MPNG-MUL7-IJEZ-NLAJ-N3AR-K
f(5) = SA2G-Z6FC-PDPQ-VBJ7-PKRX-DIT6-OZC3-O
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
