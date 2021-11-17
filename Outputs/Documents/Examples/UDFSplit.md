
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  74 EC 6D C8  2A DA 6A 2F  39 43 2B 86  96 1D 3F 8E
~~~~

This has the UDF representation:

OTWG-3SBK-3JVC-6OKD-FODJ-MHJ7-RY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 155418056211206179145261372319310102414
a1 = 159623714560668388311048344019954446955
a2 = 227538264837278467560108863364488451672
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 202297668688214571553043972271984789534
f(2) = 23689076997902972154295084090099956984
f(3) = 300157014982148307875763922637192027778
f(4) = 10854381878135188327326665617956367395
f(5) = 176628278448679003899107135327697610356
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 98 31 1D  20 BA 4E C6  9C DE 30 5D  C5 9F 82 C8
  1E
f(2) = 
  31 11 D2 59  AB 97 35 37  E8 BF 97 79  24 68 EE FC
  F8
f(3) = 
  32 E1 D0 23  68 C1 8D BE  12 DD 78 7D  A2 F2 61 DE
  82
f(4) = 
  33 08 2A 7A  58 39 58 59  1B 37 D3 6B  41 3B DB 6C
  23
f(5) = 
  34 84 E1 5E  79 FE 95 09  01 CE A8 41  FF 45 5B A6
  74
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYJ-QMI5-EC5E-5RU4-3YYF-3RM7-QLEB-4
f(2) = SAYR-DUSZ-VOLT-KN7I-X6LX-SJDI-536P-Q
f(3) = SAZO-DUBD-NDAY-3PQS-3V4H-3IXS-MHPI-E
f(4) = SAZQ-QKT2-LA4V-QWI3-G7JW-WQJ3-3NWC-G
f(5) = SA2I-JYK6-PH7J-KCIB-Z2UE-D72F-LOTH-I
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
