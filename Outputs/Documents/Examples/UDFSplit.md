
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  FE B7 7B B6  28 58 7A D7  C1 02 52 62  6C DC FF 40
~~~~

This has the UDF representation:

723X-XNRI-LB5N-PQIC-KJRG-ZXH7-IA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 338576610422873697898808206918957203264
a1 = 9810947393023848162671550368158365593
a2 = 98701729114982871224943669938563913726
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 106806920009941953823048819793911271076
f(2) = 72440687826975952197176772545993166340
f(3) = 235477913873975693021192065175202889056
f(4) = 255636231230002712831720090249772227717
f(5) = 132915639895057011628760847769701182323
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 50 5A 43  B9 A5 86 03  9A D1 A7 FA  0F E3 32 CE
  A4
f(2) = 
  31 36 7F 91  A9 2F 30 9F  97 53 1E C4  A3 DB EA CE
  04
f(3) = 
  32 B1 27 65  84 C5 58 4E  CD 45 66 B2  1E 57 04 FD
  60
f(4) = 
  33 C0 51 BF  4C 67 FD 11  3C A8 7F C2  7F 54 81 5C
  85
f(5) = 
  34 63 FE 9F  00 17 1E E6  E5 7C 69 F5  C6 D4 5F EB
  73
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYF-AWSD-XGSY-MA42-2GT7-UD7D-GLHK-I
f(2) = SAYT-M74R-VEXT-BH4X-KMPM-JI63-5LHA-I
f(3) = SAZL-CJ3F-QTCV-QTWN-IVTL-EHSX-AT6W-A
f(4) = SAZ4-AUN7-JRT7-2EJ4-VB74-E72U-QFOI-K
f(5) = SA2G-H7U7-AALR-5ZXF-PRU7-LRWU-L7VX-G
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
