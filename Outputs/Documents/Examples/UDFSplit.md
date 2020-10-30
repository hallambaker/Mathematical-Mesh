
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  D7 71 25 50  A3 D7 D3 17  35 B5 C7 CD  E5 47 02 58
~~~~

This has the UDF representation:

25YS-KUFD-27JR-ONNV-Y7G6-KRYC-LA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 286371505476886656948864767384374149720
a1 = 273925979049863603265726557940570642549
a2 = 148363664449822833933938668229540655896
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 28096415134696167221780778690949025151
f(2) = 66548653692151345362574126456605212374
f(3) = 61445854228313727907870203249574499882
f(4) = 12788016743183314857669009069856887675
f(5) = 260857508157698569675345151349220587260
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 15 23 2C  37 A0 3E 22  17 7A 19 75  6D CD EA 0D
  7F
f(2) = 
  31 32 10 CD  F3 15 D5 0E  81 FA C3 85  86 7E 23 7E
  D6
f(3) = 
  32 2E 3A 0A  83 04 9C 98  56 B7 B3 F8  17 F5 F3 56
  2A
f(4) = 
  33 09 9E E1  E7 6C 94 BF  95 B0 EA CD  22 35 59 93
  7B
f(5) = 
  34 C4 3F 54  20 4D BD 84  3E E6 68 04  A5 3C 56 36
  FC
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYB-KIZM-G6QD-4IQX-PIMX-K3ON-5IGX-6
f(2) = SAYT-EEGN-6MK5-KDUB-7LBY-LBT6-EN7N-M
f(3) = SAZC-4OQK-QMCJ-ZGCW-W6Z7-QF7V-6NLC-U
f(4) = SAZQ-THXB-45WJ-JP4V-WDVM-2IRV-LGJX-W
f(5) = SA2M-IP2U-EBG3-3BB6-4ZUA-JJJ4-KY3P-Y
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
