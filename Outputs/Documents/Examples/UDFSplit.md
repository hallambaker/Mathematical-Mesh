
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  DA 4C 6B 52  A5 CC 8E 21  27 59 19 75  ED 0F 16 19
~~~~

This has the UDF representation:

3JGG-WUVF-ZSHC-CJ2Z-DF26-2DYW-DE

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 290168494408209542766551069936577353241
a1 = 203791780635558934216798217983061273808
a2 = 107651371230849808713614696318391902532
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 261329279353679822233589376806262318074
f(2) = 107510439839911255664482468880962876464
f(3) = 168994342787842306522604953592447239918
f(4) = 105498621276534511344582223508947196929
f(5) = 257305642226926333593788886062230959004
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 C4 9A 30  3D F2 7A 29  DE 05 50 F9  A9 06 E2 A3
  FA
f(2) = 
  31 50 E1 C1  EE 48 FF 39  1A 27 02 6C  83 0C B8 F4
  30
f(3) = 
  32 7F 23 20  63 A9 5B BB  D5 8C 6D 72  03 FE 92 06
  EE
f(4) = 
  33 4F 5E 4B  9E 13 8F B2  10 35 92 0A  2B DC 6D DC
  01
f(5) = 
  34 C1 93 43  9D 87 9B 1B  CA 22 70 34  FA A6 4C 73
  9C
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYM-JGRQ-HXZH-UKO6-AVIP-TKIG-4KR7-U
f(2) = SAYV-BYOB-5ZEP-6OI2-E4BG-ZAYM-XD2D-A
f(3) = SAZH-6IZA-MOUV-XO6V-RRWX-EA76-SIDO-4
f(4) = SAZU-6XSL-TYJY-7MQQ-GWJA-UK64-NXOA-C
f(5) = SA2M-DE2D-TWDZ-WG6K-EJYD-J6VG-JRZZ-Y
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
