
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  C7 06 AC D7  8C 33 36 DB  14 56 FF 1B  8A 90 4E A7
~~~~

This has the UDF representation:

Y4DK-ZV4M-GM3N-WFCW-74NY-VECO-U4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 264551030594246051968655611548056702631
a1 = 297725982489234459928549289735566381273
a2 = 118316774559670038567226391391796289491
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 29053801273623537682077811882950381
f(2) = 312422993048579735704535934291069988620
f(3) = 180885747573348998079093358690313182827
f(4) = 285982051217458337588103565873148956016
f(5) = 287429537059969290768191948407809096680
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 00 05 98  76 87 0E 82  85 C2 AA B7  26 B7 99 7E
  ED
f(2) = 
  31 EB 0A 7A  D1 BB 06 7E  30 D9 B6 AF  09 55 8D 6F
  0C
f(3) = 
  32 88 15 53  E9 28 1B 29  DC 59 7A E6  C3 64 6C 1E
  6B
f(4) = 
  33 D7 26 23  BC CE 4C 85  88 41 F7 5E  54 E4 35 8D
  70
f(5) = 
  34 D8 3C EA  4C AD 9A 91  34 93 2C 15  BD D4 E9 BB
  E8
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYA-ABMY-O2DQ-5AUF-YKVL-OJVX-TF7O-2
f(2) = SAY6-WCT2-2G5Q-M7RQ-3G3K-6CKV-RVXQ-Y
f(3) = SAZI-QFKT-5EUB-WKO4-LF5O-NQ3E-NQPG-W
f(4) = SAZ5-OJRD-XTHE-ZBMI-IH3V-4VHE-GWGX-A
f(5) = SA2N-QPHK-JSWZ-VEJU-SMWB-LPOU-5G56-Q
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
