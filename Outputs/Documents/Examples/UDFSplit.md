
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  A5 EE 6E 3B  44 86 CF EF  ED E7 E5 9F  0E 9F 5D 4C
~~~~

This has the UDF representation:

UXXG-4O2E-Q3H6-73PH-4WPQ-5H25-JQ

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 220560621717568356713517510883100548428
a1 = 188207439976704515962068078916794741852
a2 = 186306699171171121067952180744395419812
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 254792393944505530280163163112522498585
f(2) = 321355197592846482519338569398967076859
f(3) = 79966665741652749967669122310666071743
f(4) = 211191532232801259551904036711155906251
f(5) = 34465063224415084345294097736900157369
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 BF AF 3A  E8 7C E4 6C  7C 5C 1B 1A  E8 D7 F9 C2
  19
f(2) = 
  31 F1 C2 C2  81 21 0D FF  7A A2 7E F9  2C 68 3C 07
  FB
f(3) = 
  32 3C 29 05  05 31 03 88  EA C1 13 80  69 BF 66 2E
  BF
f(4) = 
  33 9E E2 02  74 AC C5 08  CC B7 D8 B0  A0 DD 78 36
  CB
f(5) = 
  34 19 ED BA  CF 94 52 7F  20 86 CE 89  D1 C2 72 1F
  B9
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYL-7LZ2-5B6O-I3D4-LQNR-V2GX-7HBB-S
f(2) = SAY7-DQWC-QEQQ-3732-UJ7P-SLDI-HQD7-W
f(3) = SAZD-YKIF-AUYQ-HCHK-YEJY-A2N7-MYXL-6
f(4) = SAZZ-5YQC-OSWM-KCGM-W7ML-BIG5-PA3M-W
f(5) = SA2B-T3N2-Z6KF-E7ZA-Q3HI-TUOC-OIP3-S
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
