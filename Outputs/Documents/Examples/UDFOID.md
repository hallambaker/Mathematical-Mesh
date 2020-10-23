
Given the following Ed25519 public key:

~~~~

  13 6F EE D8  CB F1 5C BE  9D 88 81 A5  4C BE 21 DF
  72 13 B1 52  90 55 5F 3C  FC F7 76 FC  CF 96 35 49
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  13 6F EE D8  CB F1 5C BE  9D 88 81 A5  4C BE 21 DF
  72 13 B1 52  90 55 5F 3C  FC F7 76 FC  CF 96 35 49
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQB-G37O-3DF7-CXF6-TWEI-DJKM-XYQ5-64QT-WFJJ-AVK7-HT6P-O5X4-Z6LD-KSI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MA2M-PTFD-AHOL-KA5G-6YFE-E24Y-BTOM
~~~~
