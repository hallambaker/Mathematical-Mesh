
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  1D B4 F6 62  9B 7B 0D B5  39 77 8B 15  FB 35 DB 9B
~~~~

This has the UDF representation:

DW2P-MYU3-PMG3-KOLX-RMK7-WNO3-TM

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 39487222597540193128062240275075292059
a1 = 158990353329828492134048943063163889021
a2 = 104214680526199015527960019589140578303
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 302692256453567700790071202927379759383
f(2) = 93761917520116312581250989894428960299
f(3) = 93260939639062955428350816039759317821
f(4) = 301189322810407629331370681363370831949
f(5) = 36982333192273407363561371001727079669
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 E3 B8 68  76 DE A0 46  6D AD B0 62  60 D4 88 41
  17
f(2) = 
  31 46 89 E3  72 15 34 44  DC 83 98 19  E2 58 9A A6
  2B
f(3) = 
  32 46 29 67  54 3F 37 09  01 BB 2E B1  9A 87 6D 0B
  3D
f(4) = 
  33 E2 96 F4  1D 5C A8 92  DD 54 74 29  89 60 FF 70
  4D
f(5) = 
  34 1B D2 89  CD 6D 88 E2  6F 4F 68 81  AE E5 51 D4
  F5
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYO-HODI-O3PK-ARTN-VWYG-EYGU-RBAR-O
f(2) = SAYU-NCPD-OIKT-IRG4-QOMB-TYSY-TKTC-W
f(3) = SAZE-MKLH-KQ7T-OCIB-XMXL-DGUH-NUFT-2
f(4) = SAZ6-FFXU-DVOK-REW5-KR2C-TCLA-75YE-2
f(5) = SA2B-XUUJ-ZVWY-RYTP-J5UI-DLXF-KHKP-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
