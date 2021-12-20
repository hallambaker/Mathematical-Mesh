
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  91 F9 C1 35  F8 95 2E ED  A8 2B 52 D1  B5 6C 63 12
~~~~

This has the UDF representation:

SH44-CNPY-SUXO-3KBL-KLI3-K3DD-CI

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 194034860087666725674628416150589694738
a1 = 337244113635675674053610390557053262707
a2 = 238771936248653926132727666347242721764
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 89486176130119398934217258191349256195
f(2) = 122198997748941460995886825494826049673
f(3) = 292173324944132911859637118061020075172
f(4) = 259126790794755288062093528458163121185
f(5) = 23059395300808589603256056686255187712
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 43 52 69  1E 82 24 49  B7 DE 2D AC  3D 02 82 90
  03
f(2) = 
  31 5B EE AB  BF B3 87 72  99 8C 6F BE  FC 53 09 E0
  89
f(3) = 
  32 DB CE 89  19 8C BE A9  92 B2 F1 8B  0F A7 02 54
  A4
f(4) = 
  33 C2 F2 01  2C 0D C9 EE  A3 51 B3 10  76 FE 6B EC
  21
f(5) = 
  34 11 59 13  F7 36 A9 41  CB 68 B4 4F  32 59 46 A7
  00
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYE-GUTJ-D2BC-ISNX-3YW2-YPIC-QKIA-G
f(2) = SAYV-X3VL-X6ZY-O4UZ-RRX3-57CT-BHQI-S
f(3) = SAZN-XTUJ-DGGL-5KMS-WLYY-WD5H-AJKK-I
f(4) = SAZ4-F4QB-FQG4-T3VD-KGZR-A5X6-NPWC-C
f(5) = SA2B-CWIT-643K-SQOL-NC2E-6MSZ-I2TQ-A
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
