
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  C4 C4 71 54  3D A6 9F 05  F4 F9 B1 40  BE 67 0E 48
~~~~

This has the UDF representation:

YTCH-CVB5-U2PQ-L5HZ-WFAL-4ZYO-JA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 261548675944647219392615334375997247048
a1 = 338436361571120972220704076733024374497
a2 = 40015544933861152079669721351675910998
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 299718215528690880229614525028929321036
f(2) = 77636478059518381762578550953445005513
f(3) = 275868197379006650918256627013080723493
f(4) = 213848639645278760769899538344300051962
f(5) = 231860171779273174780881892378871202427
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 E1 7B A0  ED 02 D2 E4  CA AD 10 C5  B6 3B 5F 38
  4C
f(2) = 
  31 3A 68 3D  E5 C3 64 1B  BF FA 00 56  2C 32 55 98
  C9
f(3) = 
  32 CF 8A 48  3E 7F 5A 43  E5 DB C8 62  A2 A3 4A 30
  25
f(4) = 
  33 A0 E1 BF  F7 36 B5 5D  3C 52 68 EB  19 8E 3C FD
  FA
f(5) = 
  34 AE 6E A5  0F E9 75 67  C3 5D E1 EF  90 F3 2E 02
  7B
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYO-C65A-5UBN-FZGK-VUIM-LNR3-L44E-Y
f(2) = SAYT-U2B5-4XBW-IG57-7IAF-MLBS-KWMM-S
f(3) = SAZM-7CSI-HZ7V-UQ7F-3PEG-FIVD-JIYC-K
f(4) = SAZ2-BYN7-643L-KXJ4-KJUO-WGMO-HT67-U
f(5) = SA2K-43VF-B7UX-KZ6D-LXQ6-7EHT-FYBH-W
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
