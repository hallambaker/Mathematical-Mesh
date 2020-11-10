
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  D7 8C D4 32  5C 65 B3 F0  B6 D0 8F 1B  9C DC 21 EC
~~~~

This has the UDF representation:

26GN-IMS4-MWZ7-BNWQ-R4NZ-ZXBB-5Q

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 286515244514791460564996565425763131884
a1 = 153737628857256663949677806285805472921
a2 = 217387147976955431352829975160102608137
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 317357654428065092404129739439903001435
f(2) = 102409626453372660022173648910711664246
f(3) = 322235894432591090345877508701725543331
f(4) = 296271724523843456448492103949408215676
f(5) = 24517116727129758330017434653759681281
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 EE C0 DC  68 D0 A6 F5  76 A5 FF DA  50 B9 16 CB
  5B
f(2) = 
  31 4D 0B 60  6A 09 A3 8B  42 7B 1A F1  94 F9 B2 2E
  76
f(3) = 
  32 F2 6C 60  36 07 5B 75  54 36 21 D4  E8 5E AE 4B
  A3
f(4) = 
  33 DE E3 DB  CC C9 CE B3  AB D7 14 84  4A E8 0B 22
  7C
f(5) = 
  34 12 71 D3  2E 50 FD 46  49 5D F2 FF  BC 95 C8 B3
  01
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYO-5QG4-NDIK-N5LW-UX75-UUFZ-C3FV-W
f(2) = SAYU-2C3A-NIE2-HC2C-PMNP-DFHZ-WIXH-M
f(3) = SAZP-E3DA-GYDV-W5KU-GYQ5-J2C6-VZF2-G
f(4) = SAZ5-5Y63-ZTE4-5M5L-24KI-ISXI-BMRH-Y
f(5) = SA2B-E4OT-FZIP-2RSJ-LXZP-7PEV-ZCZQ-C
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
