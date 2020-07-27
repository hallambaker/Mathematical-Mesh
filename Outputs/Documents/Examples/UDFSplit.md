
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  CA 65 A1 30  57 25 91 56  B9 6F 32 D0  17 F0 A2 5A
~~~~

This has the UDF representation:

EDFG-LIJQ-K4SZ-CVVZ-N4ZN-AF7Q-UJNA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 269031746429133624973381789488312787546
a1 = 322115533094025657321906342357735266839
a2 = 32658764136027301650768999736923473956
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 283523676738248120482682524151203316834
f(2) = 23050768398478755830146650856172582527
f(3) = 168177755251702457942523384466757007639
f(4) = 38339903456042299893063510119420169156
f(5) = 314101946853375208608516242677698490092
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 D5 4C AC  84 88 7E AF  0F 3C E4 8B  92 BC 61 44
  62
f(2) = 
  31 11 57 6A  A0 65 D7 A1  45 95 07 AE  BC D2 44 76
  7F
f(3) = 
  32 7E 85 DB  83 EF 30 67  F9 C1 D8 9C  4E 59 9A 39
  17
f(4) = 
  33 1C D7 FF  2F 24 89 03  2B C3 57 54  47 52 62 8B
  C4
f(5) = 
  34 EC 4D D5  A2 05 E1 72  DB 99 83 D6  A7 BC 9D 6E
  EC
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYN-KTFM-QSEH-5LYP-HTSI-XEV4-MFCG-E
f(2) = SAYR-CV3K-UBS5-PIKF-SUD2-5PGS-IR3H-6
f(3) = SAZH-5BO3-QPXT-AZ7Z-YHMJ-YTSZ-TI4R-O
f(4) = SAZR-ZV77-F4SI-SAZL-YNLV-IR2S-MKF4-I
f(5) = SA2O-YTOV-UIC6-C4W3-TGB5-NJ54-TVXO-Y
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
