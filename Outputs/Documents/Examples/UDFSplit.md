
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  A3 88 32 BF  63 22 15 12  B8 D6 3D 6F  C0 90 8A FA
~~~~

This has the UDF representation:

UOED-FP3D-EIKR-FOGW-HVX4-BEEK-7I

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 217371344969441465614046869339119848186
a1 = 145490338483319385036511075297312598268
a2 = 317346143404492428141613439772680848806
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 339925459936314815328796776977345083753
f(2) = 76324760949357630936649741865627382411
f(3) = 107133981850446839364354978867503167174
f(4) = 92070755718643977148537880551204226535
f(5) = 31135082553949044289198446916730560494
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 FF BB 43  20 87 4A 8E  84 51 75 6A  09 2D 5C F9
  69
f(2) = 
  31 39 6B 9D  40 36 6D 0D  1E 96 8D E8  96 38 CB 72
  8B
f(3) = 
  32 50 99 41  1E 70 89 90  E1 88 1F B9  16 E2 DB F6
  C6
f(4) = 
  33 45 44 2E  BB 35 A0 19  CD 26 2A DB  8B 2B 8E 85
  E7
f(5) = 
  34 17 6C 66  16 85 B0 A7  E1 70 AF 4F  F3 12 E3 1F
  EE
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYP-7O2D-ECDU-VDUE-KF2W-UCJN-LT4W-S
f(2) = SAYT-S245-IA3G-2DI6-S2G6-RFRY-ZNZI-W
f(3) = SAZF-BGKB-DZYI-TEHB-RAP3-SFXC-3P3M-M
f(4) = SAZU-KRBO-XM22-AGON-EYVN-XCZL-R2C6-O
f(5) = SA2B-O3DG-C2C3-BJ7B-OCXU-74YS-4MP6-4
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
