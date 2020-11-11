
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  D3 3A 58 01  32 A9 F7 46  F8 B1 8E 2B  13 BA 94 42
~~~~

This has the UDF representation:

2M5F-QAJS-VH3U-N6FR-RYVR-HOUU-II

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 280770045275365279734715443894655030338
a1 = 134376403998057263730140412159629386595
a2 = 76199330805222946620803271022585278342
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 151063413157707026622284519645101483768
f(2) = 173755442650494666751460137440718493882
f(3) = 8563766832789736658867689849737849173
f(4) = 336053119546469163271256391735695972655
f(5) = 135376400028717556198502420803288229807
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 71 A5 C1  4D 96 FF 32  ED 65 3D 06  22 96 1C E6
  F8
f(2) = 
  31 82 B8 14  BC 6B EA A6  24 4D FA 9A  4F F6 7E 18
  BA
f(3) = 
  32 06 71 52  4D B1 6C 50  EB B2 EA 4A  B3 34 DE 29
  55
f(4) = 
  33 FC D1 7A  01 67 84 33  43 94 0C 17  4C 51 3D 19
  2F
f(5) = 
  34 65 D8 8B  D7 8E 32 4D  2B F1 60 00  1B 4B 9A E7
  AF
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYH-DJOB-JWLP-6MXN-MU6Q-MIUW-DTTP-Q
f(2) = SAYY-FOAU-XRV6-VJRE-JX5J-UT7W-PYML-U
f(3) = SAZA-M4KS-JWYW-YUHL-WLVE-VMZU-3YUV-K
f(4) = SAZ7-ZUL2-AFTY-IM2D-SQGB-OTCR-HUMS-6
f(5) = SA2G-LWEL-26HD-ETJL-6FQA-AG2L-TLT2-6
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
