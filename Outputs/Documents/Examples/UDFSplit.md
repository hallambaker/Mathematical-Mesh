
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  75 3A 48 2F  03 87 3E 3F  21 34 B9 5D  67 9F CB 14
~~~~

This has the UDF representation:

OU5E-QLYD-Q47D-6IJU-XFOW-PH6L-CQ

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 155822292782937232189266151757880216340
a1 = 52514224998333021193064981113871493289
a2 = 203474489200375365192337586083394147412
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 71528640060707155111294111523377645534
f(2) = 53901598818289344954622636023895158045
f(3) = 102941169055683801719251725259432753873
f(4) = 218647350772890525405181379229990433018
f(5) = 60737777048971052549036990503799983973
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 35 CF EA  3B F5 D4 C7  7A C7 B6 01  CC AD 82 07
  DE
f(2) = 
  31 28 8D 12  00 96 24 22  0D 88 0E 9C  1E B7 49 ED
  1D
f(3) = 
  32 4D 71 BF  7C E4 75 4D  F7 62 3E 88  53 84 F7 7A
  D1
f(4) = 
  33 A4 7D F2  B0 E0 C8 4B  38 56 45 C6  6B 16 8A B0
  FA
f(5) = 
  34 2D B1 AB  9C 8B 1D 19  D0 64 24 56  65 6C 03 8F
  65
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYD-LT7K-HP25-JR32-Y63A-DTFN-QID5-4
f(2) = SAYS-RDIS-ACLC-IIQN-RAHJ-YHVX-JHWR-2
f(3) = SAZE-24N7-PTSH-KTPX-MI7I-QU4E-655N-C
f(4) = SAZ2-I7PS-WDQM-QSZY-KZC4-M2YW-RKYP-U
f(5) = SA2C-3MNL-TSFR-2GOQ-MQSF-MZLM-AOHW-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
