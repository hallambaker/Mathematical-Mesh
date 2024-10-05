
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  3D 02 BC FA  E7 57 6B 0F  69 58 C7 9E  71 EC 33 52
~~~~

This has the UDF representation:

HUBL-Z6XH-K5VQ-62KY-Y6PH-D3BT-KI

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 81097125308239772375056440565556851538
a1 = 275219372461879926758256173645272321813
a2 = 232528580590146051954521985054446197046
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 248562711439327287624459991833507158890
f(2) = 200520724908829979856158298346813437320
f(3) = 277253532637686312533525967537243898335
f(4) = 138478767704957822193188391973030330428
f(5) = 124478797031582972298520179085940945106
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 BA FF 6F  D8 CD B0 34  7B B3 69 C3  E5 83 E6 5B
  6A
f(2) = 
  31 96 DA E3  09 13 0F 23  1F 9E 93 58  C2 4B 98 B5
  88
f(3) = 
  32 D0 95 16  8B B7 74 36  FB 2A D5 86  34 C9 03 41
  DF
f(4) = 
  33 68 2E 0A  60 BA DF 70  0E 58 30 4C  3C FC 26 00
  3C
f(5) = 
  34 5D A5 BE  88 1D 50 CE  59 26 A3 AA  DA E5 00 F0
  D2
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYL-V73P-3DG3-AND3-WNU4-HZMD-4ZNW-U
f(2) = SAYZ-NWXD-BEJQ-6IY7-T2JV-RQSL-TC2Y-Q
f(3) = SAZN-BFIW-RO3X-INX3-FLKY-MNGJ-ANA5-6
f(4) = SAZW-QLQK-MC5N-64AO-LAYE-YPH4-EYAD-Y
f(5) = SA2F-3JN6-RAOV-BTSZ-E2R2-VWXF-ADYN-E
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
