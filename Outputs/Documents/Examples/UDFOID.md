
Given the following Ed25519 public key:

~~~~

  2A D5 D5 92  D2 E8 D0 CB  93 4D 0C 5A  25 27 94 91
  15 8B B6 3B  71 5C 00 69  B2 8C E0 D2  88 45 19 59
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  2A D5 D5 92  D2 E8 D0 CB  93 4D 0C 5A  25 27 94 91
  15 8B B6 3B  71 5C 00 69  B2 8C E0 D2  88 45 19 59
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQC-VVOV-SLJO-RUGL-SNGQ-Y
        WRF-E6KJ-CFML-WY5X-CXAA-NGZI-ZYGS-RBCR-SWI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDAM-JWIR-477C-3OUL-FVZH-AAZK-2ID3
~~~~
