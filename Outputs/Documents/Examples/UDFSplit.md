
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  01 A4 0B A5  CA 07 D1 4A  01 61 51 89  33 A1 85 52
~~~~

This has the UDF representation:

AGSA-XJOK-A7IU-UALB-KGET-HIMF-KI

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 2181000922262505430375612626271044946
a1 = 59566364847501639508895606353141271908
a2 = 143814304035553219287541591903494399768
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 205561669805317364226812810882906716622
f(2) = 16006212917601734671583978082994764820
f(3) = 114079364100992543691438329090071612554
f(4) = 159498756434551327823001256472369048317
f(5) = 152264389918278087066272760229887072109
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 9A A5 BC  CE BD E9 A1  67 D2 FB AE  CC 80 01 F9
  CE
f(2) = 
  31 0C 0A AF  39 C8 0B FC  B7 40 CB 60  74 00 60 3C
  14
f(3) = 
  32 55 D2 E2  E6 E8 6E E3  38 4A D0 66  7F B4 BC 4C
  8A
f(4) = 
  33 77 FE 57  D6 1F 12 54  EA F1 0A C0  EF 9D 16 2A
  FD
f(5) = 
  34 72 8D 0E  07 6B F6 51  CF 33 7A 6F  C3 B9 6D D7
  6D
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYJ-VJN4-Z266-TILH-2L52-5TEA-AH44-4
f(2) = SAYQ-YCVP-HHEA-X7FX-IDFW-A5AA-MA6B-I
f(3) = SAZF-LUXC-43UG-5YZY-JLIG-M75U-XRGI-U
f(4) = SAZX-P7SX-2YPR-EVHK-6EFM-B345-CYVP-2
f(5) = SA2H-FDIO-A5V7-MUOP-GN5G-7Q5Z-NXLW-2
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
