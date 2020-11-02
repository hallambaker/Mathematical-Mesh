
Given the following Ed25519 public key:

~~~~

  79 B2 E8 8D  6D FD A7 B3  73 0D 85 C4  85 96 D3 45
  27 01 86 14  97 F5 80 71  EC 5B A8 D4  08 B1 44 2D
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  79 B2 E8 8D  6D FD A7 B3  73 0D 85 C4  85 96 D3 45
  27 01 86 14  97 F5 80 71  EC 5B A8 D4  08 B1 44 2D
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQH-TMXI-RVW7-3J5T-OMGY-L
        REF-S3JU-KJYB-QYKJ-P5MA-OHWF-XKGU-BCYU-ILI
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MCXA-UZTB-U6JB-5TVG-OH3L-EABX-QGLJ
~~~~
