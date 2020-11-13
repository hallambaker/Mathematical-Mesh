
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  A1 74 50 3D  79 CF FC B9  D6 75 7A DE  C7 09 45 13
~~~~

This has the UDF representation:

UF2F-APLZ-Z76L-TVTV-PLPM-OCKF-CM

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 214609641220346828343678694400964773139
a1 = 191211305387810736280772587057080822776
a2 = 198856728160743274595138570416909786013
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 264395307847962375756215244443187170421
f(2) = 31329696955187545432279720455692716715
f(3) = 195977542383899264298621337302017835035
f(4) = 77774110292220605428490880118626102367
f(5) = 17001767601090032285262956337285730218
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 C6 E8 AF  1E 29 7F D7  E1 01 88 FA  65 09 BC 4C
  75
f(2) = 
  31 17 91 E1  51 9B 1C C2  86 A4 DC 32  21 3C 59 8A
  AB
f(3) = 
  32 93 6F E6  D7 CE A6 BC  AA C0 6F 22  13 5E E1 00
  1B
f(4) = 
  33 3A 82 BF  B0 C4 1D C6  4D 54 41 CA  3B 71 52 AC
  5F
f(5) = 
  34 0C CA 6B  DC 7B 81 DF  6E 60 54 2A  99 73 AE 8F
  AA
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYM-N2FP-DYUX-7V7B-AGEP-UZIJ-XRGH-K
f(2) = SAYR-PEPB-KGNR-ZQUG-UTOD-EIJ4-LGFK-W
f(3) = SAZJ-G37G-27HK-NPFK-YBXS-EE26-4EAB-W
f(4) = SAZT-VAV7-WDCB-3RSN-KRA4-UO3R-KKWF-6
f(5) = SA2A-ZSTL-3R5Y-DX3O-MBKC-VGLT-V2H2-U
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
