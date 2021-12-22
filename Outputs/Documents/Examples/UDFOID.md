
Given the following Ed25519 public key:

~~~~

  9D 30 FC 0E  89 F2 71 AA  F3 AE 0B A5  50 CD 6B 59
  54 00 C9 95  63 84 0A A0  07 4A 48 93  8C 11 E1 E4
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  9D 30 FC 0E  89 F2 71 AA  F3 AE 0B A5  50 CD 6B 59
  54 00 C9 95  63 84 0A A0  07 4A 48 93  8C 11 E1 E4
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQJ-2MH4-B2E7-E4NK-6OXA-X
        JKQ-ZVVV-SVAA-ZGKW-HBAK-UADU-USET-RQI6-DZA
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MC4Q-QOEC-IOAT-FEQB-DTEA-OTBD-MQFB
~~~~
