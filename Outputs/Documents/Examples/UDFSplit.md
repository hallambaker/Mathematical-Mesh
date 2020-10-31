
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  90 CF BD 2D  18 33 FC BB  16 19 48 9B  E1 38 0D CF
~~~~

This has the UDF representation:

SDH3-2LIY-GP6L-WFQZ-JCN6-COAN-Z4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 192487473790917487264859183609661623759
a1 = 47655814675099692236056956397719811074
a2 = 139176320568141552648550636538976694303
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 39037242113220268686092169114589917629
f(2) = 163939651571806155404426427697471600105
f(3) = 226912335245736683956487351926538459680
f(4) = 227955293135011854342274941801790496354
f(5) = 167068525239631666561789197323227710127
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 1D 5E 4C  A2 69 8A 63  F0 10 53 F6  4D 27 DC F1
  BD
f(2) = 
  31 7B 55 A0  DF 0C 80 8A  BA 02 86 F7  9E 58 DE B5
  E9
f(3) = 
  32 AA B5 B9  E3 01 16 71  18 EC B2 4C  8F 74 3D 5A
  20
f(4) = 
  33 AB 7E 97  AE 47 4C 17  0C CE D5 F5  20 79 F8 DE
  62
f(5) = 
  34 7D B0 3A  40 DF 21 7C  95 A8 F1 F1  51 6A 11 42
  AF
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYB-2XSM-UJUY-UY7Q-CBJ7-MTJH-3TY3-2
f(2) = SAYX-WVNA-34GI-BCV2-AKDP-PHSY-3226-S
f(3) = SAZK-VNNZ-4MAR-M4IY-5SZE-ZD3U-HVNC-A
f(4) = SAZ2-W7UX-VZDU-YFYM-Z3K7-KIDZ-7DPG-E
f(5) = SA2H-3MB2-IDPS-C7EV-VDY7-CULK-CFBK-6
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
