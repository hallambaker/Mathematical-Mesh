
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  4B 02 B6 CD  FE 73 C5 92  95 F1 22 83  BD 89 2E C4
~~~~

This has the UDF representation:

JMBL-NTP6-OPCZ-FFPR-EKB3-3CJO-YQ

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 99706191996656092125352500413069864644
a1 = 289920843938923872952475376695427789317
a2 = 176120712078601651678729858114386099589
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 225465381093243153293183127791115542043
f(2) = 22901260505156590891724256534396995606
f(3) = 172578564074273331847725101506450648347
f(4) = 334214924879654912697811055275508288759
f(5) = 167527976000362869978607510409801705335
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 A9 9F 0D  8A 00 E2 B2  32 07 02 EC  2D 78 05 9E
  1B
f(2) = 
  31 11 3A 9F  51 7C 1B E3  8C 3A 10 05  38 84 C9 08
  16
f(3) = 
  32 81 D5 6C  24 70 1F 59  A1 2F 18 6D  A4 E3 D3 6D
  1B
f(4) = 
  33 FB 6F 74  02 DC ED 14  70 E6 1C 25  72 95 24 CC
  F7
f(5) = 
  34 7E 08 B6  EC C2 85 13  FB 5F 1B 2C  A1 98 BD 27
  77
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYK-THYN-RIAO-FMRS-A4BO-YLLY-AWPB-W
f(2) = SAYR-COU7-KF6B-XY4M-HIIA-KOEE-ZEEB-M
f(3) = SAZI-DVLM-ERYB-6WNB-F4MG-3JHD-2NWR-W
f(4) = SAZ7-W33U-ALOO-2FDQ-4YOC-K4UV-ETGP-O
f(5) = SA2H-4CFW-5TBI-KE73-L4NS-ZIMY-XUTX-O
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
