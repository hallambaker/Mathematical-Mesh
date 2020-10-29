
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  55 75 D5 BF  D8 23 0F 13  27 14 A8 BA  75 06 BF 70
~~~~

This has the UDF representation:

KV25-LP6Y-EMHR-GJYU-VC5H-KBV7-OA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 113596213726882187773548937822387748720
a1 = 78568159714620383690019947087775415691
a2 = 126375286575627730271646076120517679023
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 318539660017130301735214961030680843434
f(2) = 95668945616756949313423921616472873180
f(3) = 125548804367639057434925034443300260972
f(4) = 67896869348838162636343692079394795303
f(5) = 262995507481292728381054501956524687680
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 EF A4 81  C8 CC 6B 05  60 B1 A5 C9  F1 A6 84 94
  AA
f(2) = 
  31 47 F9 2B  30 A7 03 4E  2A C5 E8 35  AC B6 DD 98
  DC
f(3) = 
  32 5E 73 D1  F7 67 EB E9  71 63 DB EB  EB A6 11 CC
  6C
f(4) = 
  33 33 14 76  1D 0F 24 D7  34 8B 80 EC  AE 74 21 2F
  27
f(5) = 
  34 C5 DB 17  A1 9C AE 17  74 3C D7 37  F5 21 0B C1
  40
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYO-7JEB-ZDGG-WBLA-WGS4-T4NG-QSKK-U
f(2) = SAYU-P6JL-GCTQ-GTRK-YXUD-LLFW-3WMN-Y
f(3) = SAZF-446R-65T6-X2LR-MPN6-X25G-CHGG-Y
f(4) = SAZT-GFDW-DUHS-JVZU-ROAO-ZLTU-EEXS-O
f(5) = SA2M-LWYX-UGOK-4F3U-HTLT-P5JB-BPAU-A
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
