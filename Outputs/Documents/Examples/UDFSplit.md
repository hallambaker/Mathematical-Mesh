
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  17 36 E7 2C  94 04 21 81  2D A2 B7 36  DF DA 67 5A
~~~~

This has the UDF representation:

C43O-OLEU-AQQY-CLNC-W43N-7WTH-LI

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 30857316701880315310076836138242959194
a1 = 27922516948236239535551394922970180897
a2 = 289544291787349618228726950396054195628
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 8041758516527709610980574025499124212
f(2) = 224032416984935876905963605273095468979
f(3) = 338546925186166353731651322449263781988
f(4) = 11302916199280676624669118122235851732
f(5) = 263147490787094235975140814587316312732
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 06 0C C9  4E 72 58 EA  FF C5 24 A8  9D 7E 41 A1
  F4
f(2) = 
  31 A8 8B 12  F4 2F 76 94  81 7C F8 79  FF 49 90 77
  B3
f(3) = 
  32 FE B1 C4  1D CB 5D 1E  06 55 1E 2B  5C 41 C6 E8
  64
f(4) = 
  33 08 80 DC  CB 46 0C 87  8E 4D 95 BC  B4 66 E4 F3
  D4
f(5) = 
  34 C5 F8 5C  FC 9F 84 D1  19 66 5F 2E  07 B8 EA 9A
  9C
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYA-MDGJ-JZZF-R2X7-YUSK-RHL6-IGQ7-I
f(2) = SAY2-RCYS-6QXX-NFEB-PT4H-T72J-SB33-G
f(3) = SAZP-5MOE-DXFV-2HQG-KUPC-WXCB-Y3UG-I
f(4) = SAZQ-RAG4-ZNDA-ZB4O-JWK3-ZNDG-4TZ5-I
f(5) = SA2M-L6C4-7SPY-JUIZ-MZPS-4B5Y-5KNJ-Y
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
