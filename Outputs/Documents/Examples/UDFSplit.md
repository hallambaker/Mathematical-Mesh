
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  2F BA 85 CE  0F 53 44 EB  F5 BC 14 85  69 52 A7 07
~~~~

This has the UDF representation:

F65I-LTQP-KNCO-X5N4-CSCW-SUVH-A4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 63442196903800229039966466513021609735
a1 = 246115659426027064403294183570649366251
a2 = 184637917349608649053967084097639421404
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 153913406758497479033853126749542185883
f(2) = 273378084391473563672299347749573393332
f(3) = 81553862881790019491930522081347020575
f(4) = 259005476071323773419495864608399490626
f(5) = 125168190118197898528246160467194380471
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 73 CA A4  D6 19 39 41  1E F9 3B 3B  0E 59 1C 7B
  9B
f(2) = 
  31 CD AA B4  31 EE 28 65  77 54 9F DE  B7 07 02 7B
  B4
f(3) = 
  32 3D 5A B3  E1 8E 20 B1  F5 07 E9 FF  7F 73 04 A7
  1F
f(4) = 
  33 C2 DA A3  E4 F9 22 26  98 13 19 9D  67 9D 22 FE
  42
f(5) = 
  34 5E 2A 84  3C 2F 2C C3  60 76 2E B8  6F 85 5D 80
  B7
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYH-HSVE-2YMT-SQI6-7E5T-WDSZ-DR5Z-W
f(2) = SAY4-3KVU-GHXC-QZLX-KSP5-5NYH-AJ53-I
f(3) = SAZD-2WVT-4GHC-BMPV-A7U7-673T-ASTR-6
f(4) = SAZ4-FWVD-4T4S-EJUY-CMMZ-2Z45-EL7E-E
f(5) = SA2F-4KUE-HQXS-ZQ3A-OYXL-Q34F-LWAL-O
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
