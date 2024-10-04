
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  4E DC D3 74  D4 38 0A 1B  8B CB 5E 4F  4D A1 70 77
~~~~

This has the UDF representation:

J3ON-G5GU-HAFB-XC6L-LZHU-3ILQ-O4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 104826377824672891981720014791704146039
a1 = 100209224910746589098497554736761493437
a2 = 135801272672280192054441544566367127045
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 554508486761209671284506663064555014
f(2) = 167885184493409911469732087667159218079
f(3) = 266536038923680533913688150372219923727
f(4) = 296507071777573077003152694778246671958
f(5) = 257798283055087540738125720885239462772
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 00 6A CB  61 11 B0 FD  66 FF A2 47  3B 04 ED CE
  06
f(2) = 
  31 7E 4D 82  A9 CD 7C DF  AE E0 44 DA  70 A8 0C 37
  9F
f(3) = 
  32 C8 84 F9  4F 07 9B B0  F3 2D B3 17  F0 36 FC AD
  0F
f(4) = 
  33 DF 11 2F  50 C0 0D 71  33 E7 EC FF  B9 B1 BF 2E
  56
f(5) = 
  34 C1 F2 24  AE F6 D2 20  71 0E F2 91  CD 18 53 BB
  74
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYA-A2WL-MEI3-B7LG-76RE-OOYE-5XHA-M
f(2) = SAYX-4TMC-VHGX-ZX5O-4BCN-U4FI-BQ3Z-6
f(3) = SAZM-RBHZ-J4DZ-XMHT-FWZR-P4BW-7SWQ-6
f(4) = SAZ5-6EJP-KDAA-24JT-47WP-7ONR-X4XF-M
f(5) = SA2M-D4RE-V33N-EIDR-B3ZJ-DTIY-KO5X-I
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
