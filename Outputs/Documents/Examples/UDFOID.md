
Given the following Ed25519 public key:

~~~~

  BD 89 56 D8  EB 71 0F B2  F7 05 7B 9A  77 ED DE 21
  41 77 C3 88  95 0E 85 70  1C 4E D4 19  4C DB 7C C0
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  BD 89 56 D8  EB 71 0F B2  F7 05 7B 9A  77 ED DE 21
  41 77 C3 88  95 0E 85 70  1C 4E D4 19  4C DB 7C C0
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQL-3CKW-3DVX-CD5S-64CX-X
        GTX-5XPC-CQLX-YOEJ-KDUF-OAOE-5VAZ-JTNX-ZQA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDRA-JLK7-PBZQ-MQ5R-WDXZ-B37Y-WFWA
~~~~
