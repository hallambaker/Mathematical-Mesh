
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  08 C1 B0 33  D4 B7 45 A7  B1 3C ED FB  20 26 6D F9
~~~~

This has the UDF representation:

BDA3-AM6U-W5C2-PMJ4-5X5S-AJTN-7E

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 11639511070535464080792228590537567737
a1 = 71733631461306920591059610053779639861
a2 = 304402524877859902550454942796761489056
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 47493300488763823758932174009310485147
f(2) = 11587405820835061611232790158069957655
f(3) = 244204193987687641101068684468584196768
f(4) = 64778931147444635301690642077316779472
f(5) = 153876351141982971139847877847804128781
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 23 BA E0  80 3F 7C AB  1C 5E C0 EF  71 07 45 9A
  9B
f(2) = 
  31 08 B7 A7  37 1E AA DD  5D DD 96 A7  B9 69 C3 84
  17
f(3) = 
  32 B7 B8 04  58 72 41 DC  6C 2D BE 16  D4 47 A0 2A
  A0
f(4) = 
  33 30 BB F7  E4 3A 41 A8  47 4F 37 3C  C1 A0 DB 8D
  D0
f(5) = 
  34 73 C3 81  DA 76 AA 40  EF 42 02 19  81 75 75 AE
  0D
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYC-HOXA-QA7X-ZKY4-L3AO-64IH-IWNJ-W
f(2) = SAYQ-RN5H-G4PK-VXK5-3WLK-POLJ-YOCB-O
f(3) = SAZL-POAE-LBZE-DXDM-FW7B-NVCH-UAVK-A
f(4) = SAZT-BO7X-4Q5E-DKCH-J43T-ZQNA-3OG5-A
f(5) = SA2H-HQ4B-3J3K-UQHP-IIBB-TALV-OWXA-2
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
