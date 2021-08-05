
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  8E FE 66 10  A5 94 81 75  55 E4 09 BE  EB A2 F9 16
~~~~

This has the UDF representation:

R37G-MEFF-SSAX-KVPE-BG7O-XIXZ-CY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 190071288928200631860159323512976374038
a1 = 14009151250881526762711026105093241258
a2 = 192504880386395685081784875462483055914
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 56302953644539380241280617648784459703
f(2) = 307544379133669498785971662709558657196
f(3) = 263230831553714060567483243831762543503
f(4) = 263644677825611529049189968447164330131
f(5) = 308785917949361904231091836555764017080
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 2A 5B 8D  EF A8 8A CE  79 F6 A8 D4  F8 AF 24 C7
  B7
f(2) = 
  31 E7 5E E4  95 1A B5 51  97 DE 4D E9  C4 76 A0 C0
  AC
f(3) = 
  32 C6 08 6A  00 FC 14 0A  CF 0C D3 48  22 42 16 E3
  8F
f(4) = 
  33 C6 58 1E  33 4C A6 FA  1F 82 38 F0  12 11 87 30
  93
f(5) = 
  34 E8 4E 01  2C 0C 6E 1F  89 3E 7E E1  93 E4 F1 A7
  B8
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYC-UW4N-56UI-VTTZ-62UN-J6FP-ETD3-O
f(2) = SAY6-OXXE-SUNL-KUMX-3ZG6-TRDW-UDAK-Y
f(3) = SAZM-MCDK-AD6B-ICWP-BTJU-QISC-C3RY-6
f(4) = SAZ4-MWA6-GNGK-N6Q7-QI4P-AEQR-Q4YJ-G
f(5) = SA2O-QTQB-FQGG-4H4J-HZ7O-DE7E-6GT3-Q
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
