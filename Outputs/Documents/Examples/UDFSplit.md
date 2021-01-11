
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  7B F3 E8 0F  BB C5 E1 50  AC 9F 08 A7  AE 07 55 D8
~~~~

This has the UDF representation:

PPZ6-QD53-YXQV-BLE7-BCT2-4B2V-3A

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 164761478383732019626097050265921738200
a1 = 46841092629178117160030855269034239208
a2 = 260933840733645743442894509428057409755
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 132254044825617416765647807531245175656
f(2) = 281331925813855837327612976220915221115
f(3) = 271712754427508817848617948903163663070
f(4) = 103396530666576358328662725577990501521
f(5) = 116665621451996922231121913677163947975
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 63 7F 33  D8 53 0D CB  83 D4 82 3B  59 21 85 03
  68
f(2) = 
  31 D3 A6 8E  DA A4 34 35  DC CC 47 E7  04 80 45 C2
  7B
f(3) = 
  32 CC 69 F9  16 AF 39 20  5B 93 F0 0B  A9 CA 49 92
  DE
f(4) = 
  33 4D C9 72  8C 74 1C 8B  00 2B 7A A9  48 FF 90 74
  91
f(5) = 
  34 57 C4 FB  3B F2 DE 75  CA 92 E7 BF  E2 20 1A 67
  C7
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYG-G7ZT-3BJQ-3S4D-2SBD-WWJB-QUBW-Q
f(2) = SAY5-HJUO-3KSD-INO4-ZRD6-OBEA-IXBH-W
f(3) = SAZM-Y2PZ-C2XT-SIC3-SPYA-XKOK-JGJN-4
f(4) = SAZU-3SLS-RR2B-ZCYA-FN5K-SSH7-SB2J-C
f(5) = SA2F-PRH3-HPZN-45OK-SLT3-7YRA-DJT4-O
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
