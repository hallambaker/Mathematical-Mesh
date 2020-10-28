
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  1D D7 85 62  F3 46 C4 5B  77 87 56 23  88 C7 F9 78
~~~~

This has the UDF representation:

DXLY-KYXT-I3CF-W54H-KYRY-RR7Z-PA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 39666661102475169789473107034010810744
a1 = 107955667541116186020847827976784513231
a2 = 290779403423885097103134981792870250821
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 98119365146537989450081309371897363289
f(2) = 57566142196494076390210260431987994462
f(3) = 258289359173281894073234567646050915770
f(4) = 19724282235024515572405016150549704199
f(5) = 22435645223598867814470820809020782763
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 49 D1 1A  33 58 EB 7C  F8 25 86 C9  A0 FB C2 3B
  59
f(2) = 
  31 2B 4E D5  F0 B0 FA AA  04 A0 04 36  F8 9E CE EF
  5E
f(3) = 
  32 C2 50 B8  9A FB 74 4B  80 E6 FF 9E  2A 71 EE 15
  BA
f(4) = 
  33 0E D6 C2  32 38 58 61  6C FA 78 FF  36 75 1F AE
  07
f(5) = 
  34 10 E0 F2  B6 67 A6 EB  C8 DA 70 5A  1C A8 63 B8
  AB
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYE-TUI2-GNMO-W7HY-EWDM-TIH3-YI5V-S
f(2) = SAYS-WTWV-6CYP-VKQE-UACD-N6E6-Z3XV-4
f(3) = SAZM-EUFY-TL5X-IS4A-437Z-4KTR-5YK3-U
f(4) = SAZQ-5VWC-GI4F-QYLM-7J4P-6NTV-D6XA-O
f(5) = SA2B-BYHS-WZT2-N26I-3JYF-UHFI-MO4K-W
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
