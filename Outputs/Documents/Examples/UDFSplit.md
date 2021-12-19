
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  D0 E9 D5 13  C5 62 67 C7  FE 81 76 AA  9F 35 F9 28
~~~~

This has the UDF representation:

2DU5-KE6F-MJT4-P7UB-O2VJ-6NPZ-FA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 277693550010969293736378277297256790312
a1 = 193718286828595111178487703517377743884
a2 = 52853058942051233960797472918536052027
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 183982528860677175412288846301402374716
f(2) = 195977625594487525009794361142620063174
f(3) = 313678840212400342528894821820909855686
f(4) = 196803805793477164506215620904503540745
f(5) = 185634889258656454405131365825169329858
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 8A 69 BF  04 30 AE 09  F1 BA C5 60  88 FF 16 22
  3C
f(2) = 
  31 93 6F EA  F2 12 90 1A  F9 BE B6 C6  FA 68 E2 05
  C6
f(3) = 
  32 EB FC 58  DD 6B 08 9A  E0 0A 55 A9  FE DC 99 A3
  C6
f(4) = 
  33 94 0F 08  C6 3A 17 89  A4 9D A2 09  96 5A 3C FC
  09
f(5) = 
  34 8B A7 FA  AC 7F BC E7  47 78 9B E5  C0 E1 CC 0E
  C2
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYI-U2N7-AQYK-4CPR-XLCW-BCH7-CYRD-Y
f(2) = SAYZ-G37K-6IJJ-AGXZ-X23M-N6TI-4IC4-M
f(3) = SAZO-X7CY-3VVQ-RGXA-BJK2-T7W4-TGR4-M
f(4) = SAZZ-IDYI-YY5B-PCNE-TWRA-TFS2-HT6A-S
f(5) = SA2I-XJ72-VR73-ZZ2H-PCN6-LQHB-ZQHM-E
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
