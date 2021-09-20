
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  83 73 92 A9  AA FD 46 ED  64 D0 46 10  12 52 03 B6
~~~~

This has the UDF representation:

QNZZ-FKNK-7VDO-2ZGQ-IYIB-EUQD-WY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 174728956260835727429022374024732345270
a1 = 205194409052494194859746872120286191144
a2 = 233493972040959208968218444750573006299
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 273134970433350667793613083463823331206
f(2) = 157964194845907099167891467540523906726
f(3) = 169498996419443485015232133686602283337
f(4) = 307739375153959825335635081902058461039
f(5) = 232402964128517656665725704755124228325
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 CD 7B E1  C0 60 88 1B  B4 5E 5C A5  FF 14 7F 0F
  86
f(2) = 
  31 76 D6 CC  1B D1 83 40  5A 01 F3 84  A8 3E D3 F6
  A6
f(3) = 
  32 7F 84 51  BB FD EE B4  DE 4F 94 E2  0B 91 50 B9
  49
f(4) = 
  33 E7 84 72  A0 E5 CA 79  41 47 40 BE  29 0B F5 57
  6F
f(5) = 
  34 AE D7 2E  CA 89 16 8D  82 E8 F7 19  00 AE C1 D0
  E5
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYM-267B-YBQI-QG5U-LZOK-L7YU-P4HY-M
f(2) = SAYX-NVWM-DPIY-GQC2-AHZY-JKB6-2P3K-M
f(3) = SAZH-7BCR-XP66-5NG6-J6KO-EC4R-KC4U-S
f(4) = SAZ6-PBDS-UDS4-U6KB-I5AL-4KIL-6VLW-6
f(5) = SA2K-5VZO-ZKER-NDMC-5D3R-SAFO-YHIO-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
