
Given the following Ed25519 public key:

~~~~

  95 BA F8 CE  53 54 B3 92  3E 18 63 86  6E 0F 77 4F
  E0 99 C4 4B  A4 AC 9B 76  5C 63 76 BE  3B 65 79 03
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  95 BA F8 CE  53 54 B3 92  3E 18 63 86  6E 0F 77 4F
  E0 99 C4 4B  A4 AC 9B 76  5C 63 76 BE  3B 65 79 03
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQJ-LOXY-ZZJV-JM4S-HYMG-H
        BTO-B53U-7YEZ-YRF2-JLE3-OZOG-G5V6-HNSX-SAY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MAUA-L6SU-HXQJ-ZPXE-HT2N-K644-DKNO
~~~~
