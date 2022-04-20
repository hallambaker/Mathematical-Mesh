
Given the following Ed25519 public key:

~~~~

  AB DB B8 C3  BC B9 A1 34  E6 DB 4D 69  3D AB F5 B4
  27 E0 E2 44  75 84 42 59  41 9F 40 EE  32 E9 82 92
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  AB DB B8 C3  BC B9 A1 34  E6 DB 4D 69  3D AB F5 B4
  27 E0 E2 44  75 84 42 59  41 9F 40 EE  32 E9 82 92
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQK-XW5Y-YO6L-TIJU-43NU-2
        2J5-VP23-IJ7A-4JCH-LBCC-LFAZ-6QHO-GLUY-FEQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDGT-32T4-MBOH-S5XB-7THD-VD6U-4NOU
~~~~
