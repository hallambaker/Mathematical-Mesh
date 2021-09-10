
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  5B D4 81 5B  F7 32 34 97  43 DD 9E 01  48 E2 D6 2C
~~~~

This has the UDF representation:

LPKI-CW7X-GI2J-OQ65-TYAU-RYWW-FQ

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 122063138267541879825292984199420237356
a1 = 324638099185525005232502876551885067337
a2 = 210580363340595489478190498427661830808
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 316999233872723911072611751747198923994
f(2) = 252531322317219994349562301286764849234
f(3) = 268941770521968593119519240249886224583
f(4) = 25948211566031243919107961204794838534
f(5) = 204115379291284873675077679015027114101
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 EE 7B D4  E9 65 30 3E  7E 2B F2 DF  31 91 04 34
  DA
f(2) = 
  31 BD FB C3  78 51 30 1A  63 51 E7 44  16 A5 F1 28
  52
f(3) = 
  32 CA 54 4D  08 BB 31 C8  46 B5 BA CC  B0 87 A9 B0
  C7
f(4) = 
  33 13 85 71  9A A3 35 48  28 57 6D 78  FF 36 2D CE
  06
f(5) = 
  34 99 8F 31  2E 09 3A 9A  08 36 FF 49  02 B1 7D 80
  75
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYO-466U-5FST-APT6-FPZN-6MMR-AQ2N-U
f(2) = SAY3-366D-PBIT-AGTD-KHTU-IFVF-6EUF-E
f(3) = SAZM-UVCN-BC5T-DSCG-WW5M-ZMEH-VGYM-O
f(4) = SAZR-HBLR-TKRT-KSBI-K5WX-R7ZW-FXHA-M
f(5) = SA2J-TDZR-FYET-VGQI-G37U-SAVR-PWAH-K
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
