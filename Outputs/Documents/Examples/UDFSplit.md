
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  0D 55 26 32  A9 A1 5C D1  59 6C 64 9A  33 DF 7D EA
~~~~

This has the UDF representation:

BVKS-MMVJ-UFON-CWLM-MSND-HX35-5I

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 17722083923650473209162416748964576746
a1 = 179939269230698515974348418668894737254
a2 = 322744549631982532444769199226453909629
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 180123535865393058164905427212545012122
f(2) = 307449353229223781083437621265496843742
f(3) = 59417169094204178501384391476051860099
f(4) = 116591717302211177345494952707746484207
f(5) = 138690630932306314152394697528812504559
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 87 82 87  F8 DE C1 14  67 64 A0 D3  5E 2B 07 B1
  9A
f(2) = 
  31 E7 4C 97  71 91 7D 81  25 82 E8 D5  57 66 A4 A5
  DE
f(3) = 
  32 2C B3 54  9C C1 D6 A3  0B B4 44 6A  85 E6 B6 5A
  83
f(4) = 
  33 57 B6 BF  7A 6F CC 7A  19 F8 B3 92  E9 AB 3C CF
  EF
f(5) = 
  34 68 56 D8  0A 9B 5F 06  50 50 36 4E  82 B4 38 05
  EF
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYI-PAUH-7DPM-CFDH-MSQN-GXRL-A6YZ-U
f(2) = SAY6-OTEX-OGIX-3AJF-QLUN-KV3G-USS5-4
f(3) = SAZC-ZM2U-TTA5-NIYL-WRCG-VBPG-WZNI-G
f(4) = SAZV-PNV7-PJX4-Y6QZ-7CZZ-F2NL-HTH6-6
f(5) = SA2G-QVWY-BKNV-6BSQ-KA3E-5AVU-HAC6-6
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
