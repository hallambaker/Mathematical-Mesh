
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  41 CD AA D2  1B A7 C0 30  BA 16 8A 98  44 A8 7B 76
~~~~

This has the UDF representation:

IHG2-VUQ3-U7AD-BOQW-RKME-JKD3-OY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 87467705238124813652348620107479022454
a1 = 275161588086146334560116511493077273388
a2 = 32506989379145825610271007930194301400
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 54853915782478510359361532098982385735
f(2) = 87254105085123858286916459950874351816
f(3) = 184668273146060857435013403663154920697
f(4) = 6814053044351044340277755804055880871
f(5) = 234256178621871345929458731237113655352
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 29 44 7A  DA 8B 9A C4  3E 80 1D 71  5C 9C BB 18
  47
f(2) = 
  31 41 A4 87  85 25 AF 00  03 64 CC 73  2F 07 B4 D8
  C8
f(3) = 
  32 8A ED D0  D1 E9 E4 73  7F 68 23 90  0F 85 95 BC
  F9
f(4) = 
  33 05 20 56  C0 D8 3B 1E  B2 8A 22 C7  FE 16 5D C4
  A7
f(5) = 
  34 B0 3C 19  51 F0 B3 01  9C CA CA 1A  FA BA 0C F0
  38
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYC-SRD2-3KFZ-VRB6-QAOX-CXE4-XMME-O
f(2) = SAYU-DJEH-QUS2-6AAD-MTGH-GLYH-WTMM-Q
f(3) = SAZI-V3OQ-2HU6-I437-NARZ-AD4F-SW6P-S
f(4) = SAZQ-KICW-YDMD-WHVS-RIRM-P7QW-LXCK-O
f(5) = SA2L-APAZ-KHYL-GAM4-ZLFB-V6V2-BTYD-Q
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
