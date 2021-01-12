
Given the following Ed25519 public key:

~~~~

  B0 11 9D 96  C1 64 99 86  8F 29 1E 59  EA E5 01 FC
  DC 17 61 76  12 E5 D0 80  2D 8B 35 5C  C5 22 EA 49
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  B0 11 9D 96  C1 64 99 86  8F 29 1E 59  EA E5 01 FC
  DC 17 61 76  12 E5 D0 80  2D 8B 35 5C  C5 22 EA 49
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQL-AEM5-S3AW-JGMG-R4UR-4
        WPK-4UA7-ZXAX-MF3B-FZOQ-QAWY-WNK4-YURO-USI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDJK-E4NV-P4ZR-VIJB-NKXQ-WMPR-BOSR
~~~~
