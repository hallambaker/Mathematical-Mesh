
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  8F EA EB EB  5C 1E 06 73  B3 69 49 7A  33 1F 84 66
~~~~

This has the UDF representation:

R7VO-X224-DYDH-HM3J-JF5D-GH4E-MY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 191299385875524087631644103734934340710
a1 = 93000484550467220873947456871563255800
a2 = 267783629521051905228114550698647171398
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 211801133026104750270331503873376556401
f(2) = 87305405376912296438498790545576691874
f(3) = 158094569848885189599520571183302958636
f(4) = 83886259521084966290022238354787145180
f(5) = 204962841314450089973378399491797463013
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 9F 57 6A  18 69 B6 A0  9F BA B7 5E  17 32 7E 95
  71
f(2) = 
  31 41 AE 68  D1 DC 70 B5  99 C5 98 E4  79 24 84 08
  A2
f(3) = 
  32 76 EF E8  17 B4 4C 45  61 D4 0D DC  A0 09 2F DE
  2C
f(4) = 
  33 3F 1B E7  E9 F1 49 4F  F7 E6 16 46  8B E0 82 15
  DC
f(5) = 
  34 9A 32 68  48 93 67 D5  5B FB B2 22  3C AA 7A AF
  E5
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYJ-6V3K-DBU3-NIE7-XK3V-4FZS-P2KX-C
f(2) = SAYU-DLTI-2HOH-BNMZ-YWMO-I6JE-QQEK-E
f(3) = SAZH-N37I-C62E-YRLB-2QG5-ZIAJ-F7PC-Y
f(4) = SAZT-6G7H-5HYU-ST7X-4YLE-NC7A-QIK5-Y
f(5) = SA2J-UMTI-JCJW-PVK3-7OZC-EPFK-PKX6-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
