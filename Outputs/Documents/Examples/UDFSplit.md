
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  AD 47 F8 65  49 70 B1 96  95 5C 0B 10  06 3C E5 39
~~~~

This has the UDF representation:

VVD7-QZKJ-OCYZ-NFK4-BMIA-MPHF-HE

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 230330134410101182374344119375204508985
a1 = 163952626525990518178691591501010276776
a2 = 217578748397345040216428032299000118115
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 271579142412498277306089135743446692369
f(2) = 67420913367708525743941001846152688969
f(3) = 298420181117608854614648932546858921799
f(4) = 284012211820322336991463712982028967845
f(5) = 24197005475848972874385343151662827107
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 CC 50 3D  81 F6 74 43  5D 56 23 60  1A 8F 96 32
  11
f(2) = 
  31 32 B8 CB  AC 00 51 C0  14 F7 B9 D4  EE 02 46 F5
  49
f(3) = 
  32 E0 81 A2  E3 67 09 27  BD 7A 1F 69  8A 5E 4F 2F
  47
f(4) = 
  33 D5 AA C3  28 2A 9A 7A  56 DD 54 1D  EF A3 AE DF
  A5
f(5) = 
  34 12 34 2C  7A 4B 05 B7  E1 21 57 F2  1D D2 66 06
  63
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYM-YUB5-QH3H-IQ25-KYRW-AGUP-SYZB-C
f(2) = SAYT-FOGL-VQAF-DQAU-6645-J3QC-I32U-S
f(3) = SAZO-BANC-4NTQ-SJ55-PIPW-TCS6-J4XU-O
f(4) = SAZ5-LKWD-FAVJ-U6SW-3VKB-335D-V3P2-K
f(5) = SA2B-ENBM-PJFQ-LN7B-EFL7-EHOS-MYDG-G
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
