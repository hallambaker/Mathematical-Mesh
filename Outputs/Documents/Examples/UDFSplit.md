
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  7F CF 1C 10  4D 1A B2 2B  24 D6 34 A1  BB 96 C1 7C
~~~~

This has the UDF representation:

P7HR-YECN-DKZC-WJGW-GSQ3-XFWB-PQ

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 169887330113383146857542444931823878524
a1 = 37294686720900876459020772411743700562
a2 = 173493291019521638779124509862741131686
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 40392940932867198632313119774540499265
f(2) = 257885133791394527965332814342739383378
f(3) = 141799174847088207929852313772884107849
f(4) = 32417431020886701989246225496742884185
f(5) = 270022269233728473606889156946083923893
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 1E 63 65  BF 2E 73 5A  BF 82 C8 9F  CD F7 43 09
  41
f(2) = 
  31 C2 02 DE  C1 5F 1D 38  CE 76 79 77  AC CC 76 D4
  52
f(3) = 
  32 6A AD 87  16 DF 18 4C  57 FF E8 BC  3E 3B 32 22
  49
f(4) = 
  33 18 63 5E  BF AE 64 95  5C 1F 16 6D  82 43 74 F3
  59
f(5) = 
  34 CB 24 65  BB CD 02 13  DA D4 02 8B  78 E5 3F 47
  B5
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYB-4Y3F-X4XH-GWV7-QLEJ-7TPX-IMEU-C
f(2) = SAY4-EAW6-YFPR-2OGO-OZ4X-PLGM-O3KF-E
f(3) = SAZG-VLMH-C3PR-QTCX-77UL-YPR3-GIRE-S
f(4) = SAZR-QY26-X6XG-JFK4-D4LG-3ASD-OTZV-S
f(5) = SA2M-WJDF-XPGQ-EE62-2QBI-W6HF-H5D3-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
