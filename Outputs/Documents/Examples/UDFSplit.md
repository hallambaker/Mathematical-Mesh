
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  12 0A C3 1B  FF 09 CD 86  CD 3E 6B 4B  CF BA 91 8D
~~~~

This has the UDF representation:

CIFM-GG77-BHGY-NTJ6-NNF4-7OUR-RU

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 23981984180677462358025211329449202061
a1 = 217449633820028444820075594055263988236
a2 = 299283543253615188179136358544176182525
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 200432794333382631893862556497121161315
f(2) = 294885957151441250861223403889609062605
f(3) = 307341472634853319260107753506912905931
f(4) = 237799340783618837090515605349032691293
f(5) = 86259561597737804352446959415968418691
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 96 C9 F3  B9 2E 52 75  AE C9 C5 75  B1 93 D0 B0
  63
f(2) = 
  31 DD D8 F8  31 86 F7 0B  B9 E2 74 52  07 3E 2A B8
  CD
f(3) = 
  32 E7 37 D0  85 08 F7 8F  A8 17 4B 00  4C CE C8 AA
  CB
f(4) = 
  33 B2 E6 7C  B3 B4 54 01  79 68 49 80  82 45 AA 86
  5D
f(5) = 
  34 40 E4 FC  BD 89 0C 61  2D D5 6F D2  A7 A2 D0 4B
  83
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYJ-NSPT-XEXF-E5NO-ZHCX-LMMT-2CYG-G
f(2) = SAY5-3WHY-GGDP-OC5Z-4J2F-EBZ6-FK4M-2
f(3) = SAZO-ON6Q-QUEP-PD5I-C5FQ-ATGO-ZCVM-W
f(4) = SAZ3-FZT4-WO2F-IALZ-NBEY-BASF-VKDF-2
f(5) = SA2E-BZH4-XWEQ-YYJN-2VX5-FJ5C-2BFY-G
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
