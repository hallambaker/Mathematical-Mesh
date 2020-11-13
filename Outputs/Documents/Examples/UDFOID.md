
Given the following Ed25519 public key:

~~~~

  88 C9 58 14  96 B3 B6 A7  B4 C5 44 5B  74 00 0E E6
  80 BF 14 7B  00 D7 A7 44  0F 29 80 D0  39 B1 A7 7D
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  88 C9 58 14  96 B3 B6 A7  B4 C5 44 5B  74 00 0E E6
  80 BF 14 7B  00 D7 A7 44  0F 29 80 D0  39 B1 A7 7D
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQI-RSKY-CSLL-HNVH-WTCU-I
        W3U-AAHO-NAF7-CR5Q-BV5H-IQHS-TAGQ-HGY2-O7I
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MAML-LLIN-4GRS-IO6P-E6GW-KTEK-ODN3
~~~~
