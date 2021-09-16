
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  02 A6 E7 D1  AC 1C 22 9A  FE FC 93 12  06 88 58 3E
~~~~

This has the UDF representation:

AKTO-PUNM-DQRJ-V7X4-SMJA-NCCY-HY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 3525079118656457181111454019099318334
a1 = 253192157042930076940661272453443474553
a2 = 226866878844392544020443375219387468370
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 143301748085040614678841494260162049750
f(2) = 56247440898332933290709070076463294892
f(3) = 82644524479471876480088788899771265267
f(4) = 222492998828457444246980650730085960875
f(5) = 135510497024351173128010048135639170209
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 6B CE E9  AB 6D 07 8E  65 F7 4F E5  72 B0 15 36
  D6
f(2) = 
  31 2A 50 DC  F2 4B 77 41  CA 88 12 8F  B8 E4 DC 29
  AC
f(3) = 
  32 3E 2C C1  A6 47 6B 3C  C8 B1 44 91  E4 A4 DD 30
  F3
f(4) = 
  33 A7 62 97  C7 60 E3 7F  60 72 E5 EB  F5 F0 18 4C
  AB
f(5) = 
  34 65 F2 5F  55 97 E0 09  91 CC F6 9D  EC C6 8D 7C
  A1
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYG-XTXJ-VNWQ-PDTF-65H6-K4VQ-CU3N-M
f(2) = SAYS-UUG4-6JFX-OQOK-RAJI-7OHE-3QU2-Y
f(3) = SAZD-4LGB-UZDW-WPGI-WFCJ-DZFE-3UYP-G
f(4) = SAZ2-OYUX-Y5QO-G73A-OLS6-X5PQ-DBGK-W
f(5) = SA2G-L4S7-KWL6-ACMR-ZT3J-33GG-RV6K-C
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
