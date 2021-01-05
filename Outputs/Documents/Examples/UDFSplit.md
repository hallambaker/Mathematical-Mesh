
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  65 3A E8 43  D2 3A 35 E0  1E 87 E9 77  D0 C8 A4 52
~~~~

This has the UDF representation:

MU5O-QQ6S-HI26-AHUH-5F35-BSFE-KI

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 134557891684448682988702617575432430674
a1 = 196973856017976890867155803534548331781
a2 = 187861308602815293012156948453693402303
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 179110689384302403404640762131905953251
f(2) = 259103737368848246381518196163998068927
f(3) = 34254668717147748455960312239940566195
f(4) = 185128217271077836554716325223269868069
f(5) = 31159649188761583751037020250449551535
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 86 BF 76  C8 FF D6 55  55 84 61 19  67 67 76 BD
  E3
f(2) = 
  31 C2 ED 90  8C E9 36 B3  19 49 1B 8E  79 84 A7 30
  BF
f(3) = 
  32 19 C5 35  8F 8E 5B 4F  2B 6C B7 48  AE 28 59 FC
  B3
f(4) = 
  33 8B 46 65  D0 EF 44 29  8B EF 34 48  05 52 8F 22
  25
f(5) = 
  34 17 71 21  51 0B F1 42  3A D0 92 8C  7F 03 46 A0
  AF
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYI-NP3W-ZD75-MVKV-QRQR-SZ3H-O266-G
f(2) = SAY4-F3MQ-RTUT-NMYZ-JENY-46ME-U4YL-6
f(3) = SAZB-TRJV-R6HF-WTZL-NS3U-RLRI-LH6L-G
f(4) = SAZY-WRTF-2DXU-IKML-542E-QBKS-R4RC-K
f(5) = SA2B-O4JB-KEF7-CQR2-2CJI-Y7YD-I2QK-6
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
