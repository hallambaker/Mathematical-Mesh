
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  3E AF 8C 7C  4A 85 F7 EC  7E FC F0 B2  DF 9C F5 F0
~~~~

This has the UDF representation:

H2XY-Y7CK-QX36-Y7X4-6CZN-7HHV-6A

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 83323637073608890605557692967272904176
a1 = 255162942599465260402270874517662057695
a2 = 19137550451637655947705938030584278875
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 17341763203773343492159898083751029239
f(2) = 329917357158151571737548586693165923559
f(3) = 203318173928184951599936500212952615
f(4) = 49046747013918573524437769800196750928
f(5) = 136165276757184273992687479161349106991
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 0D 0B E6  F0 4E 0E CA  3A F1 2A 6F  3A 9B CE E9
  F7
f(2) = 
  31 F8 33 C5  90 41 23 D3  AA F7 E5 E0  0B BB 6D 3C
  E7
f(3) = 
  32 00 27 28  5C 23 C5 14  3C 93 2F 43  26 3E 77 EE
  27
f(4) = 
  33 24 E6 0F  53 F5 F2 8B  EF C3 06 98  8A 24 EE FE
  50
f(5) = 
  34 66 70 7A  77 B7 AC 3A  C4 87 6B E0  37 6E D2 6D
  2F
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYA-2C7G-6BHA-5SR2-6EVG-6OU3-Z3U7-O
f(2) = SAY7-QM6F-SBAS-HU5K-67S6-AC53-NU6O-O
f(3) = SAZA-AJZI-LQR4-KFB4-SMXU-GJR6-O7XC-O
f(4) = SAZS-JZQP-KP27-FC7P-YMDJ-RCRE-537F-A
f(5) = SA2G-M4D2-O632-YOWE-Q5V6-AN3O-2JWS-6
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
