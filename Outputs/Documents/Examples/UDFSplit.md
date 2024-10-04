
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  CB E6 CE 6A  EC 49 4F 9F  2D B2 71 0A  33 10 43 68
~~~~

This has the UDF representation:

ZPTM-42XM-JFHZ-6LNS-OEFD-GECD-NA

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 271031698069491601216108542578828264296
a1 = 513694355457258025950646345484428951
a2 = 272870674710434324359938093042993902451
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 204133700214444720138622674535538384191
f(2) = 2412317938389560854263777714699885974
f(3) = 6149918162264586826406459548080981152
f(4) = 215346500886069798055050720035681669725
f(5) = 289719699188866731076821951745733740186
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 99 92 B8  78 98 B4 80  1C A2 67 A1  11 6F 5A 5D
  3F
f(2) = 
  31 01 D0 98  75 00 3D BB  DB C8 3A 5E  1F 72 F1 DD
  96
f(3) = 
  32 04 A0 6E  60 22 E5 02  DC 9F 2A A8  34 3D D6 C4
  A0
f(4) = 
  33 A2 02 3A  3A 00 AA 55  1F 27 38 7F  4F D0 09 12
  5D
f(5) = 
  34 D9 F5 FC  02 99 8D B2  A3 60 63 E3  72 29 88 C6
  9A
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYJ-TEVY-PCML-JAA4-UJT2-CELP-LJOT-6
f(2) = SAYQ-DUEY-OUAD-3O63-ZA5F-4H3S-6HOZ-M
f(3) = SAZA-JIDO-MARO-KAW4-T4VK-QNB5-23CK-A
f(4) = SAZ2-EAR2-HIAK-UVI7-E44H-6T6Q-BEJF-2
f(5) = SA2N-T5P4-AKMY-3MVD-MBR6-G4RJ-RDDJ-U
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
