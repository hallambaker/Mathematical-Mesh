
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  D3 C2 A4 20  C5 0B F0 27  C1 72 25 73  3C 8E 33 82
~~~~

This has the UDF representation:

2PBK-IIGF-BPYC-PQLS-EVZT-ZDRT-QI

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 281477741612632184293185428372398683010
a1 = 296753219287990509327378646195085950469
a2 = 84637674981802937864103081676657277166
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 322586268961487168021292548812373699138
f(2) = 192687779353009564014231225173895058091
f(3) = 232064639708137835735376064888730971376
f(4) = 100434483105933519721352460525113227486
f(5) = 138079676467335079435535019514810037928
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 F2 AF DB  02 51 36 B1  C0 7A 13 23  1E 4C 33 2A
  42
f(2) = 
  31 90 F6 51  00 BA 21 16  FC CC 02 EB  D1 02 1C 92
  AB
f(3) = 
  32 AE 96 06  1B FF CB 1F  DC B7 41 7F  8B 5E 4A 6C
  F0
f(4) = 
  33 4B 8E FA  54 22 34 CC  60 3B CE DE  4D 60 BC B8
  DE
f(5) = 
  34 67 E1 2D  A9 21 5E 1C  87 59 AB 08  17 09 73 76
  A8
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYP-FL63-AJIT-NMOA-PIJS-GHSM-GMVE-E
f(2) = SAYZ-B5SR-AC5C-CFX4-ZQBO-XUIC-DSJK-W
f(3) = SAZK-5FQG-DP74-WH64-W5AX-7C26-JJWP-A
f(4) = SAZU-XDX2-KQRD-JTDA-HPHN-4TLA-XS4N-4
f(5) = SA2G-PYJN-VEQV-4HEH-LGVQ-QFYJ-ON3K-Q
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
