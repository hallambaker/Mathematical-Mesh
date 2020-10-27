
Given the following Ed25519 public key:

~~~~

  D9 93 8F E2  B5 BC 37 69  84 0C 45 E9  AA 4D 8A AE
  D0 B0 5D 73  CE B5 CE ED  8D 05 60 4C  7C 2C 51 26
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  D9 93 8F E2  B5 BC 37 69  84 0C 45 E9  AA 4D 8A AE
  D0 B0 5D 73  CE B5 CE ED  8D 05 60 4C  7C 2C 51 26
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQN-TE4P-4K23-YN3J-QQGE-L2NK-JWFK-5UFQ-LVZ4-5NOO-5WGQ-KYCM-PQWF-CJQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCZA-LGEZ-UHD6-5ILK-YQOJ-DMG7-CI4U
~~~~
