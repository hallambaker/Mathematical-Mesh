
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  DA BB A6 A8  D6 8A 56 2E  57 F6 C8 F1  EE CF 9C 86
~~~~

This has the UDF representation:

3K52-NKGW-RJLC-4V7W-ZDY6-5T44-QY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 290746042850380212476545125094106569862
a1 = 103291203886022489505603384781504805601
a2 = 296633763028811638391287643954538015541
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 10106275923337413446686938966612967990
f(2) = 322734035053917891199404040748195397200
f(3) = 207782219479306255344572608143549222971
f(4) = 5533196120440969345567248584442656810
f(5) = 56269331898260496665762569502643910224
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 07 9A 65  DF 92 A0 28  31 FD FD C0  5F B0 AF 02
  36
f(2) = 
  31 F2 CC 50  70 9C BA 1B  74 97 A5 81  E0 E9 94 3E
  50
f(3) = 
  32 9C 51 66  5B F4 D8 2F  F6 24 EE 0D  75 99 7F 50
  3B
f(4) = 
  33 04 29 A7  A1 9A FA 65  B6 A5 D7 63  1D C0 70 38
  2A
f(5) = 
  34 2A 55 14  41 8F 20 BC  B6 1A 61 82  D9 5E 66 F6
  50
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYA-PGTF-36JK-AKBR-7X64-AX5Q-V4BD-M
f(2) = SAY7-FTCQ-OCOL-UG3U-S6SY-DYHJ-SQ7F-A
f(3) = SAZJ-YULG-LP2N-QL7W-ETXA-25MZ-P5ID-W
f(4) = SAZQ-IKNH-UGNP-UZNW-UXLW-GHOA-OA4C-U
f(5) = SA2C-UVIU-IGHS-BPFW-DJQY-FWK6-M33F-A
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
