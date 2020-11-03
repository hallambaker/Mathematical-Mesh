
Given the following Ed25519 public key:

~~~~

  E2 D3 5B A8  3A 6D 74 AF  B8 F0 6D 5F  F3 08 61 83
  9E 79 4C D1  B4 D9 89 EF  64 A6 5D 75  CA E4 75 90
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  E2 D3 5B A8  3A 6D 74 AF  B8 F0 6D 5F  F3 08 61 83
  9E 79 4C D1  B4 D9 89 EF  64 A6 5D 75  CA E4 75 90
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQO-FU23-VA5G-25FP-XDYG-2
        X7T-BBQY-HHTZ-JTI3-JWMJ-55SK-MXLV-ZLSH-LEA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCLI-OBEN-NYKT-QSAP-BUS2-262S-FRZA
~~~~
