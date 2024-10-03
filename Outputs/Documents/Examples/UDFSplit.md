
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  7E 58 4F 70  E5 52 C8 F9  0F C5 65 51  26 54 28 47
~~~~

This has the UDF representation:

PZME-64HF-KLEP-SD6F-MVIS-MVBI-I4

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 167941260847335503130728370075281401927
a1 = 23954731780393029674851925604278385695
a2 = 238436372488806873642152000992078518959
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 90049998195596942984357689239870095074
f(2) = 148749113600533666658916402956847614632
f(3) = 3756240141207210691029903794445749094
f(4) = 335636111659494502007447406616200921474
f(5) = 123541627392580150218045089126808497251
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 43 BE FF  B1 77 B8 EA  87 53 89 14  7B 97 8F BE
  E2
f(2) = 
  31 6F E8 09  86 7D E9 56  9D EC 44 F5  93 EA 4D 0A
  A8
f(3) = 
  32 02 D3 6C  EF F7 E4 0D  3C D9 F9 08  9A 1E 8C 0B
  66
f(4) = 
  33 FC 81 29  ED E5 A9 0E  64 1C A5 4D  8E 34 4C C1
  82
f(5) = 
  34 5C F1 40  80 47 38 5A  13 B4 49 C4  70 2B 8F 2C
  63
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYE-HPX7-WF33-R2UH-KOER-I64X-R67O-E
f(2) = SAYW-72AJ-QZ66-SVU5-5RCP-LE7K-JUFK-Q
f(3) = SAZA-FU3M-5736-IDJ4-3H4Q-RGQ6-RQFW-M
f(4) = SAZ7-ZAJJ-5XS2-SDTE-DSSU-3DRU-JTAY-E
f(5) = SA2F-Z4KA-QBDT-QWQT-WRE4-I4BL-R4WG-G
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
