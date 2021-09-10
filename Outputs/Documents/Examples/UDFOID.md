
Given the following Ed25519 public key:

~~~~

  80 FF 80 47  CD 19 CA 82  6E AD F6 3F  36 18 11 54
  9D C3 F5 14  46 63 D2 EF  99 7E 0C DB  E2 2D 29 00
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  80 FF 80 47  CD 19 CA 82  6E AD F6 3F  36 18 11 54
  9D C3 F5 14  46 63 D2 EF  99 7E 0C DB  E2 2D 29 00
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQI-B74A-I7GR-TSUC-N2W7-M
        PZW-DAIV-JHOD-6UKE-MY6S-56MX-4DG3-4IWS-SAA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MBNW-VRQE-BVX3-7KUQ-72JJ-FVEO-VTQB
~~~~
