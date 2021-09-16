
Given the following Ed25519 public key:

~~~~

  57 01 4A 32  33 8A 40 D6  6E 34 93 B8  A2 B4 CE 88
  35 AC B5 87  22 31 3C 13  3D 6D 3F 5D  61 82 70 57
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  57 01 4A 32  33 8A 40 D6  6E 34 93 B8  A2 B4 CE 88
  35 AC B5 87  22 31 3C 13  3D 6D 3F 5D  61 82 70 57
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQF-OAKK-GIZY-UQGW-NY2J-H
        OFC-WTHI-QNNM-WWDS-EMJ4-CM6W-2P25-MGBH-AVY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCOY-YBEF-PLXH-ORWD-4SPG-JWDQ-WISP
~~~~
