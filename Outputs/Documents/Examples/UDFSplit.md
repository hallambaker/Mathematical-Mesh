
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  04 92 B2 37  19 DE 0E B9  AC 4B 57 C6  55 8E 40 7F
~~~~

This has the UDF representation:

ASJL-ENYZ-3YHL-TLCL-K7DF-LDSA-P4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 6078601958949712922936312474165461119
a1 = 117166784636767025760218567433827692720
a2 = 46883414245760629885709817330968978165
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 170128800841477368568864697238962132004
f(2) = 87663461294587820522838109233928547712
f(3) = 98964950239219532248231155890832919750
f(4) = 204033267675372503745043837209675248118
f(5) = 62586046682108271549901545758687321309
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 7F FD 9D  7D 60 25 4C  C4 9B 14 F1  1D 47 79 54
  24
f(2) = 
  31 41 F3 5E  56 E8 0F C9  2C BA 80 27  06 A8 B1 2D
  80
f(3) = 
  32 4A 73 F4  C3 B1 9D 83  F2 0A 8C F9  82 79 35 CC
  C6
f(4) = 
  33 99 7F 60  C3 BC CE 7D  14 8B 3B 68  90 B9 07 31
  F6
f(5) = 
  34 2F 15 A2  57 09 A2 B4  94 3C 8B 74  31 68 25 5C
  DD
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYH-77M5-PVQC-KTGE-TMKP-CHKH-PFKC-I
f(2) = SAYU-D426-K3UA-7SJM-XKAC-OBVI-WEWY-A
f(3) = SAZE-U47U-YOYZ-3A7S-BKGP-TATZ-GXGM-M
f(4) = SAZZ-S73A-YO6M-47IU-RM5W-REFZ-A4Y7-M
f(5) = SA2C-6FNC-K4E2-FNEU-HSFX-IMLI-EVON-2
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
