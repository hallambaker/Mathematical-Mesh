
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  E9 BA 5A 1B  18 07 23 7D  B1 59 BD D4  F2 DA 29 08
~~~~

This has the UDF representation:

5G5F-UGYY-A4RX-3MKZ-XXKP-FWRJ-BA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 310677717797033863178867935485697337608
a1 = 32602509232022251880115580139771310780
a2 = 245600100132723195785373117688628955562
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 248597960240840847380982025882329392443
f(2) = 337436036029155759690467744224451146895
f(3) = 236909578241040136643950483080294389457
f(4) = 287300953797432441704804849881627331636
f(5) = 148327795777394211409656237196681761925
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 BB 06 39  BF 3A 1B F3  92 F2 26 38  C2 18 4B A5
  3B
f(2) = 
  31 FD DB D1  0D 60 DE 93  DB 70 3D E9  94 D3 0E B4
  8F
f(3) = 
  32 B2 3B 20  05 8C 4F 04  57 2B A0 D0  4D 23 23 56
  D1
f(4) = 
  33 D8 24 26  A7 BC 6D 45  06 24 4E EC  EB 08 89 8C
  34
f(5) = 
  34 6F 96 E4  F3 F1 39 55  E8 5A 48 3F  6E 83 41 54
  85
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYL-WBRZ-X45B-X44S-6ITD-RQQY-JOST-W
f(2) = SAY7-3W6R-BVQN-5E63-OA66-TFGT-B22I-6
f(3) = SAZL-EOZA-AWGE-6BCX-FOQN-ATJD-ENLN-C
f(4) = SAZ5-QJBG-U66G-2RIG-ERHO-Z2YI-RGGD-I
f(5) = SA2G-7FXE-6PYT-SVPI-LJED-63UD-IFKI-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
