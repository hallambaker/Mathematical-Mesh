
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  84 CF E7 67  64 A6 D1 A9  64 4F C2 6C  B4 A3 8F C9
~~~~

This has the UDF representation:

QTH6-OZ3E-U3I2-SZCP-YJWL-JI4P-ZE

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 176537594321594959815016461874567024585
a1 = 25845204866995156990315464644226574986
a2 = 95465059626661471735876416834183245797
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 297847858815251588541208343352976845368
f(2) = 269805875641292697275778451067984946238
f(3) = 92411644799718286018726785019591327195
f(4) = 105947533211466818233427952639564199746
f(5) = 310413540876538293919881953927903563891
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 E0 13 69  38 5E C7 83  44 DC E9 BC  F5 02 53 AA
  38
f(2) = 
  31 CA FA B8  B4 AD 6A 80  7A F6 61 71  4E 74 50 24
  3E
f(3) = 
  32 45 85 D5  DC 50 8F C9  4B B0 B6 DF  79 0A 98 FD
  DB
f(4) = 
  33 4F B4 C0  AF 48 37 5D  B7 0B EA 07  74 C5 2E 37
  42
f(5) = 
  34 E9 87 79  2D 94 61 3D  BD 07 FA E9  41 A4 0F D0
  73
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYO-AE3J-HBPM-PA2E-3TU3-Z5IC-KOVD-Q
f(2) = SAY4-V6VY-WSWW-VAD2-6ZQX-CTTU-KASD-4
f(3) = SAZE-LBOV-3RII-7SKL-WC3N-66IK-TD65-W
f(4) = SAZU-7NGA-V5ED-OXNX-BPVA-O5GF-FY3U-E
f(5) = SA2O-TB3Z-FWKG-CPN5-A75O-SQNE-B7IH-G
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
