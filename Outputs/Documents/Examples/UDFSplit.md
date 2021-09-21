
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  BF 4F 47 D4  BE 7A 98 3E  B8 98 A3 A8  45 8F 51 7F
~~~~

This has the UDF representation:

X5HU-PVF6-PKMD-5OEY-UOUE-LD2R-P4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 254294195553145855172674365825355829631
a1 = 57172405974899503986703232137671673432
a2 = 59295943197195553259219963450162663766
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 30480177804302448955222953981421955322
f(2) = 265540413370788612719586076469581620052
f(3) = 278910168410727419539014518426298400807
f(4) = 70589442924118869413508279851572297587
f(5) = 321142970752839889269816575608939733406
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 16 EE 44  CA 76 C8 19  0A C6 5A 17  20 D7 F6 28
  FA
f(2) = 
  31 C7 C5 39  2D D4 C1 1A  E0 28 16 60  19 20 FC A3
  54
f(3) = 
  32 D1 D4 24  FE D8 65 9D  BE DD CD 7E  91 20 A2 C0
  27
f(4) = 
  33 35 1B 08  3D 81 B5 A1  A6 E7 7F 72  88 D6 E8 7F
  73
f(5) = 
  34 F1 99 E2  E9 D0 B1 26  98 45 2C 3C  00 43 CD E1
  9E
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYB-N3SE-ZJ3M-QGIK-YZNB-OIGX-6YUP-U
f(2) = SAY4-PRJZ-FXKM-CGXA-FALG-AGJA-7SRV-I
f(3) = SAZN-DVBE-73MG-LHN6-3XGX-5EJA-ULAC-O
f(4) = SAZT-KGYI-HWA3-LING-457X-FCGW-5B7X-G
f(5) = SA2P-DGPC-5HIL-CJUY-IUWD-YACD-ZXQZ-4
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
