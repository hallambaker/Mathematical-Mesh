
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  D8 DC 8C 7D  BE E2 25 43  A8 86 24 DE  04 B2 36 D9
~~~~

This has the UDF representation:

3DOI-Y7N6-4ISU-HKEG-ETPA-JMRW-3E

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 288258401898359861219324208368992794329
a1 = 172337878901790550135586289506209443269
a2 = 303986693747056954711147097548010088274
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 84018240705330439139308380559675902858
f(2) = 147469100085476463018212140414610976428
f(3) = 138328613117859469392660880502029803532
f(4) = 56596779802479458262654600821932384170
f(5) = 242555967060274893091567908806086929849
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 3F 35 53  16 AF A6 F4  E4 9F F0 BD  F5 4C CA 4B
  8A
f(2) = 
  31 6E F1 83  FC 91 A4 2A  A1 7D 94 7B  28 13 CC 2E
  AC
f(3) = 
  32 68 11 1F  2F 64 D9 C6  7A 41 71 5C  76 59 B7 E0
  0C
f(4) = 
  33 2A 94 24  AF 29 47 C8  6E EB 87 61  E0 1E 8D 5F
  AA
f(5) = 
  34 B6 7A 94  7B DE EE 30  7F 7B D6 8B  65 62 4C AD
  B9
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYD-6NKT-C2X2-N5HE-T7YL-35KM-ZJFY-U
f(2) = SAYW-54MD-7SI2-IKVB-PWKH-WKAT-ZQXK-Y
f(3) = SAZG-QEI7-F5SN-TRT2-IFYV-Y5SZ-W7QA-Y
f(4) = SAZS-VFBE-V4UU-PSDO-5ODW-DYA6-RVP2-U
f(5) = SA2L-M6UU-PPPO-4MD7-PPLI-WZLC-JSW3-S
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
