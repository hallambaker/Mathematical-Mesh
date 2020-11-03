
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  F7 A6 EB 8D  28 CB FC 27  0F B6 2F 42  72 F9 05 CE
~~~~

This has the UDF representation:

66TO-XDJI-ZP6C-OD5W-F5BH-F6IF-ZY

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 329186013787444777738542053389141345742
a1 = 201114126503548069811577983640981360738
a2 = 338925375028196273048231456110050900273
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 188660781477312193671602278276637183739
f(2) = 45421565381695228774376200520698399268
f(3) = 239750732421532346510238427553093203836
f(4) = 91083548754946619952439744510285174429
f(5) = 279984748223814976027729366255810734061
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 8D EE BE  AD B1 BF FF  6F 91 B0 A8  3D 24 A0 CE
  FB
f(2) = 
  31 22 2B E0  12 EF DC 0E  3D 94 53 A6  CE 5E 63 8A
  24
f(3) = 
  32 B4 5E 4F  BC E3 20 28  91 17 9F 2A  F6 20 41 37
  7C
f(4) = 
  33 44 86 0D  AB 8B 8C 4E  6A 1B 93 34  B4 6A 39 D6
  9D
f(5) = 
  34 D2 A3 19  DE E9 20 7F  C8 A0 2F C4  09 3C 4D 67
  ED
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYI-33V6-VWY3-773P-SGYK-QPJE-UDHP-W
f(2) = SAYS-EK7A-CLX5-YDR5-SRJ2-NTS6-MOFC-I
f(3) = SAZL-IXSP-XTRS-AKER-C6PS-V5RA-IE3X-Y
f(4) = SAZU-JBQN-VOFY-YTTK-DOJT-JNDK-HHLJ-2
f(5) = SA2N-FIYZ-33US-A76I-UAX4-ICJ4-JVT6-2
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
