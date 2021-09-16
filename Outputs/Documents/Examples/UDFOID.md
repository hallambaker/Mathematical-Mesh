
Given the following Ed25519 public key:

~~~~

  9F E5 E4 8A  89 5E 31 31  44 67 EA 97  3C 82 E2 16
  D7 0A 79 E6  2E 9E FA E1  EE 0B B0 FD  52 81 A9 B0
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  9F E5 E4 8A  89 5E 31 31  44 67 EA 97  3C 82 E2 16
  D7 0A 79 E6  2E 9E FA E1  EE 0B B0 FD  52 81 A9 B0
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQJ-7ZPE-RKEV-4MJR-IRT6-V
        FZ4-QLRB-NVYK-PHTC-5HX2-4HXA-XMH5-KKA2-TMA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MB2B-QSZH-2A6F-RAKF-KAJO-3RSW-2IOM
~~~~
