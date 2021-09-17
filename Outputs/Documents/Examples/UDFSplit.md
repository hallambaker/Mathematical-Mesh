
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  E4 F0 2A 14  8E 97 97 8B  19 E9 90 3B  23 CD 64 25
~~~~

This has the UDF representation:

4TYC-UFEO-S6LY-WGPJ-SA5S-HTLE-EU

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 304310987774905916145056216948918805541
a1 = 247206160897509953743237989584623599711
a2 = 306518111500905843417973326460872729267
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 177470526331444786379518318130878711505
f(2) = 323383920968856879986552464802815864496
f(3) = 61486437845265270039409442101193841500
f(4) = 72342810802546883464838464889549065531
f(5) = 15670672919763256799464925736113325082
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 85 83 94  80 D4 78 B9  CC 83 DF A5  B5 13 F7 86
  D1
f(2) = 
  31 F3 49 7A  4A 12 12 EC  C1 C8 70 22  05 59 46 EE
  B0
f(3) = 
  32 2E 41 DB  70 47 66 30  6A E7 9B 05  2B F3 BB 9B
  5C
f(4) = 
  33 36 6C B7  F3 74 72 84  C7 E1 60 4F  28 E3 55 8D
  3B
f(5) = 
  34 0B CA 0F  D3 99 37 E9  D8 B5 BF FF  FC 28 14 C4
  1A
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYI-LA4U-QDKH-ROOM-QPP2-LNIT-66DN-C
f(2) = SAY7-GSL2-JIJB-F3GB-ZBYC-EBKZ-I3XL-A
f(3) = SAZC-4QO3-OBDW-MMDK-46NQ-KK7T-XONV-Y
f(4) = SAZT-M3FX-6N2H-FBGH-4FQE-6KHD-KWGT-W
f(5) = SA2A-XSQP-2OMT-P2OY-WW77-77BI-CTCB-U
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
