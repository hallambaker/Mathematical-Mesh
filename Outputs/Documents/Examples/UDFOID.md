
Given the following Ed25519 public key:

~~~~

  DF 3D 69 68  C5 85 02 3F  4C 9A 7C 67  19 96 7B DB
  4E FB 81 3F  41 E7 E4 D4  7A E5 1F 71  BB 9D 7B A4
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  DF 3D 69 68  C5 85 02 3F  4C 9A 7C 67  19 96 7B DB
  4E FB 81 3F  41 E7 E4 D4  7A E5 1F 71  BB 9D 7B A4
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQN-6PLJ-NDCY-KAR7-JSNH-Y
        ZYZ-SZ55-WTX3-QE7U-DZ7E-2R5O-KH3R-XOOX-XJA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDGP-K4DF-G57R-R3BX-RFEE-LTPM-PY5V
~~~~
