
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  B2 75 91 26  DB D7 9B 62  B6 0C 77 BE  C4 D5 FD 1B
~~~~

This has the UDF representation:

WJ2Z-CJW3-26NW-FNQM-O67M-JVP5-DM

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 237213026010264175233467496524212993307
a1 = 92364685514750155803847109818989989510
a2 = 57856791765874975977099829344640712371
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 47152136369950843551039828256075483681
f(2) = 313087197182325927286186426108987610304
f(3) = 14171107684574036048783467787644738655
f(4) = 171250968639510560228954775587351503255
f(5) = 103762046205258572899951134644571481090
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 23 79 2B  CF AD AF D5  61 97 19 EE  C7 BE 83 0A
  21
f(2) = 
  31 EB 8A 66  9C 84 8A EB  B9 ED DA 82  F8 AF 28 94
  C0
f(3) = 
  32 0A A9 41  8D 60 68 DE  6B BA 4E 34  51 96 C6 9C
  5F
f(4) = 
  33 80 D5 BC  A2 41 49 AD  76 FC 75 02  D2 75 5D 21
  97
f(5) = 
  34 4E 0F D7  DB 27 2D 58  DB B4 4E EE  7B 4A EC 24
  02
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYC-G6JL-Z6W2-7VLB-S4M6-5R56-QMFC-C
f(2) = SAY6-XCTG-TSCI-V25Z-5XNI-F6FP-FCKM-A
f(3) = SAZA-VKKB-RVQG-RXTL-XJHD-IUMW-Y2OF-6
f(4) = SAZY-BVN4-UJAU-TLLW-7R2Q-FUTV-LUQZ-O
f(5) = SA2E-4D6X-3MTS-2WG3-WRHO-462K-5QSA-E
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
