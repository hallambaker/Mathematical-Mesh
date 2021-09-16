
Given the following Ed25519 public key:

~~~~

  3F 49 85 14  1C A9 F0 2D  F1 E4 71 29  CC 8F 5B EE
  4A 03 31 E1  68 71 61 28  44 F6 E7 7A  E1 2A 6D 2A
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  3F 49 85 14  1C A9 F0 2D  F1 E4 71 29  CC 8F 5B EE
  4A 03 31 E1  68 71 61 28  44 F6 E7 7A  E1 2A 6D 2A
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQD-6SMF-CQOK-T4BN-6HSH-C
        KOM-R5N6-4SQD-GHQW-Q4LB-FBCP-NZ32-4EVG-2KQ
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDFQ-QLXC-TUZE-6I7I-LQID-UIYR-FSCU
~~~~
