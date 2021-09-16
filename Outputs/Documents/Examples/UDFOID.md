
Given the following Ed25519 public key:

~~~~

  78 4C B4 10  95 B4 71 72  27 41 08 9C  66 FF 82 B6
  43 B7 1E 10  D1 42 7F 99  EF B1 DE 0E  7E E1 01 C3
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  78 4C B4 10  95 B4 71 72  27 41 08 9C  66 FF 82 B6
  43 B7 1E 10  D1 42 7F 99  EF B1 DE 0E  7E E1 01 C3
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQH-QTFU-CCK3-I4LS-E5AQ-R
        HDG-76BL-MQ5X-DYIN-CQT7-THX3-DXQO-P3QQ-DQY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MDFK-N2LC-FNRS-EMJ5-QS34-2YML-EI4F
~~~~
