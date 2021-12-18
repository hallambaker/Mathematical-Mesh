
Alice decides to encrypt an important document and split the encryption key so that
there are five key shares, three of which will be required to recover the key.

~~~~
Alice's master secret is
  99 83 FF DD  6F 43 E8 84  E1 9A BF 50  41 F0 DB E0
~~~~

This has the UDF representation:

TGB7-7XLP-IPUI-JYM2-X5IE-D4G3-4A

The master secret is converted to an integer applying network byte order conventions.
Since the master secret is 128 bits, it is guaranteed to be smaller than the modulus.
The resulting value becomes the polynomial value a0.

Since a threshold of three shares is required, we will need a second order polynomial.
The co-efficients of the polynomial a1, a2 are random numbers smaller than the 
modulus:

~~~~
a0 = 204057263801867969962330932391189732320
a1 = 257292788167330838715498332851009138326
a2 = 312403602772948733496575650712186164723
~~~~

The master secret is the value f(0) = a0. The key shares are the values f(1), f(2)...f(5):

~~~~
f(1) = 93188920900270615247655701090848612355
f(2) = 266845416623632264062757163783111610329
f(3) = 44462017130075989480886105604442303228
f(4) = 106603456261478718428791741418377114066
f(5) = 112987367096901987443099463793147831336
~~~~

The first byte of each share specifies the recovery information (quorum, x value), the
remaining bytes specify the share value in network byte order:

~~~~
f(1) = 
  30 46 1B 88  87 F7 A1 7D  A0 D6 37 E1  18 C8 BA 20
  03
f(2) = 
  31 C8 C0 8E  CE 96 B8 02  99 92 AA D2  2B 28 60 8F
  D9
f(3) = 
  32 21 73 12  B1 4C 87 77  6F 16 F3 92  87 60 E4 2A
  FC
f(4) = 
  33 50 33 14  30 19 0F DC  21 63 12 22  2D 72 44 F1
  D2
f(5) = 
  34 55 00 93  4A FC 51 30  B0 77 06 81  1D 5C 82 E4
  28
~~~~

The UDF presentation of the key shares is thus:

~~~~
f(1) = SAYE-MG4I-Q732-C7NA-2Y36-CGGI-XIQA-G
f(2) = SAY4-RQEO-Z2LL-QAUZ-SKVN-EKZI-MCH5-S
f(3) = SAZC-C4YS-WFGI-O53P-C3ZZ-FB3A-4QVP-Y
f(4) = SAZV-AMYU-GAMQ-7XBB-MMJC-ELLS-ITY5-E
f(5) = SA2F-KAET-JL6F-CMFQ-O4DI-CHK4-QLSC-Q
~~~~

To recover the value f(0) from any three shares, we need to fit a polynomial curve to 
the three points and use it to calculate the value at x=0 using the Lagrange polynomial
basis.
