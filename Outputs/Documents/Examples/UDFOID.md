
Given the following Ed25519 public key:

~~~~

  38 1D 2C A1  5C E8 74 E1  50 5D 27 5A  BC A4 D7 64
  8C 27 DD 4F  2A 7D A7 75  15 35 F0 F4  29 1F 7C A7
~~~~

The equivalent DER encoding is:

~~~~

  30 2E 30 07  06 03 2B 65  70 05 00 03  23 00 04 20
  38 1D 2C A1  5C E8 74 E1  50 5D 27 5A  BC A4 D7 64
  8C 27 DD 4F  2A 7D A7 75  15 35 F0 F4  29 1F 7C A7
~~~~

To encode this key as a UDF OID sequence we prepend the value OID
and convert to Base32:

~~~~
OID:        OAYC-4MAH-AYBS-WZLQ-AUAA-GIYA-AQQD-QHJM-UFOO-Q5HB-KBOS-O
        WV4-UTLW-JDBH-3VHS-U7NH-OUKT-L4HU-FEPX-ZJY
~~~~

The corresponding UDF content digest value is more compact and allows us to identify the 
key unambiguously but does not provide the value:

~~~~
MALR-MJJ7-FZZB-RJWW-I6V7-KRFR-L2PW
~~~~
