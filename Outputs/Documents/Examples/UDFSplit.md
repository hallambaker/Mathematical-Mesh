
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  AA 83 97 82  03 70 1C 1E  47 EF CD 01  DC 6E EE BB
~~~~

This has the UDF representation:

ECVI-HF4C-ANYB-YHSH-57GQ-DXDO-525Q

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 226652023116479026575690901801541758651
a1 = 133696476314417612124425336357329019234
a2 = 13062604580310218252465807617106405493
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 33128737090268393489207438344208971871
f(2) = 206013027145616660371030197552857207584
f(3) = 64740159440646900294409964563950042776
f(4) = 289874867817236040186095954241023900461
f(5) = 200852418433507153119338951720542357625
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 18 EC 5C  D8 7A 4C 6A  DB B7 93 4D  A1 11 02 F8
  5F
f(2) = 
  31 9A FC AA  71 4D 76 B5  27 CE BE 85  62 C5 8F D3
  20
f(3) = 
  32 30 B4 80  4C 7C EE FB  02 8D 71 74  46 FA 15 7E
  98
f(4) = 
  33 DA 13 DE  6A 08 B5 3C  6B F3 AC 1A  4D AE 93 FB
  2D
f(5) = 
  34 97 1A C4  C9 F0 C9 79  64 01 6E 77  76 E3 0B 48
  79
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYB-R3C4-3B5E-Y2W3-W6JU-3IIR-AL4F-6
f(2) = SAYZ-V7FK-OFGX-NNJH-Z27I-KYWF-R7JS-A
f(3) = SAZD-BNEA-JR6O-56YC-RVYX-IRX2-CV7J-Q
f(4) = SAZ5-UE66-NIEL-KPDL-6OWB-UTNO-SP5S-2
f(5) = SA2J-OGWE-ZHYM-S6LE-AFXH-O5XD-BNEH-S
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
