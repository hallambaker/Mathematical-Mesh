
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  93 60 E6 AB  F9 85 D4 0B  12 F0 D9 01  5A BF 28 5F
~~~~

This has the UDF representation:

SNQO-NK7Z-QXKA-WEXQ-3EAV-VPZI-L4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 195899654458250162518094852127857780831
a1 = 272348556613757547488969567029394350054
a2 = 315298294335899644923872588610537051856
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 102981771566030428004187792904252759727
f(2) = 300378110424671519874651303469953630828
f(3) = 107523937192296511202736168961423971120
f(4) = 204983985710782328915191604242200203617
f(5) = 252475889059190509548643001880514116812
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 4D 79 91  58 9F 19 04  7C DF BF DE  F8 24 63 1E
  AF
f(2) = 
  31 E1 FA B8  41 92 28 C6  94 3A D5 88  72 B0 58 C2
  6C
f(3) = 
  32 50 E4 5B  66 D2 B5 1A  51 24 31 D5  70 FE A0 13
  30
f(4) = 
  33 9A 36 7A  C8 60 BD FF  B3 9B D4 C5  F3 0F 39 11
  61
f(5) = 
  34 BD F1 16  66 3C 43 76  BB A1 BE 59  F8 E2 23 BC
  CC
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYE-26MR-LCPR-SBD4-3675-56BE-MMPK-6
f(2) = SAY6-D6VY-IGJC-RRUU-HLKY-Q4VQ-LDBG-Y
f(3) = SAZF-BZC3-M3JL-KGSR-EQY5-K4H6-UAJT-A
f(4) = SAZZ-UNT2-ZBQL-375T-TPKM-L4YP-HEIW-C
f(5) = SA2L-34IW-MY6E-G5V3-UG7F-T6HC-EO6M-Y
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
