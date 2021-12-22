
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  C8 09 5F 08  23 23 E1 09  44 CC 67 90  B6 D5 3E B6
~~~~

This has the UDF representation:

ZAEV-6CBD-EPQQ-SRGM-M6IL-NVJ6-WY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 265894257302322985503093545181365223094
a1 = 217623920411790785156716014337062225266
a2 = 29095549309676121621182527171158229231
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 172331360102851428817617479257817466084
f(2) = 136959561522732115374506467676586167536
f(3) = 159778861561965045173760510437671327450
f(4) = 240789260220550218215379607541072945826
f(5) = 39708390577549171035989151555022811157
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 81 A5 D0  0B A8 C5 0A  0A 4A AB CC  91 17 05 C4
  E4
f(2) = 
  31 67 09 73  BA E7 67 A1  87 1C 20 AC  FA 5B 1A CC
  F0
f(3) = 
  32 78 34 4A  15 DF 0B A7  7F B9 2B 08  CC 83 14 56
  DA
f(4) = 
  33 B5 26 53  1C 8F B1 1B  F4 21 CA E0  07 8E F2 62
  A2
f(5) = 
  34 1D DF 8E  CE F9 57 FE  E4 56 00 32  AB 7E B4 F0
  15
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYI-DJOQ-BOUM-KCQK-JKV4-ZEIX-AXCO-I
f(2) = SAYW-OCLT-XLTW-PIMH-DQQK-Z6S3-DLGP-A
f(3) = SAZH-QNCK-CXPQ-XJ37-XEVQ-RTED-CRLN-U
f(4) = SAZ3-KJST-DSH3-CG7U-EHFO-AB4O-6JRK-E
f(5) = SA2B-3X4O-Z34V-P7XE-KYAD-FK36-WTYB-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
