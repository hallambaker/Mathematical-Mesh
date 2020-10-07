
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  43 04 B6 E9  D2 6E 28 22  AF EE 55 7C  51 08 61 62
~~~~

This has the UDF representation:

IMCL-N2OS-NYUC-FL7O-KV6F-CCDB-MI

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 89082754828858256659842863646447788386
a1 = 321014781412884043392555426779501880606
a2 = 56244255603398119427285612458693439570
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 126059424924201956016309295452874897055
f(2) = 275524606226341894227346952176688884864
f(3) = 197195931814339607829581226386121540306
f(4) = 231355768609133560286386725512941074888
f(5) = 37721749689785288134388842125379277103
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 5E D6 29  80 EA E3 C7  3B 6E DB 44  49 FC 00 76
  9F
f(2) = 
  31 CF 48 1B  E4 74 39 3B  1E D8 B5 0E  EF 43 02 EC
  80
f(3) = 
  32 94 5A 8E  14 6E 6E 83  CC ED 7B B5  6C 26 0F C2
  D2
f(4) = 
  33 AE 0D 80  10 D9 83 A1  45 AD 2F 37  C0 A5 26 F9
  C8
f(5) = 
  34 1C 60 F1  D9 B5 78 93  89 17 CF 95  EC C0 48 91
  2F
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYF-5VRJ-QDVO-HRZ3-N3NU-ISP4-AB3J-6
f(2) = SAY4-6SA3-4R2D-SOY6-3C2Q-532D-ALWI-A
f(3) = SAZJ-IWUO-CRXG-5A6M-5V53-K3BG-B7BN-E
f(4) = SAZ2-4DMA-CDMY-HIKF-VUXT-PQFF-E344-Q
f(5) = SA2B-YYHR-3G2X-RE4J-C7HZ-L3GA-JCIS-6
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
