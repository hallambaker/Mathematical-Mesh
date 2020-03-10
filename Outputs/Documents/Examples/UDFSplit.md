
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  C7 D4 B4 F3  0D 4E 64 F6  51 6C 4E 1B  DD 82 38 ED
~~~~

This has the UDF representation:

EDD5-JNHT-BVHG-J5SR-NRHB-XXMC-HDWQ

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 265620808185497868554038322316259244269
a1 = 301181837366687588944898329970885393917
a2 = 314886648144000321334531819818775329340
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 201124559854308851906719257242383544512
f(2) = 85836873969243551001714616942522080421
f(3) = 260040117451240429302399008848443063503
f(4) = 43169556458422559882023218096610070744
f(5) = 115789924832666869667336459550559525158
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 97 4F 2E  65 94 E1 46  4F A8 64 69  35 8C 2D F0
  C0
f(2) = 
  31 40 93 94  A1 9C 8B EA  A1 52 AA EC  CE BE 45 1C
  A5
f(3) = 
  32 C3 A1 E7  A7 24 4E 51  EB 50 3F D8  E7 73 C7 BC
  CF
f(4) = 
  33 20 7A 27  76 2C 28 7C  2D A1 23 2D  7F AC B5 D0
  D8
f(5) = 
  34 57 1C 54  0E B4 1A 69  68 45 54 EA  97 69 0F 59
  26
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYJ-OTZO-MWKO-CRSP-VBSG-SNMM-FXYM-A
f(2) = SAYU-BE4U-UGOI-X2VB-KKVO-ZTV6-IUOK-K
f(3) = SAZM-HIPH-U4SE-4UPL-KA75-RZ3T-Y66M-6
f(4) = SAZS-A6RH-OYWC-Q7BN-UERS-275M-WXIN-Q
f(5) = SA2F-OHCU-B22B-U2LI-IVKO-VF3J-B5MS-M
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
